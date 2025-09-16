namespace SaludSoft
{
    partial class FormModificarPaciente
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
            this.LTexto = new System.Windows.Forms.Label();
            this.LabelEditarPaciente = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LInfoPaciente = new System.Windows.Forms.Label();
            this.TBApellido = new System.Windows.Forms.TextBox();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.TBDni = new System.Windows.Forms.TextBox();
            this.TBDireccion = new System.Windows.Forms.TextBox();
            this.TBEmail = new System.Windows.Forms.TextBox();
            this.LDireccion = new System.Windows.Forms.Label();
            this.LApellido = new System.Windows.Forms.Label();
            this.LDni = new System.Windows.Forms.Label();
            this.TBTelefono = new System.Windows.Forms.TextBox();
            this.LCorreo = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.LTelefono = new System.Windows.Forms.Label();
            this.BGuardar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.LSexo = new System.Windows.Forms.Label();
            this.RBMasculino = new System.Windows.Forms.RadioButton();
            this.RBFemenino = new System.Windows.Forms.RadioButton();
            this.BNuevoPaciente = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.BNuevoPaciente);
            this.panel1.Controls.Add(this.LTexto);
            this.panel1.Controls.Add(this.LabelEditarPaciente);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 57);
            this.panel1.TabIndex = 4;
            // 
            // LTexto
            // 
            this.LTexto.AutoSize = true;
            this.LTexto.Location = new System.Drawing.Point(51, 47);
            this.LTexto.Name = "LTexto";
            this.LTexto.Size = new System.Drawing.Size(0, 13);
            this.LTexto.TabIndex = 2;
            // 
            // LabelEditarPaciente
            // 
            this.LabelEditarPaciente.AutoSize = true;
            this.LabelEditarPaciente.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelEditarPaciente.Location = new System.Drawing.Point(434, 6);
            this.LabelEditarPaciente.Name = "LabelEditarPaciente";
            this.LabelEditarPaciente.Size = new System.Drawing.Size(156, 26);
            this.LabelEditarPaciente.TabIndex = 1;
            this.LabelEditarPaciente.Text = "Editar Paciente";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.RBFemenino);
            this.panel2.Controls.Add(this.RBMasculino);
            this.panel2.Controls.Add(this.LSexo);
            this.panel2.Controls.Add(this.LInfoPaciente);
            this.panel2.Controls.Add(this.TBApellido);
            this.panel2.Controls.Add(this.TBNombre);
            this.panel2.Controls.Add(this.TBDni);
            this.panel2.Controls.Add(this.TBDireccion);
            this.panel2.Controls.Add(this.TBEmail);
            this.panel2.Controls.Add(this.LDireccion);
            this.panel2.Controls.Add(this.LApellido);
            this.panel2.Controls.Add(this.LDni);
            this.panel2.Controls.Add(this.TBTelefono);
            this.panel2.Controls.Add(this.LCorreo);
            this.panel2.Controls.Add(this.LNombre);
            this.panel2.Controls.Add(this.LTelefono);
            this.panel2.Location = new System.Drawing.Point(27, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(941, 423);
            this.panel2.TabIndex = 5;
            // 
            // LInfoPaciente
            // 
            this.LInfoPaciente.AutoSize = true;
            this.LInfoPaciente.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LInfoPaciente.Location = new System.Drawing.Point(356, 17);
            this.LInfoPaciente.Name = "LInfoPaciente";
            this.LInfoPaciente.Size = new System.Drawing.Size(235, 25);
            this.LInfoPaciente.TabIndex = 8;
            this.LInfoPaciente.Text = "Informacion Personal";
            // 
            // TBApellido
            // 
            this.TBApellido.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBApellido.Location = new System.Drawing.Point(236, 112);
            this.TBApellido.Name = "TBApellido";
            this.TBApellido.Size = new System.Drawing.Size(174, 26);
            this.TBApellido.TabIndex = 7;
            // 
            // TBNombre
            // 
            this.TBNombre.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNombre.Location = new System.Drawing.Point(12, 112);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(163, 26);
            this.TBNombre.TabIndex = 6;
            // 
            // TBDni
            // 
            this.TBDni.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDni.Location = new System.Drawing.Point(465, 112);
            this.TBDni.Name = "TBDni";
            this.TBDni.Size = new System.Drawing.Size(182, 26);
            this.TBDni.TabIndex = 5;
            // 
            // TBDireccion
            // 
            this.TBDireccion.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDireccion.Location = new System.Drawing.Point(12, 291);
            this.TBDireccion.Name = "TBDireccion";
            this.TBDireccion.Size = new System.Drawing.Size(163, 26);
            this.TBDireccion.TabIndex = 5;
            // 
            // TBEmail
            // 
            this.TBEmail.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBEmail.Location = new System.Drawing.Point(256, 291);
            this.TBEmail.Name = "TBEmail";
            this.TBEmail.Size = new System.Drawing.Size(138, 26);
            this.TBEmail.TabIndex = 6;
            // 
            // LDireccion
            // 
            this.LDireccion.AutoSize = true;
            this.LDireccion.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDireccion.Location = new System.Drawing.Point(56, 245);
            this.LDireccion.Name = "LDireccion";
            this.LDireccion.Size = new System.Drawing.Size(85, 23);
            this.LDireccion.TabIndex = 3;
            this.LDireccion.Text = "Direccion:";
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LApellido.Location = new System.Drawing.Point(262, 77);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(95, 23);
            this.LApellido.TabIndex = 4;
            this.LApellido.Text = "Apellido(s):";
            // 
            // LDni
            // 
            this.LDni.AutoSize = true;
            this.LDni.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDni.Location = new System.Drawing.Point(526, 77);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(49, 23);
            this.LDni.TabIndex = 3;
            this.LDni.Text = "DNI:";
            // 
            // TBTelefono
            // 
            this.TBTelefono.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBTelefono.Location = new System.Drawing.Point(482, 289);
            this.TBTelefono.Name = "TBTelefono";
            this.TBTelefono.Size = new System.Drawing.Size(205, 26);
            this.TBTelefono.TabIndex = 4;
            // 
            // LCorreo
            // 
            this.LCorreo.AutoSize = true;
            this.LCorreo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCorreo.Location = new System.Drawing.Point(257, 245);
            this.LCorreo.Name = "LCorreo";
            this.LCorreo.Size = new System.Drawing.Size(153, 23);
            this.LCorreo.TabIndex = 2;
            this.LCorreo.Text = "Correo Electronico:";
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(35, 77);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(92, 23);
            this.LNombre.TabIndex = 2;
            this.LNombre.Text = "Nombre(s):";
            // 
            // LTelefono
            // 
            this.LTelefono.AutoSize = true;
            this.LTelefono.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTelefono.Location = new System.Drawing.Point(505, 243);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LTelefono.Size = new System.Drawing.Size(173, 23);
            this.LTelefono.TabIndex = 1;
            this.LTelefono.Text = "Telefono De Contacto:";
            // 
            // BGuardar
            // 
            this.BGuardar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardar.Location = new System.Drawing.Point(875, 495);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(93, 36);
            this.BGuardar.TabIndex = 7;
            this.BGuardar.Text = "Guardar";
            this.BGuardar.UseVisualStyleBackColor = true;
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelar.Location = new System.Drawing.Point(772, 495);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(93, 36);
            this.BCancelar.TabIndex = 8;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // LSexo
            // 
            this.LSexo.AutoSize = true;
            this.LSexo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LSexo.Location = new System.Drawing.Point(787, 77);
            this.LSexo.Name = "LSexo";
            this.LSexo.Size = new System.Drawing.Size(51, 23);
            this.LSexo.TabIndex = 14;
            this.LSexo.Text = "Sexo:";
            // 
            // RBMasculino
            // 
            this.RBMasculino.AutoSize = true;
            this.RBMasculino.Location = new System.Drawing.Point(726, 136);
            this.RBMasculino.Name = "RBMasculino";
            this.RBMasculino.Size = new System.Drawing.Size(73, 17);
            this.RBMasculino.TabIndex = 15;
            this.RBMasculino.TabStop = true;
            this.RBMasculino.Text = "Masculino";
            this.RBMasculino.UseVisualStyleBackColor = true;
            // 
            // RBFemenino
            // 
            this.RBFemenino.AutoSize = true;
            this.RBFemenino.Location = new System.Drawing.Point(834, 136);
            this.RBFemenino.Name = "RBFemenino";
            this.RBFemenino.Size = new System.Drawing.Size(71, 17);
            this.RBFemenino.TabIndex = 16;
            this.RBFemenino.TabStop = true;
            this.RBFemenino.Text = "Femenino";
            this.RBFemenino.UseVisualStyleBackColor = true;
            // 
            // BNuevoPaciente
            // 
            this.BNuevoPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(32)))));
            this.BNuevoPaciente.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevoPaciente.ForeColor = System.Drawing.Color.White;
            this.BNuevoPaciente.Location = new System.Drawing.Point(806, 9);
            this.BNuevoPaciente.Name = "BNuevoPaciente";
            this.BNuevoPaciente.Size = new System.Drawing.Size(150, 35);
            this.BNuevoPaciente.TabIndex = 6;
            this.BNuevoPaciente.Text = "+ Nuevo Paciente";
            this.BNuevoPaciente.UseVisualStyleBackColor = false;
            this.BNuevoPaciente.Click += new System.EventHandler(this.BNuevoPaciente_Click);
            // 
            // FormModificarPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 598);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BGuardar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormModificarPaciente";
            this.Text = "FormModificarPaciente";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LTexto;
        private System.Windows.Forms.Label LabelEditarPaciente;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LInfoPaciente;
        private System.Windows.Forms.TextBox TBApellido;
        private System.Windows.Forms.TextBox TBNombre;
        private System.Windows.Forms.TextBox TBDni;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.Label LDni;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.TextBox TBEmail;
        private System.Windows.Forms.TextBox TBDireccion;
        private System.Windows.Forms.TextBox TBTelefono;
        private System.Windows.Forms.Label LDireccion;
        private System.Windows.Forms.Label LCorreo;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Label LSexo;
        private System.Windows.Forms.RadioButton RBMasculino;
        private System.Windows.Forms.RadioButton RBFemenino;
        private System.Windows.Forms.Button BNuevoPaciente;
    }
}