using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SaludSoft
{
    public partial class FormNuevoTurno : Form
    {
        public FormNuevoTurno()
        {
            InitializeComponent();
            CargarProfesionales();
            CargarEstados();
        }

        // Paciente
        private void CargarProfesionales()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                string query = "SELECT id_profesional, nombre + ' ' + apellido AS Profesional FROM Profesional";
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbDoctores.DataSource = dt;
                cmbDoctores.DisplayMember = "Profesional";
                cmbDoctores.ValueMember = "id_profesional";
                cmbDoctores.SelectedIndex = -1;
            }
        }

        private void CargarEstados()
        {
            CMBEstadoTurno.Items.Add("Pendiente");
            CMBEstadoTurno.Items.Add("Confirmado");
            CMBEstadoTurno.Items.Add("Cancelado");
            CMBEstadoTurno.Items.Add("Realizado");
            CMBEstadoTurno.SelectedIndex = 0;
        }

        private void BBuscarPaciente_Click(object sender, EventArgs e)
        {
            // Validar que el DNI sea un número válido
            if (!int.TryParse(TBDniPaciente.Text.Trim(), out int dni))
            {
                MessageBox.Show("Ingrese un DNI válido.");
                TBDniPaciente.Focus();
                return;
            }

            MessageBox.Show("Buscando DNI: " + dni); // ver qué DNI se está enviando

            string query = "SELECT nombre, apellido, id_paciente FROM Paciente WHERE dni = @dni";

            try
            {
                using (SqlConnection conexion = Conexion.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.Add("@dni", SqlDbType.Int).Value = dni;

                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows) //debug extra
                        {
                            dr.Read();
                            TBNombre.Text = dr["nombre"]?.ToString() ?? "";
                            TBApellido.Text = dr["apellido"]?.ToString() ?? "";
                            TBIdPaciente.Text = dr["id_paciente"]?.ToString() ?? "";

                            MessageBox.Show("Paciente encontrado: " + TBNombre.Text + " " + TBApellido.Text);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró paciente con ese DNI en la base actual.");
                            TBNombre.Text = "";
                            TBApellido.Text = "";
                            TBIdPaciente.Text = "";
                            TBDniPaciente.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar paciente: " + ex.Message);
            }
        }

        private void cmbDoctores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDoctores.SelectedValue == null) return;

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                string query = @"SELECT pc.id_profesional_consultorio, c.descripcion 
                                 FROM Profesional_Consultorio pc
                                 INNER JOIN Consultorio c ON pc.id_consultorio = c.id_consultorio
                                 WHERE pc.id_profesional = @id_profesional";
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.SelectCommand.Parameters.AddWithValue("@id_profesional", cmbDoctores.SelectedValue);
                DataTable dt = new DataTable();
                da.Fill(dt);

                CMBConsultorio.DataSource = dt;
                CMBConsultorio.DisplayMember = "descripcion";
                CMBConsultorio.ValueMember = "id_profesional_consultorio";
            }
        }

        private void cmbConsultorio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMBConsultorio.SelectedValue == null) return;

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                string query = @"SELECT id_agenda, 
                                        diaSemana + ' ' + FORMAT(horaInicio, 'HH:mm') + '-' + FORMAT(horaFin, 'HH:mm') AS Horario
                                 FROM Agenda 
                                 WHERE id_profesional_consultorio = @id_pc";
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.SelectCommand.Parameters.AddWithValue("@id_pc", CMBConsultorio.SelectedValue);
                DataTable dt = new DataTable();
                da.Fill(dt);
                // horarios viene de la agenda del profesional en el consultorio seleccionado
                CMBHorario.DataSource = dt;
                CMBHorario.DisplayMember = "Horario";
                CMBHorario.ValueMember = "id_agenda";
            }
        }

        private void BAgregarTurno_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                string query = @"INSERT INTO Turnos (fecha, estado, motivo, id_paciente, id_agenda, id_profesional_consultorio)
                 VALUES (@fecha, @estado, @motivo, @id_paciente, @id_agenda, @id_pc)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id_turno", Guid.NewGuid().GetHashCode()); 
                cmd.Parameters.AddWithValue("@fecha", DTPFechas.Value);
                cmd.Parameters.AddWithValue("@estado", CMBEstadoTurno.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@motivo", TBMotivoConsulta.Text);
                cmd.Parameters.AddWithValue("@id_paciente", TBIdPaciente.Text);
                cmd.Parameters.AddWithValue("@id_agenda", CMBHorario.SelectedValue);
                cmd.Parameters.AddWithValue("@id_pc", CMBConsultorio.SelectedValue);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Turno guardado correctamente");
            }
        }
   
        private void BCancelarTurno_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

