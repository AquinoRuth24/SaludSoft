using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;

namespace SaludSoft
{
    public partial class ReportesRecep : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        private const uint PBM_SETSTATE = 0x0410 + 16;
        private static void SetPBState(ProgressBar pb, int state) =>
            SendMessage(pb.Handle, PBM_SETSTATE, (IntPtr)state, IntPtr.Zero);

        private string _estadoActual = "Confirmado";
        private bool _detalleVisible = false;

        public ReportesRecep()
        {
            InitializeComponent();

            Load += ReportesRecep_Load;

            // Actualizar datos
            btActualizar.Click += (s, e) => RefrescarTodo();

            // Clicks de las 3 cards
            WireCardClicks();

            dgvRankingMedicos.RowPostPaint += dgvRankingMedicos_RowPostPaint;
            dgvRankingMedicos.CellPainting += dgvRankingMedicos_CellPainting;
        }

        // ===== LOAD =====
        private void ReportesRecep_Load(object sender, EventArgs e)
        {
            // Filtros
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
            lReportesMes.Text = "Reporte mensual";

            dgvDetalle.AutoGenerateColumns = false;
            dgvRankingMedicos.AutoGenerateColumns = false;
          
            foreach (var pb in new[] { pbTurnosConfirmados, pbTP, progressBar1 })
            {
                pb.Style = ProgressBarStyle.Continuous;
                pb.MarqueeAnimationSpeed = 0;
            }
            SetPBState(pbTurnosConfirmados, 1); 
            SetPBState(pbTP, 3);                
            SetPBState(progressBar1, 2);        

            // Charts
            var caPie = EnsureChartArea(chPieEstados, "ca");
            var lgPie = EnsureLegend(chPieEstados, "lg");
            var sPie = EnsureSeries(chPieEstados, "Estados", SeriesChartType.Pie, caPie, lgPie);
            sPie.IsValueShownAsLabel = true;
            sPie.LabelForeColor = Color.Black;
            sPie.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            sPie["PieLabelStyle"] = "Outside";
            sPie["PieLineColor"] = "Gray";
            sPie.Label = "#VALX #PERCENT{P0}";    
            sPie.LegendText = "#VALX";            

            chPieEstados.Legends[lgPie].Docking = Docking.Bottom;
            chPieEstados.Legends[lgPie].Alignment = StringAlignment.Center;

            var caTop = EnsureChartArea(chTopMedicos, "caTop");
            var sTop = EnsureSeries(chTopMedicos, "Consultas", SeriesChartType.Column, caTop, null);
            var ca = chTopMedicos.ChartAreas[caTop];
            ca.AxisX.MajorGrid.Enabled = false;
            ca.AxisY.MajorGrid.Enabled = false;
            ca.AxisX.LineWidth = 0; ca.AxisY.LineWidth = 0;
            ca.AxisX.LabelStyle.Font = new Font("Segoe UI", 9f);
            ca.AxisY.LabelStyle.Font = new Font("Segoe UI", 9f);
            ca.AxisX.Interval = 1;
            sTop.Color = Color.FromArgb(38, 166, 91);
            sTop.BorderWidth = 0;
            sTop.IsValueShownAsLabel = true;
            sTop.LabelForeColor = Color.DimGray;
            sTop.Font = new Font("Segoe UI", 9f, FontStyle.Bold);

            gbDetalle.Visible = true;
            _detalleVisible = true;

            RefrescarTodo();
            ConfigurarPie();




        }

        // ===== RANGO FECHAS =====
        private (DateTime desde, DateTime hastaEx) RangoActual()
        {
            var desde = dtpPeriodo.Value.Date;
            if (dtpHasta.Checked)
            {
                var hastaEx = dtpHasta.Value.Date.AddDays(1); // exclusivo
                if (hastaEx <= desde) hastaEx = desde.AddDays(1);
                return (desde, hastaEx);
            }
            // si no hay “hasta”, por defecto solo ese día
            return (desde, desde.AddDays(1));
        }


        // ===== BD HELPERS =====
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

        // ===== UI: CARDS =====
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

        // ===== CHART HELPERS =====
        private static string EnsureChartArea(Chart chart, string desiredName)
        {
            if (chart.ChartAreas.IndexOf(desiredName) >= 0) return desiredName;
            if (chart.ChartAreas.Count == 0)
            {
                chart.ChartAreas.Add(new ChartArea(desiredName));
                return desiredName;
            }
            chart.ChartAreas[0].Name = desiredName;
            return desiredName;
        }
        private static string EnsureLegend(Chart chart, string desiredName)
        {
            if (chart.Legends.IndexOf(desiredName) >= 0) return desiredName;
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
            Series s = chart.Series.IndexOf(seriesName) >= 0
                ? chart.Series[seriesName]
                : new Series(seriesName);

            if (chart.Series.IndexOf(seriesName) < 0)
                chart.Series.Add(s);

            s.ChartType = type;
            s.ChartArea = areaName;

            if (!string.IsNullOrWhiteSpace(legendName))
            {
                if (chart.Legends.IndexOf(legendName) < 0)
                    chart.Legends.Add(new Legend(legendName));
                s.Legend = legendName;
                s.IsVisibleInLegend = true;
            }
            else
            {
                s.IsVisibleInLegend = false;
            }
            return s;
        }

        // ===== REFRESH =====
        private void RefrescarTodo()
        {
            CargarKpisYTorta();
            CargarTopMedicosYRanking();
            if (_detalleVisible) CargarDetalleEstado();
        }

        // KPI + TORTA
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

            var dtEstados = GetTable(sqlEstados, c => {
                c.Parameters.AddWithValue("@d", desde);
                c.Parameters.AddWithValue("@h", hastaEx);
            });

            int total = GetTable(sqlTotal, c => {
                c.Parameters.AddWithValue("@d", desde);
                c.Parameters.AddWithValue("@h", hastaEx);
            }).AsEnumerable().Select(r => r.Field<int>("TotalMes")).DefaultIfEmpty(0).First();

            // Obtener valores
            int conf = dtEstados.AsEnumerable()
                .Where(r => r.Field<string>("Estado").Equals("Confirmado", StringComparison.OrdinalIgnoreCase))
                .Select(r => r.Field<int>("Cant")).DefaultIfEmpty(0).First();

            int pend = dtEstados.AsEnumerable()
                .Where(r => r.Field<string>("Estado").Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                .Select(r => r.Field<int>("Cant")).DefaultIfEmpty(0).First();

            int canc = dtEstados.AsEnumerable()
                .Where(r => r.Field<string>("Estado").Equals("Cancelado", StringComparison.OrdinalIgnoreCase))
                .Select(r => r.Field<int>("Cant")).DefaultIfEmpty(0).First();

            // Actualizar KPI Cards
            SetCard(pbTurnosConfirmados, lbValor, lbTituloConfirmado, "Turnos Confirmados", conf, total, 1);
            SetCard(pbTP, lbValorTP, lbTurnosPendientes, "Turnos Pendientes", pend, total, 3);
            SetCard(progressBar1, lbValorTC, lbTurnosCancelados, "Turnos Cancelados", canc, total, 2);

            LlenarPie(conf, pend, canc);

        }


        private void SetCard(ProgressBar pb, Label lbNumero, Label lbTitulo, string titulo, int valor, int total, int colorState)
        {
            lbTitulo.Text = titulo;
            lbNumero.Text = valor.ToString();
            pb.Maximum = Math.Max(total, 1);
            pb.Value = Math.Min(valor, pb.Maximum);
            SetPBState(pb, colorState);
        }

        // ===== DETALLE (toggle) =====
        private void ToggleDetalle(string estado)
        {
            if (_detalleVisible && _estadoActual.Equals(estado, StringComparison.OrdinalIgnoreCase))
            {
                _detalleVisible = false;
                gbDetalle.Visible = false;
                return;
            }

            _estadoActual = estado;
            CargarDetalleEstado();
            gbDetalle.Text = $"Detalle de turnos (mostrando: {estado})";
            _detalleVisible = true;
            gbDetalle.Visible = true;
        }

        private void CargarDetalleEstado()
        {
            var (desde, hastaEx) = RangoActual();

            string sql = @"
            SELECT 
                (pa.apellido + ', ' + pa.nombre)   AS Paciente,
                (pr.apellido + ' ' + pr.nombre)    AS Profesional,
                es.nombre                          AS Especialidad,
                FORMAT(t.fecha,'dd/MM/yyyy HH:mm') AS [Fecha/Hora]
            FROM dbo.Turnos t
            INNER JOIN dbo.Paciente pa                ON pa.id_paciente = t.id_paciente
            INNER JOIN dbo.Agenda a                   ON a.id_agenda = t.id_agenda
            INNER JOIN dbo.Profesional_Consultorio pc ON pc.id_profesional_consultorio = a.id_profesional_consultorio
            INNER JOIN dbo.Profesional pr             ON pr.id_profesional = pc.id_profesional
            INNER JOIN dbo.Especialidad es            ON es.id_especialidad = pr.id_especialidad
            WHERE t.fecha >= @desde AND t.fecha < @hasta AND t.estado = @estado
            ORDER BY t.fecha;";

            var dt = GetTable(sql, c =>
            {
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

        // ===== TOP MÉDICOS + RANKING =====
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
WHERE t.fecha >= @desde AND t.fecha < @hasta AND t.estado = 'Confirmado'
GROUP BY pr.id_profesional, pr.apellido, pr.nombre, es.nombre
ORDER BY Consultas DESC;";

            var dtTop = GetTable(sqlTop, c =>
            {
                c.Parameters.AddWithValue("@desde", desde);
                c.Parameters.AddWithValue("@hasta", hastaEx);
            });

            var s = EnsureSeries(chTopMedicos, "Consultas",
                SeriesChartType.Column,
                EnsureChartArea(chTopMedicos, "caTop"),
                null);
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

            dgvRankingMedicos.AutoGenerateColumns = false; // evita duplicados
            dgvRankingMedicos.DataSource = dtRanking;

            if (dgvRankingMedicos.Columns.Contains("colPos")) dgvRankingMedicos.Columns["colPos"].DataPropertyName = "Pos";
            if (dgvRankingMedicos.Columns.Contains("colMedico")) dgvRankingMedicos.Columns["colMedico"].DataPropertyName = "Medico";
            if (dgvRankingMedicos.Columns.Contains("colEspec")) dgvRankingMedicos.Columns["colEspec"].DataPropertyName = "Especialidad";
            if (dgvRankingMedicos.Columns.Contains("colConsultas")) dgvRankingMedicos.Columns["colConsultas"].DataPropertyName = "Consultas";
            if (dgvRankingMedicos.Columns.Contains("colPorcentaje")) dgvRankingMedicos.Columns["colPorcentaje"].DataPropertyName = "Porcentaje";
        }

        // ===== Estética ranking =====
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
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), f, Brushes.DarkGreen,
                    new RectangleF(cx - radius, cy - radius, radius * 2, radius * 2), sf);
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

        // ==== LAYOUT SECCIONES====
        private const int SPACING = 10; 

   
        private void LayoutSections()
        {
            
            int y = tlKpis.Bottom + SPACING;

           
            if (_detalleVisible)
            {
                gbDetalle.Visible = true;
                gbDetalle.Top = y;
                y = gbDetalle.Bottom + SPACING;
            }
            else
            {
                gbDetalle.Visible = false;
                
            }

            gbTopMedicos.Top = y;
            y = gbTopMedicos.Bottom + SPACING;

            
            var btnImprimir = Controls.Find("btnImprimir", true).FirstOrDefault() as Control;
            if (btnImprimir != null)
            {
               
                btnImprimir.Top = y;
                y = btnImprimir.Bottom + SPACING;
            }

           
            if (AutoScroll)
                AutoScrollMinSize = new Size(0, y + 20);
        }

        // ====== PIE CHART HELPERS ======
        private void ConfigurarPie()
        {
            var ca = EnsureChartArea(chPieEstados, "ca");
            var lg = EnsureLegend(chPieEstados, "lg");

            var s = EnsureSeries(chPieEstados, "Estados", SeriesChartType.Pie, ca, lg);
            s.IsValueShownAsLabel = true;
            s.Label = "#PERCENT{P0}";          
            s["PieLabelStyle"] = "Outside";    
            s["PieLineColor"] = "Gray";        
            s.LegendText = "#VALX";            

           
            chPieEstados.Legends[lg].Docking = Docking.Bottom;
            chPieEstados.Legends[lg].Alignment = StringAlignment.Center;
        }

       
        private void LlenarPie(int conf, int pend, int canc)
        {
            var s = chPieEstados.Series["Estados"];
            s.Points.Clear();

           
            var verde = Color.FromArgb(38, 166, 91);   // Confirmados
            var amarillo = Color.FromArgb(247, 202, 24);  // Pendientes
            var rojo = Color.FromArgb(231, 76, 60);   // Cancelados

            var data = new[]
            {
        ("Confirmados", conf, verde),
        ("Pendientes",  pend, amarillo),
        ("Cancelados",  canc, rojo)
    };

            int total = Math.Max(conf + pend + canc, 0);
            foreach (var item in data)
            {
                int idx = s.Points.AddY(item.Item2); 
                var p = s.Points[idx];               

                p.AxisLabel = item.Item1;           
                p.LegendText = item.Item1;           
                p.Color = item.Item3;
                p.Label = total == 0 ? "" : "#PERCENT{P0}";
                p.ToolTip = $"{item.Item1}: {item.Item2} (#PERCENT{{P0}})";
            }

        }

        private static int FindColumnIndex(DataGridView dgv, params string[] candidates)
        {
            if (dgv == null) return -1;
            // por Name
            for (int i = 0; i < dgv.Columns.Count; i++)
                if (candidates.Any(c => string.Equals(dgv.Columns[i].Name, c, StringComparison.OrdinalIgnoreCase)))
                    return i;
            // por HeaderText
            for (int i = 0; i < dgv.Columns.Count; i++)
                if (candidates.Any(c => string.Equals(dgv.Columns[i].HeaderText, c, StringComparison.OrdinalIgnoreCase)))
                    return i;
            return -1;
        }


        private DataGridView TryGetGridByEstado(string estado)
        {
            estado = (estado ?? "").ToLowerInvariant(); // "confirmado" | "pendiente" | "cancelado"
            foreach (Control c in this.Controls)
            {
                if (c is DataGridView dgv)
                {
                    string n = (dgv.Name ?? "").ToLowerInvariant();
                    if (estado.StartsWith("conf") && n.Contains("confirm")) return dgv;
                    if (estado.StartsWith("pend") && n.Contains("pend")) return dgv;
                    if (estado.StartsWith("canc") && n.Contains("cancel")) return dgv;
                }
            }
            return null;
        }
        private static string ColumnLetter(int colIndex)
        {
            string col = "";
            while (colIndex > 0)
            {
                int mod = (colIndex - 1) % 26;
                col = (char)('A' + mod) + col;
                colIndex = (colIndex - mod) / 26;
            }
            return col;
        }

        
        private (int conf, int pend, int canc) GetTotalsFromChartOrFallback()
        {
            int tConf = 0, tPend = 0, tCanc = 0;

           
            if (chPieEstados?.Series.Count > 0 && chPieEstados.Series[0].Points.Count > 0)
            {
                foreach (var p in chPieEstados.Series[0].Points)
                {
                    string lbl = (p.AxisLabel ?? p.LegendText ?? "").Trim().ToLowerInvariant();
                    int val = (int)p.YValues.FirstOrDefault();

                    if (lbl.Contains("confirm")) tConf = val;
                    else if (lbl.Contains("pend")) tPend = val;
                    else if (lbl.Contains("cancel")) tCanc = val;
                }
               
                return (tConf, tPend, tCanc);
            }

            
            int countGrid = dgvDetalle?.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow) ?? 0;
            string estado = _estadoActual?.Trim() ?? "";
            if (estado.StartsWith("conf", System.StringComparison.OrdinalIgnoreCase)) tConf = countGrid;
            else if (estado.StartsWith("pend", System.StringComparison.OrdinalIgnoreCase)) tPend = countGrid;
            else if (estado.StartsWith("canc", System.StringComparison.OrdinalIgnoreCase)) tCanc = countGrid;

            return (tConf, tPend, tCanc);
        }

        /*private int DumpGrid(Excel.Worksheet ws, DataGridView dgv, int filaInicio, int colInicio)
        {
            if (dgv == null || dgv.Rows.Count == 0) return filaInicio;

            // Cabeceras
            for (int c = 0; c < dgv.Columns.Count; c++)
            {
                ws.Cells[filaInicio, colInicio + c] = dgv.Columns[c].HeaderText;
                ((Excel.Range)ws.Cells[filaInicio, colInicio + c]).Font.Bold = true;
            }
            // Datos
            int rOut = filaInicio + 1;
            foreach (DataGridViewRow r in dgv.Rows)
            {
                if (r.IsNewRow) continue;
                for (int c = 0; c < dgv.Columns.Count; c++)
                    ws.Cells[rOut, colInicio + c] = r.Cells[c].Value?.ToString() ?? "";
                rOut++;
            }
            ((Excel.Range)ws.Columns).AutoFit();
            return rOut - 1;
        }*/
        // boton volver 
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lReportesMes_Click(object sender, EventArgs e)
        {

        }

        /*private void btnImprimir_Click(object sender, EventArgs e)
        {
            Excel.Application app = null;
            Excel.Workbook wb = null;
            Excel.Worksheet ws1 = null, ws2 = null;
            Excel.ChartObjects chartObjs1 = null, chartObjs2 = null;
            Excel.ChartObject chPieObj = null, chColObj = null;

            try
            {
                if ((dgvDetalle?.Rows.Count ?? 0) == 0 && (dgvRankingMedicos?.Rows.Count ?? 0) == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Reportes",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var (tConf, tPend, tCanc) = GetTotalsFromChartOrFallback();

                app = new Excel.Application { Visible = false };
                wb = app.Workbooks.Add(Type.Missing);

                // -------- Hoja 1: Resumen + detalle (dgvDetalle) --------
                ws1 = wb.ActiveSheet;
                ws1.Name = "Turnos por Estado";

                ws1.Cells[1, 1] = "Estado"; ws1.Cells[1, 2] = "Cantidad";
                ((Excel.Range)ws1.Range["A1", "B1"]).Font.Bold = true;

                ws1.Cells[2, 1] = "Confirmado"; ws1.Cells[2, 2] = tConf;
                ws1.Cells[3, 1] = "Pendiente"; ws1.Cells[3, 2] = tPend;
                ws1.Cells[4, 1] = "Cancelado"; ws1.Cells[4, 2] = tCanc;
                ws1.Cells[5, 1] = "Total"; ws1.Cells[5, 2] = tConf + tPend + tCanc;
                ((Excel.Range)ws1.Cells[5, 1]).Font.Bold = true;
                ((Excel.Range)ws1.Cells[5, 2]).Font.Bold = true;

                chartObjs1 = (Excel.ChartObjects)ws1.ChartObjects();
                chPieObj = chartObjs1.Add(350, 0, 480, 320);
                Excel.Chart chPie = chPieObj.Chart;
                chPie.ChartType = Excel.XlChartType.xlPie;
                chPie.SetSourceData(ws1.Range["A2", "B4"]);
                chPie.HasTitle = true;
                chPie.ChartTitle.Text = "Distribución de turnos";
                chPie.HasLegend = true;
                chPie.Legend.Position = Excel.XlLegendPosition.xlLegendPositionRight;
                chPie.ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowPercent);
                chPie.SeriesCollection(1).ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowValue);
                chPie.SeriesCollection(1).DataLabels().ShowPercentage = true;
                chPie.SeriesCollection(1).DataLabels().ShowValue = true;

                int fila = 7;
                ws1.Cells[fila, 1] = "Detalle de turnos";
                ((Excel.Range)ws1.Cells[fila, 1]).Font.Bold = true;
                fila++;
                DumpGrid(ws1, dgvDetalle, fila, 1);

                // -------- Hoja 2: Ranking Médicos (dgvRankingMedicos) --------
                if (dgvRankingMedicos != null && dgvRankingMedicos.Rows.Count > 0)
                {
                    ws2 = wb.Sheets.Add(After: ws1);
                    ws2.Name = "Ranking Médicos";

                    int lastRow = DumpGrid(ws2, dgvRankingMedicos, 1, 1);

                    
                    int idxMedico = dgvRankingMedicos.Columns["colMedico"].Index + 1;
                    int idxCant = dgvRankingMedicos.Columns["colConsultas"].Index + 1;

                    string x1 = ColumnLetter(idxMedico) + "2";
                    string x2 = ColumnLetter(idxMedico) + lastRow;
                    string y1 = ColumnLetter(idxCant) + "2";
                    string y2 = ColumnLetter(idxCant) + lastRow;

                    chartObjs2 = (Excel.ChartObjects)ws2.ChartObjects();
                    chColObj = chartObjs2.Add(350, 0, 520, 340);
                    Excel.Chart chCol = chColObj.Chart;
                    chCol.ChartType = Excel.XlChartType.xlColumnClustered;
                    chCol.HasTitle = true;
                    chCol.ChartTitle.Text = "Ranking de Médicos (cantidad de turnos)";
                    chCol.SetSourceData(ws2.Range[$"{y1}:{y2}"]);
                    chCol.SeriesCollection(1).XValues = ws2.Range[$"{x1}:{x2}"];
                    chCol.Axes(Excel.XlAxisType.xlCategory).HasTitle = true;
                    chCol.Axes(Excel.XlAxisType.xlCategory).AxisTitle.Text = "Médico";
                    chCol.Axes(Excel.XlAxisType.xlValue).HasTitle = true;
                    chCol.Axes(Excel.XlAxisType.xlValue).AxisTitle.Text = "Turnos";
                    chCol.ApplyDataLabels();
                }

                string fileName = $"Reporte_SaludSoft_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
                wb.SaveAs(ruta);

                if (MessageBox.Show($"Reporte generado.\n¿Abrir en Excel para imprimir?\n\n{ruta}",
                    "Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    app.Visible = true;
                }
                else
                {
                    wb.Close(false);
                    app.Quit();
                }

                MessageBox.Show("Archivo guardado en: " + ruta, "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                void Release(object o) { if (o != null) Marshal.ReleaseComObject(o); }
                Release(chColObj); Release(chartObjs2);
                Release(chPieObj); Release(chartObjs1);
                Release(ws2); Release(ws1);
                if (wb != null) { try { wb.Close(false); } catch { } Release(wb); }
                if (app != null) { try { app.Quit(); } catch { } Release(app); }
                GC.Collect(); GC.WaitForPendingFinalizers();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual de reportes
            this.Close();

        }*/
    }
}

