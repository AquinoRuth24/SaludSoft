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
            }
        }
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

                Color circleColor = pos == 1 ? Color.Gold :
                                    pos == 2 ? Color.Silver :
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
        private FlowLayoutPanel contenedorResumen;

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
                        "Citas Confirmadas",
                        $"{(total > 0 ? Math.Round((double)completadas / total * 100, 1) : 0)}% del total",
                        Color.FromArgb(220, 255, 230),
                        Color.ForestGreen
                    );

                    Panel tarjetaCanceladas = CrearTarjetaResumen(
                        canceladas.ToString(),
                        "Citas Canceladas",
                        $"{(total > 0 ? Math.Round((double)canceladas / total * 100, 1) : 0)}% del total",
                        Color.FromArgb(255, 230, 230),
                        Color.Firebrick
                    );

                    Panel tarjetaPendientes = CrearTarjetaResumen(
                        pendientes.ToString(),
                        "Citas Pendientes",
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

            CargarGrafico();
            CargarRankingMedicosGrid();
            CargarResumenCitas();
            CargarEstadisticasGenerales();
        }
        private void BVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
