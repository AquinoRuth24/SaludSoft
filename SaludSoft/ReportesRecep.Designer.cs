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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lReportesMes = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lFechaPeriodo = new System.Windows.Forms.Label();
            this.dtpPeriodo = new System.Windows.Forms.DateTimePicker();
            this.btActualizar = new System.Windows.Forms.Button();
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
            this.dtpPeriodo.CustomFormat = "MMMM yyyy";
            this.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodo.Location = new System.Drawing.Point(140, 75);
            this.dtpPeriodo.Name = "dtpPeriodo";
            this.dtpPeriodo.ShowUpDown = true;
            this.dtpPeriodo.Size = new System.Drawing.Size(137, 20);
            this.dtpPeriodo.TabIndex = 2;
            // 
            // btActualizar
            // 
            this.btActualizar.BackgroundImage = global::SaludSoft.Properties.Resources.actualizar;
            this.btActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btActualizar.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActualizar.Location = new System.Drawing.Point(681, 77);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(39, 23);
            this.btActualizar.TabIndex = 3;
            this.btActualizar.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbValor);
            this.panel2.Controls.Add(this.lbTituloConfirmado);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(283, 50);
            this.panel2.TabIndex = 4;
            // 
            // lbValor
            // 
            this.lbValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbValor.AutoSize = true;
            this.lbValor.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValor.ForeColor = System.Drawing.Color.Green;
            this.lbValor.Location = new System.Drawing.Point(260, 12);
            this.lbValor.Name = "lbValor";
            this.lbValor.Size = new System.Drawing.Size(0, 27);
            this.lbValor.TabIndex = 1;
            // 
            // lbTituloConfirmado
            // 
            this.lbTituloConfirmado.AutoSize = true;
            this.lbTituloConfirmado.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTituloConfirmado.ForeColor = System.Drawing.Color.Green;
            this.lbTituloConfirmado.Location = new System.Drawing.Point(11, 15);
            this.lbTituloConfirmado.Name = "lbTituloConfirmado";
            this.lbTituloConfirmado.Size = new System.Drawing.Size(160, 23);
            this.lbTituloConfirmado.TabIndex = 0;
            this.lbTituloConfirmado.Text = "Turnos Confirmados";
            // 
            // pbTurnosConfirmados
            // 
            this.pbTurnosConfirmados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbTurnosConfirmados.Location = new System.Drawing.Point(3, 80);
            this.pbTurnosConfirmados.MarqueeAnimationSpeed = 0;
            this.pbTurnosConfirmados.Name = "pbTurnosConfirmados";
            this.pbTurnosConfirmados.Size = new System.Drawing.Size(283, 29);
            this.pbTurnosConfirmados.Step = 1;
            this.pbTurnosConfirmados.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbTurnosConfirmados.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbValorTP);
            this.panel3.Controls.Add(this.lbTurnosPendientes);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(292, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(283, 50);
            this.panel3.TabIndex = 5;
            // 
            // lbValorTP
            // 
            this.lbValorTP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbValorTP.AutoSize = true;
            this.lbValorTP.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValorTP.ForeColor = System.Drawing.Color.Yellow;
            this.lbValorTP.Location = new System.Drawing.Point(254, 11);
            this.lbValorTP.Name = "lbValorTP";
            this.lbValorTP.Size = new System.Drawing.Size(0, 27);
            this.lbValorTP.TabIndex = 1;
            // 
            // lbTurnosPendientes
            // 
            this.lbTurnosPendientes.AutoSize = true;
            this.lbTurnosPendientes.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTurnosPendientes.ForeColor = System.Drawing.Color.Yellow;
            this.lbTurnosPendientes.Location = new System.Drawing.Point(12, 14);
            this.lbTurnosPendientes.Name = "lbTurnosPendientes";
            this.lbTurnosPendientes.Size = new System.Drawing.Size(149, 23);
            this.lbTurnosPendientes.TabIndex = 0;
            this.lbTurnosPendientes.Text = "Turnos Pendientes";
            // 
            // pbTP
            // 
            this.pbTP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbTP.Location = new System.Drawing.Point(292, 81);
            this.pbTP.MarqueeAnimationSpeed = 0;
            this.pbTP.Name = "pbTP";
            this.pbTP.Size = new System.Drawing.Size(283, 28);
            this.pbTP.Step = 1;
            this.pbTP.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbTP.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lbValorTC);
            this.panel4.Controls.Add(this.lbTurnosCancelados);
            this.panel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel4.Location = new System.Drawing.Point(581, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(285, 50);
            this.panel4.TabIndex = 6;
            // 
            // lbValorTC
            // 
            this.lbValorTC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbValorTC.AutoSize = true;
            this.lbValorTC.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValorTC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lbValorTC.Location = new System.Drawing.Point(256, 10);
            this.lbValorTC.Name = "lbValorTC";
            this.lbValorTC.Size = new System.Drawing.Size(0, 27);
            this.lbValorTC.TabIndex = 1;
            // 
            // lbTurnosCancelados
            // 
            this.lbTurnosCancelados.AutoSize = true;
            this.lbTurnosCancelados.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTurnosCancelados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lbTurnosCancelados.Location = new System.Drawing.Point(12, 10);
            this.lbTurnosCancelados.Name = "lbTurnosCancelados";
            this.lbTurnosCancelados.Size = new System.Drawing.Size(150, 23);
            this.lbTurnosCancelados.TabIndex = 0;
            this.lbTurnosCancelados.Text = "Turnos Cancelados";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(581, 81);
            this.progressBar1.MarqueeAnimationSpeed = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(285, 28);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            // 
            // gbDetalle
            // 
            this.gbDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetalle.Controls.Add(this.chPieEstados);
            this.gbDetalle.Controls.Add(this.dgvDetalle);
            this.gbDetalle.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetalle.ForeColor = System.Drawing.Color.Green;
            this.gbDetalle.Location = new System.Drawing.Point(12, 232);
            this.gbDetalle.Name = "gbDetalle";
            this.gbDetalle.Size = new System.Drawing.Size(870, 200);
            this.gbDetalle.TabIndex = 7;
            this.gbDetalle.TabStop = false;
            this.gbDetalle.Text = "Detalle de Turnos Confirmados/Pendientes/Cancelados";
            this.gbDetalle.Visible = false;
            // 
            // chPieEstados
            // 
            this.chPieEstados.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea3.Name = "ChartArea1";
            this.chPieEstados.ChartAreas.Add(chartArea3);
            legend3.Alignment = System.Drawing.StringAlignment.Center;
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend3.Name = "Legend1";
            this.chPieEstados.Legends.Add(legend3);
            this.chPieEstados.Location = new System.Drawing.Point(653, 44);
            this.chPieEstados.Name = "chPieEstados";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Legend1";
            series3.Name = "Estados";
            this.chPieEstados.Series.Add(series3);
            this.chPieEstados.Size = new System.Drawing.Size(223, 120);
            this.chPieEstados.TabIndex = 1;
            this.chPieEstados.Text = "chart1";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToResizeColumns = false;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "g";
            dataGridViewCellStyle3.NullValue = null;
            this.colFechaHora.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFechaHora.HeaderText = "Fecha/Hora";
            this.colFechaHora.Name = "colFechaHora";
            this.colFechaHora.ReadOnly = true;
            // 
            // tlKpis
            // 
            this.tlKpis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlKpis.ColumnCount = 3;
            this.tlKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlKpis.Controls.Add(this.progressBar1, 2, 1);
            this.tlKpis.Controls.Add(this.pbTP, 1, 1);
            this.tlKpis.Controls.Add(this.panel4, 2, 0);
            this.tlKpis.Controls.Add(this.panel2, 0, 0);
            this.tlKpis.Controls.Add(this.pbTurnosConfirmados, 0, 1);
            this.tlKpis.Controls.Add(this.panel3, 1, 0);
            this.tlKpis.Location = new System.Drawing.Point(13, 114);
            this.tlKpis.Name = "tlKpis";
            this.tlKpis.RowCount = 2;
            this.tlKpis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlKpis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlKpis.Size = new System.Drawing.Size(869, 112);
            this.tlKpis.TabIndex = 8;
            // 
            // gbTopMedicos
            // 
            this.gbTopMedicos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTopMedicos.Controls.Add(this.dgvRankingMedicos);
            this.gbTopMedicos.Controls.Add(this.chTopMedicos);
            this.gbTopMedicos.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTopMedicos.ForeColor = System.Drawing.Color.Green;
            this.gbTopMedicos.Location = new System.Drawing.Point(12, 232);
            this.gbTopMedicos.Name = "gbTopMedicos";
            this.gbTopMedicos.Size = new System.Drawing.Size(871, 256);
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
            this.dgvRankingMedicos.Location = new System.Drawing.Point(20, 134);
            this.dgvRankingMedicos.Name = "dgvRankingMedicos";
            this.dgvRankingMedicos.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRankingMedicos.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRankingMedicos.RowHeadersVisible = false;
            this.dgvRankingMedicos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRankingMedicos.Size = new System.Drawing.Size(845, 98);
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
            chartArea4.Name = "caTop";
            this.chTopMedicos.ChartAreas.Add(chartArea4);
            this.chTopMedicos.Dock = System.Windows.Forms.DockStyle.Top;
            legend4.Name = "lgTop";
            this.chTopMedicos.Legends.Add(legend4);
            this.chTopMedicos.Location = new System.Drawing.Point(3, 26);
            this.chTopMedicos.Name = "chTopMedicos";
            this.chTopMedicos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series4.ChartArea = "caTop";
            series4.Legend = "lgTop";
            series4.Name = "Consultas";
            this.chTopMedicos.Series.Add(series4);
            this.chTopMedicos.Size = new System.Drawing.Size(865, 102);
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
            this.dtpHasta.CustomFormat = "MMMM yyyy";
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(452, 72);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.ShowUpDown = true;
            this.dtpHasta.Size = new System.Drawing.Size(136, 20);
            this.dtpHasta.TabIndex = 11;
            // 
            // ReportesRecep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(895, 512);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.lFechaHasta);
            this.Controls.Add(this.gbTopMedicos);
            this.Controls.Add(this.tlKpis);
            this.Controls.Add(this.gbDetalle);
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
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.gbDetalle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chPieEstados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.tlKpis.ResumeLayout(false);
            this.gbTopMedicos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankingMedicos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chTopMedicos)).EndInit();
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
    }
}