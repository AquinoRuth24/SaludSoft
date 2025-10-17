using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class FormAgenda : Form
    {
        private readonly Form _home;
        // Franjas base
        private readonly TimeSpan _manianaInicio = new TimeSpan(8, 0, 0);
        private readonly TimeSpan _manianaFin = new TimeSpan(11, 0, 0);
        private readonly TimeSpan _tardeInicio = new TimeSpan(16, 0, 0);
        private readonly TimeSpan _tardeFin = new TimeSpan(19, 0, 0);
        private readonly int _saltoMin = 30;

        private List<TurnoVM> _turnosDia = new List<TurnoVM>();
        private DateTime _diaSeleccionado = DateTime.Today;
        private bool _sobreturnoActivo = false;

        public FormAgenda()
        {
            InitializeComponent();

            CargarProfesionales();
            CargarConsultorios();
            CargarAgenda();

            ConfigurarDTVGAgenda();
            WireEventosAgenda();

            _diaSeleccionado = DateTime.Today;
            if (mcFecha != null) mcFecha.SetDate(_diaSeleccionado);

            CargarTurnosDelDia();
            RefrescarFranjas();

            if (DTVGAgenda != null)
                DTVGAgenda.DataBindingComplete += DTVGAgenda_DataBindingComplete;
        }

        //Datos base

        private void CargarProfesionales()
        {
            using (SqlConnection cn = Conexion.GetConnection())
            {
                cn.Open();
                string sql = @"
                    SELECT id_profesional, nombre + ' ' + apellido AS Profesional
                    FROM Profesional
                    WHERE id_estado = 1";

                var da = new SqlDataAdapter(sql, cn);
                var dt = new DataTable();
                da.Fill(dt);

                var row = dt.NewRow();
                row["id_profesional"] = 0;
                row["Profesional"] = "Todos los profesionales";
                dt.Rows.InsertAt(row, 0);

                CMBProfesionales.DataSource = dt;
                CMBProfesionales.DisplayMember = "Profesional";
                CMBProfesionales.ValueMember = "id_profesional";
            }
        }

        private void CargarConsultorios(int idProfesional = 0)
        {
            using (SqlConnection cn = Conexion.GetConnection())
            {
                cn.Open();
                string sql = @"
                    SELECT c.id_consultorio, c.descripcion AS Consultorio
                    FROM Consultorio c
                    WHERE EXISTS (
                        SELECT 1
                        FROM Profesional_Consultorio pc
                        WHERE pc.id_consultorio = c.id_consultorio
                          AND (@p = 0 OR pc.id_profesional = @p)
                    )";
                var da = new SqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@p", idProfesional);
                var dt = new DataTable();
                da.Fill(dt);
            }
        }

        private void CargarAgenda(int idProfesional = 0, int idConsultorio = 0, DateTime? fecha = null)
        {
            using (SqlConnection cn = Conexion.GetConnection())
            {
                cn.Open();
                string sql = @"
                    SELECT a.id_agenda, a.diaSemana,
                           CONVERT(varchar(5), a.horaInicio, 108) + ' - ' + CONVERT(varchar(5), a.horaFin, 108) AS Horario,
                           p.nombre + ' ' + p.apellido AS Profesional,
                           c.nroConsultorio AS NroConsultorio, c.descripcion AS Consultorio
                    FROM Agenda a
                    INNER JOIN Profesional_Consultorio pc ON a.id_profesional_consultorio = pc.id_profesional_consultorio
                    INNER JOIN Profesional p ON pc.id_profesional = p.id_profesional
                    INNER JOIN Consultorio c ON pc.id_consultorio = c.id_consultorio
                    WHERE (@p = 0 OR p.id_profesional = @p)
                      AND (@c = 0 OR c.id_consultorio = @c)
                    ORDER BY a.horaInicio";
                var da = new SqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@p", idProfesional);
                da.SelectCommand.Parameters.AddWithValue("@c", idConsultorio);
                var dt = new DataTable();
                da.Fill(dt);
            }
        }

        //Grilla

        private void ConfigurarDTVGAgenda()
        {
            DTVGAgenda.AutoGenerateColumns = false;
            DTVGAgenda.ReadOnly = true;
            DTVGAgenda.AllowUserToAddRows = false;
            DTVGAgenda.AllowUserToDeleteRows = false;
            DTVGAgenda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTVGAgenda.RowHeadersVisible = false;
            DTVGAgenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            colFechaHora.DataPropertyName = nameof(TurnoVM.FechaHora);
            colFechaHora.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            colPaciente.DataPropertyName = nameof(TurnoVM.Paciente);
            colProfesional.DataPropertyName = nameof(TurnoVM.Profesional);
            colMotivo.DataPropertyName = nameof(TurnoVM.Motivo);
            colEstado.DataPropertyName = nameof(TurnoVM.Estado);

            // Columna indicador de Sobreturno (S)
            if (!DTVGAgenda.Columns.Cast<DataGridViewColumn>().Any(c => c.Name == "colS"))
            {
                var colS = new DataGridViewTextBoxColumn
                {
                    Name = "colS",
                    HeaderText = "Sobreturno",
                    Width = 40,
                    DataPropertyName = nameof(TurnoVM.FlagSobreturno)
                };
                DTVGAgenda.Columns.Insert(0, colS);
            }

            if (!DTVGAgenda.Columns.OfType<DataGridViewButtonColumn>().Any(c => c.Name == "colEditar"))
            {
                DTVGAgenda.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "colEditar",
                    HeaderText = "Acciones",
                    Text = "Editar",
                    UseColumnTextForButtonValue = true
                });
            }
            if (!DTVGAgenda.Columns.OfType<DataGridViewButtonColumn>().Any(c => c.Name == "colCancelar"))
            {
                DTVGAgenda.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "colCancelar",
                    HeaderText = "",
                    Text = "Cancelar / Reprog.",
                    UseColumnTextForButtonValue = true
                });
            }

            DTVGAgenda.CellContentClick += DTVGAgenda_CellContentClick;
        }

        private void DTVGAgenda_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DTVGAgenda.Rows)
            {
                var estado = Convert.ToString(row.Cells["colEstado"].Value);
                bool confirmado = string.Equals(estado, "Confirmado", StringComparison.OrdinalIgnoreCase);
                bool cancelado = string.Equals(estado, "Cancelado", StringComparison.OrdinalIgnoreCase);

                var cEditar = row.Cells["colEditar"] as DataGridViewButtonCell;
                var cCancelar = row.Cells["colCancelar"] as DataGridViewButtonCell;

                //Confirmado o Cancelado -> sin acciones
                bool sinAcciones = confirmado || cancelado;
                if (cEditar != null) cEditar.ReadOnly = sinAcciones;
                if (cCancelar != null) cCancelar.ReadOnly = sinAcciones;

                // Colores informativos
                if (confirmado) row.DefaultCellStyle.BackColor = Color.Honeydew;
                else if (cancelado) row.DefaultCellStyle.BackColor = Color.MistyRose;

                // Resaltar sobreturno
                var flag = Convert.ToString(row.Cells["colS"].Value);
                if (flag == "S")
                    row.DefaultCellStyle.BackColor = row.DefaultCellStyle.BackColor == Color.Empty
                        ? Color.LemonChiffon : row.DefaultCellStyle.BackColor;
            }
        }

        private void WireEventosAgenda()
        {
            mcFecha.MaxSelectionCount = 1;
            mcFecha.DateSelected += (s, a) =>
            {
                _diaSeleccionado = a.Start.Date;
                CargarTurnosDelDia();
                RefrescarFranjas();
            };

            CMBProfesionales.SelectedIndexChanged += (s, a) =>
            {
                if (int.TryParse(CMBProfesionales.SelectedValue?.ToString(), out int idProf))
                    CargarConsultorios(idProf);

                CargarTurnosDelDia();
                RefrescarFranjas();
            };

            btSobreturno.Click += (s, a) =>
            {
                _sobreturnoActivo = !_sobreturnoActivo;
                RefrescarFranjas();
            };
        }

        //Turnos del día

        private void CargarTurnosDelDia()
        {
            int idProfesional = 0;
            int.TryParse(CMBProfesionales.SelectedValue?.ToString(), out idProfesional);

            using (SqlConnection cn = Conexion.GetConnection())
            {
                cn.Open();
                string sql = @"
                    SELECT  t.id_turno       AS IdTurno,
                            t.fecha          AS FechaHora,
                            pa.apellido + ' ' + pa.nombre AS Paciente,
                            pr.nombre + ' ' + pr.apellido AS Profesional,
                            t.motivo         AS Motivo,
                            t.estado         AS Estado
                    FROM Turnos t
                    INNER JOIN Paciente pa                ON pa.id_paciente = t.id_paciente
                    INNER JOIN Agenda a                   ON a.id_agenda = t.id_agenda
                    INNER JOIN Profesional_Consultorio pc ON pc.id_profesional_consultorio = a.id_profesional_consultorio
                    INNER JOIN Profesional pr             ON pr.id_profesional = pc.id_profesional
                    WHERE CONVERT(date, t.fecha) = @fecha
                      AND (@idProfesional = 0 OR pr.id_profesional = @idProfesional)
                    ORDER BY t.fecha";
                var da = new SqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@fecha", _diaSeleccionado.Date);
                da.SelectCommand.Parameters.AddWithValue("@idProfesional", idProfesional);

                var dt = new DataTable();
                da.Fill(dt);

                // Slots estándar del día (sin sobreturno)
                var slotsEstandar = GenerarSlotsEstandar(_diaSeleccionado).ToHashSet();

                _turnosDia = dt.AsEnumerable().Select(r =>
                {
                    var fh = r.Field<DateTime>("FechaHora");
                    bool esS = !slotsEstandar.Contains(fh);
                    return new TurnoVM
                    {
                        IdTurno = r.Field<int>("IdTurno"),
                        FechaHora = fh,
                        Paciente = r.Field<string>("Paciente"),
                        Profesional = r.Field<string>("Profesional"),
                        Motivo = r.Field<string>("Motivo"),
                        Estado = r.Field<string>("Estado"),
                        EsSobreturno = esS
                    };
                }).ToList();
            }

            DTVGAgenda.DataSource = null;
            DTVGAgenda.DataSource = _turnosDia;
        }

        //Franjas

        private static DateTime RoundUp(DateTime dt, int minutos)
        {
            var ticks = TimeSpan.FromMinutes(minutos).Ticks;
            return new DateTime(((dt.Ticks + ticks - 1) / ticks) * ticks, dt.Kind);
        }

        private IEnumerable<DateTime> GenerarSlotsEstandar(DateTime fecha)
        {
            var list = new List<DateTime>();
            void addRange(TimeSpan ini, TimeSpan fin)
            {
                for (DateTime t = fecha.Date + ini; t <= fecha.Date + fin; t = t.AddMinutes(_saltoMin))
                    list.Add(t);
            }
            addRange(_manianaInicio, _manianaFin);
            addRange(_tardeInicio, _tardeFin);
            return list;
        }

        private List<DateTime> GenerarSlots(DateTime fechaSeleccionada)
        {
            var slots = new List<DateTime>();

            void addRange(TimeSpan ini, TimeSpan fin)
            {
                DateTime desde = fechaSeleccionada.Date + ini;
                DateTime hasta = fechaSeleccionada.Date + fin;

                if (fechaSeleccionada.Date == DateTime.Today)
                {
                    var ahora = RoundUp(DateTime.Now, _saltoMin);
                    if (ahora > desde) desde = ahora;
                }

                for (DateTime t = desde; t <= hasta; t = t.AddMinutes(_saltoMin))
                    slots.Add(t);
            }

            // estándar
            foreach (var s in GenerarSlotsEstandar(fechaSeleccionada)) slots.Add(s);

            // extras de sobreturno
            if (_sobreturnoActivo)
            {
                var extras = new[]
                {
                    new TimeSpan(11,30,0),
                    new TimeSpan(12, 0,0),
                    new TimeSpan(12,30,0),
                    new TimeSpan(15,30,0),
                    new TimeSpan(19,30,0) 
                };
                foreach (var ts in extras)
                {
                    var dt = fechaSeleccionada.Date + ts;
                    if (fechaSeleccionada.Date == DateTime.Today && dt < RoundUp(DateTime.Now, _saltoMin)) continue;
                    slots.Add(dt);
                }
            }

            slots = slots.Distinct().OrderBy(x => x).ToList();

            if (!_sobreturnoActivo)
            {
                var ocupados = _turnosDia.Select(x => x.FechaHora).ToHashSet();
                slots = slots.Where(s => !ocupados.Contains(s)).ToList();
            }

            return slots;
        }

        private void RefrescarFranjas()
        {
            flpFranjas.SuspendLayout();
            flpFranjas.Controls.Clear();

            int total = 0, libres = 0;

            var slots = GenerarSlots(_diaSeleccionado);
            var ocupados = _turnosDia.Select(x => x.FechaHora).ToHashSet();

            foreach (var fh in slots)
            {
                bool ocupado = ocupados.Contains(fh);

                var b = new Button
                {
                    Text = fh.ToString("HH:mm"),
                    Tag = fh,
                    AutoSize = true,
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(6),
                    Padding = new Padding(10, 6, 10, 6),
                    BackColor = ocupado ? Color.FromArgb(233, 236, 239) : Color.White,
                    Enabled = !ocupado || _sobreturnoActivo
                };
                b.FlatAppearance.BorderSize = 0;
                b.Click += ClickFranja;

                if (!ocupado) libres++;
                total++;

                flpFranjas.Controls.Add(b);
            }

            lDisponibles.Text = $"{libres} de {total} disponibles";
            flpFranjas.ResumeLayout();
        }

        //Reserva desde franja 

        private string PedirDniSoloNumeros()
        {
            using (var f = new Form())
            {
                f.Text = "Reservar Turno";
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.StartPosition = FormStartPosition.CenterParent;
                f.ClientSize = new Size(360, 120);

                var lbl = new Label { Text = "Ingrese DNI del paciente (solo números):", AutoSize = true, Left = 10, Top = 10 };
                var tb = new TextBox { Left = 10, Top = 35, Width = 330, MaxLength = 8 };
                var ok = new Button { Text = "Aceptar", DialogResult = DialogResult.OK, Left = 185, Top = 70, Width = 75 };
                var cancel = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Left = 265, Top = 70, Width = 75 };

                tb.KeyPress += (s, e) =>
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                        e.Handled = true;
                };
                tb.TextChanged += (s, e) =>
                {
                    var solo = new string(tb.Text.Where(char.IsDigit).ToArray());
                    if (solo.Length > 8) solo = solo.Substring(0, 8);
                    if (tb.Text != solo)
                    {
                        int pos = tb.SelectionStart;
                        tb.Text = solo;
                        tb.SelectionStart = Math.Min(pos, tb.Text.Length);
                    }
                };

                f.Controls.AddRange(new Control[] { lbl, tb, ok, cancel });
                f.AcceptButton = ok; f.CancelButton = cancel;

                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    var dni = tb.Text.Trim();
                    if (dni.Length >= 7 && dni.Length <= 8) return dni;

                    MessageBox.Show("DNI inválido. Debe contener solo números (7–8 dígitos).",
                                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                return null;
            }
        }

        private void ClickFranja(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var fechaHora = (DateTime)btn.Tag;

            if (fechaHora < DateTime.Now.AddMinutes(-1))
            {
                MessageBox.Show("No podés reservar turnos en el pasado.", "Agenda",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(CMBProfesionales?.SelectedValue?.ToString(), out int idProfesional) || idProfesional == 0)
            {
                MessageBox.Show("Seleccioná un profesional antes de reservar.", "Agenda",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool ocupado = _turnosDia.Any(x => x.FechaHora == fechaHora);
            if (ocupado && !_sobreturnoActivo)
            {
                MessageBox.Show("Ese horario ya está ocupado. Activá 'Sobreturno' para superponer.", "Agenda",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // DNI
            string dni = null;
            do
            {
                dni = PedirDniSoloNumeros();
                if (dni == null)
                {
                    if (MessageBox.Show("¿Cancelar reserva?", "Agenda",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        return;
                }
            } while (dni == null);

            int? idPaciente = GetPacienteIdPorDni(dni);
            if (idPaciente == null)
            {
                var r = MessageBox.Show("No existe un paciente con ese DNI.\n¿Deseás registrarlo ahora?",
                                        "Paciente no encontrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    using (var frm = new FormPaciente())
                    {
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog(this);
                    }
                    idPaciente = GetPacienteIdPorDni(dni);
                    if (idPaciente == null)
                    {
                        MessageBox.Show("El paciente aún no existe. No se puede reservar el turno.", "Agenda",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else return;
            }

            // id_agenda para el día; si hay sobreturno permitimos hasta +30 min del fin
            int? idAgenda = ObtenerIdAgendaParaHorario(idProfesional, fechaHora, _sobreturnoActivo);
            if (idAgenda == null)
            {
                MessageBox.Show("El profesional no tiene agenda para ese día/horario.", "Agenda",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_sobreturnoActivo && ExisteTurnoMismoHorario(idAgenda.Value, fechaHora))
            {
                MessageBox.Show("Ya existe un turno en ese horario para esa agenda.", "Agenda",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                InsertarTurnoBD(idAgenda.Value, idPaciente.Value, fechaHora);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el turno.\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CargarTurnosDelDia();
            RefrescarFranjas();
            MessageBox.Show("Turno reservado correctamente.", "Agenda",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Acciones editar / cancelar

        private void DTVGAgenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var col = DTVGAgenda.Columns[e.ColumnIndex].Name;
            if (col != "colEditar" && col != "colCancelar") return;

            var turno = (TurnoVM)DTVGAgenda.Rows[e.RowIndex].DataBoundItem;
            bool confirmado = string.Equals(turno.Estado, "Confirmado", StringComparison.OrdinalIgnoreCase);
            bool cancelado = string.Equals(turno.Estado, "Cancelado", StringComparison.OrdinalIgnoreCase);

            //Acciones deshabilitadas
            if (confirmado || cancelado)
            {
                MessageBox.Show("No se puede realizar acciones sobre un turno " + (confirmado ? "confirmado" : "cancelado") + ".",
                                "Agenda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (col == "colEditar")
            {
                if (MostrarDialogoEditarTurno(turno, out string nuevoEstado, out string nuevoMotivo))
                {
                    try
                    {
                        ActualizarEstadoMotivoTurnoBD(turno.IdTurno, nuevoEstado, nuevoMotivo);
                        turno.Estado = nuevoEstado;
                        turno.Motivo = nuevoMotivo;
                        DTVGAgenda.Refresh();
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
                var r = MessageBox.Show("¿Qué deseás hacer?\n\nSí = Cancelar\nNo = Reprogramar\nCancelar = Salir",
                    "Cancelar o Reprogramar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    using (var cn = Conexion.GetConnection())
                    using (var cmd = new SqlCommand("UPDATE Turnos SET estado='Cancelado' WHERE id_turno=@id", cn))
                    {
                        cn.Open();
                        cmd.Parameters.AddWithValue("@id", turno.IdTurno);
                        cmd.ExecuteNonQuery();
                    }
                    turno.Estado = "Cancelado";
                    DTVGAgenda.Refresh();
                    RefrescarFranjas();
                }
                else if (r == DialogResult.No)
                {
                    var nueva = PedirNuevaFechaHora(turno.FechaHora);
                    if (nueva == null) return;

                    int idProf = ObtenerProfesionalSeleccionadoId();
                    int? idAgenda = ObtenerIdAgendaParaHorario(idProf, nueva.Value, _sobreturnoActivo);
                    if (idAgenda == null)
                    {
                        MessageBox.Show("El profesional no tiene agenda para ese día/horario.", "Agenda",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!_sobreturnoActivo && ExisteTurnoMismoHorario(idAgenda.Value, nueva.Value))
                    {
                        MessageBox.Show("Ya existe un turno en ese horario para esa agenda.",
                                        "Agenda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    ActualizarFechaTurnoBD(turno.IdTurno, nueva.Value);
                    turno.FechaHora = nueva.Value;
                    DTVGAgenda.Refresh();
                    CargarTurnosDelDia();
                    RefrescarFranjas();
                }
            }
        }

        private int ObtenerProfesionalSeleccionadoId()
        {
            return int.TryParse(CMBProfesionales?.SelectedValue?.ToString(), out int id) ? id : 0;
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
                    var rounded = new DateTime(v.Year, v.Month, v.Day, v.Hour, v.Minute / 30 * 30, 0);
                    if (rounded != dtp.Value) dtp.Value = rounded;
                };

                var ok = new Button { Text = "Aceptar", DialogResult = DialogResult.OK, Left = 245, Top = 75, Width = 75 };
                var cancel = new Button { Text = "Cancelar", DialogResult = DialogResult.Cancel, Left = 325, Top = 75, Width = 75 };

                f.Controls.AddRange(new Control[] { lbl, dtp, ok, cancel });
                f.AcceptButton = ok; f.CancelButton = cancel;

                return f.ShowDialog(this) == DialogResult.OK ? dtp.Value : (DateTime?)null;
            }
        }

        //Helpers BD 

        private int? GetPacienteIdPorDni(string dni)
        {
            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand("SELECT id_paciente FROM Paciente WHERE dni=@dni", cn))
            {
                cn.Open();
                cmd.Parameters.AddWithValue("@dni", dni);
                object res = cmd.ExecuteScalar();
                return (res == null || res == DBNull.Value) ? (int?)null : Convert.ToInt32(res);
            }
        }

        // Permitir sobreturno hasta +30 min del fin
        private int? ObtenerIdAgendaParaHorario(int idProfesional, DateTime fh, bool permitirSobreturno)
        {
            var cultura = new CultureInfo("es-ES");
            string dia = cultura.DateTimeFormat.GetDayName(fh.DayOfWeek).ToLower();
            int extra = permitirSobreturno ? 30 : 0; // extensión de ventana

            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand(@"
                SELECT TOP 1 a.id_agenda
                FROM Agenda a
                INNER JOIN Profesional_Consultorio pc ON pc.id_profesional_consultorio = a.id_profesional_consultorio
                WHERE pc.id_profesional = @p
                  AND LOWER(a.diaSemana) = @dia
                  AND @hora >= a.horaInicio 
                  AND @hora <= DATEADD(minute, @extra, a.horaFin)
                ORDER BY a.horaInicio", cn))
            {
                cn.Open();
                cmd.Parameters.AddWithValue("@p", idProfesional);
                cmd.Parameters.AddWithValue("@dia", dia);
                cmd.Parameters.AddWithValue("@hora", fh.TimeOfDay);
                cmd.Parameters.AddWithValue("@extra", extra);
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

        private void InsertarTurnoBD(int idAgenda, int idPaciente, DateTime fh)
        {
            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand(@"
                INSERT INTO Turnos (id_agenda, id_paciente, fecha, motivo, estado)
                VALUES (@a, @pac, @fh, NULL, 'Pendiente')", cn))
            {
                cn.Open();
                cmd.Parameters.AddWithValue("@a", idAgenda);
                cmd.Parameters.AddWithValue("@pac", idPaciente);
                cmd.Parameters.AddWithValue("@fh", fh);
                cmd.ExecuteNonQuery();
            }
        }

        private void ActualizarFechaTurnoBD(int idTurno, DateTime nueva)
        {
            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand("UPDATE Turnos SET fecha=@fh WHERE id_turno=@id", cn))
            {
                cn.Open();
                cmd.Parameters.AddWithValue("@fh", nueva);
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
                cmd.Parameters.AddWithValue("@motivo", motivo);
                cmd.Parameters.AddWithValue("@id", idTurno);
                cmd.ExecuteNonQuery();
            }
        }

        //Diálogo de edición (estado + motivo)

        private bool MostrarDialogoEditarTurno(TurnoVM turno, out string nuevoEstado, out string nuevoMotivo)
        {
            nuevoEstado = turno.Estado;
            nuevoMotivo = turno.Motivo;

            using (var f = new Form())
            {
                f.Text = "Editar turno";
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.StartPosition = FormStartPosition.CenterParent;
                f.ClientSize = new Size(420, 220);
                f.MinimizeBox = false; f.MaximizeBox = false;

                var lblE = new Label { Text = "Estado:", AutoSize = true, Left = 12, Top = 15 };
                var cbEstado = new ComboBox
                {
                    Left = 80,
                    Top = 10,
                    Width = 320,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                cbEstado.Items.AddRange(new[] { "Pendiente", "Confirmado", "Cancelado", "Realizado" });
                cbEstado.SelectedItem = (cbEstado.Items.Contains(turno.Estado) ? turno.Estado : "Pendiente");

                var lblM = new Label { Text = "Motivo:", AutoSize = true, Left = 12, Top = 50 };
                var tbMotivo = new TextBox
                {
                    Left = 80,
                    Top = 48,
                    Width = 320,
                    Height = 100,
                    Multiline = true,
                    ScrollBars = ScrollBars.Vertical,
                    Text = turno.Motivo ?? ""
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

        //Botones

        private void BVolverAgenda_Click(object sender, EventArgs e)
        {
            if (_home != null && !_home.IsDisposed) _home.Show();
            this.Close();
        }
        private void BBuscar_Click_1(object sender, EventArgs e) { }
        private void gbSeleccionarFecha_Enter(object sender, EventArgs e) { }
        private void btSobreturno_Click(object sender, EventArgs e) { }
    }

    public class TurnoVM
    {
        public int IdTurno { get; set; }
        public DateTime FechaHora { get; set; }
        public string Paciente { get; set; }
        public string Profesional { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }

        // Marcador de Sobreturno para la grilla
        public bool EsSobreturno { get; set; }
        public string FlagSobreturno => EsSobreturno ? "S" : "";
    }
}
