using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

// Alias para evitar choques con System.Drawing y genéricos
using PdfFont = iTextSharp.text.Font;
using PdfRect = iTextSharp.text.Rectangle;
using PdfPhrase = iTextSharp.text.Phrase;
using PdfParagraph = iTextSharp.text.Paragraph;
using PdfList = iTextSharp.text.List;
using PdfListItem = iTextSharp.text.ListItem;

namespace SaludSoft
{
    public partial class FormHistorial : Form
    {
        enum ModoDetalle { Navegacion, Alta }
        ModoDetalle _modo = ModoDetalle.Navegacion;

        // === CONEXIÓN A BD ===
        private readonly string _cnx =
            @"Server=localhost\SQLEXPRESS;Database=SaludSoft;Trusted_Connection=True;TrustServerCertificate=True;";
       //Datos de medico
        public int? ProfesionalId { get; set; }  
        public string EmailUsuarioActual { get; set; }
        public FormHistorial()
        {
            InitializeComponent();

            // Load
            this.Load += FormHistorial_Load;

            // Grid
            dgHistorial.CellContentClick += dgHistorial_CellContentClick;

            // Botones visor
            btAgregar.Click += btAgregar_Click;
            btCancelar.Click += btCancelar_Click;
            btCerrarDetalle.Click += btCerrarDetalle_Click;

            // Búsqueda por DNI
            btLupaBuscar.Click += (s, e) => EjecutarBusquedaDni();
            tbBuscarDni.MaxLength = 8;
            tbBuscarDni.ImeMode = ImeMode.Disable;
            tbBuscarDni.KeyDown += TbBuscarDni_KeyDown;
        }

        // ---------- Load ----------
        private void FormHistorial_Load(object sender, EventArgs e)
        {
            AsegurarColumnas();
            pnlOverlay.Visible = false;
            SetModo(ModoDetalle.Navegacion);

            // Configurar RTB para historial(en el diseño tmb esta)
            if (rtbHistorial != null)
            {
                rtbHistorial.ReadOnly = true;
                rtbHistorial.BorderStyle = BorderStyle.None;
                rtbHistorial.WordWrap = true;
                rtbHistorial.ScrollBars = RichTextBoxScrollBars.Vertical;
                rtbHistorial.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                rtbHistorial.BackColor = gbDetalle.BackColor; 
                rtbHistorial.Text = "—";
            }
        }

        // ---------- Validación de DNI ----------
        private void TbBuscarDni_KeyDown(object sender, KeyEventArgs e)
        {
            var tb = (TextBox)sender;

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string dni = new string(tb.Text.Where(char.IsDigit).ToArray());
                if (dni.Length == 0 || dni.Length > 8)
                {
                    MessageBox.Show("Ingresá un DNI numérico de hasta 8 dígitos.", "Buscar",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                tb.Text = dni;
                tb.SelectionStart = tb.Text.Length;
                EjecutarBusquedaDni();
                return;
            }

            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Tab ||
                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Home || e.KeyCode == Keys.End)
                return;

            if ((e.Control || e.Modifiers.HasFlag(Keys.Control)) && (e.KeyCode == Keys.C || e.KeyCode == Keys.X))
                return;

            if ((e.Control || e.Modifiers.HasFlag(Keys.Control)) && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                string clip = Clipboard.GetText() ?? "";
                string solo = new string(clip.Where(char.IsDigit).ToArray());
                int espacio = 8 - (tb.TextLength - tb.SelectionLength);
                if (espacio <= 0) return;
                if (solo.Length > espacio) solo = solo.Substring(0, espacio);

                int sel = tb.SelectionStart;
                tb.Text = tb.Text.Remove(sel, tb.SelectionLength).Insert(sel, solo);
                tb.SelectionStart = sel + solo.Length;
                return;
            }

            bool fila = e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && !e.Shift;
            bool pad = e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9;

            if (fila || pad)
            {
                int actuales = tb.TextLength - tb.SelectionLength;
                if (actuales >= 8) e.SuppressKeyPress = true;
                return;
            }

            e.SuppressKeyPress = true;
        }

        // ---------- Columnas ----------
        private void AsegurarColumnas()
        {
            if (dgHistorial.Columns["colFecha"] == null)
            {
                var colFecha = new DataGridViewTextBoxColumn
                {
                    Name = "colFecha",
                    HeaderText = "Fecha",
                    Visible = false
                };
                int idx = dgHistorial.Columns["colPaciente"]?.Index + 1 ?? dgHistorial.Columns.Count;
                dgHistorial.Columns.Insert(Math.Max(0, idx), colFecha);
            }

            if (dgHistorial.Columns["colObservaciones"] == null)
            {
                var colObs = new DataGridViewTextBoxColumn
                {
                    Name = "colObservaciones",
                    HeaderText = "Observaciones",
                    Visible = false
                };
                dgHistorial.Columns.Add(colObs);
            }

            if (dgHistorial.Columns["colHistorialTexto"] == null)
            {
                var colHist = new DataGridViewTextBoxColumn
                {
                    Name = "colHistorialTexto",
                    HeaderText = "Historial",
                    Visible = false
                };
                dgHistorial.Columns.Add(colHist);
            }

            var colBtn = dgHistorial.Columns["colVerHistorial"] as DataGridViewButtonColumn;
            if (colBtn == null)
            {
                colBtn = new DataGridViewButtonColumn
                {
                    Name = "colVerHistorial",
                    HeaderText = "Ver Historial",
                    Text = "Ver",
                    UseColumnTextForButtonValue = true,
                    Width = 110
                };
                dgHistorial.Columns.Add(colBtn);
            }
            else
            {
                colBtn.UseColumnTextForButtonValue = true;
                colBtn.Text = "Ver";
            }

        }

        // ---------- Buscar por DNI----------
        private void EjecutarBusquedaDni()
        {
            string input = (tbBuscarDni.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Ingresá un DNI para buscar.", "Buscar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbBuscarDni.Focus();
                return;
            }

            string dniBuscado = new string(input.Where(char.IsDigit).ToArray());
            if (dniBuscado.Length == 0 || dniBuscado.Length > 8)
            {
                MessageBox.Show("Ingresá un DNI numérico de hasta 8 dígitos.", "Buscar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var pac = GetPacienteBasicoPorDni(dniBuscado);
            if (pac == null)
            {
                MessageBox.Show("No existe un paciente con ese DNI. El médico no puede dar de alta pacientes.",
                                "Historial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Paciente existe: cargar su historial
            CargarFilaDesdeDbPorDni(dniBuscado);
        }

        // ---------- Click en “Ver” ----------
        private void dgHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgHistorial.Columns[e.ColumnIndex].Name != "colVerHistorial") return;

            var fila = dgHistorial.Rows[e.RowIndex];
            CargarDetalleDesdeFila(fila);
            SetModo(ModoDetalle.Navegacion);
            MostrarDetalle(true);
        }

        // ---------- Cargar visor ----------
        private void CargarDetalleDesdeFila(DataGridViewRow fila)
        {
            string paciente = Convert.ToString(fila.Cells["colPaciente"]?.Value ?? "");
            DateTime fecha = TryGetDate(fila.Cells["colFecha"]?.Value) ?? DateTime.Today;

            lValorPaciente.Text = string.IsNullOrWhiteSpace(paciente) ? "--" : paciente;
            lbFechaValor.Text = fecha.ToString("dd/MM/yyyy");

            string histRaw = Convert.ToString(fila.Cells["colHistorialTexto"]?.Value ?? "");
            rtbHistorial.Text = string.IsNullOrWhiteSpace(histRaw)
                ? "—"
                : FormatearHistorial(histRaw);

            gbDetalle.Tag = fila;
        }

        // ---------- Helpers UI ----------
        private DateTime? TryGetDate(object v)
        {
            if (v == null) return null;
            if (v is DateTime dt) return dt;
            if (DateTime.TryParse(Convert.ToString(v), out var parsed)) return parsed;
            return null;
        }

        private string FormatearHistorial(string raw)
        {
            var lineas = raw.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(l => "• " + l.Trim());
            return string.Join(Environment.NewLine + Environment.NewLine, lineas);
        }


        // ---------- Mostrar/Ocultar visor ----------
        private void MostrarDetalle(bool mostrar)
        {
            pnlOverlay.Visible = mostrar;
            gbDetalle.Visible = mostrar;
            if (mostrar)
            {
                pnlOverlay.BringToFront();
                gbDetalle.BringToFront();
                this.ActiveControl = btAgregar;
            }
        }

        private void SetModo(ModoDetalle modo)
        {
            _modo = modo;
            bool editable = (modo == ModoDetalle.Alta);
            lbFechaValor.Visible = !editable;
            dateTimePicker1.Visible = editable;
            btAgregar.Text = editable ? "Guardar" : "Agregar";
            if (!editable) this.ActiveControl = btAgregar;
        }

        // ---------- Agregar / Guardar (persistencia en BD) ----------
        private void btAgregar_Click(object sender, EventArgs e)
        {
            var filaBase = gbDetalle.Tag as DataGridViewRow;
            if (filaBase == null)
            {
                MessageBox.Show("Seleccioná un paciente de la lista (columna 'Ver').", "Historial",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string dni = Convert.ToString(filaBase.Cells["colDni"].Value ?? "");
            dni = new string((dni ?? "").Where(char.IsDigit).ToArray());
            if (dni.Length == 0)
            {
                MessageBox.Show("No se pudo determinar el DNI del paciente.", "Historial",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var pac = GetPacienteBasicoPorDni(dni);
            if (pac == null)
            {
                MessageBox.Show("El paciente ya no existe en la base de datos.", "Historial",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string paciente = $"{pac.Value.nombre} {pac.Value.apellido}";
            int idPaciente = pac.Value.idPaciente;

            // 🔹 Buscar si ya tiene un historial para HOY
            var hoy = DateTime.Today;
            var historialHoy = GetHistorialPorFecha(idPaciente, hoy);

            using (var dlg = new FormEditarHistorial() { Owner = this, StartPosition = FormStartPosition.CenterParent })
            {
                // 🔹 Si existe historial de hoy => editar, si no => alta nueva
                if (historialHoy.HasValue)
                {
                    dlg.InitContext(dni, paciente,
                                    historialHoy.Value.fecha,
                                    historialHoy.Value.diagnostico,
                                    historialHoy.Value.tratamiento,
                                    historialHoy.Value.observaciones);
                }
                else
                {
                    dlg.InitContext(dni, paciente, hoy, "", "", "");
                }

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    GuardarConsultaEnDb(
                        idPaciente: idPaciente,
                        fecha: dlg.Fecha,
                        diagnostico: dlg.Diagnostico,
                        tratamiento: dlg.Tratamiento,
                        observaciones: dlg.Observaciones
                    );

                    // Refrescar grilla/visor
                    CargarFilaDesdeDbPorDni(dni);
                    MostrarDetalle(true);
                }
            }
        }
        //Helper para editar historial por fecha
        private (DateTime fecha, string diagnostico, string tratamiento, string observaciones)? GetHistorialPorFecha(int idPaciente, DateTime fecha)
        {
            using (var cn = new SqlConnection(_cnx))
            using (var cmd = new SqlCommand(@"
        SELECT TOP 1 fechaConsulta, ISNULL(diagnostico,''), ISNULL(tratamiento,''), ISNULL(observaciones,'')
        FROM Historial
        WHERE id_paciente = @idp AND CAST(fechaConsulta AS date) = @fecha;", cn))
            {
                cmd.Parameters.AddWithValue("@idp", idPaciente);
                cmd.Parameters.AddWithValue("@fecha", fecha.Date);
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                        return (rd.GetDateTime(0), rd.GetString(1), rd.GetString(2), rd.GetString(3));
                }
            }
            return null;
        }


        // ---------- Cancelar ----------
        private void btCancelar_Click(object sender, EventArgs e)
        {
            if (_modo == ModoDetalle.Alta)
            {
                SetModo(ModoDetalle.Navegacion);
                return;
            }
            MostrarDetalle(false);
        }

        private void btCerrarDetalle_Click(object sender, EventArgs e)
        {
            MostrarDetalle(false);
        }

        // ---------- Buscar fila en grilla ----------
        private DataGridViewRow BuscarFilaPorDni(string dni)
        {
            string objetivo = new string((dni ?? "").Where(char.IsDigit).ToArray());
            foreach (DataGridViewRow r in dgHistorial.Rows)
            {
                if (r.IsNewRow) continue;
                string d = Convert.ToString(r.Cells["colDni"].Value ?? "");
                d = new string(d.Where(char.IsDigit).ToArray());
                if (d == objetivo) return r;
            }
            return null;
        }

        // ---------- Agregar / actualizar en grilla (sólo UI) ----------
        public void AgregarOActualizarConsulta(string dni, string paciente, DateTime fecha,
                                       string diagnostico, string tratamiento, string observaciones)
        {
            var fila = BuscarFilaPorDni(dni);
            if (fila == null)
            {
                int id = SiguienteId();
                int idx = dgHistorial.Rows.Add();
                fila = dgHistorial.Rows[idx];
                fila.Cells["colIdHistorial"].Value = id;
                fila.Cells["colDni"].Value = dni;
                fila.Cells["colPaciente"].Value = paciente;
            }

            fila.Cells["colFecha"].Value = fecha;
            fila.Cells["colDiagnostico"].Value = diagnostico;
            fila.Cells["colTratamiento"].Value = tratamiento;
            fila.Cells["colObservaciones"].Value = observaciones;

            string prev = Convert.ToString(fila.Cells["colHistorialTexto"].Value ?? "");
            string linea = $"{fecha:dd/MM/yyyy} — Diagnóstico: {diagnostico} | Tratamiento: {tratamiento} | Observación: {observaciones}";
            fila.Cells["colHistorialTexto"].Value = string.IsNullOrWhiteSpace(prev)
                ? linea
                : (linea + Environment.NewLine + prev);
        }

        private int SiguienteId()
        {
            int max = 0;
            foreach (DataGridViewRow r in dgHistorial.Rows)
            {
                if (r.IsNewRow) continue;
                if (int.TryParse(Convert.ToString(r.Cells["colIdHistorial"].Value), out int v))
                    if (v > max) max = v;
            }
            return max + 1;
        }

        // ---------- BD: obtener paciente por DNI ----------
        private (string nombre, string apellido, string dni, int idPaciente)? GetPacienteBasicoPorDni(string dni)
        {
            using (var cn = new SqlConnection(_cnx))
            using (var cmd = new SqlCommand(@"
                SELECT TOP 1 id_paciente, nombre, apellido, CAST(dni AS varchar(20)) AS dni
                FROM Paciente WHERE dni = @dni", cn))
            {
                cmd.Parameters.AddWithValue("@dni", dni);
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return null;
                    return (rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetInt32(0));
                }
            }
        }

        // ---------- BD: insertar/actualizar consulta ----------
        private void GuardarConsultaEnDb(int idPaciente, DateTime fecha, string diagnostico, string tratamiento, string observaciones)
        {
            using (var cn = new SqlConnection(_cnx))
            {
                cn.Open();

                int? idExistente = null;
                using (var cSel = new SqlCommand(@"
                    SELECT TOP 1 id_historial FROM Historial
                    WHERE id_paciente = @idp AND fechaConsulta = @fec", cn))
                {
                    cSel.Parameters.AddWithValue("@idp", idPaciente);
                    cSel.Parameters.AddWithValue("@fec", fecha.Date);
                    var o = cSel.ExecuteScalar();
                    if (o != null && o != DBNull.Value) idExistente = Convert.ToInt32(o);
                }

                if (idExistente.HasValue)
                {
                    using (var cUpd = new SqlCommand(@"
                        UPDATE Historial
                        SET diagnostico = @d, tratamiento = @t, observaciones = @o
                        WHERE id_historial = @id", cn))
                    {
                        cUpd.Parameters.AddWithValue("@d", (object)diagnostico ?? DBNull.Value);
                        cUpd.Parameters.AddWithValue("@t", (object)tratamiento ?? DBNull.Value);
                        cUpd.Parameters.AddWithValue("@o", (object)observaciones ?? DBNull.Value);
                        cUpd.Parameters.AddWithValue("@id", idExistente.Value);
                        cUpd.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (var cIns = new SqlCommand(@"
                        INSERT INTO Historial (id_paciente, fechaConsulta, diagnostico, tratamiento, observaciones)
                        VALUES (@idp, @fec, @d, @t, @o)", cn))
                    {
                        cIns.Parameters.AddWithValue("@idp", idPaciente);
                        cIns.Parameters.AddWithValue("@fec", fecha.Date);
                        cIns.Parameters.AddWithValue("@d", (object)diagnostico ?? DBNull.Value);
                        cIns.Parameters.AddWithValue("@t", (object)tratamiento ?? DBNull.Value);
                        cIns.Parameters.AddWithValue("@o", (object)observaciones ?? DBNull.Value);
                        cIns.ExecuteNonQuery();
                    }
                }
            }
        }

        // ---------- Carga/Refresco desde BD (paciente existente) ----------
        private void CargarFilaDesdeDbPorDni(string dni)
        {
            var pac = GetPacienteBasicoPorDni(dni);
            if (pac == null) return;

            string paciente = $"{pac.Value.nombre} {pac.Value.apellido}";
            int idPac = pac.Value.idPaciente;

            string historialTexto = "";
            using (var cn = new SqlConnection(_cnx))
            using (var cmd = new SqlCommand(@"
        SELECT fechaConsulta, ISNULL(diagnostico,''), ISNULL(tratamiento,''), ISNULL(observaciones,'')
        FROM Historial
        WHERE id_paciente = @idp
          AND (ISNULL(diagnostico,'')<>'' OR ISNULL(tratamiento,'')<>'' OR ISNULL(observaciones,'')<>'')
        ORDER BY fechaConsulta DESC;", cn))
            {
                cmd.Parameters.AddWithValue("@idp", idPac);
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    var sb = new StringBuilder();
                    while (rd.Read())
                    {
                        var f = rd.GetDateTime(0);
                        var d = rd.GetString(1);
                        var t = rd.GetString(2);
                        var o = rd.GetString(3);
                        sb.AppendLine($"{f:dd/MM/yyyy} — Diagnóstico: {d} | Tratamiento: {t} | Observación: {o}");
                    }
                    historialTexto = sb.ToString().TrimEnd();
                }
            }

            // Última fecha con datos (si querés mostrar la más reciente con info; si no hay, queda null)
            DateTime? ultFecha = null;
            using (var cn2 = new SqlConnection(_cnx))
            using (var cmd2 = new SqlCommand(@"
        SELECT MAX(fechaConsulta)
        FROM Historial
        WHERE id_paciente = @idp
          AND (ISNULL(diagnostico,'')<>'' OR ISNULL(tratamiento,'')<>'' OR ISNULL(observaciones,'')<>'')", cn2))
            {
                cmd2.Parameters.AddWithValue("@idp", idPac);
                cn2.Open();
                var o = cmd2.ExecuteScalar();
                if (o != null && o != DBNull.Value) ultFecha = Convert.ToDateTime(o);
            }

            var fila = BuscarFilaPorDni(dni);
            if (fila == null)
            {
                int idx = dgHistorial.Rows.Add();
                fila = dgHistorial.Rows[idx];
                fila.Cells["colIdHistorial"].Value = SiguienteId();
                fila.Cells["colDni"].Value = dni;
                fila.Cells["colPaciente"].Value = paciente;
            }

            fila.Cells["colFecha"].Value = (object)ultFecha ?? DBNull.Value;
            fila.Cells["colDiagnostico"].Value = "";     // el detalle puntual se carga al editar
            fila.Cells["colTratamiento"].Value = "";
            fila.Cells["colObservaciones"].Value = "";
            fila.Cells["colHistorialTexto"].Value = historialTexto;

            CargarDetalleDesdeFila(fila);
            SetModo(ModoDetalle.Navegacion);
            MostrarDetalle(true);
        }

        // Campo para evitar doble clic
        private bool _cerrando = false;

        private void btVolver_Click(object sender, EventArgs e)
        {
            if (_cerrando) return;
            _cerrando = true;
            btVolver.Enabled = false;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // =========================
        //  Exportación a PDF
        // =========================

        private void ExportarDetalleAPdf(DataGridViewRow fila)
        {
            // --- Datos desde la fila seleccionada ---
            string dni = Convert.ToString(fila.Cells["colDni"]?.Value ?? "");
            string paciente = Convert.ToString(fila.Cells["colPaciente"]?.Value ?? "");
            DateTime fecha = TryGetDate(fila.Cells["colFecha"]?.Value) ?? DateTime.Today;

            string diagnostico = Convert.ToString(fila.Cells["colDiagnostico"]?.Value ?? "");
            string tratamiento = Convert.ToString(fila.Cells["colTratamiento"]?.Value ?? "");
            string observaciones = Convert.ToString(fila.Cells["colObservaciones"]?.Value ?? "");

            var pac = GetPacienteBasicoPorDni(new string((dni ?? "").Where(char.IsDigit).ToArray()));
            if (pac != null && string.IsNullOrWhiteSpace(diagnostico) && string.IsNullOrWhiteSpace(tratamiento) && string.IsNullOrWhiteSpace(observaciones))
            {
                var ult = GetUltimaConsultaNoVacia(pac.Value.idPaciente);
                if (ult.HasValue)
                {
                    fecha = ult.Value.fecha;
                    diagnostico = ult.Value.diag;
                    tratamiento = ult.Value.trat;
                    observaciones = ult.Value.obs;
                }
            }

            // Datos del profesional
            var prof = GetProfesionalActual();
            string profesionalNombre = prof.HasValue ? $"{prof.Value.nombre} {prof.Value.apellido}" : "—";
            string profesionalMatricula = prof.HasValue ? prof.Value.matricula.ToString() : "—";

            // --- Ruta de salida ---
            string carpeta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string archivo = $"Historial_{SanitizeFileName(paciente)}_{fecha:yyyyMMdd}.pdf";
            string ruta = Path.Combine(carpeta, archivo);

            // --- Fuentes ---
            PdfFont fTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16f);
            PdfFont fSub = FontFactory.GetFont(FontFactory.HELVETICA, 9f, BaseColor.DARK_GRAY);
            PdfFont fLabel = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11f);
            PdfFont fTxt = FontFactory.GetFont(FontFactory.HELVETICA, 11f);

            // --- Documento ---
            using (var fs = new FileStream(ruta, FileMode.Create))
            {
                var doc = new Document(PageSize.A4, 50, 50, 60, 60);
                PdfWriter.GetInstance(doc, fs);
                doc.AddAuthor("SaludSoft");
                doc.AddTitle("Detalle de Historia Clínica");
                doc.Open();

                // ===== ENCABEZADO =====
                var pTitulo = new PdfParagraph("Detalle de Historia Clínica", fTitulo) { SpacingAfter = 6f };
                doc.Add(pTitulo);

                var pSub = new PdfParagraph($"Impreso: {DateTime.Now:dd/MM/yyyy HH:mm}   ·   DNI: {dni}", fSub)
                { SpacingAfter = 12f };
                doc.Add(pSub);

                // ===== TABLA PRINCIPAL =====
                var tabla = new PdfPTable(2) { WidthPercentage = 100 };
                tabla.SetWidths(new float[] { 30f, 70f });

                AgregarFilaTabla(tabla, "Paciente", paciente, fLabel, fTxt);
                AgregarFilaTabla(tabla, "Fecha de consulta", fecha.ToString("dd/MM/yyyy"), fLabel, fTxt);
                AgregarFilaTabla(tabla, "Profesional", profesionalNombre, fLabel, fTxt);
                AgregarFilaTabla(tabla, "Matrícula", profesionalMatricula, fLabel, fTxt);
                doc.Add(tabla);

                doc.Add(new PdfParagraph("\n"));

                // ===== SECCIONES (solo si tienen contenido) =====
                if (!string.IsNullOrWhiteSpace(diagnostico))
                    AgregarSeccion(doc, "Diagnóstico", diagnostico, fLabel, fTxt);

                if (!string.IsNullOrWhiteSpace(tratamiento))
                    AgregarSeccion(doc, "Tratamiento", tratamiento, fLabel, fTxt);

                if (!string.IsNullOrWhiteSpace(observaciones))
                    AgregarSeccion(doc, "Observaciones", observaciones, fLabel, fTxt);

                if (string.IsNullOrWhiteSpace(diagnostico) &&
                    string.IsNullOrWhiteSpace(tratamiento) &&
                    string.IsNullOrWhiteSpace(observaciones))
                {
                    AgregarSeccion(doc, "Detalle", "Sin registro cargado para la fecha seleccionada.", fLabel, fTxt);
                }
                doc.Close();
            }

            if (MessageBox.Show($"PDF generado:\n{ruta}\n\n¿Deseás abrirlo ahora?",
                "Historial", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try { Process.Start(new ProcessStartInfo { FileName = ruta, UseShellExecute = true }); } catch { }
            }
        }


        // Helpers PDF
        private static void AgregarFilaTabla(PdfPTable t, string label, string value, PdfFont fLabel, PdfFont fTxt)
        {
            var c1 = new PdfPCell(new PdfPhrase(label, fLabel))
            { Border = PdfRect.NO_BORDER, PaddingBottom = 4f };
            var c2 = new PdfPCell(new PdfPhrase(value, fTxt))
            { Border = PdfRect.NO_BORDER, PaddingBottom = 4f };
            t.AddCell(c1);
            t.AddCell(c2);
        }

        private static void AgregarSeccion(Document doc, string titulo, string texto, PdfFont fLabel, PdfFont fTxt)
        {
            var p1 = new PdfParagraph(titulo, fLabel) { SpacingBefore = 2f, SpacingAfter = 3f };
            var p2 = new PdfParagraph(texto, fTxt) { SpacingAfter = 8f };
            doc.Add(p1);
            doc.Add(p2);
        }

        private static string SanitizeFileName(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return "Paciente";
            foreach (var c in Path.GetInvalidFileNameChars()) s = s.Replace(c, '_');
            return s;
        }
        //Obtener datos del medico
        private (string nombre, string apellido, int matricula)? GetProfesionalActual()
        {
            using (var cn = new SqlConnection(_cnx))
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = cn;

                if (ProfesionalId.HasValue)
                {
                    cmd.CommandText = @"SELECT nombre, apellido, matricula 
                                FROM Profesional 
                                WHERE id_profesional = @id";
                    cmd.Parameters.AddWithValue("@id", ProfesionalId.Value);
                }
                else if (!string.IsNullOrWhiteSpace(EmailUsuarioActual))
                {
                    cmd.CommandText = @"SELECT TOP 1 p.nombre, p.apellido, p.matricula
                                FROM Profesional p
                                JOIN Usuario u ON u.id_usuario = p.id_usuario
                                WHERE u.email = @mail";
                    cmd.Parameters.AddWithValue("@mail", EmailUsuarioActual);
                }
                else
                {
                    return null; 
                }

                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return null;
                    return (rd.GetString(0), rd.GetString(1), rd.GetInt32(2));
                }
            }
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            var fila = gbDetalle.Tag as DataGridViewRow;
            if (fila == null)
            {
                MessageBox.Show("Seleccioná un paciente de la lista (columna 'Ver').",
                    "Historial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                ExportarDetalleAPdf(fila);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo generar el PDF.\n\n" + ex.Message,
                    "Historial", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private (DateTime fecha, string diag, string trat, string obs)? GetUltimaConsultaNoVacia(int idPaciente)
        {
            using (var cn = new SqlConnection(_cnx))
            using (var cmd = new SqlCommand(@"
        SELECT TOP 1 fechaConsulta, ISNULL(diagnostico,''), ISNULL(tratamiento,''), ISNULL(observaciones,'')
        FROM Historial
        WHERE id_paciente = @idp
          AND (ISNULL(diagnostico,'')<>'' OR ISNULL(tratamiento,'')<>'' OR ISNULL(observaciones,'')<>'')
        ORDER BY fechaConsulta DESC;", cn))
            {
                cmd.Parameters.AddWithValue("@idp", idPaciente);
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return null;
                    return (rd.GetDateTime(0), rd.GetString(1), rd.GetString(2), rd.GetString(3));
                }
            }
        }

    }
}
