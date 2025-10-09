using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic; // Opción A: para Interaction.InputBox

namespace SaludSoft
{
    public partial class FormAgenda : Form
    {
        // ===== Campos internos =====
        private readonly TimeSpan _inicio = new TimeSpan(8, 0, 0);
        private readonly TimeSpan _fin = new TimeSpan(18, 30, 0);
        private readonly int _saltoMin = 30;

        private List<TurnoVM> _turnosDia = new List<TurnoVM>();
        private DateTime _diaSeleccionado = DateTime.Today;
        private bool _sobreturnoActivo = false;

        public FormAgenda()
        {
            InitializeComponent();

            // Tuyo
            CargarProfesionales();
            CargarConsultorios();
            CargarAgenda();

            // Agenda de turnos (UI + eventos)
            ConfigurarDTVGAgenda();
            WireEventosAgenda();

            _diaSeleccionado = DateTime.Today;
            mcFecha.SetDate(_diaSeleccionado);

            CargarTurnosDelDia();
            RefrescarFranjas();
        }

        // =================== TUS MÉTODOS (ajustados) ===================
        private void CargarProfesionales()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                string query = @"SELECT id_profesional, nombre + ' ' + apellido AS Profesional 
                                 FROM Profesional 
                                 WHERE id_estado = 1";

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow row = dt.NewRow();
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
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                string query = @"SELECT c.id_consultorio, c.descripcion AS Consultorio
                                 FROM Consultorio c
                                 WHERE EXISTS (
                                    SELECT 1 FROM Profesional_Consultorio pc 
                                    WHERE pc.id_consultorio = c.id_consultorio
                                    AND (@idProfesional = 0 OR pc.id_profesional = @idProfesional)
                                 )";

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.SelectCommand.Parameters.AddWithValue("@idProfesional", idProfesional);

                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow row = dt.NewRow();
                row["id_consultorio"] = 0;
                row["Consultorio"] = "Todos los consultorios";
                dt.Rows.InsertAt(row, 0);

                // Si tenés combo de consultorios, asignalo acá:
                // CMBConsultorios.DataSource = dt;
                // CMBConsultorios.DisplayMember = "Consultorio";
                // CMBConsultorios.ValueMember = "id_consultorio";
            }
        }

        private void CargarAgenda(int idProfesional = 0, int idConsultorio = 0, DateTime? fecha = null)
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                string query = @"
                 SELECT 
                  a.id_agenda, 
                  a.diaSemana AS Disponibilidad,
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

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.SelectCommand.Parameters.AddWithValue("@idProfesional", idProfesional);
                da.SelectCommand.Parameters.AddWithValue("@idConsultorio", idConsultorio);
                da.SelectCommand.Parameters.AddWithValue("@fecha", (object)fecha ?? DBNull.Value);

                DataTable dt = new DataTable();
                da.Fill(dt);
                // (Disponibilidad) — si luego querés mostrarla, acá la tenés en dt.
            }
        }

        // =================== GRID DE TURNOS ===================
        private void ConfigurarDTVGAgenda()
        {
            DTVGAgenda.AutoGenerateColumns = false;
            DTVGAgenda.ReadOnly = true;
            DTVGAgenda.AllowUserToAddRows = false;
            DTVGAgenda.AllowUserToDeleteRows = false;
            DTVGAgenda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DTVGAgenda.RowHeadersVisible = false;
            DTVGAgenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DTVGAgenda.EnableHeadersVisualStyles = false;
            DTVGAgenda.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(199, 239, 216);

            // Tus columnas del diseñador:
            colFechaHora.DataPropertyName = nameof(TurnoVM.FechaHora);
            colFechaHora.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            colPaciente.DataPropertyName = nameof(TurnoVM.Paciente);
            colProfesional.DataPropertyName = nameof(TurnoVM.Profesional);
            colMotivo.DataPropertyName = nameof(TurnoVM.Motivo);
            colEstado.DataPropertyName = nameof(TurnoVM.Estado);

            // Botones si faltan
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
                int idProf;
                if (int.TryParse(CMBProfesionales.SelectedValue?.ToString(), out idProf))
                    CargarConsultorios(idProf);

                CargarTurnosDelDia();
                RefrescarFranjas();
            };

            btSobreturno.Click += (s, a) =>
            {
                _sobreturnoActivo = !_sobreturnoActivo;
                btSobreturno.Text = _sobreturnoActivo ? "Sobreturno: ON" : "Sobreturno";
                btSobreturno.BackColor = _sobreturnoActivo ? Color.FromArgb(40, 167, 69) : SystemColors.Control;
                btSobreturno.ForeColor = _sobreturnoActivo ? Color.White : Color.Black;
                RefrescarFranjas();
            };
        }

        // =================== Carga de turnos del día ===================
        private void CargarTurnosDelDia()
        {
            int idProfesional = 0;
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

                    using (var da = new SqlDataAdapter(sql, conexion))
                    {
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
            }
            catch
            {
                // Demo local si todavía no tenés la tabla Turno
                var d = _diaSeleccionado.Date;
                _turnosDia = new List<TurnoVM>
                {
                    new TurnoVM{ IdTurno=1, FechaHora=d.AddHours(8),   Paciente="Juan Pérez",  Profesional=CMBProfesionales.Text, Motivo="Control", Estado="Confirmado" },
                    new TurnoVM{ IdTurno=2, FechaHora=d.AddHours(9.5), Paciente="María Gómez", Profesional=CMBProfesionales.Text, Motivo="Dolor",   Estado="Pendiente" }
                };
            }

            DTVGAgenda.DataSource = null;
            DTVGAgenda.DataSource = _turnosDia;
        }

        // =================== Franjas horarias ===================
        private void RefrescarFranjas()
        {
            flpFranjas.SuspendLayout();
            flpFranjas.Controls.Clear();

            int total = 0, libres = 0;
            var almuerzo = new HashSet<TimeSpan> { new TimeSpan(12, 0, 0), new TimeSpan(12, 30, 0) };

            // Base: 08:00 a 18:30 cada 30', saltando 12:00/12:30 si NO hay sobreturno
            for (var t = _inicio; t <= _fin; t = t.Add(TimeSpan.FromMinutes(_saltoMin)))
            {
                bool esExtraSobreturno = almuerzo.Contains(t) && _sobreturnoActivo; // 12:00 / 12:30 solo si sobreturno
                if (almuerzo.Contains(t) && !_sobreturnoActivo) continue;

                AgregarBotonFranja(t, esExtraSobreturno, ref total, ref libres);
            }

            // Extra sobreturno: 19:00 (fuera de horario)
            if (_sobreturnoActivo)
            {
                var tExtra = new TimeSpan(19, 0, 0);
                AgregarBotonFranja(tExtra, true, ref total, ref libres);
            }

            if (lDisponibles != null)
                lDisponibles.Text = string.Format("{0} de {1} disponibles", libres, total);

            flpFranjas.ResumeLayout();
        }

        private void AgregarBotonFranja(TimeSpan hora, bool esExtraSobreturno, ref int total, ref int libres)
        {
            total++;

            var fh = _diaSeleccionado.Date + hora;
            bool ocupado = _turnosDia.Any(x => x.FechaHora.Hour == fh.Hour && x.FechaHora.Minute == fh.Minute);

            var b = new Button
            {
                Text = fh.ToString("HH:mm") + (esExtraSobreturno ? " •SOB" : ""),
                Tag = fh,
                AutoSize = true,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Margin = new Padding(6),
                Padding = new Padding(10, 6, 10, 6),
                BackColor = ocupado ? Color.FromArgb(233, 236, 239)
                                    : (esExtraSobreturno ? Color.WhiteSmoke : Color.White),
                Enabled = !ocupado || _sobreturnoActivo
            };
            b.Click += ClickFranja;

            if (!ocupado) libres++;
            flpFranjas.Controls.Add(b);
        }

        // =================== Alta desde franja (sin otro form) ===================
        private void ClickFranja(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var fechaHora = (DateTime)btn.Tag;

            bool ocupado = _turnosDia.Any(x => x.FechaHora == fechaHora);
            if (ocupado && !_sobreturnoActivo)
            {
                MessageBox.Show("Horario ocupado. Activá 'Sobreturno' para continuar.", "Agenda",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string paciente = Interaction.InputBox("Paciente (Apellido y Nombre):", "Registrar Turno", "");
            if (string.IsNullOrWhiteSpace(paciente)) return;

            string motivo = Interaction.InputBox("Motivo de la consulta:", "Registrar Turno", "");
            if (string.IsNullOrWhiteSpace(motivo)) motivo = "-";

            int idProfesional = 0;
            int.TryParse(CMBProfesionales.SelectedValue?.ToString(), out idProfesional);

            try
            {
                using (var cn = Conexion.GetConnection())
                {
                    cn.Open();
                    string sql = @"
                        INSERT INTO Turno (id_profesional, fecha_hora, paciente_texto, motivo, estado, es_sobreturno)
                        VALUES (@id_prof, @fh, @paciente, @motivo, @estado, @sob)";
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id_prof", idProfesional);
                        cmd.Parameters.AddWithValue("@fh", fechaHora);
                        cmd.Parameters.AddWithValue("@paciente", paciente);
                        cmd.Parameters.AddWithValue("@motivo", motivo);
                        cmd.Parameters.AddWithValue("@estado", "Confirmado");
                        cmd.Parameters.AddWithValue("@sob", _sobreturnoActivo);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // Demo local si falta tabla
                _turnosDia.Add(new TurnoVM
                {
                    IdTurno = (_turnosDia.Count == 0 ? 1 : _turnosDia.Max(x => x.IdTurno) + 1),
                    FechaHora = fechaHora,
                    Paciente = paciente,
                    Profesional = CMBProfesionales.Text,
                    Motivo = motivo,
                    Estado = "Confirmado"
                });
            }

            CargarTurnosDelDia();
            RefrescarFranjas();
        }

        // =================== Acciones del grid ===================
        private void DTVGAgenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
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

                // TODO: UPDATE en BD (id = turno.IdTurno)
                DTVGAgenda.Refresh();
            }
            else if (colName == "colCancelar")
            {
                var r = MessageBox.Show("¿Querés cancelar este turno?\n\nSí = Cancelar\nNo = Reprogramar\nCancelar = Salir",
                    "Cancelar o Reprogramar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    turno.Estado = "Cancelado";
                    // TODO: UPDATE en BD
                    DTVGAgenda.Refresh();
                    RefrescarFranjas();
                }
                else if (r == DialogResult.No)
                {
                    var input = Interaction.InputBox("Nueva fecha/hora (dd/MM/yyyy HH:mm):",
                        "Reprogramar", _diaSeleccionado.ToString("dd/MM/yyyy ") + "10:00");

                    DateTime nueva;
                    if (DateTime.TryParse(input, out nueva))
                    {
                        // TODO: UPDATE en BD
                        turno.FechaHora = nueva;
                        DTVGAgenda.Refresh();
                        CargarTurnosDelDia();
                        RefrescarFranjas();
                    }
                }
            }
        }

        // =================== Botones existentes ===================
        private void BBuscar_Click(object sender, EventArgs e)
        {
            int idProfesional = Convert.ToInt32(CMBProfesionales.SelectedValue);
            CargarAgenda(idProfesional);
            CargarTurnosDelDia();
            RefrescarFranjas();
        }

        private void BNuevaDisponibilidad_Click(object sender, EventArgs e)
        {
            var frm = new FormNuevaDisponibilidad();
            frm.ShowDialog();
            CargarAgenda();
        }

        private void BVolverAgenda_Click(object sender, EventArgs e) => this.Close();
        private void CMBProfesional_SelectedIndexChanged(object sender, EventArgs e) { /* si lo usás en el diseñador */ }
        private void BBuscar_Click_1(object sender, EventArgs e) { }
        private void gbSeleccionarFecha_Enter(object sender, EventArgs e) { }
    }

    // 
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
