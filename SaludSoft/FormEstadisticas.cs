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
            CargarGrafico();
            CargarRankingMedicosGrid();
            CargarActividadTurnosGrid();

            DTGRankingMedicos.CellPainting += DTGRankingMedicos_CellPainting;
            DTGActividadPorTurno.CellFormatting += DTGActividadTurnos_CellFormatting;

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
                WHERE t.fecha >= DATEADD(MONTH, -1, GETDATE())
                GROUP BY e.nombre
                ORDER BY CantidadTurnos DESC; ";

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para mostrar en el último mes.");
                    return;
                }

                // Calcular total de turnos
                int totalTurnos = dt.AsEnumerable().Sum(r => r.Field<int>("CantidadTurnos"));

                // Agregar columna de porcentaje
                dt.Columns.Add("Porcentaje", typeof(double));
                foreach (DataRow row in dt.Rows)
                {
                    double cantidad = Convert.ToDouble(row["CantidadTurnos"]);
                    row["Porcentaje"] = Math.Round((cantidad / totalTurnos) * 100, 1);
                }

                // Usar la configuración del diseñador
                ChartEspecialidades.Series[0].XValueMember = "Especialidad";
                ChartEspecialidades.Series[0].YValueMembers = "CantidadTurnos";
                ChartEspecialidades.DataSource = dt;
                ChartEspecialidades.DataBind();

                // Cambiar tipo a barras horizontales
                ChartEspecialidades.Series[0].ChartType = SeriesChartType.Bar;

                // Colores suaves tipo pastel
                //ChartEspecialidades.Series[0].Color = Color.FromArgb(120, 200, 150); // verde suave
                ChartEspecialidades.Palette = ChartColorPalette.None;

                // Bordes redondeados y sin borde negro
                ChartEspecialidades.Series[0].BorderWidth = 0;

                // Ejes minimalistas
                ChartEspecialidades.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                ChartEspecialidades.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                ChartEspecialidades.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
                ChartEspecialidades.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                // Leyenda fuera y título
                ChartEspecialidades.Legends.Clear();
                ChartEspecialidades.Titles.Clear();
                ChartEspecialidades.Titles.Add("Citas por Especialidad");
                ChartEspecialidades.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);
                ChartEspecialidades.Titles[0].ForeColor = Color.FromArgb(40, 60, 40);
                ChartEspecialidades.Titles[0].Alignment = ContentAlignment.TopLeft;

                // Etiquetas dentro de las barras
                foreach (var point in ChartEspecialidades.Series[0].Points)
                {
                    point.LabelForeColor = Color.Black;
                    point.Font = new Font("Segoe UI", 9);
                    point.LabelBackColor = Color.Transparent;
                }

                // Agregar porcentaje al label
                for (int i = 0; i < ChartEspecialidades.Series[0].Points.Count; i++)
                {
                    DataPoint punto = ChartEspecialidades.Series[0].Points[i];
                    double porcentaje = Convert.ToDouble(dt.Rows[i]["Porcentaje"]);
                    punto.Label = $"{punto.YValues[0]} ({porcentaje}%)";
                }
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
             WHERE t.fecha >= DATEADD(MONTH, -1, GETDATE())
             GROUP BY p.apellido, p.nombre, e.nombre
             ORDER BY CantidadTurnos DESC;";

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
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

                //estilos
                DTGRankingMedicos.EnableHeadersVisualStyles = false;
                DTGRankingMedicos.BorderStyle = BorderStyle.None;
                DTGRankingMedicos.ColumnHeadersDefaultCellStyle.BackColor = Color.White;// columnas de encabezado
                DTGRankingMedicos.DefaultCellStyle.ForeColor = Color.Black;// color de texto
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
        // boton volver
        private void BVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // cargar actividad por turnos
        private void CargarActividadTurnosGrid()
        {
            string query = @"
             SELECT 
              e.nombre AS Especialidad,
              t.estado AS Estado,
             COUNT(t.id_turno) AS CantidadTurnos
             FROM Turnos t
             INNER JOIN Agenda a ON t.id_agenda = a.id_agenda
             INNER JOIN Profesional_Consultorio pc ON a.id_profesional_consultorio = pc.id_profesional_consultorio
             INNER JOIN Profesional p ON pc.id_profesional = p.id_profesional
             INNER JOIN Especialidad e ON p.id_especialidad = e.id_especialidad
             WHERE t.fecha >= DATEADD(MONTH, -1, GETDATE())
             GROUP BY e.nombre, t.estado
             ORDER BY e.nombre, t.estado;";

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DTGActividadPorTurno.DataSource = dt;

                // Estilos visuales
                DTGActividadPorTurno.EnableHeadersVisualStyles = false;
                DTGActividadPorTurno.BorderStyle = BorderStyle.None;
                DTGActividadPorTurno.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                DTGActividadPorTurno.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                DTGActividadPorTurno.DefaultCellStyle.ForeColor = Color.Black;
                DTGActividadPorTurno.DefaultCellStyle.BackColor = Color.White;
                DTGActividadPorTurno.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
                DTGActividadPorTurno.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 220, 180);
                DTGActividadPorTurno.DefaultCellStyle.SelectionForeColor = Color.Black;
                DTGActividadPorTurno.DefaultCellStyle.Font = new Font("Segoe UI", 9);
                DTGActividadPorTurno.RowHeadersVisible = false;
                DTGActividadPorTurno.AllowUserToAddRows = false;
                DTGActividadPorTurno.ReadOnly = true;
                DTGActividadPorTurno.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DTGActividadPorTurno.GridColor = Color.White;

                // Título de columnas
                DTGActividadPorTurno.Columns["Especialidad"].HeaderText = "Especialidad";
                DTGActividadPorTurno.Columns["Estado"].HeaderText = "Estado del Turno";
                DTGActividadPorTurno.Columns["CantidadTurnos"].HeaderText = "Cantidad de Turnos";
            }
        }
        // colorear filas segun el estado del turno
        private void DTGActividadTurnos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DTGActividadPorTurno.Columns["Estado"].Index == e.ColumnIndex && e.Value != null)
            {
                string estado = e.Value.ToString().ToLower();

                if (estado.Contains("confirmado"))
                {
                    DTGActividadPorTurno.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(210, 250, 210); // verde claro
                }
                else if (estado.Contains("cancelado"))
                {
                    DTGActividadPorTurno.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220); // rojo claro
                }
                else if (estado.Contains("pendiente"))
                {
                    DTGActividadPorTurno.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200); // amarillo claro
                }
            }
        }

    }
}
