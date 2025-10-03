using System;
using System.Linq;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class FormHistorial : Form
    {
        public FormHistorial()
        {
            InitializeComponent();

            // Aseguro eventos por código
            this.Load += FormHistorial_Load;
            dgHistorial.CellContentClick += dgHistorial_CellContentClick;

            if (btCancelar != null) btCancelar.Click += btCancelar_Click;
            if (btVolver != null) btVolver.Click += btVolver_Click_1;
        }

        private void FormHistorial_Load(object sender, EventArgs e)
        {
            // Grilla
            dgHistorial.MultiSelect = false;
            dgHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgHistorial.AutoGenerateColumns = false;

            // Asegurar que la columna botón exista y tenga texto
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

            // Ocultar overlay/detalle al iniciar
            MostrarDetalle(false);

            // --- FILAS DE EJEMPLO (sin BD) ---
            dgHistorial.Rows.Clear();
            // Asegúrate de tener estas columnas: colIdHistorial, colDni, colPaciente, colDiagnostico, colTratamiento
            dgHistorial.Rows.Add(1, "37890123", "Gómez, Laura", "Resfrío común", "Reposo e hidratación", null);
            dgHistorial.Rows.Add(2, "40999888", "Pérez, Juan", "HTA controlada", "IECA", null);
        }

        // Click en el botón "Ver" de la grilla
        private void dgHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgHistorial.Columns[e.ColumnIndex].Name == "colVerHistorial")
            {
                var fila = dgHistorial.Rows[e.RowIndex];
                CargarDetalleDesdeFila(fila);
                MostrarDetalle(true);
            }
        }

        private void CargarDetalleDesdeFila(DataGridViewRow fila)
        {
            // Leer valores de la fila con los nombres EXACTOS de tus columnas
            string paciente = Convert.ToString(fila.Cells["colPaciente"]?.Value ?? "");
            string diagnostico = Convert.ToString(fila.Cells["colDiagnostico"]?.Value ?? "");
            string tratamiento = Convert.ToString(fila.Cells["colTratamiento"]?.Value ?? "");
            // Sin columna de observaciones en la grilla -> lo dejamos vacío
            string observ = "";

            // Cargar controles del detalle con los nombres EXACTOS de tu diseñador
            if (lValorPaciente != null)
                lValorPaciente.Text = string.IsNullOrWhiteSpace(paciente) ? "--" : paciente;

            if (dateTimePicker1 != null)
            {
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "dd/MM/yyyy";
                dateTimePicker1.Value = DateTime.Today;
            }

            if (tbDiagnostico != null) tbDiagnostico.Text = diagnostico;
            if (tbTrat != null) tbTrat.Text = tratamiento;
            if (tbObserv != null) tbObserv.Text = observ;

            // Si querés guardar el id (por si luego guardás): lo pongo en Tag
            if (gbDetalle != null)
                gbDetalle.Tag = fila.Cells["colIdHistorial"]?.Value;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            // Limpieza ligera
            if (tbDiagnostico != null) tbDiagnostico.Clear();
            if (tbTrat != null) tbTrat.Clear();
            if (tbObserv != null) tbObserv.Clear();
            if (lValorPaciente != null) lValorPaciente.Text = "--";

            MostrarDetalle(false);
        }

        private void MostrarDetalle(bool mostrar)
        {
            // Tenés un overlay con un groupbox adentro
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
        }

        // Tu mismo volver
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
