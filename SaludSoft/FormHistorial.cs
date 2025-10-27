using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace SaludSoft
{
    public partial class FormHistorial : Form
    {
        enum ModoDetalle { Navegacion, Alta }
        ModoDetalle _modo = ModoDetalle.Navegacion;

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
            CargarEjemplos();

            //Ajuste automático de historial
            ConfigurarWrapHistorial();
            gbDetalle.Resize += (s, ev) => AjustarWrapHistorial();
            pnlOverlay.Resize += (s, ev) => AjustarWrapHistorial();
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

        // ---------- Buscar por DNI ----------
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
            DataGridViewRow filaMatch = dgHistorial.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow)
                .FirstOrDefault(r =>
                {
                    string dniFila = Convert.ToString(r.Cells["colDni"].Value ?? "");
                    dniFila = new string(dniFila.Where(char.IsDigit).ToArray());
                    return dniFila == dniBuscado;
                });

            if (filaMatch == null)
            {
                MessageBox.Show("No se encontró historial para ese DNI.", "Buscar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgHistorial.ClearSelection();
            filaMatch.Selected = true;
            dgHistorial.CurrentCell = filaMatch.Cells["colDni"];
            dgHistorial.FirstDisplayedScrollingRowIndex = filaMatch.Index;

            CargarDetalleDesdeFila(filaMatch);
            SetModo(ModoDetalle.Navegacion);
            MostrarDetalle(true);
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
            lHistorial.Text = string.IsNullOrWhiteSpace(histRaw)
                ? "—"
                : FormatearHistorial(histRaw);

            gbDetalle.Tag = fila;

            AjustarWrapHistorial();
        }

        // ---------- Helpers ----------
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

        private void ConfigurarWrapHistorial()
        {
            if (lHistorial == null) return;
            lHistorial.AutoSize = false;
            lHistorial.UseCompatibleTextRendering = true;
            lHistorial .AutoEllipsis = false;
            lHistorial.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AjustarWrapHistorial();
        }

        private void AjustarWrapHistorial()
        {
            if (lHistorial == null || gbDetalle == null) return;

            const int margenDerecho = 20;
            int anchoDisponible = Math.Max(100, gbDetalle.ClientSize.Width - lHistorial.Left - margenDerecho);
            lHistorial.Width = anchoDisponible;

            Size medida = TextRenderer.MeasureText(
                (lHistorial.Text ?? "") + " ",
                    lHistorial.Font,
                new Size(anchoDisponible, int.MaxValue),
                TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl
            );

            lHistorial.Height = medida.Height;
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

        // ---------- Agregar ----------
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
            string paciente = Convert.ToString(filaBase.Cells["colPaciente"].Value ?? "");

            using (var dlg = new FormEditarHistorial() { Owner = this, StartPosition = FormStartPosition.CenterParent })
            {
                dlg.InitContext(dni, paciente);

                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    AgregarOActualizarConsulta(
                        dni: dni,
                        paciente: paciente,
                        fecha: dlg.Fecha,
                        diagnostico: dlg.Diagnostico,
                        tratamiento: dlg.Tratamiento,
                        observaciones: dlg.Observaciones
                    );

                    var fila = BuscarFilaPorDni(dni);
                    if (fila != null)
                    {
                        CargarDetalleDesdeFila(fila);
                        MostrarDetalle(true);
                    }
                }
            }
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

        // ---------- Datos de ejemplo ----------
        private void CargarEjemplos()
        {
            AgregarOActualizarConsulta(
                dni: "12345678",
                paciente: "Juan Pérez",
                fecha: new DateTime(2025, 10, 19),
                diagnostico: "Hipertensión arterial - Mejoría",
                tratamiento: "Enalapril 10 mg y Amlodipino 5 mg",
                observaciones: "Presión controlada. Sin síntomas. Continuar esquema."
            );

            AgregarOActualizarConsulta(
                dni: "87654321",
                paciente: "María Gómez",
                fecha: new DateTime(2025, 09, 30),
                diagnostico: "Gastritis aguda",
                tratamiento: "Omeprazol 20 mg cada 24 h",
                observaciones: "Dieta blanda. Revalorar en 15 días."
            );
        }

        // ---------- Buscar fila ----------
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

        // ---------- Agregar o actualizar ----------
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

        private void btVolver_Click(object sender, EventArgs e)
        {
            // Si el formulario fue abierto desde Medico
            if (this.Owner is Medico frmMedico)
            {
                frmMedico.Show();
                frmMedico.Activate();
            }
            else
            {
                // Si no tiene Owner, buscar si hay uno abierto
                var abierto = Application.OpenForms.OfType<Medico>().FirstOrDefault();
                if (abierto != null)
                {
                    abierto.Show();
                    abierto.Activate();
                }
            }

            // Cierra el historial actual
            this.Close();
        }
    }
}
