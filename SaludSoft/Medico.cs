using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfFont = iTextSharp.text.Font;
using System;
using System.IO;
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
        private void tbBuscarPaciente_TextChanged(object sender, EventArgs e)
        {
            
        }

        //Click del botón Historial
        private void BHistorial_Click(object sender, EventArgs e)
        {
            using (var frm = new FormHistorial())
            {
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog(this);
            }
        }

        //Click del botón Cerrar Sesión
        private void BCerrarSesion_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("¿Seguro que querés cerrar sesión?",
                                    "Cerrar sesión",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            // Cerrar todos los forms
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
            login.LimpiarCampos();


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

        private void btCerrar_Click_1(object sender, EventArgs e)
        {
            CerrarCitasUI();
        }

        private void CerrarCitasUI()
        {
            if (pnlCitas == null) return;
            pnlCitas.Visible = false;
            pnlCitas.SendToBack();
            this.Activate();
        }

        private void btnImprimirCitas_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dateTimePicker1.Value;
            DataGridView dgv = dgCitas;

            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("No hay citas para imprimir en esta fecha.", "Impresión",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                
                string rutaArchivo;
                using (var sfd = new SaveFileDialog()
                {
                    Title = "Guardar PDF de citas",
                    Filter = "Archivo PDF (*.pdf)|*.pdf",
                    FileName = $"Citas_{fechaSeleccionada:ddMMyyyy}.pdf"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                        rutaArchivo = sfd.FileName;
                    else
                    {
                        string carpeta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        rutaArchivo = Path.Combine(carpeta, $"Citas_{fechaSeleccionada:ddMMyyyy}.pdf");
                    }
                }

                // Documento
                var doc = new Document(PageSize.A4, 50, 50, 50, 50);
                PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                doc.Open();

                // Encabezado
                var fontTitulo = new PdfFont(PdfFont.FontFamily.HELVETICA, 18, PdfFont.BOLD, BaseColor.BLACK);
                var titulo = new Paragraph("Citas del día", fontTitulo) { Alignment = Element.ALIGN_CENTER };
                doc.Add(titulo);

                var fontTexto = new PdfFont(PdfFont.FontFamily.HELVETICA, 12, PdfFont.NORMAL, BaseColor.BLACK);
                doc.Add(new Paragraph($"Fecha: {fechaSeleccionada:dd/MM/yyyy}\n\n", fontTexto));

                // Columnas a exportar (solo visibles y que no sean botón/imagen)
                var columnas = dgv.Columns
                    .Cast<DataGridViewColumn>()
                    .Where(c => c.Visible && !(c is DataGridViewButtonColumn) && !(c is DataGridViewImageColumn))
                    .ToList();

                var tabla = new PdfPTable(columnas.Count) { WidthPercentage = 100 };

                // Encabezados
                var fontHeader = new PdfFont(PdfFont.FontFamily.HELVETICA, 11, PdfFont.BOLD, BaseColor.BLACK);
                foreach (var col in columnas)
                {
                    var celdaEnc = new PdfPCell(new Phrase(col.HeaderText, fontHeader))
                    {
                        BackgroundColor = BaseColor.LIGHT_GRAY,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    tabla.AddCell(celdaEnc);
                }

                // Filas
                foreach (DataGridViewRow fila in dgv.Rows)
                {
                    if (fila.IsNewRow) continue;

                    foreach (var col in columnas)
                    {
                        var val = fila.Cells[col.Index].Value?.ToString() ?? "";
                        tabla.AddCell(new Phrase(val, fontTexto));
                    }
                }

                doc.Add(tabla);
                doc.Close();

                MessageBox.Show($"PDF generado correctamente:\n{rutaArchivo}", "Impresión exitosa",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                try { System.Diagnostics.Process.Start(rutaArchivo); } catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
