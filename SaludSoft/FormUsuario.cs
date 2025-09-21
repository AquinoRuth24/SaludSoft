using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

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
        // ------------------ Load & Rol ------------------
        private void FormUsuario_Load(object sender, EventArgs e)
        {
            CargarRoles();

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
            ShowPwdFor("Administrador", false);
            ShowPwdFor("Admin", false);

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
            }
        }

        private void HideAllRoleGroups()
        {
            SetVisible("gbPaciente", false);
            SetVisible("gbMedico", false);
            SetVisible("gbRecepcionista", false);
            SetVisible("gbAdmin", false);
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
            if (cbRol?.SelectedValue == null)

            if (rolDestino == RolUsuario.Administrador)
            {
                Msg("No está permitido crear usuarios con rol Administrador.");
                return;
            }

            if (!ValidarFormulario()) return;

            // Datos comunes
            string nombre = GetText("tbNombre");
            string apellido = GetText("tbApellido");
            string dni = GetText("tbDni");
            string direccion = GetText("tbDireccion");
            string correo = GetText("tbCorreo");
            string telefono = GetText("tbTelefono");

            // Contraseña (hash PBKDF2)
            string pwPlano = GetPasswordForCurrentRole() ?? "";
            string passwordHash = string.IsNullOrWhiteSpace(pwPlano) ? null : PasswordHasher.Hash(pwPlano);

            using (var con = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=SaludSoft;Trusted_Connection=True;"))
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();

                try
            }

                    // Insert según rol
                    if (rolDestino == RolUsuario.Paciente)
                    {
                        var rbM = FindCtl<RadioButton>("rbMasculino");
                        var sexo = (rbM != null && rbM.Checked) ? "Masculino" : "Femenino";

                        string sqlPaciente = @"INSERT INTO Paciente (nombre, apellido, dni, sexo, direccion, email, telefono, id_estado)
                                               VALUES (@nombre, @apellido, @dni, @sexo, @direccion, @correo, @telefono, 1)";
                        using (var cmd = new SqlCommand(sqlPaciente, con, tx))
                        {
                            cmd.Parameters.AddWithValue("@nombre", nombre);
                            cmd.Parameters.AddWithValue("@apellido", apellido);
                            cmd.Parameters.AddWithValue("@dni", int.Parse(dni));

                        string sqlProfesional = @"INSERT INTO Profesional (id_profesional, nombre, apellido, email, matricula, id_estado, id_especialidad)
                                                  VALUES ((SELECT ISNULL(MAX(id_profesional),0)+1 FROM Profesional),
                                                          @nombre, @apellido, @correo, @matricula, 1, @id_especialidad)";


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
                Msg("No está permitido crear usuarios con rol Administrador.");
                return false;
            }

            // Sexo: si tenés rbMasculino / rbFemenino, exige uno
            var rbM = FindCtl<RadioButton>("rbMasculino");
            var rbF = FindCtl<RadioButton>("rbFemenino");
            if ((rbM != null || rbF != null) && !((rbM?.Checked ?? false) || (rbF?.Checked ?? false)))
            {
                Msg("Seleccione el sexo"); return false;
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
    }
}
