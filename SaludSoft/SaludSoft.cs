using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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

        // MENÚ PRINCIPAL
        private void BNuevoPaciente_Click(object sender, EventArgs e)
        {
            using (var frm = new FormPaciente()) frm.ShowDialog();
        }

        private void BNuevaCita_Click(object sender, EventArgs e)
        {
            using (var frm = new FormAgenda()) frm.ShowDialog();
        }

        private void BPacientes_Click(object sender, EventArgs e)
        {
            using (var frm = new FormListaPacientes()) frm.ShowDialog();
        }

        private void BAgenda_Click(object sender, EventArgs e)
        {
            using (var frm = new FormAgenda()) frm.ShowDialog();
        }

        private void PDoctores_Click(object sender, EventArgs e)
        {
            using (var frm = new FormListarProfesionales()) frm.ShowDialog();
        }

        private void BCerrarSesion_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("¿Seguro que querés cerrar sesión?", "Confirmación",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            this.Hide();
            using (var login = new FormLogin())
            {
                var result = login.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.Show();
                    CargarTotales();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void CargarTotales()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                int totalPacientes = 0;

                using (var cmdTurnos = new SqlCommand(
                    "SELECT COUNT(*) FROM Turnos WHERE CONVERT(date, fecha) = CONVERT(date, GETDATE()) AND estado <> 'Cancelado'", conexion))
                {
                    LContadorTurnosHoy.Text = ((int)cmdTurnos.ExecuteScalar()).ToString();
                }

                using (var cmdTurnosSemana = new SqlCommand(@"
                    SELECT COUNT(*) 
                      FROM Turnos 
                     WHERE CONVERT(date, fecha) >= DATEADD(DAY, 1 - DATEPART(WEEKDAY, GETDATE()), CONVERT(date, GETDATE()))
                       AND CONVERT(date, fecha) <  DATEADD(DAY, 8 - DATEPART(WEEKDAY, GETDATE()), CONVERT(date, GETDATE()))
                       AND estado <> 'Cancelado'", conexion))
                {
                    // LTurnosSemana.Text = ((int)cmdTurnosSemana.ExecuteScalar()).ToString();
                    cmdTurnosSemana.ExecuteScalar();
                }

                using (var cmdEsp = new SqlCommand("SELECT COUNT(*) FROM Especialidad", conexion))
                    LContadorEspecialidades.Text = ((int)cmdEsp.ExecuteScalar()).ToString();

                using (var cmdDoc = new SqlCommand("SELECT COUNT(*) FROM Profesional WHERE id_estado = 1", conexion))
                    LContadorDoctores.Text = ((int)cmdDoc.ExecuteScalar()).ToString();

                LContadorPacientesHoy.Text = totalPacientes.ToString();
            }
        }

        //PANEL TURNOS DEL MES
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (pnlTurnos != null) pnlTurnos.Visible = false;

            ConfigurarGrillaTurnosMes();

            if (dgvTurnosMes != null && dgvTurnosMes.Columns.Contains("colFechaHora"))
                dgvTurnosMes.Columns["colFechaHora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            CargarMedicosMes();

            // Colorear y bloquear según estado
            dgvTurnosMes.DataBindingComplete -= dgvTurnosMes_DataBindingComplete;
            dgvTurnosMes.DataBindingComplete += dgvTurnosMes_DataBindingComplete;
        }

        private void ConfigurarGrillaTurnosMes()
        {
            if (dgvTurnosMes == null) return;

            dgvTurnosMes.ReadOnly = false;
            dgvTurnosMes.AllowUserToAddRows = false;
            dgvTurnosMes.AllowUserToDeleteRows = false;
            dgvTurnosMes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTurnosMes.MultiSelect = false;
            dgvTurnosMes.RowHeadersVisible = false;
            dgvTurnosMes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BTurnos_Click(object sender, EventArgs e)
        {
            MostrarPanelTurnos();
            CargarTurnosMes(dtpSemana.Value, GetMedicoMesSeleccionado());
        }

        private void dtpSemana_ValueChanged(object sender, EventArgs e)
        {
            if (pnlTurnos.Visible)
                CargarTurnosMes(dtpSemana.Value, GetMedicoMesSeleccionado());
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarTurnosMes(dtpSemana.Value, GetMedicoMesSeleccionado());
        }

        private void btnVolver_Click(object sender, EventArgs e) => OcultarPanelTurnos();

        private void MostrarPanelTurnos()
        {
            pnlTurnos.Visible = true;
            pnlTurnos.BringToFront();
            this.Activate();
        }

        private void OcultarPanelTurnos() => pnlTurnos.Visible = false;

        // Filtro de médico
        private void CargarMedicosMes()
        {
            using (var cn = Conexion.GetConnection())
            {
                cn.Open();
                var da = new SqlDataAdapter(
                    "SELECT 0 AS id_profesional, 'Todos los profesionales' AS Nombre " +
                    "UNION ALL " +
                    "SELECT id_profesional, (apellido + ', ' + nombre) " +
                    "FROM Profesional WHERE id_estado = 1 ORDER BY 1", cn);

                var dt = new DataTable();
                da.Fill(dt);
                cmbMedicoMes.DataSource = dt;
                cmbMedicoMes.ValueMember = "id_profesional";
                cmbMedicoMes.DisplayMember = "Nombre";
            }
        }

        private int GetMedicoMesSeleccionado()
        {
            return int.TryParse(cmbMedicoMes?.SelectedValue?.ToString(), out var id) ? id : 0;
        }

        private void cmbMedicoMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pnlTurnos.Visible)
                CargarTurnosMes(dtpSemana.Value, GetMedicoMesSeleccionado());
        }

        // Rango mensual
        private (DateTime desde, DateTime hasta) ObtenerRangoMes(DateTime d)
        {
            var desde = new DateTime(d.Year, d.Month, 1);
            var hasta = desde.AddMonths(1);
            return (desde, hasta);
        }

        // Carga mensual con filtro por médico
        private void CargarTurnosMes(DateTime referencia, int idProfesional)
        {
            var (desde, hasta) = ObtenerRangoMes(referencia);
            dgvTurnosMes.Rows.Clear();

            using (var cn = Conexion.GetConnection())
            {
                cn.Open();

                string sql = @"
SELECT 
    t.id_turno,
    t.fecha AS fechaHora,
    (pa.apellido + ', ' + pa.nombre) AS Paciente,
    (pr.apellido  + ', ' + pr.nombre) AS Profesional,
    t.motivo,
    t.estado AS Estado
FROM Turnos t
INNER JOIN Paciente pa                ON pa.id_paciente = t.id_paciente
INNER JOIN Agenda a                   ON a.id_agenda = t.id_agenda
INNER JOIN Profesional_Consultorio pc ON pc.id_profesional_consultorio = a.id_profesional_consultorio
INNER JOIN Profesional pr             ON pr.id_profesional = pc.id_profesional
WHERE t.fecha >= @desde 
  AND t.fecha <  @hasta
  AND (@idProf = 0 OR pr.id_profesional = @idProf)
ORDER BY fechaHora;";

                using (var cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);
                    cmd.Parameters.AddWithValue("@idProf", idProfesional);

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            int rowIndex = dgvTurnosMes.Rows.Add(
                                Convert.ToDateTime(rd["fechaHora"]),
                                rd["Paciente"].ToString(),
                                rd["Profesional"].ToString(),
                                rd["motivo"] == DBNull.Value ? "" : rd["motivo"].ToString(),
                                rd["Estado"] == DBNull.Value ? "" : rd["Estado"].ToString(),
                                "Editar",
                                "Cancelar"
                            );
                            dgvTurnosMes.Rows[rowIndex].Tag = Convert.ToInt32(rd["id_turno"]);
                        }
                    }
                }
            }

            // refrescar colores/estados
            dgvTurnosMes_DataBindingComplete(null, null);
        }

        //desactivar botones según estado
        private void dgvTurnosMes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvTurnosMes.Rows)
            {
                string estado = (row.Cells["colEstado"].Value ?? "").ToString().Trim();

                bool cancelado = estado.Equals("Cancelado", StringComparison.OrdinalIgnoreCase);
                bool confirmado = estado.Equals("Confirmado", StringComparison.OrdinalIgnoreCase);
                bool pendiente = estado.Equals("Pendiente", StringComparison.OrdinalIgnoreCase);

                // Colores: rojo / amarillo / verde
                if (cancelado) row.DefaultCellStyle.BackColor = Color.LightCoral;
                else if (pendiente) row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                else if (confirmado) row.DefaultCellStyle.BackColor = Color.PaleGreen;
                else row.DefaultCellStyle.BackColor = Color.White;

                var cEditar = row.Cells["colEditar"] as DataGridViewButtonCell;
                var cCanc = row.Cells["colCancelar"] as DataGridViewButtonCell;

                // Bloquear ambos botones si está CANCELADO o CONFIRMADO
                bool bloquear = cancelado || confirmado;

                if (cEditar != null)
                {
                    cEditar.ReadOnly = bloquear;
                    cEditar.Style.BackColor = bloquear ? Color.Gainsboro : Color.White;
                    cEditar.FlatStyle = FlatStyle.Flat;
                }

                if (cCanc != null)
                {
                    cCanc.ReadOnly = bloquear;
                    cCanc.Style.BackColor = bloquear ? Color.Gainsboro : Color.White;
                    cCanc.FlatStyle = FlatStyle.Flat;
                }
            }
        }


        // Acciones: Editar / Cancelar / Reprogramar
        private void dgvTurnosMes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string col = dgvTurnosMes.Columns[e.ColumnIndex].Name;
            if (col != "colEditar" && col != "colCancelar") return;

            var row = dgvTurnosMes.Rows[e.RowIndex];
            int idTurno = (int)row.Tag;

            DateTime fechaHora = Convert.ToDateTime(row.Cells["colFechaHora"].Value);
            string estado = row.Cells["colEstado"].Value?.ToString() ?? "Pendiente";

            // Bloqueo total: Cancelado o Confirmado no permiten ninguna acción
            if (estado.Equals("Cancelado", StringComparison.OrdinalIgnoreCase) ||
                estado.Equals("Confirmado", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"No se pueden realizar acciones sobre un turno {estado.ToLower()}.",
                                "Turnos del mes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (col == "colEditar")
            {
                if (MostrarDialogoEditarTurno(estado, row.Cells["colMotivo"].Value?.ToString() ?? "",
                                              out string nuevoEstado, out string nuevoMotivo))
                {
                    try
                    {
                        ActualizarEstadoMotivoTurnoBD(idTurno, nuevoEstado, nuevoMotivo);
                        row.Cells["colEstado"].Value = nuevoEstado;
                        row.Cells["colMotivo"].Value = nuevoMotivo;
                        dgvTurnosMes_DataBindingComplete(null, null); // refresca colores/botones
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo actualizar el turno.\n" + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return;
            }

            if (col == "colCancelar")
            {
                var r = MessageBox.Show(
                    "¿Qué deseás hacer?\n\nSí = Cancelar\nNo = Reprogramar\nCancelar = Salir",
                    "Cancelar o Reprogramar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    CancelarTurnoPlano(idTurno);
                    row.Cells["colEstado"].Value = "Cancelado";
                    dgvTurnosMes_DataBindingComplete(null, null);
                }
                else if (r == DialogResult.No)
                {
                    var nueva = PedirNuevaFechaHora(fechaHora);
                    if (nueva == null) return;

                    int idProf = ProfesionalDeFila(row.Cells["colProfesional"].Value?.ToString());
                    int? idAgenda = ObtenerIdAgendaParaHorario(idProf, nueva.Value);
                    if (idAgenda == null)
                    {
                        MessageBox.Show("El profesional no tiene agenda para ese día/horario.",
                                        "Agenda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (ExisteTurnoMismoHorario(idAgenda.Value, nueva.Value))
                    {
                        MessageBox.Show("Ya existe un turno en ese horario para esa agenda.",
                                        "Agenda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    ActualizarFechaTurnoBD(idTurno, nueva.Value, idAgenda.Value);
                    row.Cells["colFechaHora"].Value = nueva.Value;
                }
            }
        }


        //Helpers BD acciones
        private void CancelarTurnoPlano(int idTurno)
        {
            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand("UPDATE Turnos SET estado='Cancelado' WHERE id_turno=@id", cn))
            {
                cn.Open();
                cmd.Parameters.AddWithValue("@id", idTurno);
                cmd.ExecuteNonQuery();
            }
        }

        private void ActualizarEstadoMotivoTurnoBD(int idTurno, string estado, string motivo)
        {
            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand(
                "UPDATE Turnos SET estado = @estado, motivo = @motivo WHERE id_turno = @id", cn))
            {
                cn.Open();
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@motivo", (object)motivo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id", idTurno);
                cmd.ExecuteNonQuery();
            }
        }

        private void ActualizarFechaTurnoBD(int idTurno, DateTime nueva, int idAgenda)
        {
            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand(
                "UPDATE Turnos SET fecha=@fh, id_agenda=@a WHERE id_turno=@id", cn))
            {
                cn.Open();
                cmd.Parameters.AddWithValue("@fh", nueva);
                cmd.Parameters.AddWithValue("@a", idAgenda);
                cmd.Parameters.AddWithValue("@id", idTurno);
                cmd.ExecuteNonQuery();
            }
        }

        private int? ObtenerIdAgendaParaHorario(int idProfesional, DateTime fh)
        {
            var cultura = new System.Globalization.CultureInfo("es-ES");
            string dia = cultura.DateTimeFormat.GetDayName(fh.DayOfWeek).ToLower();

            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand(@"
                SELECT TOP 1 a.id_agenda
                  FROM Agenda a
                  INNER JOIN Profesional_Consultorio pc ON pc.id_profesional_consultorio = a.id_profesional_consultorio
                 WHERE pc.id_profesional = @p
                   AND LOWER(a.diaSemana) = @dia
                   AND @hora >= a.horaInicio 
                   AND @hora <= a.horaFin
                 ORDER BY a.horaInicio", cn))
            {
                cn.Open();
                cmd.Parameters.AddWithValue("@p", idProfesional);
                cmd.Parameters.AddWithValue("@dia", dia);
                cmd.Parameters.AddWithValue("@hora", fh.TimeOfDay);
                var o = cmd.ExecuteScalar();
                return (o == null || o == DBNull.Value) ? (int?)null : Convert.ToInt32(o);
            }
        }

        private bool ExisteTurnoMismoHorario(int idAgenda, DateTime fechaHora)
        {
            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT COUNT(1) FROM Turnos WHERE id_agenda=@a AND fecha=@fh AND estado <> 'Cancelado'", cn))
            {
                cn.Open();
                cmd.Parameters.AddWithValue("@a", idAgenda);
                cmd.Parameters.AddWithValue("@fh", fechaHora);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        //Diálogos
        private bool MostrarDialogoEditarTurno(string estadoActual, string motivoActual,
                                               out string nuevoEstado, out string nuevoMotivo)
        {
            nuevoEstado = estadoActual;
            nuevoMotivo = motivoActual;

            using (var f = new Form())
            {
                f.Text = "Editar turno";
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.StartPosition = FormStartPosition.CenterParent;
                f.ClientSize = new Size(420, 220);

                var lblE = new Label { Text = "Estado:", AutoSize = true, Left = 12, Top = 15 };
                var cbEstado = new ComboBox
                {
                    Left = 80,
                    Top = 10,
                    Width = 320,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                cbEstado.Items.AddRange(new[] { "Pendiente", "Confirmado", "Cancelado", "Realizado" });
                cbEstado.SelectedItem = cbEstado.Items.Contains(estadoActual) ? estadoActual : "Pendiente";

                var lblM = new Label { Text = "Motivo:", AutoSize = true, Left = 12, Top = 50 };
                var tbMotivo = new TextBox
                {
                    Left = 80,
                    Top = 48,
                    Width = 320,
                    Height = 100,
                    Multiline = true,
                    ScrollBars = ScrollBars.Vertical,
                    Text = motivoActual ?? ""
                };

                var btOk = new Button { Text = "Guardar", DialogResult = DialogResult.OK, Left = 235, Top = 160, Width = 80 };
                var btCancel = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Left = 320, Top = 160, Width = 80 };

                f.Controls.AddRange(new Control[] { lblE, cbEstado, lblM, tbMotivo, btOk, btCancel });
                f.AcceptButton = btOk; f.CancelButton = btCancel;

                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    var motivo = tbMotivo.Text.Trim();
                    if (string.IsNullOrWhiteSpace(motivo))
                    {
                        MessageBox.Show("El motivo de consulta es obligatorio.",
                                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    nuevoEstado = cbEstado.SelectedItem?.ToString() ?? "Pendiente";
                    nuevoMotivo = motivo;
                    return true;
                }
            }
            return false;
        }

        private DateTime? PedirNuevaFechaHora(DateTime valorActual)
        {
            using (var f = new Form())
            {
                f.Text = "Reprogramar";
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.StartPosition = FormStartPosition.CenterParent;
                f.ClientSize = new Size(420, 120);

                var lbl = new Label { Text = "Nueva fecha/hora (dd/MM/yyyy HH:mm):", AutoSize = true, Left = 10, Top = 10 };

                var dtp = new DateTimePicker
                {
                    Left = 10,
                    Top = 35,
                    Width = 380,
                    Format = DateTimePickerFormat.Custom,
                    CustomFormat = "dd/MM/yyyy HH:mm",
                    ShowUpDown = true,
                    Value = valorActual
                };
                dtp.ValueChanged += (s, e) =>
                {
                    var v = dtp.Value;
                    var rounded = new DateTime(v.Year, v.Month, v.Day, v.Hour, (v.Minute / 30) * 30, 0);
                    if (rounded != dtp.Value) dtp.Value = rounded;
                };

                var ok = new Button { Text = "Aceptar", DialogResult = DialogResult.OK, Left = 245, Top = 75, Width = 75 };
                var cancel = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Left = 325, Top = 75, Width = 75 };

                f.Controls.AddRange(new Control[] { lbl, dtp, ok, cancel });
                f.AcceptButton = ok; f.CancelButton = cancel;

                return f.ShowDialog(this) == DialogResult.OK ? dtp.Value : (DateTime?)null;
            }
        }

        private int ProfesionalDeFila(string profesionalApellidoNombre)
        {
            if (string.IsNullOrWhiteSpace(profesionalApellidoNombre)) return 0;

            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT TOP 1 id_profesional FROM Profesional WHERE (apellido + ', ' + nombre) = @n", cn))
            {
                cn.Open();
                cmd.Parameters.AddWithValue("@n", profesionalApellidoNombre);
                var o = cmd.ExecuteScalar();
                return (o == null || o == DBNull.Value) ? 0 : Convert.ToInt32(o);
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ReportesRecep frm = new ReportesRecep();
            frm.ShowDialog();
            this.Show();
        }
    }
}
