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
            CargarEstadosPaciente();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int radio = 30;
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

        private void CargarEstadosPaciente()
        {
            try
            {
                using (SqlConnection conexion = Conexion.GetConnection())
                {
                    conexion.Open();
                    string query = "SELECT id_estado, descripcion FROM EstadoPaciente";
                    SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    CMBEstadoPaciente.DataSource = dt;
                    CMBEstadoPaciente.DisplayMember = "descripcion"; 
                    CMBEstadoPaciente.ValueMember = "id_estado";     
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estados: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
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
        // validacion de campos 
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(TBNombre.Text) ||
                string.IsNullOrWhiteSpace(TBApellido.Text) ||
                string.IsNullOrWhiteSpace(TBDni.Text) ||
                string.IsNullOrWhiteSpace(TBTelefono.Text) ||
                string.IsNullOrWhiteSpace(TBDireccion.Text) ||
                string.IsNullOrWhiteSpace(TBEmail.Text) ||
                CMBEstadoPaciente.SelectedValue == null)
            {
                MessageBox.Show("Debe completar todos los campos.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

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
            TBDireccion.Clear();
            TBEmail.Clear();

            TBDiagnostico.Clear();
            TBTratamiento.Clear();
            TBObservacion.Clear();

            CMBEstadoPaciente.SelectedIndex = -1;
        }

        // Validaciones de ingreso
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
        // botones 
        private void BRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                using (SqlConnection conexion = Conexion.GetConnection())
                {
                    conexion.Open();

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

                    // Insertamos paciente (con estado seleccionado)
                    string queryPaciente = "INSERT INTO Paciente (nombre, apellido, dni, email, telefono, direccion, id_estado, sexo) " +
                                           "VALUES (@Nombre, @Apellido, @Dni, @Email, @Telefono, @Direccion, @IdEstado,@sexo);" +
                                            "SELECT SCOPE_IDENTITY();"; 

                    int idPaciente;
                    using (SqlCommand cmd = new SqlCommand(queryPaciente, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", TBNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@Apellido", TBApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@Dni", int.Parse(TBDni.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Email", TBEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Telefono", TBTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("@Direccion", TBDireccion.Text.Trim());
                        cmd.Parameters.AddWithValue("@IdEstado", CMBEstadoPaciente.SelectedValue);
                        cmd.Parameters.AddWithValue("@Sexo", RBMasculino.Checked ? "Masculino" : "Femenino");

                        idPaciente = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Insertamos historial inicial
                    string queryHistorial = "INSERT INTO Historial (id_paciente, fechaConsulta, diagnostico, tratamiento, observaciones) " +
                                            "VALUES (@IdPaciente, @Fecha, @Diagnostico, @Tratamiento, @Observaciones)";
                    using (SqlCommand cmd = new SqlCommand(queryHistorial, conexion))
                    {
                        cmd.Parameters.AddWithValue("@IdPaciente", idPaciente);
                        cmd.Parameters.AddWithValue("@Fecha", DTMHistorialInicial.Value);
                        cmd.Parameters.AddWithValue("@Diagnostico", TBDiagnostico.Text.Trim());
                        cmd.Parameters.AddWithValue("@Tratamiento", TBTratamiento.Text.Trim());
                        cmd.Parameters.AddWithValue("@Observaciones", TBObservacion.Text.Trim());
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
                                          "Confirmar",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LimpiarCampos();
                this.Close();
            }
        }

        private void BInicio_Click(object sender, EventArgs e)
        {
            SaludSoft frm = new SaludSoft();
            frm.ShowDialog();
            this.Close();
        }

        private void BPacientes_Click(object sender, EventArgs e)
        {
            FormListaPacientes frm = new FormListaPacientes();
            frm.ShowDialog();
            this.Close();
        }

        private void BCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();
            frm.ShowDialog();
            this.Close();
        }

    }
}
