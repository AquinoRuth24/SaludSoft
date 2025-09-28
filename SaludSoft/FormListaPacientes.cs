using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class FormListaPacientes : Form
    {
        public FormListaPacientes()
        {
            InitializeComponent();           // ¡siempre llamar!
            if (!DesignMode) CargarPacientes();
        }

        // botones
        private void BVolver_Click(object sender, EventArgs e) => this.Close();

        private void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            var filtro = TBBuscar.Text.Trim();
            CargarPacientes(filtro);
        }

        private void BBuscarPaciente_Click(object sender, EventArgs e)
        {
            var filtro = TBBuscar.Text.Trim();
            CargarPacientes(filtro);
        }

        // cargar pacientes
        private void CargarPacientes(string filtro = "")
        {
            try
            {
                using (SqlConnection conexion = Conexion.GetConnection())
                {
                    conexion.Open();

                    // Nota: usamos Estado (unificada) y CAST para filtrar por DNI
                    string query = @"
SELECT  p.id_paciente,
        p.nombre,
        p.apellido,
        p.dni,
        p.telefono,
        p.email,
        p.direccion,
        p.sexo,
        e.descripcion AS estado
FROM Paciente p
INNER JOIN Estado e
        ON p.id_estado = e.id_estado
WHERE (p.nombre   LIKE @filtro
    OR p.apellido LIKE @filtro
    OR CAST(p.dni AS VARCHAR(20)) LIKE @filtro)
ORDER BY p.apellido, p.nombre;";

                    using (var da = new SqlDataAdapter(query, conexion))
                    {
                        da.SelectCommand.Parameters.Add("@filtro", SqlDbType.VarChar, 100).Value = $"%{filtro}%";
                        var dt = new DataTable();
                        da.Fill(dt);

                        dgvPacientes.DataSource = dt;
                        dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvPacientes.AllowUserToAddRows = false;

                        // Agregar columna de acción una sola vez
                        if (dgvPacientes.Columns["Editar"] == null)
                        {
                            var btnEditar = new DataGridViewButtonColumn
                            {
                                HeaderText = "Acciones",
                                Name = "Editar",
                                Text = "Modificar",
                                UseColumnTextForButtonValue = true
                            };
                            dgvPacientes.Columns.Add(btnEditar);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // 208 = Invalid object name (por si la BD no tiene las tablas)
                var msg = ex.Number == 208
                    ? "No se encuentra alguna de las tablas (Paciente o Estado). Verificá que la BD sea 'SaludSoft'."
                    : $"Error SQL ({ex.Number}): {ex.Message}";
                MessageBox.Show(msg, "Error al cargar pacientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar pacientes:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dgvPacientes.Columns[e.ColumnIndex].Name;

            if (columnName == "Editar")
            {
                int idPaciente = Convert.ToInt32(dgvPacientes.Rows[e.RowIndex].Cells["id_paciente"].Value);

                string nombre = dgvPacientes.Rows[e.RowIndex].Cells["nombre"].Value?.ToString();
                string apellido = dgvPacientes.Rows[e.RowIndex].Cells["apellido"].Value?.ToString();
                string dni = dgvPacientes.Rows[e.RowIndex].Cells["dni"].Value?.ToString();
                string telefono = dgvPacientes.Rows[e.RowIndex].Cells["telefono"].Value?.ToString();
                string email = dgvPacientes.Rows[e.RowIndex].Cells["email"].Value?.ToString();
                string direccion = dgvPacientes.Rows[e.RowIndex].Cells["direccion"].Value?.ToString();

                var frmEditar = new FormModificarPaciente(idPaciente, nombre, apellido, dni, telefono, email, direccion);
                frmEditar.StartPosition = FormStartPosition.CenterParent;
                frmEditar.ShowDialog(this);

                // refrescar
                CargarPacientes(TBBuscar.Text.Trim());
            }
        }
    }
}
