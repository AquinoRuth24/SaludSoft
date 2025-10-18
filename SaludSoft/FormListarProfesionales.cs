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

namespace SaludSoft
{
    public partial class FormListarProfesionales : Form
    {
        public FormListarProfesionales()
        {
            InitializeComponent();
            CargarProfesionalesActivos();
            ConfigurarGrilla();
        }
        // muestra los profesionales con nombre, apellido y su estado 
        private void CargarProfesionalesActivos()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"
                    SELECT 
                        p.id_profesional,
                        p.nombre AS Nombre,
                        p.apellido AS Apellido,
                        e.descripcion AS Estado
                    FROM Profesional p
                    INNER JOIN Estado e ON e.id_estado = p.id_estado";

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DGProfesionales.DataSource = dt;
            }

            DGProfesionales.ClearSelection();
        }
        // colorea las filas de los profesionales que estan inactivos 
        private void ConfigurarGrilla()
        {
            DGProfesionales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGProfesionales.ReadOnly = true;
            DGProfesionales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGProfesionales.AllowUserToAddRows = false;
            DGProfesionales.AllowUserToDeleteRows = false;

            DGProfesionales.CellFormatting += DGProfesionales_CellFormatting;
        }
        // mostrar la especialidad del profesional que se selecciona
        private void MostrarEspecialidad(int idProfesional)
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"
                 SELECT TOP 1 e.nombre
                 FROM Profesional p
                 INNER JOIN Especialidad e ON e.id_especialidad = p.id_especialidad
                 WHERE p.id_profesional = @idProfesional";


                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@idProfesional", idProfesional);

                object result = cmd.ExecuteScalar();

                string especialidad = result != null ? result.ToString() : "Sin especialidad asignada";

                MessageBox.Show(
                    $"Especialidad: {especialidad}",
                    "Información del Profesional",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
        private void DGProfesionales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idProfesional = Convert.ToInt32(DGProfesionales.Rows[e.RowIndex].Cells["id_profesional"].Value);
            MostrarEspecialidad(idProfesional);
        }

        private void DGProfesionales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGProfesionales.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString().ToLower();

                // Inactivos con fondo rojo claro
                if (estado.Contains("inactivo"))
                {
                    DGProfesionales.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                    DGProfesionales.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                }
                else if (estado.Contains("activo"))
                {
                    DGProfesionales.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Honeydew;
                    DGProfesionales.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGreen;
                }
            }
        }
    }
}
