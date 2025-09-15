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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPaciente));
            this.PanelLogoPaciente = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LabelRegistroPaciente = new System.Windows.Forms.Label();
            this.PMenu = new System.Windows.Forms.Panel();
            this.BDoctores = new System.Windows.Forms.Button();
            this.BTurnos = new System.Windows.Forms.Button();
            this.BPacientes = new System.Windows.Forms.Button();
            this.BInicio = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LPaciente = new System.Windows.Forms.Label();
            this.LTexto = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TBNroCalle = new System.Windows.Forms.TextBox();
            this.LNroCalle = new System.Windows.Forms.Label();
            this.LCiudad = new System.Windows.Forms.Label();
            this.TBCiudad = new System.Windows.Forms.TextBox();
            this.TBEmail = new System.Windows.Forms.TextBox();
            this.TBDireccion = new System.Windows.Forms.TextBox();
            this.TBTelefono = new System.Windows.Forms.TextBox();
            this.LDireccion = new System.Windows.Forms.Label();
            this.LCorreo = new System.Windows.Forms.Label();
            this.LTelefono = new System.Windows.Forms.Label();
            this.LInfoContacto = new System.Windows.Forms.Label();
            this.BRegistrar = new System.Windows.Forms.Button();
            this.BEliminar = new System.Windows.Forms.Button();
            this.LNombre = new System.Windows.Forms.Label();
            this.LDni = new System.Windows.Forms.Label();
            this.LApellido = new System.Windows.Forms.Label();
            this.TBDni = new System.Windows.Forms.TextBox();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.TBApellido = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LInfoPaciente = new System.Windows.Forms.Label();
            this.BPruebaConexion = new System.Windows.Forms.Button();
            this.PanelLogoPaciente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelLogoPaciente
            // 
            this.PanelLogoPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(66)))));
            this.PanelLogoPaciente.Controls.Add(this.pictureBox1);
            this.PanelLogoPaciente.Location = new System.Drawing.Point(-5, -1);
            this.PanelLogoPaciente.Name = "PanelLogoPaciente";
            this.PanelLogoPaciente.Size = new System.Drawing.Size(154, 108);
            this.PanelLogoPaciente.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(17, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 75);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // LabelRegistroPaciente
            // 
            this.LabelRegistroPaciente.AutoSize = true;
            this.LabelRegistroPaciente.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRegistroPaciente.Location = new System.Drawing.Point(117, 11);
            this.LabelRegistroPaciente.Name = "LabelRegistroPaciente";
            this.LabelRegistroPaciente.Size = new System.Drawing.Size(277, 26);
            this.LabelRegistroPaciente.TabIndex = 1;
            this.LabelRegistroPaciente.Text = "Registro de Nuevo Paciente";
            // 
            // PMenu
            // 
            this.PMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(66)))));
            this.PMenu.Controls.Add(this.BDoctores);
            this.PMenu.Controls.Add(this.BTurnos);
            this.PMenu.Controls.Add(this.BPacientes);
            this.PMenu.Controls.Add(this.BInicio);
            this.PMenu.Location = new System.Drawing.Point(-5, 94);
            this.PMenu.Name = "PMenu";
            this.PMenu.Size = new System.Drawing.Size(154, 357);
            this.PMenu.TabIndex = 2;
            // 
            // BDoctores
            // 
            this.BDoctores.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BDoctores.Location = new System.Drawing.Point(21, 230);
            this.BDoctores.Name = "BDoctores";
            this.BDoctores.Size = new System.Drawing.Size(92, 46);
            this.BDoctores.TabIndex = 3;
            this.BDoctores.Text = "Doctores";
            this.BDoctores.UseVisualStyleBackColor = true;
            // 
            // BTurnos
            // 
            this.BTurnos.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTurnos.Location = new System.Drawing.Point(17, 164);
            this.BTurnos.Name = "BTurnos";
            this.BTurnos.Size = new System.Drawing.Size(108, 37);
            this.BTurnos.TabIndex = 4;
            this.BTurnos.Text = "Turnos";
            this.BTurnos.UseVisualStyleBackColor = true;
            // 
            // BPacientes
            // 
            this.BPacientes.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPacientes.Location = new System.Drawing.Point(15, 103);
            this.BPacientes.Name = "BPacientes";
            this.BPacientes.Size = new System.Drawing.Size(114, 40);
            this.BPacientes.TabIndex = 5;
            this.BPacientes.Text = "Pacientes";
            this.BPacientes.UseVisualStyleBackColor = true;
            this.BPacientes.Click += new System.EventHandler(this.BPacientes_Click);
            // 
            // BInicio
            // 
            this.BInicio.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BInicio.Location = new System.Drawing.Point(21, 19);
            this.BInicio.Name = "BInicio";
            this.BInicio.Size = new System.Drawing.Size(92, 43);
            this.BInicio.TabIndex = 2;
            this.BInicio.Text = "Inicio";
            this.BInicio.UseVisualStyleBackColor = true;
            this.BInicio.Click += new System.EventHandler(this.BInicio_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.LPaciente);
            this.panel1.Controls.Add(this.LTexto);
            this.panel1.Controls.Add(this.LabelRegistroPaciente);
            this.panel1.Location = new System.Drawing.Point(167, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(595, 77);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // LPaciente
            // 
            this.LPaciente.AutoSize = true;
            this.LPaciente.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPaciente.Location = new System.Drawing.Point(24, 47);
            this.LPaciente.Name = "LPaciente";
            this.LPaciente.Size = new System.Drawing.Size(496, 21);
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.TBNroCalle);
            this.panel3.Controls.Add(this.LNroCalle);
            this.panel3.Controls.Add(this.LCiudad);
            this.panel3.Controls.Add(this.TBCiudad);
            this.panel3.Controls.Add(this.TBEmail);
            this.panel3.Controls.Add(this.TBDireccion);
            this.panel3.Controls.Add(this.TBTelefono);
            this.panel3.Controls.Add(this.LDireccion);
            this.panel3.Controls.Add(this.LCorreo);
            this.panel3.Controls.Add(this.LTelefono);
            this.panel3.Controls.Add(this.LInfoContacto);
            this.panel3.Location = new System.Drawing.Point(167, 268);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(595, 141);
            this.panel3.TabIndex = 5;
            // 
            // TBNroCalle
            // 
            this.TBNroCalle.Location = new System.Drawing.Point(429, 111);
            this.TBNroCalle.Name = "TBNroCalle";
            this.TBNroCalle.Size = new System.Drawing.Size(100, 20);
            this.TBNroCalle.TabIndex = 10;
            this.TBNroCalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNroCalle_KeyPress);
            // 
            // LNroCalle
            // 
            this.LNroCalle.AutoSize = true;
            this.LNroCalle.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNroCalle.Location = new System.Drawing.Point(304, 111);
            this.LNroCalle.Name = "LNroCalle";
            this.LNroCalle.Size = new System.Drawing.Size(102, 18);
            this.LNroCalle.TabIndex = 9;
            this.LNroCalle.Text = "Numero Calle:";
            // 
            // LCiudad
            // 
            this.LCiudad.AutoSize = true;
            this.LCiudad.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCiudad.Location = new System.Drawing.Point(319, 54);
            this.LCiudad.Name = "LCiudad";
            this.LCiudad.Size = new System.Drawing.Size(60, 18);
            this.LCiudad.TabIndex = 8;
            this.LCiudad.Text = "Ciudad:";
            // 
            // TBCiudad
            // 
            this.TBCiudad.Location = new System.Drawing.Point(415, 54);
            this.TBCiudad.Name = "TBCiudad";
            this.TBCiudad.Size = new System.Drawing.Size(123, 20);
            this.TBCiudad.TabIndex = 7;
            this.TBCiudad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBCiudad_KeyPress);
            // 
            // TBEmail
            // 
            this.TBEmail.Location = new System.Drawing.Point(165, 93);
            this.TBEmail.Name = "TBEmail";
            this.TBEmail.Size = new System.Drawing.Size(126, 20);
            this.TBEmail.TabIndex = 6;
            this.TBEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBEmail_KeyPress);
            // 
            // TBDireccion
            // 
            this.TBDireccion.Location = new System.Drawing.Point(415, 82);
            this.TBDireccion.Name = "TBDireccion";
            this.TBDireccion.Size = new System.Drawing.Size(123, 20);
            this.TBDireccion.TabIndex = 5;
            // 
            // TBTelefono
            // 
            this.TBTelefono.Location = new System.Drawing.Point(165, 56);
            this.TBTelefono.Name = "TBTelefono";
            this.TBTelefono.Size = new System.Drawing.Size(126, 20);
            this.TBTelefono.TabIndex = 4;
            this.TBTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBTelefono_KeyPress);
            // 
            // LDireccion
            // 
            this.LDireccion.AutoSize = true;
            this.LDireccion.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDireccion.Location = new System.Drawing.Point(319, 84);
            this.LDireccion.Name = "LDireccion";
            this.LDireccion.Size = new System.Drawing.Size(75, 18);
            this.LDireccion.TabIndex = 3;
            this.LDireccion.Text = "Direccion:";
            // 
            // LCorreo
            // 
            this.LCorreo.AutoSize = true;
            this.LCorreo.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCorreo.Location = new System.Drawing.Point(3, 95);
            this.LCorreo.Name = "LCorreo";
            this.LCorreo.Size = new System.Drawing.Size(135, 18);
            this.LCorreo.TabIndex = 2;
            this.LCorreo.Text = "Correo Electronico:";
            // 
            // LTelefono
            // 
            this.LTelefono.AutoSize = true;
            this.LTelefono.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTelefono.Location = new System.Drawing.Point(3, 56);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LTelefono.Size = new System.Drawing.Size(153, 18);
            this.LTelefono.TabIndex = 1;
            this.LTelefono.Text = "Telefono De Contacto:";
            // 
            // LInfoContacto
            // 
            this.LInfoContacto.AutoSize = true;
            this.LInfoContacto.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LInfoContacto.Location = new System.Drawing.Point(159, 14);
            this.LInfoContacto.Name = "LInfoContacto";
            this.LInfoContacto.Size = new System.Drawing.Size(275, 25);
            this.LInfoContacto.TabIndex = 0;
            this.LInfoContacto.Text = "Informacion De Contacto";
            // 
            // BRegistrar
            // 
            this.BRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(66)))));
            this.BRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BRegistrar.ForeColor = System.Drawing.SystemColors.Control;
            this.BRegistrar.Location = new System.Drawing.Point(713, 415);
            this.BRegistrar.Name = "BRegistrar";
            this.BRegistrar.Size = new System.Drawing.Size(87, 36);
            this.BRegistrar.TabIndex = 6;
            this.BRegistrar.Text = "Registrar";
            this.BRegistrar.UseVisualStyleBackColor = false;
            this.BRegistrar.Click += new System.EventHandler(this.BRegistrar_Click);
            // 
            // BEliminar
            // 
            this.BEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEliminar.Location = new System.Drawing.Point(596, 415);
            this.BEliminar.Name = "BEliminar";
            this.BEliminar.Size = new System.Drawing.Size(91, 36);
            this.BEliminar.TabIndex = 7;
            this.BEliminar.Text = "Cancelar";
            this.BEliminar.UseVisualStyleBackColor = true;
            this.BEliminar.Click += new System.EventHandler(this.BEliminar_Click);
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(8, 65);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(83, 18);
            this.LNombre.TabIndex = 2;
            this.LNombre.Text = "Nombre(s):";
            // 
            // LDni
            // 
            this.LDni.AutoSize = true;
            this.LDni.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDni.Location = new System.Drawing.Point(287, 65);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(39, 18);
            this.LDni.TabIndex = 3;
            this.LDni.Text = "DNI:";
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LApellido.Location = new System.Drawing.Point(8, 103);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(84, 18);
            this.LApellido.TabIndex = 4;
            this.LApellido.Text = "Apellido(s):";
            // 
            // TBDni
            // 
            this.TBDni.Location = new System.Drawing.Point(341, 63);
            this.TBDni.Name = "TBDni";
            this.TBDni.Size = new System.Drawing.Size(140, 20);
            this.TBDni.TabIndex = 5;
            this.TBDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBDni_KeyPress);
            // 
            // TBNombre
            // 
            this.TBNombre.Location = new System.Drawing.Point(97, 65);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(132, 20);
            this.TBNombre.TabIndex = 6;
            this.TBNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNombre_KeyPress);
            // 
            // TBApellido
            // 
            this.TBApellido.Location = new System.Drawing.Point(98, 103);
            this.TBApellido.Name = "TBApellido";
            this.TBApellido.Size = new System.Drawing.Size(138, 20);
            this.TBApellido.TabIndex = 7;
            this.TBApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBApellido_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.LInfoPaciente);
            this.panel2.Controls.Add(this.TBApellido);
            this.panel2.Controls.Add(this.TBNombre);
            this.panel2.Controls.Add(this.TBDni);
            this.panel2.Controls.Add(this.LApellido);
            this.panel2.Controls.Add(this.LDni);
            this.panel2.Controls.Add(this.LNombre);
            this.panel2.Location = new System.Drawing.Point(184, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(567, 145);
            this.panel2.TabIndex = 4;
            // 
            // LInfoPaciente
            // 
            this.LInfoPaciente.AutoSize = true;
            this.LInfoPaciente.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LInfoPaciente.Location = new System.Drawing.Point(162, 15);
            this.LInfoPaciente.Name = "LInfoPaciente";
            this.LInfoPaciente.Size = new System.Drawing.Size(235, 25);
            this.LInfoPaciente.TabIndex = 8;
            this.LInfoPaciente.Text = "Informacion Personal";
            // 
            // BPruebaConexion
            // 
            this.BPruebaConexion.Location = new System.Drawing.Point(155, 423);
            this.BPruebaConexion.Name = "BPruebaConexion";
            this.BPruebaConexion.Size = new System.Drawing.Size(204, 23);
            this.BPruebaConexion.TabIndex = 8;
            this.BPruebaConexion.Text = "Prueba Conexion";
            this.BPruebaConexion.UseVisualStyleBackColor = true;
            this.BPruebaConexion.Click += new System.EventHandler(this.BPruebaConexion_Click);
            // 
            // FormPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BPruebaConexion);
            this.Controls.Add(this.BEliminar);
            this.Controls.Add(this.BRegistrar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PMenu);
            this.Controls.Add(this.PanelLogoPaciente);
            this.Name = "FormPaciente";
            this.Text = "FormPaciente";
            this.Load += new System.EventHandler(this.FormPaciente_Load);
            this.PanelLogoPaciente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelLogoPaciente;
        private System.Windows.Forms.Label LabelRegistroPaciente;
        private System.Windows.Forms.Panel PMenu;
        private System.Windows.Forms.Button BDoctores;
        private System.Windows.Forms.Button BTurnos;
        private System.Windows.Forms.Button BPacientes;
        private System.Windows.Forms.Button BInicio;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LPaciente;
        private System.Windows.Forms.Label LTexto;
        private System.Windows.Forms.Panel panel3;
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
        private System.Windows.Forms.Label LInfoContacto;
        private System.Windows.Forms.TextBox TBTelefono;
        private System.Windows.Forms.Label LDireccion;
        private System.Windows.Forms.TextBox TBEmail;
        private System.Windows.Forms.TextBox TBDireccion;
        private System.Windows.Forms.Label LCiudad;
        private System.Windows.Forms.TextBox TBCiudad;
        private System.Windows.Forms.Button BPruebaConexion;
        private System.Windows.Forms.TextBox TBNroCalle;
        private System.Windows.Forms.Label LNroCalle;
    }
}