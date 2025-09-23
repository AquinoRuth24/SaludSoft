using SaludSoft.Resources.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent(); 
        }

        
        // Helpers de navegación
        private void MostrarYVolver(Form destino)
        {
            if (destino == null) return;

            destino.StartPosition = FormStartPosition.CenterScreen;
            destino.Show();
            this.Hide();

            destino.FormClosed += (s, a) =>
            {
                if (!this.IsDisposed)
                {
                    this.Show();
                    this.Activate();
                    this.BringToFront();
                }
            };
        }

        private T BuscarAbierto<T>() where T : Form
        {
            return Application.OpenForms.OfType<T>().FirstOrDefault();
        }

        
        // Botones
        private void btInicio_Click(object sender, EventArgs e)
        {
            
            this.Activate();
            this.BringToFront();
        }

        private void btGestionUsuario_Click(object sender, EventArgs e)
        {
            // Abre  FormGestionUsuario
            var frm = BuscarAbierto<FormGestionUsuario>();
            if (frm == null) frm = new FormGestionUsuario();

            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
            frm.Focus();

            MostrarYVolver(frm);
        }

        private void btBackup_Click(object sender, EventArgs e)
        {
            var frm = BuscarAbierto<Backup>();
            if (frm == null) frm = new Backup();

            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
            frm.Focus();

            MostrarYVolver(frm);
        }

        private void btCerrarSesion_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("¿Seguro que querés cerrar sesión?",
                                    "Cerrar sesión",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

           

            //Cerrar
            var aCerrar = Application.OpenForms.Cast<Form>()
                           .Where(f => f != this && !(f is FormLogin))
                           .ToList();
            foreach (var f in aCerrar) f.Close();

            var login = BuscarAbierto<FormLogin>();
            if (login == null) login = new FormLogin();

            login.StartPosition = FormStartPosition.CenterScreen;
            login.Show();

            this.Hide();
            login.FormClosed += (s, a2) =>
            {
                if (!this.IsDisposed) this.Close();
            };
        }

   
    }
}
