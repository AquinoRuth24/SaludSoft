namespace SaludSoft
{
    partial class FormPaciente
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
            this.LabelRegistroPaciente = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LPaciente = new System.Windows.Forms.Label();
            this.LTexto = new System.Windows.Forms.Label();
            this.TBEmail = new System.Windows.Forms.TextBox();
            this.TBDireccion = new System.Windows.Forms.TextBox();
            this.TBTelefono = new System.Windows.Forms.TextBox();
            this.LDireccion = new System.Windows.Forms.Label();
            this.LCorreo = new System.Windows.Forms.Label();
            this.LTelefono = new System.Windows.Forms.Label();
            this.BRegistrar = new System.Windows.Forms.Button();
            this.BEliminar = new System.Windows.Forms.Button();
            this.LNombre = new System.Windows.Forms.Label();
            this.LDni = new System.Windows.Forms.Label();
            this.LApellido = new System.Windows.Forms.Label();
            this.TBDni = new System.Windows.Forms.TextBox();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.TBApellido = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LSexo = new System.Windows.Forms.Label();
            this.RBMasculino = new System.Windows.Forms.RadioButton();
            this.LEstado = new System.Windows.Forms.Label();
            this.CMBEstadoPaciente = new System.Windows.Forms.ComboBox();
            this.LInfoPaciente = new System.Windows.Forms.Label();
            this.RBFemenino = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TBTratamiento = new System.Windows.Forms.TextBox();
            this.TBObservacion = new System.Windows.Forms.TextBox();
            this.TBDiagnostico = new System.Windows.Forms.TextBox();
            this.LObservaciones = new System.Windows.Forms.Label();
            this.LTratamiento = new System.Windows.Forms.Label();
            this.LDiagnosticoInicial = new System.Windows.Forms.Label();
            this.LFechaConsulta = new System.Windows.Forms.Label();
            this.DTMHistorialInicial = new System.Windows.Forms.DateTimePicker();
            this.LHistorialInicial = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelRegistroPaciente
            // 
            this.LabelRegistroPaciente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelRegistroPaciente.AutoSize = true;
            this.LabelRegistroPaciente.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRegistroPaciente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.LabelRegistroPaciente.Location = new System.Drawing.Point(359, 12);
            this.LabelRegistroPaciente.Name = "LabelRegistroPaciente";
            this.LabelRegistroPaciente.Size = new System.Drawing.Size(265, 27);
            this.LabelRegistroPaciente.TabIndex = 1;
            this.LabelRegistroPaciente.Text = "Registro de Nuevo Paciente";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.LPaciente);
            this.panel1.Controls.Add(this.LTexto);
            this.panel1.Controls.Add(this.LabelRegistroPaciente);
            this.panel1.Location = new System.Drawing.Point(12, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 77);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // LPaciente
            // 
            this.LPaciente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LPaciente.AutoSize = true;
            this.LPaciente.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPaciente.Location = new System.Drawing.Point(244, 47);
            this.LPaciente.Name = "LPaciente";
            this.LPaciente.Size = new System.Drawing.Size(552, 23);
            this.LPaciente.TabIndex = 3;
            this.LPaciente.Text = "Complete la información del paciente para crear su expediente médico";
            // 
            // LTexto
            // 
            this.LTexto.AutoSize = true;
            this.LTexto.Location = new System.Drawing.Point(51, 47);
            this.LTexto.Name = "LTexto";
            this.LTexto.Size = new System.Drawing.Size(0, 13);
            this.LTexto.TabIndex = 2;
            // 
            // TBEmail
            // 
            this.TBEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TBEmail.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBEmail.Location = new System.Drawing.Point(587, 90);
            this.TBEmail.Name = "TBEmail";
            this.TBEmail.Size = new System.Drawing.Size(204, 26);
            this.TBEmail.TabIndex = 6;
            this.TBEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBEmail_KeyPress);
            // 
            // TBDireccion
            // 
            this.TBDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TBDireccion.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDireccion.Location = new System.Drawing.Point(510, 131);
            this.TBDireccion.Name = "TBDireccion";
            this.TBDireccion.Size = new System.Drawing.Size(281, 26);
            this.TBDireccion.TabIndex = 5;
            // 
            // TBTelefono
            // 
            this.TBTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TBTelefono.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBTelefono.Location = new System.Drawing.Point(587, 48);
            this.TBTelefono.Name = "TBTelefono";
            this.TBTelefono.Size = new System.Drawing.Size(204, 26);
            this.TBTelefono.TabIndex = 4;
            this.TBTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBTelefono_KeyPress);
            // 
            // LDireccion
            // 
            this.LDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LDireccion.AutoSize = true;
            this.LDireccion.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDireccion.Location = new System.Drawing.Point(396, 134);
            this.LDireccion.Name = "LDireccion";
            this.LDireccion.Size = new System.Drawing.Size(85, 23);
            this.LDireccion.TabIndex = 3;
            this.LDireccion.Text = "Direccion:";
            // 
            // LCorreo
            // 
            this.LCorreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LCorreo.AutoSize = true;
            this.LCorreo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCorreo.Location = new System.Drawing.Point(397, 93);
            this.LCorreo.Name = "LCorreo";
            this.LCorreo.Size = new System.Drawing.Size(153, 23);
            this.LCorreo.TabIndex = 2;
            this.LCorreo.Text = "Correo Electronico:";
            // 
            // LTelefono
            // 
            this.LTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LTelefono.AutoSize = true;
            this.LTelefono.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTelefono.Location = new System.Drawing.Point(397, 51);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LTelefono.Size = new System.Drawing.Size(173, 23);
            this.LTelefono.TabIndex = 1;
            this.LTelefono.Text = "Telefono De Contacto:";
            // 
            // BRegistrar
            // 
            this.BRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BRegistrar.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BRegistrar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BRegistrar.Location = new System.Drawing.Point(744, 202);
            this.BRegistrar.Name = "BRegistrar";
            this.BRegistrar.Size = new System.Drawing.Size(101, 43);
            this.BRegistrar.TabIndex = 6;
            this.BRegistrar.Text = "Registrar";
            this.BRegistrar.UseVisualStyleBackColor = false;
            this.BRegistrar.Click += new System.EventHandler(this.BRegistrar_Click);
            // 
            // BEliminar
            // 
            this.BEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BEliminar.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEliminar.Location = new System.Drawing.Point(866, 202);
            this.BEliminar.Name = "BEliminar";
            this.BEliminar.Size = new System.Drawing.Size(91, 43);
            this.BEliminar.TabIndex = 7;
            this.BEliminar.Text = "Cancelar";
            this.BEliminar.UseVisualStyleBackColor = false;
            this.BEliminar.Click += new System.EventHandler(this.BEliminar_Click);
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(26, 48);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(92, 23);
            this.LNombre.TabIndex = 2;
            this.LNombre.Text = "Nombre(s):";
            // 
            // LDni
            // 
            this.LDni.AutoSize = true;
            this.LDni.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDni.Location = new System.Drawing.Point(38, 130);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(49, 23);
            this.LDni.TabIndex = 3;
            this.LDni.Text = "DNI:";
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LApellido.Location = new System.Drawing.Point(23, 93);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(95, 23);
            this.LApellido.TabIndex = 4;
            this.LApellido.Text = "Apellido(s):";
            // 
            // TBDni
            // 
            this.TBDni.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDni.Location = new System.Drawing.Point(165, 131);
            this.TBDni.Name = "TBDni";
            this.TBDni.Size = new System.Drawing.Size(204, 26);
            this.TBDni.TabIndex = 5;
            this.TBDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBDni_KeyPress);
            // 
            // TBNombre
            // 
            this.TBNombre.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNombre.Location = new System.Drawing.Point(165, 48);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(204, 26);
            this.TBNombre.TabIndex = 6;
            this.TBNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNombre_KeyPress);
            // 
            // TBApellido
            // 
            this.TBApellido.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBApellido.Location = new System.Drawing.Point(165, 90);
            this.TBApellido.Name = "TBApellido";
            this.TBApellido.Size = new System.Drawing.Size(204, 26);
            this.TBApellido.TabIndex = 7;
            this.TBApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBApellido_KeyPress);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.LSexo);
            this.panel2.Controls.Add(this.RBMasculino);
            this.panel2.Controls.Add(this.LEstado);
            this.panel2.Controls.Add(this.CMBEstadoPaciente);
            this.panel2.Controls.Add(this.TBDireccion);
            this.panel2.Controls.Add(this.LInfoPaciente);
            this.panel2.Controls.Add(this.LDireccion);
            this.panel2.Controls.Add(this.TBApellido);
            this.panel2.Controls.Add(this.TBNombre);
            this.panel2.Controls.Add(this.TBDni);
            this.panel2.Controls.Add(this.TBEmail);
            this.panel2.Controls.Add(this.LApellido);
            this.panel2.Controls.Add(this.LDni);
            this.panel2.Controls.Add(this.TBTelefono);
            this.panel2.Controls.Add(this.LNombre);
            this.panel2.Controls.Add(this.LTelefono);
            this.panel2.Controls.Add(this.LCorreo);
            this.panel2.Controls.Add(this.RBFemenino);
            this.panel2.Location = new System.Drawing.Point(12, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 199);
            this.panel2.TabIndex = 4;
            // 
            // LSexo
            // 
            this.LSexo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LSexo.AutoSize = true;
            this.LSexo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSexo.Location = new System.Drawing.Point(406, 170);
            this.LSexo.Name = "LSexo";
            this.LSexo.Size = new System.Drawing.Size(51, 23);
            this.LSexo.TabIndex = 13;
            this.LSexo.Text = "Sexo:";
            // 
            // RBMasculino
            // 
            this.RBMasculino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RBMasculino.AutoSize = true;
            this.RBMasculino.Location = new System.Drawing.Point(520, 170);
            this.RBMasculino.Name = "RBMasculino";
            this.RBMasculino.Size = new System.Drawing.Size(73, 17);
            this.RBMasculino.TabIndex = 11;
            this.RBMasculino.TabStop = true;
            this.RBMasculino.Text = "Masculino";
            this.RBMasculino.UseVisualStyleBackColor = true;
            // 
            // LEstado
            // 
            this.LEstado.AutoSize = true;
            this.LEstado.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEstado.Location = new System.Drawing.Point(23, 166);
            this.LEstado.Name = "LEstado";
            this.LEstado.Size = new System.Drawing.Size(64, 23);
            this.LEstado.TabIndex = 10;
            this.LEstado.Text = "Estado:";
            // 
            // CMBEstadoPaciente
            // 
            this.CMBEstadoPaciente.FormattingEnabled = true;
            this.CMBEstadoPaciente.Location = new System.Drawing.Point(159, 170);
            this.CMBEstadoPaciente.Name = "CMBEstadoPaciente";
            this.CMBEstadoPaciente.Size = new System.Drawing.Size(121, 21);
            this.CMBEstadoPaciente.TabIndex = 9;
            // 
            // LInfoPaciente
            // 
            this.LInfoPaciente.AutoSize = true;
            this.LInfoPaciente.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LInfoPaciente.Location = new System.Drawing.Point(359, 10);
            this.LInfoPaciente.Name = "LInfoPaciente";
            this.LInfoPaciente.Size = new System.Drawing.Size(199, 26);
            this.LInfoPaciente.TabIndex = 8;
            this.LInfoPaciente.Text = "Informaciòn Personal";
            this.LInfoPaciente.Click += new System.EventHandler(this.LInfoPaciente_Click);
            // 
            // RBFemenino
            // 
            this.RBFemenino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RBFemenino.AutoSize = true;
            this.RBFemenino.Location = new System.Drawing.Point(607, 170);
            this.RBFemenino.Name = "RBFemenino";
            this.RBFemenino.Size = new System.Drawing.Size(71, 17);
            this.RBFemenino.TabIndex = 12;
            this.RBFemenino.TabStop = true;
            this.RBFemenino.Text = "Femenino";
            this.RBFemenino.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.TBTratamiento);
            this.panel3.Controls.Add(this.BRegistrar);
            this.panel3.Controls.Add(this.BEliminar);
            this.panel3.Controls.Add(this.TBObservacion);
            this.panel3.Controls.Add(this.TBDiagnostico);
            this.panel3.Controls.Add(this.LObservaciones);
            this.panel3.Controls.Add(this.LTratamiento);
            this.panel3.Controls.Add(this.LDiagnosticoInicial);
            this.panel3.Controls.Add(this.LFechaConsulta);
            this.panel3.Controls.Add(this.DTMHistorialInicial);
            this.panel3.Controls.Add(this.LHistorialInicial);
            this.panel3.Location = new System.Drawing.Point(12, 294);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(960, 255);
            this.panel3.TabIndex = 9;
            // 
            // TBTratamiento
            // 
            this.TBTratamiento.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBTratamiento.Location = new System.Drawing.Point(464, 70);
            this.TBTratamiento.Multiline = true;
            this.TBTratamiento.Name = "TBTratamiento";
            this.TBTratamiento.Size = new System.Drawing.Size(192, 112);
            this.TBTratamiento.TabIndex = 8;
            // 
            // TBObservacion
            // 
            this.TBObservacion.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBObservacion.Location = new System.Drawing.Point(727, 71);
            this.TBObservacion.Multiline = true;
            this.TBObservacion.Name = "TBObservacion";
            this.TBObservacion.Size = new System.Drawing.Size(170, 112);
            this.TBObservacion.TabIndex = 7;
            // 
            // TBDiagnostico
            // 
            this.TBDiagnostico.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDiagnostico.Location = new System.Drawing.Point(191, 71);
            this.TBDiagnostico.Multiline = true;
            this.TBDiagnostico.Name = "TBDiagnostico";
            this.TBDiagnostico.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TBDiagnostico.Size = new System.Drawing.Size(211, 112);
            this.TBDiagnostico.TabIndex = 6;
            // 
            // LObservaciones
            // 
            this.LObservaciones.AutoSize = true;
            this.LObservaciones.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LObservaciones.Location = new System.Drawing.Point(754, 44);
            this.LObservaciones.Name = "LObservaciones";
            this.LObservaciones.Size = new System.Drawing.Size(121, 23);
            this.LObservaciones.TabIndex = 5;
            this.LObservaciones.Text = "Observaciones:";
            // 
            // LTratamiento
            // 
            this.LTratamiento.AutoSize = true;
            this.LTratamiento.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTratamiento.Location = new System.Drawing.Point(506, 44);
            this.LTratamiento.Name = "LTratamiento";
            this.LTratamiento.Size = new System.Drawing.Size(104, 23);
            this.LTratamiento.TabIndex = 4;
            this.LTratamiento.Text = "Tratamiento:";
            // 
            // LDiagnosticoInicial
            // 
            this.LDiagnosticoInicial.AutoSize = true;
            this.LDiagnosticoInicial.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDiagnosticoInicial.Location = new System.Drawing.Point(217, 44);
            this.LDiagnosticoInicial.Name = "LDiagnosticoInicial";
            this.LDiagnosticoInicial.Size = new System.Drawing.Size(152, 23);
            this.LDiagnosticoInicial.TabIndex = 3;
            this.LDiagnosticoInicial.Text = "Diagnostico Inicial:";
            // 
            // LFechaConsulta
            // 
            this.LFechaConsulta.AutoSize = true;
            this.LFechaConsulta.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaConsulta.Location = new System.Drawing.Point(16, 44);
            this.LFechaConsulta.Name = "LFechaConsulta";
            this.LFechaConsulta.Size = new System.Drawing.Size(123, 23);
            this.LFechaConsulta.TabIndex = 2;
            this.LFechaConsulta.Text = "Fecha Consulta:";
            // 
            // DTMHistorialInicial
            // 
            this.DTMHistorialInicial.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTMHistorialInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTMHistorialInicial.Location = new System.Drawing.Point(20, 83);
            this.DTMHistorialInicial.Name = "DTMHistorialInicial";
            this.DTMHistorialInicial.Size = new System.Drawing.Size(136, 30);
            this.DTMHistorialInicial.TabIndex = 1;
            // 
            // LHistorialInicial
            // 
            this.LHistorialInicial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LHistorialInicial.AutoSize = true;
            this.LHistorialInicial.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LHistorialInicial.Location = new System.Drawing.Point(359, 9);
            this.LHistorialInicial.Name = "LHistorialInicial";
            this.LHistorialInicial.Size = new System.Drawing.Size(145, 26);
            this.LHistorialInicial.TabIndex = 0;
            this.LHistorialInicial.Text = "Historial Inicial";
            // 
            // FormPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 551);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormPaciente";
            this.Text = "FormPaciente";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LabelRegistroPaciente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LPaciente;
        private System.Windows.Forms.Label LTexto;
        private System.Windows.Forms.Button BRegistrar;
        private System.Windows.Forms.Button BEliminar;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Label LDni;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.TextBox TBDni;
        private System.Windows.Forms.TextBox TBNombre;
        private System.Windows.Forms.TextBox TBApellido;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LInfoPaciente;
        private System.Windows.Forms.Label LCorreo;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.TextBox TBTelefono;
        private System.Windows.Forms.Label LDireccion;
        private System.Windows.Forms.TextBox TBEmail;
        private System.Windows.Forms.TextBox TBDireccion;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LHistorialInicial;
        private System.Windows.Forms.Label LFechaConsulta;
        private System.Windows.Forms.DateTimePicker DTMHistorialInicial;
        private System.Windows.Forms.Label LObservaciones;
        private System.Windows.Forms.Label LTratamiento;
        private System.Windows.Forms.Label LDiagnosticoInicial;
        private System.Windows.Forms.TextBox TBDiagnostico;
        private System.Windows.Forms.TextBox TBTratamiento;
        private System.Windows.Forms.TextBox TBObservacion;
        private System.Windows.Forms.Label LEstado;
        private System.Windows.Forms.ComboBox CMBEstadoPaciente;
        private System.Windows.Forms.Label LSexo;
        private System.Windows.Forms.RadioButton RBFemenino;
        private System.Windows.Forms.RadioButton RBMasculino;
    }
}