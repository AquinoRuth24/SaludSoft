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

        private void BCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();
            frm.ShowDialog();
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

                    DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                    btnEliminar.Name = "Eliminar";
                    btnEliminar.Text = "Eliminar";
                    btnEliminar.UseColumnTextForButtonValue = true;
                    dgvPacientes.Columns.Add(btnEliminar);
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

                // ELIMINAR
                if (columnName == "Eliminar")
                {
                    int idPaciente = Convert.ToInt32(dgvPacientes.Rows[e.RowIndex].Cells["id_paciente"].Value);

                    DialogResult result = MessageBox.Show("¿Está seguro de eliminar este paciente?",
                                                          "Confirmación",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        using (SqlConnection conexion = Conexion.GetConnection())
                        {
                            conexion.Open();
                            // baja logica del paciente 2 = inactivo
                            string queryDelete = "UPDATE Paciente SET id_estado = 2 WHERE id_paciente = @id";

                            SqlCommand cmd = new SqlCommand(queryDelete, conexion);
                            cmd.Parameters.AddWithValue("@id", idPaciente);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Paciente eliminado correctamente.",
                                        "Éxito",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        // Actualiza la lista de pacientes
                        CargarPacientes();
                    }
                }
            }
        }

      
    }
}
