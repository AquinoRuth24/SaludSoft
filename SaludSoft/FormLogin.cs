using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaludSoft.Security; 

namespace SaludSoft
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();

            this.AcceptButton = btIniciarSesion;
            tbContraseña.UseSystemPasswordChar = true;

            if (!DesignMode)
            {
                // === Usuario: correo electrónico ===
                tbUsuario.KeyPress += SoloEmail_KeyPress;
                tbUsuario.TextChanged += SanitizarEmailAlPegar;
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }

        // ====== CLICK LOGIN (BD + ruteo por rol) ======
        private void btIniciarSesion_Click(object sender, EventArgs e)
        {
            string email = tbUsuario.Text.Trim();
            string pass = tbContraseña.Text; // permitir cualquier char

            if (!EsEmailBasico(email))
            {
                MessageBox.Show("Ingresá un correo electrónico válido como usuario.",
                                "Usuario inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUsuario.Focus();
                tbUsuario.SelectAll();
                return;
            }

            if (string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Ingresá tu contraseña.", "Falta contraseña",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbContraseña.Focus();
                return;
            }

            try
            {
                var result = Autenticar(email, pass);
                if (result == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.",
                                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tbContraseña.Clear();
                    tbContraseña.Focus();
                    return;
                }

                AbrirSegunRol(result.Rol, result.Nombre);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar/autenticar:\n" + ex.Message,
                                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lOlvidasteContraseña_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Contactá al administrador o usa el proceso de recuperación.",
                "Olvidé mi contraseña",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

     
        // AUTENTICACIÓN contra BD
        private sealed class LoginResult
        {
            public int IdUsuario { get; set; }
            public string Nombre { get; set; }
            public string Rol { get; set; }
        }

        // Traemos el hash y verificamos en memoria.
        private LoginResult Autenticar(string email, string passwordIngresada)
        {
            const string sql = @"
SELECT TOP 1 
    u.id_usuario,
    (u.nombre + ' ' + u.apellido) AS nombreCompleto,
    r.descripcion AS rol,
    u.[contraseña] AS hashGuardado
FROM dbo.Usuario u
JOIN dbo.Rol r ON r.id_rol = u.id_rol
WHERE u.email = @email;";

            using (var cn = Conexion.GetConnection())
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 200).Value = email;

                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return null;

                    int id = rd.GetInt32(0);
                    string nombre = rd.GetString(1);
                    string rol = rd.GetString(2);
                    string hashGuardado = rd.IsDBNull(3) ? null : rd.GetString(3);

                    // Verificar hash
                    bool ok = PasswordHasher.Verify(passwordIngresada, hashGuardado);
                    if (!ok) return null;

                    return new LoginResult
                    {
                        IdUsuario = id,
                        Nombre = nombre,
                        Rol = rol
                    };
                }
            }
        }

        
        // Navegación por rol 
        private void AbrirSegunRol(string rol, string nombre)
        {
            string formName;
            switch (rol.Trim().ToLowerInvariant())
            {
                case "administrador": formName = "Admin"; break;           
                case "recepcionista": formName = "FormSaludSoft"; break;   
                case "medico": formName = "FormMedico"; break;     
                default:
                    MessageBox.Show($"Rol '{rol}' sin vista asignada.", "Aviso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }

            var destino = CrearFormularioPorNombre(formName);
            if (destino == null)
            {
                MessageBox.Show($"No se encontró el formulario '{formName}'. " +
                                $"Crealo o cambia el nombre en el switch.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            destino.StartPosition = FormStartPosition.CenterScreen;
            destino.Text = $"SaludSoft - {rol} | {nombre}";

            this.Hide();
            destino.FormClosed += (s, e) =>
            {
                tbContraseña.Clear();
                this.Show();
                this.Activate();
                tbUsuario.Focus();
            };
            destino.Show();
        }

        private Form CrearFormularioPorNombre(string nombreTipo)
        {
            var tipo = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => {
                    try { return a.GetTypes(); }
                    catch { return Array.Empty<Type>(); }
                })
                .FirstOrDefault(t =>
                    typeof(Form).IsAssignableFrom(t) &&
                    (t.Name.Equals(nombreTipo, StringComparison.OrdinalIgnoreCase) ||
                     (t.FullName != null && t.FullName.EndsWith("." + nombreTipo, StringComparison.OrdinalIgnoreCase))));

            if (tipo == null) return null;

            try { return (Form)Activator.CreateInstance(tipo); }
            catch { return null; }
        }

        
        // USUARIO = EMAIL (permitir @ . _ - + y sólo una @)
        private static bool EsEmailChar(char c)
            => char.IsLetterOrDigit(c) || c == '@' || c == '.' || c == '_' || c == '-' || c == '+';

        private void SoloEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;              
            if (e.KeyChar == ' ') { e.Handled = true; return; } 

            if (!EsEmailChar(e.KeyChar)) { e.Handled = true; return; }

            // una sola @
            var tb = (TextBox)sender;
            if (e.KeyChar == '@' && tb.Text.Contains('@'))
                e.Handled = true;
        }

        private void SanitizarEmailAlPegar(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            int caret = tb.SelectionStart;

            var sb = new StringBuilder(tb.Text.Length);
            bool vioArroba = false;

            foreach (char c in tb.Text)
            {
                if (!EsEmailChar(c)) continue;

                if (c == '@')
                {
                    if (vioArroba) continue; 
                    vioArroba = true;
                }

                sb.Append(c);
            }

            if (tb.Text != sb.ToString())
            {
                tb.Text = sb.ToString();
                tb.SelectionStart = Math.Min(caret, tb.Text.Length);
            }
        }

        // Validación
        private static bool EsEmailBasico(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            int at = s.IndexOf('@'); if (at <= 0) return false;
            int dot = s.LastIndexOf('.'); if (dot <= at + 1) return false;
            if (dot == s.Length - 1) return false;
            return true;
        }


        private void tbUsuario_TextChanged(object sender, EventArgs e) { }
        private void tbContraseña_TextChanged(object sender, EventArgs e) { }
    }
}
