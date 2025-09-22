using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaludSoft.Resources.Models
{
    public partial class FormModificarMedico : Form
    {
        private int _idUsuario;
        private int _estado;

        public FormModificarMedico(int idUsuario, string nombre, string apellido, string email, string telefono, string matricula, int idEspecialidad, int estado)
        {
            InitializeComponent();
            this.gbMedico.Visible = true;
            _idUsuario = idUsuario;
            _estado = estado;

            tbNombre.Text = nombre;
            tbApellido.Text = apellido;
            tbCorreo.Text = email;
            tbTelefono.Text = telefono;
            tbMatricula.Text = matricula;

            // Cargar especialidades en el combo
            CargarEspecialidades();

            // Seleccionar la especialidad correspondiente
            if (idEspecialidad > 0)
            {
                CMBEsecialidad.SelectedValue = idEspecialidad;
            }
        }

        private void CargarEspecialidades()
        {
            try
            {
                using (SqlConnection conexion = Conexion.GetConnection())
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("SELECT id_especialidad, nombre FROM Especialidad", conexion);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    CMBEsecialidad.DataSource = dt;
                    CMBEsecialidad.DisplayMember = "nombre";         
                    CMBEsecialidad.ValueMember = "id_especialidad";    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar especialidades: " + ex.Message);
            }
        }
        // botones
        private void BTModificar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion = Conexion.GetConnection())
                {
                    conexion.Open();

                    // Actualizar datos básicos de Usuario
                    string queryUsuario = "UPDATE Usuario SET nombre = @nombre, apellido = @apellido, email = @email, telefono = @telefono WHERE id_usuario = @id";
                    SqlCommand cmdUsuario = new SqlCommand(queryUsuario, conexion);
                    cmdUsuario.Parameters.AddWithValue("@nombre", tbNombre.Text);
                    cmdUsuario.Parameters.AddWithValue("@apellido", tbApellido.Text);
                    cmdUsuario.Parameters.AddWithValue("@email", tbCorreo.Text);
                    cmdUsuario.Parameters.AddWithValue("@telefono", tbTelefono.Text);
                    cmdUsuario.Parameters.AddWithValue("@id", _idUsuario);
                    cmdUsuario.ExecuteNonQuery();

                    // Actualizar datos de Médico
                    string queryMedico = "UPDATE Profesional SET matricula = @matricula, id_especialidad = @idEspecialidad WHERE id_usuario = @id";
                    SqlCommand cmdMedico = new SqlCommand(queryMedico, conexion);
                    cmdMedico.Parameters.AddWithValue("@matricula", tbMatricula.Text);


                    cmdMedico.Parameters.AddWithValue("@idEspecialidad", CMBEsecialidad.SelectedValue);

                    cmdMedico.Parameters.AddWithValue("@id", _idUsuario);
                    cmdMedico.ExecuteNonQuery();
                }

                MessageBox.Show("Médico actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar médico: " + ex.Message);
            }

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

