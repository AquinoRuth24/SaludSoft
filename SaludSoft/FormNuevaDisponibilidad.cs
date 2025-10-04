using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SaludSoft.Security;

namespace SaludSoft
{
    public partial class FormNuevaDisponibilidad : Form
    {
        private int? idAgendaEditando = null;  // para saber si estoy editando
        private bool esEdicion = false;
        public FormNuevaDisponibilidad()
        {
            InitializeComponent();

            // Configuración de los pickers de hora
            DTPHoraInicio.Format = DateTimePickerFormat.Time;
            DTPHoraInicio.ShowUpDown = true;

            DPTHoraFin.Format = DateTimePickerFormat.Time;
            DPTHoraFin.ShowUpDown = true;

            // Cargar días de la semana
            CBDiaSemana.Items.AddRange(new string[]
            {
                "Lunes","Martes","Miércoles","Jueves","Viernes"
            });
            CBDiaSemana.SelectedIndex = 0;

            CargarProfesionalConsultorio();
        }

        // Constructor para editar una disponibilidad existente
        public FormNuevaDisponibilidad(int idAgenda)
        {
            InitializeComponent();

            esEdicion = true;
            idAgendaEditando = idAgenda;

            // Configuración de los pickers de hora
            DTPHoraInicio.Format = DateTimePickerFormat.Time;
            DTPHoraInicio.ShowUpDown = true;
            DPTHoraFin.Format = DateTimePickerFormat.Time;
            DPTHoraFin.ShowUpDown = true;

            // Cargar días y combos
            CBDiaSemana.Items.AddRange(new string[]
            {
             "Lunes", "Martes", "Miércoles", "Jueves", "Viernes"
            });

            CargarProfesionalConsultorio();

            CargarDatosAgenda(idAgenda);

            // Cambiar textos del formulario
            this.Text = "Editar Disponibilidad";
            BGuardar.Text = "Actualizar";
        }
        // cargar datos de la agenda para editar
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

            // Bloquear cambio de profesional_consultorio al editar
            CMBProfesional_consultorio.Enabled = false;
        }

        // cargar en el combox los datos de la tabla Profesional_Consultorio
        private void CargarProfesionalConsultorio()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"
                 SELECT pc.id_profesional_consultorio,
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
                CMBProfesional_consultorio.SelectedIndex = -1;
            }
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {

            if (!SesionActual.EstaLogueado)
            {
                MessageBox.Show("Debes iniciar sesión primero.");
                return;
            }

            int idUsuario = SesionActual.IdUsuario;

            if (CMBProfesional_consultorio.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un profesional y un consultorio.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CBDiaSemana.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un día de la semana.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TimeSpan horaInicio = DTPHoraInicio.Value.TimeOfDay;
            TimeSpan horaFin = DPTHoraFin.Value.TimeOfDay;

            if (horaFin <= horaInicio)
            {
                MessageBox.Show("La hora de fin debe ser mayor a la hora de inicio.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idProfesionalConsultorio = Convert.ToInt32(CMBProfesional_consultorio.SelectedValue);
            string diaSemana = CBDiaSemana.SelectedItem.ToString();
            int intervalo = 30;

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                string getConsultorio = @"SELECT id_consultorio FROM Profesional_Consultorio 
                              WHERE id_profesional_consultorio = @idProfCons";
                SqlCommand cmdGet = new SqlCommand(getConsultorio, conexion);
                cmdGet.Parameters.AddWithValue("@idProfCons", idProfesionalConsultorio);
                int idConsultorio = Convert.ToInt32(cmdGet.ExecuteScalar());

                // Validar choque de horarios en el mismo consultorio y día
                string checkQuery = @"
                 SELECT COUNT(*) 
                 FROM Agenda a
                 INNER JOIN Profesional_Consultorio pc 
                 ON a.id_profesional_consultorio = pc.id_profesional_consultorio
                 WHERE pc.id_consultorio = @idConsultorio
                 AND a.diaSemana = @diaSemana
                 AND (a.horaInicio < @horaFin AND a.horaFin > @horaInicio)";

                SqlCommand checkCmd = new SqlCommand(checkQuery, conexion);
                checkCmd.Parameters.AddWithValue("@idConsultorio", idConsultorio);
                checkCmd.Parameters.AddWithValue("@diaSemana", diaSemana);
                checkCmd.Parameters.AddWithValue("@horaInicio", horaInicio);
                checkCmd.Parameters.AddWithValue("@horaFin", horaFin);

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("El consultorio ya tiene otra disponibilidad en ese horario.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // INSERT o UPDATE según el modo
                if (!esEdicion)
                {
                    string insertQuery = @"
                     INSERT INTO Agenda 
                     (id_usuario, id_profesional_consultorio, diaSemana, horaInicio, horaFin, intervalo)
                     VALUES (@idUsuario, @idProfCons, @diaSemana, @horaInicio, @horaFin, @intervalo)";

                    SqlCommand cmd = new SqlCommand(insertQuery, conexion);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@idProfCons", idProfesionalConsultorio);
                    cmd.Parameters.AddWithValue("@diaSemana", diaSemana);
                    cmd.Parameters.AddWithValue("@horaInicio", horaInicio);
                    cmd.Parameters.AddWithValue("@horaFin", horaFin);
                    cmd.Parameters.AddWithValue("@intervalo", intervalo);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Disponibilidad guardada correctamente.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string updateQuery = @"
                     UPDATE Agenda
                     SET diaSemana = @diaSemana,
                      horaInicio = @horaInicio,
                      horaFin = @horaFin
                     WHERE id_agenda = @idAgenda";

                    SqlCommand cmd = new SqlCommand(updateQuery, conexion);
                    cmd.Parameters.AddWithValue("@diaSemana", diaSemana);
                    cmd.Parameters.AddWithValue("@horaInicio", horaInicio);
                    cmd.Parameters.AddWithValue("@horaFin", horaFin);
                    cmd.Parameters.AddWithValue("@idAgenda", idAgendaEditando);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Disponibilidad actualizada correctamente.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cancelar el Registro?",
                                   "Confirmar",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void BVolverAgenda_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
