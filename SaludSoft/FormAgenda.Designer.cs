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
            this.panel2 = new System.Windows.Forms.Panel();
            this.BVolverAgenda = new System.Windows.Forms.Button();
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
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTVGAgenda)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.BVolverAgenda);
            this.panel2.Controls.Add(this.BNuevaDisponibilidad);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.LGestionAgenda);
            this.panel2.Location = new System.Drawing.Point(0, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 67);
            this.panel2.TabIndex = 5;
            // 
            // BVolverAgenda
            // 
            this.BVolverAgenda.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVolverAgenda.Location = new System.Drawing.Point(15, 19);
            this.BVolverAgenda.Name = "BVolverAgenda";
            this.BVolverAgenda.Size = new System.Drawing.Size(77, 31);
            this.BVolverAgenda.TabIndex = 8;
            this.BVolverAgenda.Text = "<--Volver";
            this.BVolverAgenda.UseVisualStyleBackColor = true;
            this.BVolverAgenda.Click += new System.EventHandler(this.BVolverAgenda_Click);
            // 
            // BNuevaDisponibilidad
            // 
            this.BNuevaDisponibilidad.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevaDisponibilidad.Location = new System.Drawing.Point(884, 8);
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
            this.LGestionAgenda.Location = new System.Drawing.Point(468, 19);
            this.LGestionAgenda.Name = "LGestionAgenda";
            this.LGestionAgenda.Size = new System.Drawing.Size(197, 26);
            this.LGestionAgenda.TabIndex = 1;
            this.LGestionAgenda.Text = "Gestion De Agenda";
            // 
            // DTVGAgenda
            // 
            this.DTVGAgenda.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DTVGAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTVGAgenda.Location = new System.Drawing.Point(0, 154);
            this.DTVGAgenda.Name = "DTVGAgenda";
            this.DTVGAgenda.Size = new System.Drawing.Size(1028, 360);
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
            this.panel3.Location = new System.Drawing.Point(0, 79);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1028, 69);
            this.panel3.TabIndex = 7;
            // 
            // BBuscar
            // 
            this.BBuscar.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscar.Location = new System.Drawing.Point(917, 16);
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
            this.LConsultorio.Location = new System.Drawing.Point(662, 6);
            this.LConsultorio.Name = "LConsultorio";
            this.LConsultorio.Size = new System.Drawing.Size(97, 23);
            this.LConsultorio.TabIndex = 16;
            this.LConsultorio.Text = "Consultorio:";
            // 
            // LProfesional
            // 
            this.LProfesional.AutoSize = true;
            this.LProfesional.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProfesional.Location = new System.Drawing.Point(403, 6);
            this.LProfesional.Name = "LProfesional";
            this.LProfesional.Size = new System.Drawing.Size(96, 23);
            this.LProfesional.TabIndex = 15;
            this.LProfesional.Text = "Profesional:";
            // 
            // CMBConsultorio
            // 
            this.CMBConsultorio.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMBConsultorio.FormattingEnabled = true;
            this.CMBConsultorio.Location = new System.Drawing.Point(586, 32);
            this.CMBConsultorio.Name = "CMBConsultorio";
            this.CMBConsultorio.Size = new System.Drawing.Size(229, 28);
            this.CMBConsultorio.TabIndex = 13;
            // 
            // CMBProfesionales
            // 
            this.CMBProfesionales.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMBProfesionales.FormattingEnabled = true;
            this.CMBProfesionales.Location = new System.Drawing.Point(340, 32);
            this.CMBProfesionales.Name = "CMBProfesionales";
            this.CMBProfesionales.Size = new System.Drawing.Size(216, 28);
            this.CMBProfesionales.TabIndex = 12;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(144, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 44);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // FormAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 518);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.DTVGAgenda);
            this.Controls.Add(this.panel2);
            this.Name = "FormAgenda";
            this.Text = "FormAgenda";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTVGAgenda)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.Button BVolverAgenda;
    }
}