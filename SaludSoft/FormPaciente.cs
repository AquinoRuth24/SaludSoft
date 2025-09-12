using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class FormPaciente : Form
    {
        public FormPaciente()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int radio = 30; // Ajusta el nivel de redondeo
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = panel1.ClientRectangle;

            using (GraphicsPath path = new GraphicsPath())
            {
                int d = radio * 2;
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();

                panel1.Region = new Region(path);
            }
        }

        private void FormPaciente_Load(object sender, EventArgs e)
        {

        }

        private void BRegistrar_Click(object sender, EventArgs e)
        {

        }

        private void BPruebaConexion_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = Conexion.GetConnection())
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Conexión exitosa a la base de datos SaludSoft.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar: " + ex.Message);
                }
            }
        }
    }
}
