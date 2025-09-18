using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;        // <--- IMPORTANTE
using System.Linq;
using System.Windows.Forms;

namespace SaludSoft.Resources
{
    public partial class FormGestionUsuario : Form
    {
        private const string ColAcciones = "Acciones"; // (Name) de tu columna existente
        private const int BtnW = 34, BtnH = 26, BtnGap = 8, BtnRadius = 8;

        private Image _icoEditar, _icoBorrar;

        public FormGestionUsuario()
        {
            InitializeComponent();
            //dgUsuario.CellPainting += dgUsuario_CellPainting;
            dgUsuario.CellMouseClick += dgUsuario_CellMouseClick;
        }

        private void FormGestionUsuario_Load(object sender, EventArgs e)
        {
            dgUsuario.AutoGenerateColumns = false;
            dgUsuario.RowHeadersVisible = false;
            dgUsuario.ReadOnly = true;
            dgUsuario.AllowUserToAddRows = false;
            dgUsuario.AllowUserToDeleteRows = false;
            dgUsuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgUsuario.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgUsuario.RowTemplate.Height = 44;

            // Carga de íconos desde carpeta del proyecto (y fallback a Resources embebidos si existieran)
            _icoEditar = LoadProjectImage("archivo-de-edicion.png")
                         ?? GetRes("edit", "editar", "pencil", "lapiz");
            _icoBorrar = LoadProjectImage("basura.png")
                         ?? GetRes("trash", "delete", "papelera", "eliminar");

            var fuente = new[]
            {
                new {
                    Id = Guid.NewGuid(),
                    colUsuario  = "Juan Pérez\njuan.perez@email.com",
                    colTipo     = "Paciente",
                    colContacto = "+1 234 567 8901",
                    colEstado   = "Activo"
                }
            }.ToList();

            dgUsuario.DataSource = fuente;
            if (dgUsuario.Columns["Id"] != null) dgUsuario.Columns["Id"].Visible = false;
        }

        
         

         

     
   

        // --------- Click en cada "pastilla" ---------
        private void dgUsuario_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgUsuario.Columns[e.ColumnIndex].Name != ColAcciones) return;

            var cellRect = dgUsuario.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            var rVer = BtnRect(cellRect, 0);
            var rEdt = BtnRect(cellRect, 1);
            var rDel = BtnRect(cellRect, 2);
            var pt = new Point(e.X, e.Y);

            var idObj = dgUsuario.Rows[e.RowIndex].Cells["Id"]?.Value;
            if (idObj == null) return;
            var id = Guid.Parse(idObj.ToString());

            if (rVer.Contains(pt)) VerUsuario(id);
            else if (rEdt.Contains(pt)) EditarUsuario(id);
            else if (rDel.Contains(pt))
            {
                if (MessageBox.Show("¿Eliminar lógicamente este usuario?",
                                    "Confirmar", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EliminarLogico(id);
                }
            }
        }

        // --------- Tu lógica (stubs) ---------
      
        private void EditarUsuario(Guid id) => MessageBox.Show($"EDITAR: {id}");
        private void EliminarLogico(Guid id)
        {
            MessageBox.Show($"ELIMINADO (soft): {id}");
            // TODO: marcar Eliminado=true en tu lista/modelo y refrescar
        }

        // --------- Helpers gráficos / carga de imágenes ---------
        private Rectangle BtnRect(Rectangle cell, int idx /*0 ver, 1 editar, 2 eliminar*/)
        {
            int total = BtnW * 3 + BtnGap * 2;
            int x = cell.X + (cell.Width - total) / 2;
            int y = cell.Y + (cell.Height - BtnH) / 2;
            if (idx == 1) x += BtnW + BtnGap;
            if (idx == 2) x += (BtnW + BtnGap) * 2;
            return new Rectangle(x, y, BtnW, BtnH);
        }

        private Rectangle Center(Rectangle host, int w, int h)
            => new Rectangle(host.X + (host.Width - w) / 2, host.Y + (host.Height - h) / 2, w, h);

        private GraphicsPath Round(Rectangle r, int radius)
        {
            int d = radius * 2;
            var gp = new GraphicsPath();
            gp.AddArc(r.X, r.Y, d, d, 180, 90);
            gp.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            gp.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            gp.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            gp.CloseFigure();
            return gp;
        }

        // Carga desde carpeta del proyecto o desde la salida (bin), y si no, intenta Properties.Resources
        private Image LoadProjectImage(string fileName)
        {
            try
            {
                // 1) salida (bin\Debug...\Resources) si copiaste "Copy if newer"
                string outRes = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", fileName);
                if (File.Exists(outRes)) return Image.FromFile(outRes);

                // 2) raíz del proyecto (…\SaludSoft\Resources)
                string projRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
                string projRes = Path.Combine(projRoot, "Resources", fileName);
                if (File.Exists(projRes)) return Image.FromFile(projRes);

                return null;
            }
            catch { return null; }
        }

        private Image GetRes(params string[] keys)
        {
            foreach (var k in keys)
            {
                var obj = Properties.Resources.ResourceManager.GetObject(k);
                if (obj is Image img) return img;
            }
            return null;
        }

        

        // Mantengo tus handlers vacíos para que no rompa el diseñador
        private void cbTipos_SelectionChangeCommitted(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
