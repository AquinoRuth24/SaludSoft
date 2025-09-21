using System;
using System.Linq;
using System.Windows.Forms;

namespace SaludSoft.Resources.Models
{
    public partial class FormGestionUsuario : Form
    {
        // Índices de columnas (resueltos una vez)
        private int _colEstado = -1;
        private int _colRol = -1;
        private int _colEspecialidad = -1;

        // Índices de las columnas de acciones
        private int _colEditar = -1;
        private int _colEliminar = -1;

        public FormGestionUsuario()
        {
            InitializeComponent();
        }

        private void FormGestionUsuario_Load(object sender, EventArgs e)
        {
            // --- Ajustes visuales de la grilla (opcionales) ---
            if (dgUsuario != null)
            {
                dgUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgUsuario.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgUsuario.RowHeadersVisible = false;
                dgUsuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgUsuario.MultiSelect = false;
                dgUsuario.ReadOnly = true; // mantenemos lectura en grilla; edición se hace en diálogo
            }

            // --- Combo de Rol ---
            if (cbTipo != null && cbTipo.Items.Count == 0)
            {
                cbTipo.Items.AddRange(new object[] { "Todos", "Paciente", "Médico", "Recepcionista", "Administrador" });
                cbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
                cbTipo.SelectedIndex = 0;
            }

            // --- Combo de Estado ---
            if (cbEstado != null && cbEstado.Items.Count == 0)
            {
                cbEstado.Items.AddRange(new object[] { "Todos", "Activo", "Inactivo" });
                cbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
                cbEstado.SelectedIndex = 0;
            }

            // Disparar filtros al cambiar combos
            if (cbTipo != null) cbTipo.SelectedIndexChanged += (s, ev) => AplicarFiltros();
            if (cbEstado != null) cbEstado.SelectedIndexChanged += (s, ev) => AplicarFiltros();

            // Resolver índices de columnas existentes
            _colEstado = FindColumnIndex(new[] { "Estado", "estado" });
            _colRol = FindColumnIndex(new[] { "Rol", "rol", "Tipo", "tipo_usuario", "Tipo Usuario" });
            _colEspecialidad = FindColumnIndex(new[] { "Especialidad", "especialidad" });

            // Agregar columnas de acciones (Editar/Eliminar) al lado de "Especialidad"
            AgregarColumnasAcciones();

            // Manejar clicks de botones en la grilla
            dgUsuario.CellContentClick -= dgUsuario_CellContentClick;
            dgUsuario.CellContentClick += dgUsuario_CellContentClick;

            // Filtro inicial
            AplicarFiltros();
        }

        // === Agregar Usuario: abrir FormUsuario modal, sin cerrar ni ocultar este form ===
        private void btAgregarUsuario_Click(object sender, EventArgs e)
        {
            // Si ya hay un FormUsuario abierto, traerlo al frente
            var existente = Application.OpenForms.Cast<Form>()
                                 .FirstOrDefault(f => f.GetType().Name == "FormUsuario");
            if (existente != null)
            {
                try
                {
                    existente.WindowState = FormWindowState.Normal;
                    existente.BringToFront();
                    existente.Activate();
                }
                catch { /* ignorar */ }
                return;
            }

            // Crear por reflexión (evita error de referencia directa)
            var tipo = typeof(FormGestionUsuario).Assembly.GetTypes()
                        .FirstOrDefault(t => typeof(Form).IsAssignableFrom(t) && t.Name == "FormUsuario");
            if (tipo == null)
            {
                MessageBox.Show("No se encontró el formulario 'FormUsuario'. Verificá el nombre/clase.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var frm = (Form)Activator.CreateInstance(tipo))
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this); // modal
            }

            // Si guardaste cambios en FormUsuario, acá podés recargar y re-aplicar filtros
            // RecargarUsuariosDesdeBD();
            // AplicarFiltros();
        }

        // === Volver: ocultar este form, abrir/activar Admin; cuando Admin se cierre, cerrar este ===
        private void button1_Click(object sender, EventArgs e)
        {
            var admin = Application.OpenForms.Cast<Form>()
                          .FirstOrDefault(f => f.GetType().Name == "Admin");

            if (admin == null)
            {
                var tipoAdmin = typeof(FormGestionUsuario).Assembly.GetTypes()
                                  .FirstOrDefault(t => typeof(Form).IsAssignableFrom(t) && t.Name == "Admin");
                if (tipoAdmin == null)
                {
                    MessageBox.Show("No se encontró el formulario 'Admin'. Verificá el nombre/clase.",
                                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                admin = (Form)Activator.CreateInstance(tipoAdmin);
                admin.StartPosition = FormStartPosition.CenterScreen;
                admin.FormClosed += (s2, ev2) =>
                {
                    try { this.Close(); } catch { /* ignorar */ }
                };

                this.Hide();
                admin.Show();
            }
            else
            {
                admin.WindowState = FormWindowState.Normal;
                admin.BringToFront();
                admin.Activate();

                admin.FormClosed -= Admin_FormClosed_CerrarEste;
                admin.FormClosed += Admin_FormClosed_CerrarEste;

                this.Hide();
            }
        }

        private void Admin_FormClosed_CerrarEste(object sender, FormClosedEventArgs e)
        {
            try { this.Close(); } catch { /* ignorar */ }
        }

        // ===================== CLICK en botones de acciones =====================
        private void dgUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (e.ColumnIndex == _colEditar)
            {
                EditarFilaConDialogo(e.RowIndex);
            }
            else if (e.ColumnIndex == _colEliminar)
            {
                EliminarFilaConConfirmacion(e.RowIndex);
            }
        }

        // ===================== Filtros =====================
        private void AplicarFiltros()
        {
            if (dgUsuario == null) return;

            if (_colEstado == -1) _colEstado = FindColumnIndex(new[] { "Estado", "estado" });
            if (_colRol == -1) _colRol = FindColumnIndex(new[] { "Rol", "rol", "Tipo", "tipo_usuario", "Tipo Usuario" });
            if (_colEspecialidad == -1) _colEspecialidad = FindColumnIndex(new[] { "Especialidad", "especialidad" });

            string filtroRol = (cbTipo?.SelectedItem?.ToString() ?? "Todos").Trim().ToLowerInvariant();
            string filtroEstado = (cbEstado?.SelectedItem?.ToString() ?? "Todos").Trim().ToLowerInvariant();

            bool filtraRol = _colRol != -1 && filtroRol != "todos";
            bool filtraEstado = _colEstado != -1 && filtroEstado != "todos";

            foreach (DataGridViewRow row in dgUsuario.Rows)
            {
                if (row.IsNewRow) continue;

                bool okRol = true;
                if (filtraRol)
                {
                    string vRol = (row.Cells[_colRol].Value?.ToString() ?? "").Trim().ToLowerInvariant();
                    okRol = vRol == filtroRol;
                }

                bool okEstado = true;
                if (filtraEstado)
                {
                    string vEstado = (row.Cells[_colEstado].Value?.ToString() ?? "").Trim().ToLowerInvariant();
                    okEstado = vEstado == filtroEstado;
                }

                row.Visible = okRol && okEstado;
            }
        }

        // ===================== Helpers de columnas y acciones =====================
        private int FindColumnIndex(string[] posiblesNombres)
        {
            if (dgUsuario == null || dgUsuario.Columns.Count == 0) return -1;

            foreach (DataGridViewColumn col in dgUsuario.Columns)
            {
                string name = (col.Name ?? "").Trim();
                string header = (col.HeaderText ?? "").Trim();
                string prop = (col.DataPropertyName ?? "").Trim();

                foreach (var esperado in posiblesNombres)
                {
                    if (string.Equals(header, esperado, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(name, esperado, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(prop, esperado, StringComparison.OrdinalIgnoreCase))
                        return col.Index;
                }
            }
            return -1;
        }

        private void AgregarColumnasAcciones()
        {
            if (dgUsuario == null) return;

            // Si ya las agregamos antes, no repetir
            if (_colEditar != -1 || _colEliminar != -1)
                return;

            // Ubicar después de "Especialidad"; si no existe, al final
            int insertAt = (_colEspecialidad != -1) ? _colEspecialidad + 1 : dgUsuario.Columns.Count;

            // Columna Editar
            var colEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Acciones",
                Name = "colEditar",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                FlatStyle = FlatStyle.Popup
            };

            // Insertar "Editar"
            dgUsuario.Columns.Insert(insertAt, colEditar);
            _colEditar = insertAt;

            // Columna Eliminar (otra columna botón)
            var colEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "", // vacío porque ya dice "Acciones" en la anterior
                Name = "colEliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                FlatStyle = FlatStyle.Popup
            };

            dgUsuario.Columns.Insert(insertAt + 1, colEliminar);
            _colEliminar = insertAt + 1;

            // Ajustar pesos si usás Fill
            try
            {
                dgUsuario.Columns[_colEditar].FillWeight = 60;
                dgUsuario.Columns[_colEliminar].FillWeight = 70;
            }
            catch { /* ignorar si no aplica */ }
        }

        private void EditarFilaConDialogo(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgUsuario.Rows.Count) return;
            var row = dgUsuario.Rows[rowIndex];
            if (row.IsNewRow) return;

            // Armar nombre visible
            var nombre = SafeCell(row, new[] { "Nombre", "nombre" });
            var apellido = SafeCell(row, new[] { "Apellido", "apellido" });
            string etiqueta = (apellido + " " + nombre).Trim();
            if (string.IsNullOrEmpty(etiqueta))
                etiqueta = SafeCell(row, new[] { "Email", "email" });

            // Confirmación previa
            var rta = MessageBox.Show(
                $"¿Desea editar los datos de:\n\n{etiqueta}?",
                "Confirmar edición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta != DialogResult.Yes) return;

            // Si existe FormUsuario, abrimos esa ventana de edición (modal)
            var tipo = typeof(FormGestionUsuario).Assembly.GetTypes()
                        .FirstOrDefault(t => typeof(Form).IsAssignableFrom(t) && t.Name == "FormUsuario");

            if (tipo != null)
            {
                using (var frm = (Form)Activator.CreateInstance(tipo))
                {
                    frm.StartPosition = FormStartPosition.CenterParent;

                    // Si tu FormUsuario soporta modo edición por propiedades públicas, podrías setearlas acá.
                    // (p.ej., frm.Tag = objetoUsuario; o propiedades específicas si existen)

                    frm.ShowDialog(this);
                }

                // Post-edición: recargar o actualizar fila desde BD si corresponde
                // RecargarUsuariosDesdeBD();
                // AplicarFiltros();
            }
            else
            {
                // Diálogo simple de ejemplo para tocar algunos campos directamente (fallback)
                using (var dlg = new EditInlineDialog(
                    titulo: "Editar usuario",
                    especialidad: SafeCell(row, new[] { "Especialidad", "especialidad" }),
                    telefono: SafeCell(row, new[] { "Teléfono", "telefono", "Tel", "tel" }),
                    estado: SafeCell(row, new[] { "Estado", "estado" })
                ))
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        // Actualizar celdas visibles (persistencia en BD: hacelo en tu capa de datos)
                        SetCell(row, new[] { "Especialidad", "especialidad" }, dlg.Especialidad);
                        SetCell(row, new[] { "Teléfono", "telefono", "Tel", "tel" }, dlg.Telefono);
                        SetCell(row, new[] { "Estado", "estado" }, dlg.Estado?.Trim());
                    }
                }
            }
        }

        private void EliminarFilaConConfirmacion(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgUsuario.Rows.Count) return;
            var row = dgUsuario.Rows[rowIndex];
            if (row.IsNewRow) return;

            // Identificador/nombre para mostrar
            var nombre = SafeCell(row, new[] { "Nombre", "nombre" });
            var apellido = SafeCell(row, new[] { "Apellido", "apellido" });
            string etiqueta = (apellido + " " + nombre).Trim();
            if (string.IsNullOrEmpty(etiqueta))
                etiqueta = SafeCell(row, new[] { "Email", "email" });

            // Estado actual
            string estadoActual = SafeCell(row, new[] { "Estado", "estado" }).Trim();

            if (estadoActual.Equals("Inactivo", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"El usuario ya está Inactivo:\n\n{etiqueta}",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Confirmación previa
            var rta = MessageBox.Show(
                $"¿Confirma dar de BAJA (eliminación lógica) al usuario:\n\n{etiqueta}?\n\n" +
                "Esto lo pasará a 'Inactivo' sin eliminarlo de la base de datos.",
                "Confirmar baja lógica", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (rta != DialogResult.Yes) return;

            try
            {
                // === ELIMINACIÓN LÓGICA 
                // 1) Actualizar visualmente la grilla
                SetCell(row, new[] { "Estado", "estado" }, "Inactivo");

                

                //  Reaplicar filtros por si estás viendo solo Activos:
                AplicarFiltros();

                MessageBox.Show("Usuario marcado como Inactivo (baja lógica).",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo aplicar la baja lógica. " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string SafeCell(DataGridViewRow row, string[] posiblesNombres)
        {
            // Busca una celda por header/name/dataproperty y devuelve su texto
            foreach (DataGridViewColumn col in dgUsuario.Columns)
            {
                string name = (col.Name ?? "");
                string header = (col.HeaderText ?? "");
                string prop = (col.DataPropertyName ?? "");

                if (posiblesNombres.Any(n =>
                        string.Equals(n, name, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(n, header, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(n, prop, StringComparison.OrdinalIgnoreCase)))
                {
                    return row.Cells[col.Index].Value?.ToString() ?? "";
                }
            }
            return "";
        }

        private void SetCell(DataGridViewRow row, string[] posiblesNombres, string value)
        {
            foreach (DataGridViewColumn col in dgUsuario.Columns)
            {
                string name = (col.Name ?? "");
                string header = (col.HeaderText ?? "");
                string prop = (col.DataPropertyName ?? "");

                if (posiblesNombres.Any(n =>
                        string.Equals(n, name, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(n, header, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(n, prop, StringComparison.OrdinalIgnoreCase)))
                {
                    row.Cells[col.Index].Value = value ?? "";
                    return;
                }
            }
        }
    }

    // ===== Diálogo simple inline para edición mínima (fallback si no está FormUsuario) =====
    internal class EditInlineDialog : Form
    {
        private TextBox txtEspecialidad;
        private TextBox txtTelefono;
        private ComboBox cbEstado;
        private Button btnOK;
        private Button btnCancel;

        public string Especialidad => txtEspecialidad.Text;
        public string Telefono => txtTelefono.Text;
        public string Estado => cbEstado.SelectedItem?.ToString();

        public EditInlineDialog(string titulo, string especialidad, string telefono, string estado)
        {
            this.Text = titulo;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(360, 220);

            var lblEsp = new Label { Text = "Especialidad:", Left = 15, Top = 20, Width = 100 };
            txtEspecialidad = new TextBox { Left = 120, Top = 18, Width = 210, Text = especialidad ?? "" };

            var lblTel = new Label { Text = "Teléfono:", Left = 15, Top = 60, Width = 100 };
            txtTelefono = new TextBox { Left = 120, Top = 58, Width = 210, Text = telefono ?? "" };

            var lblEst = new Label { Text = "Estado:", Left = 15, Top = 100, Width = 100 };
            cbEstado = new ComboBox { Left = 120, Top = 98, Width = 210, DropDownStyle = ComboBoxStyle.DropDownList };
            cbEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            if (!string.IsNullOrWhiteSpace(estado))
            {
                var normalized = estado.Trim();
                int idx = cbEstado.Items.Cast<object>()
                              .ToList()
                              .FindIndex(x => string.Equals(x.ToString(), normalized, StringComparison.OrdinalIgnoreCase));
                cbEstado.SelectedIndex = (idx >= 0) ? idx : 0;
            }
            else cbEstado.SelectedIndex = 0;

            btnOK = new Button { Text = "Guardar", Left = 120, Width = 100, Top = 150, DialogResult = DialogResult.OK };
            btnCancel = new Button { Text = "Cancelar", Left = 230, Width = 100, Top = 150, DialogResult = DialogResult.Cancel };

            btnOK.Click += (s, e) =>
            {
                // Confirmación previa de guardado
                var r = MessageBox.Show("¿Confirmar cambios?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes) this.DialogResult = DialogResult.OK; else this.DialogResult = DialogResult.None;
            };

            this.Controls.AddRange(new Control[] { lblEsp, txtEspecialidad, lblTel, txtTelefono, lblEst, cbEstado, btnOK, btnCancel });
            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }
    }
}
