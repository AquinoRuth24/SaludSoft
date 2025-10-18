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
    public partial class SaludSoft : Form
    {
        public SaludSoft()
        {
            InitializeComponent();
            CargarTotales();


        }
        // botones del menu principal
        private void BNuevoPaciente_Click(object sender, EventArgs e)
        {
            // se instancia el formulario y se muestra 
            FormPaciente frm = new FormPaciente();  
            frm.ShowDialog();
        }

        private void BNuevaCita_Click(object sender, EventArgs e)
        {
            FormAgenda frm = new FormAgenda();
            frm.ShowDialog();
        }

        private void BPacientes_Click(object sender, EventArgs e)
        {
            FormListaPacientes frm = new FormListaPacientes();
            frm.ShowDialog();
        }

        private void BCerrarSesion_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("¿Seguro que querés cerrar sesión?",
                           "Confirmación",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question);

            if (r != DialogResult.Yes) return;

            this.Hide(); // no queda visible

            using (var login = new FormLogin())
            {
                var result = login.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Sesión nueva: volvés al principal
                    this.Show();
                    CargarTotales();
                }
                else
                {

                    this.Close();
                }
            }
        }

        private void BAgenda_Click(object sender, EventArgs e)
        {
            FormAgenda frm = new FormAgenda();
            frm.ShowDialog();
        }

        private void PDoctores_Click(object sender, EventArgs e)
        {
            FormListarProfesionales frm = new FormListarProfesionales();
            frm.ShowDialog();
        }

        private void CargarTotales()
        {

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                // Pacientes hoy (por ejemplo, registrados hoy)
                SqlCommand cmdPacientes = new SqlCommand(
                    "SELECT COUNT(*) FROM Paciente WHERE CAST(GETDATE() AS DATE) = CAST(GETDATE() AS DATE)", conexion);
                int totalPacientes = (int)cmdPacientes.ExecuteScalar();

                // Turnos programados hoy
                SqlCommand cmdTurnos = new SqlCommand(
                    "SELECT COUNT(*) FROM Turnos WHERE fecha = CAST(GETDATE() AS DATE)", conexion);
                int totalTurnos = (int)cmdTurnos.ExecuteScalar();

                // turnos programados esta semana
                SqlCommand cmdTurnosSemana = new SqlCommand(@"
                 SELECT COUNT(*) 
                 FROM Turnos 
                 WHERE fecha >= DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE))
                 AND fecha < DATEADD(DAY, 8 - DATEPART(WEEKDAY, GETDATE()), CAST(GETDATE() AS DATE))
                 ", conexion);
                int totalTurnosSemana = (int)cmdTurnosSemana.ExecuteScalar();

                // Especialidades
                SqlCommand cmdEspecialidades = new SqlCommand(
                    "SELECT COUNT(*) FROM Especialidad", conexion);
                int totalEspecialidades = (int)cmdEspecialidades.ExecuteScalar();

                // Doctores disponibles
                SqlCommand cmdDoctores = new SqlCommand(
                    "SELECT COUNT(*) FROM Profesional WHERE id_estado = 1", conexion);
                int totalDoctores = (int)cmdDoctores.ExecuteScalar();

                // Actualizamos los labels del formulario
                LContadorPacientesHoy.Text = totalPacientes.ToString();
                LContadorTurnosHoy.Text = totalTurnos.ToString();
                LTurnosSemana.Text = totalTurnosSemana.ToString();
                LContadorEspecialidades.Text = totalEspecialidades.ToString();
                LContadorDoctores.Text = totalDoctores.ToString();
            }
        }

    
    }
}
