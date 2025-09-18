using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class FormNuevaDisponibilidad : Form
    {
        public FormNuevaDisponibilidad()
        {
            InitializeComponent();

            // Configurar pickers de hora
            DTPHoraInicio.Format = DateTimePickerFormat.Time;
            DTPHoraInicio.ShowUpDown = true;

            DPTHoraFin.Format = DateTimePickerFormat.Time;
            DPTHoraFin.ShowUpDown = true;

            CargarProfesionales();
        }

        private void CargarProfesionales()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"SELECT id_profesional, nombre + ' ' + apellido AS Profesional 
                         FROM Profesional 
                         WHERE id_estado = 1"; // solo profesionales activos

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                CMBProfesional.DataSource = dt;
                CMBProfesional.DisplayMember = "Profesional";
                CMBProfesional.ValueMember = "id_profesional";

                if (dt.Rows.Count > 0)
                {
                    CMBProfesional.SelectedIndex = 0;

                    // Cargar sus consultorios directamente
                    int idProfesional = Convert.ToInt32(CMBProfesional.SelectedValue);
                    CargarConsultorios(idProfesional);
                }
                else
                {
                    CMBProfesional.SelectedIndex = -1;
                    CMBConsultorio.DataSource = null;
                }
            }
        }

        private void CargarConsultorios(int idProfesional)
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                string query = @"SELECT pc.id_profesional_consultorio, 
                                c.descripcion AS Consultorio
                         FROM Profesional_Consultorio pc
                         INNER JOIN Consultorio c ON pc.id_consultorio = c.id_consultorio
                         WHERE pc.id_profesional = @idProfesional";

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.SelectCommand.Parameters.AddWithValue("@idProfesional", idProfesional);

                DataTable dt = new DataTable();
                da.Fill(dt);

                CMBConsultorio.DataSource = dt;
                CMBConsultorio.DisplayMember = "Consultorio";
                CMBConsultorio.ValueMember = "id_profesional_consultorio";
                CMBConsultorio.SelectedIndex = -1;
            }
        }

        private void CMBProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(CMBProfesional.SelectedValue?.ToString(), out int idProfesional))
            {
                CargarConsultorios(idProfesional);
            }
            else
            {
                CMBConsultorio.DataSource = null;
            }
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            if (CMBProfesional.SelectedValue == null || CMBConsultorio.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un profesional y un consultorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime fecha = DPTFecha.Value.Date;
            TimeSpan horaInicio = DTPHoraInicio.Value.TimeOfDay;
            TimeSpan horaFin = DPTHoraFin.Value.TimeOfDay;

            if (horaFin <= horaInicio)
            {
                MessageBox.Show("La hora de fin debe ser mayor a la hora de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idProfesionalConsultorio = Convert.ToInt32(CMBConsultorio.SelectedValue);

            // el id_usuario de la/el recepcionista logueada
            int idUsuario = 1;

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"INSERT INTO Agenda (disponibilidad, hora_inicio, hora_fin, id_usuario, id_profesional_consultorio)
                                 VALUES (@fecha, @horaInicio, @horaFin, @idUsuario, @idProfCons)";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@horaInicio", horaInicio);
                cmd.Parameters.AddWithValue("@horaFin", horaFin);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@idProfCons", idProfesionalConsultorio);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Disponibilidad guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                //LimpiarCampos();
                this.Close();
            }
        }
    }
}

