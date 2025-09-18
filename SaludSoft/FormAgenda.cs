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
            CargarAgenda();
        }

        private void CargarProfesionales()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"SELECT id_profesional, nombre + ' ' + apellido AS Profesional 
                         FROM Profesional 
                         WHERE id_estado = 1"; // solo profesionales activos

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                CMBProfesional.DataSource = dt;
                CMBProfesional.DisplayMember = "Profesional";
                CMBProfesional.ValueMember = "id_profesional";

                if (dt.Rows.Count > 0)
                {
                    CMBProfesional.SelectedIndex = 0;

                    // Cargar sus consultorios directamente
                    int idProfesional = Convert.ToInt32(CMBProfesional.SelectedValue);
                    CargarConsultorios(idProfesional);
                }
                else
                {
                    CMBProfesional.SelectedIndex = -1;
                    CMBConsultorio.DataSource = null;
                }
            }
        }

        private void CargarConsultorios(int idProfesional)
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                string query = @"SELECT pc.id_profesional_consultorio, 
                                c.descripcion AS Consultorio
                         FROM Profesional_Consultorio pc
                         INNER JOIN Consultorio c ON pc.id_consultorio = c.id_consultorio
                         WHERE pc.id_profesional = @idProfesional";

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.SelectCommand.Parameters.AddWithValue("@idProfesional", idProfesional);

                DataTable dt = new DataTable();
                da.Fill(dt);

                CMBConsultorio.DataSource = dt;
                CMBConsultorio.DisplayMember = "Consultorio";
                CMBConsultorio.ValueMember = "id_profesional_consultorio";
                CMBConsultorio.SelectedIndex = -1;
            }
        }

        private void CargarAgenda(string filtro = "")
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"
            SELECT 
                a.id_agenda,
                a.disponibilidad,
                u.nombre + ' ' + u.apellido AS Recepcionista,
                p.nombre + ' ' + p.apellido AS Profesional,
                c.descripcion AS Consultorio
            FROM Agenda a
            INNER JOIN Usuario u ON a.id_usuario = u.id_usuario
            INNER JOIN Profesional_Consultorio pc ON a.id_profesional_consultorio = pc.id_profesional_consultorio
            INNER JOIN Profesional p ON pc.id_profesional = p.id_profesional
            INNER JOIN Consultorio c ON pc.id_consultorio = c.id_consultorio
            WHERE (p.nombre LIKE @filtro OR p.apellido LIKE @filtro OR c.descripcion LIKE @filtro)";

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                da.SelectCommand.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                DTVGAgenda.DataSource = dt;

                DTVGAgenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DTVGAgenda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DTVGAgenda.AllowUserToAddRows = false;

                // agregar botones si no existen
                if (DTVGAgenda.Columns["Editar"] == null)
                {
                    DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                    btnEditar.HeaderText = "Acciones";
                    btnEditar.Name = "Editar";
                    btnEditar.Text = "Modificar";
                    btnEditar.UseColumnTextForButtonValue = true;
                    DTVGAgenda.Columns.Add(btnEditar);

                    DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                    btnEliminar.Name = "Eliminar";
                    btnEliminar.Text = "Eliminar";
                    btnEliminar.UseColumnTextForButtonValue = true;
                    DTVGAgenda.Columns.Add(btnEliminar);
                }
            }
        }

        private void DTVGAgenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = DTVGAgenda.Columns[e.ColumnIndex].Name;

                // EDITAR
                if (columnName == "Editar")
                {
                    int idAgenda = Convert.ToInt32(DTVGAgenda.Rows[e.RowIndex].Cells["id_agenda"].Value);
                    DateTime fecha = Convert.ToDateTime(DTVGAgenda.Rows[e.RowIndex].Cells["disponibilidad"].Value);

                    // Podés abrir un form para editar
                   // FormModificarAgenda frmEditar = new FormModificarAgenda(//idAgenda, fecha);
                   // frmEditar.ShowDialog();

                    CargarAgenda();
                }

                // ELIMINAR
                if (columnName == "Eliminar")
                {
                    int idAgenda = Convert.ToInt32(DTVGAgenda.Rows[e.RowIndex].Cells["id_agenda"].Value);

                    DialogResult result = MessageBox.Show("¿Está seguro de eliminar esta disponibilidad?",
                                                          "Confirmación",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        using (SqlConnection conexion = Conexion.GetConnection())
                        {
                            conexion.Open();
                            string queryDelete = "DELETE FROM Agenda WHERE id_agenda = @id";

                            SqlCommand cmd = new SqlCommand(queryDelete, conexion);
                            cmd.Parameters.AddWithValue("@id", idAgenda);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Disponibilidad eliminada correctamente.",
                                        "Éxito",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        CargarAgenda();
                    }
                }
            }
        }
        // para enlazar los combox profesional y consultorio
        private void CMBProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(CMBProfesional.SelectedValue?.ToString(), out int idProfesional))
            {
                CargarConsultorios(idProfesional);
            }
            else
            {
                CMBConsultorio.DataSource = null;
            }
        }

        private void BNuevaDisponibilidad_Click(object sender, EventArgs e)
        {
            FormNuevaDisponibilidad frm = new FormNuevaDisponibilidad();
            frm.ShowDialog();
        }
    }
}

