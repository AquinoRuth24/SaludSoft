using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class FormModificarUsuario : Form
    {
        private int _idUsuario;

        public FormModificarUsuario(int idUsuario, string nombre, string apellido, string email, string telefono, string rol)
        {
            InitializeComponent();

            _idUsuario = idUsuario;

            tbNombre.Text = nombre;
            tbApellido.Text = apellido;
            tbCorreo.Text = email;
            tbTelefono.Text = telefono;

            CargarRoles();
            CMBRol.SelectedItem = rol;
        }

        private void CargarRoles()
        {
            CMBRol.Items.Clear();

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT id_rol, descripcion FROM Rol", conexion);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    CMBRol.Items.Add(dr["descripcion"].ToString());
                }
            }
        }
        //Hash simple
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
        // botones
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BTModificar_Click(object sender, EventArgs e)
        {
            if (CMBRol.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                //actualiza datos del usuario
                string query = @"UPDATE Usuario
                                 SET nombre = @nombre,
                                     apellido = @apellido,
                                     email = @correo,
                                     telefono = @telefono,
                                     id_rol = (SELECT id_rol FROM Rol WHERE descripcion = @rol)
                                 WHERE id_usuario = @id";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@nombre", tbNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@apellido", tbApellido.Text.Trim());
                cmd.Parameters.AddWithValue("@correo", tbCorreo.Text.Trim());
                cmd.Parameters.AddWithValue("@telefono", tbTelefono.Text.Trim());
                cmd.Parameters.AddWithValue("@rol", CMBRol.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@id", _idUsuario);

                cmd.ExecuteNonQuery();

                //si se cambia la contraseña
                if (!string.IsNullOrWhiteSpace(TBContraseña.Text))
                {
                    string hash = HashPassword(TBContraseña.Text.Trim());

                    SqlCommand cmdPwd = new SqlCommand("UPDATE Usuario SET contraseña = @pwd WHERE id_usuario = @id", conexion);
                    cmdPwd.Parameters.AddWithValue("@pwd", hash);
                    cmdPwd.Parameters.AddWithValue("@id", _idUsuario);
                    cmdPwd.ExecuteNonQuery();
                }

                MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
