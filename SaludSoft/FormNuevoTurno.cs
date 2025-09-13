using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SaludSoft
{
    public partial class FormNuevoTurno : Form
    {
        public FormNuevoTurno()
        {
            InitializeComponent();
            CargarDoctores();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void CargarDoctores()
        {
            try
            {
                using (SqlConnection conexion = Conexion.GetConnection())
                {
                    conexion.Open();
                    string query = "SELECT id_profesional, nombre + ' ' + apellido AS Doctor FROM Profesional";

                    SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbDoctores.DataSource = dt;
                    // se configura para mostrar el nombre completo(se concatena en la base de datos)
                    cmbDoctores.DisplayMember = "Doctor";
                    // se guarda el id del profesional
                    cmbDoctores.ValueMember = "id_profesional";
                    // para que no se muestre ninguna seleccion inicial 
                    cmbDoctores.SelectedIndex = -1;
                    // se ve mientras no se haya seleccionado nada
                    cmbDoctores.Text = "Seleccione un doctor";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar doctores: " + ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

    }
}
