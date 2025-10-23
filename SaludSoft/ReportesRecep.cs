using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;                          
using System.Runtime.InteropServices;        
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Printing;               //para imprimir

namespace SaludSoft
{
    public partial class ReportesRecep : Form
    {
        // ==== Colores ProgressBar (1=Verde, 2=Rojo, 3=Amarillo) ====
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        private const uint PBM_SETSTATE = 0x0410 + 16;
        private static void SetPBState(ProgressBar pb, int state) =>
            SendMessage(pb.Handle, PBM_SETSTATE, (IntPtr)state, IntPtr.Zero);

        private string _estadoActual = "Confirmado";
        private bool _detalleVisible = false;

        // --- para imprimir ---
        private PrintDocument _pd;
        private Bitmap _captureBmp;

        public ReportesRecep()
        {
            InitializeComponent();

            Load += ReportesRecep_Load;
            btActualizar.Click += btActualizar_Click;
            btnVolver.Click += btnVolver_Click;

          
            if (this.Controls.Find("btnImprimir", true).FirstOrDefault() is Button btnImp)
                btnImp.Click += btnImprimir_Click;

            WireCardClicks();
        }

        //LOAD
        private void ReportesRecep_Load(object sender, EventArgs e)
        {
            
            dtpPeriodo.Format = DateTimePickerFormat.Custom;
            dtpPeriodo.CustomFormat = "MMMM yyyy";
            dtpPeriodo.ShowUpDown = true;
            dtpPeriodo.Value = DateTime.Today;
            dtpHasta.Format = DateTimePickerFormat.Custom;
            dtpHasta.CustomFormat = "MMMM yyyy";
            dtpHasta.ShowUpDown = true;
            dtpHasta.ShowCheckBox = true;
            dtpHasta.Checked = false;
            lFechaPeriodo.Text = "Fecha Desde:";
            lFechaHasta.Text = "Fecha Hasta:";
            lReportesMes.Text = "Reporte mensual";

            EstiloBasico();

            gbDetalle.Visible = false;
            _detalleVisible = false;

            RefrescarTodo();
            ReordenarSecciones(false);
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            RefrescarTodo();
            _detalleVisible = false;
            ReordenarSecciones(false);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Hide();
            try
            {
                using (var frm = new SaludSoft())   
                    frm.ShowDialog(this);
            }
            finally
            {
                Close(); 
            }
        }

        //RANGO FECHAS Y BD 
        // Si dtpHasta.Checked -> usa [mes dede dtpPeriodo, MES(dtpHasta)+1)
        // Si no, usa SOLO el mes de dtpPeriodo.
        private (DateTime desde, DateTime hastaEx) RangoActual()
        {
            var desde = new DateTime(dtpPeriodo.Value.Year, dtpPeriodo.Value.Month, 1);
            if (dtpHasta.Checked)
            {
                var hastaMes = new DateTime(dtpHasta.Value.Year, dtpHasta.Value.Month, 1);
                var hastaEx = hastaMes.AddMonths(1);
                if (hastaEx <= desde) hastaEx = desde.AddMonths(1);
                return (desde, hastaEx);
            }
            return (desde, desde.AddMonths(1));
        }

        private DataTable GetTable(string sql, Action<SqlCommand> bind)
        {
            using (var cn = Conexion.GetConnection())
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.SelectCommand.CommandTimeout = 30;
                bind?.Invoke(da.SelectCommand);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private int GetScalarInt(string sql, Action<SqlCommand> bind)
        {
            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.CommandTimeout = 30;
                bind?.Invoke(cmd);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        //UI / ESTILO
        private void WireCardClicks()
        {
            void makeClickable(Control root, EventHandler onClick)
            {
                root.Cursor = Cursors.Hand;
                root.Click += onClick;
                foreach (Control c in root.Controls) { c.Cursor = Cursors.Hand; c.Click += onClick; }
            }
            makeClickable(panel2, (s, e) => ToggleDetalle("Confirmado"));
            makeClickable(panel3, (s, e) => ToggleDetalle("Pendiente"));
            makeClickable(panel4, (s, e) => ToggleDetalle("Cancelado"));
        }

        private void EstiloBasico()
        {
            // Layout tipo “stack” vertical
            tlKpis.Dock = DockStyle.Top;
            gbDetalle.Dock = DockStyle.Top;
            gbTopMedicos.Dock = DockStyle.Top;
            AutoScroll = true;

            // ProgressBars con color
            foreach (var pb in new[] { pbTurnosConfirmados, pbTP, progressBar1 })
            {
                pb.Style = ProgressBarStyle.Continuous;
                pb.MarqueeAnimationSpeed = 0;
            }
            SetPBState(pbTurnosConfirmados, 1); // verde
            SetPBState(pbTP, 3); // amarillo
            SetPBState(progressBar1, 2); // rojo

            // DGV Detalle
            dgvDetalle.AutoGenerateColumns = false;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.EnableHeadersVisualStyles = false;
            dgvDetalle.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvDetalle.ColumnHeadersDefaultCellStyle.ForeColor = Color.DimGray;
            dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 247);
            if (dgvDetalle.Columns.Contains("colFechaHora"))
            {
                dgvDetalle.Columns["colFechaHora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvDetalle.Columns["colFechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            // DGV Ranking
            dgvRankingMedicos.AutoGenerateColumns = false;
            dgvRankingMedicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRankingMedicos.ReadOnly = true;
            dgvRankingMedicos.RowHeadersVisible = false;
            dgvRankingMedicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRankingMedicos.EnableHeadersVisualStyles = false;
            dgvRankingMedicos.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvRankingMedicos.ColumnHeadersDefaultCellStyle.ForeColor = Color.DimGray;

            // Charts base
            if (chPieEstados.ChartAreas.Count == 0) chPieEstados.ChartAreas.Add(new ChartArea("ca"));
            if (chPieEstados.Legends.Count == 0)
                chPieEstados.Legends.Add(new Legend("lg") { Docking = Docking.Bottom, Alignment = StringAlignment.Center });
            chPieEstados.Series.Clear();
            var seriePie = new Series("Estados")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                ChartArea = "ca",
                Legend = "lg",
            };
            seriePie["PieLabelStyle"] = "Outside";
            seriePie["PieLineColor"] = "Gray";
            seriePie.Label = "#VALX #PERCENT{P0}";
            chPieEstados.Series.Add(seriePie);

            if (chTopMedicos.ChartAreas.Count == 0) chTopMedicos.ChartAreas.Add(new ChartArea("caTop"));
            if (chTopMedicos.Series.Count == 0) chTopMedicos.Series.Add(new Series("Consultas"));
            chTopMedicos.Series["Consultas"].ChartType = SeriesChartType.Column;
            var ca = chTopMedicos.ChartAreas["caTop"];
            ca.AxisX.MajorGrid.Enabled = false;
            ca.AxisY.MajorGrid.Enabled = false;
            ca.AxisX.LineWidth = 0;
            ca.AxisY.LineWidth = 0;
            ca.AxisX.LabelStyle.Font = new Font("Segoe UI", 9f);
            ca.AxisY.LabelStyle.Font = new Font("Segoe UI", 9f);
            ca.AxisX.Interval = 1;
            var s = chTopMedicos.Series["Consultas"];
            s.Color = Color.FromArgb(38, 166, 91);
            s.BorderWidth = 0;
            s.IsValueShownAsLabel = true;
            s.LabelForeColor = Color.DimGray;
            s.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
        }
        // ===== Helpers para Chart =====
        private static string EnsureChartArea(Chart chart, string desiredName)
        {
            // Si ya existe, devolver
            if (chart.ChartAreas.IndexOf(desiredName) >= 0)
                return desiredName;

            // Si no hay ninguna, crear con ese nombre
            if (chart.ChartAreas.Count == 0)
            {
                chart.ChartAreas.Add(new ChartArea(desiredName));
                return desiredName;
            }

            // Si hay alguna (ej. "ChartArea1"), la renombramos a desiredName
            chart.ChartAreas[0].Name = desiredName;
            return desiredName;
        }

        private static string EnsureLegend(Chart chart, string desiredName)
        {
            if (chart.Legends.IndexOf(desiredName) >= 0)
                return desiredName;

            if (chart.Legends.Count == 0)
            {
                chart.Legends.Add(new Legend(desiredName));
                return desiredName;
            }

            chart.Legends[0].Name = desiredName;
            return desiredName;
        }

        private static Series EnsureSeries(Chart chart, string seriesName, SeriesChartType type, string areaName, string legendName)
        {
            Series s;
            if (chart.Series.IndexOf(seriesName) >= 0)
                s = chart.Series[seriesName];
            else
            {
                s = new Series(seriesName);
                chart.Series.Add(s);
            }

            s.ChartType = type;
            s.ChartArea = areaName;
            s.Legend = legendName;
            return s;
        }

        private void ReordenarSecciones(bool mostrarDetalle)
        {
            SuspendLayout();
            if (mostrarDetalle)
            {
                gbDetalle.Visible = true;
                tlKpis.BringToFront();
                gbDetalle.BringToFront();
                gbTopMedicos.BringToFront();
            }
            else
            {
                gbDetalle.Visible = false;
                tlKpis.BringToFront();
                gbTopMedicos.BringToFront();
            }
            ResumeLayout();
        }

        // REFRESH GLOBAL
        private void RefrescarTodo()
        {
            CargarKpisYTorta();
            CargarTopMedicosYRanking();
        }

        //KPI + TORTA 
        private void CargarKpisYTorta()
        {
            var (desde, hastaEx) = RangoActual();

            string sqlEstados = @"
SELECT t.estado AS Estado, COUNT(*) AS Cant
FROM dbo.Turnos t
WHERE t.fecha >= @d AND t.fecha < @h
GROUP BY t.estado;";

            string sqlTotal = @"
SELECT COUNT(*) AS TotalMes
FROM dbo.Turnos
WHERE fecha >= @d AND fecha < @h;";

            var dtEstados = GetTable(sqlEstados, c => { c.Parameters.AddWithValue("@d", desde); c.Parameters.AddWithValue("@h", hastaEx); });
            int total = GetTable(sqlTotal, c => { c.Parameters.AddWithValue("@d", desde); c.Parameters.AddWithValue("@h", hastaEx); })
                        .AsEnumerable().Select(r => r.Field<int>("TotalMes")).DefaultIfEmpty(0).First();

            int conf = dtEstados.AsEnumerable().Where(r => r.Field<string>("Estado").Equals("Confirmado", StringComparison.OrdinalIgnoreCase))
                                               .Select(r => r.Field<int>("Cant")).DefaultIfEmpty(0).First();
            int pend = dtEstados.AsEnumerable().Where(r => r.Field<string>("Estado").Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                                               .Select(r => r.Field<int>("Cant")).DefaultIfEmpty(0).First();
            int canc = dtEstados.AsEnumerable().Where(r => r.Field<string>("Estado").Equals("Cancelado", StringComparison.OrdinalIgnoreCase))
                                               .Select(r => r.Field<int>("Cant")).DefaultIfEmpty(0).First();

            // KPI + colores
            SetCard(pbTurnosConfirmados, lbValor, lbTituloConfirmado, "Turnos Confirmados", conf, total, 1);
            SetCard(pbTP, lbValorTP, lbTurnosPendientes, "Turnos Pendientes", pend, total, 3);
            SetCard(progressBar1, lbValorTC, lbTurnosCancelados, "Turnos Cancelados", canc, total, 2);

            // Torta
            var s = chPieEstados.Series["Estados"];
            s.Points.Clear();
            foreach (DataRow r in dtEstados.Rows)
            {
                var dp = new DataPoint { AxisLabel = r.Field<string>("Estado") };
                dp.YValues = new[] { Convert.ToDouble(r.Field<int>("Cant")) };
                dp.ToolTip = "#VALX: #VAL";
                s.Points.Add(dp);
            }
        }

        private void SetCard(ProgressBar pb, Label lbNumero, Label lbTitulo, string titulo, int valor, int total, int colorState)
        {
            lbTitulo.Text = titulo;
            lbNumero.Text = valor.ToString();
            pb.Maximum = Math.Max(total, 1);
            pb.Value = Math.Min(valor, pb.Maximum);
            SetPBState(pb, colorState);
        }

        // DETALLE (toggle con card)
        private void ToggleDetalle(string estado)
        {
            if (_detalleVisible && _estadoActual.Equals(estado, StringComparison.OrdinalIgnoreCase))
            {
                _detalleVisible = false;
                ReordenarSecciones(false);
                return;
            }

            _estadoActual = estado;
            CargarDetalleEstado();
            gbDetalle.Text = $"Detalle de turnos (mostrando: {estado})";

            _detalleVisible = true;
            ReordenarSecciones(true);
            ScrollControlIntoView(gbDetalle);
        }

        private void CargarDetalleEstado()
        {
            var (desde, hastaEx) = RangoActual();

            string sql = @"
SELECT 
    (pa.apellido + ', ' + pa.nombre)          AS Paciente,
    (pr.apellido  + ' ' + pr.nombre)          AS Profesional,
    es.nombre                                  AS Especialidad,
    FORMAT(t.fecha,'dd/MM/yyyy HH:mm')         AS [Fecha/Hora],
    t.motivo                                   AS Motivo
FROM dbo.Turnos t
INNER JOIN dbo.Paciente pa                ON pa.id_paciente = t.id_paciente
INNER JOIN dbo.Agenda a                   ON a.id_agenda = t.id_agenda
INNER JOIN dbo.Profesional_Consultorio pc ON pc.id_profesional_consultorio = a.id_profesional_consultorio
INNER JOIN dbo.Profesional pr             ON pr.id_profesional = pc.id_profesional
INNER JOIN dbo.Especialidad es            ON es.id_especialidad = pr.id_especialidad
WHERE t.fecha >= @desde 
  AND t.fecha <  @hasta
  AND t.estado = @estado
ORDER BY t.fecha;";

            var dt = GetTable(sql, c => {
                c.Parameters.AddWithValue("@desde", desde);
                c.Parameters.AddWithValue("@hasta", hastaEx);
                c.Parameters.AddWithValue("@estado", _estadoActual);
            });

            dgvDetalle.AutoGenerateColumns = false;
            dgvDetalle.DataSource = dt;

            if (dgvDetalle.Columns.Contains("colPaciente")) dgvDetalle.Columns["colPaciente"].DataPropertyName = "Paciente";
            if (dgvDetalle.Columns.Contains("colProfesional")) dgvDetalle.Columns["colProfesional"].DataPropertyName = "Profesional";
            if (dgvDetalle.Columns.Contains("colEspecialidad")) dgvDetalle.Columns["colEspecialidad"].DataPropertyName = "Especialidad";
            if (dgvDetalle.Columns.Contains("colFechaHora")) dgvDetalle.Columns["colFechaHora"].DataPropertyName = "Fecha/Hora";
        }

        //TOP MÉDICOS + RANKING
        private void CargarTopMedicosYRanking()
        {
            var (desde, hastaEx) = RangoActual();

            string sqlTop = @"
SELECT TOP (5)
  pr.id_profesional,
  (pr.apellido + ' ' + pr.nombre) AS Medico,
  es.nombre                       AS Especialidad,
  COUNT(*)                        AS Consultas
FROM dbo.Turnos t
INNER JOIN dbo.Agenda a                   ON a.id_agenda = t.id_agenda
INNER JOIN dbo.Profesional_Consultorio pc ON pc.id_profesional_consultorio = a.id_profesional_consultorio
INNER JOIN dbo.Profesional pr             ON pr.id_profesional = pc.id_profesional
INNER JOIN dbo.Especialidad es            ON es.id_especialidad = pr.id_especialidad
WHERE t.fecha >= @desde AND t.fecha < @hasta
  AND t.estado = 'Confirmado'
GROUP BY pr.id_profesional, pr.apellido, pr.nombre, es.nombre
ORDER BY Consultas DESC;";

            var dtTop = GetTable(sqlTop, c => {
                c.Parameters.AddWithValue("@desde", desde);
                c.Parameters.AddWithValue("@hasta", hastaEx);
            });

            var s = chTopMedicos.Series["Consultas"];
            s.Points.Clear();
            foreach (DataRow r in dtTop.Rows)
            {
                var dp = new DataPoint { AxisLabel = r["Medico"].ToString() };
                dp.YValues = new[] { Convert.ToDouble(r["Consultas"]) };
                dp.Label = "#VAL";
                dp.ToolTip = "#VALX: #VAL consultas";
                s.Points.Add(dp);
            }

            int totalConf = GetScalarInt(@"
SELECT COUNT(*) FROM dbo.Turnos
WHERE fecha >= @d AND fecha < @h AND estado='Confirmado';",
                c => { c.Parameters.AddWithValue("@d", desde); c.Parameters.AddWithValue("@h", hastaEx); });

            var dtRanking = new DataTable();
            dtRanking.Columns.Add("Pos", typeof(int));
            dtRanking.Columns.Add("Medico", typeof(string));
            dtRanking.Columns.Add("Especialidad", typeof(string));
            dtRanking.Columns.Add("Consultas", typeof(int));
            dtRanking.Columns.Add("Porcentaje", typeof(int));

            int pos = 1;
            foreach (DataRow r in dtTop.Rows)
            {
                int cant = Convert.ToInt32(r["Consultas"]);
                int pct = totalConf == 0 ? 0 : (cant * 100 / totalConf);
                dtRanking.Rows.Add(pos++, r["Medico"], r["Especialidad"], cant, pct);
            }

            dgvRankingMedicos.AutoGenerateColumns = false;
            dgvRankingMedicos.DataSource = dtRanking;

            if (dgvRankingMedicos.Columns.Contains("colPos")) dgvRankingMedicos.Columns["colPos"].DataPropertyName = "Pos";
            if (dgvRankingMedicos.Columns.Contains("colMedico")) dgvRankingMedicos.Columns["colMedico"].DataPropertyName = "Medico";
            if (dgvRankingMedicos.Columns.Contains("colEspec")) dgvRankingMedicos.Columns["colEspec"].DataPropertyName = "Especialidad";
            if (dgvRankingMedicos.Columns.Contains("colConsultas")) dgvRankingMedicos.Columns["colConsultas"].DataPropertyName = "Consultas";
            if (dgvRankingMedicos.Columns.Contains("colPorcentaje")) dgvRankingMedicos.Columns["colPorcentaje"].DataPropertyName = "Porcentaje";
        }

        // RANKING LOOK & FEEL
        private void dgvRankingMedicos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = (DataGridView)sender;
            var col = grid.Columns["colPos"];
            if (col == null) return;

            var cellRect = grid.GetCellDisplayRectangle(col.Index, e.RowIndex, true);
            var cx = cellRect.Left + 16;
            var cy = cellRect.Top + cellRect.Height / 2;
            int radius = 14;

            using (var b = new SolidBrush(Color.FromArgb(225, 243, 235)))
            using (var p = new Pen(Color.FromArgb(38, 166, 91)))
            using (var f = new Font("Segoe UI", 8f, FontStyle.Bold))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillEllipse(b, cx - radius, cy - radius, radius * 2, radius * 2);
                e.Graphics.DrawEllipse(p, cx - radius, cy - radius, radius * 2, radius * 2);
                var text = (e.RowIndex + 1).ToString();
                e.Graphics.DrawString(text, f, Brushes.DarkGreen, new RectangleF(cx - radius, cy - radius, radius * 2, radius * 2), sf);
            }
        }

        private void dgvRankingMedicos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var grid = (DataGridView)sender;
            if (grid.Columns["colPorcentaje"] == null || e.ColumnIndex != grid.Columns["colPorcentaje"].Index) return;

            e.Handled = true;
            e.PaintBackground(e.CellBounds, true);

            int pct = 0;
            var val = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (val != null && int.TryParse(val.ToString(), out var p)) pct = Math.Max(0, Math.Min(100, p));

            var rect = e.CellBounds; rect.Inflate(-6, -8);
            var fill = rect; fill.Width = (int)(rect.Width * (pct / 100.0));

            using (var back = new SolidBrush(Color.FromArgb(238, 244, 241)))
            using (var fore = new SolidBrush(Color.FromArgb(38, 166, 91)))
            using (var pen = new Pen(Color.FromArgb(210, 223, 218)))
            using (var f = new Font("Segoe UI", 8.5f, FontStyle.Bold))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.FillRectangle(back, rect);
                e.Graphics.FillRectangle(fore, fill);
                e.Graphics.DrawRectangle(pen, rect);
                e.Graphics.DrawString($"{pct}%", f, Brushes.DimGray, rect, sf);
            }
        }

        // IMPRIMIR A PDF
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog()
            {
                Title = "Guardar reporte en PDF",
                Filter = "Archivo PDF (*.pdf)|*.pdf",
                FileName = $"Reporte_{DateTime.Now:yyyyMMdd_HHmm}.pdf"
            })
            {
                if (sfd.ShowDialog(this) != DialogResult.OK) return;
                ImprimirAArchivoPdf(sfd.FileName);
                MessageBox.Show("Reporte exportado correctamente.", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Captura visual de todo el formulario
        private Bitmap CapturarFormulario()
        {
            var bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            this.DrawToBitmap(bmp, new Rectangle(Point.Empty, this.ClientSize));
            return bmp;
        }

        // Imprime con la impresora del sistema "Microsoft Print to PDF"
        private void ImprimirAArchivoPdf(string path)
        {
            _captureBmp = CapturarFormulario();

            _pd = new PrintDocument();
            _pd.DefaultPageSettings.Landscape = true; 
            _pd.PrintPage += (s, e) =>
            {
                // Ajustar imagen a la página manteniendo proporción
                var page = e.MarginBounds;
                float ratio = Math.Min(page.Width / (float)_captureBmp.Width, page.Height / (float)_captureBmp.Height);
                var w = (int)(_captureBmp.Width * ratio);
                var h = (int)(_captureBmp.Height * ratio);
                var dest = new Rectangle(page.Left + (page.Width - w) / 2, page.Top + (page.Height - h) / 2, w, h);
                e.Graphics.DrawImage(_captureBmp, dest);
                e.HasMorePages = false;
            };

            // Selecciona impresora PDF de Windows y guarda directamente
            _pd.PrinterSettings = new PrinterSettings
            {
                PrinterName = "Microsoft Print to PDF",
                PrintToFile = true,
                PrintFileName = path
            };

            _pd.Print();
            _captureBmp?.Dispose();
            _captureBmp = null;
        }
    }
}
