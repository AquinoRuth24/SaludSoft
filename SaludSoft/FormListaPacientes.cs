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
    public partial class FormListaPacientes : Form
    {
        public FormListaPacientes()
        {
            if (!DesignMode)
            {
                InitializeComponent();
                CargarPacientes();
            }
        }
        // botones 
        private void BInicioFormTurno_Click(object sender, EventArgs e)
        {
            SaludSoft frm = new SaludSoft();
            frm.ShowDialog();
            this.Close();
        }

        private void BPacientesFormTurno_Click(object sender, EventArgs e)
        {
            FormListaPacientes frm = new FormListaPacientes();
            frm.ShowDialog();
            this.Close();
        }

        private void BVolver_Click(object sender, EventArgs e)
        {
           
            this.Close(); 
        }
        // cargar pacientes
        private void CargarPacientes()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = "SELECT nombre, apellido, dni, telefono, email FROM Paciente";
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPacientes.DataSource = dt;

                dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvPacientes.AllowUserToAddRows = false;

                // Agregar botones de acción si no existen
                if (dgvPacientes.Columns["Editar"] == null)
                {
                    DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                    btnEditar.HeaderText = "Acciones";
                    btnEditar.Name = "Editar";
                    btnEditar.Text = "Modificar";
                    btnEditar.UseColumnTextForButtonValue = true;
                    dgvPacientes.Columns.Add(btnEditar);

                    //DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                    //btnEliminar.Name = "Eliminar";
                    //btnEliminar.Text = "Eliminar";
                    //btnEliminar.UseColumnTextForButtonValue = true;
                    //dgvPacientes.Columns.Add(btnEliminar);
                }
            }
        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvPacientes.Columns[e.ColumnIndex].Name == "Editar")
                {
                    int idPaciente = Convert.ToInt32(dgvPacientes.Rows[e.RowIndex].Cells["id_paciente"].Value);

                    string nombre = dgvPacientes.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                    string apellido = dgvPacientes.Rows[e.RowIndex].Cells["apellido"].Value.ToString();
                    string dni = dgvPacientes.Rows[e.RowIndex].Cells["dni"].Value.ToString();
                    string telefono = dgvPacientes.Rows[e.RowIndex].Cells["telefono"].Value.ToString();
                    string email = dgvPacientes.Rows[e.RowIndex].Cells["email"].Value.ToString();

                    string calle = "";
                    string numero = "";
                    string ciudad = "";

                    using (SqlConnection conexion = Conexion.GetConnection())
                    {
                        conexion.Open();
                        string query = "SELECT calle, numero_calle, ciudad FROM Direccion WHERE id_paciente = @id";
                        SqlCommand cmd = new SqlCommand(query, conexion);
                        cmd.Parameters.AddWithValue("@id", idPaciente);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            calle = reader["calle"].ToString();
                            numero = reader["numero_calle"].ToString();
                            ciudad = reader["ciudad"].ToString();
                        }
                    }

                    FormModificarPaciente frmEditar = new FormModificarPaciente(
                        idPaciente, nombre, apellido, dni, telefono, email, calle, numero, ciudad
                    );
                    frmEditar.ShowDialog();

                    // actualiza los datos
                    CargarPacientes();
                }
            }
        }

    
    }
}
