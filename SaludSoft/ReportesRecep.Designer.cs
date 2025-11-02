namespace SaludSoft
{
    partial class ReportesRecep
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lReportesMes = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lFechaPeriodo = new System.Windows.Forms.Label();
            this.dtpPeriodo = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbValor = new System.Windows.Forms.Label();
            this.lbTituloConfirmado = new System.Windows.Forms.Label();
            this.pbTurnosConfirmados = new System.Windows.Forms.ProgressBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbValorTP = new System.Windows.Forms.Label();
            this.lbTurnosPendientes = new System.Windows.Forms.Label();
            this.pbTP = new System.Windows.Forms.ProgressBar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbValorTC = new System.Windows.Forms.Label();
            this.lbTurnosCancelados = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.gbDetalle = new System.Windows.Forms.GroupBox();
            this.chPieEstados = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlKpis = new System.Windows.Forms.TableLayoutPanel();
            this.gbTopMedicos = new System.Windows.Forms.GroupBox();
            this.dgvRankingMedicos = new System.Windows.Forms.DataGridView();
            this.colPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEspec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConsultas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPorcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chTopMedicos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lFechaHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btActualizar = new System.Windows.Forms.Button();
            this.panelPacientes = new System.Windows.Forms.Panel();
            this.panelDisponibilidad = new System.Windows.Forms.Panel();
            this.lbTituloPacientes = new System.Windows.Forms.Label();
            this.lbValorPacientes = new System.Windows.Forms.Label();
            this.lbTituloDisponibilidad = new System.Windows.Forms.Label();
            this.lbValorDisponibilidad = new System.Windows.Forms.Label();
            this.pbPacientes = new System.Windows.Forms.ProgressBar();
            this.pbDisponibilidad = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gbDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chPieEstados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.tlKpis.SuspendLayout();
            this.gbTopMedicos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankingMedicos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chTopMedicos)).BeginInit();
            this.panelPacientes.SuspendLayout();
            this.panelDisponibilidad.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.btnVolver);
            this.panel1.Controls.Add(this.lReportesMes);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 62);
            this.panel1.TabIndex = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVolver.BackgroundImage = global::SaludSoft.Properties.Resources.angulo_izquierdo;
            this.btnVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVolver.Location = new System.Drawing.Point(130, 19);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(44, 29);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lReportesMes
            // 
            this.lReportesMes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lReportesMes.AutoSize = true;
            this.lReportesMes.BackColor = System.Drawing.Color.White;
            this.lReportesMes.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lReportesMes.ForeColor = System.Drawing.Color.Green;
            this.lReportesMes.Location = new System.Drawing.Point(380, 19);
            this.lReportesMes.Name = "lReportesMes";
            this.lReportesMes.Size = new System.Drawing.Size(179, 29);
            this.lReportesMes.TabIndex = 1;
            this.lReportesMes.Text = "Reporte mensual";
            this.lReportesMes.Click += new System.EventHandler(this.lReportesMes_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SaludSoft.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lFechaPeriodo
            // 
            this.lFechaPeriodo.AutoSize = true;
            this.lFechaPeriodo.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFechaPeriodo.Location = new System.Drawing.Point(13, 74);
            this.lFechaPeriodo.Name = "lFechaPeriodo";
            this.lFechaPeriodo.Size = new System.Drawing.Size(123, 23);
            this.lFechaPeriodo.TabIndex = 1;
            this.lFechaPeriodo.Text = "Fecha Desde: ";
            // 
            // dtpPeriodo
            // 
            this.dtpPeriodo.CustomFormat = "dd/MM/yyyy";
            this.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodo.Location = new System.Drawing.Point(140, 75);
            this.dtpPeriodo.Name = "dtpPeriodo";
            this.dtpPeriodo.ShowUpDown = true;
            this.dtpPeriodo.Size = new System.Drawing.Size(137, 20);
            this.dtpPeriodo.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbValor);
            this.panel2.Controls.Add(this.lbTituloConfirmado);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(169, 73);
            this.panel2.TabIndex = 4;
            // 
            // lbValor
            // 
            this.lbValor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbValor.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValor.ForeColor = System.Drawing.Color.Green;
            this.lbValor.Location = new System.Drawing.Point(0, 33);
            this.lbValor.Name = "lbValor";
            this.lbValor.Size = new System.Drawing.Size(167, 21);
            this.lbValor.TabIndex = 1;
            this.lbValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTituloConfirmado
            // 
            this.lbTituloConfirmado.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTituloConfirmado.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTituloConfirmado.ForeColor = System.Drawing.Color.Green;
            this.lbTituloConfirmado.Location = new System.Drawing.Point(0, 0);
            this.lbTituloConfirmado.Name = "lbTituloConfirmado";
            this.lbTituloConfirmado.Size = new System.Drawing.Size(167, 33);
            this.lbTituloConfirmado.TabIndex = 0;
            this.lbTituloConfirmado.Text = "Turnos Confirmados";
            this.lbTituloConfirmado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbTurnosConfirmados
            // 
            this.pbTurnosConfirmados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbTurnosConfirmados.Location = new System.Drawing.Point(3, 82);
            this.pbTurnosConfirmados.MarqueeAnimationSpeed = 0;
            this.pbTurnosConfirmados.Name = "pbTurnosConfirmados";
            this.pbTurnosConfirmados.Size = new System.Drawing.Size(169, 28);
            this.pbTurnosConfirmados.Step = 1;
            this.pbTurnosConfirmados.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbTurnosConfirmados.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbValorTP);
            this.panel3.Controls.Add(this.lbTurnosPendientes);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(178, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(165, 73);
            this.panel3.TabIndex = 5;
            // 
            // lbValorTP
            // 
            this.lbValorTP.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbValorTP.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValorTP.ForeColor = System.Drawing.Color.Yellow;
            this.lbValorTP.Location = new System.Drawing.Point(0, 33);
            this.lbValorTP.Name = "lbValorTP";
            this.lbValorTP.Size = new System.Drawing.Size(163, 21);
            this.lbValorTP.TabIndex = 1;
            this.lbValorTP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTurnosPendientes
            // 
            this.lbTurnosPendientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTurnosPendientes.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTurnosPendientes.ForeColor = System.Drawing.Color.Yellow;
            this.lbTurnosPendientes.Location = new System.Drawing.Point(0, 0);
            this.lbTurnosPendientes.Name = "lbTurnosPendientes";
            this.lbTurnosPendientes.Size = new System.Drawing.Size(163, 33);
            this.lbTurnosPendientes.TabIndex = 0;
            this.lbTurnosPendientes.Text = "Turnos Pendientes";
            this.lbTurnosPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbTP
            // 
            this.pbTP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbTP.Location = new System.Drawing.Point(178, 82);
            this.pbTP.MarqueeAnimationSpeed = 0;
            this.pbTP.Name = "pbTP";
            this.pbTP.Size = new System.Drawing.Size(165, 28);
            this.pbTP.Step = 1;
            this.pbTP.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbTP.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lbValorTC);
            this.panel4.Controls.Add(this.lbTurnosCancelados);
            this.panel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(349, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(154, 73);
            this.panel4.TabIndex = 6;
            // 
            // lbValorTC
            // 
            this.lbValorTC.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbValorTC.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValorTC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lbValorTC.Location = new System.Drawing.Point(0, 33);
            this.lbValorTC.Name = "lbValorTC";
            this.lbValorTC.Size = new System.Drawing.Size(152, 21);
            this.lbValorTC.TabIndex = 1;
            this.lbValorTC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTurnosCancelados
            // 
            this.lbTurnosCancelados.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTurnosCancelados.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTurnosCancelados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lbTurnosCancelados.Location = new System.Drawing.Point(0, 0);
            this.lbTurnosCancelados.Name = "lbTurnosCancelados";
            this.lbTurnosCancelados.Size = new System.Drawing.Size(152, 33);
            this.lbTurnosCancelados.TabIndex = 0;
            this.lbTurnosCancelados.Text = "Turnos Cancelados";
            this.lbTurnosCancelados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(349, 82);
            this.progressBar1.MarqueeAnimationSpeed = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(154, 28);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            // 
            // gbDetalle
            // 
            this.gbDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetalle.BackColor = System.Drawing.Color.LightGreen;
            this.gbDetalle.Controls.Add(this.chPieEstados);
            this.gbDetalle.Controls.Add(this.dgvDetalle);
            this.gbDetalle.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetalle.ForeColor = System.Drawing.Color.Green;
            this.gbDetalle.Location = new System.Drawing.Point(0, 0);
            this.gbDetalle.Name = "gbDetalle";
            this.gbDetalle.Size = new System.Drawing.Size(870, 239);
            this.gbDetalle.TabIndex = 7;
            this.gbDetalle.TabStop = false;
            this.gbDetalle.Text = "Detalle de Turnos Confirmados/Pendientes/Cancelados";
            this.gbDetalle.Visible = false;
            // 
            // chPieEstados
            // 
            this.chPieEstados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chPieEstados.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea13.BackColor = System.Drawing.Color.White;
            chartArea13.BorderWidth = 0;
            chartArea13.Name = "ChartArea1";
            this.chPieEstados.ChartAreas.Add(chartArea13);
            legend13.Alignment = System.Drawing.StringAlignment.Center;
            legend13.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend13.Name = "Legend1";
            this.chPieEstados.Legends.Add(legend13);
            this.chPieEstados.Location = new System.Drawing.Point(653, 44);
            this.chPieEstados.Name = "chPieEstados";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series13.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series13.IsValueShownAsLabel = true;
            series13.Legend = "Legend1";
            series13.Name = "Estados";
            this.chPieEstados.Series.Add(series13);
            this.chPieEstados.Size = new System.Drawing.Size(213, 150);
            this.chPieEstados.TabIndex = 1;
            this.chPieEstados.Text = "chart1";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToResizeColumns = false;
            this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPaciente,
            this.colProfesional,
            this.colEspecialidad,
            this.colFechaHora});
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.Location = new System.Drawing.Point(27, 29);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(605, 165);
            this.dgvDetalle.TabIndex = 0;
            // 
            // colPaciente
            // 
            this.colPaciente.HeaderText = "Paciente";
            this.colPaciente.Name = "colPaciente";
            this.colPaciente.ReadOnly = true;
            // 
            // colProfesional
            // 
            this.colProfesional.HeaderText = "Profesional";
            this.colProfesional.Name = "colProfesional";
            this.colProfesional.ReadOnly = true;
            // 
            // colEspecialidad
            // 
            this.colEspecialidad.HeaderText = "Especialidad";
            this.colEspecialidad.Name = "colEspecialidad";
            this.colEspecialidad.ReadOnly = true;
            // 
            // colFechaHora
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Format = "g";
            dataGridViewCellStyle13.NullValue = null;
            this.colFechaHora.DefaultCellStyle = dataGridViewCellStyle13;
            this.colFechaHora.HeaderText = "Fecha/Hora";
            this.colFechaHora.Name = "colFechaHora";
            this.colFechaHora.ReadOnly = true;
            // 
            // tlKpis
            // 
            this.tlKpis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlKpis.ColumnCount = 5;
            this.tlKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.63918F));
            this.tlKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.81443F));
            this.tlKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.54639F));
            this.tlKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tlKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.tlKpis.Controls.Add(this.progressBar1, 2, 1);
            this.tlKpis.Controls.Add(this.pbTP, 1, 1);
            this.tlKpis.Controls.Add(this.panel4, 2, 0);
            this.tlKpis.Controls.Add(this.panel2, 0, 0);
            this.tlKpis.Controls.Add(this.pbTurnosConfirmados, 0, 1);
            this.tlKpis.Controls.Add(this.panel3, 1, 0);
            this.tlKpis.Controls.Add(this.panelPacientes, 3, 0);
            this.tlKpis.Controls.Add(this.panelDisponibilidad, 4, 0);
            this.tlKpis.Controls.Add(this.pbPacientes, 3, 1);
            this.tlKpis.Controls.Add(this.pbDisponibilidad, 4, 1);
            this.tlKpis.Location = new System.Drawing.Point(13, 113);
            this.tlKpis.Name = "tlKpis";
            this.tlKpis.RowCount = 2;
            this.tlKpis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.91151F));
            this.tlKpis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0885F));
            this.tlKpis.Size = new System.Drawing.Size(871, 113);
            this.tlKpis.TabIndex = 8;
            // 
            // gbTopMedicos
            // 
            this.gbTopMedicos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTopMedicos.BackColor = System.Drawing.Color.PaleGreen;
            this.gbTopMedicos.Controls.Add(this.gbDetalle);
            this.gbTopMedicos.Controls.Add(this.dgvRankingMedicos);
            this.gbTopMedicos.Controls.Add(this.chTopMedicos);
            this.gbTopMedicos.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTopMedicos.ForeColor = System.Drawing.Color.Green;
            this.gbTopMedicos.Location = new System.Drawing.Point(13, 232);
            this.gbTopMedicos.Name = "gbTopMedicos";
            this.gbTopMedicos.Size = new System.Drawing.Size(871, 236);
            this.gbTopMedicos.TabIndex = 9;
            this.gbTopMedicos.TabStop = false;
            this.gbTopMedicos.Text = "Médicos con Más Consultas Realizadas este Mes";
            // 
            // dgvRankingMedicos
            // 
            this.dgvRankingMedicos.AllowUserToAddRows = false;
            this.dgvRankingMedicos.AllowUserToDeleteRows = false;
            this.dgvRankingMedicos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRankingMedicos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRankingMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRankingMedicos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPos,
            this.colMedico,
            this.colEspec,
            this.colConsultas,
            this.colPorcentaje});
            this.dgvRankingMedicos.Location = new System.Drawing.Point(20, 152);
            this.dgvRankingMedicos.Name = "dgvRankingMedicos";
            this.dgvRankingMedicos.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRankingMedicos.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvRankingMedicos.RowHeadersVisible = false;
            this.dgvRankingMedicos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRankingMedicos.Size = new System.Drawing.Size(833, 78);
            this.dgvRankingMedicos.TabIndex = 1;
            // 
            // colPos
            // 
            this.colPos.FillWeight = 25.38071F;
            this.colPos.HeaderText = "#";
            this.colPos.Name = "colPos";
            this.colPos.ReadOnly = true;
            // 
            // colMedico
            // 
            this.colMedico.FillWeight = 118.6548F;
            this.colMedico.HeaderText = "Médico";
            this.colMedico.Name = "colMedico";
            this.colMedico.ReadOnly = true;
            // 
            // colEspec
            // 
            this.colEspec.FillWeight = 118.6548F;
            this.colEspec.HeaderText = "Especialidad";
            this.colEspec.Name = "colEspec";
            this.colEspec.ReadOnly = true;
            // 
            // colConsultas
            // 
            this.colConsultas.FillWeight = 118.6548F;
            this.colConsultas.HeaderText = "Consultas";
            this.colConsultas.Name = "colConsultas";
            this.colConsultas.ReadOnly = true;
            // 
            // colPorcentaje
            // 
            this.colPorcentaje.FillWeight = 118.6548F;
            this.colPorcentaje.HeaderText = "% del total";
            this.colPorcentaje.Name = "colPorcentaje";
            this.colPorcentaje.ReadOnly = true;
            // 
            // chTopMedicos
            // 
            this.chTopMedicos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea14.AxisY.Interval = 1D;
            chartArea14.AxisY.LabelStyle.Format = "N0";
            chartArea14.Name = "caTop";
            this.chTopMedicos.ChartAreas.Add(chartArea14);
            legend14.Name = "lgTop";
            this.chTopMedicos.Legends.Add(legend14);
            this.chTopMedicos.Location = new System.Drawing.Point(3, 20);
            this.chTopMedicos.Name = "chTopMedicos";
            this.chTopMedicos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series14.ChartArea = "caTop";
            series14.Legend = "lgTop";
            series14.Name = "Consultas";
            this.chTopMedicos.Series.Add(series14);
            this.chTopMedicos.Size = new System.Drawing.Size(865, 132);
            this.chTopMedicos.TabIndex = 0;
            this.chTopMedicos.Text = "chart1";
            // 
            // lFechaHasta
            // 
            this.lFechaHasta.AutoSize = true;
            this.lFechaHasta.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFechaHasta.Location = new System.Drawing.Point(331, 72);
            this.lFechaHasta.Name = "lFechaHasta";
            this.lFechaHasta.Size = new System.Drawing.Size(115, 23);
            this.lFechaHasta.TabIndex = 10;
            this.lFechaHasta.Text = "Fecha Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "dd/MM/yyyy";
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(452, 72);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.ShowUpDown = true;
            this.dtpHasta.Size = new System.Drawing.Size(136, 20);
            this.dtpHasta.TabIndex = 11;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.BackgroundImage = global::SaludSoft.Properties.Resources.impresora;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImprimir.Location = new System.Drawing.Point(801, 474);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 35);
            this.btnImprimir.TabIndex = 12;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btActualizar
            // 
            this.btActualizar.BackgroundImage = global::SaludSoft.Properties.Resources.actualizar;
            this.btActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btActualizar.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActualizar.Location = new System.Drawing.Point(624, 72);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(39, 23);
            this.btActualizar.TabIndex = 3;
            this.btActualizar.UseVisualStyleBackColor = true;
            // 
            // panelPacientes
            // 
            this.panelPacientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPacientes.Controls.Add(this.lbValorPacientes);
            this.panelPacientes.Controls.Add(this.lbTituloPacientes);
            this.panelPacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPacientes.Location = new System.Drawing.Point(509, 3);
            this.panelPacientes.Name = "panelPacientes";
            this.panelPacientes.Size = new System.Drawing.Size(165, 73);
            this.panelPacientes.TabIndex = 7;
            // 
            // panelDisponibilidad
            // 
            this.panelDisponibilidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDisponibilidad.Controls.Add(this.lbValorDisponibilidad);
            this.panelDisponibilidad.Controls.Add(this.lbTituloDisponibilidad);
            this.panelDisponibilidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDisponibilidad.Location = new System.Drawing.Point(680, 3);
            this.panelDisponibilidad.Name = "panelDisponibilidad";
            this.panelDisponibilidad.Size = new System.Drawing.Size(188, 73);
            this.panelDisponibilidad.TabIndex = 8;
            // 
            // lbTituloPacientes
            // 
            this.lbTituloPacientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTituloPacientes.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTituloPacientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbTituloPacientes.Location = new System.Drawing.Point(0, 0);
            this.lbTituloPacientes.Name = "lbTituloPacientes";
            this.lbTituloPacientes.Size = new System.Drawing.Size(163, 33);
            this.lbTituloPacientes.TabIndex = 0;
            this.lbTituloPacientes.Text = "Pacientes Totales";
            this.lbTituloPacientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbValorPacientes
            // 
            this.lbValorPacientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbValorPacientes.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValorPacientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbValorPacientes.Location = new System.Drawing.Point(0, 33);
            this.lbValorPacientes.Name = "lbValorPacientes";
            this.lbValorPacientes.Size = new System.Drawing.Size(163, 23);
            this.lbValorPacientes.TabIndex = 1;
            this.lbValorPacientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTituloDisponibilidad
            // 
            this.lbTituloDisponibilidad.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTituloDisponibilidad.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTituloDisponibilidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbTituloDisponibilidad.Location = new System.Drawing.Point(0, 0);
            this.lbTituloDisponibilidad.Name = "lbTituloDisponibilidad";
            this.lbTituloDisponibilidad.Size = new System.Drawing.Size(186, 33);
            this.lbTituloDisponibilidad.TabIndex = 0;
            this.lbTituloDisponibilidad.Text = "Agenda Disponible";
            this.lbTituloDisponibilidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbValorDisponibilidad
            // 
            this.lbValorDisponibilidad.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbValorDisponibilidad.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValorDisponibilidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lbValorDisponibilidad.Location = new System.Drawing.Point(0, 33);
            this.lbValorDisponibilidad.Name = "lbValorDisponibilidad";
            this.lbValorDisponibilidad.Size = new System.Drawing.Size(186, 23);
            this.lbValorDisponibilidad.TabIndex = 1;
            this.lbValorDisponibilidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbPacientes
            // 
            this.pbPacientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbPacientes.Location = new System.Drawing.Point(509, 82);
            this.pbPacientes.Name = "pbPacientes";
            this.pbPacientes.Size = new System.Drawing.Size(165, 28);
            this.pbPacientes.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbPacientes.TabIndex = 9;
            // 
            // pbDisponibilidad
            // 
            this.pbDisponibilidad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbDisponibilidad.Location = new System.Drawing.Point(680, 82);
            this.pbDisponibilidad.Name = "pbDisponibilidad";
            this.pbDisponibilidad.Size = new System.Drawing.Size(188, 28);
            this.pbDisponibilidad.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbDisponibilidad.TabIndex = 10;
            // 
            // ReportesRecep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(895, 512);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.lFechaHasta);
            this.Controls.Add(this.gbTopMedicos);
            this.Controls.Add(this.tlKpis);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.dtpPeriodo);
            this.Controls.Add(this.lFechaPeriodo);
            this.Controls.Add(this.panel1);
            this.Name = "ReportesRecep";
            this.Text = "ReportesRecep";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.gbDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chPieEstados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.tlKpis.ResumeLayout(false);
            this.gbTopMedicos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankingMedicos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chTopMedicos)).EndInit();
            this.panelPacientes.ResumeLayout(false);
            this.panelDisponibilidad.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lReportesMes;
        private System.Windows.Forms.Label lFechaPeriodo;
        private System.Windows.Forms.DateTimePicker dtpPeriodo;
        private System.Windows.Forms.Button btActualizar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbTituloConfirmado;
        private System.Windows.Forms.ProgressBar pbTurnosConfirmados;
        private System.Windows.Forms.Label lbValor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbValorTP;
        private System.Windows.Forms.Label lbTurnosPendientes;
        private System.Windows.Forms.ProgressBar pbTP;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbValorTC;
        private System.Windows.Forms.Label lbTurnosCancelados;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.GroupBox gbDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chPieEstados;
        private System.Windows.Forms.TableLayoutPanel tlKpis;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaHora;
        private System.Windows.Forms.GroupBox gbTopMedicos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chTopMedicos;
        private System.Windows.Forms.DataGridView dgvRankingMedicos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEspec;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConsultas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPorcentaje;
        private System.Windows.Forms.Label lFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Panel panelPacientes;
        private System.Windows.Forms.Label lbTituloPacientes;
        private System.Windows.Forms.Panel panelDisponibilidad;
        private System.Windows.Forms.Label lbValorPacientes;
        private System.Windows.Forms.Label lbTituloDisponibilidad;
        private System.Windows.Forms.Label lbValorDisponibilidad;
        private System.Windows.Forms.ProgressBar pbPacientes;
        private System.Windows.Forms.ProgressBar pbDisponibilidad;
    }
}