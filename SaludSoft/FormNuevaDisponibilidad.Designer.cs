namespace SaludSoft
{
    partial class FormNuevaDisponibilidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNuevaDisponibilidad));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LTexto = new System.Windows.Forms.Label();
            this.LNuevaDisponibilidad = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LDia = new System.Windows.Forms.Label();
            this.CBDiaSemana = new System.Windows.Forms.ComboBox();
            this.BGuardar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.DPTHoraFin = new System.Windows.Forms.DateTimePicker();
            this.DTPHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LHoraFin = new System.Windows.Forms.Label();
            this.LHoraInicio = new System.Windows.Forms.Label();
            this.LProfesionales = new System.Windows.Forms.Label();
            this.CMBProfesional_consultorio = new System.Windows.Forms.ComboBox();
            this.BVolverAgenda = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.BVolverAgenda);
            this.panel1.Controls.Add(this.LTexto);
            this.panel1.Controls.Add(this.LNuevaDisponibilidad);
            this.panel1.Location = new System.Drawing.Point(2, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 51);
            this.panel1.TabIndex = 5;
            // 
            // LTexto
            // 
            this.LTexto.AutoSize = true;
            this.LTexto.Location = new System.Drawing.Point(51, 47);
            this.LTexto.Name = "LTexto";
            this.LTexto.Size = new System.Drawing.Size(0, 13);
            this.LTexto.TabIndex = 2;
            // 
            // LNuevaDisponibilidad
            // 
            this.LNuevaDisponibilidad.AutoSize = true;
            this.LNuevaDisponibilidad.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNuevaDisponibilidad.Location = new System.Drawing.Point(434, 15);
            this.LNuevaDisponibilidad.Name = "LNuevaDisponibilidad";
            this.LNuevaDisponibilidad.Size = new System.Drawing.Size(220, 26);
            this.LNuevaDisponibilidad.TabIndex = 1;
            this.LNuevaDisponibilidad.Text = "Nueva Disponibilidad";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.LDia);
            this.panel3.Controls.Add(this.CBDiaSemana);
            this.panel3.Controls.Add(this.BGuardar);
            this.panel3.Controls.Add(this.BCancelar);
            this.panel3.Controls.Add(this.DPTHoraFin);
            this.panel3.Controls.Add(this.DTPHoraInicio);
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.LHoraFin);
            this.panel3.Controls.Add(this.LHoraInicio);
            this.panel3.Controls.Add(this.LProfesionales);
            this.panel3.Controls.Add(this.CMBProfesional_consultorio);
            this.panel3.Location = new System.Drawing.Point(2, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1013, 454);
            this.panel3.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(183, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 23);
            this.label2.TabIndex = 21;
            this.label2.Text = "Consultorios";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 23);
            this.label1.TabIndex = 20;
            this.label1.Text = "Y";
            // 
            // LDia
            // 
            this.LDia.AutoSize = true;
            this.LDia.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDia.Location = new System.Drawing.Point(136, 267);
            this.LDia.Name = "LDia";
            this.LDia.Size = new System.Drawing.Size(146, 23);
            this.LDia.TabIndex = 19;
            this.LDia.Text = "Dia De La Semana:";
            // 
            // CBDiaSemana
            // 
            this.CBDiaSemana.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBDiaSemana.FormattingEnabled = true;
            this.CBDiaSemana.Location = new System.Drawing.Point(122, 313);
            this.CBDiaSemana.Name = "CBDiaSemana";
            this.CBDiaSemana.Size = new System.Drawing.Size(160, 28);
            this.CBDiaSemana.TabIndex = 16;
            // 
            // BGuardar
            // 
            this.BGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.BGuardar.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardar.Location = new System.Drawing.Point(911, 404);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(99, 36);
            this.BGuardar.TabIndex = 13;
            this.BGuardar.Text = "Guardar";
            this.BGuardar.UseVisualStyleBackColor = false;
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelar.Location = new System.Drawing.Point(783, 404);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(97, 36);
            this.BCancelar.TabIndex = 12;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // DPTHoraFin
            // 
            this.DPTHoraFin.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DPTHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DPTHoraFin.Location = new System.Drawing.Point(771, 310);
            this.DPTHoraFin.Name = "DPTHoraFin";
            this.DPTHoraFin.ShowUpDown = true;
            this.DPTHoraFin.Size = new System.Drawing.Size(102, 28);
            this.DPTHoraFin.TabIndex = 11;
            // 
            // DTPHoraInicio
            // 
            this.DTPHoraInicio.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTPHoraInicio.Location = new System.Drawing.Point(474, 310);
            this.DTPHoraInicio.Name = "DTPHoraInicio";
            this.DTPHoraInicio.ShowUpDown = true;
            this.DTPHoraInicio.Size = new System.Drawing.Size(105, 28);
            this.DTPHoraInicio.TabIndex = 10;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(54, 18);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(107, 89);
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(454, 139);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(81, 102);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // LHoraFin
            // 
            this.LHoraFin.AutoSize = true;
            this.LHoraFin.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LHoraFin.Location = new System.Drawing.Point(779, 267);
            this.LHoraFin.Name = "LHoraFin";
            this.LHoraFin.Size = new System.Drawing.Size(74, 23);
            this.LHoraFin.TabIndex = 7;
            this.LHoraFin.Text = "Hora Fin";
            // 
            // LHoraInicio
            // 
            this.LHoraInicio.AutoSize = true;
            this.LHoraInicio.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LHoraInicio.Location = new System.Drawing.Point(459, 267);
            this.LHoraInicio.Name = "LHoraInicio";
            this.LHoraInicio.Size = new System.Drawing.Size(94, 23);
            this.LHoraInicio.TabIndex = 6;
            this.LHoraInicio.Text = "Hora Inicio";
            // 
            // LProfesionales
            // 
            this.LProfesionales.AutoSize = true;
            this.LProfesionales.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProfesionales.Location = new System.Drawing.Point(183, 18);
            this.LProfesionales.Name = "LProfesionales";
            this.LProfesionales.Size = new System.Drawing.Size(106, 23);
            this.LProfesionales.TabIndex = 2;
            this.LProfesionales.Text = "Profesionales";
            // 
            // CMBProfesional_consultorio
            // 
            this.CMBProfesional_consultorio.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMBProfesional_consultorio.FormattingEnabled = true;
            this.CMBProfesional_consultorio.Location = new System.Drawing.Point(389, 42);
            this.CMBProfesional_consultorio.Name = "CMBProfesional_consultorio";
            this.CMBProfesional_consultorio.Size = new System.Drawing.Size(237, 28);
            this.CMBProfesional_consultorio.TabIndex = 0;
            // 
            // BVolverAgenda
            // 
            this.BVolverAgenda.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVolverAgenda.Location = new System.Drawing.Point(10, 10);
            this.BVolverAgenda.Name = "BVolverAgenda";
            this.BVolverAgenda.Size = new System.Drawing.Size(77, 31);
            this.BVolverAgenda.TabIndex = 9;
            this.BVolverAgenda.Text = "<--Volver";
            this.BVolverAgenda.UseVisualStyleBackColor = true;
            this.BVolverAgenda.Click += new System.EventHandler(this.BVolverAgenda_Click);
            // 
            // FormNuevaDisponibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 530);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FormNuevaDisponibilidad";
            this.Text = "FormNuevaDisponibilidad";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LTexto;
        private System.Windows.Forms.Label LNuevaDisponibilidad;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LProfesionales;
        private System.Windows.Forms.ComboBox CMBProfesional_consultorio;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LHoraFin;
        private System.Windows.Forms.Label LHoraInicio;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DateTimePicker DPTHoraFin;
        private System.Windows.Forms.DateTimePicker DTPHoraInicio;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.ComboBox CBDiaSemana;
        private System.Windows.Forms.Label LDia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BVolverAgenda;
    }
}