using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                // Bloquear teclas no alfanuméricas
                tbUsuario.KeyPress += SoloAlfanumerico_KeyPress;
                tbContraseña.KeyPress += SoloAlfanumerico_KeyPress;

                // Si pegan texto con caracteres inválidos, lo limpio
                tbUsuario.TextChanged += SanitizarAlPegar;
                tbContraseña.TextChanged += SanitizarAlPegar;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btIniciarSesion_Click(object sender, EventArgs e)
        {

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

        // 1) Bloquea en el momento de tipear (no permite escribir nada que no sea letra o número)
        private void SoloAlfanumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control (Backspace, Delete, flechas, Tab, Enter, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Bloquear espacios
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                return;
            }

            // Permitir sólo letras y números (incluye letras acentuadas)
            if (!char.IsLetterOrDigit(e.KeyChar))
                e.Handled = true;
        }

        // 2) Si pegan texto con Ctrl+V u otro método, se limpia lo que no sea alfanumérico
        private void SanitizarAlPegar(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            int caret = tb.SelectionStart;

            var limpio = new System.Text.StringBuilder(tb.Text.Length);
            foreach (char c in tb.Text)
                if (char.IsLetterOrDigit(c)) limpio.Append(c);

            if (tb.Text != limpio.ToString())
            {
                tb.Text = limpio.ToString();
                // Restauro la posición del cursor lo mejor posible
                tb.SelectionStart = Math.Min(caret, tb.Text.Length);
            }
        }

    }
}