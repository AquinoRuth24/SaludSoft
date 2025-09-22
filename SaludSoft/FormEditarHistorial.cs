using System;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class FormEditarHistorial : Form
    {
        public FormEditarHistorial()
        {
            InitializeComponent();

         
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;

            // Si cerrar con la X, cuenta como Cancel
            this.FormClosing += FormEditarHistorial_FormClosing;

            // Permite cerrar con ESC
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) btCancelar_Click(s, e);
            };

            // Botón Cancelar:
            this.CancelButton = btCancelar;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            VolverAlPadreYCerrar();
        }
        // Botón Volver:no vuelve al formulario de medico
        private void brVolver_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.Cancel;
            VolverAlPadreYCerrar();
        }

        private void VolverAlPadreYCerrar()
        {
            // Trae al frente el FormHistorial
            if (this.Owner != null)
            {
                try
                {
                    this.Owner.Activate();
                    this.Owner.BringToFront();
                }
                catch { /* no-op */ }
            }
            this.Close();
        }

        private void FormEditarHistorial_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            if (this.DialogResult == DialogResult.None)
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
