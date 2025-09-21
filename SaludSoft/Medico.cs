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
    public partial class Medico : Form
    {
        public Medico()
        {
            InitializeComponent();
        }

        private void tbBuscarPaciente_TextChanged(object sender, EventArgs e)
        {

        }

        private void BHistorial_Click(object sender, EventArgs e)
        {
            FormHistorial frm = new FormHistorial();
            frm.ShowDialog();
        }

        private void BCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();
            frm.ShowDialog();
        }
    }
}
