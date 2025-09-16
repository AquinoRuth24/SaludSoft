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
            CargarDoctores();
        }

        private void CargarDoctores()
        {
            try
            {
                using (SqlConnection conexion = Conexion.GetConnection())
                {
                    conexion.Open();
                    string query = "SELECT id_profesional, nombre + ' ' + apellido AS Doctor FROM Profesional";

                    SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbDoctores.DataSource = dt;
                    // se configura para mostrar el nombre completo(se concatena en la base de datos)
                    cmbDoctores.DisplayMember = "Doctor";
                    // se guarda el id del profesional
                    cmbDoctores.ValueMember = "id_profesional";
                    // para que no se muestre ninguna seleccion inicial 
                    cmbDoctores.SelectedIndex = -1;
                    // se ve mientras no se haya seleccionado nada
                    cmbDoctores.Text = "Seleccione un doctor";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar doctores: " + ex.Message);
            }
        }
        // validaciones
        private void TBDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ValidarCampos()
        {
            // Verifica DNI 
            if (string.IsNullOrWhiteSpace(TBDni.Text))
            {
                MessageBox.Show("Debe ingresar un DNI.");
                TBTelefono.Focus();
                return false;
            }

            if (!int.TryParse(TBDni.Text, out _))
            {
                MessageBox.Show("El DNI debe contener solo números.");
                TBTelefono.Focus();
                return false;
            }

            // Verifica que se seleccione un doctor
            if (cmbDoctores.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un doctor.");
                cmbDoctores.Focus();
                return false;
            }

            // Verifica fecha que sea una valida y no anterior al dia actual
            if (dateTimePickerFecha.Value.Date < DateTime.Today)
            {
                MessageBox.Show("La fecha no puede ser anterior a hoy.");
                dateTimePickerFecha.Focus();
                return false;
            }

            // La hora es obligatoria
            if (dateTimePickerHora.CustomFormat == " ")
            {
                MessageBox.Show("Debe seleccionar una hora.");
                dateTimePickerHora.Focus();
                return false;
            }

            return true;
        }

        // se agrega el turno
        private void BAgregarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                int idPaciente = -1;

                using (SqlConnection conexion = Conexion.GetConnection())
                {
                    conexion.Open();

                    // Verifica si el paciente existe en la BD mediante el dni
                    string queryPaciente = "SELECT id_paciente FROM Paciente WHERE dni = @dni";
                    SqlCommand cmdPaciente = new SqlCommand(queryPaciente, conexion);
                    cmdPaciente.Parameters.AddWithValue("@dni", TBDni.Text.Trim());

                    object result = cmdPaciente.ExecuteScalar();
                    if (result != null)
                    {
                        idPaciente = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("El paciente no está registrado. Primero debe registrarse.");
                        return;
                    }

                    // registra  el turno
                    string query = @"INSERT INTO Turnos (id_paciente, id_profesional, fecha, hora, motivo) 
                             VALUES (@idPaciente, @idDoctor, @fecha, @hora, @motivo)";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                    cmd.Parameters.AddWithValue("@idDoctor", cmbDoctores.SelectedValue);
                    cmd.Parameters.AddWithValue("@fecha", dateTimePickerFecha.Value.Date);
                    cmd.Parameters.AddWithValue("@hora", dateTimePickerHora.Value.ToString("HH:mm"));
                    cmd.Parameters.AddWithValue("@motivo", TBMotivoConsulta.Text.Trim());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Turno registrado con éxito.");

                    LimpiarCampos();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el turno: " + ex.Message);
            }
        }
       
        private void LimpiarCampos()
        {
            {
                TBNomYApe.Clear();
                TBTelefono.Clear();
                TBDni.Clear();
                TBMotivoConsulta.Clear();
                cmbDoctores.SelectedIndex = -1;
                dateTimePickerHora.Value = DateTime.Now;
                dateTimePickerFecha.Value = DateTime.Today;
            }
        }

        // botones 
        private void BInicioFormTurno_Click(object sender, EventArgs e)
        {
            SaludSoft frm = new SaludSoft();
            frm.ShowDialog();
            this.Close();
        }
        private void BPacientesFormTurno_Click(object sender, EventArgs e)
        {
            FormListaPacientes frm = new FormListaPacientes();
            frm.ShowDialog();
            this.Close();
        }

        private void BCancelarTurno_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            this.Close();
        }
    }
    }

