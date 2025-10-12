using SaludSoft.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class FormConsultorio : Form
    {
        // Para saber si estoy editando
        private int? idAsignacionEditando = null;
        private int? idProfesionalConsultorioActual = null;

        public FormConsultorio()
        {
            InitializeComponent();
            CargarConsultorios();
            CargarTotales();

            CBDiasSemanas.Items.AddRange(new string[]{
              "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" });
            CBDiasSemanas.SelectedIndex = 0;

            DGWConsultorios_profesional.CellContentClick += DGWConsultorios_profesional_CellClick;
        }

        // cargar datos 
        private void CargarConsultorios()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"
                 SELECT 
                  c.nroConsultorio, 
                  c.descripcion, 
                 ISNULL(p.nombre + ' ' + p.apellido, '-') AS profesional,
                 ISNULL(e.nombre, '-') AS especialidad,
                 ISNULL(a.diaSemana, '-') AS diaSemana,
                 ISNULL(CONVERT(VARCHAR(5), a.horaInicio, 108), '-') AS horaInicio,
                 ISNULL(CONVERT(VARCHAR(5), a.horaFin, 108), '-') AS horaFin,
                 ISNULL(CONVERT(VARCHAR, pc.vigencia_desde, 103)+ ' - ' + CONVERT(VARCHAR, pc.vigencia_hasta, 103), '-') AS vigencia 
                 FROM Consultorio c 
                 LEFT JOIN Profesional_Consultorio pc ON c.id_consultorio = pc.id_consultorio 
                 LEFT JOIN Profesional p ON pc.id_profesional = p.id_profesional 
                 LEFT JOIN Especialidad e ON p.id_especialidad = e.id_especialidad
                 LEFT JOIN Agenda a ON pc.id_profesional_consultorio = a.id_profesional_consultorio";

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DGWConsultorios_profesional.DataSource = null;
                DGWConsultorios_profesional.Columns.Clear();
                DGWConsultorios_profesional.DataSource = dt;

                DGWConsultorios_profesional.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DGWConsultorios_profesional.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Botón Editar
                if (!DGWConsultorios_profesional.Columns.Contains("Editar"))
                {
                    DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                    btnEditar.HeaderText = "Acciones";
                    btnEditar.Name = "Editar";
                    btnEditar.Text = " Editar";
                    btnEditar.UseColumnTextForButtonValue = true;
                    DGWConsultorios_profesional.Columns.Add(btnEditar);
                }

                // Botón Eliminar
                if (!DGWConsultorios_profesional.Columns.Contains("Eliminar"))
                {
                    DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                    btnEliminar.HeaderText = "Acciones";
                    btnEliminar.Name = "Eliminar";
                    btnEliminar.Text = " Eliminar";
                    btnEliminar.UseColumnTextForButtonValue = true;
                    DGWConsultorios_profesional.Columns.Add(btnEliminar);
                }
            }
        }

        private void CargarCombos()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                // Cargar consultorios
                SqlDataAdapter daCons = new SqlDataAdapter("SELECT id_consultorio, descripcion FROM Consultorio", conexion);
                DataTable dtCons = new DataTable();
                daCons.Fill(dtCons);
                CMBConsultorio.DataSource = dtCons;
                CMBConsultorio.DisplayMember = "descripcion";
                CMBConsultorio.ValueMember = "id_consultorio";
                CMBConsultorio.SelectedIndex = -1;

                // Cargar profesionales
                SqlDataAdapter daProf = new SqlDataAdapter(@"
                   SELECT p.id_profesional, 
                   p.nombre + ' ' + p.apellido + ' - ' + e.nombre AS profesional_especialidad
                   FROM Profesional p
                   INNER JOIN Especialidad e ON p.id_especialidad = e.id_especialidad
                   INNER JOIN EstadoProfesional ep ON p.id_estado = ep.id_estado
                   WHERE ep.descripcion = 'Activo'", conexion);
                DataTable dtProf = new DataTable();
                daProf.Fill(dtProf);

                DataRow fila = dtProf.NewRow();
                fila["id_profesional"] = DBNull.Value;
                fila["profesional_especialidad"] = "Seleccione un profesional";
                dtProf.Rows.InsertAt(fila, 0);

                CMBProfesional.DataSource = dtProf;
                CMBProfesional.DisplayMember = "profesional_especialidad";
                CMBProfesional.ValueMember = "id_profesional";
                CMBProfesional.SelectedIndex = 0;
            }
        }

        private void CargarTotales()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                // Total consultorios
                SqlCommand cmdTotal = new SqlCommand("SELECT COUNT(*) FROM Consultorio", conexion);
                int total = (int)cmdTotal.ExecuteScalar();

                // Asignados (vigentes o futuras)
                SqlCommand cmdAsig = new SqlCommand(@"
                  SELECT COUNT(DISTINCT id_consultorio)
                  FROM Profesional_Consultorio
                  WHERE vigencia_hasta >= CAST(GETDATE() AS DATE)", conexion);
                int asignados = (int)cmdAsig.ExecuteScalar();

                // Disponibles = total - asignados vigentes
                int disponibles = total - asignados;
                if (disponibles < 0) disponibles = 0;

                // Mostrar
                LTotalConsultorios.Text = total.ToString();
                LConsultoriosDisponibles.Text = disponibles.ToString();
                LConsultoriosAsignados.Text = asignados.ToString();
            }
        }

        // Agregar o Editar Profesional_consultorio
        private void BAgregarProfesional_consultorio_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                int nuevoIdProfesionalConsultorio = -1;

                if (idAsignacionEditando == null)
                {
                    // INSERTAR 
                    string query = @"
                     INSERT INTO Profesional_Consultorio (
                     id_profesional, id_consultorio, fecha, vigencia_desde, vigencia_hasta )
                     VALUES (@prof, @cons, GETDATE(), @desde, @hasta);
                     SELECT SCOPE_IDENTITY();"; // obtiene el ID recién creado

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@prof", CMBProfesional.SelectedValue);
                    cmd.Parameters.AddWithValue("@cons", CMBConsultorio.SelectedValue);
                    cmd.Parameters.AddWithValue("@desde", DTPDesde.Value);
                    cmd.Parameters.AddWithValue("@hasta", DTPHasta.Value);

                    MessageBox.Show("Profesional asignado correctamente. Ahora configure su disponibilidad.", "Asignación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // ACTUALIZAR
                    string queryUpdateOnly = @"
                     UPDATE pc
                     SET id_profesional = @prof,
                      vigencia_desde = @desde,
                      vigencia_hasta = @hasta
                     FROM Profesional_Consultorio pc
                     INNER JOIN Consultorio c ON pc.id_consultorio = c.id_consultorio
                     WHERE c.nroConsultorio = @nro;";

                    SqlCommand cmdUpdate = new SqlCommand(queryUpdateOnly, conexion);
                    cmdUpdate.Parameters.AddWithValue("@prof", CMBProfesional.SelectedValue);
                    cmdUpdate.Parameters.AddWithValue("@desde", DTPDesde.Value);
                    cmdUpdate.Parameters.AddWithValue("@hasta", DTPHasta.Value);
                    cmdUpdate.Parameters.AddWithValue("@nro", idAsignacionEditando);

                    cmdUpdate.ExecuteNonQuery();

                    // Obtener el id_profesional_consultorio
                    string querySelectId = @"
                     SELECT pc.id_profesional_consultorio
                     FROM Profesional_Consultorio pc
                     INNER JOIN Consultorio c ON pc.id_consultorio = c.id_consultorio
                     WHERE c.nroConsultorio = @nro;";

                    SqlCommand cmdSelect = new SqlCommand(querySelectId, conexion);
                    cmdSelect.Parameters.AddWithValue("@nro", idAsignacionEditando);

                    object result = cmdSelect.ExecuteScalar();
                    if (result != null)
                    {
                        nuevoIdProfesionalConsultorio = Convert.ToInt32(result);
                    }

                    MessageBox.Show("Asignación actualizada correctamente.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (nuevoIdProfesionalConsultorio > 0)
                {
                    // Almacenar el ID de la asignación para usarlo al guardar la disponibilidad.
                    idProfesionalConsultorioActual = nuevoIdProfesionalConsultorio;

                    // Ocultar el panel de asignación y mostrar el de disponibilidad.
                    GBAsignarProfesional.Visible = false;
                    GBDisponibilidad.Visible = true;
                }
            }

            // Resetear interfaz
            idAsignacionEditando = null;
            BAgregarProfesional_consultorio.Text = "Agregar";
            GBAsignarProfesional.Text = "Asignar consultorio";
            CMBConsultorio.Enabled = true;
            CargarConsultorios();
            CargarTotales();
        }

        // agregar consultorio
        private void BGuardarConsultorio_Click(object sender, EventArgs e)
        {
            // Validar que los campos no esteen vacios
            if (string.IsNullOrWhiteSpace(TBNroConsultorio.Text) || string.IsNullOrWhiteSpace(TBDescripcion.Text))
            {
                MessageBox.Show("Por favor complete todos los campos.", "Campos obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el número de consultorio sea nuevo
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Consultorio WHERE nroConsultorio = @nro", conexion);
                checkCmd.Parameters.AddWithValue("@nro", TBNroConsultorio.Text.Trim());
                int existe = (int)checkCmd.ExecuteScalar();

                if (existe > 0)
                {
                    MessageBox.Show("Ya existe un consultorio con ese número.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Si no existe lo inserta
                string query = "INSERT INTO Consultorio (nroConsultorio, descripcion) VALUES (@nro, @desc)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@nro", TBNroConsultorio.Text.Trim());
                cmd.Parameters.AddWithValue("@desc", TBDescripcion.Text.Trim());
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Consultorio agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TBNroConsultorio.Clear();
            TBDescripcion.Clear();
            CargarConsultorios();
            CargarTotales();
            GBAgregarConsultorio.Visible = false;
        }

        // botones 
        private void BVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BAsignarProfesional_Click_1(object sender, EventArgs e)
        {
            CargarCombos();
            GBAsignarProfesional.Text = "Asignar consultorio";
            BAgregarProfesional_consultorio.Text = "Agregar";
            idAsignacionEditando = null;
            CMBConsultorio.Enabled = true;
            GBAsignarProfesional.Visible = true;
        }
        private void BCancelarConsultorio_Click(object sender, EventArgs e)
        {
            GBAgregarConsultorio.Visible = false;
        }
        private void BCancelarProfesional_consultorio_Click(object sender, EventArgs e)
        {
            idAsignacionEditando = null;
            BAgregarProfesional_consultorio.Text = "Agregar";
            GBAsignarProfesional.Text = "Asignar consultorio";
            CMBConsultorio.Enabled = true;
            GBAsignarProfesional.Visible = false;
        }
        private void BAgregarConsultorio_Click(object sender, EventArgs e)
        {
            GBAgregarConsultorio.Visible = true;
        }

        private void DGWConsultorios_profesional_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Botón Editar
                if (DGWConsultorios_profesional.Columns[e.ColumnIndex].Name == "Editar")
                {
                    string nroCons = DGWConsultorios_profesional.Rows[e.RowIndex].Cells["nroConsultorio"].Value.ToString();
                    string profesional = DGWConsultorios_profesional.Rows[e.RowIndex].Cells["profesional"].Value.ToString();

                    if (profesional != "-")
                    {
                        // Guardar nro consultorio en edición
                        idAsignacionEditando = Convert.ToInt32(nroCons);

                        // Cargar combos
                        CargarCombos();
                        GBAsignarProfesional.Visible = true;
                        GBAsignarProfesional.Text = "Editar asignación";
                        BAgregarProfesional_consultorio.Text = "Actualizar";

                        // Seleccionar consultorio (bloquearlo en edición)
                        CMBConsultorio.SelectedIndex = CMBConsultorio.FindStringExact(
                            DGWConsultorios_profesional.Rows[e.RowIndex].Cells["descripcion"].Value.ToString()
                        );
                        CMBConsultorio.Enabled = false;

                        // Seleccionar profesional
                        CMBProfesional.SelectedIndex = CMBProfesional.FindString(profesional);

                        // Fechas
                        string vigencia = DGWConsultorios_profesional.Rows[e.RowIndex].Cells["vigencia"].Value.ToString();
                        if (vigencia != "-")
                        {
                            string[] fechas = vigencia.Split('-');
                            DTPDesde.Value = DateTime.Parse(fechas[0].Trim());
                            DTPHasta.Value = DateTime.Parse(fechas[1].Trim());
                        }
                    }
                }

                // Botón Eliminar
                if (DGWConsultorios_profesional.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    DialogResult result =
                        MessageBox.Show("¿Seguro que desea eliminar esta asignación?", "Confirmación",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning); if (result == DialogResult.Yes)
                    {
                        using (SqlConnection conexion = Conexion.GetConnection())
                        {
                            conexion.Open(); string query = @" 
                           DELETE FROM Profesional_Consultorio 
                           WHERE id_consultorio = ( SELECT TOP 1 id_consultorio FROM Consultorio WHERE nroConsultorio = @nro)";
                            SqlCommand cmd = new SqlCommand(query, conexion);
                            cmd.Parameters.AddWithValue
                                  ("@nro", DGWConsultorios_profesional.Rows[e.RowIndex].Cells["nroConsultorio"].Value);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Asignación eliminada correctamente.");
                        CargarConsultorios();
                        CargarTotales();
                    }
                }
            }
        }

        // filtro de busqueda
        private void BBuscar_Click(object sender, EventArgs e)
        {
            if (DGWConsultorios_profesional.DataSource != null)
            {
                DataTable dt = DGWConsultorios_profesional.DataSource as DataTable;
                if (dt != null)
                {
                    string filtro = TBBuscar.Text.Trim();

                    if (string.IsNullOrEmpty(filtro))
                    {
                        dt.DefaultView.RowFilter = "";
                    }
                    else
                    {
                        dt.DefaultView.RowFilter = string.Format(
                            "Convert(nroConsultorio, 'System.String') LIKE '%{0}%' OR " +
                            "descripcion LIKE '%{0}%' OR " +
                            "profesional LIKE '%{0}%' OR " +
                            "especialidad LIKE '%{0}%'",
                            filtro.Replace("'", "''")
                        );
                    }
                }
            }
        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            TBBuscar.Clear();
            if (DGWConsultorios_profesional.DataSource != null)
            {
                (DGWConsultorios_profesional.DataSource as DataTable).DefaultView.RowFilter = "";
            }
        }

        // validaciones 
        private void TBNroConsultorio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y tecla de borrado
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BGuardarDisponibe_Click(object sender, EventArgs e)
        {
            // Validar que la asignación exista
            if (idProfesionalConsultorioActual == null || idProfesionalConsultorioActual <= 0)
            {
                MessageBox.Show("Primero debe asignar un profesional a un consultorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Ocultar el GroupBox de disponibilidad si no hay asignación
                GBDisponibilidad.Visible = false;
                return;
            }

            //Validar campos de disponibilidad
            if (CBDiasSemanas.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un día de la semana.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //intervalo fijo de 30 minutos
            int intervalo = 30;

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                string query = @"
                 INSERT INTO Agenda (id_usuario, id_profesional_consultorio, diaSemana, horaInicio, horaFin, intervalo)
                 VALUES (@usuario, @profCons, @dia, @inicio, @fin, @intervalo)";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@usuario", SesionActual.IdUsuario);
                cmd.Parameters.AddWithValue("@profCons", idProfesionalConsultorioActual);
                cmd.Parameters.AddWithValue("@dia", CBDiasSemanas.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@inicio", DTPHoraInicio.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@fin", DTPHoraFin.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@intervalo", intervalo);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Disponibilidad agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Limpiar los campos de disponibilidad después de guardar.
            CBDiasSemanas.SelectedIndex = 0;
            DTPHoraInicio.Value = DateTime.Now;
            DTPHoraFin.Value = DateTime.Now;

            idProfesionalConsultorioActual = null;
            GBDisponibilidad.Visible = false;
        }

        private void BCancearDisponibilidad_Click(object sender, EventArgs e)
        {
            idProfesionalConsultorioActual = null;
            GBDisponibilidad.Visible = false;
        }
    }
}
