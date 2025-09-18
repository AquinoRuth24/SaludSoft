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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lTitulo = new System.Windows.Forms.Label();
            this.lSubtitulo = new System.Windows.Forms.Label();
            this.btVolver = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbComun = new System.Windows.Forms.GroupBox();
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.lNombre = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lApellido = new System.Windows.Forms.Label();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.lCorreo = new System.Windows.Forms.Label();
            this.tbCorreo = new System.Windows.Forms.TextBox();
            this.lTelefono = new System.Windows.Forms.Label();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.gbPaciente = new System.Windows.Forms.GroupBox();
            this.lEdad = new System.Windows.Forms.Label();
            this.tbEdad = new System.Windows.Forms.TextBox();
            this.lDireccion = new System.Windows.Forms.Label();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.gbMedico = new System.Windows.Forms.GroupBox();
            this.lEspecialidad = new System.Windows.Forms.Label();
            this.tbEspecialidad = new System.Windows.Forms.TextBox();
            this.lMatricula = new System.Windows.Forms.Label();
            this.tbMatricula = new System.Windows.Forms.TextBox();
            this.lSexo = new System.Windows.Forms.Label();
            this.rbFemenino = new System.Windows.Forms.RadioButton();
            this.rbMasculino = new System.Windows.Forms.RadioButton();
            this.lContraseñaMedico = new System.Windows.Forms.Label();
            this.tbContraseñaMedico = new System.Windows.Forms.TextBox();
            this.gbAdmin = new System.Windows.Forms.GroupBox();
            this.lContraseñaAdmin = new System.Windows.Forms.Label();
            this.tbContraseñaAdmin = new System.Windows.Forms.TextBox();
            this.gbRecepcionista = new System.Windows.Forms.GroupBox();
            this.lContraseñaRecep = new System.Windows.Forms.Label();
            this.tbContraseñaRecep = new System.Windows.Forms.TextBox();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAgregar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.gbComun.SuspendLayout();
            this.gbPaciente.SuspendLayout();
            this.gbMedico.SuspendLayout();
            this.gbAdmin.SuspendLayout();
            this.gbRecepcionista.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btVolver);
            this.panel1.Location = new System.Drawing.Point(1, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 607);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SaludSoft.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.lSubtitulo);
            this.panel2.Controls.Add(this.lTitulo);
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(801, 93);
            this.panel2.TabIndex = 2;
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lTitulo.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitulo.Location = new System.Drawing.Point(315, 9);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(182, 34);
            this.lTitulo.TabIndex = 3;
            this.lTitulo.Text = "Nuevo Usuario";
            // 
            // lSubtitulo
            // 
            this.lSubtitulo.AutoSize = true;
            this.lSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lSubtitulo.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSubtitulo.Location = new System.Drawing.Point(215, 53);
            this.lSubtitulo.Name = "lSubtitulo";
            this.lSubtitulo.Size = new System.Drawing.Size(359, 29);
            this.lSubtitulo.TabIndex = 3;
            this.lSubtitulo.Text = "Ingrese los datos del nuevo usuario";
            // 
            // btVolver
            // 
            this.btVolver.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btVolver.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVolver.Image = global::SaludSoft.Properties.Resources.angulo_izquierdo;
            this.btVolver.Location = new System.Drawing.Point(64, 22);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(75, 48);
            this.btVolver.TabIndex = 3;
            this.btVolver.UseVisualStyleBackColor = false;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::SaludSoft.Properties.Resources.hogar;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(21, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 48);
            this.button1.TabIndex = 3;
            this.button1.Text = "Inicio ";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::SaludSoft.Properties.Resources.circulo_marca_x;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(11, 496);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 43);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cerrar Sesión";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(199, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(788, 351);
            this.panel3.TabIndex = 3;
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
            this.gbComun.Location = new System.Drawing.Point(221, 173);
            this.gbComun.Name = "gbComun";
            this.gbComun.Size = new System.Drawing.Size(785, 214);
            this.gbComun.TabIndex = 3;
            this.gbComun.TabStop = false;
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
            this.cbRol.Location = new System.Drawing.Point(221, 110);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(231, 28);
            this.cbRol.TabIndex = 4;
            this.cbRol.SelectedIndexChanged += new System.EventHandler(this.cbRol_SelectedIndexChanged);
            // 
            // lNombre
            // 
            this.lNombre.AutoSize = true;
            this.lNombre.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNombre.Location = new System.Drawing.Point(163, 28);
            this.lNombre.Name = "lNombre";
            this.lNombre.Size = new System.Drawing.Size(141, 29);
            this.lNombre.TabIndex = 5;
            this.lNombre.Text = "Nombres(s): ";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(416, 28);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(203, 26);
            this.tbNombre.TabIndex = 5;
            // 
            // lApellido
            // 
            this.lApellido.AutoSize = true;
            this.lApellido.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lApellido.Location = new System.Drawing.Point(173, 73);
            this.lApellido.Name = "lApellido";
            this.lApellido.Size = new System.Drawing.Size(131, 29);
            this.lApellido.TabIndex = 5;
            this.lApellido.Text = "Apellido(s): ";
            // 
            // tbApellido
            // 
            this.tbApellido.Location = new System.Drawing.Point(416, 76);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(203, 26);
            this.tbApellido.TabIndex = 5;
            // 
            // lCorreo
            // 
            this.lCorreo.AutoSize = true;
            this.lCorreo.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCorreo.Location = new System.Drawing.Point(94, 124);
            this.lCorreo.Name = "lCorreo";
            this.lCorreo.Size = new System.Drawing.Size(210, 29);
            this.lCorreo.TabIndex = 5;
            this.lCorreo.Text = "Correo Electrónico: ";
            // 
            // tbCorreo
            // 
            this.tbCorreo.Location = new System.Drawing.Point(416, 124);
            this.tbCorreo.Name = "tbCorreo";
            this.tbCorreo.Size = new System.Drawing.Size(203, 26);
            this.tbCorreo.TabIndex = 5;
            // 
            // lTelefono
            // 
            this.lTelefono.AutoSize = true;
            this.lTelefono.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTelefono.Location = new System.Drawing.Point(190, 166);
            this.lTelefono.Name = "lTelefono";
            this.lTelefono.Size = new System.Drawing.Size(114, 29);
            this.lTelefono.TabIndex = 5;
            this.lTelefono.Text = "Teléfono: ";
            // 
            // tbTelefono
            // 
            this.tbTelefono.Location = new System.Drawing.Point(416, 170);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(203, 26);
            this.tbTelefono.TabIndex = 5;
            // 
            // gbPaciente
            // 
            this.gbPaciente.Controls.Add(this.gbMedico);
            this.gbPaciente.Controls.Add(this.rbMasculino);
            this.gbPaciente.Controls.Add(this.rbFemenino);
            this.gbPaciente.Controls.Add(this.lSexo);
            this.gbPaciente.Controls.Add(this.tbDireccion);
            this.gbPaciente.Controls.Add(this.lDireccion);
            this.gbPaciente.Controls.Add(this.tbEdad);
            this.gbPaciente.Controls.Add(this.lEdad);
            this.gbPaciente.Location = new System.Drawing.Point(221, 393);
            this.gbPaciente.Name = "gbPaciente";
            this.gbPaciente.Size = new System.Drawing.Size(780, 100);
            this.gbPaciente.TabIndex = 5;
            this.gbPaciente.TabStop = false;
            this.gbPaciente.Visible = false;
            // 
            // lEdad
            // 
            this.lEdad.AutoSize = true;
            this.lEdad.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEdad.Location = new System.Drawing.Point(163, 20);
            this.lEdad.Name = "lEdad";
            this.lEdad.Size = new System.Drawing.Size(78, 29);
            this.lEdad.TabIndex = 6;
            this.lEdad.Text = "Edad: ";
            // 
            // tbEdad
            // 
            this.tbEdad.Location = new System.Drawing.Point(288, 20);
            this.tbEdad.Name = "tbEdad";
            this.tbEdad.Size = new System.Drawing.Size(100, 26);
            this.tbEdad.TabIndex = 6;
            // 
            // lDireccion
            // 
            this.lDireccion.AutoSize = true;
            this.lDireccion.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDireccion.Location = new System.Drawing.Point(122, 68);
            this.lDireccion.Name = "lDireccion";
            this.lDireccion.Size = new System.Drawing.Size(119, 29);
            this.lDireccion.TabIndex = 6;
            this.lDireccion.Text = "Dirección: ";
            // 
            // tbDireccion
            // 
            this.tbDireccion.Location = new System.Drawing.Point(288, 68);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(180, 26);
            this.tbDireccion.TabIndex = 6;
            // 
            // gbMedico
            // 
            this.gbMedico.Controls.Add(this.tbContraseñaMedico);
            this.gbMedico.Controls.Add(this.tbMatricula);
            this.gbMedico.Controls.Add(this.lContraseñaMedico);
            this.gbMedico.Controls.Add(this.lMatricula);
            this.gbMedico.Controls.Add(this.tbEspecialidad);
            this.gbMedico.Controls.Add(this.lEspecialidad);
            this.gbMedico.Location = new System.Drawing.Point(0, 10);
            this.gbMedico.Name = "gbMedico";
            this.gbMedico.Size = new System.Drawing.Size(780, 144);
            this.gbMedico.TabIndex = 6;
            this.gbMedico.TabStop = false;
            this.gbMedico.Visible = false;
            // 
            // lEspecialidad
            // 
            this.lEspecialidad.AutoSize = true;
            this.lEspecialidad.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEspecialidad.Location = new System.Drawing.Point(156, 12);
            this.lEspecialidad.Name = "lEspecialidad";
            this.lEspecialidad.Size = new System.Drawing.Size(148, 29);
            this.lEspecialidad.TabIndex = 7;
            this.lEspecialidad.Text = "Especialidad: ";
            // 
            // tbEspecialidad
            // 
            this.tbEspecialidad.Location = new System.Drawing.Point(431, 12);
            this.tbEspecialidad.Name = "tbEspecialidad";
            this.tbEspecialidad.Size = new System.Drawing.Size(188, 26);
            this.tbEspecialidad.TabIndex = 8;
            // 
            // lMatricula
            // 
            this.lMatricula.AutoSize = true;
            this.lMatricula.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMatricula.Location = new System.Drawing.Point(183, 62);
            this.lMatricula.Name = "lMatricula";
            this.lMatricula.Size = new System.Drawing.Size(121, 29);
            this.lMatricula.TabIndex = 7;
            this.lMatricula.Text = "Matrícula: ";
            // 
            // tbMatricula
            // 
            this.tbMatricula.Location = new System.Drawing.Point(431, 66);
            this.tbMatricula.Name = "tbMatricula";
            this.tbMatricula.Size = new System.Drawing.Size(188, 26);
            this.tbMatricula.TabIndex = 7;
            // 
            // lSexo
            // 
            this.lSexo.AutoSize = true;
            this.lSexo.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSexo.Location = new System.Drawing.Point(505, 26);
            this.lSexo.Name = "lSexo";
            this.lSexo.Size = new System.Drawing.Size(79, 29);
            this.lSexo.TabIndex = 7;
            this.lSexo.Text = "Sexo: ";
            // 
            // rbFemenino
            // 
            this.rbFemenino.AutoSize = true;
            this.rbFemenino.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFemenino.Location = new System.Drawing.Point(609, 26);
            this.rbFemenino.Name = "rbFemenino";
            this.rbFemenino.Size = new System.Drawing.Size(59, 33);
            this.rbFemenino.TabIndex = 7;
            this.rbFemenino.TabStop = true;
            this.rbFemenino.Text = "F ";
            this.rbFemenino.UseVisualStyleBackColor = true;
            this.rbFemenino.CheckedChanged += new System.EventHandler(this.rbFemenino_CheckedChanged);
            // 
            // rbMasculino
            // 
            this.rbMasculino.AutoSize = true;
            this.rbMasculino.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMasculino.Location = new System.Drawing.Point(689, 22);
            this.rbMasculino.Name = "rbMasculino";
            this.rbMasculino.Size = new System.Drawing.Size(65, 33);
            this.rbMasculino.TabIndex = 7;
            this.rbMasculino.TabStop = true;
            this.rbMasculino.Text = "M ";
            this.rbMasculino.UseVisualStyleBackColor = true;
            // 
            // lContraseñaMedico
            // 
            this.lContraseñaMedico.AutoSize = true;
            this.lContraseñaMedico.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lContraseñaMedico.Location = new System.Drawing.Point(168, 99);
            this.lContraseñaMedico.Name = "lContraseñaMedico";
            this.lContraseñaMedico.Size = new System.Drawing.Size(136, 29);
            this.lContraseñaMedico.TabIndex = 7;
            this.lContraseñaMedico.Text = "Contraseña: ";
            // 
            // tbContraseñaMedico
            // 
            this.tbContraseñaMedico.Location = new System.Drawing.Point(431, 112);
            this.tbContraseñaMedico.Name = "tbContraseñaMedico";
            this.tbContraseñaMedico.Size = new System.Drawing.Size(188, 26);
            this.tbContraseñaMedico.TabIndex = 8;
            // 
            // gbAdmin
            // 
            this.gbAdmin.Controls.Add(this.gbRecepcionista);
            this.gbAdmin.Controls.Add(this.tbContraseñaAdmin);
            this.gbAdmin.Controls.Add(this.lContraseñaAdmin);
            this.gbAdmin.Location = new System.Drawing.Point(221, 398);
            this.gbAdmin.Name = "gbAdmin";
            this.gbAdmin.Size = new System.Drawing.Size(780, 89);
            this.gbAdmin.TabIndex = 6;
            this.gbAdmin.TabStop = false;
            this.gbAdmin.Visible = false;
            // 
            // lContraseñaAdmin
            // 
            this.lContraseñaAdmin.AutoSize = true;
            this.lContraseñaAdmin.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lContraseñaAdmin.Location = new System.Drawing.Point(167, 30);
            this.lContraseñaAdmin.Name = "lContraseñaAdmin";
            this.lContraseñaAdmin.Size = new System.Drawing.Size(136, 29);
            this.lContraseñaAdmin.TabIndex = 0;
            this.lContraseñaAdmin.Text = "Contraseña: ";
            // 
            // tbContraseñaAdmin
            // 
            this.tbContraseñaAdmin.Location = new System.Drawing.Point(415, 34);
            this.tbContraseñaAdmin.Name = "tbContraseñaAdmin";
            this.tbContraseñaAdmin.Size = new System.Drawing.Size(203, 26);
            this.tbContraseñaAdmin.TabIndex = 1;
            // 
            // gbRecepcionista
            // 
            this.gbRecepcionista.Controls.Add(this.tbContraseñaRecep);
            this.gbRecepcionista.Controls.Add(this.lContraseñaRecep);
            this.gbRecepcionista.Location = new System.Drawing.Point(0, 5);
            this.gbRecepcionista.Name = "gbRecepcionista";
            this.gbRecepcionista.Size = new System.Drawing.Size(785, 100);
            this.gbRecepcionista.TabIndex = 7;
            this.gbRecepcionista.TabStop = false;
            this.gbRecepcionista.Visible = false;
            // 
            // lContraseñaRecep
            // 
            this.lContraseñaRecep.AutoSize = true;
            this.lContraseñaRecep.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lContraseñaRecep.Location = new System.Drawing.Point(168, 22);
            this.lContraseñaRecep.Name = "lContraseñaRecep";
            this.lContraseñaRecep.Size = new System.Drawing.Size(136, 29);
            this.lContraseñaRecep.TabIndex = 0;
            this.lContraseñaRecep.Text = "Contraseña: ";
            // 
            // tbContraseñaRecep
            // 
            this.tbContraseñaRecep.Location = new System.Drawing.Point(416, 22);
            this.tbContraseñaRecep.Name = "tbContraseñaRecep";
            this.tbContraseñaRecep.Size = new System.Drawing.Size(187, 26);
            this.tbContraseñaRecep.TabIndex = 1;
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btCancelar.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Location = new System.Drawing.Point(617, 620);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(137, 51);
            this.btCancelar.TabIndex = 7;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAgregar
            // 
            this.btAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btAgregar.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAgregar.Location = new System.Drawing.Point(812, 622);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(138, 49);
            this.btAgregar.TabIndex = 8;
            this.btAgregar.Text = "Agregar ";
            this.btAgregar.UseVisualStyleBackColor = false;
            this.btAgregar.Click += new System.EventHandler(this.btAgregar_Click);
            // 
            // FormUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1003, 696);
            this.Controls.Add(this.btAgregar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.gbAdmin);
            this.Controls.Add(this.gbPaciente);
            this.Controls.Add(this.cbRol);
            this.Controls.Add(this.gbComun);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FormUsuario";
            this.Text = "FormUsuario";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbComun.ResumeLayout(false);
            this.gbComun.PerformLayout();
            this.gbPaciente.ResumeLayout(false);
            this.gbPaciente.PerformLayout();
            this.gbMedico.ResumeLayout(false);
            this.gbMedico.PerformLayout();
            this.gbAdmin.ResumeLayout(false);
            this.gbAdmin.PerformLayout();
            this.gbRecepcionista.ResumeLayout(false);
            this.gbRecepcionista.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.Label lSubtitulo;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.Panel panel3;
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
        private System.Windows.Forms.TextBox tbEspecialidad;
        private System.Windows.Forms.Label lEspecialidad;
        private System.Windows.Forms.RadioButton rbMasculino;
        private System.Windows.Forms.RadioButton rbFemenino;
        private System.Windows.Forms.TextBox tbContraseñaMedico;
        private System.Windows.Forms.Label lContraseñaMedico;
        private System.Windows.Forms.GroupBox gbAdmin;
        private System.Windows.Forms.TextBox tbContraseñaAdmin;
        private System.Windows.Forms.Label lContraseñaAdmin;
        private System.Windows.Forms.GroupBox gbRecepcionista;
        private System.Windows.Forms.TextBox tbContraseñaRecep;
        private System.Windows.Forms.Label lContraseñaRecep;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAgregar;
    }
}