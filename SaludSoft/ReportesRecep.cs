using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SaludSoft
{
    public partial class ReportesRecep : Form
    {
        private string _estadoActual = "Confirmado";
        private bool _detalleVisible = false;

        public ReportesRecep()
        {
            InitializeComponent();

            // Eventos
            this.Load += ReportesRecep_Load;
            btActualizar.Click += btActualizar_Click;

            // Clicks en las 3 cards KPI
            WireCardClicks();
        }

        //LOAD
        private void ReportesRecep_Load(object sender, EventArgs e)
        {
            // Filtro mes/año
            dtpPeriodo.Format = DateTimePickerFormat.Custom;
            dtpPeriodo.CustomFormat = "MMMM yyyy";
            dtpPeriodo.ShowUpDown = true;
            dtpPeriodo.Value = DateTime.Today;

            ActualizarEncabezado();
            EstiloBasico();

            gbDetalle.Visible = false;
            _detalleVisible = false;

            RefrescarTodo();
            ReordenarSecciones(false);
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            ActualizarEncabezado();
            RefrescarTodo();
            _detalleVisible = false;
            ReordenarSecciones(false);
        }

        //UTILIDADES BD
        private (DateTime desde, DateTime hastaEx) RangoMes()
        {
            var d = new DateTime(dtpPeriodo.Value.Year, dtpPeriodo.Value.Month, 1);
            return (d, d.AddMonths(1));
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
        private void ActualizarEncabezado()
        {
            var mes = new DateTime(dtpPeriodo.Value.Year, dtpPeriodo.Value.Month, 1);
            lFechaPeriodo.Text = $"Fecha: {mes:MMMM 'de' yyyy}";
            lReportesMes.Text = "Reporte mensual";
        }

        private void WireCardClicks()
        {
            void clickAll(Control root, EventHandler h)
            {
                root.Click += h;
                foreach (Control c in root.Controls) c.Click += h;
            }
            clickAll(panel2, (s, e) => ToggleDetalle("Confirmado"));
            clickAll(panel3, (s, e) => ToggleDetalle("Pendiente"));
            clickAll(panel4, (s, e) => ToggleDetalle("Cancelado"));
        }

        private void EstiloBasico()
        {
            foreach (var pb in new[] { pbTurnosConfirmados, pbTP, progressBar1 })
            {
                pb.Style = ProgressBarStyle.Continuous;
                pb.MarqueeAnimationSpeed = 0;
            }

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
            chTopMedicos.ChartAreas["caTop"].AxisX.MajorGrid.Enabled = false;
            chTopMedicos.ChartAreas["caTop"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
        }

        
        private void ReordenarSecciones(bool mostrarDetalle)
        {
            this.SuspendLayout();
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
            this.ResumeLayout();
        }

        // REFRESH GLOBAL
        private void RefrescarTodo()
        {
            CargarKpisYTorta();
            CargarTopMedicosYRanking();
            CargarResumen(); 
        }

        //KPI + TORTA
        private void CargarKpisYTorta()
        {
            var (desde, hastaEx) = RangoMes();

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

            int conf = dtEstados.AsEnumerable().Where(r => r.Field<string>("Estado").Equals("Confirmado", StringComparison.OrdinalIgnoreCase))
                                               .Select(r => r.Field<int>("Cant")).DefaultIfEmpty(0).First();
            int pend = dtEstados.AsEnumerable().Where(r => r.Field<string>("Estado").Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                                               .Select(r => r.Field<int>("Cant")).DefaultIfEmpty(0).First();
            int canc = dtEstados.AsEnumerable().Where(r => r.Field<string>("Estado").Equals("Cancelado", StringComparison.OrdinalIgnoreCase))
                                               .Select(r => r.Field<int>("Cant")).DefaultIfEmpty(0).First();

            SetCard(pbTurnosConfirmados, lbValor, lbTituloConfirmado, "Turnos Confirmados", conf, total);
            SetCard(pbTP, lbValorTP, lbTurnosPendientes, "Turnos Pendientes", pend, total);
            SetCard(progressBar1, lbValorTC, lbTurnosCancelados, "Turnos Cancelados", canc, total);

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

        private void SetCard(ProgressBar pb, Label lbNumero, Label lbTitulo, string titulo, int valor, int total)
        {
            lbTitulo.Text = titulo;
            lbNumero.Text = valor.ToString();
            pb.Maximum = Math.Max(total, 1);
            pb.Value = Math.Min(valor, pb.Maximum);
        }

        // DETALLE
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
            gbDetalle.Text = $"Detalle de Turnos Confirmados/Pendientes/Cancelados  (Mostrando: {estado})";

            _detalleVisible = true;
            ReordenarSecciones(true);
            this.ScrollControlIntoView(gbDetalle);
        }

        private void CargarDetalleEstado()
        {
            var (desde, hastaEx) = RangoMes();

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
            var (desde, hastaEx) = RangoMes();

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

            // Barras
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

            // % sobre total confirmados del mes
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

        //RESUMEN
        private void CargarResumen()
        {
            
        }
    }
}
