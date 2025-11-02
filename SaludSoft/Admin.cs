using Org.BouncyCastle.Utilities;
using SaludSoft.Resources.Models;
using SaludSoft.Security;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            CargarCantidadPacientes();
            CargarTurnosDelDia();
            ConfigurarGrillaTurnos();
        }

        
        // Helpers de navegación
        private void MostrarYVolver(Form destino)
        {
            if (destino == null) return;

            destino.StartPosition = FormStartPosition.CenterScreen;
            destino.Show();
            this.Hide();

            destino.FormClosed += (s, a) =>
            {
                if (!this.IsDisposed)
                {
                    this.Show();
                    this.Activate();
                    this.BringToFront();
                }
            };
        }

        private T BuscarAbierto<T>() where T : Form
        {
            return Application.OpenForms.OfType<T>().FirstOrDefault();
        }
        // cargar profesionales y trunos
        private void CargarProfesionales()
        {
            using (var cn = Conexion.GetConnection())
            {
                cn.Open();
                var da = new SqlDataAdapter(@"
                 SELECT id_profesional, (apellido + ', ' + nombre) AS Nombre
                 FROM Profesional
                 WHERE id_estado = 1
                 ORDER BY apellido, nombre", cn);

                var dt = new System.Data.DataTable();
                da.Fill(dt);

                // Crear la fila "Todos los profesionales"
                var filaTodos = dt.NewRow();
                filaTodos["id_profesional"] = 0;
                filaTodos["Nombre"] = "Todos los profesionales";

                // Insertarla al principio
                dt.Rows.InsertAt(filaTodos, 0);

                cmbMedicoMes.DataSource = dt;
                cmbMedicoMes.DisplayMember = "Nombre";
                cmbMedicoMes.ValueMember = "id_profesional";
            }
        }

        private int GetIdProfesionalSeleccionado()
        {
            return int.TryParse(cmbMedicoMes.SelectedValue?.ToString(), out int id) ? id : 0;
        }

        private (DateTime desde, DateTime hasta) ObtenerRangoMes(DateTime fecha)
        {
            var desde = new DateTime(fecha.Year, fecha.Month, 1);
            var hasta = desde.AddMonths(1);
            return (desde, hasta);
        }
        // cargar los turnos del mes seleccionado
        private void CargarTurnosMes(DateTime fecha, int idProfesional)
        {
            var (desde, hasta) = ObtenerRangoMes(fecha);
            dgvTurnosMes.Rows.Clear();

            using (var cn = Conexion.GetConnection())
            {
                cn.Open();
                string sql = @"
                 SELECT 
                 t.fecha AS FechaHora,
                 (pa.apellido + ', ' + pa.nombre) AS Paciente,
                 (pr.apellido + ', ' + pr.nombre) AS Profesional,
                 t.motivo AS Motivo,
                 t.estado AS Estado
                 FROM Turnos t
                 INNER JOIN Paciente pa ON pa.id_paciente = t.id_paciente
                 INNER JOIN Agenda a ON a.id_agenda = t.id_agenda
                 INNER JOIN Profesional_Consultorio pc ON pc.id_profesional_consultorio = a.id_profesional_consultorio
                 INNER JOIN Profesional pr ON pr.id_profesional = pc.id_profesional
                 WHERE t.fecha >= @desde AND t.fecha < @hasta
                 AND (@idProf = 0 OR pr.id_profesional = @idProf)
                 ORDER BY t.fecha";

                using (var cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);
                    cmd.Parameters.AddWithValue("@idProf", idProfesional);

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            dgvTurnosMes.Rows.Add(
                                Convert.ToDateTime(rd["FechaHora"]).ToString("dd/MM/yyyy HH:mm"),
                                rd["Paciente"].ToString(),
                                rd["Profesional"].ToString(),
                                rd["Motivo"].ToString(),
                                rd["Estado"].ToString()
                            );
                        }
                    }
                }
            }

            AplicarColoresEstados();
        }
        // colores de estados 
        private void ConfigurarGrillaTurnos()
        {
            dgvTurnosMes.Columns.Clear();
            dgvTurnosMes.ReadOnly = true;
            dgvTurnosMes.AllowUserToAddRows = false;
            dgvTurnosMes.AllowUserToDeleteRows = false;
            dgvTurnosMes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTurnosMes.RowHeadersVisible = false;

            dgvTurnosMes.Columns.Add("colFechaHora", "Fecha/Hora");
            dgvTurnosMes.Columns.Add("colPaciente", "Paciente");
            dgvTurnosMes.Columns.Add("colProfesional", "Profesional");
            dgvTurnosMes.Columns.Add("colMotivo", "Motivo");
            dgvTurnosMes.Columns.Add("colEstado", "Estado");
        }
        private void AplicarColoresEstados()
        {
            foreach (DataGridViewRow row in dgvTurnosMes.Rows)
            {
                string estado = (row.Cells["colEstado"].Value ?? "").ToString().Trim();

                if (estado.Equals("Cancelado", StringComparison.OrdinalIgnoreCase))
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                else if (estado.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LemonChiffon;
                else if (estado.Equals("Confirmado", StringComparison.OrdinalIgnoreCase))
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.PaleGreen;
                else
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            }
        }
        // eventos de filtros
        private void dtpMes_ValueChanged(object sender, EventArgs e)
        {
            if (pnlTurnos.Visible)
                CargarTurnosMes(dtpSemana.Value, GetIdProfesionalSeleccionado());
        }

        private void cmbProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pnlTurnos.Visible)
                CargarTurnosMes(dtpSemana.Value, GetIdProfesionalSeleccionado());
        }
        // Botones
        private void btInicio_Click(object sender, EventArgs e)
        {
            
            this.Activate();
            this.BringToFront();
        }

        private void btGestionUsuario_Click(object sender, EventArgs e)
        {
            // Abre  FormGestionUsuario
            var frm = BuscarAbierto<FormGestionUsuario>();
            if (frm == null) frm = new FormGestionUsuario();

            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
            frm.Focus();

            MostrarYVolver(frm);
        }

        private void btBackup_Click(object sender, EventArgs e)
        {
            var frm = BuscarAbierto<Backup>();
            if (frm == null) frm = new Backup();

            frm.WindowState = FormWindowState.Normal;
            frm.BringToFront();
            frm.Focus();

            MostrarYVolver(frm);
        }
        private void BReportes_Click(object sender, EventArgs e)
        {
            FormEstadisticas frm = new FormEstadisticas();
                frm.ShowDialog();
        }
        private void btCerrarSesion_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("¿Seguro que querés cerrar sesión?", "Confirmación",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                SesionActual.IdUsuario = 0;
                SesionActual.Nombre = null;
                SesionActual.Rol = null;
                
            }
            catch { /* ignorar si no existe */ }

            var login = Application.OpenForms.OfType<FormLogin>().FirstOrDefault() ?? new FormLogin();

            
            login.LimpiarCampos();
            login.StartPosition = FormStartPosition.CenterScreen;
            login.Show();
            login.Activate();

           
            this.Close();
        }

        private void btEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades frm = new Especialidades();
            frm.ShowDialog();
        }

        private void BPacienetes_Click(object sender, EventArgs e)
        {
            FormListaPacientes frm = new FormListaPacientes();
            frm.ShowDialog();
        }
        private void btConsultorios_Click(object sender, EventArgs e)
        {
            FormConsultorio frm = new FormConsultorio();
            frm.ShowDialog();
        }
        private void btTurnos_Click(object sender, EventArgs e)
        {
            pnlTurnos.Visible = true;
            pnlTurnos.BringToFront();
            CargarProfesionales();
            CargarTurnosMes(dtpSemana.Value, GetIdProfesionalSeleccionado());
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            pnlTurnos.Visible = false;
        }
        // contadores 
        private void CargarCantidadPacientes()
        {
            int cantidad = 0;

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Paciente", conexion);
                cantidad = (int)cmd.ExecuteScalar();
            }

            // Asignar el texto al botón o label
            LContador.Text = $"{cantidad}";
        }

        private void CargarTurnosDelDia()
        {
            int cantidadTurnos = 0;

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"
                 SELECT COUNT(*) 
                 FROM Turnos 
                 WHERE CONVERT(date, fecha) = CONVERT(date, GETDATE())";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cantidadTurnos = (int)cmd.ExecuteScalar();
                }
            }

            LTurnosDelDia.Text = $"{cantidadTurnos}";
        }

       
    }
}
