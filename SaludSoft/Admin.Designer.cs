namespace SaludSoft
{
    partial class Admin
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lAdministrador = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btConsultoriosDisponibles = new System.Windows.Forms.Button();
            this.btEspecialidades = new System.Windows.Forms.Button();
            this.btCitasMes = new System.Windows.Forms.Button();
            this.btMedicosActivos = new System.Windows.Forms.Button();
            this.btTotalUsuario = new System.Windows.Forms.Button();
            this.btGestionUsuario = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btCerrarSesion = new System.Windows.Forms.Button();
            this.btBackup = new System.Windows.Forms.Button();
            this.btConsultorios = new System.Windows.Forms.Button();
            this.btTurnos = new System.Windows.Forms.Button();
            this.btInicio = new System.Windows.Forms.Button();
            this.btMedicos = new System.Windows.Forms.Button();
            this.btUsuario = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.btCerrarSesion);
            this.panel1.Controls.Add(this.btBackup);
            this.panel1.Controls.Add(this.btConsultorios);
            this.panel1.Controls.Add(this.btTurnos);
            this.panel1.Controls.Add(this.btInicio);
            this.panel1.Controls.Add(this.btMedicos);
            this.panel1.Controls.Add(this.btUsuario);
            this.panel1.Location = new System.Drawing.Point(3, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 698);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.btGestionUsuario);
            this.panel2.Controls.Add(this.lAdministrador);
            this.panel2.Location = new System.Drawing.Point(218, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 84);
            this.panel2.TabIndex = 2;
            // 
            // lAdministrador
            // 
            this.lAdministrador.AutoSize = true;
            this.lAdministrador.BackColor = System.Drawing.Color.Transparent;
            this.lAdministrador.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAdministrador.ForeColor = System.Drawing.Color.Green;
            this.lAdministrador.Location = new System.Drawing.Point(34, 25);
            this.lAdministrador.Name = "lAdministrador";
            this.lAdministrador.Size = new System.Drawing.Size(200, 34);
            this.lAdministrador.TabIndex = 3;
            this.lAdministrador.Text = "Administrador  ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Controls.Add(this.btConsultoriosDisponibles);
            this.panel3.Controls.Add(this.btEspecialidades);
            this.panel3.Controls.Add(this.btCitasMes);
            this.panel3.Controls.Add(this.btMedicosActivos);
            this.panel3.Controls.Add(this.btTotalUsuario);
            this.panel3.Location = new System.Drawing.Point(221, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(781, 608);
            this.panel3.TabIndex = 3;
            // 
            // btConsultoriosDisponibles
            // 
            this.btConsultoriosDisponibles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btConsultoriosDisponibles.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConsultoriosDisponibles.Image = global::SaludSoft.Properties.Resources.construccion_de_casas;
            this.btConsultoriosDisponibles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btConsultoriosDisponibles.Location = new System.Drawing.Point(173, 387);
            this.btConsultoriosDisponibles.Name = "btConsultoriosDisponibles";
            this.btConsultoriosDisponibles.Size = new System.Drawing.Size(388, 83);
            this.btConsultoriosDisponibles.TabIndex = 4;
            this.btConsultoriosDisponibles.Text = "Consultorios Disponibles ";
            this.btConsultoriosDisponibles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btConsultoriosDisponibles.UseVisualStyleBackColor = false;
            // 
            // btEspecialidades
            // 
            this.btEspecialidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btEspecialidades.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEspecialidades.Image = global::SaludSoft.Properties.Resources.libro_medico;
            this.btEspecialidades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEspecialidades.Location = new System.Drawing.Point(391, 209);
            this.btEspecialidades.Name = "btEspecialidades";
            this.btEspecialidades.Size = new System.Drawing.Size(266, 100);
            this.btEspecialidades.TabIndex = 3;
            this.btEspecialidades.Text = "Especialidades ";
            this.btEspecialidades.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEspecialidades.UseVisualStyleBackColor = false;
            // 
            // btCitasMes
            // 
            this.btCitasMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btCitasMes.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCitasMes.Image = global::SaludSoft.Properties.Resources.CitasProgramadas;
            this.btCitasMes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCitasMes.Location = new System.Drawing.Point(54, 209);
            this.btCitasMes.Name = "btCitasMes";
            this.btCitasMes.Size = new System.Drawing.Size(265, 96);
            this.btCitasMes.TabIndex = 2;
            this.btCitasMes.Text = "Citas del mes";
            this.btCitasMes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCitasMes.UseVisualStyleBackColor = false;
            // 
            // btMedicosActivos
            // 
            this.btMedicosActivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btMedicosActivos.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMedicosActivos.Image = global::SaludSoft.Properties.Resources.equipo_medico;
            this.btMedicosActivos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMedicosActivos.Location = new System.Drawing.Point(391, 64);
            this.btMedicosActivos.Name = "btMedicosActivos";
            this.btMedicosActivos.Size = new System.Drawing.Size(257, 93);
            this.btMedicosActivos.TabIndex = 1;
            this.btMedicosActivos.Text = "Médicos Activos ";
            this.btMedicosActivos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMedicosActivos.UseVisualStyleBackColor = false;
            // 
            // btTotalUsuario
            // 
            this.btTotalUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btTotalUsuario.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTotalUsuario.Image = global::SaludSoft.Properties.Resources.usuario;
            this.btTotalUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTotalUsuario.Location = new System.Drawing.Point(72, 64);
            this.btTotalUsuario.Name = "btTotalUsuario";
            this.btTotalUsuario.Size = new System.Drawing.Size(247, 93);
            this.btTotalUsuario.TabIndex = 0;
            this.btTotalUsuario.Text = "Total  Usuarios ";
            this.btTotalUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btTotalUsuario.UseVisualStyleBackColor = false;
            // 
            // btGestionUsuario
            // 
            this.btGestionUsuario.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGestionUsuario.Image = global::SaludSoft.Properties.Resources.agregar;
            this.btGestionUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGestionUsuario.Location = new System.Drawing.Point(461, 13);
            this.btGestionUsuario.Name = "btGestionUsuario";
            this.btGestionUsuario.Size = new System.Drawing.Size(290, 49);
            this.btGestionUsuario.TabIndex = 3;
            this.btGestionUsuario.Text = "Gestionar Usuario ";
            this.btGestionUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGestionUsuario.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SaludSoft.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(3, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btCerrarSesion
            // 
            this.btCerrarSesion.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCerrarSesion.Image = global::SaludSoft.Properties.Resources.circulo_marca_x;
            this.btCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCerrarSesion.Location = new System.Drawing.Point(15, 440);
            this.btCerrarSesion.Name = "btCerrarSesion";
            this.btCerrarSesion.Size = new System.Drawing.Size(182, 45);
            this.btCerrarSesion.TabIndex = 2;
            this.btCerrarSesion.Text = "Cerrar Sesión";
            this.btCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // btBackup
            // 
            this.btBackup.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBackup.Image = global::SaludSoft.Properties.Resources.monedas;
            this.btBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBackup.Location = new System.Drawing.Point(48, 347);
            this.btBackup.Name = "btBackup";
            this.btBackup.Size = new System.Drawing.Size(134, 56);
            this.btBackup.TabIndex = 2;
            this.btBackup.Text = "Backup ";
            this.btBackup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBackup.UseVisualStyleBackColor = true;
            // 
            // btConsultorios
            // 
            this.btConsultorios.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConsultorios.Image = global::SaludSoft.Properties.Resources.construccion_de_casas;
            this.btConsultorios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btConsultorios.Location = new System.Drawing.Point(15, 190);
            this.btConsultorios.Name = "btConsultorios";
            this.btConsultorios.Size = new System.Drawing.Size(167, 55);
            this.btConsultorios.TabIndex = 2;
            this.btConsultorios.Text = "Consultorios";
            this.btConsultorios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btConsultorios.UseVisualStyleBackColor = true;
            // 
            // btTurnos
            // 
            this.btTurnos.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTurnos.Image = global::SaludSoft.Properties.Resources.alt_de_inventario;
            this.btTurnos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTurnos.Location = new System.Drawing.Point(48, 259);
            this.btTurnos.Name = "btTurnos";
            this.btTurnos.Size = new System.Drawing.Size(115, 61);
            this.btTurnos.TabIndex = 5;
            this.btTurnos.Text = "Turnos ";
            this.btTurnos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btTurnos.UseVisualStyleBackColor = true;
            // 
            // btInicio
            // 
            this.btInicio.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInicio.Image = global::SaludSoft.Properties.Resources.hogar;
            this.btInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInicio.Location = new System.Drawing.Point(46, 15);
            this.btInicio.Name = "btInicio";
            this.btInicio.Size = new System.Drawing.Size(117, 42);
            this.btInicio.TabIndex = 2;
            this.btInicio.Text = "Inicio ";
            this.btInicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btInicio.UseVisualStyleBackColor = true;
            this.btInicio.Click += new System.EventHandler(this.button1_Click);
            // 
            // btMedicos
            // 
            this.btMedicos.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMedicos.Image = global::SaludSoft.Properties.Resources.equipo_medico;
            this.btMedicos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMedicos.Location = new System.Drawing.Point(37, 120);
            this.btMedicos.Name = "btMedicos";
            this.btMedicos.Size = new System.Drawing.Size(138, 52);
            this.btMedicos.TabIndex = 4;
            this.btMedicos.Text = "Médicos ";
            this.btMedicos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMedicos.UseVisualStyleBackColor = true;
            // 
            // btUsuario
            // 
            this.btUsuario.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUsuario.Image = global::SaludSoft.Properties.Resources.usuario;
            this.btUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btUsuario.Location = new System.Drawing.Point(35, 62);
            this.btUsuario.Name = "btUsuario";
            this.btUsuario.Size = new System.Drawing.Size(147, 52);
            this.btUsuario.TabIndex = 3;
            this.btUsuario.Text = "Usuarios ";
            this.btUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btUsuario.UseVisualStyleBackColor = true;
            this.btUsuario.Click += new System.EventHandler(this.button2_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 674);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Admin";
            this.Text = "Admin";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btTurnos;
        private System.Windows.Forms.Button btInicio;
        private System.Windows.Forms.Button btMedicos;
        private System.Windows.Forms.Button btUsuario;
        private System.Windows.Forms.Button btBackup;
        private System.Windows.Forms.Button btConsultorios;
        private System.Windows.Forms.Button btCerrarSesion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lAdministrador;
        private System.Windows.Forms.Button btGestionUsuario;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btTotalUsuario;
        private System.Windows.Forms.Button btMedicosActivos;
        private System.Windows.Forms.Button btCitasMes;
        private System.Windows.Forms.Button btEspecialidades;
        private System.Windows.Forms.Button btConsultoriosDisponibles;
    }
}