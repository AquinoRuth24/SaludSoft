namespace SaludSoft.Resources
{
    partial class FormUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btVolver = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lSubtitulo = new System.Windows.Forms.Label();
            this.lTitulo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbComun = new System.Windows.Forms.GroupBox();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.lTelefono = new System.Windows.Forms.Label();
            this.tbCorreo = new System.Windows.Forms.TextBox();
            this.lCorreo = new System.Windows.Forms.Label();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.lApellido = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lNombre = new System.Windows.Forms.Label();
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.gbPaciente = new System.Windows.Forms.GroupBox();
            this.tbDni = new System.Windows.Forms.TextBox();
            this.rbMasculino = new System.Windows.Forms.RadioButton();
            this.lDni = new System.Windows.Forms.Label();
            this.rbFemenino = new System.Windows.Forms.RadioButton();
            this.lSexo = new System.Windows.Forms.Label();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.lDireccion = new System.Windows.Forms.Label();
            this.tbEdad = new System.Windows.Forms.TextBox();
            this.lEdad = new System.Windows.Forms.Label();
            this.gbMedico = new System.Windows.Forms.GroupBox();
            this.CmbEspecialidades = new System.Windows.Forms.ComboBox();
            this.tbContraseñaMedico = new System.Windows.Forms.TextBox();
            this.tbMatricula = new System.Windows.Forms.TextBox();
            this.lContraseñaMedico = new System.Windows.Forms.Label();
            this.lMatricula = new System.Windows.Forms.Label();
            this.lEspecialidad = new System.Windows.Forms.Label();
            this.gbRecepcionista = new System.Windows.Forms.GroupBox();
            this.tbContraseñaRecep = new System.Windows.Forms.TextBox();
            this.lContraseñaRecepcionista = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAgregar = new System.Windows.Forms.Button();
            this.gbAdmin = new System.Windows.Forms.GroupBox();
            this.lContraAdmin = new System.Windows.Forms.Label();
            this.tbContraAdmin = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbComun.SuspendLayout();
            this.gbPaciente.SuspendLayout();
            this.gbMedico.SuspendLayout();
            this.gbRecepcionista.SuspendLayout();
            this.gbAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btVolver);
            this.panel1.Location = new System.Drawing.Point(1, 57);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 461);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::SaludSoft.Properties.Resources.circulo_marca_x;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 408);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 37);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cerrar Sesión";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btVolver
            // 
            this.btVolver.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btVolver.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVolver.Image = global::SaludSoft.Properties.Resources.angulo_izquierdo;
            this.btVolver.Location = new System.Drawing.Point(43, 14);
            this.btVolver.Margin = new System.Windows.Forms.Padding(2);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(50, 31);
            this.btVolver.TabIndex = 3;
            this.btVolver.UseVisualStyleBackColor = false;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.lSubtitulo);
            this.panel2.Controls.Add(this.lTitulo);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(938, 60);
            this.panel2.TabIndex = 2;
            // 
            // lSubtitulo
            // 
            this.lSubtitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lSubtitulo.AutoSize = true;
            this.lSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lSubtitulo.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSubtitulo.Location = new System.Drawing.Point(345, 37);
            this.lSubtitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lSubtitulo.Name = "lSubtitulo";
            this.lSubtitulo.Size = new System.Drawing.Size(249, 20);
            this.lSubtitulo.TabIndex = 3;
            this.lSubtitulo.Text = "Ingrese los datos del nuevo usuario";
            this.lSubtitulo.Click += new System.EventHandler(this.lSubtitulo_Click);
            // 
            // lTitulo
            // 
            this.lTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lTitulo.AutoSize = true;
            this.lTitulo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lTitulo.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitulo.Location = new System.Drawing.Point(396, 9);
            this.lTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(158, 29);
            this.lTitulo.TabIndex = 3;
            this.lTitulo.Text = "Nuevo Usuario";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SaludSoft.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // gbComun
            // 
            this.gbComun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbComun.Controls.Add(this.tbTelefono);
            this.gbComun.Controls.Add(this.lTelefono);
            this.gbComun.Controls.Add(this.tbCorreo);
            this.gbComun.Controls.Add(this.lCorreo);
            this.gbComun.Controls.Add(this.tbApellido);
            this.gbComun.Controls.Add(this.lApellido);
            this.gbComun.Controls.Add(this.tbNombre);
            this.gbComun.Controls.Add(this.lNombre);
            this.gbComun.Location = new System.Drawing.Point(147, 97);
            this.gbComun.Margin = new System.Windows.Forms.Padding(2);
            this.gbComun.Name = "gbComun";
            this.gbComun.Padding = new System.Windows.Forms.Padding(2);
            this.gbComun.Size = new System.Drawing.Size(584, 139);
            this.gbComun.TabIndex = 3;
            this.gbComun.TabStop = false;
            // 
            // tbTelefono
            // 
            this.tbTelefono.Location = new System.Drawing.Point(271, 105);
            this.tbTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(137, 20);
            this.tbTelefono.TabIndex = 5;
            // 
            // lTelefono
            // 
            this.lTelefono.AutoSize = true;
            this.lTelefono.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTelefono.Location = new System.Drawing.Point(124, 104);
            this.lTelefono.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lTelefono.Name = "lTelefono";
            this.lTelefono.Size = new System.Drawing.Size(79, 20);
            this.lTelefono.TabIndex = 5;
            this.lTelefono.Text = "Teléfono: ";
            this.lTelefono.Click += new System.EventHandler(this.lTelefono_Click);
            // 
            // tbCorreo
            // 
            this.tbCorreo.Location = new System.Drawing.Point(271, 76);
            this.tbCorreo.Margin = new System.Windows.Forms.Padding(2);
            this.tbCorreo.Name = "tbCorreo";
            this.tbCorreo.Size = new System.Drawing.Size(137, 20);
            this.tbCorreo.TabIndex = 5;
            // 
            // lCorreo
            // 
            this.lCorreo.AutoSize = true;
            this.lCorreo.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCorreo.Location = new System.Drawing.Point(57, 75);
            this.lCorreo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lCorreo.Name = "lCorreo";
            this.lCorreo.Size = new System.Drawing.Size(146, 20);
            this.lCorreo.TabIndex = 5;
            this.lCorreo.Text = "Correo Electrónico: ";
            // 
            // tbApellido
            // 
            this.tbApellido.Location = new System.Drawing.Point(271, 47);
            this.tbApellido.Margin = new System.Windows.Forms.Padding(2);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(137, 20);
            this.tbApellido.TabIndex = 5;
            // 
            // lApellido
            // 
            this.lApellido.AutoSize = true;
            this.lApellido.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lApellido.Location = new System.Drawing.Point(115, 47);
            this.lApellido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lApellido.Name = "lApellido";
            this.lApellido.Size = new System.Drawing.Size(88, 19);
            this.lApellido.TabIndex = 5;
            this.lApellido.Text = "Apellido(s): ";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(271, 17);
            this.tbNombre.Margin = new System.Windows.Forms.Padding(2);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(137, 20);
            this.tbNombre.TabIndex = 5;
            // 
            // lNombre
            // 
            this.lNombre.AutoSize = true;
            this.lNombre.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNombre.Location = new System.Drawing.Point(109, 15);
            this.lNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lNombre.Name = "lNombre";
            this.lNombre.Size = new System.Drawing.Size(97, 20);
            this.lNombre.TabIndex = 5;
            this.lNombre.Text = "Nombres(s): ";
            // 
            // cbRol
            // 
            this.cbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRol.FormattingEnabled = true;
            this.cbRol.Items.AddRange(new object[] {
            "Paciente",
            "Médico",
            "Recepcionista",
            "Administrador"});
            this.cbRol.Location = new System.Drawing.Point(147, 72);
            this.cbRol.Margin = new System.Windows.Forms.Padding(2);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(155, 21);
            this.cbRol.TabIndex = 4;
            this.cbRol.SelectedIndexChanged += new System.EventHandler(this.cbRol_SelectedIndexChanged);
            // 
            // gbPaciente
            // 
            this.gbPaciente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPaciente.Controls.Add(this.tbDni);
            this.gbPaciente.Controls.Add(this.rbMasculino);
            this.gbPaciente.Controls.Add(this.lDni);
            this.gbPaciente.Controls.Add(this.rbFemenino);
            this.gbPaciente.Controls.Add(this.lSexo);
            this.gbPaciente.Controls.Add(this.tbDireccion);
            this.gbPaciente.Controls.Add(this.lDireccion);
            this.gbPaciente.Controls.Add(this.tbEdad);
            this.gbPaciente.Controls.Add(this.lEdad);
            this.gbPaciente.Location = new System.Drawing.Point(147, 267);
            this.gbPaciente.Margin = new System.Windows.Forms.Padding(2);
            this.gbPaciente.Name = "gbPaciente";
            this.gbPaciente.Padding = new System.Windows.Forms.Padding(2);
            this.gbPaciente.Size = new System.Drawing.Size(583, 95);
            this.gbPaciente.TabIndex = 5;
            this.gbPaciente.TabStop = false;
            this.gbPaciente.Visible = false;
            // 
            // tbDni
            // 
            this.tbDni.Location = new System.Drawing.Point(167, 14);
            this.tbDni.Name = "tbDni";
            this.tbDni.Size = new System.Drawing.Size(137, 20);
            this.tbDni.TabIndex = 11;
            // 
            // rbMasculino
            // 
            this.rbMasculino.AutoSize = true;
            this.rbMasculino.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMasculino.Location = new System.Drawing.Point(459, 14);
            this.rbMasculino.Margin = new System.Windows.Forms.Padding(2);
            this.rbMasculino.Name = "rbMasculino";
            this.rbMasculino.Size = new System.Drawing.Size(45, 24);
            this.rbMasculino.TabIndex = 7;
            this.rbMasculino.TabStop = true;
            this.rbMasculino.Text = "M ";
            this.rbMasculino.UseVisualStyleBackColor = true;
            // 
            // lDni
            // 
            this.lDni.AutoSize = true;
            this.lDni.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lDni.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDni.Location = new System.Drawing.Point(107, 17);
            this.lDni.Name = "lDni";
            this.lDni.Size = new System.Drawing.Size(48, 19);
            this.lDni.TabIndex = 10;
            this.lDni.Text = "DNI: ";
            // 
            // rbFemenino
            // 
            this.rbFemenino.AutoSize = true;
            this.rbFemenino.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFemenino.Location = new System.Drawing.Point(395, 14);
            this.rbFemenino.Margin = new System.Windows.Forms.Padding(2);
            this.rbFemenino.Name = "rbFemenino";
            this.rbFemenino.Size = new System.Drawing.Size(42, 24);
            this.rbFemenino.TabIndex = 7;
            this.rbFemenino.TabStop = true;
            this.rbFemenino.Text = "F ";
            this.rbFemenino.UseVisualStyleBackColor = true;
            this.rbFemenino.CheckedChanged += new System.EventHandler(this.rbFemenino_CheckedChanged);
            // 
            // lSexo
            // 
            this.lSexo.AutoSize = true;
            this.lSexo.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSexo.Location = new System.Drawing.Point(337, 17);
            this.lSexo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lSexo.Name = "lSexo";
            this.lSexo.Size = new System.Drawing.Size(54, 20);
            this.lSexo.TabIndex = 7;
            this.lSexo.Text = "Sexo: ";
            // 
            // tbDireccion
            // 
            this.tbDireccion.Location = new System.Drawing.Point(167, 73);
            this.tbDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(121, 20);
            this.tbDireccion.TabIndex = 6;
            // 
            // lDireccion
            // 
            this.lDireccion.AutoSize = true;
            this.lDireccion.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDireccion.Location = new System.Drawing.Point(81, 70);
            this.lDireccion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lDireccion.Name = "lDireccion";
            this.lDireccion.Size = new System.Drawing.Size(82, 20);
            this.lDireccion.TabIndex = 6;
            this.lDireccion.Text = "Dirección: ";
            // 
            // tbEdad
            // 
            this.tbEdad.Location = new System.Drawing.Point(167, 43);
            this.tbEdad.Margin = new System.Windows.Forms.Padding(2);
            this.tbEdad.Name = "tbEdad";
            this.tbEdad.Size = new System.Drawing.Size(68, 20);
            this.tbEdad.TabIndex = 6;
            // 
            // lEdad
            // 
            this.lEdad.AutoSize = true;
            this.lEdad.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEdad.Location = new System.Drawing.Point(104, 44);
            this.lEdad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lEdad.Name = "lEdad";
            this.lEdad.Size = new System.Drawing.Size(54, 20);
            this.lEdad.TabIndex = 6;
            this.lEdad.Text = "Edad: ";
            // 
            // gbMedico
            // 
            this.gbMedico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMedico.Controls.Add(this.CmbEspecialidades);
            this.gbMedico.Controls.Add(this.tbContraseñaMedico);
            this.gbMedico.Controls.Add(this.tbMatricula);
            this.gbMedico.Controls.Add(this.lContraseñaMedico);
            this.gbMedico.Controls.Add(this.lMatricula);
            this.gbMedico.Controls.Add(this.lEspecialidad);
            this.gbMedico.Location = new System.Drawing.Point(147, 253);
            this.gbMedico.Margin = new System.Windows.Forms.Padding(2);
            this.gbMedico.Name = "gbMedico";
            this.gbMedico.Padding = new System.Windows.Forms.Padding(2);
            this.gbMedico.Size = new System.Drawing.Size(584, 94);
            this.gbMedico.TabIndex = 6;
            this.gbMedico.TabStop = false;
            this.gbMedico.Visible = false;
            // 
            // CmbEspecialidades
            // 
            this.CmbEspecialidades.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEspecialidades.FormattingEnabled = true;
            this.CmbEspecialidades.Location = new System.Drawing.Point(293, 9);
            this.CmbEspecialidades.Name = "CmbEspecialidades";
            this.CmbEspecialidades.Size = new System.Drawing.Size(121, 26);
            this.CmbEspecialidades.TabIndex = 9;
            // 
            // tbContraseñaMedico
            // 
            this.tbContraseñaMedico.Location = new System.Drawing.Point(287, 73);
            this.tbContraseñaMedico.Margin = new System.Windows.Forms.Padding(2);
            this.tbContraseñaMedico.Name = "tbContraseñaMedico";
            this.tbContraseñaMedico.Size = new System.Drawing.Size(127, 20);
            this.tbContraseñaMedico.TabIndex = 8;
            // 
            // tbMatricula
            // 
            this.tbMatricula.Location = new System.Drawing.Point(287, 44);
            this.tbMatricula.Margin = new System.Windows.Forms.Padding(2);
            this.tbMatricula.Name = "tbMatricula";
            this.tbMatricula.Size = new System.Drawing.Size(127, 20);
            this.tbMatricula.TabIndex = 7;
            // 
            // lContraseñaMedico
            // 
            this.lContraseñaMedico.AutoSize = true;
            this.lContraseñaMedico.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lContraseñaMedico.Location = new System.Drawing.Point(101, 71);
            this.lContraseñaMedico.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lContraseñaMedico.Name = "lContraseñaMedico";
            this.lContraseñaMedico.Size = new System.Drawing.Size(96, 20);
            this.lContraseñaMedico.TabIndex = 7;
            this.lContraseñaMedico.Text = "Contraseña: ";
            // 
            // lMatricula
            // 
            this.lMatricula.AutoSize = true;
            this.lMatricula.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMatricula.Location = new System.Drawing.Point(112, 40);
            this.lMatricula.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lMatricula.Name = "lMatricula";
            this.lMatricula.Size = new System.Drawing.Size(85, 20);
            this.lMatricula.TabIndex = 7;
            this.lMatricula.Text = "Matrícula: ";
            // 
            // lEspecialidad
            // 
            this.lEspecialidad.AutoSize = true;
            this.lEspecialidad.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEspecialidad.Location = new System.Drawing.Point(104, 8);
            this.lEspecialidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lEspecialidad.Name = "lEspecialidad";
            this.lEspecialidad.Size = new System.Drawing.Size(103, 20);
            this.lEspecialidad.TabIndex = 7;
            this.lEspecialidad.Text = "Especialidad: ";
            // 
            // gbRecepcionista
            // 
            this.gbRecepcionista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRecepcionista.Controls.Add(this.tbContraseñaRecep);
            this.gbRecepcionista.Controls.Add(this.lContraseñaRecepcionista);
            this.gbRecepcionista.Location = new System.Drawing.Point(144, 277);
            this.gbRecepcionista.Margin = new System.Windows.Forms.Padding(2);
            this.gbRecepcionista.Name = "gbRecepcionista";
            this.gbRecepcionista.Padding = new System.Windows.Forms.Padding(2);
            this.gbRecepcionista.Size = new System.Drawing.Size(587, 58);
            this.gbRecepcionista.TabIndex = 7;
            this.gbRecepcionista.TabStop = false;
            this.gbRecepcionista.Visible = false;
            // 
            // tbContraseñaRecep
            // 
            this.tbContraseñaRecep.Location = new System.Drawing.Point(279, 14);
            this.tbContraseñaRecep.Margin = new System.Windows.Forms.Padding(2);
            this.tbContraseñaRecep.Name = "tbContraseñaRecep";
            this.tbContraseñaRecep.Size = new System.Drawing.Size(124, 20);
            this.tbContraseñaRecep.TabIndex = 1;
            // 
            // lContraseñaRecepcionista
            // 
            this.lContraseñaRecepcionista.AutoSize = true;
            this.lContraseñaRecepcionista.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lContraseñaRecepcionista.Location = new System.Drawing.Point(112, 14);
            this.lContraseñaRecepcionista.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lContraseñaRecepcionista.Name = "lContraseñaRecepcionista";
            this.lContraseñaRecepcionista.Size = new System.Drawing.Size(96, 20);
            this.lContraseñaRecepcionista.TabIndex = 0;
            this.lContraseñaRecepcionista.Text = "Contraseña: ";
            this.lContraseñaRecepcionista.Click += new System.EventHandler(this.lContraseñaRecep_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btCancelar.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Location = new System.Drawing.Point(775, 418);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(91, 39);
            this.btCancelar.TabIndex = 7;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAgregar
            // 
            this.btAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btAgregar.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAgregar.Location = new System.Drawing.Point(638, 418);
            this.btAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(92, 39);
            this.btAgregar.TabIndex = 8;
            this.btAgregar.Text = "Agregar ";
            this.btAgregar.UseVisualStyleBackColor = false;
            this.btAgregar.Click += new System.EventHandler(this.btAgregar_Click);
            // 
            // gbAdmin
            // 
            this.gbAdmin.Controls.Add(this.lContraAdmin);
            this.gbAdmin.Controls.Add(this.tbContraAdmin);
            this.gbAdmin.Location = new System.Drawing.Point(162, 253);
            this.gbAdmin.Name = "gbAdmin";
            this.gbAdmin.Size = new System.Drawing.Size(517, 82);
            this.gbAdmin.TabIndex = 9;
            this.gbAdmin.TabStop = false;
            // 
            // lContraAdmin
            // 
            this.lContraAdmin.AutoSize = true;
            this.lContraAdmin.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lContraAdmin.Location = new System.Drawing.Point(118, 19);
            this.lContraAdmin.Name = "lContraAdmin";
            this.lContraAdmin.Size = new System.Drawing.Size(89, 19);
            this.lContraAdmin.TabIndex = 1;
            this.lContraAdmin.Text = "Contraseña: ";
            // 
            // tbContraAdmin
            // 
            this.tbContraAdmin.Location = new System.Drawing.Point(276, 19);
            this.tbContraAdmin.Name = "tbContraAdmin";
            this.tbContraAdmin.Size = new System.Drawing.Size(135, 20);
            this.tbContraAdmin.TabIndex = 0;
            // 
            // FormUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(938, 513);
            this.Controls.Add(this.gbPaciente);
            this.Controls.Add(this.gbAdmin);
            this.Controls.Add(this.gbMedico);
            this.Controls.Add(this.gbRecepcionista);
            this.Controls.Add(this.btAgregar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.cbRol);
            this.Controls.Add(this.gbComun);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormUsuario";
            this.Text = "FormUsuario";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbComun.ResumeLayout(false);
            this.gbComun.PerformLayout();
            this.gbPaciente.ResumeLayout(false);
            this.gbPaciente.PerformLayout();
            this.gbMedico.ResumeLayout(false);
            this.gbMedico.PerformLayout();
            this.gbRecepcionista.ResumeLayout(false);
            this.gbRecepcionista.PerformLayout();
            this.gbAdmin.ResumeLayout(false);
            this.gbAdmin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.Label lSubtitulo;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox gbComun;
        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.Label lNombre;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label lApellido;
        private System.Windows.Forms.Label lCorreo;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.TextBox tbCorreo;
        private System.Windows.Forms.TextBox tbTelefono;
        private System.Windows.Forms.Label lTelefono;
        private System.Windows.Forms.GroupBox gbPaciente;
        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.Label lDireccion;
        private System.Windows.Forms.TextBox tbEdad;
        private System.Windows.Forms.Label lEdad;
        private System.Windows.Forms.Label lSexo;
        private System.Windows.Forms.GroupBox gbMedico;
        private System.Windows.Forms.TextBox tbMatricula;
        private System.Windows.Forms.Label lMatricula;
        private System.Windows.Forms.Label lEspecialidad;
        private System.Windows.Forms.RadioButton rbMasculino;
        private System.Windows.Forms.RadioButton rbFemenino;
        private System.Windows.Forms.TextBox tbContraseñaMedico;
        private System.Windows.Forms.Label lContraseñaMedico;
        private System.Windows.Forms.GroupBox gbRecepcionista;
        private System.Windows.Forms.TextBox tbContraseñaRecep;
        private System.Windows.Forms.Label lContraseñaRecepcionista;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAgregar;
        private System.Windows.Forms.GroupBox gbAdmin;
        private System.Windows.Forms.Label lContraAdmin;
        private System.Windows.Forms.TextBox tbContraAdmin;
        private System.Windows.Forms.ComboBox CmbEspecialidades;
        private System.Windows.Forms.Label lDni;
        private System.Windows.Forms.TextBox tbDni;
    }
}