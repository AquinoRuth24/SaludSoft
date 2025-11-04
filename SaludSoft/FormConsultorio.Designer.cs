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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConsultorio));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BVolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DGWConsultorios_profesional = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LDescripcion = new System.Windows.Forms.Label();
            this.LTotalConsultorios = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.LConsultoriosDisponibles = new System.Windows.Forms.Label();
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
            this.GBAgregarConsultorio = new System.Windows.Forms.GroupBox();
            this.BCancelarConsultorio = new System.Windows.Forms.Button();
            this.BGuardarConsultorio = new System.Windows.Forms.Button();
            this.TBDescripcion = new System.Windows.Forms.TextBox();
            this.TBNroConsultorio = new System.Windows.Forms.TextBox();
            this.LConsultorio = new System.Windows.Forms.Label();
            this.LDescripcionConsul = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.LConsultoriosAsignados = new System.Windows.Forms.Label();
            this.BAgregarConsultorio = new System.Windows.Forms.Button();
            this.BAsignarProfesional = new System.Windows.Forms.Button();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BBuscar = new System.Windows.Forms.Button();
            this.BLimpiar = new System.Windows.Forms.Button();
            this.BGuardarDisponibilidad = new System.Windows.Forms.Button();
            this.BCancelarDisponibilidad = new System.Windows.Forms.Button();
            this.DPTHoraFin = new System.Windows.Forms.DateTimePicker();
            this.LHoraFin = new System.Windows.Forms.Label();
            this.LHoraInicio = new System.Windows.Forms.Label();
            this.DTPHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.LDia = new System.Windows.Forms.Label();
            this.LProfesionales = new System.Windows.Forms.Label();
            this.CBDiaSemana = new System.Windows.Forms.ComboBox();
            this.CMBProfesional_consultorio = new System.Windows.Forms.ComboBox();
            this.DTPHoraFin = new System.Windows.Forms.DateTimePicker();
            this.DPTHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.BCancearDisponibilidad = new System.Windows.Forms.Button();
            this.BGuardarDisponibe = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.CLBDiasSemana = new System.Windows.Forms.CheckedListBox();
            this.GBDisponibilidad = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGWConsultorios_profesional)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.GBAsignarProfesional.SuspendLayout();
            this.GBAgregarConsultorio.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.GBDisponibilidad.SuspendLayout();
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
            this.DGWConsultorios_profesional.Location = new System.Drawing.Point(-12, 253);
            this.DGWConsultorios_profesional.Name = "DGWConsultorios_profesional";
            this.DGWConsultorios_profesional.Size = new System.Drawing.Size(1044, 267);
            this.DGWConsultorios_profesional.TabIndex = 3;
            this.DGWConsultorios_profesional.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGWConsultorios_profesional_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.Controls.Add(this.LDescripcion);
            this.panel2.Controls.Add(this.LTotalConsultorios);
            this.panel2.Location = new System.Drawing.Point(26, 86);
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
            // LTotalConsultorios
            // 
            this.LTotalConsultorios.AutoSize = true;
            this.LTotalConsultorios.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTotalConsultorios.Location = new System.Drawing.Point(76, 13);
            this.LTotalConsultorios.Name = "LTotalConsultorios";
            this.LTotalConsultorios.Size = new System.Drawing.Size(29, 32);
            this.LTotalConsultorios.TabIndex = 0;
            this.LTotalConsultorios.Text = "0";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGreen;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.LConsultoriosDisponibles);
            this.panel3.Location = new System.Drawing.Point(236, 86);
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
            // LConsultoriosDisponibles
            // 
            this.LConsultoriosDisponibles.AutoSize = true;
            this.LConsultoriosDisponibles.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LConsultoriosDisponibles.Location = new System.Drawing.Point(84, 13);
            this.LConsultoriosDisponibles.Name = "LConsultoriosDisponibles";
            this.LConsultoriosDisponibles.Size = new System.Drawing.Size(29, 32);
            this.LConsultoriosDisponibles.TabIndex = 0;
            this.LConsultoriosDisponibles.Text = "0";
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
            this.GBAsignarProfesional.Location = new System.Drawing.Point(656, 205);
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
            this.label7.Location = new System.Drawing.Point(239, 19);
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
            this.BAgregarProfesional_consultorio.Text = "Agregar";
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
            this.CMBProfesional.Location = new System.Drawing.Point(222, 53);
            this.CMBProfesional.Name = "CMBProfesional";
            this.CMBProfesional.Size = new System.Drawing.Size(161, 21);
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
            // GBAgregarConsultorio
            // 
            this.GBAgregarConsultorio.BackColor = System.Drawing.Color.LightGreen;
            this.GBAgregarConsultorio.Controls.Add(this.BCancelarConsultorio);
            this.GBAgregarConsultorio.Controls.Add(this.BGuardarConsultorio);
            this.GBAgregarConsultorio.Controls.Add(this.TBDescripcion);
            this.GBAgregarConsultorio.Controls.Add(this.TBNroConsultorio);
            this.GBAgregarConsultorio.Controls.Add(this.LConsultorio);
            this.GBAgregarConsultorio.Controls.Add(this.LDescripcionConsul);
            this.GBAgregarConsultorio.Location = new System.Drawing.Point(1, 265);
            this.GBAgregarConsultorio.Name = "GBAgregarConsultorio";
            this.GBAgregarConsultorio.Size = new System.Drawing.Size(389, 212);
            this.GBAgregarConsultorio.TabIndex = 13;
            this.GBAgregarConsultorio.TabStop = false;
            this.GBAgregarConsultorio.Visible = false;
            // 
            // BCancelarConsultorio
            // 
            this.BCancelarConsultorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BCancelarConsultorio.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelarConsultorio.Location = new System.Drawing.Point(166, 177);
            this.BCancelarConsultorio.Name = "BCancelarConsultorio";
            this.BCancelarConsultorio.Size = new System.Drawing.Size(93, 29);
            this.BCancelarConsultorio.TabIndex = 5;
            this.BCancelarConsultorio.Text = "Cancelar";
            this.BCancelarConsultorio.UseVisualStyleBackColor = false;
            this.BCancelarConsultorio.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BGuardarConsultorio
            // 
            this.BGuardarConsultorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BGuardarConsultorio.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardarConsultorio.Location = new System.Drawing.Point(295, 177);
            this.BGuardarConsultorio.Name = "BGuardarConsultorio";
            this.BGuardarConsultorio.Size = new System.Drawing.Size(88, 29);
            this.BGuardarConsultorio.TabIndex = 4;
            this.BGuardarConsultorio.Text = "Guardar";
            this.BGuardarConsultorio.UseVisualStyleBackColor = false;
            this.BGuardarConsultorio.Click += new System.EventHandler(this.BGuardarConsultorio_Click);
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
            this.TBNroConsultorio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNroConsultorio_KeyPress);
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
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGreen;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.LConsultoriosAsignados);
            this.panel4.Location = new System.Drawing.Point(453, 86);
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
            // LConsultoriosAsignados
            // 
            this.LConsultoriosAsignados.AutoSize = true;
            this.LConsultoriosAsignados.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LConsultoriosAsignados.Location = new System.Drawing.Point(88, 13);
            this.LConsultoriosAsignados.Name = "LConsultoriosAsignados";
            this.LConsultoriosAsignados.Size = new System.Drawing.Size(29, 32);
            this.LConsultoriosAsignados.TabIndex = 0;
            this.LConsultoriosAsignados.Text = "0";
            // 
            // BAgregarConsultorio
            // 
            this.BAgregarConsultorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BAgregarConsultorio.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregarConsultorio.ForeColor = System.Drawing.Color.Black;
            this.BAgregarConsultorio.Location = new System.Drawing.Point(1, 187);
            this.BAgregarConsultorio.Name = "BAgregarConsultorio";
            this.BAgregarConsultorio.Size = new System.Drawing.Size(190, 43);
            this.BAgregarConsultorio.TabIndex = 11;
            this.BAgregarConsultorio.Text = "+ Agregar Consultorio";
            this.BAgregarConsultorio.UseVisualStyleBackColor = false;
            this.BAgregarConsultorio.Click += new System.EventHandler(this.BAgregarConsultorio_Click);
            // 
            // BAsignarProfesional
            // 
            this.BAsignarProfesional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BAsignarProfesional.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAsignarProfesional.Location = new System.Drawing.Point(217, 187);
            this.BAsignarProfesional.Name = "BAsignarProfesional";
            this.BAsignarProfesional.Size = new System.Drawing.Size(166, 43);
            this.BAsignarProfesional.TabIndex = 12;
            this.BAsignarProfesional.Text = "+ Asignar Profesional";
            this.BAsignarProfesional.UseVisualStyleBackColor = false;
            this.BAsignarProfesional.Click += new System.EventHandler(this.BAsignarProfesional_Click_1);
            // 
            // TBBuscar
            // 
            this.TBBuscar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBBuscar.Location = new System.Drawing.Point(756, 119);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(276, 28);
            this.TBBuscar.TabIndex = 15;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(658, 124);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 23);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // BBuscar
            // 
            this.BBuscar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscar.Location = new System.Drawing.Point(804, 171);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(77, 28);
            this.BBuscar.TabIndex = 18;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = true;
            this.BBuscar.Click += new System.EventHandler(this.BBuscar_Click);
            // 
            // BLimpiar
            // 
            this.BLimpiar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiar.Location = new System.Drawing.Point(955, 171);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.Size = new System.Drawing.Size(77, 28);
            this.BLimpiar.TabIndex = 19;
            this.BLimpiar.Text = "Limpiar";
            this.BLimpiar.UseVisualStyleBackColor = true;
            this.BLimpiar.Click += new System.EventHandler(this.BLimpiar_Click);
            // 
            // BGuardarDisponibilidad
            // 
            this.BGuardarDisponibilidad.Location = new System.Drawing.Point(0, 0);
            this.BGuardarDisponibilidad.Name = "BGuardarDisponibilidad";
            this.BGuardarDisponibilidad.Size = new System.Drawing.Size(75, 23);
            this.BGuardarDisponibilidad.TabIndex = 0;
            // 
            // BCancelarDisponibilidad
            // 
            this.BCancelarDisponibilidad.Location = new System.Drawing.Point(0, 0);
            this.BCancelarDisponibilidad.Name = "BCancelarDisponibilidad";
            this.BCancelarDisponibilidad.Size = new System.Drawing.Size(75, 23);
            this.BCancelarDisponibilidad.TabIndex = 0;
            // 
            // DPTHoraFin
            // 
            this.DPTHoraFin.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DPTHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DPTHoraFin.Location = new System.Drawing.Point(127, 96);
            this.DPTHoraFin.Name = "DPTHoraFin";
            this.DPTHoraFin.ShowUpDown = true;
            this.DPTHoraFin.Size = new System.Drawing.Size(102, 28);
            this.DPTHoraFin.TabIndex = 27;
            // 
            // LHoraFin
            // 
            this.LHoraFin.AutoSize = true;
            this.LHoraFin.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LHoraFin.Location = new System.Drawing.Point(10, 96);
            this.LHoraFin.Name = "LHoraFin";
            this.LHoraFin.Size = new System.Drawing.Size(74, 23);
            this.LHoraFin.TabIndex = 26;
            this.LHoraFin.Text = "Hora Fin";
            // 
            // LHoraInicio
            // 
            this.LHoraInicio.AutoSize = true;
            this.LHoraInicio.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LHoraInicio.Location = new System.Drawing.Point(10, 58);
            this.LHoraInicio.Name = "LHoraInicio";
            this.LHoraInicio.Size = new System.Drawing.Size(94, 23);
            this.LHoraInicio.TabIndex = 25;
            this.LHoraInicio.Text = "Hora Inicio";
            // 
            // DTPHoraInicio
            // 
            this.DTPHoraInicio.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTPHoraInicio.Location = new System.Drawing.Point(124, 53);
            this.DTPHoraInicio.Name = "DTPHoraInicio";
            this.DTPHoraInicio.ShowUpDown = true;
            this.DTPHoraInicio.Size = new System.Drawing.Size(105, 28);
            this.DTPHoraInicio.TabIndex = 24;
            // 
            // LDia
            // 
            this.LDia.AutoSize = true;
            this.LDia.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDia.Location = new System.Drawing.Point(259, 50);
            this.LDia.Name = "LDia";
            this.LDia.Size = new System.Drawing.Size(146, 23);
            this.LDia.TabIndex = 23;
            this.LDia.Text = "Dia De La Semana:";
            // 
            // LProfesionales
            // 
            this.LProfesionales.AutoSize = true;
            this.LProfesionales.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProfesionales.Location = new System.Drawing.Point(252, 7);
            this.LProfesionales.Name = "LProfesionales";
            this.LProfesionales.Size = new System.Drawing.Size(106, 23);
            this.LProfesionales.TabIndex = 22;
            this.LProfesionales.Text = "Profesionales";
            // 
            // CBDiaSemana
            // 
            this.CBDiaSemana.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBDiaSemana.FormattingEnabled = true;
            this.CBDiaSemana.Location = new System.Drawing.Point(251, 96);
            this.CBDiaSemana.Name = "CBDiaSemana";
            this.CBDiaSemana.Size = new System.Drawing.Size(160, 28);
            this.CBDiaSemana.TabIndex = 17;
            // 
            // CMBProfesional_consultorio
            // 
            this.CMBProfesional_consultorio.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMBProfesional_consultorio.FormattingEnabled = true;
            this.CMBProfesional_consultorio.Location = new System.Drawing.Point(6, 7);
            this.CMBProfesional_consultorio.Name = "CMBProfesional_consultorio";
            this.CMBProfesional_consultorio.Size = new System.Drawing.Size(237, 28);
            this.CMBProfesional_consultorio.TabIndex = 1;
            // 
            // DTPHoraFin
            // 
            this.DTPHoraFin.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTPHoraFin.Location = new System.Drawing.Point(143, 134);
            this.DTPHoraFin.Name = "DTPHoraFin";
            this.DTPHoraFin.Size = new System.Drawing.Size(102, 28);
            this.DTPHoraFin.TabIndex = 3;
            // 
            // DPTHoraInicio
            // 
            this.DPTHoraInicio.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DPTHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DPTHoraInicio.Location = new System.Drawing.Point(6, 134);
            this.DPTHoraInicio.Name = "DPTHoraInicio";
            this.DPTHoraInicio.Size = new System.Drawing.Size(102, 28);
            this.DPTHoraInicio.TabIndex = 2;
            // 
            // BCancearDisponibilidad
            // 
            this.BCancearDisponibilidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BCancearDisponibilidad.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancearDisponibilidad.Location = new System.Drawing.Point(199, 177);
            this.BCancearDisponibilidad.Name = "BCancearDisponibilidad";
            this.BCancearDisponibilidad.Size = new System.Drawing.Size(93, 29);
            this.BCancearDisponibilidad.TabIndex = 6;
            this.BCancearDisponibilidad.Text = "Cancelar";
            this.BCancearDisponibilidad.UseVisualStyleBackColor = false;
            this.BCancearDisponibilidad.Click += new System.EventHandler(this.BCancelarDisponibilidad_Click);
            // 
            // BGuardarDisponibe
            // 
            this.BGuardarDisponibe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BGuardarDisponibe.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardarDisponibe.Location = new System.Drawing.Point(310, 177);
            this.BGuardarDisponibe.Name = "BGuardarDisponibe";
            this.BGuardarDisponibe.Size = new System.Drawing.Size(88, 29);
            this.BGuardarDisponibe.TabIndex = 7;
            this.BGuardarDisponibe.Text = "Guardar";
            this.BGuardarDisponibe.UseVisualStyleBackColor = false;
            this.BGuardarDisponibe.Click += new System.EventHandler(this.BGuardarDisponibilidad_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(54, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Dia De la Semana";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Hora Inicio";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(159, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 18);
            this.label10.TabIndex = 11;
            this.label10.Text = "Hora Fin";
            // 
            // CLBDiasSemana
            // 
            this.CLBDiasSemana.CheckOnClick = true;
            this.CLBDiasSemana.FormattingEnabled = true;
            this.CLBDiasSemana.Location = new System.Drawing.Point(235, 63);
            this.CLBDiasSemana.Name = "CLBDiasSemana";
            this.CLBDiasSemana.Size = new System.Drawing.Size(120, 19);
            this.CLBDiasSemana.TabIndex = 12;
            // 
            // GBDisponibilidad
            // 
            this.GBDisponibilidad.Controls.Add(this.CLBDiasSemana);
            this.GBDisponibilidad.Controls.Add(this.label10);
            this.GBDisponibilidad.Controls.Add(this.label6);
            this.GBDisponibilidad.Controls.Add(this.label5);
            this.GBDisponibilidad.Controls.Add(this.BGuardarDisponibe);
            this.GBDisponibilidad.Controls.Add(this.BCancearDisponibilidad);
            this.GBDisponibilidad.Controls.Add(this.DPTHoraInicio);
            this.GBDisponibilidad.Controls.Add(this.DTPHoraFin);
            this.GBDisponibilidad.Location = new System.Drawing.Point(396, 265);
            this.GBDisponibilidad.Name = "GBDisponibilidad";
            this.GBDisponibilidad.Size = new System.Drawing.Size(404, 212);
            this.GBDisponibilidad.TabIndex = 22;
            this.GBDisponibilidad.TabStop = false;
            this.GBDisponibilidad.Visible = false;
            // 
            // FormConsultorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 532);
            this.Controls.Add(this.GBDisponibilidad);
            this.Controls.Add(this.GBAgregarConsultorio);
            this.Controls.Add(this.GBAsignarProfesional);
            this.Controls.Add(this.BLimpiar);
            this.Controls.Add(this.BBuscar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.TBBuscar);
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
            this.GBAsignarProfesional.ResumeLayout(false);
            this.GBAsignarProfesional.PerformLayout();
            this.GBAgregarConsultorio.ResumeLayout(false);
            this.GBAgregarConsultorio.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.GBDisponibilidad.ResumeLayout(false);
            this.GBDisponibilidad.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGWConsultorios_profesional;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LDescripcion;
        private System.Windows.Forms.Label LTotalConsultorios;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LConsultoriosDisponibles;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LConsultoriosAsignados;
        private System.Windows.Forms.Button BAgregarConsultorio;
        private System.Windows.Forms.Button BAsignarProfesional;
        private System.Windows.Forms.GroupBox GBAgregarConsultorio;
        private System.Windows.Forms.GroupBox GBAsignarProfesional;
        private System.Windows.Forms.Button BCancelarConsultorio;
        private System.Windows.Forms.Button BGuardarConsultorio;
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
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.Button BLimpiar;
        private System.Windows.Forms.ComboBox CMBProfesional_consultorio;
        private System.Windows.Forms.ComboBox CBDiaSemana;
        private System.Windows.Forms.Label LProfesionales;
        private System.Windows.Forms.Label LDia;
        private System.Windows.Forms.DateTimePicker DTPHoraInicio;
        private System.Windows.Forms.Label LHoraInicio;
        private System.Windows.Forms.Label LHoraFin;
        private System.Windows.Forms.DateTimePicker DPTHoraFin;
        private System.Windows.Forms.Button BCancelarDisponibilidad;
        private System.Windows.Forms.Button BGuardarDisponibilidad;
        private System.Windows.Forms.DateTimePicker DTPHoraFin;
        private System.Windows.Forms.DateTimePicker DPTHoraInicio;
        private System.Windows.Forms.Button BCancearDisponibilidad;
        private System.Windows.Forms.Button BGuardarDisponibe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox CLBDiasSemana;
        private System.Windows.Forms.GroupBox GBDisponibilidad;
    }
}