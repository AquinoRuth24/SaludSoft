using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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

        public ReportesRecep()
        {
            InitializeComponent();

            Load += ReportesRecep_Load;

            // Actualizar datos
            btActualizar.Click += (s, e) => RefrescarTodo();

            // Clicks de las 3 cards
            WireCardClicks();

            // Estética del ranking
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

            //evitar duplicados en las grillas
            dgvDetalle.AutoGenerateColumns = false;
            dgvRankingMedicos.AutoGenerateColumns = false;

            // Colores de barras (solo apariencia)
            foreach (var pb in new[] { pbTurnosConfirmados, pbTP, progressBar1 })
            {
                pb.Style = ProgressBarStyle.Continuous;
                pb.MarqueeAnimationSpeed = 0;
            }
            SetPBState(pbTurnosConfirmados, 1); // verde
            SetPBState(pbTP, 3);                // amarillo
            SetPBState(progressBar1, 2);        // rojo

            // Charts
            var caPie = EnsureChartArea(chPieEstados, "ca");
            var lgPie = EnsureLegend(chPieEstados, "lg");
            var sPie = EnsureSeries(chPieEstados, "Estados", SeriesChartType.Pie, caPie, lgPie);
            sPie.IsValueShownAsLabel = true;
            sPie["PieLabelStyle"] = "Outside";
            sPie["PieLineColor"] = "Gray";
            sPie.Label = "#VALX #PERCENT{P0}";
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
        }

        // ===== RANGO FECHAS =====
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

            var dtEstados = GetTable(sqlEstados, c => { c.Parameters.AddWithValue("@d", desde); c.Parameters.AddWithValue("@h", hastaEx); });
            int total = GetTable(sqlTotal, c => { c.Parameters.AddWithValue("@d", desde); c.Parameters.AddWithValue("@h", hastaEx); })
                        .AsEnumerable().Select(r => r.Field<int>("TotalMes")).DefaultIfEmpty(0).First();

            int conf = dtEstados.AsEnumerable().Where(r => r.Field<string>("Estado").Equals("Confirmado", StringComparison.OrdinalIgnoreCase))
                                               .Select(r => r.Field<int>("Cant")).DefaultIfEmpty(0).First();
            int pend = dtEstados.AsEnumerable().Where(r => r.Field<string>("Estado").Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                                               .Select(r => r.Field<int>("Cant")).DefaultIfEmpty(0).First();
            int canc = dtEstados.AsEnumerable().Where(r => r.Field<string>("Estado").Equals("Cancelado", StringComparison.OrdinalIgnoreCase))
                                               .Select(r => r.Field<int>("Cant")).DefaultIfEmpty(0).First();

            SetCard(pbTurnosConfirmados, lbValor, lbTituloConfirmado, "Turnos Confirmados", conf, total, 1);
            SetCard(pbTP, lbValorTP, lbTurnosPendientes, "Turnos Pendientes", pend, total, 3);
            SetCard(progressBar1, lbValorTC, lbTurnosCancelados, "Turnos Cancelados", canc, total, 2);

            var seriePie = EnsureSeries(chPieEstados, "Estados",
                SeriesChartType.Pie,
                EnsureChartArea(chPieEstados, "ca"),
                EnsureLegend(chPieEstados, "lg"));
            seriePie.Points.Clear();

            foreach (DataRow r in dtEstados.Rows)
            {
                var dp = new DataPoint { AxisLabel = r.Field<string>("Estado") };
                dp.YValues = new[] { Convert.ToDouble(r.Field<int>("Cant")) };
                dp.ToolTip = "#VALX: #VAL";
                seriePie.Points.Add(dp);
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
    }
}
