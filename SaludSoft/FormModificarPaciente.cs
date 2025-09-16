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
    public partial class FormModificarPaciente : Form
    {

        private int idPaciente;

        public FormModificarPaciente(
            int id, string nombre, string apellido, string dni,
            string telefono, string email, string direccion)
        {
            InitializeComponent();
            idPaciente = id;

            // Carga datos del paciente y direccion
            TBNombre.Text = nombre;
            TBApellido.Text = apellido;
            TBDni.Text = dni;
            TBTelefono.Text = telefono;
            TBEmail.Text = email;
            TBDireccion.Text = direccion;
        }

        // funcionalidades de los botones
        private void BGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                SqlTransaction trans = conexion.BeginTransaction();

                try
                {
                    // Actualiza los datos del paciente
                    string queryPaciente = @"UPDATE Paciente 
                                     SET nombre = @nombre, 
                                         apellido = @apellido, 
                                         dni = @dni, 
                                         telefono = @telefono, 
                                         email = @email,
                                         direccion = @direccion,
                                         sexo = @sexo
                                     WHERE id_paciente = @id";

                       SqlCommand cmdPaciente = new SqlCommand(queryPaciente, conexion, trans);
                       cmdPaciente.Parameters.AddWithValue("@nombre", TBNombre.Text.Trim());
                       cmdPaciente.Parameters.AddWithValue("@apellido", TBApellido.Text.Trim());
                       cmdPaciente.Parameters.AddWithValue("@dni", int.Parse(TBDni.Text.Trim()));
                       cmdPaciente.Parameters.AddWithValue("@telefono", TBTelefono.Text.Trim());
                       cmdPaciente.Parameters.AddWithValue("@email", TBEmail.Text.Trim());
                       cmdPaciente.Parameters.AddWithValue("@direccion", TBDireccion.Text.Trim());
                       cmdPaciente.Parameters.AddWithValue("@sexo", RBMasculino.Checked ? "Masculino" : "Femenino");
                    // Id del paciente que estamos modificando
                    cmdPaciente.Parameters.AddWithValue("@id", idPaciente);
                       cmdPaciente.ExecuteNonQuery();

                       trans.Commit();

                       MessageBox.Show("Paciente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       this.Close();
                 }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BNuevoPaciente_Click(object sender, EventArgs e)
        {
            FormPaciente frm = new FormPaciente();
            frm.ShowDialog();
            this.Close();
        }
    }
    
}
