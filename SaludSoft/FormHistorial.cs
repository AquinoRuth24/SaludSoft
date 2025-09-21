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
                int idHistorial = Convert.ToInt32(dgHistorial.Rows[e.RowIndex].Cells["colIdHistorial"].Value);

                // Abrir formulario de detalle/modificación
                // frm = new FormDetalleHistorial(idHistorial);
                //frm.ShowDialog();
            }
        }
    }
}
