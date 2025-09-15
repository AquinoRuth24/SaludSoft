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
    public partial class SaludSoft : Form
    {
        public SaludSoft()
        {
            InitializeComponent();
            

        }

        private void BNuevoPaciente_Click(object sender, EventArgs e)
        {
            // se instancia el formulario y se muestra 
            FormPaciente frm = new FormPaciente();  
            frm.ShowDialog();
        }

        private void BNuevaCita_Click(object sender, EventArgs e)
        {
            FormNuevoTurno frm = new FormNuevoTurno();
            frm.ShowDialog();
        }

        private void BInicio_Click(object sender, EventArgs e)
        {
            SaludSoft frm = new SaludSoft();
            frm.ShowDialog();
        }

        private void BPacientes_Click(object sender, EventArgs e)
        {
            FormListaPacientes frm = new FormListaPacientes();
            frm.ShowDialog();
        }
    }
}
