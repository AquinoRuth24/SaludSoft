namespace SaludSoft
{
    partial class FormHistorial
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
            this.btVolver = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgHistorial = new System.Windows.Forms.DataGridView();
            this.colIdHistorial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiagnostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTratamiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVerHistorial = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lDni = new System.Windows.Forms.Label();
            this.btLupaBuscar = new System.Windows.Forms.Button();
            this.tbBuscarDni = new System.Windows.Forms.TextBox();
            this.pnlOverlay = new System.Windows.Forms.Panel();
            this.gbDetalle = new System.Windows.Forms.GroupBox();
            this.lvResumen = new System.Windows.Forms.ListView();
            this.Fecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Diagnóstico = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tratamiento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Observaciones = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbFechaValor = new System.Windows.Forms.Label();
            this.btCerrarDetalle = new System.Windows.Forms.Button();
            this.lbObsValor = new System.Windows.Forms.Label();
            this.lbTratValor = new System.Windows.Forms.Label();
            this.lbDiagValor = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAgregar = new System.Windows.Forms.Button();
            this.tbObserv = new System.Windows.Forms.TextBox();
            this.lObserv = new System.Windows.Forms.Label();
            this.tbTrat = new System.Windows.Forms.TextBox();
            this.lTrat = new System.Windows.Forms.Label();
            this.tbDiagnostico = new System.Windows.Forms.TextBox();
            this.lDiagnostico = new System.Windows.Forms.Label();
            this.lFecha = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lValorPaciente = new System.Windows.Forms.Label();
            this.lPaciente = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHistorial)).BeginInit();
            this.pnlOverlay.SuspendLayout();
            this.gbDetalle.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // btVolver
            // 
            this.btVolver.BackColor = System.Drawing.Color.White;
            this.btVolver.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVolver.Image = global::SaludSoft.Properties.Resources.angulo_izquierdo;
            this.btVolver.Location = new System.Drawing.Point(144, 17);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(48, 44);
            this.btVolver.TabIndex = 3;
            this.btVolver.UseVisualStyleBackColor = false;
            this.btVolver.Click += new System.EventHandler(this.btVolver_Click_1);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.btVolver);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1023, 74);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(464, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Historia Clìnica ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SaludSoft.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // dgHistorial
            // 
            this.dgHistorial.AllowUserToAddRows = false;
            this.dgHistorial.AllowUserToDeleteRows = false;
            this.dgHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdHistorial,
            this.colDni,
            this.colPaciente,
            this.colFecha,
            this.colDiagnostico,
            this.colTratamiento,
            this.colVerHistorial});
            this.dgHistorial.Location = new System.Drawing.Point(87, 149);
            this.dgHistorial.MultiSelect = false;
            this.dgHistorial.Name = "dgHistorial";
            this.dgHistorial.RowHeadersVisible = false;
            this.dgHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHistorial.Size = new System.Drawing.Size(779, 402);
            this.dgHistorial.TabIndex = 3;
            this.dgHistorial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgHistorial_CellContentClick);
            // 
            // colIdHistorial
            // 
            this.colIdHistorial.HeaderText = "Id_Historial";
            this.colIdHistorial.Name = "colIdHistorial";
            // 
            // colDni
            // 
            this.colDni.HeaderText = "DNI";
            this.colDni.Name = "colDni";
            // 
            // colPaciente
            // 
            this.colPaciente.HeaderText = "Paciente";
            this.colPaciente.Name = "colPaciente";
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Visible = false;
            // 
            // colDiagnostico
            // 
            this.colDiagnostico.HeaderText = "Diagnòstico";
            this.colDiagnostico.Name = "colDiagnostico";
            // 
            // colTratamiento
            // 
            this.colTratamiento.HeaderText = "Tratamiento";
            this.colTratamiento.Name = "colTratamiento";
            // 
            // colVerHistorial
            // 
            this.colVerHistorial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colVerHistorial.HeaderText = "Ver Historial";
            this.colVerHistorial.Name = "colVerHistorial";
            this.colVerHistorial.ReadOnly = true;
            this.colVerHistorial.UseColumnTextForButtonValue = true;
            this.colVerHistorial.Width = 69;
            // 
            // lDni
            // 
            this.lDni.AutoSize = true;
            this.lDni.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDni.Location = new System.Drawing.Point(197, 90);
            this.lDni.Name = "lDni";
            this.lDni.Size = new System.Drawing.Size(58, 23);
            this.lDni.TabIndex = 4;
            this.lDni.Text = "DNI: ";
            // 
            // btLupaBuscar
            // 
            this.btLupaBuscar.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLupaBuscar.Image = global::SaludSoft.Properties.Resources.busqueda;
            this.btLupaBuscar.Location = new System.Drawing.Point(528, 81);
            this.btLupaBuscar.Name = "btLupaBuscar";
            this.btLupaBuscar.Size = new System.Drawing.Size(59, 41);
            this.btLupaBuscar.TabIndex = 6;
            this.btLupaBuscar.UseVisualStyleBackColor = true;
            // 
            // tbBuscarDni
            // 
            this.tbBuscarDni.Location = new System.Drawing.Point(285, 94);
            this.tbBuscarDni.Name = "tbBuscarDni";
            this.tbBuscarDni.Size = new System.Drawing.Size(219, 20);
            this.tbBuscarDni.TabIndex = 7;
            // 
            // pnlOverlay
            // 
            this.pnlOverlay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOverlay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlOverlay.Controls.Add(this.gbDetalle);
            this.pnlOverlay.Location = new System.Drawing.Point(393, 167);
            this.pnlOverlay.Name = "pnlOverlay";
            this.pnlOverlay.Size = new System.Drawing.Size(473, 384);
            this.pnlOverlay.TabIndex = 8;
            this.pnlOverlay.Visible = false;
            // 
            // gbDetalle
            // 
            this.gbDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetalle.BackColor = System.Drawing.Color.Gainsboro;
            this.gbDetalle.Controls.Add(this.lvResumen);
            this.gbDetalle.Controls.Add(this.lbFechaValor);
            this.gbDetalle.Controls.Add(this.btCerrarDetalle);
            this.gbDetalle.Controls.Add(this.lbObsValor);
            this.gbDetalle.Controls.Add(this.lbTratValor);
            this.gbDetalle.Controls.Add(this.lbDiagValor);
            this.gbDetalle.Controls.Add(this.pnlBotones);
            this.gbDetalle.Controls.Add(this.tbObserv);
            this.gbDetalle.Controls.Add(this.lObserv);
            this.gbDetalle.Controls.Add(this.tbTrat);
            this.gbDetalle.Controls.Add(this.lTrat);
            this.gbDetalle.Controls.Add(this.tbDiagnostico);
            this.gbDetalle.Controls.Add(this.lDiagnostico);
            this.gbDetalle.Controls.Add(this.lFecha);
            this.gbDetalle.Controls.Add(this.dateTimePicker1);
            this.gbDetalle.Controls.Add(this.lValorPaciente);
            this.gbDetalle.Controls.Add(this.lPaciente);
            this.gbDetalle.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetalle.Location = new System.Drawing.Point(18, 15);
            this.gbDetalle.Name = "gbDetalle";
            this.gbDetalle.Size = new System.Drawing.Size(440, 352);
            this.gbDetalle.TabIndex = 0;
            this.gbDetalle.TabStop = false;
            this.gbDetalle.Text = "Detalle Historial";
            this.gbDetalle.Visible = false;
            // 
            // lvResumen
            // 
            this.lvResumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResumen.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Fecha,
            this.Diagnóstico,
            this.Tratamiento,
            this.Observaciones});
            this.lvResumen.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvResumen.FullRowSelect = true;
            this.lvResumen.GridLines = true;
            this.lvResumen.HideSelection = false;
            this.lvResumen.Location = new System.Drawing.Point(16, 216);
            this.lvResumen.Name = "lvResumen";
            this.lvResumen.ShowGroups = false;
            this.lvResumen.Size = new System.Drawing.Size(421, 85);
            this.lvResumen.TabIndex = 24;
            this.lvResumen.UseCompatibleStateImageBehavior = false;
            this.lvResumen.View = System.Windows.Forms.View.Details;
            // 
            // Fecha
            // 
            this.Fecha.Text = "Fecha";
            this.Fecha.Width = 120;
            // 
            // Diagnóstico
            // 
            this.Diagnóstico.Text = "Diagnóstico";
            this.Diagnóstico.Width = 220;
            // 
            // Tratamiento
            // 
            this.Tratamiento.Text = "Tratamiento";
            this.Tratamiento.Width = 180;
            // 
            // Observaciones
            // 
            this.Observaciones.Text = "Observaciones";
            this.Observaciones.Width = 180;
            // 
            // lbFechaValor
            // 
            this.lbFechaValor.AutoSize = true;
            this.lbFechaValor.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFechaValor.Location = new System.Drawing.Point(79, 68);
            this.lbFechaValor.Name = "lbFechaValor";
            this.lbFechaValor.Size = new System.Drawing.Size(0, 23);
            this.lbFechaValor.TabIndex = 23;
            this.lbFechaValor.Visible = false;
            // 
            // btCerrarDetalle
            // 
            this.btCerrarDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCerrarDetalle.Image = global::SaludSoft.Properties.Resources.circulo_marca_x;
            this.btCerrarDetalle.Location = new System.Drawing.Point(401, 0);
            this.btCerrarDetalle.Name = "btCerrarDetalle";
            this.btCerrarDetalle.Size = new System.Drawing.Size(31, 34);
            this.btCerrarDetalle.TabIndex = 22;
            this.btCerrarDetalle.UseVisualStyleBackColor = true;
            this.btCerrarDetalle.Click += new System.EventHandler(this.btCerrarDetalle_Click);
            // 
            // lbObsValor
            // 
            this.lbObsValor.AutoSize = true;
            this.lbObsValor.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbObsValor.Location = new System.Drawing.Point(151, 188);
            this.lbObsValor.Name = "lbObsValor";
            this.lbObsValor.Size = new System.Drawing.Size(0, 23);
            this.lbObsValor.TabIndex = 21;
            this.lbObsValor.Visible = false;
            // 
            // lbTratValor
            // 
            this.lbTratValor.AutoSize = true;
            this.lbTratValor.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTratValor.Location = new System.Drawing.Point(152, 145);
            this.lbTratValor.Name = "lbTratValor";
            this.lbTratValor.Size = new System.Drawing.Size(0, 23);
            this.lbTratValor.TabIndex = 20;
            this.lbTratValor.Visible = false;
            // 
            // lbDiagValor
            // 
            this.lbDiagValor.AutoSize = true;
            this.lbDiagValor.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDiagValor.Location = new System.Drawing.Point(152, 105);
            this.lbDiagValor.Name = "lbDiagValor";
            this.lbDiagValor.Size = new System.Drawing.Size(0, 23);
            this.lbDiagValor.TabIndex = 19;
            this.lbDiagValor.Visible = false;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btCancelar);
            this.pnlBotones.Controls.Add(this.btAgregar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(3, 260);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(434, 89);
            this.pnlBotones.TabIndex = 18;
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btCancelar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Location = new System.Drawing.Point(309, 33);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(94, 39);
            this.btCancelar.TabIndex = 1;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = false;
            // 
            // btAgregar
            // 
            this.btAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btAgregar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAgregar.Location = new System.Drawing.Point(189, 31);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(93, 43);
            this.btAgregar.TabIndex = 0;
            this.btAgregar.Text = "Agregar";
            this.btAgregar.UseVisualStyleBackColor = false;
            // 
            // tbObserv
            // 
            this.tbObserv.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbObserv.Location = new System.Drawing.Point(141, 185);
            this.tbObserv.Name = "tbObserv";
            this.tbObserv.Size = new System.Drawing.Size(133, 30);
            this.tbObserv.TabIndex = 17;
            // 
            // lObserv
            // 
            this.lObserv.AutoSize = true;
            this.lObserv.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lObserv.Location = new System.Drawing.Point(15, 194);
            this.lObserv.Name = "lObserv";
            this.lObserv.Size = new System.Drawing.Size(109, 19);
            this.lObserv.TabIndex = 16;
            this.lObserv.Text = "Observaciones: ";
            // 
            // tbTrat
            // 
            this.tbTrat.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTrat.Location = new System.Drawing.Point(141, 145);
            this.tbTrat.Name = "tbTrat";
            this.tbTrat.Size = new System.Drawing.Size(133, 30);
            this.tbTrat.TabIndex = 15;
            // 
            // lTrat
            // 
            this.lTrat.AutoSize = true;
            this.lTrat.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTrat.Location = new System.Drawing.Point(15, 153);
            this.lTrat.Name = "lTrat";
            this.lTrat.Size = new System.Drawing.Size(97, 19);
            this.lTrat.TabIndex = 14;
            this.lTrat.Text = "Tratamiento: ";
            // 
            // tbDiagnostico
            // 
            this.tbDiagnostico.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDiagnostico.Location = new System.Drawing.Point(141, 102);
            this.tbDiagnostico.Name = "tbDiagnostico";
            this.tbDiagnostico.ReadOnly = true;
            this.tbDiagnostico.Size = new System.Drawing.Size(133, 30);
            this.tbDiagnostico.TabIndex = 13;
            // 
            // lDiagnostico
            // 
            this.lDiagnostico.AutoSize = true;
            this.lDiagnostico.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDiagnostico.Location = new System.Drawing.Point(15, 117);
            this.lDiagnostico.Name = "lDiagnostico";
            this.lDiagnostico.Size = new System.Drawing.Size(92, 19);
            this.lDiagnostico.TabIndex = 12;
            this.lDiagnostico.Text = "Diagnóstico: ";
            // 
            // lFecha
            // 
            this.lFecha.AutoSize = true;
            this.lFecha.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFecha.Location = new System.Drawing.Point(15, 76);
            this.lFecha.Name = "lFecha";
            this.lFecha.Size = new System.Drawing.Size(58, 19);
            this.lFecha.TabIndex = 11;
            this.lFecha.Text = "Fecha: ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(79, 70);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(102, 26);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // lValorPaciente
            // 
            this.lValorPaciente.AutoSize = true;
            this.lValorPaciente.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lValorPaciente.Location = new System.Drawing.Point(94, 43);
            this.lValorPaciente.Name = "lValorPaciente";
            this.lValorPaciente.Size = new System.Drawing.Size(25, 19);
            this.lValorPaciente.TabIndex = 9;
            this.lValorPaciente.Text = "--";
            // 
            // lPaciente
            // 
            this.lPaciente.AutoSize = true;
            this.lPaciente.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPaciente.Location = new System.Drawing.Point(15, 43);
            this.lPaciente.Name = "lPaciente";
            this.lPaciente.Size = new System.Drawing.Size(73, 19);
            this.lPaciente.TabIndex = 8;
            this.lPaciente.Text = "Paciente: ";
            // 
            // FormHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1022, 563);
            this.Controls.Add(this.pnlOverlay);
            this.Controls.Add(this.tbBuscarDni);
            this.Controls.Add(this.btLupaBuscar);
            this.Controls.Add(this.lDni);
            this.Controls.Add(this.dgHistorial);
            this.Controls.Add(this.panel2);
            this.Name = "FormHistorial";
            this.Text = "FormHistorial";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgHistorial)).EndInit();
            this.pnlOverlay.ResumeLayout(false);
            this.gbDetalle.ResumeLayout(false);
            this.gbDetalle.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.DataGridView dgHistorial;
        private System.Windows.Forms.Label lDni;
        private System.Windows.Forms.Button btLupaBuscar;
        private System.Windows.Forms.TextBox tbBuscarDni;
        private System.Windows.Forms.Panel pnlOverlay;
        private System.Windows.Forms.GroupBox gbDetalle;
        private System.Windows.Forms.Label lPaciente;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lValorPaciente;
        private System.Windows.Forms.TextBox tbDiagnostico;
        private System.Windows.Forms.Label lDiagnostico;
        private System.Windows.Forms.Label lFecha;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.TextBox tbObserv;
        private System.Windows.Forms.Label lObserv;
        private System.Windows.Forms.TextBox tbTrat;
        private System.Windows.Forms.Label lTrat;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAgregar;
        private System.Windows.Forms.Label lbTratValor;
        private System.Windows.Forms.Label lbDiagValor;
        private System.Windows.Forms.Button btCerrarDetalle;
        private System.Windows.Forms.Label lbObsValor;
        private System.Windows.Forms.Label lbFechaValor;
        private System.Windows.Forms.ListView lvResumen;
        private System.Windows.Forms.ColumnHeader Fecha;
        private System.Windows.Forms.ColumnHeader Diagnóstico;
        private System.Windows.Forms.ColumnHeader Tratamiento;
        private System.Windows.Forms.ColumnHeader Observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiagnostico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTratamiento;
        private System.Windows.Forms.DataGridViewButtonColumn colVerHistorial;
    }
}