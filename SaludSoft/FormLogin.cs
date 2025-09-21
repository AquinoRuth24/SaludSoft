using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                // === Usuario: correo electrónico ===
                tbUsuario.KeyPress += SoloEmail_KeyPress;
                tbUsuario.TextChanged += SanitizarEmailAlPegar;

                // === Contraseña: alfanumérico como tenías ===
                tbContraseña.KeyPress += SoloAlfanumerico_KeyPress;
                tbContraseña.TextChanged += SanitizarAlPegar;
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void btIniciarSesion_Click(object sender, EventArgs e)
        {
            if (!EsEmailBasico(tbUsuario.Text))
            {
                MessageBox.Show("Ingresá un correo electrónico válido como usuario.",
                                "Usuario inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUsuario.Focus();
                tbUsuario.SelectAll();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbContraseña.Text))
            {
                MessageBox.Show("Ingresá tu contraseña.", "Falta contraseña",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbContraseña.Focus();
                return;
            }

            // TODO: autenticación real (hash/BD). Demo:
            MessageBox.Show("Login OK (demo).", "SaludSoft",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lOlvidasteContraseña_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Contactá al administrador o usa el proceso de recuperación.",
                "Olvidé mi contraseña",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ─────────────────────────────────────────────────────────
        // USUARIO = EMAIL (permitir @ . _ - + y sólo una @)
        private static bool EsEmailChar(char c)
            => char.IsLetterOrDigit(c) || c == '@' || c == '.' || c == '_' || c == '-' || c == '+';

        private void SoloEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;              // backspace, enter, etc.
            if (e.KeyChar == ' ') { e.Handled = true; return; } // sin espacios

            if (!EsEmailChar(e.KeyChar)) { e.Handled = true; return; }

            // una sola @
            var tb = (TextBox)sender;
            if (e.KeyChar == '@' && tb.Text.Contains('@'))
                e.Handled = true;
        }

        private void SanitizarEmailAlPegar(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            int caret = tb.SelectionStart;

            var sb = new StringBuilder(tb.Text.Length);
            bool vioArroba = false;

            foreach (char c in tb.Text)
            {
                if (!EsEmailChar(c)) continue;

                if (c == '@')
                {
                    if (vioArroba) continue; // descarta @ repetidas
                    vioArroba = true;
                }

                sb.Append(c);
            }

            if (tb.Text != sb.ToString())
            {
                tb.Text = sb.ToString();
                tb.SelectionStart = Math.Min(caret, tb.Text.Length);
            }
        }

        // Validación muy simple (sin System.Net.Mail)
        private static bool EsEmailBasico(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            int at = s.IndexOf('@');
            if (at <= 0) return false;
            int dot = s.LastIndexOf('.');
            if (dot <= at + 1) return false;
            if (dot == s.Length - 1) return false;
            return true;
        }

        // ─────────────────────────────────────────────────────────
        // CONTRASEÑA = ALFANUMÉRICO (tu lógica original)
        private void SoloAlfanumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;

            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                return;
            }

            if (!char.IsLetterOrDigit(e.KeyChar))
                e.Handled = true;
        }

        private void SanitizarAlPegar(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            int caret = tb.SelectionStart;

            var limpio = new StringBuilder(tb.Text.Length);
            foreach (char c in tb.Text)
                if (char.IsLetterOrDigit(c)) limpio.Append(c);

            if (tb.Text != limpio.ToString())
            {
                tb.Text = limpio.ToString();
                tb.SelectionStart = Math.Min(caret, tb.Text.Length);
            }
        }

        private void tbUsuario_TextChanged(object sender, EventArgs e) { }
        private void tbContraseña_TextChanged(object sender, EventArgs e) { }
    }
}
