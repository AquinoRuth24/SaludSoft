namespace SaludSoft
{
    partial class SaludSoft
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaludSoft));
            this.PMenu = new System.Windows.Forms.Panel();
            this.BAgenda = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BCerrarSesion = new System.Windows.Forms.Button();
            this.BTurnos = new System.Windows.Forms.Button();
            this.BPacientes = new System.Windows.Forms.Button();
            this.BInicio = new System.Windows.Forms.Button();
            this.PSuperior = new System.Windows.Forms.Panel();
            this.BNuevoPaciente = new System.Windows.Forms.Button();
            this.LRecepcionista = new System.Windows.Forms.Label();
            this.Label = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BNuevaCita = new System.Windows.Forms.Button();
            this.PPacientes = new System.Windows.Forms.Panel();
            this.PPacientesHoy = new System.Windows.Forms.PictureBox();
            this.LPacientesHoy = new System.Windows.Forms.Label();
            this.PCitas = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.LTurnosProgramados = new System.Windows.Forms.Label();
            this.PDoctores = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.LDoctores = new System.Windows.Forms.Label();
            this.PEspecialidades = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.PMenu.SuspendLayout();
            this.panel4.SuspendLayout();
            this.PSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PPacientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PPacientesHoy)).BeginInit();
            this.PCitas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.PDoctores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.PEspecialidades.SuspendLayout();
            this.SuspendLayout();
            // 
            // PMenu
            // 
            this.PMenu.BackColor = System.Drawing.Color.DarkGreen;
            this.PMenu.Controls.Add(this.BAgenda);
            this.PMenu.Controls.Add(this.panel4);
            this.PMenu.Controls.Add(this.BTurnos);
            this.PMenu.Controls.Add(this.BPacientes);
            this.PMenu.Controls.Add(this.BInicio);
            this.PMenu.Location = new System.Drawing.Point(2, 65);
            this.PMenu.Name = "PMenu";
            this.PMenu.Size = new System.Drawing.Size(120, 463);
            this.PMenu.TabIndex = 0;
            // 
            // BAgenda
            // 
            this.BAgenda.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgenda.Location = new System.Drawing.Point(10, 253);
            this.BAgenda.Name = "BAgenda";
            this.BAgenda.Size = new System.Drawing.Size(98, 35);
            this.BAgenda.TabIndex = 8;
            this.BAgenda.Text = "Agenda";
            this.BAgenda.UseVisualStyleBackColor = true;
            this.BAgenda.Click += new System.EventHandler(this.BAgenda_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BCerrarSesion);
            this.panel4.Location = new System.Drawing.Point(3, 339);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(117, 124);
            this.panel4.TabIndex = 11;
            // 
            // BCerrarSesion
            // 
            this.BCerrarSesion.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCerrarSesion.Location = new System.Drawing.Point(3, 45);
            this.BCerrarSesion.Name = "BCerrarSesion";
            this.BCerrarSesion.Size = new System.Drawing.Size(108, 53);
            this.BCerrarSesion.TabIndex = 6;
            this.BCerrarSesion.Text = "Cerrar sesion";
            this.BCerrarSesion.UseVisualStyleBackColor = true;
            this.BCerrarSesion.Click += new System.EventHandler(this.BCerrarSesion_Click);
            // 
            // BTurnos
            // 
            this.BTurnos.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTurnos.Location = new System.Drawing.Point(10, 179);
            this.BTurnos.Name = "BTurnos";
            this.BTurnos.Size = new System.Drawing.Size(92, 36);
            this.BTurnos.TabIndex = 4;
            this.BTurnos.Text = "Turnos";
            this.BTurnos.UseVisualStyleBackColor = true;
            // 
            // BPacientes
            // 
            this.BPacientes.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPacientes.Location = new System.Drawing.Point(6, 115);
            this.BPacientes.Name = "BPacientes";
            this.BPacientes.Size = new System.Drawing.Size(102, 40);
            this.BPacientes.TabIndex = 5;
            this.BPacientes.Text = "Pacientes";
            this.BPacientes.UseVisualStyleBackColor = true;
            this.BPacientes.Click += new System.EventHandler(this.BPacientes_Click);
            // 
            // BInicio
            // 
            this.BInicio.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BInicio.Location = new System.Drawing.Point(10, 50);
            this.BInicio.Name = "BInicio";
            this.BInicio.Size = new System.Drawing.Size(92, 43);
            this.BInicio.TabIndex = 2;
            this.BInicio.Text = "Inicio";
            this.BInicio.UseVisualStyleBackColor = true;
            this.BInicio.Click += new System.EventHandler(this.BInicio_Click);
            // 
            // PSuperior
            // 
            this.PSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.PSuperior.Controls.Add(this.BNuevoPaciente);
            this.PSuperior.Controls.Add(this.LRecepcionista);
            this.PSuperior.Controls.Add(this.Label);
            this.PSuperior.Controls.Add(this.LNombre);
            this.PSuperior.Controls.Add(this.pictureBox1);
            this.PSuperior.Controls.Add(this.BNuevaCita);
            this.PSuperior.Location = new System.Drawing.Point(2, 1);
            this.PSuperior.Name = "PSuperior";
            this.PSuperior.Size = new System.Drawing.Size(931, 75);
            this.PSuperior.TabIndex = 1;
            // 
            // BNuevoPaciente
            // 
            this.BNuevoPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(32)))));
            this.BNuevoPaciente.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevoPaciente.ForeColor = System.Drawing.Color.White;
            this.BNuevoPaciente.Location = new System.Drawing.Point(819, 11);
            this.BNuevoPaciente.Name = "BNuevoPaciente";
            this.BNuevoPaciente.Size = new System.Drawing.Size(102, 54);
            this.BNuevoPaciente.TabIndex = 5;
            this.BNuevoPaciente.Text = "+ Nuevo     Paciente";
            this.BNuevoPaciente.UseVisualStyleBackColor = false;
            this.BNuevoPaciente.Click += new System.EventHandler(this.BNuevoPaciente_Click);
            // 
            // LRecepcionista
            // 
            this.LRecepcionista.AutoSize = true;
            this.LRecepcionista.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LRecepcionista.Location = new System.Drawing.Point(108, 8);
            this.LRecepcionista.Name = "LRecepcionista";
            this.LRecepcionista.Size = new System.Drawing.Size(209, 38);
            this.LRecepcionista.TabIndex = 4;
            this.LRecepcionista.Text = "Recepcionista";
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label.Location = new System.Drawing.Point(424, 46);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(192, 19);
            this.Label.TabIndex = 2;
            this.Label.Text = "Sistema de Gestión Médica";
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(465, 8);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(110, 29);
            this.LNombre.TabIndex = 3;
            this.LNombre.Text = "SaludSoft";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 75);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // BNuevaCita
            // 
            this.BNuevaCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(32)))));
            this.BNuevaCita.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevaCita.ForeColor = System.Drawing.Color.White;
            this.BNuevaCita.Location = new System.Drawing.Point(697, 11);
            this.BNuevaCita.Name = "BNuevaCita";
            this.BNuevaCita.Size = new System.Drawing.Size(108, 54);
            this.BNuevaCita.TabIndex = 0;
            this.BNuevaCita.Text = "+ Nuevo     Turno";
            this.BNuevaCita.UseVisualStyleBackColor = false;
            this.BNuevaCita.Click += new System.EventHandler(this.BNuevaCita_Click);
            // 
            // PPacientes
            // 
            this.PPacientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(249)))), ((int)(((byte)(240)))));
            this.PPacientes.Controls.Add(this.PPacientesHoy);
            this.PPacientes.Controls.Add(this.LPacientesHoy);
            this.PPacientes.Location = new System.Drawing.Point(171, 93);
            this.PPacientes.Name = "PPacientes";
            this.PPacientes.Size = new System.Drawing.Size(263, 100);
            this.PPacientes.TabIndex = 2;
            // 
            // PPacientesHoy
            // 
            this.PPacientesHoy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PPacientesHoy.BackgroundImage")));
            this.PPacientesHoy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PPacientesHoy.Location = new System.Drawing.Point(184, 0);
            this.PPacientesHoy.Name = "PPacientesHoy";
            this.PPacientesHoy.Size = new System.Drawing.Size(76, 37);
            this.PPacientesHoy.TabIndex = 8;
            this.PPacientesHoy.TabStop = false;
            // 
            // LPacientesHoy
            // 
            this.LPacientesHoy.AutoSize = true;
            this.LPacientesHoy.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPacientesHoy.Location = new System.Drawing.Point(3, 6);
            this.LPacientesHoy.Name = "LPacientesHoy";
            this.LPacientesHoy.Size = new System.Drawing.Size(115, 19);
            this.LPacientesHoy.TabIndex = 0;
            this.LPacientesHoy.Text = "Pacientes Hoy";
            // 
            // PCitas
            // 
            this.PCitas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(235)))));
            this.PCitas.Controls.Add(this.pictureBox3);
            this.PCitas.Controls.Add(this.LTurnosProgramados);
            this.PCitas.Location = new System.Drawing.Point(634, 93);
            this.PCitas.Name = "PCitas";
            this.PCitas.Size = new System.Drawing.Size(254, 111);
            this.PCitas.TabIndex = 3;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(202, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(47, 53);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // LTurnosProgramados
            // 
            this.LTurnosProgramados.AutoSize = true;
            this.LTurnosProgramados.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTurnosProgramados.Location = new System.Drawing.Point(3, 6);
            this.LTurnosProgramados.Name = "LTurnosProgramados";
            this.LTurnosProgramados.Size = new System.Drawing.Size(193, 19);
            this.LTurnosProgramados.TabIndex = 0;
            this.LTurnosProgramados.Text = "Turnos Programados hoy";
            // 
            // PDoctores
            // 
            this.PDoctores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.PDoctores.Controls.Add(this.pictureBox4);
            this.PDoctores.Controls.Add(this.LDoctores);
            this.PDoctores.Location = new System.Drawing.Point(641, 376);
            this.PDoctores.Name = "PDoctores";
            this.PDoctores.Size = new System.Drawing.Size(264, 100);
            this.PDoctores.TabIndex = 4;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(195, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(65, 50);
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // LDoctores
            // 
            this.LDoctores.AutoSize = true;
            this.LDoctores.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDoctores.Location = new System.Drawing.Point(18, 11);
            this.LDoctores.Name = "LDoctores";
            this.LDoctores.Size = new System.Drawing.Size(171, 19);
            this.LDoctores.TabIndex = 0;
            this.LDoctores.Text = "Doctores  Disponibles";
            // 
            // PEspecialidades
            // 
            this.PEspecialidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.PEspecialidades.Controls.Add(this.label5);
            this.PEspecialidades.Location = new System.Drawing.Point(171, 376);
            this.PEspecialidades.Name = "PEspecialidades";
            this.PEspecialidades.Size = new System.Drawing.Size(260, 100);
            this.PEspecialidades.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(72, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Especialidades";
            // 
            // SaludSoft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 523);
            this.Controls.Add(this.PEspecialidades);
            this.Controls.Add(this.PDoctores);
            this.Controls.Add(this.PCitas);
            this.Controls.Add(this.PPacientes);
            this.Controls.Add(this.PSuperior);
            this.Controls.Add(this.PMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "SaludSoft";
            this.PMenu.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.PSuperior.ResumeLayout(false);
            this.PSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PPacientes.ResumeLayout(false);
            this.PPacientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PPacientesHoy)).EndInit();
            this.PCitas.ResumeLayout(false);
            this.PCitas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.PDoctores.ResumeLayout(false);
            this.PDoctores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.PEspecialidades.ResumeLayout(false);
            this.PEspecialidades.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PMenu;
        private System.Windows.Forms.Panel PSuperior;
        private System.Windows.Forms.Button BNuevaCita;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BTurnos;
        private System.Windows.Forms.Button BPacientes;
        private System.Windows.Forms.Button BInicio;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Label LRecepcionista;
        private System.Windows.Forms.Panel PPacientes;
        private System.Windows.Forms.Label LPacientesHoy;
        private System.Windows.Forms.Panel PCitas;
        private System.Windows.Forms.Label LTurnosProgramados;
        private System.Windows.Forms.Panel PDoctores;
        private System.Windows.Forms.Label LDoctores;
        private System.Windows.Forms.Panel PEspecialidades;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox PPacientesHoy;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button BNuevoPaciente;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BCerrarSesion;
        private System.Windows.Forms.Button BAgenda;
    }
}

