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
        private void BVolver_Click(object sender, EventArgs e)
        {
           
            this.Close(); 
        }
        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = TBBuscar.Text.Trim();
            CargarPacientes(filtro);
        }

        private void BBuscarPaciente_Click(object sender, EventArgs e)
        {
            string filtro = TBBuscar.Text.Trim();
            CargarPacientes(filtro);
        }

        // cargar pacientes
        private void CargarPacientes(string filtro = "")
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"SELECT p.id_paciente, p.nombre, p.apellido, p.dni, p.telefono, p.email, 
                        p.direccion, p.sexo, e.descripcion AS estado
                 FROM Paciente p
                 INNER JOIN EstadoPaciente e ON p.id_estado = e.id_estado
                 WHERE(p.nombre LIKE @filtro OR p.apellido LIKE @filtro OR p.dni LIKE @filtro)";

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.SelectCommand.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPacientes.DataSource = dt;

                dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvPacientes.AllowUserToAddRows = false;

                // botones de acciones
                if (dgvPacientes.Columns["Editar"] == null)
                {
                    DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                    btnEditar.HeaderText = "Acciones";
                    btnEditar.Name = "Editar";
                    btnEditar.Text = "Modificar";
                    btnEditar.UseColumnTextForButtonValue = true;
                    dgvPacientes.Columns.Add(btnEditar);
                }
            }
        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = dgvPacientes.Columns[e.ColumnIndex].Name;

                // EDITAR
                if (columnName == "Editar")
                {
                    int idPaciente = Convert.ToInt32(dgvPacientes.Rows[e.RowIndex].Cells["id_paciente"].Value);

                    string nombre = dgvPacientes.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                    string apellido = dgvPacientes.Rows[e.RowIndex].Cells["apellido"].Value.ToString();
                    string dni = dgvPacientes.Rows[e.RowIndex].Cells["dni"].Value.ToString();
                    string telefono = dgvPacientes.Rows[e.RowIndex].Cells["telefono"].Value.ToString();
                    string email = dgvPacientes.Rows[e.RowIndex].Cells["email"].Value.ToString();
                    string direccion = dgvPacientes.Rows[e.RowIndex].Cells["direccion"].Value.ToString();
                    string sexo = dgvPacientes.Rows[e.RowIndex].Cells["sexo"].Value.ToString();

                    FormModificarPaciente frmEditar = new FormModificarPaciente(
                        idPaciente, nombre, apellido, dni, telefono, email,direccion
                    );
                    frmEditar.ShowDialog();

                    // actualiza la informacion del paciente
                    CargarPacientes();
                }

            }
        }

      
    }
}
