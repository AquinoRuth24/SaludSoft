using SaludSoft.Security;
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
    public partial class FormConsultorio : Form
    {
        // Campos de control
        private int? idAgendaEditando = null;
        private bool esEdicion = false;

        public FormConsultorio()
        {
            InitializeComponent();
            CargarProfesionalConsultorio();
            CargarDisponibilidades();

            DGWConsultorios_profesional.CellClick += DGWConsultorios_profesional_CellClick;

            // Configurar pickers de hora
            DTPHoraInicio.Format = DateTimePickerFormat.Time;
            DTPHoraInicio.ShowUpDown = true;
            DPTHoraFin.Format = DateTimePickerFormat.Time;
            DPTHoraFin.ShowUpDown = true;

            // Días de la semana
            CBDiaSemana.Items.AddRange(new string[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes" });
        }

        // ==============================
        // CARGAS INICIALES
        // ==============================

        private void CargarProfesionalConsultorio()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"
                    SELECT 
                        pc.id_profesional_consultorio,
                        p.nombre + ' ' + p.apellido + ' - ' + c.descripcion AS ProfesionalConsultorio
                    FROM Profesional_Consultorio pc
                    INNER JOIN Profesional p ON pc.id_profesional = p.id_profesional
                    INNER JOIN Consultorio c ON pc.id_consultorio = c.id_consultorio";

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                CMBProfesional_consultorio.DataSource = dt;
                CMBProfesional_consultorio.DisplayMember = "ProfesionalConsultorio";
                CMBProfesional_consultorio.ValueMember = "id_profesional_consultorio";
            }
        }

        // ==============================
        // CARGAR DISPONIBILIDADES
        // ==============================

        private void CargarDisponibilidades()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"
                    SELECT 
                        a.id_agenda,
                        c.descripcion AS Consultorio,
                        p.nombre + ' ' + p.apellido AS Profesional,
                        a.diaSemana AS Día,
                        CONVERT(varchar(5), a.horaInicio, 108) AS HoraInicio,
                        CONVERT(varchar(5), a.horaFin, 108) AS HoraFin
                    FROM Agenda a
                    INNER JOIN Profesional_Consultorio pc ON a.id_profesional_consultorio = pc.id_profesional_consultorio
                    INNER JOIN Profesional p ON pc.id_profesional = p.id_profesional
                    INNER JOIN Consultorio c ON pc.id_consultorio = c.id_consultorio
                    ORDER BY c.descripcion, a.diaSemana, a.horaInicio";

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DGWConsultorios_profesional.DataSource = null;
                DGWConsultorios_profesional.Columns.Clear();
                DGWConsultorios_profesional.DataSource = dt;

                DGWConsultorios_profesional.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DGWConsultorios_profesional.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Botón Editar
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.HeaderText = "Acción";
                btnEditar.Text = "Editar";
                btnEditar.Name = "Editar";
                btnEditar.UseColumnTextForButtonValue = true;
                DGWConsultorios_profesional.Columns.Add(btnEditar);

                // Botón Eliminar
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.HeaderText = "";
                btnEliminar.Text = "Eliminar";
                btnEliminar.Name = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                DGWConsultorios_profesional.Columns.Add(btnEliminar);
            }
        }

        // ==============================
        // BOTONES
        // ==============================

        private void BNuevaDisponibilidad_Click(object sender, EventArgs e)
        {
            esEdicion = false;
            idAgendaEditando = null;

            GBNuevaDisponibilidad.Visible = true;
            BGuardarDisponibilidad.Text = "Guardar";
            CMBProfesional_consultorio.Enabled = true;
        }

        private void BCancelarDisponibilidad_Click(object sender, EventArgs e)
        {
            GBNuevaDisponibilidad.Visible = false;
            esEdicion = false;
            idAgendaEditando = null;
        }

        // ==============================
        // GUARDAR / ACTUALIZAR
        // ==============================

        private void BGuardar_Click(object sender, EventArgs e)
        {
            string dia = CBDiaSemana.SelectedItem?.ToString();
            TimeSpan horaInicio = DTPHoraInicio.Value.TimeOfDay;
            TimeSpan horaFin = DPTHoraFin.Value.TimeOfDay;
            int idProfesionalConsultorio = Convert.ToInt32(CMBProfesional_consultorio.SelectedValue);

            if (string.IsNullOrEmpty(dia))
            {
                MessageBox.Show("Seleccione un día de la semana.");
                return;
            }

            if (horaFin <= horaInicio)
            {
                MessageBox.Show("La hora de fin debe ser mayor que la hora de inicio.");
                return;
            }

            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query;
                if (!esEdicion)
                {
                    // NUEVA DISPONIBILIDAD
                    query = @"
                        INSERT INTO Agenda (id_profesional_consultorio, diaSemana, horaInicio, horaFin)
                        VALUES (@id_profesional_consultorio, @dia, @horaInicio, @horaFin)";
                }
                else
                {
                    // ACTUALIZACIÓN
                    query = @"
                        UPDATE Agenda
                        SET diaSemana = @dia, horaInicio = @horaInicio, horaFin = @horaFin
                        WHERE id_agenda = @idAgenda";
                }

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id_profesional_consultorio", idProfesionalConsultorio);
                cmd.Parameters.AddWithValue("@dia", dia);
                cmd.Parameters.AddWithValue("@horaInicio", horaInicio);
                cmd.Parameters.AddWithValue("@horaFin", horaFin);

                if (esEdicion)
                    cmd.Parameters.AddWithValue("@idAgenda", idAgendaEditando);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show(esEdicion ? "Disponibilidad actualizada correctamente." :
                                        "Disponibilidad guardada correctamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Resetear formulario
            esEdicion = false;
            idAgendaEditando = null;
            CMBProfesional_consultorio.Enabled = true;
            BGuardarDisponibilidad.Text = "Guardar";
            GBNuevaDisponibilidad.Visible = false;

            CargarDisponibilidades();
        }

        // ==============================
        // EDICIÓN Y ELIMINACIÓN
        // ==============================

        private void DGWConsultorios_profesional_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int idAgenda = Convert.ToInt32(DGWConsultorios_profesional.Rows[e.RowIndex].Cells["id_agenda"].Value);

            // EDITAR
            if (DGWConsultorios_profesional.Columns[e.ColumnIndex].Name == "Editar")
            {
                EditarDisponibilidad(idAgenda);
            }

            // ELIMINAR
            if (DGWConsultorios_profesional.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult result = MessageBox.Show("¿Desea eliminar esta disponibilidad?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conexion = Conexion.GetConnection())
                    {
                        conexion.Open();
                        string query = "DELETE FROM Agenda WHERE id_agenda = @id";
                        SqlCommand cmd = new SqlCommand(query, conexion);
                        cmd.Parameters.AddWithValue("@id", idAgenda);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Disponibilidad eliminada correctamente.");
                    CargarDisponibilidades();
                }
            }
        }

        // ==============================
        // CARGAR DATOS PARA EDICIÓN
        // ==============================

        private void EditarDisponibilidad(int idAgenda)
        {
            esEdicion = true;
            idAgendaEditando = idAgenda;

            CargarDatosAgenda(idAgenda);

            GBNuevaDisponibilidad.Visible = true;
            BGuardarDisponibilidad.Text = "Actualizar";
        }

        private void CargarDatosAgenda(int idAgenda)
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"
                    SELECT 
                        a.diaSemana,
                        a.horaInicio,
                        a.horaFin,
                        pc.id_profesional_consultorio
                    FROM Agenda a
                    INNER JOIN Profesional_Consultorio pc 
                        ON a.id_profesional_consultorio = pc.id_profesional_consultorio
                    WHERE a.id_agenda = @idAgenda";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@idAgenda", idAgenda);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        CBDiaSemana.SelectedItem = reader["diaSemana"].ToString();
                        DTPHoraInicio.Value = DateTime.Today.Add((TimeSpan)reader["horaInicio"]);
                        DPTHoraFin.Value = DateTime.Today.Add((TimeSpan)reader["horaFin"]);
                        CMBProfesional_consultorio.SelectedValue = Convert.ToInt32(reader["id_profesional_consultorio"]);
                    }
                }
            }

            CMBProfesional_consultorio.Enabled = false;
        }


    }
}