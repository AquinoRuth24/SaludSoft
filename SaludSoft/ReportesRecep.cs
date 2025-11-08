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
using PdfDoc = iTextSharp.text.Document;
using PdfWriterAlias = iTextSharp.text.pdf.PdfWriter;
using PdfPTableAlias = iTextSharp.text.pdf.PdfPTable;
using PdfPCellAlias = iTextSharp.text.pdf.PdfPCell;
using PdfPhraseAlias = iTextSharp.text.Phrase;
using PdfParagraphAlias = iTextSharp.text.Paragraph;
using PdfFontAlias = iTextSharp.text.Font;
using PdfImageAlias = iTextSharp.text.Image;
using PdfBaseColor = iTextSharp.text.BaseColor;
using PdfPageSize = iTextSharp.text.PageSize;
using PdfFontFactory = iTextSharp.text.FontFactory;

namespace SaludSoft
{
    public partial class ReportesRecep : Form
    {
        // ===== WinAPI para colorear ProgressBars =====
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        private const uint PBM_SETSTATE = 0x0410 + 16;
        private static void SetPBState(ProgressBar pb, int state) =>
            SendMessage(pb.Handle, PBM_SETSTATE, (IntPtr)state, IntPtr.Zero);

        // ===== Estado UI =====
        private string _estadoActual = "Confirmado";
        private bool _detalleVisible = false;
        private enum ModoDetalle { PorEstado, PacientesTotales }
        private ModoDetalle _modo = ModoDetalle.PorEstado;

        private bool _agendaVisible = false;
        private bool _cargandoMedicos = false;
        private bool _gbDetalleResizeHooked = false;

        public ReportesRecep()
        {
            InitializeComponent();

            InicializarAgendaDisponibleUI();
            WireAgendaDisponibleCard();

            Load += ReportesRecep_Load;

            if (btActualizar != null)
                btActualizar.Click += (s, e) => RefrescarTodo();

            WireCardClicks();

            dgvRankingMedicos.RowPostPaint += dgvRankingMedicos_RowPostPaint;
            dgvRankingMedicos.CellPainting += dgvRankingMedicos_CellPainting;
        }

        // ===== LOAD =====
        private void ReportesRecep_Load(object sender, EventArgs e)
        {
            // Filtros de periodo
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

            // Charts base
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

            CrearTableLayoutDetalle();

            RefrescarTodo();
            ConfigurarPie();
            ActualizarKpiAgendaDisponible();
            tlAgendaDisponible.Visible = false;

            if (btnImprimir != null)
                btnImprimir.Click += btnImprimir_Click;
        }

        // ===== Rango de fechas =====
        private (DateTime desde, DateTime hastaEx) RangoActual()
        {
            var desde = dtpPeriodo.Value.Date;
            if (dtpHasta.Checked)
            {
                var hastaEx = dtpHasta.Value.Date.AddDays(1);
                if (hastaEx <= desde) hastaEx = desde.AddDays(1);
                return (desde, hastaEx);
            }
            return (desde, desde.AddDays(1));
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

        // ===== Cards clickeables =====
        private void WireCardClicks()
        {
            void makeClickable(Control root, EventHandler onClick)
            {
                root.Cursor = Cursors.Hand;
                root.Click += onClick;
                foreach (Control c in root.Controls)
                {
                    c.Cursor = Cursors.Hand;
                    c.Click += onClick;
                }
            }

            makeClickable(panel2, (s, e) => ToggleDetalle("Confirmado"));
            makeClickable(panel3, (s, e) => ToggleDetalle("Pendiente"));
            makeClickable(panel4, (s, e) => ToggleDetalle("Cancelado"));

            var pnlPacTot = this.Controls.Find("panelPacientes", true).FirstOrDefault();
            if (pnlPacTot != null)
                makeClickable(pnlPacTot, (s, e) => MostrarPacientesTotales());
        }

        // ===== Chart helpers =====
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

        // ===== Columnas del detalle =====
        private void EnsureDetalleColumnsForPacientes()
        {
            dgvDetalle.AutoGenerateColumns = false;

            // Estilo base
            dgvDetalle.ReadOnly = true;
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.MultiSelect = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.RowHeadersVisible = false;

            dgvDetalle.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            dgvDetalle.DefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            dgvDetalle.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 250, 247);

            void addFill(string name, string header, string dataProp, float fillWeight)
            {
                if (!dgvDetalle.Columns.Contains(name))
                {
                    var col = new DataGridViewTextBoxColumn
                    {
                        Name = name,
                        HeaderText = header,
                        DataPropertyName = dataProp,
                        ReadOnly = true,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                        FillWeight = fillWeight
                    };
                    dgvDetalle.Columns.Add(col);
                }
                else
                {
                    var c = dgvDetalle.Columns[name];
                    c.HeaderText = header;
                    c.DataPropertyName = dataProp;
                    c.Visible = true;
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    c.FillWeight = fillWeight;
                }
            }

            addFill("colNombre", "Nombre", "Nombre", 16);
            addFill("colApellido", "Apellido", "Apellido", 16);
            addFill("colDni", "DNI", "DNI", 12);
            addFill("colCorreo", "Correo", "Correo", 28);
            addFill("colMedico", "Médico", "Medico", 16);
            addFill("colMotivo", "Motivo", "Motivo", 22);

            foreach (DataGridViewColumn c in dgvDetalle.Columns)
                c.Visible = new[] { "colNombre", "colApellido", "colDni", "colCorreo", "colMedico", "colMotivo" }.Contains(c.Name);
        }

        // ===== Columnas del detalle =====
        private void EnsureDetalleColumnsForEstado()
        {
            dgvDetalle.AutoGenerateColumns = false;

            void addText(string name, string header, string dataProp, int width)
            {
                if (!dgvDetalle.Columns.Contains(name))
                {
                    dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = name,
                        HeaderText = header,
                        DataPropertyName = dataProp,
                        ReadOnly = true,
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                        Width = width
                    });
                }
                else
                {
                    var c = dgvDetalle.Columns[name];
                    c.HeaderText = header;
                    c.DataPropertyName = dataProp;
                    c.Visible = true;
                    c.Width = width;
                }
            }

            addText("colNombre", "Nombre", "Nombre", 140);
            addText("colApellido", "Apellido", "Apellido", 140);
            addText("colDni", "DNI", "DNI", 110);
            addText("colCorreo", "Correo", "Correo", 200);
            addText("colMedico", "Médico", "Medico", 180);

            foreach (DataGridViewColumn c in dgvDetalle.Columns)
                c.Visible = new[] { "colNombre", "colApellido", "colDni", "colCorreo", "colMedico" }.Contains(c.Name);
        }

        // ===== Mostrar Pacientes Totales =====
        private void MostrarPacientesTotales()
        {
            _modo = ModoDetalle.PacientesTotales;
            _detalleVisible = true;
            _agendaVisible = false;

            gbDetalle.Visible = true;
            gbDetalle.Text = "Pacientes atendidos (Confirmados)";
            tlAgendaDisponible.Visible = false;
            gbTopMedicos.Visible = false;

            CargarPacientesTotales();
            SetDetalleLayout(soloGrid: true);
            LayoutSections();
        }

        private void CargarPacientesTotales()
        {
            var (desde, hastaEx) = RangoActual();

            string sql = @"
            SELECT DISTINCT
                pa.nombre                           AS Nombre,
                pa.apellido                         AS Apellido,
                pa.dni                              AS DNI,
                pa.email                            AS Correo,
                oa.Medico                           AS Medico,
                oa.Motivo                           AS Motivo
            FROM dbo.Paciente pa
            OUTER APPLY (
                SELECT TOP (1)
                    (pr.apellido + ' ' + pr.nombre) AS Medico,
                    t.motivo                        AS Motivo,
                    t.fecha                         AS FechaTurno
                FROM dbo.Turnos t
                INNER JOIN dbo.Agenda a                   ON a.id_agenda = t.id_agenda
                INNER JOIN dbo.Profesional_Consultorio pc ON pc.id_profesional_consultorio = a.id_profesional_consultorio
                INNER JOIN dbo.Profesional pr             ON pr.id_profesional = pc.id_profesional
                WHERE t.id_paciente = pa.id_paciente
                  AND t.fecha >= @desde AND t.fecha < @hasta
                  AND ISNULL(t.estado,'Pendiente') = 'Confirmado'
                ORDER BY t.fecha DESC
            ) oa
            WHERE oa.FechaTurno IS NOT NULL
            ORDER BY pa.apellido, pa.nombre;";

            var dt = GetTable(sql, c =>
            {
                c.Parameters.AddWithValue("@desde", desde);
                c.Parameters.AddWithValue("@hasta", hastaEx);
            });

            EnsureDetalleColumnsForPacientes();
            dgvDetalle.DataSource = dt;
            SetDetalleLayout(soloGrid: true);

            if (lbValorPacientes != null) lbValorPacientes.Text = dt.Rows.Count.ToString();
        }

        // ===== Refrescar todo =====
        private void RefrescarTodo()
        {
            CargarKpisYTorta();
            CargarTopMedicosYRanking();

            if (_detalleVisible)
            {
                if (_modo == ModoDetalle.PacientesTotales) CargarPacientesTotales();
                else CargarDetalleEstado();
            }

           
            int totalPacientes = ContarPacientesTotales();
            if (lbValorPacientes != null)
                lbValorPacientes.Text = totalPacientes.ToString();
        }

     
        private int ContarPacientesTotales()
        {
            var (desde, hastaEx) = RangoActual();

            const string sql = @"
                SELECT COUNT(DISTINCT t.id_paciente)
                FROM dbo.Turnos t
                WHERE t.id_paciente IS NOT NULL
                  AND ISNULL(t.estado,'Pendiente') = 'Confirmado'
                  AND t.fecha >= @d AND t.fecha < @h;";

            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@d", desde);
                cmd.Parameters.AddWithValue("@h", hastaEx);
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
            }
        }

        // ===== KPIs + Pie =====
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

            int conf = dtEstados.AsEnumerable()
                .Where(r => (r.Field<string>("Estado") ?? "").Equals("Confirmado", StringComparison.OrdinalIgnoreCase))
                .Select(r => r.Field<int>("Cant")).DefaultIfEmpty(0).First();

            int pend = dtEstados.AsEnumerable()
                .Where(r => (r.Field<string>("Estado") ?? "").Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                .Select(r => r.Field<int>("Cant")).DefaultIfEmpty(0).First();

            int canc = dtEstados.AsEnumerable()
                .Where(r => (r.Field<string>("Estado") ?? "").Equals("Cancelado", StringComparison.OrdinalIgnoreCase))
                .Select(r => r.Field<int>("Cant")).DefaultIfEmpty(0).First();

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

        // ===== Toggle Detalle por Estado =====
        private void ToggleDetalle(string estado)
        {
            if (_detalleVisible && _modo == ModoDetalle.PorEstado &&
                _estadoActual.Equals(estado, StringComparison.OrdinalIgnoreCase))
            {
                _detalleVisible = false;
                gbDetalle.Visible = false;
                LayoutSections();
                return;
            }

            _modo = ModoDetalle.PorEstado;
            _estadoActual = estado;

            _agendaVisible = false;
            tlAgendaDisponible.Visible = false;

            _detalleVisible = true;
            gbDetalle.Visible = true;
            gbDetalle.Text = $"Detalle de turnos (mostrando: {estado})";

            CargarDetalleEstado();
            SetDetalleLayout(soloGrid: false);
            LayoutSections();
        }

        private void CargarDetalleEstado()
        {
            var (desde, hastaEx) = RangoActual();

            string sql = @"
            SELECT 
                pa.nombre                         AS Nombre,
                pa.apellido                       AS Apellido,
                pa.dni                            AS DNI,
                pa.email                          AS Correo,
                (pr.apellido + ' ' + pr.nombre)   AS Medico
            FROM dbo.Turnos t
            INNER JOIN dbo.Paciente pa                ON pa.id_paciente = t.id_paciente
            INNER JOIN dbo.Agenda a                   ON a.id_agenda = t.id_agenda
            INNER JOIN dbo.Profesional_Consultorio pc ON pc.id_profesional_consultorio = a.id_profesional_consultorio
            INNER JOIN dbo.Profesional pr             ON pr.id_profesional = pc.id_profesional
            WHERE t.fecha >= @desde AND t.fecha < @hasta 
              AND ISNULL(t.estado,'Pendiente') = @estado
            ORDER BY pr.apellido, pr.nombre, pa.apellido, pa.nombre;";

            var dt = GetTable(sql, c =>
            {
                c.Parameters.AddWithValue("@desde", desde);
                c.Parameters.AddWithValue("@hasta", hastaEx);
                c.Parameters.AddWithValue("@estado", _estadoActual);
            });

            EnsureDetalleColumnsForEstado();
            dgvDetalle.DataSource = dt;
            SetDetalleLayout(soloGrid: false);
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

            dgvRankingMedicos.AutoGenerateColumns = false;
            dgvRankingMedicos.DataSource = dtRanking;

            if (dgvRankingMedicos.Columns.Contains("colPos")) dgvRankingMedicos.Columns["colPos"].DataPropertyName = "Pos";
            if (dgvRankingMedicos.Columns.Contains("colMedico")) dgvRankingMedicos.Columns["colMedico"].DataPropertyName = "Medico";
            if (dgvRankingMedicos.Columns.Contains("colEspec")) dgvRankingMedicos.Columns["colEspec"].DataPropertyName = "Especialidad";
            if (dgvRankingMedicos.Columns.Contains("colConsultas")) dgvRankingMedicos.Columns["colConsultas"].DataPropertyName = "Consultas";
            if (dgvRankingMedicos.Columns.Contains("colPorcentaje")) dgvRankingMedicos.Columns["colPorcentaje"].DataPropertyName = "Porcentaje";
        }

        // ===== Estética Ranking =====
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

        // ===== Layout Secciones =====
        private const int SPACING = 10;

        private void CrearTableLayoutDetalle()
        {
            if (gbDetalle == null || dgvDetalle == null || chPieEstados == null) return;
            if (gbDetalle.Controls.Find("tlDetalle", true).FirstOrDefault() != null) return;

            var tlDetalle = new TableLayoutPanel
            {
                Name = "tlDetalle",
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.Transparent
            };

            tlDetalle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55f));
            tlDetalle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45f));
            tlDetalle.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

            gbDetalle.Controls.Remove(dgvDetalle);
            gbDetalle.Controls.Remove(chPieEstados);

            dgvDetalle.Dock = DockStyle.Fill;
            chPieEstados.Dock = DockStyle.Fill;

            tlDetalle.Controls.Add(dgvDetalle, 0, 0);
            tlDetalle.Controls.Add(chPieEstados, 1, 0);

            gbDetalle.Controls.Add(tlDetalle);
        }

        private void SetDetalleLayout(bool soloGrid)
        {
            CrearTableLayoutDetalle();
            var tlDetalle = gbDetalle.Controls.Find("tlDetalle", true).FirstOrDefault() as TableLayoutPanel;
            if (tlDetalle == null) return;

            if (soloGrid)
            {
                tlDetalle.ColumnStyles[0].Width = 100f;
                tlDetalle.ColumnStyles[1].Width = 0f;
                chPieEstados.Visible = false;

                if (_gbDetalleResizeHooked)
                {
                    gbDetalle.Resize -= GbDetalle_Resize;
                    _gbDetalleResizeHooked = false;
                }
            }
            else
            {
                tlDetalle.ColumnStyles[0].Width = 55f;
                tlDetalle.ColumnStyles[1].Width = 45f;
                chPieEstados.Visible = true;

                if (!_gbDetalleResizeHooked)
                {
                    gbDetalle.Resize += GbDetalle_Resize;
                    _gbDetalleResizeHooked = true;
                }
            }

            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.Invalidate();
        }

        private void GbDetalle_Resize(object sender, EventArgs e) { }

        private void LayoutSections()
        {
            SuspendLayout();

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

            if (tlAgendaDisponible != null)
            {
                tlAgendaDisponible.Top = y;
                tlAgendaDisponible.Visible = _agendaVisible;
                if (_agendaVisible)
                    y = tlAgendaDisponible.Bottom + SPACING;
            }

            gbTopMedicos.Visible = !_agendaVisible && !_detalleVisible;
            gbTopMedicos.Top = y;
            y = gbTopMedicos.Bottom + SPACING;

            var btnImprimir = Controls.Find("btnImprimir", true).FirstOrDefault();
            if (btnImprimir != null)
            {
                btnImprimir.Top = y;
                y = btnImprimir.Bottom + SPACING;
            }

            if (AutoScroll)
                AutoScrollMinSize = new Size(0, y + 20);

            ResumeLayout();
        }

        // ===== Pie config + data =====
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

            var verde = Color.FromArgb(38, 166, 91);
            var amarillo = Color.FromArgb(247, 202, 24);
            var rojo = Color.FromArgb(231, 76, 60);

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

        // ===== Utilidad TryMap para DataGridView =====
        private static void TryMap(DataGridView dgv, string colName, string dataProp)
        {
            var c = (dgv?.Columns.Contains(colName) ?? false) ? dgv.Columns[colName] : null;
            if (c != null) c.DataPropertyName = dataProp;
        }

        // ===== Card Agenda Disponible (abre/cierra) =====
        private void WireAgendaDisponibleCard()
        {
            var pnl = this.Controls.Find("panelDisponibilidad", true).FirstOrDefault();
            if (pnl == null) return;

            void hook(Control c)
            {
                c.Cursor = Cursors.Hand;
                c.Click += (s, e) => ToggleAgendaDisponible();
                c.DoubleClick += (s, e) => ToggleAgendaDisponible();
                foreach (Control ch in c.Controls) hook(ch);
            }
            hook(pnl);
        }

        private void ToggleAgendaDisponible(bool? forceOpen = null)
        {
            bool abrir = forceOpen ?? !_agendaVisible;

            if (abrir)
            {
                _agendaVisible = true;
                _detalleVisible = false;
                gbDetalle.Visible = false;

                tlAgendaDisponible.Visible = true;
                tlAgendaDisponible.BringToFront();
                BuscarAgendaDisponible();
            }
            else
            {
                _agendaVisible = false;
                tlAgendaDisponible.Visible = false;
            }
            LayoutSections();
        }

        // ===== Inicializa bloque Agenda Disponible =====
        private void InicializarAgendaDisponibleUI()
        {
            if (tlAgendaDisponible == null) return;

            if (dtADesde != null)
            {
                dtADesde.Format = DateTimePickerFormat.Custom;
                dtADesde.CustomFormat = "dd/MM/yyyy";
                dtADesde.Value = DateTime.Today;
            }
            if (dtAHasta != null)
            {
                dtAHasta.Format = DateTimePickerFormat.Custom;
                dtAHasta.CustomFormat = "dd/MM/yyyy";
                dtAHasta.Value = DateTime.Today;
            }

            if (btFiltrarAD != null) btFiltrarAD.Click += (s, e) => BuscarAgendaDisponible();
            if (btCerrarAD != null) btCerrarAD.Click += (s, e) => ToggleAgendaDisponible(false);

            if (cbMedico != null) cbMedico.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BuscarAgendaDisponible(); } };
            if (dtADesde != null) dtADesde.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BuscarAgendaDisponible(); } };
            if (dtAHasta != null) dtAHasta.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BuscarAgendaDisponible(); } };

            if (dgAgendaLibre != null)
            {
                dgAgendaLibre.AutoGenerateColumns = false;
                TryMap(dgAgendaLibre, "colFecha", "Fecha");
                TryMap(dgAgendaLibre, "colHora", "Hora");
                TryMap(dgAgendaLibre, "columMedico", "Profesional");
                TryMap(dgAgendaLibre, "columEspecialidad", "Especialidad");
                TryMap(dgAgendaLibre, "columConsultorio", "Consultorio");

                dgAgendaLibre.RowHeadersVisible = false;
                dgAgendaLibre.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgAgendaLibre.MultiSelect = false;
                dgAgendaLibre.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            CargarMedicosCombo();
        }

        // ===== Helpers agenda =====
        private static int DiaSemanaNumeroEs(string nombreEs)
        {
            if (string.IsNullOrWhiteSpace(nombreEs)) return 0;

            string s = nombreEs.Trim().ToLowerInvariant();
            s = s.Replace("á", "a").Replace("é", "e").Replace("í", "i")
                 .Replace("ó", "o").Replace("ú", "u");

            if (int.TryParse(s, out int n) && n >= 1 && n <= 7) return n;

            switch (s)
            {
                case "lun": case "lunes": return 1;
                case "mar": case "martes": return 2;
                case "mie": case "miercoles": return 3;
                case "jue": case "jueves": return 4;
                case "vie": case "viernes": return 5;
                case "sab": case "sabado": return 6;
                case "dom": case "domingo": return 7;
                default: return 0;
            }
        }

        private const int _slotMin = 30;

        private DataTable GenerarLibresDesdeAgenda(DateTime desde, DateTime hastaEx, int idMedico)
        {
            const string SQL_AGENDAS = @"
            SELECT 
                a.id_agenda,
                pc.id_profesional,
                a.diaSemana,
                a.horaInicio,
                a.horaFin,
                (pr.apellido + ' ' + pr.nombre) AS Profesional,
                es.nombre AS Especialidad,
                ISNULL(c.descripcion,'') AS Consultorio
            FROM dbo.Agenda a
            INNER JOIN dbo.Profesional_Consultorio pc ON pc.id_profesional_consultorio = a.id_profesional_consultorio
            INNER JOIN dbo.Profesional pr             ON pr.id_profesional = pc.id_profesional
            LEFT  JOIN dbo.Especialidad es            ON es.id_especialidad = pr.id_especialidad
            LEFT  JOIN dbo.Consultorio c              ON c.id_consultorio = pc.id_consultorio
            /**FILTRO_MEDICO**/";

            const string SQL_OCUPADOS = @"
            SELECT t.id_agenda, t.fecha
            FROM dbo.Turnos t
            WHERE t.fecha >= @d AND t.fecha < @h
              AND ISNULL(t.estado,'Pendiente') <> 'Cancelado'
              AND t.id_paciente IS NOT NULL;";

            var agendas = new DataTable();
            var ocupados = new DataTable();

            using (var cn = Conexion.GetConnection())
            {
                string sqlA = SQL_AGENDAS;
                if (idMedico > 0) sqlA = sqlA.Replace("/**FILTRO_MEDICO**/", "WHERE pc.id_profesional = @idMedico");
                else sqlA = sqlA.Replace("/**FILTRO_MEDICO**/", "");

                using (var da = new SqlDataAdapter(sqlA, cn))
                {
                    if (idMedico > 0) da.SelectCommand.Parameters.AddWithValue("@idMedico", idMedico);
                    da.Fill(agendas);
                }
                using (var da = new SqlDataAdapter(SQL_OCUPADOS, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@d", desde);
                    da.SelectCommand.Parameters.AddWithValue("@h", hastaEx);
                    da.Fill(ocupados);
                }
            }

            var setOcupados = new HashSet<string>(
                ocupados.AsEnumerable().Select(r => $"{r.Field<int>("id_agenda")}|{r.Field<DateTime>("fecha"):yyyyMMddHHmm}")
            );

            var libres = new DataTable();
            libres.Columns.Add("Fecha", typeof(DateTime));
            libres.Columns.Add("Hora", typeof(string));
            libres.Columns.Add("Profesional", typeof(string));
            libres.Columns.Add("Especialidad", typeof(string));
            libres.Columns.Add("Consultorio", typeof(string));
            libres.Columns.Add("Medico", typeof(string));

            for (DateTime dia = desde.Date; dia < hastaEx.Date; dia = dia.AddDays(1))
            {
                int nDia = ((int)dia.DayOfWeek + 6) % 7 + 1; // lunes=1 ... domingo=7
                foreach (DataRow a in agendas.Rows)
                {
                    int nAgenda = DiaSemanaNumeroEs(a["diaSemana"]?.ToString());
                    if (nAgenda != nDia) continue;

                    var hi = (TimeSpan)a["horaInicio"];
                    var hf = (TimeSpan)a["horaFin"];
                    int idAgenda = (int)a["id_agenda"];

                    DateTime fhi = dia.Date + hi;
                    DateTime fhf = dia.Date + hf;

                    for (DateTime fh = fhi; fh < fhf; fh = fh.AddMinutes(_slotMin))
                    {
                        string clave = $"{idAgenda}|{fh:yyyyMMddHHmm}";
                        if (setOcupados.Contains(clave)) continue;

                        libres.Rows.Add(
                            fh.Date,
                            fh.ToString("HH:mm"),
                            a["Profesional"]?.ToString() ?? "",
                            a["Especialidad"]?.ToString() ?? "",
                            a["Consultorio"]?.ToString() ?? "",
                            a["Profesional"]?.ToString() ?? ""
                        );
                    }
                }
            }

            return libres;
        }

        // ===== Cargar combo médicos =====
        private void CargarMedicosCombo()
        {
            if (cbMedico == null) return;
            if (_cargandoMedicos) return;

            try
            {
                _cargandoMedicos = true;

                const string SQL = @"
                SELECT pr.id_profesional AS Id, (pr.apellido + ' ' + pr.nombre) AS Nombre
                FROM dbo.Profesional pr
                ORDER BY pr.apellido, pr.nombre;";

                using (var cn = Conexion.GetConnection())
                using (var da = new SqlDataAdapter(SQL, cn))
                {
                    var dt = new DataTable();
                    da.Fill(dt);

                    var row = dt.NewRow();
                    row["Id"] = 0;
                    row["Nombre"] = "Todos los médicos";
                    dt.Rows.InsertAt(row, 0);

                    cbMedico.DisplayMember = "Nombre";
                    cbMedico.ValueMember = "Id";
                    cbMedico.DataSource = dt;
                }
            }
            finally
            {
                _cargandoMedicos = false;
            }
        }

        // ===== Buscar Agenda Disponible =====
        private void BuscarAgendaDisponible()
        {
            if (dgAgendaLibre == null) return;

            DateTime d = (dtADesde?.Value.Date ?? DateTime.Today);
            DateTime hEx = (dtAHasta?.Value.Date ?? DateTime.Today).AddDays(1);

            int idMedico = 0;
            if (cbMedico != null && cbMedico.SelectedValue != null)
                int.TryParse(cbMedico.SelectedValue.ToString(), out idMedico);

            string sqlTurnosLibres = @"
            SELECT 
                CAST(t.fecha AS date)             AS Fecha,
                CONVERT(varchar(5), t.fecha,108)  AS Hora,
                (pr.apellido + ' ' + pr.nombre)   AS Medico,
                es.nombre                         AS Especialidad,
                ISNULL(c.descripcion,'')          AS Consultorio
            FROM dbo.Turnos t
            INNER JOIN dbo.Agenda a                    ON a.id_agenda = t.id_agenda
            INNER JOIN dbo.Profesional_Consultorio pc  ON pc.id_profesional_consultorio = a.id_profesional_consultorio
            INNER JOIN dbo.Profesional pr              ON pr.id_profesional = pc.id_profesional
            LEFT  JOIN dbo.Especialidad es             ON es.id_especialidad = pr.id_especialidad
            LEFT  JOIN dbo.Consultorio c               ON c.id_consultorio = pc.id_consultorio
            WHERE t.fecha >= @d AND t.fecha < @h
              AND (t.id_paciente IS NULL OR ISNULL(t.estado,'') = 'Cancelado')
              /**FILTRO_MEDICO**/
            ORDER BY t.fecha;";

            if (idMedico > 0)
                sqlTurnosLibres = sqlTurnosLibres.Replace("/**FILTRO_MEDICO**/", "AND pr.id_profesional = @idMedico");
            else
                sqlTurnosLibres = sqlTurnosLibres.Replace("/**FILTRO_MEDICO**/", "");

            DataTable dtLibres;
            using (var cn = Conexion.GetConnection())
            using (var da = new SqlDataAdapter(sqlTurnosLibres, cn))
            {
                da.SelectCommand.Parameters.AddWithValue("@d", d);
                da.SelectCommand.Parameters.AddWithValue("@h", hEx);
                if (idMedico > 0) da.SelectCommand.Parameters.AddWithValue("@idMedico", idMedico);
                dtLibres = new DataTable();
                da.Fill(dtLibres);
            }

            if (dtLibres.Rows.Count == 0)
                dtLibres = GenerarLibresDesdeAgenda(d, hEx, idMedico);

            TryMap(dgAgendaLibre, "colFecha", "Fecha");
            TryMap(dgAgendaLibre, "colHora", "Hora");
            TryMap(dgAgendaLibre, "columMedico", "Profesional");
            TryMap(dgAgendaLibre, "columEspecialidad", "Especialidad");
            TryMap(dgAgendaLibre, "columConsultorio", "Consultorio");

            dgAgendaLibre.AutoGenerateColumns = false;
            dgAgendaLibre.DataSource = dtLibres;

            ActualizarKpiAgendaDisponible();
        }

        // ===== KPI: Agendas activas =====
        private void ActualizarKpiAgendaDisponible()
        {
            try
            {
                DateTime d = (dtADesde?.Value.Date ?? DateTime.Today);
                DateTime hEx = (dtAHasta?.Value.Date ?? DateTime.Today).AddDays(1);

                int idMedico = 0;
                if (cbMedico?.SelectedValue != null)
                    int.TryParse(cbMedico.SelectedValue.ToString(), out idMedico);

                // Contamos PROFESIONALES con agenda vigente (activos) que tengan al menos 1 fila en Agenda.
                string sql = @"
                SELECT COUNT(DISTINCT pc.id_profesional)
                FROM dbo.Agenda a
                INNER JOIN dbo.Profesional_Consultorio pc ON pc.id_profesional_consultorio = a.id_profesional_consultorio
                INNER JOIN dbo.Profesional pr             ON pr.id_profesional = pc.id_profesional
                WHERE pr.id_estado = 1
                  -- superposición de vigencia con el rango solicitado
                  AND pc.vigencia_desde <= @h
                  AND pc.vigencia_hasta  >= @d
                  /**FILTRO_MEDICO**/;";

                if (idMedico > 0)
                    sql = sql.Replace("/**FILTRO_MEDICO**/", "AND pc.id_profesional = @idMedico");
                else
                    sql = sql.Replace("/**FILTRO_MEDICO**/", "");

                int agendasActivas = GetScalarInt(sql, c =>
                {
                    c.Parameters.AddWithValue("@d", d);
                    c.Parameters.AddWithValue("@h", hEx);
                    if (idMedico > 0) c.Parameters.AddWithValue("@idMedico", idMedico);
                });

                // UI
                if (lbTituloDisponibilidad != null) lbTituloDisponibilidad.Text = "Agendas activas";
                if (lbValorDisponibilidad != null) lbValorDisponibilidad.Text = agendasActivas.ToString();

                if (pbDisponibilidad != null)
                {
                    pbDisponibilidad.Maximum = Math.Max(agendasActivas, 1);
                    pbDisponibilidad.Value = Math.Min(agendasActivas, pbDisponibilidad.Maximum);
                    SetPBState(pbDisponibilidad, 1); // verde
                }
            }
            catch
            {
                if (lbValorDisponibilidad != null) lbValorDisponibilidad.Text = "0";
                try { SetPBState(pbDisponibilidad, 2); } catch { }
            }
        }


        private void lReportesMes_Click(object sender, EventArgs e) { }
        private void lbValorPacientes_Click(object sender, EventArgs e) { }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ====== HELPERS PDF ======
        private static PdfFontAlias FTitle(int size)
            => PdfFontFactory.GetFont("Helvetica", size, PdfFontAlias.BOLD, PdfBaseColor.BLACK);
        private static PdfFontAlias FText(int size)
            => PdfFontFactory.GetFont("Helvetica", size, PdfFontAlias.NORMAL, PdfBaseColor.BLACK);
        private static PdfFontAlias FSmall(int size)
            => PdfFontFactory.GetFont("Helvetica", size, PdfFontAlias.NORMAL, new PdfBaseColor(60, 60, 60));

        private static PdfImageAlias ChartToImg(Chart chart, int maxWidth, int maxHeight)
        {
            using (var ms = new MemoryStream())
            {
                chart.SaveImage(ms, ChartImageFormat.Png);
                var img = PdfImageAlias.GetInstance(ms.ToArray());
                img.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                img.SpacingBefore = 6f;
                img.SpacingAfter = 6f;
                img.ScaleToFit(maxWidth, maxHeight);
                return img;
            }
        }

        private static PdfPTableAlias GridToPdfTable(DataGridView grid)
        {
            var cols = grid.Columns.Cast<DataGridViewColumn>()
                         .Where(c => c.Visible)
                         .OrderBy(c => c.DisplayIndex)
                         .ToList();

            var table = new PdfPTableAlias(cols.Count)
            {
                WidthPercentage = 100f,
                SpacingBefore = 6f,
                SpacingAfter = 6f
            };

            // Encabezados
            foreach (var c in cols)
            {
                var cell = new PdfPCellAlias(new PdfPhraseAlias(c.HeaderText, FText(10)))
                {
                    BackgroundColor = new PdfBaseColor(230, 240, 235),
                    Padding = 4f
                };
                table.AddCell(cell);
            }

            // Filas
            foreach (DataGridViewRow r in grid.Rows)
            {
                if (r.IsNewRow) continue;
                foreach (var c in cols)
                {
                    var val = r.Cells[c.Index].Value?.ToString() ?? "";
                    var cell = new PdfPCellAlias(new PdfPhraseAlias(val, FText(10))) { Padding = 3f };
                    table.AddCell(cell);
                }
            }

            return table;
        }

        private void AddSectionTitle(PdfDoc doc, string text)
        {
            var p = new PdfParagraphAlias(text, FTitle(12))
            {
                SpacingBefore = 10f,
                SpacingAfter = 4f,
                Alignment = iTextSharp.text.Element.ALIGN_LEFT
            };
            doc.Add(p);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                bool hayAlgo =
                    (dgvDetalle?.Rows.Count ?? 0) > 0 ||
                    (dgvRankingMedicos?.Rows.Count ?? 0) > 0 ||
                    (chPieEstados?.Series.Count ?? 0) > 0 ||
                    (chTopMedicos?.Series.Count ?? 0) > 0;

                if (!hayAlgo)
                {
                    MessageBox.Show("No hay datos para imprimir.", "Reportes",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string sugerido = $"Reporte_SaludSoft_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
                using (var sfd = new SaveFileDialog { FileName = sugerido, Filter = "Archivo PDF (*.pdf)|*.pdf" })
                {
                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    var doc = new PdfDoc(PdfPageSize.A4.Rotate(), 36, 36, 36, 36);
                    var fs = new FileStream(sfd.FileName, FileMode.Create);
                    var writer = PdfWriterAlias.GetInstance(doc, fs);

                    doc.Open();

                    var titulo = new PdfParagraphAlias("REPORTE MENSUAL - SALUDSOFT", FTitle(16))
                    {
                        Alignment = iTextSharp.text.Element.ALIGN_CENTER,
                        SpacingAfter = 5f
                    };
                    doc.Add(titulo);

                    DateTime fechaDesde = dtpPeriodo.Value.Date;
                    DateTime fechaHasta = dtpHasta.Checked ? dtpHasta.Value.Date : fechaDesde;

                    var rango = new PdfParagraphAlias(
                        $"Desde: {fechaDesde:dd/MM/yyyy}    Hasta: {fechaHasta:dd/MM/yyyy}", FText(11))
                    {
                        Alignment = iTextSharp.text.Element.ALIGN_CENTER,
                        SpacingAfter = 8f
                    };
                    doc.Add(rango);

                    var info = new PdfParagraphAlias($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm}", FSmall(9))
                    {
                        Alignment = iTextSharp.text.Element.ALIGN_CENTER,
                        SpacingAfter = 10f
                    };
                    doc.Add(info);

                    var kpi = new PdfParagraphAlias(
                        $"Confirmados: {lbValor?.Text ?? "0"}   |   " +
                        $"Pendientes: {lbValorTP?.Text ?? "0"}   |   " +
                        $"Cancelados: {lbValorTC?.Text ?? "0"}",
                        FText(11))
                    {
                        Alignment = iTextSharp.text.Element.ALIGN_CENTER,
                        SpacingAfter = 6f
                    };
                    doc.Add(kpi);

                    if (chPieEstados != null && chPieEstados.Series.Count > 0)
                    {
                        AddSectionTitle(doc, "Distribución de turnos");
                        var imgPie = ChartToImg(chPieEstados, 800, 360);
                        doc.Add(imgPie);
                    }

                    if (dgvDetalle != null && dgvDetalle.Rows.Count > 0)
                    {
                        string tituloDetalle = (_modo == ModoDetalle.PacientesTotales)
                            ? "Pacientes atendidos (Confirmados)"
                            : $"Detalle de turnos (mostrando: {_estadoActual})";

                        AddSectionTitle(doc, tituloDetalle);
                        var tablaDetalle = GridToPdfTable(dgvDetalle);
                        doc.Add(tablaDetalle);
                    }

                    if (dgvRankingMedicos != null && dgvRankingMedicos.Rows.Count > 0)
                    {
                        AddSectionTitle(doc, "Ranking de Médicos");
                        var tablaRank = GridToPdfTable(dgvRankingMedicos);
                        doc.Add(tablaRank);
                    }

                    if (chTopMedicos != null && chTopMedicos.Series.Count > 0)
                    {
                        AddSectionTitle(doc, "Consultas por Médico");
                        var imgCols = ChartToImg(chTopMedicos, 800, 340);
                        doc.Add(imgCols);
                    }

                    doc.Close();
                    writer.Close();
                    fs.Close();

                    if (MessageBox.Show("PDF generado correctamente.\n\n¿Desea abrirlo ahora?",
                        "PDF", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try { System.Diagnostics.Process.Start(sfd.FileName); } catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "PDF",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
