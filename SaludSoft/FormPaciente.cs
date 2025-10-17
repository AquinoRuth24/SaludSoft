using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class FormPaciente : Form
    {
        public FormPaciente()
        {
            InitializeComponent();
            CargarEstadosPaciente();

            // Solo números en DNI
            TBDni.TextChanged += (s, e) =>
            {
                int sel = TBDni.SelectionStart;
                string soloDigitos = new string(TBDni.Text.Where(char.IsDigit).ToArray());
                if (soloDigitos.Length > 8) soloDigitos = soloDigitos.Substring(0, 8);
                if (TBDni.Text != soloDigitos)
                {
                    TBDni.Text = soloDigitos;
                    TBDni.SelectionStart = Math.Min(sel, TBDni.Text.Length);
                }
            };

            TBTelefono.MaxLength = 15;

            
            this.Shown += (s, e) =>
            {
                this.ActiveControl = TBNombre;
                TBNombre.Focus();
            };
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
                    string query = "SELECT id_estado, descripcion FROM Estado ORDER BY descripcion";
                    SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    CMBEstadoPaciente.DataSource = dt;
                    CMBEstadoPaciente.DisplayMember = "descripcion";
                    CMBEstadoPaciente.ValueMember = "id_estado";
                    CMBEstadoPaciente.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estados: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new MailAddress(email.Trim());
                return addr.Address == email.Trim();
            }
            catch { return false; }
        }

        // Validación simple antes de guardar
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(TBNombre.Text) ||
                string.IsNullOrWhiteSpace(TBApellido.Text) ||
                string.IsNullOrWhiteSpace(TBDni.Text) ||
                string.IsNullOrWhiteSpace(TBTelefono.Text) ||
                string.IsNullOrWhiteSpace(TBDireccion.Text) ||
                string.IsNullOrWhiteSpace(TBEmail.Text) ||
                CMBEstadoPaciente.SelectedValue == null ||
                (!RBMasculino.Checked && !RBFemenino.Checked))
            {
                MessageBox.Show("Debe completar todos los campos obligatorios (incluye sexo).",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            // DNI 7-8 dígitos
            string dni = TBDni.Text.Trim();
            if (!(dni.Length == 7 || dni.Length == 8) || !Regex.IsMatch(dni, @"^\d+$"))
            {
                MessageBox.Show("DNI inválido. Debe tener 7 u 8 dígitos.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            // Teléfono 8-15 dígitos
            string tel = TBTelefono.Text.Trim();
            if (tel.Length < 8 || tel.Length > 15 || !Regex.IsMatch(tel, @"^\d+$"))
            {
                MessageBox.Show("Teléfono inválido. Debe tener entre 8 y 15 dígitos.",
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
            RBMasculino.Checked = false;
            RBFemenino.Checked = false;

            // Fecha sugerida = hoy
            if (DTMHistorialInicial != null)
                DTMHistorialInicial.Value = DateTime.Today;
        }

        // --- Handlers para restricciones de entrada ---
        private void TBNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }
        private void TBApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }
        private void TBDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void TBTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
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

        // --- Botones ---
        private void BRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                using (SqlConnection conexion = Conexion.GetConnection())
                {
                    conexion.Open();
                    using (var tx = conexion.BeginTransaction())
                    {
                        try
                        {
                            // Verificar duplicados (dni/email)
                            string queryCheck = @"SELECT COUNT(*) FROM Paciente WHERE dni = @Dni OR email = @Email";
                            using (SqlCommand cmdCheck = new SqlCommand(queryCheck, conexion, tx))
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
                                    tx.Rollback();
                                    return;
                                }
                            }

                            //Insert Paciente
                            string queryPaciente = @"
                                INSERT INTO Paciente (nombre, apellido, dni, email, telefono, direccion, id_estado, sexo)
                                VALUES (@Nombre, @Apellido, @Dni, @Email, @Telefono, @Direccion, @IdEstado, @Sexo);
                                SELECT SCOPE_IDENTITY();";

                            int idPaciente;
                            using (SqlCommand cmd = new SqlCommand(queryPaciente, conexion, tx))
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

                            // Insert Historial inicial
                            //    - diagnostico debe ir NULL si está vacío
                            //    - fecha no puede ser futura por tu CHECK
                            DateTime fecha = DTMHistorialInicial.Value.Date;
                            if (fecha > DateTime.Today) fecha = DateTime.Today;

                            string diag = TBDiagnostico.Text?.Trim();
                            string trat = TBTratamiento.Text?.Trim();
                            string obs = TBObservacion.Text?.Trim();

                            string queryHistorial = @"
                                INSERT INTO Historial (id_paciente, fechaConsulta, diagnostico, tratamiento, observaciones)
                                VALUES (@IdPaciente, @Fecha, @Diagnostico, @Tratamiento, @Observaciones);";

                            using (SqlCommand cmd = new SqlCommand(queryHistorial, conexion, tx))
                            {
                                cmd.Parameters.AddWithValue("@IdPaciente", idPaciente);
                                cmd.Parameters.AddWithValue("@Fecha", fecha);
                                cmd.Parameters.AddWithValue("@Diagnostico",
                                    string.IsNullOrWhiteSpace(diag) ? (object)DBNull.Value : diag);
                                cmd.Parameters.AddWithValue("@Tratamiento",
                                    string.IsNullOrWhiteSpace(trat) ? (object)DBNull.Value : trat);
                                cmd.Parameters.AddWithValue("@Observaciones",
                                    string.IsNullOrWhiteSpace(obs) ? (object)DBNull.Value : obs);

                                cmd.ExecuteNonQuery();
                            }

                            tx.Commit();
                            MessageBox.Show("Paciente registrado correctamente.",
                                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                            this.Close();
                        }
                        catch (Exception exTx)
                        {
                            tx.Rollback();
                            MessageBox.Show("Error al registrar: " + exTx.Message,
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cancelar el registro?", "Confirmar",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpiarCampos();
                this.Close();
            }
        }

        private void LInfoPaciente_Click(object sender, EventArgs e) { }
    }
}
