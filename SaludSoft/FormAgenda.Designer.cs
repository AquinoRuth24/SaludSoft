namespace SaludSoft
{
    partial class FormAgenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgenda));
            this.PMenu = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BCerrarSesion = new System.Windows.Forms.Button();
            this.BDoctores = new System.Windows.Forms.Button();
            this.BTurnos = new System.Windows.Forms.Button();
            this.BPacientes = new System.Windows.Forms.Button();
            this.BInicio = new System.Windows.Forms.Button();
            this.PanelLogoPaciente = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BVolver = new System.Windows.Forms.Button();
            this.LTexto = new System.Windows.Forms.Label();
            this.LabelGestionPaciente = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BNuevaDisponibilidad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LGestionAgenda = new System.Windows.Forms.Label();
            this.DTVGAgenda = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BBuscar = new System.Windows.Forms.Button();
            this.LConsultorio = new System.Windows.Forms.Label();
            this.LProfesional = new System.Windows.Forms.Label();
            this.CMBConsultorio = new System.Windows.Forms.ComboBox();
            this.CMBProfesionales = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BAgenda = new System.Windows.Forms.Button();
            this.PMenu.SuspendLayout();
            this.panel4.SuspendLayout();
            this.PanelLogoPaciente.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTVGAgenda)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // PMenu
            // 
            this.PMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(66)))));
            this.PMenu.Controls.Add(this.BAgenda);
            this.PMenu.Controls.Add(this.panel4);
            this.PMenu.Controls.Add(this.BDoctores);
            this.PMenu.Controls.Add(this.BTurnos);
            this.PMenu.Controls.Add(this.BPacientes);
            this.PMenu.Controls.Add(this.BInicio);
            this.PMenu.Location = new System.Drawing.Point(3, 79);
            this.PMenu.Name = "PMenu";
            this.PMenu.Size = new System.Drawing.Size(154, 438);
            this.PMenu.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BCerrarSesion);
            this.panel4.Location = new System.Drawing.Point(3, 314);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(151, 124);
            this.panel4.TabIndex = 9;
            // 
            // BCerrarSesion
            // 
            this.BCerrarSesion.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCerrarSesion.Location = new System.Drawing.Point(20, 7);
            this.BCerrarSesion.Name = "BCerrarSesion";
            this.BCerrarSesion.Size = new System.Drawing.Size(108, 53);
            this.BCerrarSesion.TabIndex = 6;
            this.BCerrarSesion.Text = "Cerrar sesion";
            this.BCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // BDoctores
            // 
            this.BDoctores.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BDoctores.Location = new System.Drawing.Point(27, 200);
            this.BDoctores.Name = "BDoctores";
            this.BDoctores.Size = new System.Drawing.Size(92, 46);
            this.BDoctores.TabIndex = 3;
            this.BDoctores.Text = "Doctores";
            this.BDoctores.UseVisualStyleBackColor = true;
            // 
            // BTurnos
            // 
            this.BTurnos.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTurnos.Location = new System.Drawing.Point(17, 147);
            this.BTurnos.Name = "BTurnos";
            this.BTurnos.Size = new System.Drawing.Size(108, 37);
            this.BTurnos.TabIndex = 4;
            this.BTurnos.Text = "Turnos";
            this.BTurnos.UseVisualStyleBackColor = true;
            // 
            // BPacientes
            // 
            this.BPacientes.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPacientes.Location = new System.Drawing.Point(17, 91);
            this.BPacientes.Name = "BPacientes";
            this.BPacientes.Size = new System.Drawing.Size(114, 40);
            this.BPacientes.TabIndex = 5;
            this.BPacientes.Text = "Pacientes";
            this.BPacientes.UseVisualStyleBackColor = true;
            // 
            // BInicio
            // 
            this.BInicio.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BInicio.Location = new System.Drawing.Point(27, 39);
            this.BInicio.Name = "BInicio";
            this.BInicio.Size = new System.Drawing.Size(92, 43);
            this.BInicio.TabIndex = 2;
            this.BInicio.Text = "Inicio";
            this.BInicio.UseVisualStyleBackColor = true;
            // 
            // PanelLogoPaciente
            // 
            this.PanelLogoPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(66)))));
            this.PanelLogoPaciente.Controls.Add(this.panel1);
            this.PanelLogoPaciente.Controls.Add(this.pictureBox1);
            this.PanelLogoPaciente.Location = new System.Drawing.Point(3, 0);
            this.PanelLogoPaciente.Name = "PanelLogoPaciente";
            this.PanelLogoPaciente.Size = new System.Drawing.Size(154, 108);
            this.PanelLogoPaciente.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.BVolver);
            this.panel1.Controls.Add(this.LTexto);
            this.panel1.Controls.Add(this.LabelGestionPaciente);
            this.panel1.Location = new System.Drawing.Point(160, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 46);
            this.panel1.TabIndex = 5;
            // 
            // BVolver
            // 
            this.BVolver.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVolver.Location = new System.Drawing.Point(15, 9);
            this.BVolver.Name = "BVolver";
            this.BVolver.Size = new System.Drawing.Size(77, 31);
            this.BVolver.TabIndex = 3;
            this.BVolver.Text = "<--Volver";
            this.BVolver.UseVisualStyleBackColor = true;
            // 
            // LTexto
            // 
            this.LTexto.AutoSize = true;
            this.LTexto.Location = new System.Drawing.Point(51, 47);
            this.LTexto.Name = "LTexto";
            this.LTexto.Size = new System.Drawing.Size(0, 13);
            this.LTexto.TabIndex = 2;
            // 
            // LabelGestionPaciente
            // 
            this.LabelGestionPaciente.AutoSize = true;
            this.LabelGestionPaciente.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGestionPaciente.Location = new System.Drawing.Point(292, 9);
            this.LabelGestionPaciente.Name = "LabelGestionPaciente";
            this.LabelGestionPaciente.Size = new System.Drawing.Size(213, 26);
            this.LabelGestionPaciente.TabIndex = 1;
            this.LabelGestionPaciente.Text = "Gestion De Pacientes";
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.BNuevaDisponibilidad);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.LGestionAgenda);
            this.panel2.Location = new System.Drawing.Point(163, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(865, 67);
            this.panel2.TabIndex = 5;
            // 
            // BNuevaDisponibilidad
            // 
            this.BNuevaDisponibilidad.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevaDisponibilidad.Location = new System.Drawing.Point(735, 7);
            this.BNuevaDisponibilidad.Name = "BNuevaDisponibilidad";
            this.BNuevaDisponibilidad.Size = new System.Drawing.Size(113, 52);
            this.BNuevaDisponibilidad.TabIndex = 3;
            this.BNuevaDisponibilidad.Text = "Nueva Disponibilidad";
            this.BNuevaDisponibilidad.UseVisualStyleBackColor = true;
            this.BNuevaDisponibilidad.Click += new System.EventHandler(this.BNuevaDisponibilidad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // LGestionAgenda
            // 
            this.LGestionAgenda.AutoSize = true;
            this.LGestionAgenda.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LGestionAgenda.Location = new System.Drawing.Point(308, 20);
            this.LGestionAgenda.Name = "LGestionAgenda";
            this.LGestionAgenda.Size = new System.Drawing.Size(197, 26);
            this.LGestionAgenda.TabIndex = 1;
            this.LGestionAgenda.Text = "Gestion De Agenda";
            // 
            // DTVGAgenda
            // 
            this.DTVGAgenda.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DTVGAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTVGAgenda.Location = new System.Drawing.Point(163, 154);
            this.DTVGAgenda.Name = "DTVGAgenda";
            this.DTVGAgenda.Size = new System.Drawing.Size(865, 360);
            this.DTVGAgenda.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BBuscar);
            this.panel3.Controls.Add(this.LConsultorio);
            this.panel3.Controls.Add(this.LProfesional);
            this.panel3.Controls.Add(this.CMBConsultorio);
            this.panel3.Controls.Add(this.CMBProfesionales);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(163, 79);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(865, 69);
            this.panel3.TabIndex = 7;
            // 
            // BBuscar
            // 
            this.BBuscar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscar.Location = new System.Drawing.Point(756, 26);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(92, 34);
            this.BBuscar.TabIndex = 18;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = true;
            // 
            // LConsultorio
            // 
            this.LConsultorio.AutoSize = true;
            this.LConsultorio.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LConsultorio.Location = new System.Drawing.Point(547, 6);
            this.LConsultorio.Name = "LConsultorio";
            this.LConsultorio.Size = new System.Drawing.Size(97, 23);
            this.LConsultorio.TabIndex = 16;
            this.LConsultorio.Text = "Consultorio:";
            // 
            // LProfesional
            // 
            this.LProfesional.AutoSize = true;
            this.LProfesional.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProfesional.Location = new System.Drawing.Point(272, 6);
            this.LProfesional.Name = "LProfesional";
            this.LProfesional.Size = new System.Drawing.Size(96, 23);
            this.LProfesional.TabIndex = 15;
            this.LProfesional.Text = "Profesional:";
            // 
            // CMBConsultorio
            // 
            this.CMBConsultorio.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMBConsultorio.FormattingEnabled = true;
            this.CMBConsultorio.Location = new System.Drawing.Point(484, 32);
            this.CMBConsultorio.Name = "CMBConsultorio";
            this.CMBConsultorio.Size = new System.Drawing.Size(229, 28);
            this.CMBConsultorio.TabIndex = 13;
            // 
            // CMBProfesionales
            // 
            this.CMBProfesionales.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMBProfesionales.FormattingEnabled = true;
            this.CMBProfesionales.Location = new System.Drawing.Point(210, 32);
            this.CMBProfesionales.Name = "CMBProfesionales";
            this.CMBProfesionales.Size = new System.Drawing.Size(216, 28);
            this.CMBProfesionales.TabIndex = 12;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(3, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 44);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // BAgenda
            // 
            this.BAgenda.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgenda.Location = new System.Drawing.Point(21, 264);
            this.BAgenda.Name = "BAgenda";
            this.BAgenda.Size = new System.Drawing.Size(98, 35);
            this.BAgenda.TabIndex = 10;
            this.BAgenda.Text = "Agenda";
            this.BAgenda.UseVisualStyleBackColor = true;
            // 
            // FormAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 518);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.DTVGAgenda);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PanelLogoPaciente);
            this.Controls.Add(this.PMenu);
            this.Name = "FormAgenda";
            this.Text = "FormAgenda";
            this.PMenu.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.PanelLogoPaciente.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTVGAgenda)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PMenu;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BCerrarSesion;
        private System.Windows.Forms.Button BDoctores;
        private System.Windows.Forms.Button BTurnos;
        private System.Windows.Forms.Button BPacientes;
        private System.Windows.Forms.Button BInicio;
        private System.Windows.Forms.Panel PanelLogoPaciente;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BVolver;
        private System.Windows.Forms.Label LTexto;
        private System.Windows.Forms.Label LabelGestionPaciente;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LGestionAgenda;
        private System.Windows.Forms.Button BNuevaDisponibilidad;
        private System.Windows.Forms.DataGridView DTVGAgenda;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.Label LConsultorio;
        private System.Windows.Forms.Label LProfesional;
        private System.Windows.Forms.ComboBox CMBConsultorio;
        private System.Windows.Forms.ComboBox CMBProfesionales;
        private System.Windows.Forms.Button BAgenda;
    }
}