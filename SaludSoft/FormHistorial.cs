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
    public partial class FormHistorial : Form
    {
        public FormHistorial()
        {
            InitializeComponent();
        }

        private void dgHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgHistorial.Columns[e.ColumnIndex].Name == "colEditar" && e.RowIndex >= 0)
            {
                // Tomar el id de historial de la fila
                //int idHistorial = Convert.ToInt32(dgHistorial.Rows[e.RowIndex].Cells["colIdHistorial"].Value);

                // Abrir formulario de detalle/modificación
                //FormDetalleHistorial frm = new FormDetalleHistorial(idHistorial);
                //frm.ShowDialog();
            }
        }

        private void btVolver_Click_1(object sender, EventArgs e)
        {
         
            // Si fue abierto modal con Owner:
            if (this.Owner is Medico m)
            {
                m.Show();
                m.Activate();
            }
            else
            {
                // Fallback: buscar un Medico abierto
                var medico = Application.OpenForms.OfType<Medico>().FirstOrDefault();
                if (medico != null) { medico.Show(); medico.Activate(); }
            }

            this.Close(); // cierra FormHistorial
        }
    }
    }

