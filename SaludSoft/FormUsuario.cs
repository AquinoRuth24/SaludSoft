using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SaludSoft.Security; // Para PasswordHasher.Hash

namespace SaludSoft.Resources
{
    public partial class FormUsuario : Form
    {
        public FormUsuario()
        {
            InitializeComponent();

            // Eventos base
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

        /// <summary>
        /// Exige que el primer TextBox existente entre 'names' tenga texto.
        /// Si ninguno de los nombres existe, lo consideramos OK.
        /// </summary>
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
            return true; // ningún control de la lista existe -> no falla
        }


        private enum RolUsuario { Paciente = 0, Medico = 1, Recepcionista = 2, Administrador = 3 }

        // ------------------ Load & Rol ------------------
        private void FormUsuario_Load(object sender, EventArgs e)
        {
            if (cbRol != null && cbRol.Items.Count == 0)
            {
                cbRol.Items.AddRange(new object[] { "Paciente", "Médico", "Recepcionista","Administrador" });
                cbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            if (cbRol != null && cbRol.SelectedIndex < 0) cbRol.SelectedIndex = 0;

            AplicarUIRol();
            this.AutoScaleMode = AutoScaleMode.Font;
        }

        private void cbRol_SelectedIndexChanged(object sender, EventArgs e) => AplicarUIRol();

        private void AplicarUIRol()
        {
            // Ocultar específicos
            SetVisible("gbPaciente", false);
            SetVisible("gbMedico", false);
            SetVisible("gbRecep", false);
            SetVisible("gbAdmin", false);
           
            // Ocultar todas las contraseñas por rol
            ShowPwdFor("Medico", false);
            ShowPwdFor("Administrador", false);
            ShowPwdFor("Recep", false);
           

            // (opcional) extras de médico
            ToggleMedicoExtras(false);

            var rol = (RolUsuario)(cbRol?.SelectedIndex ?? 0);
            switch (rol)
            {
                case RolUsuario.Paciente:
                    SetVisible("gbPaciente", true);
            
                    break;

                case RolUsuario.Medico:
                    SetVisible("gbMedico", true);
                    ShowPwdFor("Medico", true);
                    ToggleMedicoExtras(true);
                    break;

                case RolUsuario.Recepcionista:
                    SetVisible("gbRecepcionista", true);
                    ShowPwdFor("Recepcionista", true);      
                    break;

                case RolUsuario.Administrador:
                    SetVisible("gbAdmin", true);
                    ShowPwdFor("Administrador", true);
                    break;

                
            }
        }

        // ------------------ Botones ------------------
        // Botón "Inicio"
        private void button1_Click(object sender, EventArgs e)
        {
            // Opción simple: cerrar este formulario (volver atrás)
            this.DialogResult = DialogResult.Cancel;
            this.Close();

            // Si preferís ir a otra pantalla, descomentá y ajustá:
            // var home = new Admin();   // o el form que sea tu inicio
            // home.Show();
            // this.Hide();
        }
        // Botón "Cerrar sesión"
        private void button2_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("¿Cerrar sesión?", "Confirmar",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                // Si tenés pantalla de login:
                // var login = new FormLogin();
                // login.Show();
                // this.Hide();
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
            if (!ValidarFormulario()) return;

            // Comunes
            string nombre = GetText("tbNombre");
            string apellido = GetText("tbApellido");
            string dni = GetText("tbDni");
            string direccion = GetText("tbDireccion");
            string correo = GetText("tbCorreo");
            string telefono = GetText("tbTelefono");

            var rol = (RolUsuario)(cbRol?.SelectedIndex ?? 0);
            string rolStr = cbRol?.Text ?? rol.ToString();

            // Contraseña -> HASH PBKDF2 (PasswordHasher)
            string pwPlano = GetPasswordForCurrentRole() ?? "";
            string passwordHash = string.IsNullOrWhiteSpace(pwPlano) ? null : PasswordHasher.Hash(pwPlano);

            // Específicos (sin “Turno”)
            string extra = "";
            if (rol == RolUsuario.Medico)
            {
                string matricula = GetTextAny("tbMatricula");
                string especialidad = GetTextAny("tbEspecialidadFormUsuario", "tbEspecialidad");
        
                string consultorio = GetTextAny("tbConsultorio");
                extra = $" | Matrícula: {matricula} | Esp.: {especialidad} | Cons.: {consultorio}";
            }

            // SIN BD: solo mostramos resumen
            MessageBox.Show(
                $"Rol: {rolStr}\n" +
                $"Nombre: {nombre} {apellido}\n" +
                $"DNI: {dni}\n" +
                $"Correo: {correo}\n" +
                $"Tel.: {telefono}\n" +
                $"Dirección: {direccion}\n" +
                $"Contraseña: {(string.IsNullOrEmpty(passwordHash) ? "(vacía)" : "(hash generado)")}\n" +
                $"{extra}",
                "Usuario (modo sin BD)",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Limpiar contraseña ingresada
            var tbPwd = GetPasswordTextBoxForCurrentRole();
            if (tbPwd != null) tbPwd.Text = string.Empty;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btVolver_Click(object sender, EventArgs e)
        {
            // Haz aquí lo que quieras al “volver”. Por ejemplo, cerrar el form:
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
            const string SOLO_LETRAS = @"^[\p{L}\s]+$";                  // letras (incluye acentos) y espacios
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
                if (!ReqAny(new[] { "tbDepartamento", "txtDepartamento" }, "Ingrese el departamento")) return false;
                var cboNivel = FindCtl<ComboBox>("cboNivelAcceso");
                if (cboNivel != null && string.IsNullOrWhiteSpace(cboNivel.Text)) { Msg("Seleccione el nivel de acceso"); return false; }
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
            bool Req(string name, string message)
            {
                var tb = FindCtl<TextBox>(name);
                if (tb != null && string.IsNullOrWhiteSpace(tb.Text)) { Msg(message); tb?.Focus(); return false; }
                return true;
            }
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
            if (char.IsLetterOrDigit(c) || c == '@' || c == '.' || c == '_' || c == '-')
                return;
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

            // Si están en contenedores distintos, fuerzo exclusión manual
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

        // Muestra/oculta Label/TextBox de contraseña por rol (acepta 'Contrasena'/'Contraseña' y 'Recep'/'Recepcionista')
        private void ShowPwdFor(string rolSuffix, bool visible)
        {
            var lbl = FindCtl<Label>($"lContrasena{rolSuffix}") ?? FindCtl<Label>($"lContraseña{rolSuffix}");
            var tb = FindCtl<TextBox>($"tbContrasena{rolSuffix}") ?? FindCtl<TextBox>($"tbContraseña{rolSuffix}");

            if (rolSuffix == "Recep" && lbl == null && tb == null)
            {
                lbl = FindCtl<Label>("lContrasenaRecepcionista") ?? FindCtl<Label>("lContraseñaRecepcionista");
                tb = FindCtl<TextBox>("tbContrasenaRecepcionista") ?? FindCtl<TextBox>("tbContraseñaRecepcionista");
            }

            if (lbl != null) lbl.Visible = visible;
            if (tb != null)
            {
                tb.Visible = visible;
                tb.UseSystemPasswordChar = true;
                tb.PasswordChar = '●';
            }
        }

        // Extras de médico (ajusta según tus nombres reales)
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
                    return FindCtl<TextBox>("tbContrasenaAdministrador") ?? FindCtl<TextBox>("tbContraseñaAdministrador");
                case RolUsuario.Recepcionista:
                    return FindCtl<TextBox>("tbContrasenaRecep") ?? FindCtl<TextBox>("tbContraseñaRecep")
                           ?? FindCtl<TextBox>("tbContrasenaRecepcionista") ?? FindCtl<TextBox>("tbContraseñaRecepcionista");
                default:
                    return null;
            }
        }
        private string GetPasswordForCurrentRole() => GetPasswordTextBoxForCurrentRole()?.Text?.Trim() ?? "";

        private void Msg(string text) => MessageBox.Show(text, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        // Si el diseñador tiene este handler enganchado, puede quedar vacío:
        private void rbFemenino_CheckedChanged(object sender, EventArgs e) { }

        private void lContraseñaRecep_Click(object sender, EventArgs e)
        {

        }
    }
}
