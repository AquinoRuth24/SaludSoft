using System;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class FormEditarHistorial : Form
    {
        private string _dni = "";
        private string _paciente = "";

        // --- Salida del diálogo ---
        public DateTime Fecha => dateTimePicker1.Value.Date;
        public string Diagnostico => tbDiag.Text.Trim();
        public string Tratamiento => tbTrat.Text.Trim();
        public string Observaciones => tbObserv.Text.Trim();

        public FormEditarHistorial()
        {
            InitializeComponent();

            // Ventana modal prolija
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            ShowInTaskbar = false;

            // Teclas rápidas
            KeyPreview = true;
            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape) btCancelar_Click(s, e);
                if (e.KeyCode == Keys.Enter) btGuardar_Click(s, e);
            };

            // Botones
            AcceptButton = btGuardar;
            CancelButton = btCancelar;

            btGuardar.Click += btGuardar_Click;
            btCancelar.Click += btCancelar_Click;
            btnVolver.Click += btnVolver_Click;

            // Cierre con la X => Cancel
            FormClosing += (s, e) =>
            {
                if (DialogResult == DialogResult.None) DialogResult = DialogResult.Cancel;
            };

            // Load
            Load += (s, e) =>
            {
                lTitulo.Text = "Editar consulta";
                lPaciente.Text = "Paciente:";
                lValorPaciente.Text = string.IsNullOrWhiteSpace(_paciente) && string.IsNullOrWhiteSpace(_dni)
                    ? "—"
                    : $"{_paciente}  |  DNI: {_dni}";

                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "dd/MM/yyyy";
                if (dateTimePicker1.Value == default) dateTimePicker1.Value = DateTime.Today;

                tbDiag.Focus();
            };
        }

        // Llamalo APENAS crees el diálogo desde FormHistorial
        public void InitContext(string dni, string paciente)
        {
            _dni = dni ?? "";
            _paciente = paciente ?? "";
        }

        // --- Guardar ---
        private void btGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbDiag.Text))
            {
                MessageBox.Show("Completá el Diagnóstico.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDiag.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        // --- Cancelar / Volver ---
        private void btCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            VolverAlPadreYCerrar();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            VolverAlPadreYCerrar();
        }

        private void VolverAlPadreYCerrar()
        {
            if (Owner != null)
            {
                try { Owner.Activate(); Owner.BringToFront(); } catch { }
            }
            Close();
        }

        // (Si el diseñador dejó algún handler vacío, puede quedar así)
        private void lObserv_Click(object sender, EventArgs e) { }
    }
}
