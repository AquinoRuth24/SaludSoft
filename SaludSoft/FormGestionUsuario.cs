using SaludSoft.Resources;
using SaludSoft.Resources.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class FormGestionUsuario : Form
    {
        public FormGestionUsuario()
        {
            if (!DesignMode)
            {
                InitializeComponent();
                CargarUsuarios();
                dgUsuario.CellContentClick += dgUsuario_CellContentClick;
            }
        }

        // Cargar usuarios
        private void CargarUsuarios(string filtro = "")
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"
                 SELECT 
                 u.id_usuario, 
                 u.nombre, 
                 u.apellido, 
                 u.email, 
                 u.telefono, 
                 r.descripcion AS rol,
                 eP.id_estado,
                 eP.descripcion AS estado,
                 p.matricula, 
                 p.id_especialidad,
                 es.nombre AS especialidad
                 FROM Usuario u
                 INNER JOIN Rol r ON u.id_rol = r.id_rol
                 INNER JOIN Estado eP ON u.id_estado = eP.id_estado
                 LEFT JOIN Profesional p ON p.email = u.email
                 LEFT JOIN Especialidad es ON p.id_especialidad = es.id_especialidad
                 WHERE u.nombre LIKE @filtro 
                 OR u.apellido LIKE @filtro 
                 OR u.email LIKE @filtro";

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.SelectCommand.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgUsuario.DataSource = null;
                dgUsuario.Columns.Clear();
                dgUsuario.DataSource = dt;

                dgUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgUsuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgUsuario.AllowUserToAddRows = false;

                // Botón Editar
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.HeaderText = "Editar";
                btnEditar.Name = "Editar";
                btnEditar.Text = "Modificar";
                btnEditar.UseColumnTextForButtonValue = true;
                dgUsuario.Columns.Add(btnEditar);

                // Botón Eliminar
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.HeaderText = "Eliminar";
                btnEliminar.Name = "Eliminar";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                dgUsuario.Columns.Add(btnEliminar);

                // Botón Restaurar
                DataGridViewButtonColumn btnRestaurar = new DataGridViewButtonColumn();
                btnRestaurar.HeaderText = "Restaurar";
                btnRestaurar.Name = "Restaurar";
                btnRestaurar.Text = "Restaurar";
                btnRestaurar.UseColumnTextForButtonValue = true;
                dgUsuario.Columns.Add(btnRestaurar);

                // Ocultar columnas innecesarias
                if (dgUsuario.Columns.Contains("id_usuario")) dgUsuario.Columns["id_usuario"].Visible = false;
                if (dgUsuario.Columns.Contains("id_estado")) dgUsuario.Columns["id_estado"].Visible = false;
                if (dgUsuario.Columns.Contains("id_especialidad")) dgUsuario.Columns["id_especialidad"].Visible = false;
                // si es administrador bloquear boton eliminar
                foreach (DataGridViewRow fila in dgUsuario.Rows)
                {
                    if (fila.Cells["rol"].Value != null &&
                        fila.Cells["rol"].Value.ToString().Equals("Administrador", StringComparison.OrdinalIgnoreCase))
                    {
                        DataGridViewButtonCell botonEliminar = fila.Cells["Eliminar"] as DataGridViewButtonCell;
                        if (botonEliminar != null)
                        {
                            botonEliminar.FlatStyle = FlatStyle.Flat;
                            botonEliminar.Style.ForeColor = System.Drawing.Color.Gray;
                            botonEliminar.Style.BackColor = System.Drawing.Color.LightGray;
                            botonEliminar.Value = "Bloqueado";
                            botonEliminar.ReadOnly = true;
                        }
                    }
                }

            }
        }

        // Eventos en DataGridView
        private void dgUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignorar encabezado
            if (dgUsuario.Rows[e.RowIndex].Cells["id_usuario"].Value == null) return;

            int idUsuario = Convert.ToInt32(dgUsuario.Rows[e.RowIndex].Cells["id_usuario"].Value);
            string columnName = dgUsuario.Columns[e.ColumnIndex].Name;

            // ===== Botón Editar =====
            if (columnName == "Editar")
            {
                string nombre = dgUsuario.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                string apellido = dgUsuario.Rows[e.RowIndex].Cells["apellido"].Value.ToString();
                string email = dgUsuario.Rows[e.RowIndex].Cells["email"].Value.ToString();
                string telefono = dgUsuario.Rows[e.RowIndex].Cells["telefono"].Value.ToString();
                string rol = dgUsuario.Rows[e.RowIndex].Cells["rol"].Value.ToString();
                int estado = Convert.ToInt32(dgUsuario.Rows[e.RowIndex].Cells["id_estado"].Value);

                if (rol == "Medico")
                {
                    // Manejo seguro de matrícula
                    string matricula = dgUsuario.Rows[e.RowIndex].Cells["matricula"].Value == DBNull.Value
                                        ? ""
                                        : dgUsuario.Rows[e.RowIndex].Cells["matricula"].Value.ToString();

                    // Manejo seguro de especialidad
                    int idEspecialidad = 0;
                    if (dgUsuario.Rows[e.RowIndex].Cells["id_especialidad"].Value != DBNull.Value &&
                        dgUsuario.Rows[e.RowIndex].Cells["id_especialidad"].Value != null)
                    {
                        int.TryParse(dgUsuario.Rows[e.RowIndex].Cells["id_especialidad"].Value.ToString(), out idEspecialidad);
                    }

                    FormModificarMedico formMedico = new FormModificarMedico(
                        idUsuario, nombre, apellido, email, telefono, matricula, idEspecialidad, estado
                    );

                    if (formMedico.ShowDialog() == DialogResult.OK)
                        CargarUsuarios();
                }
                else
                {
                    FormModificarUsuario formUsuario = new FormModificarUsuario(
                        idUsuario, nombre, apellido, email, telefono, rol
                    );

                    if (formUsuario.ShowDialog() == DialogResult.OK)
                        CargarUsuarios();
                }
            }

            // Botón Eliminar
            if (columnName == "Eliminar")
            {
                string rol = dgUsuario.Rows[e.RowIndex].Cells["rol"].Value.ToString();

                //impedir eliminar administradores
                if (rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("No se puede eliminar un usuario con rol Administrador.",
                                    "Acción no permitida",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("¿Está seguro de eliminar este usuario?",
                                                      "Confirmación",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conexion = Conexion.GetConnection())
                    {
                        conexion.Open();
                        string query = "UPDATE Usuario SET id_estado = 2 WHERE id_usuario = @id";
                        SqlCommand cmd = new SqlCommand(query, conexion);
                        cmd.Parameters.AddWithValue("@id", idUsuario);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Usuario eliminado correctamente.",
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    CargarUsuarios();
                }
            }

            // ===== Botón Restaurar =====
            if (columnName == "Restaurar")
            {
                DialogResult result = MessageBox.Show("¿Desea restaurar este usuario?",
                                                      "Confirmación",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conexion = Conexion.GetConnection())
                    {
                        conexion.Open();
                        string query = "UPDATE Usuario SET id_estado = 1 WHERE id_usuario = @id";
                        SqlCommand cmd = new SqlCommand(query, conexion);
                        cmd.Parameters.AddWithValue("@id", idUsuario);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Usuario restaurado correctamente.",
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    CargarUsuarios();
                }
            }
        }


        private void btAgregarUsuario_Click(object sender, EventArgs e)
        {
            FormUsuario frm = new FormUsuario();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarUsuarios();
            }
        }

        private void BVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
