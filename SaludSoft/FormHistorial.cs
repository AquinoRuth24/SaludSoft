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

            // Eventos (una sola vez)
            this.Load += FormHistorial_Load;
            dgHistorial.CellContentClick += dgHistorial_CellContentClick;
            btCancelar.Click += btCancelar_Click;
            btAgregar.Click += btAgregar_Click;
        }

        private void FormHistorial_Load(object sender, EventArgs e)
        {
            dgHistorial.MultiSelect = false;
            dgHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgHistorial.AutoGenerateColumns = false;

            // Asegurar botón "Ver"
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

            // Oculto el detalle de inicio
            MostrarDetalle(false);

            // Datos de prueba (sin BD)
            dgHistorial.Rows.Clear();
            dgHistorial.Rows.Add(1, "37890123", "Gómez, Laura", "Resfrío común", "Reposo", null);
            dgHistorial.Rows.Add(2, "40999888", "Pérez, Juan", "HTA controlada", "IECA", null);
        }

        // === Click en la columna botón "Ver Historial" ===
        private void dgHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgHistorial.Columns[e.ColumnIndex].Name == "colVerHistorial")
            {
                var fila = dgHistorial.Rows[e.RowIndex];
                CargarDetalleDesdeFila(fila);
                MostrarDetalle(true);
                SetModo(ModoDetalle.Navegacion); // sin cursor y solo lectura
            }
        }

        // === Cargar datos al panel detalle desde la fila seleccionada ===
        private void CargarDetalleDesdeFila(DataGridViewRow fila)
        {
            string paciente = Convert.ToString(fila.Cells["colPaciente"]?.Value ?? "");
            string diagnostico = Convert.ToString(fila.Cells["colDiagnostico"]?.Value ?? "");
            string tratamiento = Convert.ToString(fila.Cells["colTratamiento"]?.Value ?? "");

            lValorPaciente.Text = string.IsNullOrWhiteSpace(paciente) ? "--" : paciente;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Value = DateTime.Today;

            tbDiagnostico.Text = diagnostico;
            tbTrat.Text = tratamiento;
            tbObserv.Text = string.Empty;

            gbDetalle.Tag = fila.Cells["colIdHistorial"]?.Value; // opcional
        }

        // === Mostrar / ocultar overlay + detalle ===
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
                this.ActiveControl = btAgregar; // evita cursor en textbox
        }

        // === Modo de la UI (navegación vs alta) ===
        private void SetModo(ModoDetalle modo)
        {
            _modo = modo;
            bool editable = (modo == ModoDetalle.Alta);

            tbDiagnostico.ReadOnly = !editable;
            tbTrat.ReadOnly = !editable;
            tbObserv.ReadOnly = !editable;

            tbDiagnostico.TabStop = editable;
            tbTrat.TabStop = editable;
            tbObserv.TabStop = editable;

            btAgregar.Text = editable ? "Guardar" : "Agregar";

            if (!editable)
            {
                // sacar foco de los textbox
                this.ActiveControl = btAgregar;
            }
            else
            {
                // limpiar para alta
                tbDiagnostico.Clear();
                tbTrat.Clear();
                tbObserv.Clear();
                dateTimePicker1.Value = DateTime.Today;
                tbDiagnostico.Focus();
            }
        }

        // === Click en Agregar / Guardar ===
        private void btAgregar_Click(object sender, EventArgs e)
        {
            if (_modo != ModoDetalle.Alta)
            {
                SetModo(ModoDetalle.Alta);
                return;
            }

            // Guardar en grilla (sin BD)
            if (string.IsNullOrWhiteSpace(tbDiagnostico.Text))
            {
                MessageBox.Show("Completá el Diagnóstico.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDiagnostico.Focus();
                return;
            }

            // Nuevo Id = max+1
            int maxId = 0;
            foreach (DataGridViewRow r in dgHistorial.Rows)
            {
                if (r.IsNewRow) continue;
                if (int.TryParse(Convert.ToString(r.Cells["colIdHistorial"].Value), out int id))
                    if (id > maxId) maxId = id;
            }
            int nuevoId = maxId + 1;

            // DNI y Paciente del seleccionado (si hay)
            string dni = "";
            string paciente = lValorPaciente.Text;
            if (dgHistorial.CurrentRow != null && !dgHistorial.CurrentRow.IsNewRow)
                dni = Convert.ToString(dgHistorial.CurrentRow.Cells["colDni"].Value ?? "");

            int idx = dgHistorial.Rows.Add();
            var row = dgHistorial.Rows[idx];
            row.Cells["colIdHistorial"].Value = nuevoId;
            row.Cells["colDni"].Value = dni;
            row.Cells["colPaciente"].Value = paciente;
            row.Cells["colDiagnostico"].Value = tbDiagnostico.Text.Trim();
            row.Cells["colTratamiento"].Value = tbTrat.Text.Trim();

            SetModo(ModoDetalle.Navegacion);
            MessageBox.Show("Historial agregado (en memoria).", "OK",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // === Cancelar ===
        private void btCancelar_Click(object sender, EventArgs e)
        {
            if (_modo == ModoDetalle.Alta)
            {
                SetModo(ModoDetalle.Navegacion);
                return;
            }
            MostrarDetalle(false);
        }

        // === Volver (tu mismo handler existente) ===
        private void btVolver_Click_1(object sender, EventArgs e)
        {
            if (this.Owner is Medico m)
            {
                m.Show();
                m.Activate();
            }
            else
            {
                var medico = Application.OpenForms.OfType<Medico>().FirstOrDefault();
                if (medico != null) { medico.Show(); medico.Activate(); }
            }
            this.Close();
        }
    }
}
