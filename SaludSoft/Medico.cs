using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PdfFont = iTextSharp.text.Font;

namespace SaludSoft
{
    public partial class Medico : Form
    {
        private readonly string _cnx =
            "Server=localhost\\SQLEXPRESS;Database=SaludSoft;Trusted_Connection=True;";

        // Setealo desde Login:
        private string _emailUsuarioActual = "laura.gomez@hospital.com";
        private int _idProfesional = 0;
        private Panel pnlInicio;      // dashboard
        private Panel pnlPacientes;   // contenedor de dgPacientes

        // Cards (dashboard)
        private Panel cardConfirmados, cardPendientes, cardCancelados;
        private Label lbConfN, lbPendN, lbCancN;


        public Medico()
        {
            InitializeComponent();

            this.Load += Medico_Load;

            // Eventos UI
            btBuscar.Click += btBuscar_Click;
            tbBuscarPaciente.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; btBuscar_Click(s, EventArgs.Empty); } };
            dateTimePicker1.ValueChanged += (s, e) => CargarCitasDelDia();
            btInicio.Click += (s, e) =>
            {
                MostrarSeccion("INICIO");
                ActualizarCardsTurnos(dateTimePicker1.Value.Date);
            };
            btCitas.Click += btCitas_Click;
            btCerrar.Click += btCerrar_Click_1;

            btPacientes.Click += btPacientes_Click;

            dateTimePicker1.ValueChanged += (s, e) =>
            {
                CargarCitasDelDia();
                ActualizarCardsTurnos(dateTimePicker1.Value.Date);
            };

            //preparar paneles y dashboard
            PrepararSecciones();
        }


        // ---------- Load ----------
        private void Medico_Load(object sender, EventArgs e)
        {
            _idProfesional = GetIdProfesionalPorEmail(_emailUsuarioActual);
            if (_idProfesional == 0)
            {
                MessageBox.Show("No se encontró el profesional del usuario actual.", "Médico",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConfigurarMapeoGrillas();
            CargarPacientesDelProfesional();
            CargarCitasDelDia();

            // Secciones visibles
            pnlCitas.Visible = false;
            MostrarSeccion("INICIO");
            ActualizarCardsTurnos(dateTimePicker1.Value.Date);
        }

        private void PrepararSecciones()
        {
            // INICIO
            if (pnlInicio == null)
            {
                pnlInicio = new Panel
                {
                    Name = "pnlInicio",
                    Left = 200,
                    Top = 130,
                    Width = this.ClientSize.Width - 240,
                    Height = 240,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };
                this.Controls.Add(pnlInicio);
                pnlInicio.BringToFront();
                PrepararDashboard(pnlInicio);
                pnlInicio.Resize += (s, e) => ReflowCards();
            }

            // PACIENTES
            if (pnlPacientes == null)
            {
                pnlPacientes = new Panel
                {
                    Name = "pnlPacientes",
                    Left = 200,
                    Top = 130,
                    Width = this.ClientSize.Width - 240,
                    Height = this.ClientSize.Height - 180,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
                };
                this.Controls.Add(pnlPacientes);

                if (lDNI.Parent != pnlPacientes)
                {
                    lDNI.Parent = pnlPacientes;
                    lDNI.Top = 20;
                    lDNI.Left = 20;
                    lDNI.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                }

                if (tbBuscarPaciente.Parent != pnlPacientes)
                {
                    tbBuscarPaciente.Parent = pnlPacientes;
                    tbBuscarPaciente.Top = 16;
                    tbBuscarPaciente.Left = lDNI.Right + 10;
                    tbBuscarPaciente.Width = 280;
                    tbBuscarPaciente.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                }

                if (btBuscar.Parent != pnlPacientes)
                {
                    btBuscar.Parent = pnlPacientes;
                    btBuscar.Top = 16;
                    btBuscar.Left = tbBuscarPaciente.Right + 8;
                    btBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                }

                if (dgPacientes.Parent != pnlPacientes)
                {
                    dgPacientes.Parent = pnlPacientes;
                }
                
                dgPacientes.Top = tbBuscarPaciente.Bottom + 14;
                dgPacientes.Left = 20;
                dgPacientes.Width = pnlPacientes.ClientSize.Width - 40;
                dgPacientes.Height = pnlPacientes.ClientSize.Height - dgPacientes.Top - 20;
                dgPacientes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

                
                pnlPacientes.Resize += (s, e) =>
                {
                    tbBuscarPaciente.Width = Math.Max(200, pnlPacientes.ClientSize.Width - tbBuscarPaciente.Left - 120);
                    btBuscar.Left = tbBuscarPaciente.Right + 8;

                    dgPacientes.Width = pnlPacientes.ClientSize.Width - 40;
                    dgPacientes.Height = pnlPacientes.ClientSize.Height - dgPacientes.Top - 20;
                };
            }

            // Por defecto, oculto filtros de Pacientes (se muestran solo en esa sección)
            SetPacientesUIVisible(false);
        }
        private void SetPacientesUIVisible(bool visible)
        {
            if (pnlPacientes == null) return;
            lDNI.Visible = visible;
            tbBuscarPaciente.Visible = visible;
            btBuscar.Visible = visible;
            dgPacientes.Visible = visible;
        }


        private void PrepararDashboard(Panel host)
        {
            host.Controls.Clear();

            Panel CrearCard(string titulo, out Label lbNumero, Color back, Color fore)
            {
                var card = new Panel
                {
                    BackColor = back,
                    BorderStyle = BorderStyle.FixedSingle,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left
                };

                var lTitulo = new Label
                {
                    Text = titulo,
                    AutoSize = false,
                    Left = 12,
                    Top = 10,
                    Width = 10,  // se recalcula en Reflow
                    Height = 24,
                    Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold),
                    ForeColor = fore
                };

                lbNumero = new Label
                {
                    Text = "0",
                    AutoSize = false,
                    Left = 12,
                    Top = 50,   // se recalcula
                    Width = 10, // se recalcula
                    Height = 48,
                    Font = new System.Drawing.Font("Comic Sans MS", 28F, System.Drawing.FontStyle.Bold),
                    ForeColor = fore
                };

                card.Controls.Add(lTitulo);
                card.Controls.Add(lbNumero);
                return card;
            }

            cardConfirmados = CrearCard("Confirmados (hoy)", out lbConfN, Color.FromArgb(217, 247, 223), Color.FromArgb(0, 102, 68));
            cardPendientes = CrearCard("Pendientes (hoy)", out lbPendN, Color.FromArgb(255, 249, 196), Color.FromArgb(141, 98, 0));
            cardCancelados = CrearCard("Cancelados (hoy)", out lbCancN, Color.FromArgb(255, 235, 238), Color.FromArgb(183, 28, 28));

            host.Controls.Add(cardConfirmados);
            host.Controls.Add(cardPendientes);
            host.Controls.Add(cardCancelados);

            ReflowCards(); 
        }
        //se agrega metodo para acomodar las cards en el dashboard
        private void ReflowCards()
        {
            if (pnlInicio == null || cardConfirmados == null) return;

            int padding = 24;
            int cols = 3;
            int availW = pnlInicio.ClientSize.Width - padding * (cols + 1);
            int cardW = Math.Max(220, availW / cols);
            int cardH = Math.Max(120, (int)(pnlInicio.ClientSize.Height * 0.35));

            Panel[] cards = { cardConfirmados, cardPendientes, cardCancelados };
            for (int i = 0; i < cards.Length; i++)
            {
                var c = cards[i];
                c.Width = cardW;
                c.Height = cardH;
                c.Left = padding + i * (cardW + padding);
                c.Top = padding;

                foreach (Control ctrl in c.Controls)
                {
                    if (ctrl is Label lbl)
                    {
                        lbl.Width = cardW - 24;
                        if (lbl.Font.Size >= 20) 
                        {
                            lbl.Left = 12;
                            lbl.Top = (cardH / 2) - 28;
                        }
                        else // título
                        {
                            lbl.Left = 12;
                            lbl.Top = 10;
                        }
                    }
                }
            }
        }


        private void MostrarSeccion(string seccion)
        {
            seccion = (seccion ?? "").ToUpperInvariant();

            pnlInicio.Visible = seccion == "INICIO";
            pnlPacientes.Visible = seccion == "PACIENTES";
            pnlCitas.Visible = seccion == "CITAS";

            SetPacientesUIVisible(seccion == "PACIENTES");

            if (pnlInicio.Visible) pnlInicio.BringToFront();
            if (pnlPacientes.Visible) pnlPacientes.BringToFront();
            if (pnlCitas.Visible) pnlCitas.BringToFront();
        }



        //boton pacientes
        private void btPacientes_Click(object sender, EventArgs e)
        {
            MostrarSeccion("PACIENTES");
            CargarPacientesDelProfesional(); 
            dgPacientes.Focus();
        }
        private void ActualizarCardsTurnos(DateTime dia)
        {
            int conf = 0, pend = 0, canc = 0;

            const string SQL = @"
            SELECT ISNULL(t.estado,'Pendiente') AS estado, COUNT(*) AS cantidad
            FROM Turnos t
            JOIN Agenda a                   ON a.id_agenda = t.id_agenda
            JOIN Profesional_Consultorio pc ON pc.id_profesional_consultorio = a.id_profesional_consultorio
            JOIN Profesional pr             ON pr.id_profesional = pc.id_profesional
            WHERE pr.id_profesional = @idProf
              AND CAST(t.fecha AS date) = @dia
            GROUP BY ISNULL(t.estado,'Pendiente');";

            using (var cn = new SqlConnection(_cnx))
            using (var cmd = new SqlCommand(SQL, cn))
            {
                cmd.Parameters.AddWithValue("@idProf", _idProfesional);
                cmd.Parameters.AddWithValue("@dia", dia.Date);
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        string est = rd.GetString(0);
                        int cant = rd.GetInt32(1);
                        if (est.Equals("Confirmado", StringComparison.OrdinalIgnoreCase)) conf = cant;
                        else if (est.Equals("Cancelado", StringComparison.OrdinalIgnoreCase)) canc = cant;
                        else pend = cant; // todo lo demás lo tratamos como pendiente
                    }
                }
            }

            if (lbConfN != null) lbConfN.Text = conf.ToString();
            if (lbPendN != null) lbPendN.Text = pend.ToString();
            if (lbCancN != null) lbCancN.Text = canc.ToString();
        }


        // ---------- Mapeo columnas ----------
        private void ConfigurarMapeoGrillas()
        {
            // dgPacientes
            dgPacientes.AutoGenerateColumns = false;
            if (dgPacientes.Columns["colId"] != null) dgPacientes.Columns["colId"].DataPropertyName = "IdPaciente";
            if (dgPacientes.Columns["colNombre"] != null) dgPacientes.Columns["colNombre"].DataPropertyName = "Nombre";
            if (dgPacientes.Columns["colApellido"] != null) dgPacientes.Columns["colApellido"].DataPropertyName = "Apellido";
            if (dgPacientes.Columns["colDni"] != null) dgPacientes.Columns["colDni"].DataPropertyName = "DNI";
            if (dgPacientes.Columns["colTel"] != null) dgPacientes.Columns["colTel"].DataPropertyName = "Telefono";
            if (dgPacientes.Columns["colCorreo"] != null) dgPacientes.Columns["colCorreo"].DataPropertyName = "Email";

            // dgCitas
            dgCitas.AutoGenerateColumns = false;
            if (dgCitas.Columns["colHora"] != null) dgCitas.Columns["colHora"].DataPropertyName = "Hora";
            if (dgCitas.Columns["colPaciente"] != null) dgCitas.Columns["colPaciente"].DataPropertyName = "Paciente";
            if (dgCitas.Columns["colMotivo"] != null) dgCitas.Columns["colMotivo"].DataPropertyName = "Motivo";
            if (dgCitas.Columns["colConsultorio"] != null) dgCitas.Columns["colConsultorio"].DataPropertyName = "Consultorio";
        }

        // ---------- Id profesional por email ----------
        private int GetIdProfesionalPorEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return 0;

            const string SQL = @"
SELECT TOP 1 p.id_profesional
FROM Profesional p
JOIN Usuario u ON u.id_usuario = p.id_usuario
WHERE u.email = @mail;";

            using (var cn = new SqlConnection(_cnx))
            using (var cmd = new SqlCommand(SQL, cn))
            {
                cmd.Parameters.AddWithValue("@mail", email);
                cn.Open();
                var o = cmd.ExecuteScalar();
                return (o == null || o == DBNull.Value) ? 0 : Convert.ToInt32(o);
            }
        }

        // ---------- Pacientes del profesional ----------
        private void CargarPacientesDelProfesional()
        {
            const string SQL = @"
SELECT DISTINCT 
    p.id_paciente AS IdPaciente,
    p.nombre      AS Nombre,
    p.apellido    AS Apellido,
    p.dni         AS DNI,
    p.telefono    AS Telefono,
    p.email       AS Email
FROM Turnos t
JOIN Agenda a                   ON a.id_agenda = t.id_agenda
JOIN Profesional_Consultorio pc ON pc.id_profesional_consultorio = a.id_profesional_consultorio
JOIN Profesional pr             ON pr.id_profesional = pc.id_profesional
JOIN Paciente p                 ON p.id_paciente = t.id_paciente
WHERE pr.id_profesional = @idProf
ORDER BY p.apellido, p.nombre;";

            using (var cn = new SqlConnection(_cnx))
            using (var da = new SqlDataAdapter(SQL, cn))
            {
                da.SelectCommand.Parameters.AddWithValue("@idProf", _idProfesional);
                var dt = new DataTable();
                da.Fill(dt);
                dgPacientes.DataSource = dt;
            }
        }

        // ---------- Buscar por DNI ----------
        private void btBuscar_Click(object sender, EventArgs e)
        {
            string dni = new string((tbBuscarPaciente.Text ?? "").Where(char.IsDigit).ToArray());

            if (string.IsNullOrEmpty(dni))
            {
                CargarPacientesDelProfesional();
                return;
            }

            const string SQL = @"
SELECT DISTINCT 
    p.id_paciente AS IdPaciente,
    p.nombre      AS Nombre,
    p.apellido    AS Apellido,
    p.dni         AS DNI,
    p.telefono    AS Telefono,
    p.email       AS Email
FROM Turnos t
JOIN Agenda a                   ON a.id_agenda = t.id_agenda
JOIN Profesional_Consultorio pc ON pc.id_profesional_consultorio = a.id_profesional_consultorio
JOIN Profesional pr             ON pr.id_profesional = pc.id_profesional
JOIN Paciente p                 ON p.id_paciente = t.id_paciente
WHERE pr.id_profesional = @idProf
  AND p.dni = @dni
ORDER BY p.apellido, p.nombre;";

            using (var cn = new SqlConnection(_cnx))
            using (var da = new SqlDataAdapter(SQL, cn))
            {
                da.SelectCommand.Parameters.AddWithValue("@idProf", _idProfesional);
                da.SelectCommand.Parameters.AddWithValue("@dni", dni);
                var dt = new DataTable();
                da.Fill(dt);
                dgPacientes.DataSource = dt;
            }
        }

        // ---------- Citas del día ----------
        private void CargarCitasDelDia()
        {
            DateTime fini = dateTimePicker1.Value.Date;
            DateTime ffin = fini.AddDays(1);

            const string SQL = @"
SELECT 
    CONVERT(varchar(5), t.fecha, 108)    AS Hora,
    pa.apellido + ', ' + pa.nombre       AS Paciente,
    t.motivo                             AS Motivo,
    c.descripcion                        AS Consultorio
FROM Turnos t
JOIN Agenda a                   ON a.id_agenda = t.id_agenda
JOIN Profesional_Consultorio pc ON pc.id_profesional_consultorio = a.id_profesional_consultorio
JOIN Profesional pr             ON pr.id_profesional = pc.id_profesional
JOIN Paciente pa                ON pa.id_paciente = t.id_paciente
LEFT JOIN Consultorio c         ON c.id_consultorio = pc.id_consultorio
WHERE t.fecha >= @fini AND t.fecha < @ffin
  AND pr.id_profesional = @idProf
  AND ISNULL(t.estado,'Pendiente') <> 'Cancelado'
ORDER BY t.fecha;";

            using (var cn = new SqlConnection(_cnx))
            using (var da = new SqlDataAdapter(SQL, cn))
            {
                da.SelectCommand.Parameters.AddWithValue("@fini", fini);
                da.SelectCommand.Parameters.AddWithValue("@ffin", ffin);
                da.SelectCommand.Parameters.AddWithValue("@idProf", _idProfesional);

                var dt = new DataTable();
                da.Fill(dt);
                dgCitas.DataSource = dt;
            }
        }

        // ---------- Panel Citas ----------
        private void btCitas_Click(object sender, EventArgs e)
        {
            MostrarSeccion("CITAS");
            CargarCitasDelDia();
        }

        private void btCerrar_Click_1(object sender, EventArgs e)
        {
            MostrarSeccion("INICIO");
        }


        // ---------- Historial ----------
        private bool _abriendoHistorial = false;

        private void BHistorial_Click(object sender, EventArgs e)
        {
            if (_abriendoHistorial) return;
            _abriendoHistorial = true;
            BHistorial.Enabled = false;

            try
            {
                using (var frm = new FormHistorial()
                {
                    Owner = this,
                    StartPosition = FormStartPosition.CenterParent,

                    EmailUsuarioActual = _emailUsuarioActual,                       
                    ProfesionalId = (_idProfesional > 0) ? _idProfesional : (int?)null
                })
                {
                    this.Hide();
                    frm.ShowDialog(this);
                }

                this.Show();
                this.Activate();
                this.BringToFront();
            }
            finally
            {
                _abriendoHistorial = false;
                BHistorial.Enabled = true;
            }
        }


        // ---------- Cerrar sesión ----------
        private void BCerrarSesion_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("¿Seguro que querés cerrar sesión?",
                                    "Cerrar sesión",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            foreach (Form f in Application.OpenForms.Cast<Form>().ToArray())
            {
                if (f != this && !(f is FormLogin))
                    f.Close();
            }

            var login = Application.OpenForms.OfType<FormLogin>().FirstOrDefault() ?? new FormLogin();
            login.StartPosition = FormStartPosition.CenterScreen;
            login.FormClosed += (_, __) => { if (!this.IsDisposed) this.Close(); };
            login.Show();
            login.Activate();
            login.BringToFront();
            login.LimpiarCampos();
            this.Hide();
        }

        // ---------- Imprimir citas (tu código) ----------
        private void btnImprimirCitas_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dateTimePicker1.Value;
            DataGridView dgv = dgCitas;

            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("No hay citas para imprimir en esta fecha.", "Impresión",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string rutaArchivo;
                using (var sfd = new SaveFileDialog()
                {
                    Title = "Guardar PDF de citas",
                    Filter = "Archivo PDF (*.pdf)|*.pdf",
                    FileName = $"Citas_{fechaSeleccionada:ddMMyyyy}.pdf"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                        rutaArchivo = sfd.FileName;
                    else
                    {
                        string carpeta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        rutaArchivo = Path.Combine(carpeta, $"Citas_{fechaSeleccionada:ddMMyyyy}.pdf");
                    }
                }

                var doc = new Document(PageSize.A4, 50, 50, 50, 50);
                PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                doc.Open();

                var fontTitulo = new PdfFont(PdfFont.FontFamily.HELVETICA, 18, PdfFont.BOLD, BaseColor.BLACK);
                var titulo = new Paragraph("Citas del día", fontTitulo) { Alignment = Element.ALIGN_CENTER };
                doc.Add(titulo);

                var fontTexto = new PdfFont(PdfFont.FontFamily.HELVETICA, 12, PdfFont.NORMAL, BaseColor.BLACK);
                doc.Add(new Paragraph($"Fecha: {fechaSeleccionada:dd/MM/yyyy}\n\n", fontTexto));

                var columnas = dgv.Columns.Cast<DataGridViewColumn>()
                    .Where(c => c.Visible && !(c is DataGridViewButtonColumn) && !(c is DataGridViewImageColumn))
                    .ToList();

                var tabla = new PdfPTable(columnas.Count) { WidthPercentage = 100 };

                var fontHeader = new PdfFont(PdfFont.FontFamily.HELVETICA, 11, PdfFont.BOLD, BaseColor.BLACK);
                foreach (var col in columnas)
                {
                    var celdaEnc = new PdfPCell(new Phrase(col.HeaderText, fontHeader))
                    {
                        BackgroundColor = BaseColor.LIGHT_GRAY,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    tabla.AddCell(celdaEnc);
                }

                foreach (DataGridViewRow fila in dgv.Rows)
                {
                    if (fila.IsNewRow) continue;
                    foreach (var col in columnas)
                    {
                        var val = fila.Cells[col.Index].Value?.ToString() ?? "";
                        tabla.AddCell(new Phrase(val, fontTexto));
                    }
                }

                doc.Add(tabla);
                doc.Close();

                MessageBox.Show($"PDF generado correctamente:\n{rutaArchivo}", "Impresión exitosa",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                try { System.Diagnostics.Process.Start(rutaArchivo); } catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lDNI_Click(object sender, EventArgs e)
        {

        }
    }
}
