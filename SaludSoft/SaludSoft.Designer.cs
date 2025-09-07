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
            this.BDoctores = new System.Windows.Forms.Button();
            this.BCitasMedicas = new System.Windows.Forms.Button();
            this.BPacientes = new System.Windows.Forms.Button();
            this.BInicio = new System.Windows.Forms.Button();
            this.PSuperior = new System.Windows.Forms.Panel();
            this.LRecepcionista = new System.Windows.Forms.Label();
            this.Label = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BCita = new System.Windows.Forms.Button();
            this.PPacientes = new System.Windows.Forms.Panel();
            this.PPacientesHoy = new System.Windows.Forms.PictureBox();
            this.LPacientesHoy = new System.Windows.Forms.Label();
            this.PCitas = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.LCitasProgramadas = new System.Windows.Forms.Label();
            this.PDoctores = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.LDoctores = new System.Windows.Forms.Label();
            this.PRoximaCitas = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.LproximaCita = new System.Windows.Forms.Label();
            this.PEspecialidades = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.PTurnos = new System.Windows.Forms.Panel();
            this.LTodosLosTurnos = new System.Windows.Forms.Label();
            this.PMenu.SuspendLayout();
            this.PSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PPacientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PPacientesHoy)).BeginInit();
            this.PCitas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.PDoctores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.PRoximaCitas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.PEspecialidades.SuspendLayout();
            this.PTurnos.SuspendLayout();
            this.SuspendLayout();
            // 
            // PMenu
            // 
            this.PMenu.BackColor = System.Drawing.Color.DarkGreen;
            this.PMenu.Controls.Add(this.BDoctores);
            this.PMenu.Controls.Add(this.BCitasMedicas);
            this.PMenu.Controls.Add(this.BPacientes);
            this.PMenu.Controls.Add(this.BInicio);
            this.PMenu.Location = new System.Drawing.Point(2, 65);
            this.PMenu.Name = "PMenu";
            this.PMenu.Size = new System.Drawing.Size(120, 384);
            this.PMenu.TabIndex = 0;
            // 
            // BDoctores
            // 
            this.BDoctores.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BDoctores.Location = new System.Drawing.Point(10, 251);
            this.BDoctores.Name = "BDoctores";
            this.BDoctores.Size = new System.Drawing.Size(92, 46);
            this.BDoctores.TabIndex = 3;
            this.BDoctores.Text = "Doctores";
            this.BDoctores.UseVisualStyleBackColor = true;
            // 
            // BCitasMedicas
            // 
            this.BCitasMedicas.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCitasMedicas.Location = new System.Drawing.Point(10, 166);
            this.BCitasMedicas.Name = "BCitasMedicas";
            this.BCitasMedicas.Size = new System.Drawing.Size(92, 61);
            this.BCitasMedicas.TabIndex = 4;
            this.BCitasMedicas.Text = "Citas Medicas";
            this.BCitasMedicas.UseVisualStyleBackColor = true;
            // 
            // BPacientes
            // 
            this.BPacientes.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPacientes.Location = new System.Drawing.Point(3, 103);
            this.BPacientes.Name = "BPacientes";
            this.BPacientes.Size = new System.Drawing.Size(114, 40);
            this.BPacientes.TabIndex = 5;
            this.BPacientes.Text = "Pacientes";
            this.BPacientes.UseVisualStyleBackColor = true;
            // 
            // BInicio
            // 
            this.BInicio.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BInicio.Location = new System.Drawing.Point(10, 37);
            this.BInicio.Name = "BInicio";
            this.BInicio.Size = new System.Drawing.Size(92, 43);
            this.BInicio.TabIndex = 2;
            this.BInicio.Text = "Inicio";
            this.BInicio.UseVisualStyleBackColor = true;
            // 
            // PSuperior
            // 
            this.PSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.PSuperior.Controls.Add(this.LRecepcionista);
            this.PSuperior.Controls.Add(this.Label);
            this.PSuperior.Controls.Add(this.LNombre);
            this.PSuperior.Controls.Add(this.pictureBox1);
            this.PSuperior.Controls.Add(this.BCita);
            this.PSuperior.Location = new System.Drawing.Point(2, 1);
            this.PSuperior.Name = "PSuperior";
            this.PSuperior.Size = new System.Drawing.Size(800, 75);
            this.PSuperior.TabIndex = 1;
            // 
            // LRecepcionista
            // 
            this.LRecepcionista.AutoSize = true;
            this.LRecepcionista.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.Label.Location = new System.Drawing.Point(357, 43);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(192, 19);
            this.Label.TabIndex = 2;
            this.Label.Text = "Sistema de Gestión Médica";
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(387, 8);
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
            // BCita
            // 
            this.BCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(32)))));
            this.BCita.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCita.ForeColor = System.Drawing.Color.White;
            this.BCita.Location = new System.Drawing.Point(668, 11);
            this.BCita.Name = "BCita";
            this.BCita.Size = new System.Drawing.Size(118, 54);
            this.BCita.TabIndex = 0;
            this.BCita.Text = "+   Nueva Cita";
            this.BCita.UseVisualStyleBackColor = false;
            // 
            // PPacientes
            // 
            this.PPacientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.PPacientes.Controls.Add(this.PPacientesHoy);
            this.PPacientes.Controls.Add(this.LPacientesHoy);
            this.PPacientes.Location = new System.Drawing.Point(128, 108);
            this.PPacientes.Name = "PPacientes";
            this.PPacientes.Size = new System.Drawing.Size(200, 100);
            this.PPacientes.TabIndex = 2;
            // 
            // PPacientesHoy
            // 
            this.PPacientesHoy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PPacientesHoy.BackgroundImage")));
            this.PPacientesHoy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PPacientesHoy.Location = new System.Drawing.Point(124, 0);
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
            this.PCitas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.PCitas.Controls.Add(this.pictureBox3);
            this.PCitas.Controls.Add(this.LCitasProgramadas);
            this.PCitas.Location = new System.Drawing.Point(363, 108);
            this.PCitas.Name = "PCitas";
            this.PCitas.Size = new System.Drawing.Size(200, 100);
            this.PCitas.TabIndex = 3;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(153, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(47, 53);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // LCitasProgramadas
            // 
            this.LCitasProgramadas.AutoSize = true;
            this.LCitasProgramadas.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCitasProgramadas.Location = new System.Drawing.Point(3, 6);
            this.LCitasProgramadas.Name = "LCitasProgramadas";
            this.LCitasProgramadas.Size = new System.Drawing.Size(150, 19);
            this.LCitasProgramadas.TabIndex = 0;
            this.LCitasProgramadas.Text = "Citas Programadas";
            // 
            // PDoctores
            // 
            this.PDoctores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.PDoctores.Controls.Add(this.pictureBox4);
            this.PDoctores.Controls.Add(this.LDoctores);
            this.PDoctores.Location = new System.Drawing.Point(588, 108);
            this.PDoctores.Name = "PDoctores";
            this.PDoctores.Size = new System.Drawing.Size(200, 100);
            this.PDoctores.TabIndex = 4;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(135, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(65, 50);
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // LDoctores
            // 
            this.LDoctores.AutoSize = true;
            this.LDoctores.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDoctores.Location = new System.Drawing.Point(35, 6);
            this.LDoctores.Name = "LDoctores";
            this.LDoctores.Size = new System.Drawing.Size(80, 19);
            this.LDoctores.TabIndex = 0;
            this.LDoctores.Text = "Doctores ";
            // 
            // PRoximaCitas
            // 
            this.PRoximaCitas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.PRoximaCitas.Controls.Add(this.pictureBox5);
            this.PRoximaCitas.Controls.Add(this.LproximaCita);
            this.PRoximaCitas.Location = new System.Drawing.Point(128, 262);
            this.PRoximaCitas.Name = "PRoximaCitas";
            this.PRoximaCitas.Size = new System.Drawing.Size(200, 100);
            this.PRoximaCitas.TabIndex = 5;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(148, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(52, 50);
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            // 
            // LproximaCita
            // 
            this.LproximaCita.AutoSize = true;
            this.LproximaCita.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LproximaCita.Location = new System.Drawing.Point(3, 11);
            this.LproximaCita.Name = "LproximaCita";
            this.LproximaCita.Size = new System.Drawing.Size(121, 19);
            this.LproximaCita.TabIndex = 0;
            this.LproximaCita.Text = "Proximas Citas";
            // 
            // PEspecialidades
            // 
            this.PEspecialidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.PEspecialidades.Controls.Add(this.label5);
            this.PEspecialidades.Location = new System.Drawing.Point(363, 262);
            this.PEspecialidades.Name = "PEspecialidades";
            this.PEspecialidades.Size = new System.Drawing.Size(200, 100);
            this.PEspecialidades.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Especialidades";
            // 
            // PTurnos
            // 
            this.PTurnos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.PTurnos.Controls.Add(this.LTodosLosTurnos);
            this.PTurnos.Location = new System.Drawing.Point(588, 262);
            this.PTurnos.Name = "PTurnos";
            this.PTurnos.Size = new System.Drawing.Size(200, 100);
            this.PTurnos.TabIndex = 7;
            // 
            // LTodosLosTurnos
            // 
            this.LTodosLosTurnos.AutoSize = true;
            this.LTodosLosTurnos.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTodosLosTurnos.Location = new System.Drawing.Point(35, 11);
            this.LTodosLosTurnos.Name = "LTodosLosTurnos";
            this.LTodosLosTurnos.Size = new System.Drawing.Size(138, 19);
            this.LTodosLosTurnos.TabIndex = 0;
            this.LTodosLosTurnos.Text = "Todos Los Turnos";
            // 
            // SaludSoft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PTurnos);
            this.Controls.Add(this.PEspecialidades);
            this.Controls.Add(this.PRoximaCitas);
            this.Controls.Add(this.PDoctores);
            this.Controls.Add(this.PCitas);
            this.Controls.Add(this.PPacientes);
            this.Controls.Add(this.PSuperior);
            this.Controls.Add(this.PMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "SaludSoft";
            this.PMenu.ResumeLayout(false);
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
            this.PRoximaCitas.ResumeLayout(false);
            this.PRoximaCitas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.PEspecialidades.ResumeLayout(false);
            this.PEspecialidades.PerformLayout();
            this.PTurnos.ResumeLayout(false);
            this.PTurnos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PMenu;
        private System.Windows.Forms.Panel PSuperior;
        private System.Windows.Forms.Button BCita;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BDoctores;
        private System.Windows.Forms.Button BCitasMedicas;
        private System.Windows.Forms.Button BPacientes;
        private System.Windows.Forms.Button BInicio;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Label LRecepcionista;
        private System.Windows.Forms.Panel PPacientes;
        private System.Windows.Forms.Label LPacientesHoy;
        private System.Windows.Forms.Panel PCitas;
        private System.Windows.Forms.Label LCitasProgramadas;
        private System.Windows.Forms.Panel PDoctores;
        private System.Windows.Forms.Label LDoctores;
        private System.Windows.Forms.Panel PRoximaCitas;
        private System.Windows.Forms.Label LproximaCita;
        private System.Windows.Forms.Panel PEspecialidades;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel PTurnos;
        private System.Windows.Forms.Label LTodosLosTurnos;
        private System.Windows.Forms.PictureBox PPacientesHoy;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}

