using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
            CargarEspecialidades();
            DGVEspecialidad.RowTemplate.Height = 30; // alto de cada fila
            DGVEspecialidad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // columnas ajustan al ancho
        }

        private void CargarEspecialidades()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                string query = "SELECT nombre FROM Especialidad";
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DGVEspecialidad.DataSource = dt;

                LContador.Text = dt.Rows.Count.ToString();
                LDescripcion.Text = "Especialidades Registradas";
            }
        }

        private void MostrarProfesionalesDeEspecialidad(string nombreEspecialidad)
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                string query = @"
                 SELECT p.nombre + ' ' + p.apellido AS Profesional
                 FROM Profesional p
                 INNER JOIN Especialidad e ON p.id_especialidad = e.id_especialidad
                 WHERE e.nombre = @nombreEspecialidad";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@nombreEspecialidad", nombreEspecialidad);

                conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                List<string> profesionales = new List<string>();

                while (reader.Read())
                {
                    profesionales.Add(reader["Profesional"].ToString());
                }

                reader.Close();

                if (profesionales.Count > 0)
                {
                    string lista = string.Join("\n", profesionales);
                    MessageBox.Show($"Especialidad: {nombreEspecialidad}\n\nProfesionales:\n{lista}",
                                    "Información del Profesional",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"No hay profesionales registrados para la especialidad: {nombreEspecialidad}",
                                    "Información del Profesional",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
        }
        private void DGVEspecialidad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nombreEspecialidad = DGVEspecialidad.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                MostrarProfesionalesDeEspecialidad(nombreEspecialidad);
            }
        }

        // Función para normalizar el texto (quita acentos y pasa a minúsculas)
        private string Normalizar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return string.Empty;

            string lower = texto.ToLower(new CultureInfo("es-ES")).Normalize(NormalizationForm.FormD);

            var chars = lower
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray();

            return new string(chars);
        }

        private void BAgregar_Click(object sender, EventArgs e)
        {
            string nombreOriginal = TBNombre.Text.Trim();
            string nombreNormalizado = Normalizar(nombreOriginal);

            if (string.IsNullOrEmpty(nombreOriginal))
            {
                MessageBox.Show("Debe ingresar un nombre de especialidad.");
                return;
            }

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                // Guarda la versión normalizada para evitar duplicados
                string query = "INSERT INTO Especialidad (nombre) VALUES (@nombre)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@nombre", nombreNormalizado);

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Especialidad agregada correctamente.");
                    CargarEspecialidades();
                    TBNombre.Clear();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                        MessageBox.Show("La especialidad ya existe.");
                    else
                        MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void BVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
