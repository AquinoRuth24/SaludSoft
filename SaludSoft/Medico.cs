using System;
using System.Linq;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class Medico : Form
    {
        public Medico()
        {
            InitializeComponent();
        }

        // ==== Helpers ====
        private static T BuscarAbierto<T>() where T : Form
            => Application.OpenForms.OfType<T>().FirstOrDefault();

        // ==== HANDLERS QUE FALTABAN (NOMBRES EXACTOS DEL DESIGNER) ====

        // 1) TextChanged del cuadro de búsqueda de paciente
        private void tbBuscarPaciente_TextChanged(object sender, EventArgs e)
        {
            // TODO: filtrar pacientes mientras escribe (opcional)
            // Ej: FiltrarGrillaPacientes(tbBuscarPaciente.Text);
        }

        // 2) Click del botón Historial
        private void BHistorial_Click(object sender, EventArgs e)
        {
            using (var frm = new FormHistorial())
            {
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog(this);
            }
        }

        // 3) Click del botón Cerrar Sesión
        private void BCerrarSesion_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("¿Seguro que querés cerrar sesión?",
                                    "Cerrar sesión",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            // Cerrar todos los forms menos este y Login (si existiera)
            foreach (Form f in Application.OpenForms.Cast<Form>().ToArray())
            {
                if (f != this && !(f is FormLogin))
                    f.Close();
            }

            // Abrir (o reutilizar) Login
            var login = BuscarAbierto<FormLogin>() ?? new FormLogin();
            login.StartPosition = FormStartPosition.CenterScreen;

            // Al cerrarse el login, cerramos este formulario Medico
            login.FormClosed += (_, __) =>
            {
                if (!this.IsDisposed) this.Close();
            };

            login.Show();
            login.Activate();
            login.BringToFront();

            // Ocultamos este
            this.Hide();
        }

      

        private void btCitas_Click(object sender, EventArgs e)
        {
            // Mostrar panel de citas
            pnlCitas.Visible = true;
            pnlCitas.BringToFront();
            this.Show();
            this.Activate();
        }
        //corregir no cierra la ventana
        private void btCerrar_Click(object sender, EventArgs e)
        {
            // Ocultar panel de citas y volver a la vista principal del formulario
            pnlCitas.Visible = false;

            // Si tenés un panel principal, mostrale:
            // pnlHome.Visible = true;
            // pnlHome.BringToFront();

            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }
    }
}
