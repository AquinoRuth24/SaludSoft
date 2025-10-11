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
        // Campos de control
        private int? idAgendaEditando = null;
        private bool esEdicion = false;

        public FormConsultorio()
        {
            InitializeComponent();
            CargarProfesionalConsultorio();
            CargarDisponibilidades();
            CargarTotales();
            CargarCombos();

            DGWConsultorios_profesional.CellClick += DGWConsultorios_profesional_CellClick;

            // Configurar pickers de hora
            DTPHoraInicio.Format = DateTimePickerFormat.Time;
            DTPHoraInicio.ShowUpDown = true;
            DPTHoraFin.Format = DateTimePickerFormat.Time;
            DPTHoraFin.ShowUpDown = true;

            // Días de la semana
            CBDiaSemana.Items.AddRange(new string[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes" });
        }
        // Ccargar datos iniciales

        private void CargarProfesionalConsultorio()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"
                    SELECT 
                        pc.id_profesional_consultorio,
                        p.nombre + ' ' + p.apellido + ' - ' + c.descripcion AS ProfesionalConsultorio
                    FROM Profesional_Consultorio pc
                    INNER JOIN Profesional p ON pc.id_profesional = p.id_profesional
                    INNER JOIN Consultorio c ON pc.id_consultorio = c.id_consultorio";

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                CMBProfesional_consultorio.DataSource = dt;
                CMBProfesional_consultorio.DisplayMember = "ProfesionalConsultorio";
                CMBProfesional_consultorio.ValueMember = "id_profesional_consultorio";
            }
        }

        // CARGAR DISPONIBILIDADES

        private void CargarDisponibilidades()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"
                 SELECT 
                 a.id_agenda,
                 c.nroConsultorio AS [N° Consultorio],
                 c.descripcion AS [Consultorio],
                 p.nombre + ' ' + p.apellido AS [Profesional],
                 pc.vigencia_desde AS [Vigencia Desde],
                 pc.vigencia_hasta AS [Vigencia Hasta],
                 a.diaSemana AS [Día],
                 CONVERT(VARCHAR(5), a.horaInicio, 108) AS [Hora Inicio],
                 CONVERT(VARCHAR(5), a.horaFin, 108) AS [Hora Fin]
                 FROM Consultorio c
                 INNER JOIN Profesional_Consultorio pc ON c.id_consultorio = pc.id_consultorio
                 INNER JOIN Profesional p ON pc.id_profesional = p.id_profesional
                 INNER JOIN Agenda a ON pc.id_profesional_consultorio = a.id_profesional_consultorio
                 ORDER BY c.nroConsultorio, a.diaSemana, a.horaInicio";

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DGWConsultorios_profesional.DataSource = null;
                DGWConsultorios_profesional.Columns.Clear();
                DGWConsultorios_profesional.DataSource = dt;

                DGWConsultorios_profesional.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DGWConsultorios_profesional.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                // ocultar el id_agenda
                if (DGWConsultorios_profesional.Columns.Contains("id_agenda"))
                {
                    DGWConsultorios_profesional.Columns["id_agenda"].Visible = false;
                }
                // Botón Editar
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.HeaderText = "Acción";
                btnEditar.Text = "Editar";
                btnEditar.Name = "Editar";
                btnEditar.UseColumnTextForButtonValue = true;
                DGWConsultorios_profesional.Columns.Add(btnEditar);

                // Botón Eliminar
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.HeaderText = "";
                btnEliminar.Text = "Eliminar";
                btnEliminar.Name = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                DGWConsultorios_profesional.Columns.Add(btnEliminar);
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
                // Cargar profesionales
                SqlDataAdapter daProf = new SqlDataAdapter(
                   @" 
                    SELECT p.id_profesional, p.nombre + ' ' + p.apellido + ' - ' + 
                     e.nombre AS profesional_especialidad 
                    FROM Profesional p 
                    INNER JOIN Especialidad e 
                    ON p.id_especialidad = e.id_especialidad 
                    INNER JOIN EstadoProfesional ep ON p.id_estado = ep.id_estado 
                    WHERE ep.descripcion = 'Activo'", conexion);
                DataTable dtProf = new DataTable(); 
                daProf.Fill(dtProf); CMBProfesional.DataSource = dtProf; 
                CMBProfesional.DisplayMember = "profesional_especialidad"; 
                CMBProfesional.ValueMember = "id_profesional"; 
            } 
        }

        private void CargarConsultorios()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"
                 SELECT 
                  id_consultorio,
                  nroConsultorio AS [N° Consultorio],
                  descripcion AS [Descripción]
                 FROM Consultorio
                 ORDER BY nroConsultorio";

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DGWConsultorios_profesional.DataSource = null;
                DGWConsultorios_profesional.Columns.Clear();
                DGWConsultorios_profesional.DataSource = dt;

                DGWConsultorios_profesional.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DGWConsultorios_profesional.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (DGWConsultorios_profesional.Columns.Contains("id_consultorio"))
                {
                    DGWConsultorios_profesional.Columns["id_consultorio"].Visible = false;
                }
            }
        }

        // BOTONES
        private void BGuardarConsultorio_Click(object sender, EventArgs e) 
        {
            // Validar campos que no esteen vacios
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
        private void BNuevaDisponibilidad_Click(object sender, EventArgs e)
        {
            esEdicion = false;
            idAgendaEditando = null;

            GBNuevaDisponibilidad.Visible = true;
            BGuardarDisponibilidad.Text = "Guardar";
            CMBProfesional_consultorio.Enabled = true;
        }

        private void BAgregarConsultorio_Click(object sender, EventArgs e)
        {
            //esEdicion = false;
            //idAgendaEditando = null;

            GBAgregarConsultorio.Visible = true;
            BGuardarConsultorio.Text = "Guardar";
        }

        private void BAsignarProfesional_Click(object sender, EventArgs e)
        {
            //esEdicion = false;
            //idAgendaEditando = null;

            GBAsignarProfesional.Visible = true;
            BAgregarProfesional_consultorio.Text = "Guardar";
        }

        private void BCancelarDisponibilidad_Click(object sender, EventArgs e)
        {
            GBNuevaDisponibilidad.Visible = false;
            esEdicion = false;
            idAgendaEditando = null;
        }

        private void BCancelarConsultorio_Click(object sender, EventArgs e)
        {
            GBAgregarConsultorio.Visible = false;
            TBNroConsultorio.Clear();
            TBDescripcion.Clear();
            //esEdicion = false;
            //idAgendaEditando = null;
        }
        private void BVolver_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        dt.DefaultView.RowFilter = string.Format("Convert(nroConsultorio, 'System.String') " +
                          "LIKE '%{0}%' OR " +
                          "descripcion LIKE '%{0}%' OR " +
                          "profesional LIKE '%{0}%' OR " +
                          "especialidad LIKE '%{0}%'",
                          filtro.Replace("'", "''"));
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

        private void BCancelarProfesional_consultorio_Click(object sender, EventArgs e)
        {
            GBAsignarProfesional.Visible = false;
            //esEdicion = false;
            //idAgendaEditando = null;
        }
        //guardar o actializar

        private void BGuardar_Click(object sender, EventArgs e)
        {
            string dia = CBDiaSemana.SelectedItem?.ToString();
            TimeSpan horaInicio = DTPHoraInicio.Value.TimeOfDay;
            TimeSpan horaFin = DPTHoraFin.Value.TimeOfDay;
            int idProfesionalConsultorio = Convert.ToInt32(CMBProfesional_consultorio.SelectedValue);

            if (string.IsNullOrEmpty(dia))
            {
                MessageBox.Show("Seleccione un día de la semana.");
                return;
            }

            if (horaFin <= horaInicio)
            {
                MessageBox.Show("La hora de fin debe ser mayor que la hora de inicio.");
                return;
            }

            //Obtener el usuario actual desde la sesión
            int idUsuario = SesionActual.IdUsuario;

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                // verificar que no coincida con otra disponibilidad del mismo profesional
                string checkOverlap = @"
                 SELECT COUNT(*) 
                 FROM Agenda 
                 WHERE id_profesional_consultorio = @idProfesionalConsultorio 
                 AND diaSemana = @dia
                 AND (
                  (@horaInicio BETWEEN horaInicio AND horaFin)
                 OR (@horaFin BETWEEN horaInicio AND horaFin)
                 OR (horaInicio BETWEEN @horaInicio AND @horaFin))";

                SqlCommand checkCmd = new SqlCommand(checkOverlap, conexion);
                checkCmd.Parameters.AddWithValue("@idProfesionalConsultorio", idProfesionalConsultorio);
                checkCmd.Parameters.AddWithValue("@dia", dia);
                checkCmd.Parameters.AddWithValue("@horaInicio", horaInicio);
                checkCmd.Parameters.AddWithValue("@horaFin", horaFin);

                int solapado = (int)checkCmd.ExecuteScalar();
                if (solapado > 0)
                {
                    MessageBox.Show("El profesional ya tiene una disponibilidad en ese día y horario.", "Conflicto de horario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Si no hay conflicto insertar o actualizar
                string query;
                if (!esEdicion)
                {
                    query = @"INSERT INTO Agenda (id_profesional_consultorio, diaSemana, horaInicio, horaFin, id_usuario)
                  VALUES (@id_profesional_consultorio, @dia, @horaInicio, @horaFin, @id_usuario)";
                }
                else
                {
                    query = @"UPDATE Agenda SET diaSemana = @dia, horaInicio = @horaInicio, horaFin = @horaFin
                  WHERE id_agenda = @idAgenda";
                }

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id_profesional_consultorio", idProfesionalConsultorio);
                cmd.Parameters.AddWithValue("@dia", dia);
                cmd.Parameters.AddWithValue("@horaInicio", horaInicio);
                cmd.Parameters.AddWithValue("@horaFin", horaFin);

                if (!esEdicion)
                    cmd.Parameters.AddWithValue("@id_usuario", SesionActual.IdUsuario);
                else
                    cmd.Parameters.AddWithValue("@idAgenda", idAgendaEditando);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show(esEdicion ? "Disponibilidad actualizada correctamente." :
                                        "Disponibilidad guardada correctamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Resetear formulario
            esEdicion = false;
            idAgendaEditando = null;
            CMBProfesional_consultorio.Enabled = true;
            BGuardarDisponibilidad.Text = "Guardar";
            GBNuevaDisponibilidad.Visible = false;

            CargarDisponibilidades();
        }
        // editar y eliminar

        private void DGWConsultorios_profesional_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Asegura que existe la columna id_agenda
            if (!DGWConsultorios_profesional.Columns.Contains("id_agenda"))
            {
                MessageBox.Show("No se encontró la columna id_agenda.");
                return;
            }

            // Obtiene el ID de la fila seleccionada de manera segura
            int idAgenda = Convert.ToInt32(DGWConsultorios_profesional.Rows[e.RowIndex].Cells["id_agenda"].Value);

            // EDITAR
            if (DGWConsultorios_profesional.Columns[e.ColumnIndex].Name == "Editar")
            {
                EditarDisponibilidad(idAgenda);
                return;
            }
            // ELIMINAR
            if (DGWConsultorios_profesional.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult result = MessageBox.Show(
                    "¿Desea eliminar esta disponibilidad?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conexion = Conexion.GetConnection())
                    {
                        conexion.Open();

                        string query = "DELETE FROM Agenda WHERE id_agenda = @id";
                        SqlCommand cmd = new SqlCommand(query, conexion);
                        cmd.Parameters.AddWithValue("@id", idAgenda);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Disponibilidad eliminada correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se encontró la disponibilidad seleccionada.");
                        }
                    }

                    CargarDisponibilidades();
                    CargarTotales();
                }
            }
        }
        // CARGAR DATOS PARA EDICIÓN
        private void EditarDisponibilidad(int idAgenda)
        {
            esEdicion = true;
            idAgendaEditando = idAgenda;

            CargarDatosAgenda(idAgenda);

            GBNuevaDisponibilidad.Visible = true;
            BGuardarDisponibilidad.Text = "Actualizar";
        }

        private void CargarDatosAgenda(int idAgenda)
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"
                    SELECT 
                        a.diaSemana,
                        a.horaInicio,
                        a.horaFin,
                        pc.id_profesional_consultorio
                    FROM Agenda a
                    INNER JOIN Profesional_Consultorio pc 
                        ON a.id_profesional_consultorio = pc.id_profesional_consultorio
                    WHERE a.id_agenda = @idAgenda";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@idAgenda", idAgenda);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        CBDiaSemana.SelectedItem = reader["diaSemana"].ToString();
                        DTPHoraInicio.Value = DateTime.Today.Add((TimeSpan)reader["horaInicio"]);
                        DPTHoraFin.Value = DateTime.Today.Add((TimeSpan)reader["horaFin"]);
                        CMBProfesional_consultorio.SelectedValue = Convert.ToInt32(reader["id_profesional_consultorio"]);
                    }
                }
            }

            CMBProfesional_consultorio.Enabled = false;
        }

        private void CargarTotales()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open(); 
                // Total consultorios
                SqlCommand cmdTotal = new SqlCommand("SELECT COUNT(*) FROM Consultorio", conexion); 
                
                int total = (int)cmdTotal.ExecuteScalar(); 
                // Disponibles
                SqlCommand cmdDisp = new SqlCommand(
                    @"SELECT COUNT(*) 
                     FROM Consultorio c 
                     WHERE c.id_consultorio NOT IN ( SELECT id_consultorio 
                     FROM Profesional_Consultorio WHERE GETDATE() 
                     BETWEEN vigencia_desde AND vigencia_hasta)", conexion); 
                int disponibles = (int)cmdDisp.ExecuteScalar(); 
                // Asignados (vigentes o futuras)
                SqlCommand cmdAsig = new SqlCommand(
                     @" SELECT COUNT(DISTINCT id_consultorio) 
                      FROM Profesional_Consultorio 
                      WHERE vigencia_hasta >= CAST(GETDATE() AS DATE)", conexion); 
                int asignados = (int)cmdAsig.ExecuteScalar(); 
                // Mostrar
                LTotalConsultorios.Text = total.ToString(); 
                LConsultoriosDisponibles.Text = disponibles.ToString(); 
                LConsultoriosAsignados.Text = asignados.ToString(); 
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

    }
}