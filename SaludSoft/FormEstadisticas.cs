using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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

            BFiltro.Click += BFiltro_Click;

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
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
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
                ChartEspecialidades.Titles[0].Font = new Font("Segoe UI", 11, FontStyle.Bold);
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
                lblDescripcionGrafico.Text = descripcion.ToString();
                lblDescripcionGrafico.Font = new Font("Segoe UI", 9, FontStyle.Regular);
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
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = colorTexto,
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                Dock = DockStyle.Top,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblSubtitulo = new Label
            {
                Text = subtitulo,
                Font = new Font("Segoe UI", 8, FontStyle.Regular),
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
                DTGRankingMedicos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                DTGRankingMedicos.DefaultCellStyle.BackColor = Color.White;
                DTGRankingMedicos.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                DTGRankingMedicos.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
                DTGRankingMedicos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 220, 180);
                DTGRankingMedicos.DefaultCellStyle.SelectionForeColor = Color.Black;
                DTGRankingMedicos.DefaultCellStyle.Font = new Font("Segoe UI", 9);
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

                e.Graphics.DrawString(pos.ToString(), new Font("Segoe UI", 9, FontStyle.Bold),
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
                DTGDetalleMedico.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                DTGDetalleMedico.DefaultCellStyle.BackColor = Color.White;
                DTGDetalleMedico.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                DTGDetalleMedico.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
                DTGDetalleMedico.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 220, 180);
                DTGDetalleMedico.DefaultCellStyle.SelectionForeColor = Color.Black;
                DTGDetalleMedico.DefaultCellStyle.Font = new Font("Segoe UI", 9);
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
             sexo,
             COUNT(*) AS Cantidad
             FROM Paciente
             WHERE id_estado = 1 -- opcional
             GROUP BY sexo;";

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay pacientes registrados.");
                    return;
                }

                int total = dt.AsEnumerable().Sum(r => r.Field<int>("Cantidad"));
                int masculino = dt.AsEnumerable()
                    .Where(r => r.Field<string>("sexo") == "Masculino")
                    .Select(r => r.Field<int>("Cantidad"))
                    .FirstOrDefault();
                int femenino = dt.AsEnumerable()
                    .Where(r => r.Field<string>("sexo") == "Femenino")
                    .Select(r => r.Field<int>("Cantidad"))
                    .FirstOrDefault();

                double porcMasculino = total > 0 ? Math.Round((double)masculino / total * 100, 1) : 0;
                double porcFemenino = total > 0 ? Math.Round((double)femenino / total * 100, 1) : 0;

                // Limpiar contenido previo
                GBPacientes.Controls.Clear();

                // Crear contenedor interno 
                contenedorPacientes = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = false, // mantiene una sola fila
                    AutoScroll = true,
                    Padding = new Padding(40, 25, 40, 25), //espacio interno
                    BackColor = Color.White
                };

                // Crear tarjetas
                Panel tarjetaMasculino = CrearTarjetaGenero(
                    masculino.ToString(),
                    "Masculino",
                    $"{porcMasculino}% del total",
                    Color.FromArgb(230, 240, 255),
                    Color.FromArgb(0, 102, 255)
                );

                Panel tarjetaFemenino = CrearTarjetaGenero(
                    femenino.ToString(),
                    "Femenino",
                    $"{porcFemenino}% del total",
                    Color.FromArgb(255, 240, 245),
                    Color.DeepPink
                );

                Panel tarjetaTotal = CrearTarjetaGenero(
                    total.ToString(),
                    "Total Pacientes",
                    "Registrados en el sistema",
                    Color.FromArgb(240, 255, 240),
                    Color.ForestGreen
                );

                // Agregar tarjetas al contenedor
                contenedorPacientes.Controls.Add(tarjetaMasculino);
                contenedorPacientes.Controls.Add(tarjetaFemenino);
                contenedorPacientes.Controls.Add(tarjetaTotal);

                // Agregar el contenedor al GroupBox
                GBPacientes.Controls.Add(contenedorPacientes);

                // Configurar el GroupBox 
                GBPacientes.Dock = DockStyle.Top;
                GBPacientes.Height = 180; // altura tipo franja
                GBPacientes.Padding = new Padding(0);
                GBPacientes.BackColor = Color.FromArgb(245, 245, 245); // color suave de fondo
                GBPacientes.Visible = true;
                GBPacientes.BringToFront();
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
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = colorTexto,
                Dock = DockStyle.Top,
                Height = 50,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblTitulo = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                Dock = DockStyle.Top,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblSubtitulo = new Label
            {
                Text = subtitulo,
                Font = new Font("Segoe UI", 8, FontStyle.Regular),
                ForeColor = Color.Gray,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            panel.Controls.Add(lblSubtitulo);
            panel.Controls.Add(lblTitulo);
            panel.Controls.Add(lblValor);

            return panel;
        }
        // botones de accion
        private void BFiltro_Click(object sender, EventArgs e)
        {
            if (DTPDesde.Value.Date > DTPHasta.Value.Date)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.");
                return;
            }

            // Limpiar antes de recargar
            ChartEspecialidades.Series.Clear();
            DTGRankingMedicos.DataSource = null;

            // Si el GBMedicos está visible, solo recargar los médicos
            if (GBMedicos.Visible)
            {
                CargarRankingMedicosGrid();
                CargarDetalleMedico();
            }
            else
            {
                // Si estamos en la vista general, recargar todo lo demás
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
            CargarReportePacientes();
        }
    }
}
