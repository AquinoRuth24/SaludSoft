using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SaludSoft.Security; // Para PasswordHasher.Hash
using System.Data.SqlClient;

namespace SaludSoft.Resources
{
    public partial class FormUsuario : Form
    {
        public FormUsuario()
        {
            InitializeComponent();

            this.Load += FormUsuario_Load;
            if (cbRol != null) cbRol.SelectedIndexChanged += cbRol_SelectedIndexChanged;

            // Botones
            if (btAgregar != null) { btAgregar.Click += btAgregar_Click; this.AcceptButton = btAgregar; }
            if (btCancelar != null) { btCancelar.Click += btCancelar_Click; this.CancelButton = btCancelar; }

            // Restricciones de entrada (KeyPress) y radio sexo
            WireInputRestrictions();
            WireSexoRadioButtons();
        }

        // --- Helpers de validación reutilizables ---
        private bool Req(string name, string message)
        {
            var tb = FindCtl<TextBox>(name);
            if (tb == null) return true; // si el control no existe, no falla
            if (!string.IsNullOrWhiteSpace(tb.Text)) return true;

            MessageBox.Show(message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tb.Focus();
            return false;
        }

        private bool ReqAny(string[] names, string message)
        {
            foreach (var n in names)
            {
                var tb = FindCtl<TextBox>(n);
                if (tb != null)
                {
                    if (!string.IsNullOrWhiteSpace(tb.Text)) return true;
                    MessageBox.Show(message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tb.Focus();
                    return false;
                }
            }
            return true;
        }

        private enum RolUsuario { Paciente = 0, Medico = 1, Recepcionista = 2, Administrador = 3 }

        // ------------------ Load & Rol ------------------
        private void FormUsuario_Load(object sender, EventArgs e)
        {
            if (cbRol != null && cbRol.Items.Count == 0)
            {

                cbRol.Items.AddRange(new object[] { "Paciente", "Médico", "Recepcionista" });
                cbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            if (cbRol != null && cbRol.SelectedIndex < 0) cbRol.SelectedIndex = 0;

            AplicarUIRol();
            this.AutoScaleMode = AutoScaleMode.Font;
        }

        private void cbRol_SelectedIndexChanged(object sender, EventArgs e) => AplicarUIRol();

        // ------------------ Mostrar/Ocultar por Rol ------------------
        private void AplicarUIRol()
        {
            HideAllRoleGroups();

            // Ocultar variantes de contraseña
            ShowPwdFor("Medico", false);
            ShowPwdFor("Recep", false);
            ShowPwdFor("Recepcionista", false);
            // (mantengo estas dos por seguridad aunque ya no se usen)
            ShowPwdFor("Administrador", false);
            ShowPwdFor("Admin", false);

            ToggleMedicoExtras(false);

            var rol = (RolUsuario)(cbRol?.SelectedIndex ?? 0);
            switch (rol)
            {
                case RolUsuario.Paciente:
                    SetVisible("gbPaciente", true);
                    FindCtl<GroupBox>("gbPaciente")?.BringToFront();
                    break;

                case RolUsuario.Medico:
                    SetVisible("gbMedico", true);
                    ShowPwdFor("Medico", true);
                    ToggleMedicoExtras(true);
                    FindCtl<GroupBox>("gbMedico")?.BringToFront();
                    break;

                case RolUsuario.Recepcionista:
                    SetVisible("gbRecepcionista", true);
                    ShowPwdFor("Recepcionista", true);
                    ShowPwdFor("Recep", true);
                    FindCtl<GroupBox>("gbRecepcionista")?.BringToFront();
                    break;

                    // case RolUsuario.Administrador: // <- Eliminado: no se permite
                    //     break;
            }

            this.PerformLayout();
        }

        private void HideAllRoleGroups()
        {
            SetVisible("gbPaciente", false);
            SetVisible("gbMedico", false);
            SetVisible("gbRecepcionista", false);
            SetVisible("gbAdmin", false); // por si existe en el form, que quede oculto
        }

        // ------------------ Botones ------------------
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("¿Cerrar sesión?", "Confirmar",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            var rolDestino = (RolUsuario)(cbRol?.SelectedIndex ?? 0);

            // no permitir crear Administrador
            if (rolDestino == RolUsuario.Administrador)
            {
                Msg("No está permitido crear usuarios con rol Administrador.");
                return;
            }

            if (!ValidarFormulario()) return;

            // Comunes
            string nombre = GetText("tbNombre");
            string apellido = GetText("tbApellido");
            string dni = GetText("tbDni");
            string direccion = GetText("tbDireccion");
            string correo = GetText("tbCorreo");
            string telefono = GetText("tbTelefono");

            string rolStr = cbRol?.Text ?? rolDestino.ToString();

            // Contraseña -> HASH PBKDF2 (PasswordHasher)
            string pwPlano = GetPasswordForCurrentRole() ?? "";
            string passwordHash = string.IsNullOrWhiteSpace(pwPlano) ? null : PasswordHasher.Hash(pwPlano);

            // Específicos
            try
            {
                using (SqlConnection conexion = Conexion.GetConnection())
                {
                    conexion.Open();

                    // --- Insert en Usuario ---
                    string insertUsuario = @"
                INSERT INTO Usuario (nombre, apellido, contraseña, email, telefono, id_rol)
                VALUES (@nombre, @apellido, @contraseña, @correo, @telefono, @idRol);
                SELECT SCOPE_IDENTITY();";

                    int idRol = (int)rolDestino + 1;

                    int idUsuario;
                    using (SqlCommand cmd = new SqlCommand(insertUsuario, conexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@contraseña", (object)passwordHash ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@telefono", (object)telefono ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@idRol", idRol);

                        idUsuario = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // --- Insert extra si es Paciente ---
                    if (rolDestino == RolUsuario.Paciente)
                    {
                        string sexo = (FindCtl<RadioButton>("rbMasculino")?.Checked ?? false) ? "Masculino" : "Femenino";

                        string insertPaciente = @"
                    INSERT INTO Paciente (nombre, apellido, dni, sexo, direccion, email, telefono, id_estado)
                    VALUES (@nombre, @apellido, @dni, @sexo, @direccion, @correo, @telefono, 1);";

                        using (SqlCommand cmd = new SqlCommand(insertPaciente, conexion))
                        {
                            cmd.Parameters.AddWithValue("@nombre", nombre);
                            cmd.Parameters.AddWithValue("@apellido", apellido);
                            cmd.Parameters.AddWithValue("@dni", int.Parse(dni));
                            cmd.Parameters.AddWithValue("@sexo", sexo);
                            cmd.Parameters.AddWithValue("@direccion", direccion);
                            cmd.Parameters.AddWithValue("@correo", (object)correo ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@telefono", (object)telefono ?? DBNull.Value);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    // --- Insert extra si es Médico ---
                    if (rolDestino == RolUsuario.Medico)
                    {
                        string matricula = GetTextAny("tbMatricula");
                        string especialidad = GetTextAny("tbEspecialidadFormUsuario", "tbEspecialidad");
                        string consultorio = GetTextAny("tbConsultorio");

                        int idEspecialidad = 0;

                        // Primero buscar id_especialidad
                        using (SqlCommand cmdCheck = new SqlCommand(
                            "SELECT TOP 1 id_especialidad FROM Especialidad WHERE nombre = @especialidad", conexion))
                        {
                            cmdCheck.Parameters.AddWithValue("@especialidad", especialidad);
                            var result = cmdCheck.ExecuteScalar();

                            if (result == null)
                            {
                                MessageBox.Show("La especialidad ingresada no existe. Verifique la entrada.",
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return; // cancelar el guardado
                            }

                            idEspecialidad = Convert.ToInt32(result);
                        }

                        // Ahora sí, insertar en Profesional
                        string insertProfesional = @"
                          INSERT INTO Profesional (nombre, apellido, email, matricula, id_estado, id_especialidad)
                          VALUES (@nombre, @apellido, @correo, @matricula, 1, @idEspecialidad);";

                        using (SqlCommand cmd = new SqlCommand(insertProfesional, conexion))
                        {
                            cmd.Parameters.AddWithValue("@nombre", nombre);
                            cmd.Parameters.AddWithValue("@apellido", apellido);
                            cmd.Parameters.AddWithValue("@correo", correo);
                            cmd.Parameters.AddWithValue("@matricula", int.Parse(matricula));
                            cmd.Parameters.AddWithValue("@idEspecialidad", idEspecialidad);

                            cmd.ExecuteNonQuery();
                        }

                    }

                    MessageBox.Show("Usuario agregado correctamente en la base de datos.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la base de datos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ------------------ Validación ------------------
        private bool ValidarFormulario()
        {
            // Vacíos
            if (!Req("tbNombre", "Ingrese el nombre")) return false;
            if (!Req("tbApellido", "Ingrese el apellido")) return false;
            if (!Req("tbCorreo", "Ingrese el correo electrónico")) return false;
            if (!Req("tbTelefono", "Ingrese el teléfono")) return false;

            // Regex
            const string SOLO_LETRAS = @"^[\p{L}\s]+$";
            const string SOLO_NUMEROS = @"^\d+$";
            const string EMAIL_BASICO = @"^[A-Za-z0-9._-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

            if (!Match("tbNombre", SOLO_LETRAS, "Nombre: solo letras y espacios")) return false;
            if (!Match("tbApellido", SOLO_LETRAS, "Apellido: solo letras y espacios")) return false;
            if (!Match("tbDireccion", SOLO_LETRAS, "Dirección: solo letras y espacios")) return false;

            var tbDni = FindCtl<TextBox>("tbDni");
            if (tbDni != null && !string.IsNullOrWhiteSpace(tbDni.Text) && !Regex.IsMatch(tbDni.Text.Trim(), SOLO_NUMEROS))
            { Msg("DNI: solo números"); return false; }

            var tbTel = FindCtl<TextBox>("tbTelefono");
            if (tbTel != null && !string.IsNullOrWhiteSpace(tbTel.Text) && !Regex.IsMatch(tbTel.Text.Trim(), SOLO_NUMEROS))
            { Msg("Teléfono: solo números"); return false; }

            var tbCorreo = FindCtl<TextBox>("tbCorreo");
            if (tbCorreo != null && !string.IsNullOrWhiteSpace(tbCorreo.Text) && !Regex.IsMatch(tbCorreo.Text.Trim(), EMAIL_BASICO))
            { Msg("Correo: formato inválido (alfanumérico con @ y .)"); return false; }

            // Password (si existe para el rol actual)
            var tbPwd = GetPasswordTextBoxForCurrentRole();
            if (tbPwd != null && string.IsNullOrWhiteSpace(tbPwd.Text)) { Msg("Ingrese la contraseña"); return false; }

            // Específicos
            var rol = (RolUsuario)(cbRol?.SelectedIndex ?? 0);
            if (rol == RolUsuario.Medico)
            {
                if (!ReqAny(new[] { "tbMatricula" }, "Ingrese la matrícula")) return false;
                var tbMat = FindCtl<TextBox>("tbMatricula");
                if (tbMat != null && !Regex.IsMatch(tbMat.Text.Trim(), SOLO_NUMEROS)) { Msg("Matrícula: solo números"); return false; }

                if (!ReqAny(new[] { "tbEspecialidadFormUsuario", "tbEspecialidad" }, "Ingrese la especialidad")) return false;
                var esp = GetTextAny("tbEspecialidadFormUsuario", "tbEspecialidad");
                if (!string.IsNullOrWhiteSpace(esp) && !Regex.IsMatch(esp, SOLO_LETRAS)) { Msg("Especialidad: solo letras y espacios"); return false; }
            }
            else if (rol == RolUsuario.Administrador)
            {
                // No debería alcanzarse porque no se permite Administrador en UI ni al guardar
                Msg("No está permitido crear usuarios con rol Administrador.");
                return false;
            }

            // Sexo: si tenés rbMasculino / rbFemenino, exige uno
            if (rol == RolUsuario.Paciente)
            {
                var rbM = FindCtl<RadioButton>("rbMasculino");
                var rbF = FindCtl<RadioButton>("rbFemenino");
                if ((rbM != null || rbF != null) && !((rbM?.Checked ?? false) || (rbF?.Checked ?? false)))
                {
                    Msg("Seleccione el sexo");
                    return false;
                }
            }

            return true;

            // Helpers locales
            bool Match(string name, string pattern, string message)
            {
                var tb = FindCtl<TextBox>(name);
                if (tb == null || string.IsNullOrWhiteSpace(tb.Text)) return true;
                if (Regex.IsMatch(tb.Text.Trim(), pattern)) return true;
                Msg(message); tb.Focus(); return false;
            }
        }

        // ---------- RESTRICCIONES DE ENTRADA ----------
        private void WireInputRestrictions()
        {
            // Solo letras (nombre, apellido, dirección, especialidad)
            BindKeyPress(LettersOnly_KeyPress, "tbNombre", "tbApellido", "tbDireccion", "tbEspecialidadFormUsuario", "tbEspecialidad");

            // Solo números (dni, teléfono, matrícula)
            BindKeyPress(NumbersOnly_KeyPress, "tbDni", "tbTelefono", "tbMatricula");

            // Correo: alfanumérico + @ . _ -
            BindKeyPress(Email_KeyPress, "tbCorreo");
        }

        private void BindKeyPress(KeyPressEventHandler handler, params string[] names)
        {
            foreach (var n in names)
            {
                var tb = FindCtl<TextBox>(n);
                if (tb != null) tb.KeyPress += handler;
            }
        }

        private void LettersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)) return;
            if (!char.IsLetter(e.KeyChar)) e.Handled = true; // incluye acentos
        }

        private void NumbersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void Email_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            char c = e.KeyChar;
            if (char.IsLetterOrDigit(c) || c == '@' || c == '.' || c == '_' || c == '-') return;
            e.Handled = true;
        }

        // ---------- RadioButtons de sexo ----------
        private void WireSexoRadioButtons()
        {
            var rbM = FindCtl<RadioButton>("rbMasculino");
            var rbF = FindCtl<RadioButton>("rbFemenino");

            if (rbM != null && rbF != null)
            {
                rbM.CheckedChanged += Sexo_CheckedChanged;
                rbF.CheckedChanged += Sexo_CheckedChanged;
            }
        }

        private void Sexo_CheckedChanged(object sender, EventArgs e)
        {
            var rbM = FindCtl<RadioButton>("rbMasculino");
            var rbF = FindCtl<RadioButton>("rbFemenino");

            if (rbM != null && rbF != null)
            {
                if (sender == rbM && rbM.Checked) rbF.Checked = false;
                if (sender == rbF && rbF.Checked) rbM.Checked = false;
            }
        }

        // ------------------ Helpers UI/Datos ------------------
        private T FindCtl<T>(string name) where T : Control
            => this.Controls.Find(name, true).FirstOrDefault() as T;

        private void SetVisible(string controlName, bool visible)
        {
            var c = FindCtl<Control>(controlName);
            if (c != null) c.Visible = visible;
        }

        // Muestra/oculta Label/TextBox de contraseña por rol.
        // Acepta Contrasena/Contraseña/Contrasenia y sufijos Admin/Administrador/Medico/Recep/Recepcionista
        private void ShowPwdFor(string rolSuffix, bool visible)
        {
            string[] bases = { "Contrasena", "Contraseña", "Contrasenia" };
            string[] endings = {
                rolSuffix,
                rolSuffix == "Administrador" ? "Admin" : null,
                rolSuffix == "Admin" ? "Administrador" : null,
                rolSuffix == "Recep" ? "Recepcionista" : null
            };

            foreach (var b in bases)
            {
                foreach (var end in endings)
                {
                    if (end == null) continue;

                    var lbl = FindCtl<Label>($"l{b}{end}");
                    if (lbl != null) lbl.Visible = visible;

                    var tb = FindCtl<TextBox>($"tb{b}{end}");
                    if (tb != null)
                    {
                        tb.Visible = visible;
                        tb.UseSystemPasswordChar = true;
                        tb.PasswordChar = '●';
                    }
                }
            }
        }

        // Extras de médico
        private void ToggleMedicoExtras(bool visible)
        {
            SetVisible("lMatricula", visible);
            SetVisible("tbMatricula", visible);
            SetVisible("lEspecialidadFormUsuario", visible);
            SetVisible("tbEspecialidadFormUsuario", visible);
            SetVisible("lConsultorio", visible);
            SetVisible("tbConsultorio", visible);
        }

        private string GetText(string name) => FindCtl<TextBox>(name)?.Text?.Trim() ?? "";
        private string GetTextAny(params string[] names)
            => names.Select(n => FindCtl<TextBox>(n)?.Text?.Trim()).FirstOrDefault(t => !string.IsNullOrEmpty(t)) ?? "";
        private string GetComboText(string name) => FindCtl<ComboBox>(name)?.Text?.Trim() ?? "";
        private string GetNumericText(string name)
        {
            var nud = FindCtl<NumericUpDown>(name);
            return nud != null ? nud.Value.ToString() : "";
        }

        private TextBox GetPasswordTextBoxForCurrentRole()
        {
            var rol = (RolUsuario)(cbRol?.SelectedIndex ?? 0);
            switch (rol)
            {
                case RolUsuario.Medico:
                    return FindCtl<TextBox>("tbContrasenaMedico") ?? FindCtl<TextBox>("tbContraseñaMedico");
                case RolUsuario.Administrador:
                    // No debería usarse ya, pero por si acaso devolvemos null para bloquear validación
                    return null;
                case RolUsuario.Recepcionista:
                    return FindCtl<TextBox>("tbContrasenaRecep") ?? FindCtl<TextBox>("tbContraseñaRecep")
                           ?? FindCtl<TextBox>("tbContrasenaRecepcionista") ?? FindCtl<TextBox>("tbContraseñaRecepcionista");
                default:
                    return null;
            }
        }

        private string GetPasswordForCurrentRole() => GetPasswordTextBoxForCurrentRole()?.Text?.Trim() ?? "";

        private void Msg(string text) => MessageBox.Show(text, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void rbFemenino_CheckedChanged(object sender, EventArgs e) { }
        private void lContraseñaRecep_Click(object sender, EventArgs e) { }

        private void LimpiarCampos()
        {
            // Recorre todos los TextBox y limpia su contenido
            foreach (var tb in this.Controls.OfType<TextBox>())
                tb.Clear();

            // También limpia TextBox que estén dentro de GroupBox u otros contenedores
            foreach (var gb in this.Controls.OfType<GroupBox>())
            {
                foreach (var tb in gb.Controls.OfType<TextBox>())
                    tb.Clear();
            }

            // Restablecer ComboBox (roles)
            if (cbRol != null && cbRol.Items.Count > 0)
                cbRol.SelectedIndex = 0;

            // Deseleccionar radios de sexo
            var rbM = FindCtl<RadioButton>("rbMasculino");
            var rbF = FindCtl<RadioButton>("rbFemenino");
            if (rbM != null) rbM.Checked = false;
            if (rbF != null) rbF.Checked = false;

            // Opcional: limpiar NumericUpDown si usás
            foreach (var nud in this.Controls.OfType<NumericUpDown>())
                nud.Value = nud.Minimum;
        }
    }
}
