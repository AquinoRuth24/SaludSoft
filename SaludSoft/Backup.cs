using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace SaludSoft
{
    public partial class Backup : Form
    {
        private readonly string _cnx =
          "Server=localhost\\SQLEXPRESS;Database=SaludSoft;Trusted_Connection=True;";
        public Backup()
        {
            InitializeComponent();

            tbRuta.ReadOnly = true;
            cbBd.DropDownStyle = ComboBoxStyle.DropDownList;
            btRuta.Enabled = false;
            button1.Enabled = false;

            btConectar.Click += btConectar_Click;
            btRuta.Click += btRuta_Click;
            button1.Click += button1_Click;
        }

        // C# 7.3: sin 'using var'
        private bool SoportaCompresion()
        {
            try
            {
                using (var cn = new SqlConnection(_cnx))
                using (var cmd = new SqlCommand(
                    "SELECT CASE WHEN SERVERPROPERTY('EngineEdition') IN (2,3,5,8) THEN 1 ELSE 0 END", cn))
                {
                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool SeleccionarRutaSiHaceFalta()
        {
            if (!string.IsNullOrWhiteSpace(tbRuta.Text) && Directory.Exists(tbRuta.Text))
                return true;

            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Elegí la carpeta donde guardar el archivo .bak";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    tbRuta.Text = fbd.SelectedPath;
                    return true;
                }
            }
            return false;
        }

        private void btConectar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var cn = new SqlConnection(_cnx))
                using (var cmd = new SqlCommand(
                    "SELECT name FROM sys.databases WHERE database_id > 4 ORDER BY name;", cn))
                {
                    cn.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        cbBd.Items.Clear();
                        while (rd.Read()) cbBd.Items.Add(rd.GetString(0));
                    }
                }

                if (cbBd.Items.Count > 0)
                {
                    cbBd.SelectedIndex = 0;
                    btRuta.Enabled = true;
                    button1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se encontraron bases de datos de usuario.", "BackUp",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar o listar bases:\n" + ex.Message,
                    "BackUp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btRuta_Click(object sender, EventArgs e)
        {
            SeleccionarRutaSiHaceFalta();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bd = cbBd.SelectedItem == null ? null : cbBd.SelectedItem.ToString();
            if (string.IsNullOrWhiteSpace(bd))
            {
                MessageBox.Show("Seleccioná una base de datos.", "BackUp",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!SeleccionarRutaSiHaceFalta()) return;

            string carpeta = tbRuta.Text.Trim();
            string archivo = string.Format("{0}_{1:yyyyMMdd_HHmmss}.bak", bd, DateTime.Now);
            string pathFinal = Path.Combine(carpeta, archivo);

            string opciones = @"
WITH INIT, COPY_ONLY, STATS = 5,
     NAME = N'Backup manual',
     DESCRIPTION = N'Respaldo generado desde SaludSoft'";
            if (SoportaCompresion())
                opciones = @"
WITH INIT, COPY_ONLY, COMPRESSION, STATS = 5,
     NAME = N'Backup manual',
     DESCRIPTION = N'Respaldo generado desde SaludSoft'";

            try
            {
                using (var cn = new SqlConnection(_cnx))
                using (var cmd = new SqlCommand(string.Format(@"
BACKUP DATABASE [{0}]
TO DISK = @Path
{1};", bd, opciones), cn))
                {
                    cmd.Parameters.Add("@Path", SqlDbType.NVarChar, 4000).Value = pathFinal;
                    cn.Open();
                    cmd.CommandTimeout = 0;
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("✅ Backup creado:\n" + pathFinal,
                    "BackUp", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK; // volver a Admin
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error SQL al crear el backup:\n" + ex.Message,
                    "BackUp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado:\n" + ex.Message,
                    "BackUp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbBd_SelectedIndexChanged(object sender, EventArgs e) { }
        private void tbRuta_TextChanged(object sender, EventArgs e) { }
        private void lBd_Click(object sender, EventArgs e) { }
    }
}
