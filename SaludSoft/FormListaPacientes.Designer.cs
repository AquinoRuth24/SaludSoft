namespace SaludSoft
{
    partial class FormListaPacientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListaPacientes));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BVolver = new System.Windows.Forms.Button();
            this.LTexto = new System.Windows.Forms.Label();
            this.LabelGestionPaciente = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BCerrarSesion = new System.Windows.Forms.Button();
            this.BDoctoresFromTurnos = new System.Windows.Forms.Button();
            this.BTurnosFromTurnos = new System.Windows.Forms.Button();
            this.BPacientesFormTurno = new System.Windows.Forms.Button();
            this.BInicioFormTurno = new System.Windows.Forms.Button();
            this.PanelLogoPaciente = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.PMenu = new System.Windows.Forms.Panel();
            this.BDoctores = new System.Windows.Forms.Button();
            this.BCitasMedicas = new System.Windows.Forms.Button();
            this.BPacientes = new System.Windows.Forms.Button();
            this.BInicio = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvPacientes = new System.Windows.Forms.DataGridView();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.BBuscarPaciente = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.PanelLogoPaciente.SuspendLayout();
            this.panel3.SuspendLayout();
            this.PMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.BVolver);
            this.panel1.Controls.Add(this.LTexto);
            this.panel1.Controls.Add(this.LabelGestionPaciente);
            this.panel1.Location = new System.Drawing.Point(175, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 46);
            this.panel1.TabIndex = 4;
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
            this.BVolver.Click += new System.EventHandler(this.BVolver_Click);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(66)))));
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.BDoctoresFromTurnos);
            this.panel2.Controls.Add(this.BTurnosFromTurnos);
            this.panel2.Controls.Add(this.BPacientesFormTurno);
            this.panel2.Controls.Add(this.BInicioFormTurno);
            this.panel2.Location = new System.Drawing.Point(2, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(154, 416);
            this.panel2.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BCerrarSesion);
            this.panel4.Location = new System.Drawing.Point(0, 292);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(154, 124);
            this.panel4.TabIndex = 10;
            // 
            // BCerrarSesion
            // 
            this.BCerrarSesion.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCerrarSesion.Location = new System.Drawing.Point(13, 13);
            this.BCerrarSesion.Name = "BCerrarSesion";
            this.BCerrarSesion.Size = new System.Drawing.Size(108, 53);
            this.BCerrarSesion.TabIndex = 6;
            this.BCerrarSesion.Text = "Cerrar sesion";
            this.BCerrarSesion.UseVisualStyleBackColor = true;
            this.BCerrarSesion.Click += new System.EventHandler(this.BCerrarSesion_Click);
            // 
            // BDoctoresFromTurnos
            // 
            this.BDoctoresFromTurnos.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BDoctoresFromTurnos.Location = new System.Drawing.Point(27, 223);
            this.BDoctoresFromTurnos.Name = "BDoctoresFromTurnos";
            this.BDoctoresFromTurnos.Size = new System.Drawing.Size(92, 46);
            this.BDoctoresFromTurnos.TabIndex = 3;
            this.BDoctoresFromTurnos.Text = "Doctores";
            this.BDoctoresFromTurnos.UseVisualStyleBackColor = true;
            // 
            // BTurnosFromTurnos
            // 
            this.BTurnosFromTurnos.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTurnosFromTurnos.Location = new System.Drawing.Point(14, 159);
            this.BTurnosFromTurnos.Name = "BTurnosFromTurnos";
            this.BTurnosFromTurnos.Size = new System.Drawing.Size(107, 37);
            this.BTurnosFromTurnos.TabIndex = 4;
            this.BTurnosFromTurnos.Text = "Turnos";
            this.BTurnosFromTurnos.UseVisualStyleBackColor = true;
            // 
            // BPacientesFormTurno
            // 
            this.BPacientesFormTurno.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPacientesFormTurno.Location = new System.Drawing.Point(11, 89);
            this.BPacientesFormTurno.Name = "BPacientesFormTurno";
            this.BPacientesFormTurno.Size = new System.Drawing.Size(114, 40);
            this.BPacientesFormTurno.TabIndex = 5;
            this.BPacientesFormTurno.Text = "Pacientes";
            this.BPacientesFormTurno.UseVisualStyleBackColor = true;
            this.BPacientesFormTurno.Click += new System.EventHandler(this.BPacientesFormTurno_Click);
            // 
            // BInicioFormTurno
            // 
            this.BInicioFormTurno.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BInicioFormTurno.Location = new System.Drawing.Point(21, 19);
            this.BInicioFormTurno.Name = "BInicioFormTurno";
            this.BInicioFormTurno.Size = new System.Drawing.Size(92, 43);
            this.BInicioFormTurno.TabIndex = 2;
            this.BInicioFormTurno.Text = "Inicio";
            this.BInicioFormTurno.UseVisualStyleBackColor = true;
            this.BInicioFormTurno.Click += new System.EventHandler(this.BInicioFormTurno_Click);
            // 
            // PanelLogoPaciente
            // 
            this.PanelLogoPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(66)))));
            this.PanelLogoPaciente.Controls.Add(this.panel3);
            this.PanelLogoPaciente.Controls.Add(this.PMenu);
            this.PanelLogoPaciente.Controls.Add(this.pictureBox1);
            this.PanelLogoPaciente.Location = new System.Drawing.Point(2, 0);
            this.PanelLogoPaciente.Name = "PanelLogoPaciente";
            this.PanelLogoPaciente.Size = new System.Drawing.Size(154, 107);
            this.PanelLogoPaciente.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(66)))));
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Location = new System.Drawing.Point(0, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(154, 357);
            this.panel3.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(21, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 46);
            this.button1.TabIndex = 3;
            this.button1.Text = "Doctores";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(21, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 61);
            this.button2.TabIndex = 4;
            this.button2.Text = "Citas Medicas";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(11, 92);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 40);
            this.button3.TabIndex = 5;
            this.button3.Text = "Pacientes";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(21, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(92, 43);
            this.button4.TabIndex = 2;
            this.button4.Text = "Inicio";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // PMenu
            // 
            this.PMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(66)))));
            this.PMenu.Controls.Add(this.BDoctores);
            this.PMenu.Controls.Add(this.BCitasMedicas);
            this.PMenu.Controls.Add(this.BPacientes);
            this.PMenu.Controls.Add(this.BInicio);
            this.PMenu.Location = new System.Drawing.Point(3, 105);
            this.PMenu.Name = "PMenu";
            this.PMenu.Size = new System.Drawing.Size(154, 357);
            this.PMenu.TabIndex = 3;
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
            // BCitasMedicas
            // 
            this.BCitasMedicas.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCitasMedicas.Location = new System.Drawing.Point(21, 152);
            this.BCitasMedicas.Name = "BCitasMedicas";
            this.BCitasMedicas.Size = new System.Drawing.Size(92, 61);
            this.BCitasMedicas.TabIndex = 4;
            this.BCitasMedicas.Text = "Citas Medicas";
            this.BCitasMedicas.UseVisualStyleBackColor = true;
            // 
            // BPacientes
            // 
            this.BPacientes.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPacientes.Location = new System.Drawing.Point(11, 92);
            this.BPacientes.Name = "BPacientes";
            this.BPacientes.Size = new System.Drawing.Size(114, 40);
            this.BPacientes.TabIndex = 5;
            this.BPacientes.Text = "Pacientes";
            this.BPacientes.UseVisualStyleBackColor = true;
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
            // dgvPacientes
            // 
            this.dgvPacientes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacientes.Location = new System.Drawing.Point(175, 105);
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.Size = new System.Drawing.Size(800, 391);
            this.dgvPacientes.TabIndex = 7;
            this.dgvPacientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellContentClick);
            // 
            // TBBuscar
            // 
            this.TBBuscar.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBBuscar.Location = new System.Drawing.Point(274, 72);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(540, 26);
            this.TBBuscar.TabIndex = 8;
            this.TBBuscar.TextChanged += new System.EventHandler(this.TBBuscar_TextChanged);
            // 
            // BBuscarPaciente
            // 
            this.BBuscarPaciente.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscarPaciente.Location = new System.Drawing.Point(846, 72);
            this.BBuscarPaciente.Name = "BBuscarPaciente";
            this.BBuscarPaciente.Size = new System.Drawing.Size(81, 26);
            this.BBuscarPaciente.TabIndex = 9;
            this.BBuscarPaciente.Text = "Buscar";
            this.BBuscarPaciente.UseVisualStyleBackColor = true;
            this.BBuscarPaciente.Click += new System.EventHandler(this.BBuscarPaciente_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(198, 73);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 23);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // FormListaPacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 523);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.BBuscarPaciente);
            this.Controls.Add(this.TBBuscar);
            this.Controls.Add(this.dgvPacientes);
            this.Controls.Add(this.PanelLogoPaciente);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormListaPacientes";
            this.Text = "FormListaPacientes";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.PanelLogoPaciente.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.PMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LTexto;
        private System.Windows.Forms.Label LabelGestionPaciente;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BDoctoresFromTurnos;
        private System.Windows.Forms.Button BTurnosFromTurnos;
        private System.Windows.Forms.Button BPacientesFormTurno;
        private System.Windows.Forms.Button BInicioFormTurno;
        private System.Windows.Forms.Panel PanelLogoPaciente;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel PMenu;
        private System.Windows.Forms.Button BDoctores;
        private System.Windows.Forms.Button BCitasMedicas;
        private System.Windows.Forms.Button BPacientes;
        private System.Windows.Forms.Button BInicio;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvPacientes;
        private System.Windows.Forms.Button BVolver;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BCerrarSesion;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.Button BBuscarPaciente;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}