using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DFont = System.Drawing.Font;
using DRectangle = System.Drawing.Rectangle;
using IFont = iTextSharp.text.Font;


namespace SaludSoft
{
    public partial class FormEstadisticas : Form
    {
        public FormEstadisticas()
        {
            InitializeComponent();

            // Establecer fechas por defecto ultimo mes
            DTPDesde.Value = DateTime.Today.AddDays(-30);
            DTPHasta.Value = DateTime.Today;

            CargarGrafico();
            CargarRankingMedicosGrid();
            CargarResumenCitas();
            CargarEstadisticasGenerales();

            DTGRankingMedicos.CellPainting += DTGRankingMedicos_CellPainting;
            DTGRankingPacientes.CellPainting += DTGRankingPacientes_CellPainting;

            BFiltro.Click += BFiltro_Click;
            BImprimir.Click += BImprimir_Click;

        }
        //-------Parte de especialidades por turno-------//
        private void CargarGrafico()
        {
            string query = @"
             SELECT 
             e.nombre AS Especialidad,
             COUNT(t.id_turno) AS CantidadTurnos
             FROM Turnos t
             INNER JOIN Agenda a ON t.id_agenda = a.id_agenda
             INNER JOIN Profesional_Consultorio pc ON a.id_profesional_consultorio = pc.id_profesional_consultorio
             INNER JOIN Profesional p ON pc.id_profesional = p.id_profesional
             INNER JOIN Especialidad e ON p.id_especialidad = e.id_especialidad
             WHERE t.fecha BETWEEN @fechaInicio AND @fechaFin
             GROUP BY e.nombre
             ORDER BY CantidadTurnos DESC;";

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.SelectCommand.Parameters.AddWithValue("@fechaInicio", DTPDesde.Value.Date);
                da.SelectCommand.Parameters.AddWithValue("@fechaFin", DTPHasta.Value.Date);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para mostrar en el rango seleccionado.");
                    return;
                }

                int totalTurnos = dt.AsEnumerable().Sum(r => r.Field<int>("CantidadTurnos"));
                dt.Columns.Add("Porcentaje", typeof(double));
                foreach (DataRow row in dt.Rows)
                {
                    double cantidad = Convert.ToDouble(row["CantidadTurnos"]);
                    row["Porcentaje"] = Math.Round((cantidad / totalTurnos) * 100, 1);
                }

                // Configurar gráfico
                ChartEspecialidades.Series.Clear();
                Series serie = new Series("Turnos por Especialidad")
                {
                    ChartType = SeriesChartType.Pie,
                    IsValueShownAsLabel = true,
                    LabelForeColor = Color.FromArgb(90, 90, 150),
                    Font = new DFont("Segoe UI", 9, FontStyle.Bold)
                };
                serie["PieLabelStyle"] = "Outside";
                serie["PieLineColor"] = "Gray";

                string[] colores = { "#9C8ADE", "#A9A4F0", "#BFB3FF", "#C9BFF8", "#D5CFFF", "#E0DBFF" };
                serie.Points.DataBind(dt.AsEnumerable(), "Especialidad", "CantidadTurnos", null);
                for (int i = 0; i < serie.Points.Count; i++)
                {
                    serie.Points[i].Color = ColorTranslator.FromHtml(colores[i % colores.Length]);
                    serie.Points[i].Label = $"{dt.Rows[i]["Especialidad"]} {dt.Rows[i]["Porcentaje"]}%";
                }

                ChartEspecialidades.Series.Add(serie);
                ChartEspecialidades.Titles.Clear();
                ChartEspecialidades.Titles.Add("Turnos por Especialidad");
                ChartEspecialidades.Titles[0].Font = new DFont("Segoe UI", 11, FontStyle.Bold);
                ChartEspecialidades.Titles[0].Alignment = ContentAlignment.TopLeft;
                ChartEspecialidades.ChartAreas[0].BackColor = Color.White;
                ChartEspecialidades.Legends.Clear();

                //Crear descripción dinámica debajo del gráfico
                StringBuilder descripcion = new StringBuilder();
                descripcion.AppendLine("Distribución de turnos por especialidad:\n");

                foreach (DataRow row in dt.Rows)
                {
                    string especialidad = row["Especialidad"].ToString();
                    int cantidad = Convert.ToInt32(row["CantidadTurnos"]);
                    double porcentaje = Convert.ToDouble(row["Porcentaje"]);

                    descripcion.AppendLine($"• {especialidad}: {porcentaje}% ({cantidad} turnos)");
                }

                // Eliminar etiqueta anterior si ya existe
                if (this.Controls.ContainsKey("lblDescripcionGrafico"))
                {
                    this.Controls.RemoveByKey("lblDescripcionGrafico");
                }

                // Crear nueva etiqueta descriptiva
                Label lblDescripcionGrafico = new Label();
                lblDescripcionGrafico.Name = "lblDescripcionGrafico";
                lblDescripcionGrafico.Anchor = AnchorStyles.Top | AnchorStyles.Right;    
                lblDescripcionGrafico.Text = descripcion.ToString();
                lblDescripcionGrafico.Font = new DFont("Segoe UI", 9, FontStyle.Regular);
                lblDescripcionGrafico.ForeColor = Color.Black;
                lblDescripcionGrafico.AutoSize = true;
                lblDescripcionGrafico.MaximumSize = new Size(250, 0); // límite de ancho, texto con salto de línea
                lblDescripcionGrafico.BackColor = Color.WhiteSmoke;
                lblDescripcionGrafico.Padding = new Padding(10);
                lblDescripcionGrafico.BorderStyle = BorderStyle.FixedSingle;

                // Posicionar la descripcion (derecha del grafico)
                lblDescripcionGrafico.Location = new Point(
                    ChartEspecialidades.Right + 20,
                    ChartEspecialidades.Top + 40      // alineado al gráfico
                );

                this.Controls.Add(lblDescripcionGrafico);
                lblDescripcionGrafico.BringToFront();
            }
        }
        private FlowLayoutPanel contenedorResumen;
        // tarjetas de resumen de turnos
        private void CargarResumenCitas()
        {
            string query = @"
             SELECT 
             SUM(CASE WHEN t.estado = 'Confirmado' THEN 1 ELSE 0 END) AS Confirmados,
             SUM(CASE WHEN t.estado = 'Cancelado' THEN 1 ELSE 0 END) AS Canceladas,
             SUM(CASE WHEN t.estado = 'Pendiente' THEN 1 ELSE 0 END) AS Pendientes,
             COUNT(*) AS Total
             FROM Turnos t
             WHERE t.fecha BETWEEN @fechaInicio AND @fechaFin;";

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@fechaInicio", DTPDesde.Value.Date);
                cmd.Parameters.AddWithValue("@fechaFin", DTPHasta.Value.Date);
                conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int completadas = Convert.ToInt32(reader["Confirmados"]);
                    int canceladas = Convert.ToInt32(reader["Canceladas"]);
                    int pendientes = Convert.ToInt32(reader["Pendientes"]);
                    int total = Convert.ToInt32(reader["Total"]);

                    reader.Close();

                    //Eliminar el contenedor anterior si ya existe
                    if (contenedorResumen != null && this.Controls.Contains(contenedorResumen))
                    {
                        this.Controls.Remove(contenedorResumen);
                        contenedorResumen.Dispose();
                    }

                    // Crear el nuevo contenedor
                    contenedorResumen = new FlowLayoutPanel
                    {
                        Dock = DockStyle.Bottom,
                        Width = 750,
                        Height = 130,
                        AutoSize = false,
                        BackColor = Color.White,
                        Padding = new Padding(15),
                        FlowDirection = FlowDirection.LeftToRight,
                        WrapContents = false,
                        Margin = new Padding(0),
                    };

                    // Crear las tres tarjetas
                    Panel tarjetaConfirmadas = CrearTarjetaResumen(
                        completadas.ToString(),
                        "Turnos Confirmadas",
                        $"{(total > 0 ? Math.Round((double)completadas / total * 100, 1) : 0)}% del total",
                        Color.FromArgb(220, 255, 230),
                        Color.ForestGreen
                    );

                    Panel tarjetaCanceladas = CrearTarjetaResumen(
                        canceladas.ToString(),
                        "Turnos Canceladas",
                        $"{(total > 0 ? Math.Round((double)canceladas / total * 100, 1) : 0)}% del total",
                        Color.FromArgb(255, 230, 230),
                        Color.Firebrick
                    );

                    Panel tarjetaPendientes = CrearTarjetaResumen(
                        pendientes.ToString(),
                        "Turnos Pendientes",
                        "Próximas consultas programadas",
                        Color.FromArgb(230, 240, 255),
                        Color.RoyalBlue
                    );

                    // Agregar las tarjetas al contenedor
                    contenedorResumen.Controls.Add(tarjetaConfirmadas);
                    contenedorResumen.Controls.Add(tarjetaCanceladas);
                    contenedorResumen.Controls.Add(tarjetaPendientes);

                    // Posicionar el contenedor
                    contenedorResumen.Location = new Point(ChartEspecialidades.Left, ChartEspecialidades.Bottom + 20);
                    contenedorResumen.Left = (this.ClientSize.Width - contenedorResumen.Width) / 2;

                    this.Controls.Add(contenedorResumen);
                    contenedorResumen.BringToFront();
                }
            }
        }

        // Método auxiliar para crear cada tarjeta
        private Panel CrearTarjetaResumen(string valor, string titulo, string subtitulo, Color fondo, Color colorTexto)
        {
            Panel panel = new Panel
            {
                Width = 220,
                Height = 100,
                BackColor = fondo,
                Padding = new Padding(10),
                Margin = new Padding(30, 10, 30, 10),
            };

            Label lblValor = new Label
            {
                Text = valor,
                Font = new DFont("Segoe UI", 20, FontStyle.Bold),
                ForeColor = colorTexto,
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblTitulo = new Label
            {
                Text = titulo,
                Font = new DFont("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                Dock = DockStyle.Top,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblSubtitulo = new Label
            {
                Text = subtitulo,
                Font = new DFont("Segoe UI", 8, FontStyle.Regular),
                ForeColor = Color.Gray,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            panel.Controls.Add(lblSubtitulo);
            panel.Controls.Add(lblTitulo);
            panel.Controls.Add(lblValor);

            return panel;
        }
        private void CargarEstadisticasGenerales()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string queryTurnos = @"
                 SELECT COUNT(*) 
                 FROM Turnos 
                 WHERE fecha BETWEEN @fechaInicio AND @fechaFin;";

                SqlCommand cmdTurnos = new SqlCommand(queryTurnos, conexion);
                cmdTurnos.Parameters.AddWithValue("@fechaInicio", DTPDesde.Value.Date);
                cmdTurnos.Parameters.AddWithValue("@fechaFin", DTPHasta.Value.Date);

                int totalTurnos = Convert.ToInt32(cmdTurnos.ExecuteScalar());

                // Mostrar en las etiquetas
                LContadorTurnos.Text = totalTurnos.ToString();
            }
        }
        //----------parte de medicos-----------//

        // mostrar detalle del medico al hacer click en una fila
        private FlowLayoutPanel contenedorDetalleMedico;

        // cargar ranking de medicos
        private void CargarRankingMedicosGrid()
        {
            string query = @"
             SELECT 
              p.apellido + ', ' + p.nombre AS Medico,
              e.nombre AS Especialidad,
             COUNT(t.id_turno) AS CantidadTurnos
             FROM Turnos t
             INNER JOIN Agenda a ON t.id_agenda = a.id_agenda
             INNER JOIN Profesional_Consultorio pc ON a.id_profesional_consultorio = pc.id_profesional_consultorio
             INNER JOIN Profesional p ON pc.id_profesional = p.id_profesional
             INNER JOIN Especialidad e ON p.id_especialidad = e.id_especialidad
             WHERE t.fecha BETWEEN @fechaInicio AND @fechaFin
             GROUP BY p.apellido, p.nombre, e.nombre
             ORDER BY CantidadTurnos DESC;";

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.SelectCommand.Parameters.AddWithValue("@fechaInicio", DTPDesde.Value.Date);
                da.SelectCommand.Parameters.AddWithValue("@fechaFin", DTPHasta.Value.Date);

                DataTable dt = new DataTable();
                da.Fill(dt);

                DataTable dtRanking = new DataTable();
                dtRanking.Columns.Add("Posición", typeof(int));
                dtRanking.Columns.Add("Médico", typeof(string));
                dtRanking.Columns.Add("Especialidad", typeof(string));
                dtRanking.Columns.Add("Turnos Atendidos", typeof(int));

                int posicion = 1;
                foreach (DataRow row in dt.Rows)
                {
                    dtRanking.Rows.Add(posicion++, row["Medico"], row["Especialidad"], row["CantidadTurnos"]);
                }

                DTGRankingMedicos.DataSource = dtRanking;

                // estilos
                DTGRankingMedicos.EnableHeadersVisualStyles = false;
                DTGRankingMedicos.BorderStyle = BorderStyle.None;
                DTGRankingMedicos.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                DTGRankingMedicos.DefaultCellStyle.ForeColor = Color.Black;
                DTGRankingMedicos.ColumnHeadersDefaultCellStyle.Font = new DFont("Segoe UI", 10, FontStyle.Bold);
                DTGRankingMedicos.DefaultCellStyle.BackColor = Color.White;
                DTGRankingMedicos.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                DTGRankingMedicos.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
                DTGRankingMedicos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 220, 180);
                DTGRankingMedicos.DefaultCellStyle.SelectionForeColor = Color.Black;
                DTGRankingMedicos.DefaultCellStyle.Font = new DFont("Segoe UI", 9);
                DTGRankingMedicos.RowHeadersVisible = false;
                DTGRankingMedicos.AllowUserToAddRows = false;
                DTGRankingMedicos.ReadOnly = true;
                DTGRankingMedicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DTGRankingMedicos.GridColor = Color.White;
            }
        }
        // Pintar celdas de la columna posición con círculos de colores
        private void DTGRankingMedicos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);
                int pos = Convert.ToInt32(e.Value);

                Color circleColor = pos == 1 ? Color.Gold :// oro
                                    pos == 2 ? Color.Silver :// plata
                                    pos == 3 ? Color.FromArgb(205, 127, 50) : // Bronce
                                    Color.FromArgb(180, 220, 180);

                using (SolidBrush brush = new SolidBrush(circleColor))
                {
                    e.Graphics.FillEllipse(brush, e.CellBounds.X + 10, e.CellBounds.Y + 5, 25, 25);
                }

                e.Graphics.DrawString(pos.ToString(), new DFont("Segoe UI", 9, FontStyle.Bold),
                                      Brushes.White, e.CellBounds.X + 18, e.CellBounds.Y + 10);
                e.Handled = true;
            }
        }
        // cargar detalles de los medicos 
        private void CargarDetalleMedico()
        {
            string query = @"
             SELECT 
             p.apellido + ', ' + p.nombre AS 'Nombre Completo',
             SUM(CASE WHEN t.estado = 'Confirmado' THEN 1 ELSE 0 END) AS Confirmados,
             SUM(CASE WHEN t.estado = 'Cancelado' THEN 1 ELSE 0 END) AS Cancelados,
             SUM(CASE WHEN t.estado = 'Pendiente' THEN 1 ELSE 0 END) AS Pendientes,
             COUNT(*) AS Total,
             CASE WHEN COUNT(*) > 0 THEN 
             CAST(SUM(CASE WHEN t.estado = 'Confirmado' THEN 1 ELSE 0 END) * 100.0 / COUNT(*) AS DECIMAL(5,2))
             ELSE 0 END AS PorcentajeConfirmados
             FROM Turnos t
             INNER JOIN Agenda a ON t.id_agenda = a.id_agenda
             INNER JOIN Profesional_Consultorio pc ON a.id_profesional_consultorio = pc.id_profesional_consultorio
             INNER JOIN Profesional p ON pc.id_profesional = p.id_profesional
             WHERE t.fecha BETWEEN @fechaInicio AND @fechaFin
             GROUP BY p.nombre, p.apellido
             ORDER BY PorcentajeConfirmados DESC;";

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.SelectCommand.Parameters.AddWithValue("@fechaInicio", DTPDesde.Value.Date);
                da.SelectCommand.Parameters.AddWithValue("@fechaFin", DTPHasta.Value.Date);

                DataTable dt = new DataTable();
                da.Fill(dt);

                DTGDetalleMedico.DataSource = dt;

                // Estilos del DataGridView
                DTGDetalleMedico.EnableHeadersVisualStyles = false;
                DTGDetalleMedico.BorderStyle = BorderStyle.None;
                DTGDetalleMedico.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                DTGDetalleMedico.DefaultCellStyle.ForeColor = Color.Black;
                DTGDetalleMedico.ColumnHeadersDefaultCellStyle.Font = new DFont("Segoe UI", 10, FontStyle.Bold);
                DTGDetalleMedico.DefaultCellStyle.BackColor = Color.White;
                DTGDetalleMedico.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                DTGDetalleMedico.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
                DTGDetalleMedico.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 220, 180);
                DTGDetalleMedico.DefaultCellStyle.SelectionForeColor = Color.Black;
                DTGDetalleMedico.DefaultCellStyle.Font = new DFont("Segoe UI", 9);
                DTGDetalleMedico.RowHeadersVisible = false;
                DTGDetalleMedico.AllowUserToAddRows = false;
                DTGDetalleMedico.ReadOnly = true;
                DTGDetalleMedico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DTGDetalleMedico.GridColor = Color.White;
            }
        }
        
        //-------parte de pacientes-------//
        // cargar reporte de pacientes por sexo

        private FlowLayoutPanel contenedorPacientes;

        private void CargarReportePacientes()
        {
            string query = @"
             SELECT 
             p.sexo,
             COUNT(DISTINCT p.id_paciente) AS Cantidad
             FROM Paciente p
             -- para aplicar el filtro de fechas se usa el historial de consultas 
             INNER JOIN Historial h ON p.id_paciente = h.id_paciente
             WHERE h.fechaConsulta BETWEEN @fechaInicio AND @fechaFin
             AND p.id_estado = 1
             GROUP BY p.sexo;";

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.SelectCommand.Parameters.AddWithValue("@fechaInicio", DTPDesde.Value.Date);
                da.SelectCommand.Parameters.AddWithValue("@fechaFin", DTPHasta.Value.Date);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay pacientes con consultas en el rango seleccionado.");
                    return;
                }

                int total = dt.AsEnumerable().Sum(r => r.Field<int>("Cantidad"));
                int masculino = dt.AsEnumerable().Where(r => r.Field<string>("sexo") == "Masculino").Select(r => r.Field<int>("Cantidad")).FirstOrDefault();
                int femenino = dt.AsEnumerable().Where(r => r.Field<string>("sexo") == "Femenino").Select(r => r.Field<int>("Cantidad")).FirstOrDefault();

                double porcMasculino = total > 0 ? Math.Round((double)masculino / total * 100, 1) : 0;
                double porcFemenino = total > 0 ? Math.Round((double)femenino / total * 100, 1) : 0;

                // Eliminar solo el contenedor anterior si existe, sin borrar el DataGrid
                if (contenedorPacientes != null && GBPacientes.Controls.Contains(contenedorPacientes))
                {
                    GBPacientes.Controls.Remove(contenedorPacientes);
                    contenedorPacientes.Dispose();
                }

                // Crear contenedor superior con las tarjetas
                contenedorPacientes = new FlowLayoutPanel
                {
                    Dock = DockStyle.Top,
                    Height = 160,
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = false,
                    AutoScroll = true,
                    Padding = new Padding(40, 5, 40, 5),
                    BackColor = Color.White
                };

                //Crear las tarjetas de género
                Panel tarjetaMasculino = CrearTarjetaGenero(masculino.ToString(), "Masculino", $"{porcMasculino}% del total", Color.FromArgb(230, 240, 255), Color.FromArgb(0, 102, 255));
                Panel tarjetaFemenino = CrearTarjetaGenero(femenino.ToString(), "Femenino", $"{porcFemenino}% del total", Color.FromArgb(255, 240, 245), Color.DeepPink);
                Panel tarjetaTotal = CrearTarjetaGenero(total.ToString(), "Total Pacientes", "Con consultas en el rango seleccionado", Color.FromArgb(240, 255, 240), Color.ForestGreen);

                contenedorPacientes.Controls.Add(tarjetaMasculino);
                contenedorPacientes.Controls.Add(tarjetaFemenino);
                contenedorPacientes.Controls.Add(tarjetaTotal);

                //Agregar las tarjetas al GroupBox
                GBPacientes.Controls.Add(contenedorPacientes);
                contenedorPacientes.BringToFront();

                // Asegurar que el DataGrid esté visible debajo
                if (!GBPacientes.Controls.Contains(DTGRankingPacientes))
                {
                    DTGRankingPacientes.Dock = DockStyle.Fill;
                    GBPacientes.Controls.Add(DTGRankingPacientes);
                }
                DTGRankingPacientes.Visible = true;
                DTGRankingPacientes.BringToFront();
            }
        }

        private Panel CrearTarjetaGenero(string valor, string titulo, string subtitulo, Color fondo, Color colorTexto)
        {
            Panel panel = new Panel
            {
                Width = 260,
                Height = 130,
                BackColor = fondo,
                Margin = new Padding(25, 10, 25, 10), // separación entre tarjetas
                Padding = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblValor = new Label
            {
                Text = valor,
                Font = new DFont("Segoe UI", 24, FontStyle.Bold),
                ForeColor = colorTexto,
                Dock = DockStyle.Top,
                Height = 50,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblTitulo = new Label
            {
                Text = titulo,
                Font = new DFont("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                Dock = DockStyle.Top,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblSubtitulo = new Label
            {
                Text = subtitulo,
                Font = new DFont("Segoe UI", 8, FontStyle.Regular),
                ForeColor = Color.Gray,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            panel.Controls.Add(lblSubtitulo);
            panel.Controls.Add(lblTitulo);
            panel.Controls.Add(lblValor);

            return panel;
        }
        // ranking de pacientes con mas turnos
        private void CargarRankingPacientesGrid()
        {
            string query = @"
             SELECT 
             p.apellido + ', ' + p.nombre AS Paciente,
             p.dni,
             COUNT(t.id_turno) AS CantidadTurnos,
             MAX(t.fecha) AS UltimaVisita
             FROM Turnos t
             INNER JOIN Paciente p ON t.id_paciente = p.id_paciente
             WHERE t.fecha BETWEEN @fechaInicio AND @fechaFin
             GROUP BY p.apellido, p.nombre, p.dni
             ORDER BY CantidadTurnos DESC;";

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.SelectCommand.Parameters.AddWithValue("@fechaInicio", DTPDesde.Value.Date);
                da.SelectCommand.Parameters.AddWithValue("@fechaFin", DTPHasta.Value.Date);

                DataTable dt = new DataTable();
                da.Fill(dt);

                DataTable dtRanking = new DataTable();
                dtRanking.Columns.Add("Posición", typeof(int));
                dtRanking.Columns.Add("Paciente", typeof(string));
                dtRanking.Columns.Add("DNI", typeof(string));
                dtRanking.Columns.Add("Turnos", typeof(int));
                dtRanking.Columns.Add("Última Visita", typeof(DateTime));

                int posicion = 1;
                foreach (DataRow row in dt.Rows)
                {
                    dtRanking.Rows.Add(posicion++, row["Paciente"], row["dni"], row["CantidadTurnos"], row["UltimaVisita"]);
                }

                DTGRankingPacientes.DataSource = dtRanking;

                // estilos
                DTGRankingPacientes.EnableHeadersVisualStyles = false;
                DTGRankingPacientes.BorderStyle = BorderStyle.None;
                DTGRankingPacientes.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                DTGRankingPacientes.DefaultCellStyle.ForeColor = Color.Black;
                DTGRankingPacientes.ColumnHeadersDefaultCellStyle.Font = new DFont("Segoe UI", 12, FontStyle.Bold);
                DTGRankingPacientes.DefaultCellStyle.BackColor = Color.White;
                DTGRankingPacientes.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                DTGRankingPacientes.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
                DTGRankingPacientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 220, 180);
                DTGRankingPacientes.DefaultCellStyle.SelectionForeColor = Color.Black;
                DTGRankingPacientes.DefaultCellStyle.Font = new DFont("Segoe UI", 9);
                DTGRankingPacientes.RowHeadersVisible = false;
                DTGRankingPacientes.AllowUserToAddRows = false;
                DTGRankingPacientes.ReadOnly = true;
                DTGRankingPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DTGRankingPacientes.GridColor = Color.White;
            }
        }
        private void DTGRankingPacientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);
                int pos = Convert.ToInt32(e.Value);

                // Ajustar tamaño dinámico según la altura de la celda
                int circleSize = Math.Min(e.CellBounds.Height - 6, 30); // máximo 30px
                int circleX = e.CellBounds.X + 10;
                int circleY = e.CellBounds.Y + (e.CellBounds.Height - circleSize) / 2;

                Color circleColor = pos == 1 ? Color.Gold ://oro 1°lugar
                                    pos == 2 ? Color.Silver ://plata 2° lugar
                                    pos == 3 ? Color.FromArgb(205, 127, 50) :// bronce 3° lugar
                                    Color.FromArgb(180, 220, 180);

                using (SolidBrush brush = new SolidBrush(circleColor))
                {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.FillEllipse(brush, circleX, circleY, circleSize, circleSize);
                }

                // Centrar el número dentro del círculo
                string text = pos.ToString();
                using (DFont font = new DFont("Segoe UI", 9, FontStyle.Bold))
                {
                    SizeF textSize = e.Graphics.MeasureString(text, font);
                    float textX = circleX + (circleSize - textSize.Width) / 2;
                    float textY = circleY + (circleSize - textSize.Height) / 2;
                    e.Graphics.DrawString(text, font, Brushes.White, textX, textY);
                }

                e.Handled = true;
            }
        }
        // grafico de tortas con las edades de los pacientes
        /* private void CargarDistribucionEdades()
         {
             string query = @"
              SELECT 
              CASE 
                 WHEN DATEDIFF(YEAR, p.fecha_nacimiento, GETDATE()) BETWEEN 0 AND 17 THEN '0-17 años'
                 WHEN DATEDIFF(YEAR, p.fecha_nacimiento, GETDATE()) BETWEEN 18 AND 35 THEN '18-35 años'
                 WHEN DATEDIFF(YEAR, p.fecha_nacimiento, GETDATE()) BETWEEN 36 AND 50 THEN '36-50 años'
                 WHEN DATEDIFF(YEAR, p.fecha_nacimiento, GETDATE()) BETWEEN 51 AND 65 THEN '51-65 años'
                 ELSE '66+ años'
              END AS RangoEdad,
              COUNT(DISTINCT p.id_paciente) AS Cantidad
              FROM Paciente p
              INNER JOIN Historial h ON p.id_paciente = h.id_paciente
              WHERE h.fechaConsulta BETWEEN @fechaInicio AND @fechaFin
              AND p.id_estado = 1
              GROUP BY 
              CASE 
                 WHEN DATEDIFF(YEAR, p.fecha_nacimiento, GETDATE()) BETWEEN 0 AND 17 THEN '0-17 años'
                 WHEN DATEDIFF(YEAR, p.fecha_nacimiento, GETDATE()) BETWEEN 18 AND 35 THEN '18-35 años'
                 WHEN DATEDIFF(YEAR, p.fecha_nacimiento, GETDATE()) BETWEEN 36 AND 50 THEN '36-50 años'
                 WHEN DATEDIFF(YEAR, p.fecha_nacimiento, GETDATE()) BETWEEN 51 AND 65 THEN '51-65 años'
                 ELSE '66+ años'
              END
              ORDER BY RangoEdad;";

             using (SqlConnection conexion = Conexion.GetConnection())
             {
                 SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                 da.SelectCommand.Parameters.AddWithValue("@fechaInicio", DTPDesde.Value.Date);
                 da.SelectCommand.Parameters.AddWithValue("@fechaFin", DTPHasta.Value.Date);

                 DataTable dt = new DataTable();
                 da.Fill(dt);

                 if (dt.Rows.Count == 0)
                 {
                     MessageBox.Show("No hay datos de edades en el rango seleccionado.");
                     return;
                 }

                 // Crear el Chart
                 Chart ChartEdades = new Chart
                 {
                     Name = "ChartEdades",
                     Dock = DockStyle.Right,
                     Width = 380,
                     Height = 250,
                     BackColor = Color.White
                 };

                 ChartArea area = new ChartArea();
                 area.BackColor = Color.White;
                 ChartEdades.ChartAreas.Add(area);

                 Series serie = new Series("Edades")
                 {
                     ChartType = SeriesChartType.Pie,
                     Font = new Font("Segoe UI", 9, FontStyle.Bold),
                     IsValueShownAsLabel = true,
                     LabelForeColor = Color.White
                 };

                 ChartEdades.Series.Add(serie);

                 // Colores personalizados (como tu ejemplo)
                 string[] colores = { "#3B82F6", "#60A5FA", "#93C5FD", "#BFDBFE", "#DBEAFE" };

                 for (int i = 0; i < dt.Rows.Count; i++)
                 {
                     DataRow row = dt.Rows[i];
                     string rango = row["RangoEdad"].ToString();
                     int cantidad = Convert.ToInt32(row["Cantidad"]);

                     int pIndex = serie.Points.AddXY(rango, cantidad);
                     serie.Points[pIndex].Color = ColorTranslator.FromHtml(colores[i % colores.Length]);
                     serie.Points[pIndex].Label = cantidad.ToString();
                 }

                 ChartEdades.Titles.Add("Distribución por Edad");
                 ChartEdades.Titles[0].Font = new Font("Segoe UI", 11, FontStyle.Bold);
                 ChartEdades.Titles[0].Alignment = ContentAlignment.TopLeft;

                 GBPacientes.Controls.Add(ChartEdades);
                 ChartEdades.BringToFront();
             }
         }*/
        // botones de accion
        private void BFiltro_Click(object sender, EventArgs e)
        {
            if (DTPDesde.Value.Date > DTPHasta.Value.Date)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.");
                return;
            }
            // limpiar todo previamente
            ChartEspecialidades.Series.Clear();
            DTGRankingMedicos.DataSource = null;
            // si es el boton medico visible esos graficos
            if (GBMedicos.Visible)
            {
                CargarRankingMedicosGrid();
                CargarDetalleMedico();
            }// si es el boton pacientes visible esos graficos
            else if (GBPacientes.Visible)
            {
                CargarReportePacientes();
                CargarRankingPacientesGrid();
                // CargarDistribucionEdades();
            }
            // sino cargar los graficos generales
            else
            {
                CargarGrafico();
                CargarRankingMedicosGrid();
                CargarResumenCitas();
                CargarEstadisticasGenerales();
            }
        }
        private void BVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // boon de medicos
        private void BMedico_Click(object sender, EventArgs e)
        {
            // Ocultar todo lo visible en el formulario
            ChartEspecialidades.Visible = false;
            if (contenedorResumen != null) contenedorResumen.Visible = false;
            if (contenedorDetalleMedico != null) contenedorDetalleMedico.Visible = false;
            if (this.Controls.ContainsKey("lblDescripcionGrafico"))
                this.Controls["lblDescripcionGrafico"].Visible = false;
            GBContadorTurnos.Visible = false;
            GBPacientes.Visible = false;

            // Mostrar el GroupBox de Médicos
            GBMedicos.Visible = true;

            // Cargar el ranking de médicos
            CargarRankingMedicosGrid();

            // Cargar el detalle general de médicos (confirmados/cancelados/porcentaje)
            CargarDetalleMedico();
        }
        // boton de pacientes
        private void BPacientes_Click(object sender, EventArgs e)
        {
            // Ocultar todo lo visible en el formulario
            ChartEspecialidades.Visible = false;
            if (contenedorResumen != null) contenedorResumen.Visible = false;
            if (contenedorDetalleMedico != null) contenedorDetalleMedico.Visible = false;
            if (this.Controls.ContainsKey("lblDescripcionGrafico"))
                this.Controls["lblDescripcionGrafico"].Visible = false;
            // Ocultar otros GroupBox
            GBContadorTurnos.Visible = false;
            GBMedicos.Visible = false;

            // Mostrar el de pacientes
            GBPacientes.Visible = true;
            GBPacientes.BringToFront();
            // graficos de pacientes
            CargarReportePacientes();
            CargarRankingPacientesGrid();
            //CargarDistribucionEdades();
        }

        private void Turnos_Click(object sender, EventArgs e)
        {
            // Ocultar el GroupBox de Médicos
            GBMedicos.Visible = false;
            GBPacientes.Visible = false;

            // Mostrar el gráfico y las estadísticas generales
            ChartEspecialidades.Visible = true;
            GBContadorTurnos.Visible = true;

            if (this.Controls.ContainsKey("lblDescripcionGrafico"))
                this.Controls["lblDescripcionGrafico"].Visible = true;

            // Mostrar tarjetas de resumen si existen
            if (contenedorResumen != null)
                contenedorResumen.Visible = true;

            // Ocultar cualquier detalle de médico si existe
            if (contenedorDetalleMedico != null)
                contenedorDetalleMedico.Visible = false;

            // Recargar datos por si las fechas cambiaron
            CargarGrafico();
            CargarResumenCitas();
            CargarEstadisticasGenerales();
        }

        private void BImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                // Captura la imagen del formulario completo
                Bitmap captura = new Bitmap(this.Width, this.Height);
                this.DrawToBitmap(captura, new DRectangle(0, 0, this.Width, this.Height));

                // Crea el documento PDF
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivo PDF|*.pdf",
                    Title = "Guardar reporte en PDF",
                    FileName = "ReporteEstadisticas.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        // Tamaño del PDF proporcional al formulario
                        var doc = new Document(new iTextSharp.text.Rectangle(captura.Width, captura.Height), 0, 0, 0, 0);
                        PdfWriter.GetInstance(doc, stream);
                        doc.Open();

                        // Convierte el bitmap a imagen PDF
                        using (MemoryStream imageStream = new MemoryStream())
                        {
                            captura.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
                            iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(imageStream.ToArray());
                            pdfImage.ScaleToFit(doc.PageSize.Width, doc.PageSize.Height);
                            pdfImage.Alignment = Element.ALIGN_CENTER;

                            //Agrega la imagen al PDF
                            doc.Add(pdfImage);
                        }

                        doc.Close();
                        stream.Close();
                    }
                    this.ActiveControl = null;
                    MessageBox.Show("Reporte guardado correctamente en PDF.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);            }
        }
    }
}
