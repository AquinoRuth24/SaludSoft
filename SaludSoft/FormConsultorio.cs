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
        public FormConsultorio()
        {
            InitializeComponent();
            CargarConsultorios();
            CargarTotales();

            DGWConsultorios_profesional.CellClick += DGWConsultorios_profesional_CellClick;
        }
        // cargar datos 
        private void CargarConsultorios()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                string query = @"
                SELECT 
                       c.nroConsultorio, 
                       c.descripcion, 
                       ISNULL(p.nombre + ' ' + p.apellido, '-') AS profesional,
                       ISNULL(e.nombre, '-') AS especialidad,
                       ISNULL(CONVERT(VARCHAR, pc.vigencia_desde, 103) + ' - ' + 
                              CONVERT(VARCHAR, pc.vigencia_hasta, 103), '-') AS vigencia
                 FROM Consultorio c
                 LEFT JOIN Profesional_Consultorio pc ON c.id_consultorio = pc.id_consultorio
                 LEFT JOIN Profesional p ON pc.id_profesional = p.id_profesional
                 LEFT JOIN Especialidad e ON p.id_especialidad = e.id_especialidad";

                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DGWConsultorios_profesional.DataSource = null;
                DGWConsultorios_profesional.DataSource = dt;

                DGWConsultorios_profesional.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DGWConsultorios_profesional.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Botón Editar
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.HeaderText = "Acciones";
                btnEditar.Name = "Editar";
                btnEditar.Text = " Editar";
                btnEditar.UseColumnTextForButtonValue = true;
                DGWConsultorios_profesional.Columns.Add(btnEditar);

                // Botón Eliminar
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.HeaderText = "Acciones";
                btnEliminar.Name = "Eliminar";
                btnEliminar.Text = " Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                DGWConsultorios_profesional.Columns.Add(btnEliminar);
            }
        }

        private void CargarCombos()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                // Cargar consultorios
                SqlDataAdapter daCons = new SqlDataAdapter("SELECT id_consultorio, descripcion FROM Consultorio", conexion);
                DataTable dtCons = new DataTable();
                daCons.Fill(dtCons);
                CMBConsultorio.DataSource = dtCons;
                CMBConsultorio.DisplayMember = "descripcion";
                CMBConsultorio.ValueMember = "id_consultorio";

                // Cargar profesionales
                SqlDataAdapter daProf = new SqlDataAdapter(@"
                   SELECT p.id_profesional, 
                   p.nombre + ' ' + p.apellido + ' - ' + e.nombre AS profesional_especialidad
                   FROM Profesional p
                   INNER JOIN Especialidad e ON p.id_especialidad = e.id_especialidad
                   INNER JOIN EstadoProfesional ep ON p.id_estado = ep.id_estado
                   WHERE ep.descripcion = 'Activo'", conexion); 
                DataTable dtProf = new DataTable();
                daProf.Fill(dtProf);
                CMBProfesional.DataSource = dtProf;
                CMBProfesional.DisplayMember = "profesional_especialidad";
                CMBProfesional.ValueMember = "id_profesional";
            }
        }

        private void CargarTotales()
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();

                // Total consultorios
                SqlCommand cmdTotal = new SqlCommand("SELECT COUNT(*) FROM Consultorio", conexion);
                int total = (int)cmdTotal.ExecuteScalar();

                // Disponibles
                SqlCommand cmdDisp = new SqlCommand(@"
                 SELECT COUNT(*) 
                 FROM Consultorio c
                 WHERE c.id_consultorio NOT IN (
                 SELECT id_consultorio 
                 FROM Profesional_Consultorio
                 WHERE GETDATE() BETWEEN vigencia_desde AND vigencia_hasta)", conexion);
                int disponibles = (int)cmdDisp.ExecuteScalar();

                // Asignados
                SqlCommand cmdAsig = new SqlCommand(@"
                  SELECT COUNT(DISTINCT id_consultorio)
                  FROM Profesional_Consultorio
                  WHERE GETDATE() BETWEEN vigencia_desde AND vigencia_hasta", conexion);
                int asignados = (int)cmdAsig.ExecuteScalar();

                // Mostrar en labels
                LTotalConsultorios.Text = total.ToString();
                LConsultoriosDisponibles.Text = disponibles.ToString();
                LConsultoriosAsignados.Text = asignados.ToString();
            }
        }

        // Asignar Profesional_consultorio
        private void BAgregarProfesional_consultorio_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                string query = @"
                INSERT INTO Profesional_Consultorio (id_profesional, id_consultorio, fecha, vigencia_desde, vigencia_hasta)
                VALUES (@prof, @cons, GETDATE(), @desde, @hasta)";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@prof", CMBProfesional.SelectedValue);
                cmd.Parameters.AddWithValue("@cons", CMBConsultorio.SelectedValue);
                cmd.Parameters.AddWithValue("@desde", DTPDesde.Value);
                cmd.Parameters.AddWithValue("@hasta", DTPHasta.Value);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Profesional asignado correctamente.");
            GBAsignarProfesional.Visible = false;
            CargarConsultorios();
        }
        // agregar consultorio
        private void BAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = Conexion.GetConnection())
            {
                conexion.Open();
                string query = "INSERT INTO Consultorio (nroConsultorio, descripcion) VALUES (@nro, @desc)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@nro", TBNroConsultorio.Text);
                cmd.Parameters.AddWithValue("@desc", TBDescripcion.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Consultorio agregado con éxito.");
            GBAgregarConsultorio.Visible = false;
            CargarConsultorios();
            CargarTotales();
        }

        // botones 
        private void BVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BAsignarProfesional_Click_1(object sender, EventArgs e)
        {
            CargarCombos();
            GBAsignarProfesional.Visible = true;
        }
        private void BCancelar_Click(object sender, EventArgs e)
        {
            GBAgregarConsultorio.Visible = false;
        }
        private void BCancelarProfesional_consultorio_Click(object sender, EventArgs e)
        {
            GBAsignarProfesional.Visible = false;
        }
        private void BAgregarConsultorio_Click(object sender, EventArgs e)
        {
            GBAgregarConsultorio.Visible = true;
        }

        private void DGWConsultorios_profesional_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Botón Editar
                if (DGWConsultorios_profesional.Columns[e.ColumnIndex].Name == "Editar")
                {
                    string nroCons = DGWConsultorios_profesional.Rows[e.RowIndex].Cells["nroConsultorio"].Value.ToString();
                    string profesional = DGWConsultorios_profesional.Rows[e.RowIndex].Cells["profesional"].Value.ToString();

                    if (profesional != "-")
                    {
                        // Cargar combos
                        CargarCombos();
                        GBAsignarProfesional.Visible = true;

                        // Seleccionar consultorio
                        CMBConsultorio.SelectedIndex = CMBConsultorio.FindStringExact(
                            DGWConsultorios_profesional.Rows[e.RowIndex].Cells["descripcion"].Value.ToString()
                        );

                        // Seleccionar profesional
                        CMBProfesional.SelectedIndex = CMBProfesional.FindString(profesional);

                        // Fechas
                        string vigencia = DGWConsultorios_profesional.Rows[e.RowIndex].Cells["vigencia"].Value.ToString();
                        if (vigencia != "-")
                        {
                            string[] fechas = vigencia.Split('-');
                            DTPDesde.Value = DateTime.Parse(fechas[0].Trim());
                            DTPHasta.Value = DateTime.Parse(fechas[1].Trim());
                        }
                    }
                }

                // Botón Eliminar
                if (DGWConsultorios_profesional.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    DialogResult result = MessageBox.Show("¿Seguro que desea eliminar esta asignación?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        using (SqlConnection conexion = Conexion.GetConnection())
                        {
                            conexion.Open();
                            string query = @"
                             DELETE FROM Profesional_Consultorio
                             WHERE id_consultorio = (
                             SELECT TOP 1 id_consultorio FROM Consultorio WHERE nroConsultorio = @nro)";
                            SqlCommand cmd = new SqlCommand(query, conexion);
                            cmd.Parameters.AddWithValue("@nro", DGWConsultorios_profesional.Rows[e.RowIndex].Cells["nroConsultorio"].Value);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Asignación eliminada correctamente.");
                        CargarConsultorios();
                        CargarTotales();
                    }
                }
            }
        }
        // filtro de busqueda
        private void BBuscar_Click(object sender, EventArgs e)
        {
            if (DGWConsultorios_profesional.DataSource != null)
            {
                DataTable dt = DGWConsultorios_profesional.DataSource as DataTable;
                if (dt != null)
                {
                    string filtro = TBBuscar.Text.Trim();

                    if (string.IsNullOrEmpty(filtro))
                    {
                        // Si no se escribió nada, mostramos todos
                        dt.DefaultView.RowFilter = "";
                    }
                    else
                    {
                        // Filtro por nroConsultorio, descripcion, profesional o especialidad
                        dt.DefaultView.RowFilter = string.Format(
                            "Convert(nroConsultorio, 'System.String') LIKE '%{0}%' OR " +
                            "descripcion LIKE '%{0}%' OR " +
                            "profesional LIKE '%{0}%' OR " +
                            "especialidad LIKE '%{0}%'",
                            filtro.Replace("'", "''") 
                        );
                    }
                }
            }
        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            TBBuscar.Clear();
            if (DGWConsultorios_profesional.DataSource != null)
            {
                (DGWConsultorios_profesional.DataSource as DataTable).DefaultView.RowFilter = "";
            }
        }
    }
}