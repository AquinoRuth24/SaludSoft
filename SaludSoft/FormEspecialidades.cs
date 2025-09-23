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
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
            CargarEspecialidades();
        }


        private void CargarEspecialidades()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                string query = "SELECT id_especialidad, nombre FROM Especialidad";
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DGVEspecialidad.DataSource = dt;
            }
        }

        private void BAgregar_Click(object sender, EventArgs e)
        {
            string nombre = TBNombre.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Debe ingresar un nombre de especialidad.");
                return;
            }

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                string query = "INSERT INTO Especialidad (nombre) VALUES (@nombre)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@nombre", nombre);

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Especialidad agregada correctamente.");
                    CargarEspecialidades(); // refresca la lista
                   TBNombre.Clear();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // violación de UNIQUE
                        MessageBox.Show("La especialidad ya existe.");
                    else
                        MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
