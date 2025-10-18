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

        // ==============================
        //  TURNOS - Panel dentro del form
        //  Respeta nombres: pnlTurnos, dtpSemana, btnActualizarSemana, btnVolver,
        //  dgvTurnosSemana (colFechaHora, colPaciente, colProfesional, colMotivo, colEstado, colEditar, colCancelar)
        //  Botón del menú: BTurnos
        // ==============================

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Arranca oculto
            if (pnlTurnos != null) pnlTurnos.Visible = false;

            // Formato de fecha/hora en la grilla
            if (dgvTurnosSemana != null && dgvTurnosSemana.Columns.Contains("colFechaHora"))
                dgvTurnosSemana.Columns["colFechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        // --- Menú lateral: botón Turnos ---
        private void BTurnos_Click(object sender, EventArgs e)
        {
            MostrarPanelTurnos();
            CargarTurnosSemana(dtpSemana.Value);
        }

        // --- Botón Volver (dentro de pnlTurnos) ---
        private void btnVolver_Click(object sender, EventArgs e)
        {
            OcultarPanelTurnos();
        }

        // --- Botón Actualizar (dentro de pnlTurnos) ---
        private void btnActualizarSemana_Click(object sender, EventArgs e)
        {
            CargarTurnosSemana(dtpSemana.Value);
        }

        //Si cambia la fecha (selector de semana)
        private void dtpSemana_ValueChanged(object sender, EventArgs e)
        {
            if (pnlTurnos.Visible)
                CargarTurnosSemana(dtpSemana.Value);
        }

        // Helpers de navegación
        private void MostrarPanelTurnos()
        {
            pnlTurnos.Visible = true;
            pnlTurnos.BringToFront();
            this.Activate();
        }

        private void OcultarPanelTurnos()
        {
            pnlTurnos.Visible = false;
        }

        // Cargar datos de la semana completa
        private void CargarTurnosSemana(DateTime anyDateInWeek)
        {
            var (desde, hasta) = ObtenerRangoSemana(anyDateInWeek);

            dgvTurnosSemana.Rows.Clear();

            using (SqlConnection cn = Conexion.GetConnection())
            {
                cn.Open();

                string sql = @"
    SELECT 
        t.id_turno,
        DATEADD(
            SECOND, 
            DATEDIFF(SECOND, '00:00:00', COALESCE(CONVERT(time, t.hora), '00:00:00')),
            CAST(t.fecha AS datetime)
        ) AS fechaHora,
        (p.apellido + ', ' + p.nombre) AS Paciente,
        (pr.apellido + ', ' + pr.nombre) AS Profesional,
        t.motivo,
        e.descripcion AS Estado
    FROM Turnos t
    INNER JOIN Paciente p ON p.id_paciente = t.id_paciente
    LEFT JOIN Agenda a ON a.id_agenda = t.id_agenda
    LEFT JOIN Profesional pr ON pr.id_profesional = a.id_profesional
    LEFT JOIN Estado e ON e.id_estado = COALESCE(t.id_estado, t.id_estado_turno)
    WHERE t.fecha >= @desde AND t.fecha < @hasta
    ORDER BY fechaHora;";


                using (var cmd = new SqlCommand(sql, cn))
                {
                    // desde = lunes 00:00, hasta = lunes siguiente 00:00 (semana [desde, hasta))
                    cmd.Parameters.AddWithValue("@desde", desde.Date);
                    cmd.Parameters.AddWithValue("@hasta", hasta.Date);

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            int rowIndex = dgvTurnosSemana.Rows.Add(
                                Convert.ToDateTime(rd["fechaHora"]),
                                rd["Paciente"].ToString(),
                                rd["Profesional"].ToString(),
                                rd["motivo"] == DBNull.Value ? "" : rd["motivo"].ToString(),
                                rd["Estado"] == DBNull.Value ? "" : rd["Estado"].ToString(),
                                "Editar",
                                "Cancelar"
                            );

                            dgvTurnosSemana.Rows[rowIndex].Tag = Convert.ToInt32(rd["id_turno"]);
                        }
                    }
                }
            }
        }


        // Devuelve lunes 00:00, lunes siguiente 00:00
        private (DateTime desde, DateTime hasta) ObtenerRangoSemana(DateTime d)
        {
            int diff = (7 + (int)d.DayOfWeek - (int)DayOfWeek.Monday) % 7;
            DateTime lunes = d.Date.AddDays(-diff);
            DateTime lunesSiguiente = lunes.AddDays(7);
            return (lunes, lunesSiguiente);
        }

        // Acciones en la grilla (botones)
        
        private void dgvTurnosSemana_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var grid = dgvTurnosSemana;
            string colName = grid.Columns[e.ColumnIndex].Name;

            var row = grid.Rows[e.RowIndex];
            int idTurno = (row.Tag is int) ? (int)row.Tag : Convert.ToInt32(row.Tag);

            if (colName == "colEditar")
            {
                // Abre un panel/overlay de edición
                MessageBox.Show($"Editar turno #{idTurno}", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (colName == "colCancelar")
            {
                var r = MessageBox.Show("¿Deseás cancelar este turno?", "Confirmar cancelación",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    CancelarTurno(idTurno);
                    CargarTurnosSemana(dtpSemana.Value);
                }
            }
        }

        // Cambia el estado del turno a 'Cancelado'
        private void CancelarTurno(int idTurno)
        {
            using (SqlConnection cn = Conexion.GetConnection())
            {
                cn.Open();

                string sql = @"
        UPDATE t
           SET t.id_estado = e.id_estado
          FROM Turnos t
          JOIN Estado e ON e.descripcion = 'Cancelado'
         WHERE t.id_turno = @idTurno;";

                using (var cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@idTurno", idTurno);
                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
