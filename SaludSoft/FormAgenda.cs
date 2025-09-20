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
    public partial class FormAgenda : Form
    {
        public FormAgenda()
        {
            InitializeComponent();
            CargarProfesionales();
            CargarConsultorios();
            CargarAgenda();

            DTVGAgenda.CellClick += DTVGAgenda_CellClick; // evento para botones
        }
        // botones
        private void BInicio_Click(object sender, EventArgs e)
        {
            SaludSoft frm = new SaludSoft();
            frm.ShowDialog();
        }

        private void BPacientes_Click(object sender, EventArgs e)
        {
            FormListaPacientes frm = new FormListaPacientes();
            frm.ShowDialog();
        }

        private void BCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();
            frm.ShowDialog();
            this.Close();
        }

        private void BAgenda_Click(object sender, EventArgs e)
        {
            FormAgenda frm = new FormAgenda();
            frm.ShowDialog();
            this.Close();
        }
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

                // Opción "Todos"
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

                // Opción "Todos"
                DataRow row = dt.NewRow();
                row["id_consultorio"] = 0;
                row["Consultorio"] = "Todos los consultorios";
                dt.Rows.InsertAt(row, 0);

                CMBConsultorio.DataSource = dt;
                CMBConsultorio.DisplayMember = "Consultorio";
                CMBConsultorio.ValueMember = "id_consultorio";
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
                      FORMAT(a.horaInicio, 'HH:mm') + ' - ' + FORMAT(a.horaFin, 'HH:mm') AS Horario,
                       u.nombre + ' ' + u.apellido AS Recepcionista,
                       p.nombre + ' ' + p.apellido AS Profesional,
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

                DTVGAgenda.DataSource = dt;

                DTVGAgenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DTVGAgenda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DTVGAgenda.AllowUserToAddRows = false;

                ConfigurarGrid();
            }
        }

        private void ConfigurarGrid()
        {
            if (!DTVGAgenda.Columns.Contains("Editar"))
            {
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.HeaderText = "Acciones";
                btnEditar.Name = "Editar";
                btnEditar.Text = "Modificar";
                btnEditar.UseColumnTextForButtonValue = true;
                DTVGAgenda.Columns.Add(btnEditar);
            }
        }

        private void DTVGAgenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DTVGAgenda.Columns[e.ColumnIndex].Name == "Editar")
            {
                //int idAgenda = Convert.ToInt32(DTVGAgenda.Rows[e.RowIndex].Cells["id_agenda"].Value);idAgenda

                FormModificarAgenda frm = new FormModificarAgenda();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarAgenda();
                }
            }
        }

        private void CMBProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(CMBProfesionales.SelectedValue?.ToString(), out int idProfesional))
            {
                CargarConsultorios(idProfesional);
            }
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            int idProfesional = Convert.ToInt32(CMBProfesionales.SelectedValue);
            int idConsultorio = Convert.ToInt32(CMBConsultorio.SelectedValue);

            CargarAgenda(idProfesional, idConsultorio);
        }

        private void BNuevaDisponibilidad_Click(object sender, EventArgs e)
        {
            FormNuevaDisponibilidad frm = new FormNuevaDisponibilidad();
                // actualiza la agenda despues de agregar nueva disponbilidad
                CargarAgenda();
        }

        private void BVolverAgenda_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}