using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfFont = iTextSharp.text.Font;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class Medico : Form
    {
        private readonly string _cnx =
            "Server=localhost\\SQLEXPRESS;Database=SaludSoft;Trusted_Connection=True;";

        // Setealo desde Login:
        private string _emailUsuarioActual = "laura.gomez@hospital.com";
        private int _idProfesional = 0;

        public Medico()
        {
            InitializeComponent();

            this.Load += Medico_Load;

            // Eventos UI
            btBuscar.Click += btBuscar_Click;
            tbBuscarPaciente.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; btBuscar_Click(s, EventArgs.Empty); } };
            dateTimePicker1.ValueChanged += (s, e) => CargarCitasDelDia();

            btCitas.Click += btCitas_Click;
            btCerrar.Click += btCerrar_Click_1;

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

            pnlCitas.Visible = false;
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
            pnlCitas.Visible = true;
            pnlCitas.BringToFront();
            CargarCitasDelDia();
        }

        private void btCerrar_Click_1(object sender, EventArgs e)
        {
            if (pnlCitas == null) return;
            pnlCitas.Visible = false;
            pnlCitas.SendToBack();
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
                using (var frm = new FormHistorial() { Owner = this, StartPosition = FormStartPosition.CenterParent })
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
    }
}
