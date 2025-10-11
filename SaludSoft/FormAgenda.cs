using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;   // Interaction.InputBox
// using SaludSoft.Resources; // ← ya no hace falta si solo se usaba para FormUsuario

namespace SaludSoft
{
    /// <summary>
    /// Agenda de turnos:
    /// - Filtro por profesional (opcional consultorio).
    /// - Calendario diario con franjas horarias (08:00–18:30, paso 30').
    /// - Botón de “Sobreturno” para habilitar 12:00, 12:30 y 19:00 y permitir superposiciones.
    /// - Alta rápida desde franja (DNI → buscar/crear paciente → motivo → guardar).
    /// - Edición/cancelación/reprogramación desde grilla.
    /// </summary>
    public partial class FormAgenda : Form
    {
        // ====== CAMPOS ======

        // Franja base 08:00–18:30 cada 30'
        private readonly TimeSpan _inicio = new TimeSpan(8, 0, 0);
        private readonly TimeSpan _fin = new TimeSpan(18, 30, 0);
        private readonly int _saltoMin = 30;

        // Turnos del día seleccionado
        private List<TurnoVM> _turnosDia = new List<TurnoVM>();

        // Fecha seleccionada en el calendario
        private DateTime _diaSeleccionado = DateTime.Today;

        // Si true, habilita sobreturno y muestra franjas extra
        private bool _sobreturnoActivo = false;

        // ====== CTOR ======
        public FormAgenda()
        {
            InitializeComponent();

            // Datos base
            CargarProfesionales();
            CargarConsultorios();   // opcional, si tu UI usa consultorios
            CargarAgenda();         // disponibilidad (referencia/visual)

            // UI turnos
            ConfigurarDTVGAgenda();
            WireEventosAgenda();

            _diaSeleccionado = DateTime.Today;
            if (mcFecha != null) mcFecha.SetDate(_diaSeleccionado);

            CargarTurnosDelDia();
            RefrescarFranjas();
        }

        // ====== CARGAS INICIALES ======

        /// <summary>Carga el combo de profesionales (agrega “Todos”).</summary>
        private void CargarProfesionales()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                string query = @"
                    SELECT id_profesional, nombre + ' ' + apellido AS Profesional
                    FROM Profesional
                    WHERE id_estado = 1";

                var da = new SqlDataAdapter(query, conexion);
                var dt = new DataTable();
                da.Fill(dt);

                var row = dt.NewRow();
                row["id_profesional"] = 0;
                row["Profesional"] = "Todos los profesionales";
                dt.Rows.InsertAt(row, 0);

                if (CMBProfesionales != null)
                {
                    CMBProfesionales.DataSource = dt;
                    CMBProfesionales.DisplayMember = "Profesional";
                    CMBProfesionales.ValueMember = "id_profesional";
                }
            }
        }

        //Carga consultorios asociados al profesional 
        private void CargarConsultorios(int idProfesional = 0)
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                string query = @"
                    SELECT c.id_consultorio, c.descripcion AS Consultorio
                    FROM Consultorio c
                    WHERE EXISTS (
                        SELECT 1
                        FROM Profesional_Consultorio pc
                        WHERE pc.id_consultorio = c.id_consultorio
                          AND (@idProfesional = 0 OR pc.id_profesional = @idProfesional)
                    )";

                var da = new SqlDataAdapter(query, conexion);
                da.SelectCommand.Parameters.AddWithValue("@idProfesional", idProfesional);
                var dt = new DataTable();
                da.Fill(dt);
            }
        }

        //Consulta disponibilidad general 
        private void CargarAgenda(int idProfesional = 0, int idConsultorio = 0, DateTime? fecha = null)
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                string query = @"
                    SELECT a.id_agenda, a.diaSemana AS Disponibilidad,
                           CONVERT(varchar(5), a.horaInicio, 108) + ' - ' + CONVERT(varchar(5), a.horaFin, 108) AS Horario,
                           u.nombre + ' ' + u.apellido AS Recepcionista,
                           p.nombre + ' ' + p.apellido AS Profesional,
                           c.nroConsultorio AS [Nro Consultorio],
                           c.descripcion AS Consultorio
                    FROM Agenda a
                    INNER JOIN Usuario u ON a.id_usuario = u.id_usuario
                    INNER JOIN Profesional_Consultorio pc ON a.id_profesional_consultorio = pc.id_profesional_consultorio
                    INNER JOIN Profesional p ON pc.id_profesional = p.id_profesional
                    INNER JOIN Consultorio c ON pc.id_consultorio = c.id_consultorio
                    WHERE (@idProfesional = 0 OR p.id_profesional = @idProfesional)
                      AND (@idConsultorio = 0 OR c.id_consultorio = @idConsultorio)
                    ORDER BY a.horaInicio";

                var da = new SqlDataAdapter(query, conexion);
                da.SelectCommand.Parameters.AddWithValue("@idProfesional", idProfesional);
                da.SelectCommand.Parameters.AddWithValue("@idConsultorio", idConsultorio);
                da.SelectCommand.Parameters.AddWithValue("@fecha", (object)fecha ?? DBNull.Value);

                var dt = new DataTable();
                da.Fill(dt);
                // Si querés mostrarlo en alguna grilla, bindealo acá.
            }
        }

        // ====== GRILLA DE TURNOS ======

        /// <summary>Configura la grilla de agenda y agrega columnas de acción.</summary>
        private void ConfigurarDTVGAgenda()
        {
            if (DTVGAgenda == null) return;

            DTVGAgenda.AutoGenerateColumns = false;
            DTVGAgenda.ReadOnly = true;
            DTVGAgenda.AllowUserToAddRows = false;
            DTVGAgenda.AllowUserToDeleteRows = false;
            DTVGAgenda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTVGAgenda.RowHeadersVisible = false;
            DTVGAgenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DTVGAgenda.EnableHeadersVisualStyles = false;

            // Mapear columnas existentes en el diseñador
            if (colFechaHora != null)
            {
                colFechaHora.DataPropertyName = nameof(TurnoVM.FechaHora);
                colFechaHora.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (colPaciente != null) colPaciente.DataPropertyName = nameof(TurnoVM.Paciente);
            if (colProfesional != null) colProfesional.DataPropertyName = nameof(TurnoVM.Profesional);
            if (colMotivo != null) colMotivo.DataPropertyName = nameof(TurnoVM.Motivo);
            if (colEstado != null) colEstado.DataPropertyName = nameof(TurnoVM.Estado);

            // Botones de acción (si no existen)
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
                    Text = "Cancelar",
                    UseColumnTextForButtonValue = true
                });
            }

            DTVGAgenda.CellContentClick += DTVGAgenda_CellContentClick;
        }

        /// <summary>Une eventos de calendario, combos y botón Sobreturno.</summary>
        private void WireEventosAgenda()
        {
            if (mcFecha != null)
            {
                mcFecha.MaxSelectionCount = 1;
                mcFecha.DateSelected += (s, a) =>
                {
                    _diaSeleccionado = a.Start.Date;
                    CargarTurnosDelDia();
                    RefrescarFranjas();
                };
            }

            if (CMBProfesionales != null)
            {
                CMBProfesionales.SelectedIndexChanged += (s, a) =>
                {
                    if (int.TryParse(CMBProfesionales.SelectedValue?.ToString(), out int idProf))
                        CargarConsultorios(idProf);

                    CargarTurnosDelDia();
                    RefrescarFranjas();
                };
            }

            if (btSobreturno != null)
            {
                btSobreturno.Click += (s, a) =>
                {
                    _sobreturnoActivo = !_sobreturnoActivo;
                    btSobreturno.Text = "Sobreturno"; // texto fijo
                    RefrescarFranjas();
                };
            }
        }

        /// <summary>Carga los turnos del día según profesional seleccionado.</summary>
        private void CargarTurnosDelDia()
        {
            int idProfesional = 0;
            if (CMBProfesionales != null)
                int.TryParse(CMBProfesionales.SelectedValue?.ToString(), out idProfesional);

            try
            {
                using (SqlConnection conexion = Conexion.GetConnection())
                {
                    conexion.Open();
                    string sql = @"
                        SELECT  t.id_turno AS IdTurno,
                                t.fecha_hora AS FechaHora,
                                pa.apellido + ' ' + pa.nombre AS Paciente,
                                pr.nombre + ' ' + pr.apellido AS Profesional,
                                t.motivo AS Motivo,
                                t.estado AS Estado
                        FROM Turno t
                        INNER JOIN Paciente pa    ON pa.id_paciente = t.id_paciente
                        INNER JOIN Profesional pr ON pr.id_profesional = t.id_profesional
                        WHERE CAST(t.fecha_hora AS date) = @fecha
                          AND (@idProfesional = 0 OR t.id_profesional = @idProfesional)
                        ORDER BY t.fecha_hora";

                    var da = new SqlDataAdapter(sql, conexion);
                    da.SelectCommand.Parameters.AddWithValue("@fecha", _diaSeleccionado.Date);
                    da.SelectCommand.Parameters.AddWithValue("@idProfesional", idProfesional);

                    var dt = new DataTable();
                    da.Fill(dt);

                    _turnosDia = dt.AsEnumerable().Select(r => new TurnoVM
                    {
                        IdTurno = r.Field<int>("IdTurno"),
                        FechaHora = r.Field<DateTime>("FechaHora"),
                        Paciente = r.Field<string>("Paciente"),
                        Profesional = r.Field<string>("Profesional"),
                        Motivo = r.Field<string>("Motivo"),
                        Estado = r.Field<string>("Estado")
                    }).ToList();
                }
            }
            catch
            {
                // Datos mock si la BD no está disponible
                var d = _diaSeleccionado.Date;
                string profTxt = CMBProfesionales?.Text ?? "Profesional";
                _turnosDia = new List<TurnoVM>
                {
                    new TurnoVM{ IdTurno=1, FechaHora=d.AddHours(8),   Paciente="Juan Pérez",  Profesional=profTxt, Motivo="Control", Estado="Confirmado" },
                    new TurnoVM{ IdTurno=2, FechaHora=d.AddHours(9.5), Paciente="María Gómez", Profesional=profTxt, Motivo="Dolor",   Estado="Pendiente" }
                };
            }

            if (DTVGAgenda != null)
            {
                DTVGAgenda.DataSource = null;
                DTVGAgenda.DataSource = _turnosDia;
            }
        }

        // ====== FRANJAS HORARIAS ======

        /// <summary>
        /// Dibuja los botones de franjas:
        /// - Base: 08:00–18:30 cada 30' (sin 12:00 ni 12:30).
        /// - Sobreturno ON: agrega 12:00, 12:30 y 19:00 y permite superposición.
        /// </summary>
        private void RefrescarFranjas()
        {
            if (flpFranjas == null) return;

            flpFranjas.SuspendLayout();
            flpFranjas.Controls.Clear();

            int total = 0, libres = 0;

            // Base sin 12:00 / 12:30
            for (var t = _inicio; t <= _fin; t = t.Add(TimeSpan.FromMinutes(_saltoMin)))
            {
                if (t == new TimeSpan(12, 0, 0) || t == new TimeSpan(12, 30, 0)) continue;
                AgregarBotonFranja(t, false, ref total, ref libres);
            }

            // Extras de sobreturno
            if (_sobreturnoActivo)
            {
                AgregarBotonFranja(new TimeSpan(12, 0, 0), true, ref total, ref libres);
                AgregarBotonFranja(new TimeSpan(12, 30, 0), true, ref total, ref libres);
                AgregarBotonFranja(new TimeSpan(19, 0, 0), true, ref total, ref libres);
            }

            if (lDisponibles != null)
                lDisponibles.Text = $"{libres} de {total} disponibles";

            flpFranjas.ResumeLayout();
        }

        /// <summary>Crea un botón para una hora dada y lo agrega al FlowLayoutPanel.</summary>
        private void AgregarBotonFranja(TimeSpan hora, bool esExtraSobreturno, ref int total, ref int libres)
        {
            if (flpFranjas == null) return;

            total++;

            var fh = _diaSeleccionado.Date + hora;
            bool ocupado = _turnosDia.Any(x => x.FechaHora.Hour == fh.Hour && x.FechaHora.Minute == fh.Minute);

            var b = new Button
            {
                Text = fh.ToString("HH:mm") + (esExtraSobreturno ? " •SOB" : ""),
                Tag = fh,
                AutoSize = true,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(6),
                Padding = new Padding(10, 6, 10, 6),
                BackColor = ocupado ? Color.FromArgb(233, 236, 239)
                                    : (esExtraSobreturno ? Color.WhiteSmoke : Color.White),
                // En base: si está ocupado, habilitar solo con sobreturno; en extras permitir superposición
                Enabled = !ocupado || _sobreturnoActivo
            };
            b.FlatAppearance.BorderSize = 0;
            b.Click += ClickFranja;

            if (!ocupado) libres++;
            flpFranjas.Controls.Add(b);
        }

        // ====== ALTA DESDE FRANJA ======

        /// <summary>
        /// Click en una franja: pide DNI, valida/crea paciente (abre FormPaciente si no existe),
        /// pide motivo y registra el turno (evita duplicados salvo sobreturno).
        /// </summary>
        private void ClickFranja(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var fechaHora = (DateTime)btn.Tag;

            // No reservar en el pasado (tolerancia 1 min)
            if (fechaHora < DateTime.Now.AddMinutes(-1))
            {
                MessageBox.Show("No podés reservar turnos en el pasado.", "Agenda",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Profesional seleccionado
            if (!int.TryParse(CMBProfesionales?.SelectedValue?.ToString(), out int idProfesional) || idProfesional == 0)
            {
                MessageBox.Show("Seleccioná un profesional antes de reservar.", "Agenda",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Si el horario está ocupado y no hay sobreturno → bloquear
            bool ocupado = _turnosDia.Any(x => x.FechaHora == fechaHora);
            if (ocupado && !_sobreturnoActivo)
            {
                MessageBox.Show("Ese horario ya está ocupado. Activá 'Sobreturno' para superponer.", "Agenda",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // DNI
            string dni = Interaction.InputBox("Ingrese DNI del paciente (solo números):", "Reservar Turno", "");
            if (!EsDniValido(dni))
            {
                MessageBox.Show("DNI inválido. Debe contener solo números (7–9 dígitos).", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar paciente; si no existe, abrir FormPaciente (no FormUsuario)
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

                    // Reintentar búsqueda
                    idPaciente = GetPacienteIdPorDni(dni);
                    if (idPaciente == null)
                    {
                        MessageBox.Show("El paciente aún no existe. No se puede reservar el turno.", "Agenda",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    return; // canceló alta
                }
            }

            // Motivo
            string motivo = Interaction.InputBox("Motivo de la consulta:", "Reservar Turno", "");
            if (string.IsNullOrWhiteSpace(motivo) || motivo.Trim().Length < 3)
            {
                MessageBox.Show("Ingresá un motivo válido (al menos 3 caracteres).", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Evitar duplicado exacto si no hay sobreturno
            if (!_sobreturnoActivo && ExisteTurnoMismoHorario(idProfesional, fechaHora))
            {
                MessageBox.Show("Ese profesional ya tiene un turno en ese horario.", "Agenda",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Guardar
            try
            {
                InsertarTurnoBD(idProfesional, idPaciente.Value, fechaHora, motivo, _sobreturnoActivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el turno.\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Refrescar UI
            CargarTurnosDelDia();
            RefrescarFranjas();
            MessageBox.Show("Turno reservado correctamente.", "Agenda",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ====== ACCIONES DE LA GRILLA ======

        /// <summary>Editar estado/motivo o cancelar/reprogramar desde la grilla.</summary>
        private void DTVGAgenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || DTVGAgenda == null) return;

            var colName = DTVGAgenda.Columns[e.ColumnIndex].Name;
            if (colName != "colEditar" && colName != "colCancelar") return;

            var turno = (TurnoVM)DTVGAgenda.Rows[e.RowIndex].DataBoundItem;

            if (colName == "colEditar")
            {
                string nuevoMotivo = Interaction.InputBox("Motivo:", "Editar Turno", turno.Motivo);
                if (!string.IsNullOrWhiteSpace(nuevoMotivo)) turno.Motivo = nuevoMotivo;

                string nuevoEstado = Interaction.InputBox(
                    "Estado (Pendiente/Confirmado/EnCurso/Completado/Cancelado/Ausente):",
                    "Editar Turno", turno.Estado);
                if (!string.IsNullOrWhiteSpace(nuevoEstado)) turno.Estado = nuevoEstado;

                // TODO: UPDATE a BD (id_turno = turno.IdTurno)
                DTVGAgenda.Refresh();
            }
            else if (colName == "colCancelar")
            {
                var r = MessageBox.Show("¿Querés cancelar este turno?\n\nSí = Cancelar\nNo = Reprogramar\nCancelar = Salir",
                    "Cancelar o Reprogramar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    // TODO: UPDATE estado='Cancelado'
                    turno.Estado = "Cancelado";
                    DTVGAgenda.Refresh();
                    RefrescarFranjas();
                }
                else if (r == DialogResult.No)
                {
                    var input = Interaction.InputBox("Nueva fecha/hora (dd/MM/yyyy HH:mm):",
                        "Reprogramar", _diaSeleccionado.ToString("dd/MM/yyyy ") + "10:00");

                    if (DateTime.TryParse(input, out DateTime nueva))
                    {
                        // TODO: UPDATE fecha_hora en BD
                        turno.FechaHora = nueva;
                        DTVGAgenda.Refresh();
                        CargarTurnosDelDia();
                        RefrescarFranjas();
                    }
                }
            }
        }

        // ====== BOTONES EXISTENTES (si están en el diseñador) ======
        private void BVolverAgenda_Click(object sender, EventArgs e) => this.Close();
        private void BBuscar_Click_1(object sender, EventArgs e) { }
        private void gbSeleccionarFecha_Enter(object sender, EventArgs e) { }
        private void btSobreturno_Click(object sender, EventArgs e) { }

        // ====== HELPERS VALIDACIÓN/BD ======

        /// <summary>Valida formato de DNI (numérico de 7 a 9 dígitos).</summary>
        private bool EsDniValido(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return false;
            if (!dni.All(char.IsDigit)) return false;
            return dni.Length >= 7 && dni.Length <= 9;
        }

        /// <summary>Devuelve id_paciente por DNI o null si no existe.</summary>
        private int? GetPacienteIdPorDni(string dni)
        {
            using (var cn = Conexion.GetConnection())
            {
                cn.Open();
                using (var cmd = new SqlCommand("SELECT id_paciente FROM Paciente WHERE dni=@dni", cn))
                {
                    cmd.Parameters.AddWithValue("@dni", dni);
                    object res = cmd.ExecuteScalar();
                    if (res == null || res == DBNull.Value) return null;
                    return Convert.ToInt32(res);
                }
            }
        }

        /// <summary>
        /// True si ya hay un turno para el mismo profesional en esa fecha/hora (excluye cancelados).
        /// </summary>
        private bool ExisteTurnoMismoHorario(int idProfesional, DateTime fechaHora)
        {
            using (var cn = Conexion.GetConnection())
            {
                cn.Open();
                using (var cmd = new SqlCommand(
                    "SELECT COUNT(1) FROM Turno WHERE id_profesional=@p AND fecha_hora=@fh AND estado <> 'Cancelado'", cn))
                {
                    cmd.Parameters.AddWithValue("@p", idProfesional);
                    cmd.Parameters.AddWithValue("@fh", fechaHora);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        /// <summary>Inserta el turno en la base de datos.</summary>
        private void InsertarTurnoBD(int idProfesional, int idPaciente, DateTime fh, string motivo, bool esSobreturno)
        {
            using (var cn = Conexion.GetConnection())
            {
                cn.Open();
                using (var cmd = new SqlCommand(@"
                    INSERT INTO Turno (id_profesional, id_paciente, fecha_hora, motivo, estado, es_sobreturno)
                    VALUES (@prof, @pac, @fh, @motivo, 'Confirmado', @sob)", cn))
                {
                    cmd.Parameters.AddWithValue("@prof", idProfesional);
                    cmd.Parameters.AddWithValue("@pac", idPaciente);
                    cmd.Parameters.AddWithValue("@fh", fh);
                    cmd.Parameters.AddWithValue("@motivo", motivo);
                    cmd.Parameters.AddWithValue("@sob", esSobreturno);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    // ====== VIEWMODEL PARA LA GRILLA ======

    /// <summary>Modelo de datos para mostrar turnos en la grilla.</summary>
    public class TurnoVM
    {
        public int IdTurno { get; set; }
        public DateTime FechaHora { get; set; }
        public string Paciente { get; set; }
        public string Profesional { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }
    }
}
