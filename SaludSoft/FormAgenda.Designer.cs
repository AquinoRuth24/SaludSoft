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
            this.LDisponibilidad = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.LConsultorios = new System.Windows.Forms.Label();
            this.LProfesionales = new System.Windows.Forms.Label();
            this.CMBConsultorio = new System.Windows.Forms.ComboBox();
            this.CMBProfesional = new System.Windows.Forms.ComboBox();
            this.PMenu.SuspendLayout();
            this.panel4.SuspendLayout();
            this.PanelLogoPaciente.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTVGAgenda)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PMenu
            // 
            this.PMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(66)))));
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
            this.panel2.Size = new System.Drawing.Size(764, 67);
            this.panel2.TabIndex = 5;
            // 
            // BNuevaDisponibilidad
            // 
            this.BNuevaDisponibilidad.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevaDisponibilidad.Location = new System.Drawing.Point(617, 10);
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
            this.LGestionAgenda.Location = new System.Drawing.Point(257, 10);
            this.LGestionAgenda.Name = "LGestionAgenda";
            this.LGestionAgenda.Size = new System.Drawing.Size(197, 26);
            this.LGestionAgenda.TabIndex = 1;
            this.LGestionAgenda.Text = "Gestion De Agenda";
            // 
            // DTVGAgenda
            // 
            this.DTVGAgenda.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DTVGAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTVGAgenda.Location = new System.Drawing.Point(163, 226);
            this.DTVGAgenda.Name = "DTVGAgenda";
            this.DTVGAgenda.Size = new System.Drawing.Size(764, 288);
            this.DTVGAgenda.TabIndex = 6;
            this.DTVGAgenda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTVGAgenda_CellContentClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LDisponibilidad);
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Controls.Add(this.LConsultorios);
            this.panel3.Controls.Add(this.LProfesionales);
            this.panel3.Controls.Add(this.CMBConsultorio);
            this.panel3.Controls.Add(this.CMBProfesional);
            this.panel3.Location = new System.Drawing.Point(163, 79);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(764, 138);
            this.panel3.TabIndex = 7;
            // 
            // LDisponibilidad
            // 
            this.LDisponibilidad.AutoSize = true;
            this.LDisponibilidad.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDisponibilidad.Location = new System.Drawing.Point(24, 88);
            this.LDisponibilidad.Name = "LDisponibilidad";
            this.LDisponibilidad.Size = new System.Drawing.Size(120, 23);
            this.LDisponibilidad.TabIndex = 5;
            this.LDisponibilidad.Text = "Disponibilidad:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(159, 91);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(271, 26);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // LConsultorios
            // 
            this.LConsultorios.AutoSize = true;
            this.LConsultorios.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LConsultorios.Location = new System.Drawing.Point(391, 19);
            this.LConsultorios.Name = "LConsultorios";
            this.LConsultorios.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LConsultorios.Size = new System.Drawing.Size(104, 23);
            this.LConsultorios.TabIndex = 3;
            this.LConsultorios.Text = "Consultorios:";
            // 
            // LProfesionales
            // 
            this.LProfesionales.AutoSize = true;
            this.LProfesionales.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProfesionales.Location = new System.Drawing.Point(24, 21);
            this.LProfesionales.Name = "LProfesionales";
            this.LProfesionales.Size = new System.Drawing.Size(111, 23);
            this.LProfesionales.TabIndex = 2;
            this.LProfesionales.Text = "Profesionales:";
            // 
            // CMBConsultorio
            // 
            this.CMBConsultorio.FormattingEnabled = true;
            this.CMBConsultorio.Location = new System.Drawing.Point(525, 19);
            this.CMBConsultorio.Name = "CMBConsultorio";
            this.CMBConsultorio.Size = new System.Drawing.Size(172, 21);
            this.CMBConsultorio.TabIndex = 1;
            // 
            // CMBProfesional
            // 
            this.CMBProfesional.FormattingEnabled = true;
            this.CMBProfesional.Location = new System.Drawing.Point(159, 23);
            this.CMBProfesional.Name = "CMBProfesional";
            this.CMBProfesional.Size = new System.Drawing.Size(185, 21);
            this.CMBProfesional.TabIndex = 0;
            this.CMBProfesional.SelectedIndexChanged += new System.EventHandler(this.CMBProfesional_SelectedIndexChanged);
            // 
            // FormAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 518);
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
        private System.Windows.Forms.ComboBox CMBConsultorio;
        private System.Windows.Forms.ComboBox CMBProfesional;
        private System.Windows.Forms.Label LProfesionales;
        private System.Windows.Forms.Label LDisponibilidad;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label LConsultorios;
    }
}