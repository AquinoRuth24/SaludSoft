using System;
using System.Linq;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class FormHistorial : Form
    {
        enum ModoDetalle { Navegacion, Alta }
        ModoDetalle _modo = ModoDetalle.Navegacion;

        public FormHistorial()
        {
            InitializeComponent();

            this.Load += FormHistorial_Load;

            dgHistorial.CellContentClick += dgHistorial_CellContentClick;

            btAgregar.Click += btAgregar_Click;
            btCancelar.Click += btCancelar_Click;
            btCerrarDetalle.Click += btCerrarDetalle_Click;

            btLupaBuscar.Click += (s, e) => EjecutarBusquedaDni();
            tbBuscarDni.MaxLength = 8;
            tbBuscarDni.ImeMode = ImeMode.Disable;

            tbBuscarDni.KeyDown += (s, e) =>
            {
                var tb = (TextBox)s;

                // ENTER: valida y ejecuta búsqueda
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
                    tb.Text = dni;                       // normaliza por si habían puntos/espacios
                    tb.SelectionStart = tb.Text.Length;  // cursor al final
                    EjecutarBusquedaDni();
                    return;
                }

                // Permitir navegación/edición básica
                if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Tab ||
                    e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Home || e.KeyCode == Keys.End)
                    return;

                // Ctrl+C / Ctrl+X (permitidos)
                if ((e.Control || e.Modifiers.HasFlag(Keys.Control)) &&
                    (e.KeyCode == Keys.C || e.KeyCode == Keys.X))
                    return;

                // Ctrl+V: pegar solo dígitos y recortar a 8
                if ((e.Control || e.Modifiers.HasFlag(Keys.Control)) && e.KeyCode == Keys.V)
                {
                    e.SuppressKeyPress = true;
                    string clip = Clipboard.GetText() ?? "";
                    string soloDigitos = new string(clip.Where(char.IsDigit).ToArray());

                    int espacio = 8 - (tb.TextLength - tb.SelectionLength);
                    if (espacio <= 0) return;

                    if (soloDigitos.Length > espacio) soloDigitos = soloDigitos.Substring(0, espacio);

                    int selStart = tb.SelectionStart;
                    tb.Text = tb.Text.Remove(selStart, tb.SelectionLength).Insert(selStart, soloDigitos);
                    tb.SelectionStart = selStart + soloDigitos.Length;
                    return;
                }

                // Aceptar solo números (fila superior y numpad); bloquear lo demás
                bool esNumeroFila = e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && !e.Shift;
                bool esNumeroPad = e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9;

                if (esNumeroFila || esNumeroPad)
                {
                    // respetar el límite de 8 considerando selección
                    int actuales = tb.TextLength - tb.SelectionLength;
                    if (actuales >= 8) e.SuppressKeyPress = true;
                    return;
                }

                e.SuppressKeyPress = true; // bloquea cualquier otra tecla
            };


        }

        private void FormHistorial_Load(object sender, EventArgs e)
        {
            dgHistorial.MultiSelect = false;
            dgHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgHistorial.AutoGenerateColumns = false;

            AsegurarColumnas();

            MostrarDetalle(false);
            SetModo(ModoDetalle.Navegacion);

            // Demo
            dgHistorial.Rows.Clear();
            dgHistorial.Rows.Add(1, "37890123", "Gómez, Laura", new DateTime(2025, 10, 1), "Resfrío común", "Reposo", "—", null);
            dgHistorial.Rows.Add(2, "40999888", "Pérez, Juan", new DateTime(2025, 10, 2), "HTA controlada", "IECA", "—", null);
            dgHistorial.Rows.Add(3, "37890123", "Gómez, Laura", new DateTime(2025, 10, 3), "Control", "Reposo activo", "—", null);

            // Columnas del ListView (si no las agregaste en diseñador)
            if (lvResumen.Columns.Count == 0)
            {
                lvResumen.View = View.Details;
                lvResumen.FullRowSelect = true;
                lvResumen.HideSelection = false;
                lvResumen.Columns.Add("Fecha", 120);
                lvResumen.Columns.Add("Diagnóstico", 220);
                lvResumen.Columns.Add("Tratamiento", 180);
                lvResumen.Columns.Add("Observaciones", 220);
            }
        }

        private void AsegurarColumnas()
        {
            // colFecha (oculta si no la tenés)
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

            // colObservaciones (oculta)
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

            // Botón Ver
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
                MessageBox.Show("Ingresá un DNI para buscar.", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("No se encontró historial para ese DNI.", "Buscar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // ---------- Ver (lectura) ----------
        private void dgHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgHistorial.Columns[e.ColumnIndex].Name != "colVerHistorial") return;

            var fila = dgHistorial.Rows[e.RowIndex];
            CargarDetalleDesdeFila(fila);
            SetModo(ModoDetalle.Navegacion);
            MostrarDetalle(true);
        }

        private void CargarDetalleDesdeFila(DataGridViewRow fila)
        {
            string paciente = Convert.ToString(fila.Cells["colPaciente"]?.Value ?? "");
            string diagnostico = Convert.ToString(fila.Cells["colDiagnostico"]?.Value ?? "");
            string tratamiento = Convert.ToString(fila.Cells["colTratamiento"]?.Value ?? "");
            string observaciones = Convert.ToString(fila.Cells["colObservaciones"]?.Value ?? "");
            DateTime fecha = TryGetDate(fila.Cells["colFecha"]?.Value) ?? DateTime.Today;

            lValorPaciente.Text = string.IsNullOrWhiteSpace(paciente) ? "--" : paciente;

            lbFechaValor.Text = fecha.ToString("dd/MM/yyyy");
            dateTimePicker1.Value = fecha;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            lbDiagValor.Text = string.IsNullOrWhiteSpace(diagnostico) ? "—" : diagnostico;
            lbTratValor.Text = string.IsNullOrWhiteSpace(tratamiento) ? "—" : tratamiento;
            lbObsValor.Text = string.IsNullOrWhiteSpace(observaciones) ? "—" : observaciones;

            tbDiagnostico.Text = diagnostico;
            tbTrat.Text = tratamiento;
            tbObserv.Text = observaciones;

            gbDetalle.Tag = fila;

            string dni = Convert.ToString(fila.Cells["colDni"]?.Value ?? "");
            PoblarResumenPorDni(dni);
        }

        private DateTime? TryGetDate(object v)
        {
            if (v == null) return null;
            if (v is DateTime dt) return dt;
            if (DateTime.TryParse(Convert.ToString(v), out var parsed)) return parsed;
            return null;
        }

        private void PoblarResumenPorDni(string dni)
        {
            lvResumen.BeginUpdate();
            lvResumen.Items.Clear();

            var filas = dgHistorial.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow && Convert.ToString(r.Cells["colDni"].Value ?? "") == dni)
                .Select(r => new
                {
                    Fecha = TryGetDate(r.Cells["colFecha"].Value) ?? DateTime.MinValue,
                    Diagnostico = Convert.ToString(r.Cells["colDiagnostico"].Value ?? ""),
                    Tratamiento = Convert.ToString(r.Cells["colTratamiento"].Value ?? ""),
                    Observaciones = Convert.ToString(r.Cells["colObservaciones"].Value ?? "")
                })
                .OrderBy(x => x.Fecha)
                .ToList();

            foreach (var x in filas)
            {
                var item = new ListViewItem(x.Fecha == DateTime.MinValue ? "" : x.Fecha.ToString("dd/MM/yyyy"));
                item.SubItems.Add(string.IsNullOrWhiteSpace(x.Diagnostico) ? "—" : x.Diagnostico);
                item.SubItems.Add(string.IsNullOrWhiteSpace(x.Tratamiento) ? "—" : x.Tratamiento);
                item.SubItems.Add(string.IsNullOrWhiteSpace(x.Observaciones) ? "—" : x.Observaciones);
                lvResumen.Items.Add(item);
            }

            lvResumen.EndUpdate();
        }

        // ---------- Mostrar/Ocultar detalle ----------
        private void MostrarDetalle(bool mostrar)
        {
            if (pnlOverlay != null)
            {
                pnlOverlay.Visible = mostrar;
                if (mostrar) pnlOverlay.BringToFront();
            }
            if (gbDetalle != null)
            {
                gbDetalle.Visible = mostrar;
                if (mostrar) gbDetalle.BringToFront();
            }

            if (mostrar && _modo == ModoDetalle.Navegacion)
                this.ActiveControl = btAgregar;
        }

        private void SetModo(ModoDetalle modo)
        {
            _modo = modo;
            bool editable = (modo == ModoDetalle.Alta);

            lbFechaValor.Visible = !editable;
            dateTimePicker1.Visible = editable;

            tbDiagnostico.ReadOnly = !editable;
            tbTrat.ReadOnly = !editable;
            tbObserv.ReadOnly = !editable;

            lbDiagValor.Visible = !editable;
            lbTratValor.Visible = !editable;
            lbObsValor.Visible = !editable;

            tbDiagnostico.Visible = editable;
            tbTrat.Visible = editable;
            tbObserv.Visible = editable;

            btAgregar.Text = editable ? "Guardar" : "Agregar";

            if (editable)
            {
                tbDiagnostico.Clear();
                tbTrat.Clear();
                tbObserv.Clear();
                dateTimePicker1.Value = DateTime.Today;
                tbDiagnostico.Focus();
            }
            else
            {
                this.ActiveControl = btAgregar;
            }
        }

        // ---------- Agregar / Guardar ----------
        private void btAgregar_Click(object sender, EventArgs e)
        {
            if (_modo != ModoDetalle.Alta)
            {
                SetModo(ModoDetalle.Alta);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbDiagnostico.Text))
            {
                MessageBox.Show("Completá el Diagnóstico.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDiagnostico.Focus();
                return;
            }

            var filaBase = gbDetalle.Tag as DataGridViewRow;
            if (filaBase == null)
            {
                MessageBox.Show("No hay una fila seleccionada.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dni = Convert.ToString(filaBase.Cells["colDni"].Value ?? "");
            string paciente = Convert.ToString(filaBase.Cells["colPaciente"].Value ?? "");

            int maxId = 0;
            foreach (DataGridViewRow r in dgHistorial.Rows)
            {
                if (r.IsNewRow) continue;
                if (int.TryParse(Convert.ToString(r.Cells["colIdHistorial"].Value), out int id))
                    if (id > maxId) maxId = id;
            }
            int nuevoId = maxId + 1;

            int idx = dgHistorial.Rows.Add();
            var row = dgHistorial.Rows[idx];
            row.Cells["colIdHistorial"].Value = nuevoId;
            row.Cells["colDni"].Value = dni;
            row.Cells["colPaciente"].Value = paciente;
            row.Cells["colFecha"].Value = dateTimePicker1.Value.Date;
            row.Cells["colDiagnostico"].Value = tbDiagnostico.Text.Trim();
            row.Cells["colTratamiento"].Value = tbTrat.Text.Trim();
            row.Cells["colObservaciones"].Value = tbObserv.Text.Trim();

            // Refrescar vista y quedarse en lectura para ver el historial completo
            CargarDetalleDesdeFila(row);
            SetModo(ModoDetalle.Navegacion);

            // Si querés cerrar el panel después de guardar, descomentá:
            // MostrarDetalle(false);
        }

        // ---------- Cancelar / Cerrar ----------
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

        // ---------- Volver ----------
        private void btVolver_Click_1(object sender, EventArgs e)
        {
            if (this.Owner is Medico m) { m.Show(); m.Activate(); }
            else
            {
                var medico = Application.OpenForms.OfType<Medico>().FirstOrDefault();
                if (medico != null) { medico.Show(); medico.Activate(); }
            }
            this.Close();
        }
    }
}
