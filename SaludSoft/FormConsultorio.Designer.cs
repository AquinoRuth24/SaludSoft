namespace SaludSoft
{
    partial class FormConsultorio
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
            this.BVolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DGWConsultorios_profesional = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LDescripcion = new System.Windows.Forms.Label();
            this.LContador = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BAgregarConsultorio = new System.Windows.Forms.Button();
            this.BAsignarProfesional = new System.Windows.Forms.Button();
            this.GBAgregarConsultorio = new System.Windows.Forms.GroupBox();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BAgregar = new System.Windows.Forms.Button();
            this.TBDescripcion = new System.Windows.Forms.TextBox();
            this.TBNroConsultorio = new System.Windows.Forms.TextBox();
            this.LConsultorio = new System.Windows.Forms.Label();
            this.LDescripcionConsul = new System.Windows.Forms.Label();
            this.GBAsignarProfesional = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.L = new System.Windows.Forms.Label();
            this.BAgregarProfesional_consultorio = new System.Windows.Forms.Button();
            this.BCancelarProfesional_consultorio = new System.Windows.Forms.Button();
            this.CMBProfesional = new System.Windows.Forms.ComboBox();
            this.CMBConsultorio = new System.Windows.Forms.ComboBox();
            this.DTPDesde = new System.Windows.Forms.DateTimePicker();
            this.DTPHasta = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGWConsultorios_profesional)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.GBAgregarConsultorio.SuspendLayout();
            this.GBAsignarProfesional.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.BVolver);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 79);
            this.panel1.TabIndex = 2;
            // 
            // BVolver
            // 
            this.BVolver.Image = global::SaludSoft.Properties.Resources.angulo_izquierdo;
            this.BVolver.Location = new System.Drawing.Point(12, 17);
            this.BVolver.Name = "BVolver";
            this.BVolver.Size = new System.Drawing.Size(75, 44);
            this.BVolver.TabIndex = 1;
            this.BVolver.UseVisualStyleBackColor = true;
            this.BVolver.Click += new System.EventHandler(this.BVolver_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(419, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gestión de Consultorios";
            // 
            // DGWConsultorios_profesional
            // 
            this.DGWConsultorios_profesional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGWConsultorios_profesional.Location = new System.Drawing.Point(1, 265);
            this.DGWConsultorios_profesional.Name = "DGWConsultorios_profesional";
            this.DGWConsultorios_profesional.Size = new System.Drawing.Size(1044, 267);
            this.DGWConsultorios_profesional.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.Controls.Add(this.LDescripcion);
            this.panel2.Controls.Add(this.LContador);
            this.panel2.Location = new System.Drawing.Point(331, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 88);
            this.panel2.TabIndex = 8;
            // 
            // LDescripcion
            // 
            this.LDescripcion.AutoSize = true;
            this.LDescripcion.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDescripcion.Location = new System.Drawing.Point(25, 61);
            this.LDescripcion.Name = "LDescripcion";
            this.LDescripcion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LDescripcion.Size = new System.Drawing.Size(139, 19);
            this.LDescripcion.TabIndex = 1;
            this.LDescripcion.Text = "Total Consultorios";
            this.LDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LContador
            // 
            this.LContador.AutoSize = true;
            this.LContador.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LContador.Location = new System.Drawing.Point(76, 13);
            this.LContador.Name = "LContador";
            this.LContador.Size = new System.Drawing.Size(29, 32);
            this.LContador.TabIndex = 0;
            this.LContador.Text = "0";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGreen;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(581, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(193, 88);
            this.panel3.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 61);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Disponibles";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "0";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGreen;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(811, 86);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(199, 88);
            this.panel4.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 61);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(80, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Asignados";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(88, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 32);
            this.label5.TabIndex = 0;
            this.label5.Text = "0";
            // 
            // BAgregarConsultorio
            // 
            this.BAgregarConsultorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BAgregarConsultorio.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregarConsultorio.ForeColor = System.Drawing.Color.Black;
            this.BAgregarConsultorio.Location = new System.Drawing.Point(22, 206);
            this.BAgregarConsultorio.Name = "BAgregarConsultorio";
            this.BAgregarConsultorio.Size = new System.Drawing.Size(190, 43);
            this.BAgregarConsultorio.TabIndex = 11;
            this.BAgregarConsultorio.Text = "+ Agegar Consultorio";
            this.BAgregarConsultorio.UseVisualStyleBackColor = false;
            this.BAgregarConsultorio.Click += new System.EventHandler(this.BAgregarConsultorio_Click);
            // 
            // BAsignarProfesional
            // 
            this.BAsignarProfesional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BAsignarProfesional.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAsignarProfesional.Location = new System.Drawing.Point(252, 206);
            this.BAsignarProfesional.Name = "BAsignarProfesional";
            this.BAsignarProfesional.Size = new System.Drawing.Size(166, 43);
            this.BAsignarProfesional.TabIndex = 12;
            this.BAsignarProfesional.Text = "+ Asignar Profesional";
            this.BAsignarProfesional.UseVisualStyleBackColor = false;
            this.BAsignarProfesional.Click += new System.EventHandler(this.BAsignarProfesional_Click_1);
            // 
            // GBAgregarConsultorio
            // 
            this.GBAgregarConsultorio.BackColor = System.Drawing.Color.LightGreen;
            this.GBAgregarConsultorio.Controls.Add(this.BCancelar);
            this.GBAgregarConsultorio.Controls.Add(this.BAgregar);
            this.GBAgregarConsultorio.Controls.Add(this.TBDescripcion);
            this.GBAgregarConsultorio.Controls.Add(this.TBNroConsultorio);
            this.GBAgregarConsultorio.Controls.Add(this.LConsultorio);
            this.GBAgregarConsultorio.Controls.Add(this.LDescripcionConsul);
            this.GBAgregarConsultorio.Location = new System.Drawing.Point(190, 282);
            this.GBAgregarConsultorio.Name = "GBAgregarConsultorio";
            this.GBAgregarConsultorio.Size = new System.Drawing.Size(389, 212);
            this.GBAgregarConsultorio.TabIndex = 13;
            this.GBAgregarConsultorio.TabStop = false;
            this.GBAgregarConsultorio.Visible = false;
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BCancelar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelar.Location = new System.Drawing.Point(166, 177);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(93, 29);
            this.BCancelar.TabIndex = 5;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = false;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BAgregar
            // 
            this.BAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BAgregar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregar.Location = new System.Drawing.Point(295, 177);
            this.BAgregar.Name = "BAgregar";
            this.BAgregar.Size = new System.Drawing.Size(88, 29);
            this.BAgregar.TabIndex = 4;
            this.BAgregar.Text = "Agergar";
            this.BAgregar.UseVisualStyleBackColor = false;
            this.BAgregar.Click += new System.EventHandler(this.BAgregar_Click);
            // 
            // TBDescripcion
            // 
            this.TBDescripcion.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDescripcion.Location = new System.Drawing.Point(220, 47);
            this.TBDescripcion.Multiline = true;
            this.TBDescripcion.Name = "TBDescripcion";
            this.TBDescripcion.Size = new System.Drawing.Size(153, 56);
            this.TBDescripcion.TabIndex = 3;
            // 
            // TBNroConsultorio
            // 
            this.TBNroConsultorio.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNroConsultorio.Location = new System.Drawing.Point(6, 63);
            this.TBNroConsultorio.Name = "TBNroConsultorio";
            this.TBNroConsultorio.Size = new System.Drawing.Size(123, 28);
            this.TBNroConsultorio.TabIndex = 2;
            // 
            // LConsultorio
            // 
            this.LConsultorio.AutoSize = true;
            this.LConsultorio.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LConsultorio.Location = new System.Drawing.Point(15, 19);
            this.LConsultorio.Name = "LConsultorio";
            this.LConsultorio.Size = new System.Drawing.Size(103, 18);
            this.LConsultorio.TabIndex = 1;
            this.LConsultorio.Text = "Nro Consultorio";
            // 
            // LDescripcionConsul
            // 
            this.LDescripcionConsul.AutoSize = true;
            this.LDescripcionConsul.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDescripcionConsul.Location = new System.Drawing.Point(260, 19);
            this.LDescripcionConsul.Name = "LDescripcionConsul";
            this.LDescripcionConsul.Size = new System.Drawing.Size(79, 18);
            this.LDescripcionConsul.TabIndex = 0;
            this.LDescripcionConsul.Text = "Descripcion";
            // 
            // GBAsignarProfesional
            // 
            this.GBAsignarProfesional.Controls.Add(this.label8);
            this.GBAsignarProfesional.Controls.Add(this.label7);
            this.GBAsignarProfesional.Controls.Add(this.label9);
            this.GBAsignarProfesional.Controls.Add(this.L);
            this.GBAsignarProfesional.Controls.Add(this.BAgregarProfesional_consultorio);
            this.GBAsignarProfesional.Controls.Add(this.BCancelarProfesional_consultorio);
            this.GBAsignarProfesional.Controls.Add(this.CMBProfesional);
            this.GBAsignarProfesional.Controls.Add(this.CMBConsultorio);
            this.GBAsignarProfesional.Controls.Add(this.DTPDesde);
            this.GBAsignarProfesional.Controls.Add(this.DTPHasta);
            this.GBAsignarProfesional.Location = new System.Drawing.Point(599, 282);
            this.GBAsignarProfesional.Name = "GBAsignarProfesional";
            this.GBAsignarProfesional.Size = new System.Drawing.Size(389, 212);
            this.GBAsignarProfesional.TabIndex = 14;
            this.GBAsignarProfesional.TabStop = false;
            this.GBAsignarProfesional.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(275, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 18);
            this.label8.TabIndex = 6;
            this.label8.Text = "Hasta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(253, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "Profesionales";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(35, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 18);
            this.label9.TabIndex = 7;
            this.label9.Text = "Desde";
            // 
            // L
            // 
            this.L.AutoSize = true;
            this.L.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L.Location = new System.Drawing.Point(13, 16);
            this.L.Name = "L";
            this.L.Size = new System.Drawing.Size(82, 18);
            this.L.TabIndex = 4;
            this.L.Text = "Consultorios";
            // 
            // BAgregarProfesional_consultorio
            // 
            this.BAgregarProfesional_consultorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BAgregarProfesional_consultorio.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregarProfesional_consultorio.Location = new System.Drawing.Point(295, 177);
            this.BAgregarProfesional_consultorio.Name = "BAgregarProfesional_consultorio";
            this.BAgregarProfesional_consultorio.Size = new System.Drawing.Size(88, 29);
            this.BAgregarProfesional_consultorio.TabIndex = 7;
            this.BAgregarProfesional_consultorio.Text = "Agergar";
            this.BAgregarProfesional_consultorio.UseVisualStyleBackColor = false;
            this.BAgregarProfesional_consultorio.Click += new System.EventHandler(this.BAgregarProfesional_consultorio_Click);
            // 
            // BCancelarProfesional_consultorio
            // 
            this.BCancelarProfesional_consultorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BCancelarProfesional_consultorio.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelarProfesional_consultorio.Location = new System.Drawing.Point(177, 177);
            this.BCancelarProfesional_consultorio.Name = "BCancelarProfesional_consultorio";
            this.BCancelarProfesional_consultorio.Size = new System.Drawing.Size(93, 29);
            this.BCancelarProfesional_consultorio.TabIndex = 6;
            this.BCancelarProfesional_consultorio.Text = "Cancelar";
            this.BCancelarProfesional_consultorio.UseVisualStyleBackColor = false;
            this.BCancelarProfesional_consultorio.Click += new System.EventHandler(this.BCancelarProfesional_consultorio_Click);
            // 
            // CMBProfesional
            // 
            this.CMBProfesional.FormattingEnabled = true;
            this.CMBProfesional.Location = new System.Drawing.Point(246, 53);
            this.CMBProfesional.Name = "CMBProfesional";
            this.CMBProfesional.Size = new System.Drawing.Size(121, 21);
            this.CMBProfesional.TabIndex = 3;
            // 
            // CMBConsultorio
            // 
            this.CMBConsultorio.FormattingEnabled = true;
            this.CMBConsultorio.Location = new System.Drawing.Point(6, 53);
            this.CMBConsultorio.Name = "CMBConsultorio";
            this.CMBConsultorio.Size = new System.Drawing.Size(121, 21);
            this.CMBConsultorio.TabIndex = 2;
            // 
            // DTPDesde
            // 
            this.DTPDesde.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDesde.Location = new System.Drawing.Point(6, 117);
            this.DTPDesde.Name = "DTPDesde";
            this.DTPDesde.Size = new System.Drawing.Size(127, 28);
            this.DTPDesde.TabIndex = 1;
            // 
            // DTPHasta
            // 
            this.DTPHasta.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPHasta.Location = new System.Drawing.Point(237, 117);
            this.DTPHasta.Name = "DTPHasta";
            this.DTPHasta.Size = new System.Drawing.Size(130, 28);
            this.DTPHasta.TabIndex = 0;
            // 
            // FormConsultorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 532);
            this.Controls.Add(this.GBAsignarProfesional);
            this.Controls.Add(this.GBAgregarConsultorio);
            this.Controls.Add(this.BAsignarProfesional);
            this.Controls.Add(this.BAgregarConsultorio);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DGWConsultorios_profesional);
            this.Controls.Add(this.panel1);
            this.Name = "FormConsultorio";
            this.Text = "FormConsultorio";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGWConsultorios_profesional)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.GBAgregarConsultorio.ResumeLayout(false);
            this.GBAgregarConsultorio.PerformLayout();
            this.GBAsignarProfesional.ResumeLayout(false);
            this.GBAsignarProfesional.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGWConsultorios_profesional;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LDescripcion;
        private System.Windows.Forms.Label LContador;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BAgregarConsultorio;
        private System.Windows.Forms.Button BAsignarProfesional;
        private System.Windows.Forms.GroupBox GBAgregarConsultorio;
        private System.Windows.Forms.GroupBox GBAsignarProfesional;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BAgregar;
        private System.Windows.Forms.TextBox TBDescripcion;
        private System.Windows.Forms.TextBox TBNroConsultorio;
        private System.Windows.Forms.Label LConsultorio;
        private System.Windows.Forms.Label LDescripcionConsul;
        private System.Windows.Forms.ComboBox CMBProfesional;
        private System.Windows.Forms.ComboBox CMBConsultorio;
        private System.Windows.Forms.DateTimePicker DTPDesde;
        private System.Windows.Forms.DateTimePicker DTPHasta;
        private System.Windows.Forms.Label L;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BAgregarProfesional_consultorio;
        private System.Windows.Forms.Button BCancelarProfesional_consultorio;
    }
}