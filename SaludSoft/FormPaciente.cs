using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;


namespace SaludSoft
{
    public partial class FormPaciente : Form
    {
        public FormPaciente()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int radio = 30; // Ajusta el nivel de redondeo
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = panel1.ClientRectangle;

            using (GraphicsPath path = new GraphicsPath())
            {
                int d = radio * 2;
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();

                panel1.Region = new Region(path);
            }
        }

        private void FormPaciente_Load(object sender, EventArgs e)
        {

        }
        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(TBNombre.Text) ||
                string.IsNullOrWhiteSpace(TBApellido.Text) ||
                string.IsNullOrWhiteSpace(TBDni.Text) ||
                string.IsNullOrWhiteSpace(TBTelefono.Text) ||
                string.IsNullOrWhiteSpace(TBCiudad.Text) ||
                string.IsNullOrWhiteSpace(TBDireccion.Text) ||
                string.IsNullOrWhiteSpace(TBEmail.Text) ||
                string.IsNullOrWhiteSpace(TBNroCalle.Text))
            {
                MessageBox.Show("Debe completar todos los campos.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }
            // valida que el email tenga el formato correcto 
            if (!EsEmailValido(TBEmail.Text.Trim()))
            {
                MessageBox.Show("El formato del email no es válido.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
       
        private void LimpiarCampos()
        {
            TBNombre.Clear();
            TBApellido.Clear();
            TBDni.Clear();
            TBTelefono.Clear();
            TBCiudad.Clear();
            TBDireccion.Clear();
            TBEmail.Clear();
        }

        private void BPruebaConexion_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Conexion.GetConnection())
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Conexión exitosa a la base de datos SaludSoft.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar: " + ex.Message);
                }
            }
        }

        // hacemos todas las validaciones 
        private void TBNroCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TBNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }

        }

        private void TBApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void TBDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void TBTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TBCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void TBEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) &&
               !char.IsControl(e.KeyChar) &&
               e.KeyChar != '@' &&
               e.KeyChar != '.' &&
               e.KeyChar != '_' &&
               e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void BRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                using (SqlConnection conexion = Conexion.GetConnection())
                {
                    conexion.Open();

                    //Verifica si se ingresa DNI o Email que ya estee registrado
                    string queryCheck = "SELECT COUNT(*) FROM Paciente WHERE dni = @Dni OR email = @Email";
                    using (SqlCommand cmdCheck = new SqlCommand(queryCheck, conexion))
                    {
                        cmdCheck.Parameters.AddWithValue("@Dni", int.Parse(TBDni.Text.Trim()));
                        cmdCheck.Parameters.AddWithValue("@Email", TBEmail.Text.Trim());

                        int existe = (int)cmdCheck.ExecuteScalar();
                        if (existe > 0)
                        {
                            MessageBox.Show("El paciente con este DNI o Email ya está registrado.",
                                            "Duplicado",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                            return; 
                        }
                    }

                    // insertamos los datos del paciente 
                    string queryPaciente = "INSERT INTO Paciente (nombre, apellido, dni, email, telefono) " +
                                  "VALUES (@Nombre, @Apellido, @Dni, @Email, @Telefono); " +
                                  "SELECT SCOPE_IDENTITY();";

                    int idPaciente;
                    using (SqlCommand cmd = new SqlCommand(queryPaciente, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", TBNombre.Text);
                        cmd.Parameters.AddWithValue("@Apellido", TBApellido.Text);
                        cmd.Parameters.AddWithValue("@Dni", int.Parse(TBDni.Text));
                        cmd.Parameters.AddWithValue("@Email", TBEmail.Text);
                        cmd.Parameters.AddWithValue("@Telefono", TBTelefono.Text);

                        idPaciente = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    // insertamos los datos de la direccion
                    string queryDireccion = "INSERT INTO Direccion (calle, numero_calle, ciudad, id_paciente) " +
                        "VALUES (@Calle, @Numero, @Ciudad, @IdPaciente)";

                    using (SqlCommand cmd = new SqlCommand(queryDireccion, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Calle", TBDireccion.Text.Trim());
                        cmd.Parameters.AddWithValue("@Numero", string.IsNullOrWhiteSpace(TBNroCalle.Text)
                                                              ? 0
                                                              : int.Parse(TBNroCalle.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Ciudad", TBCiudad.Text.Trim());
                        cmd.Parameters.AddWithValue("@IdPaciente", idPaciente);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Paciente Registrado",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                LimpiarCampos();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Registrar Paciente: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cancelar el Registro?",
                                          "Confirmar eliminación",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LimpiarCampos();
            }
        }
    }
}
