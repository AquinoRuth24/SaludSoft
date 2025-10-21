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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lReportesMes = new System.Windows.Forms.Label();
            this.lFechaPeriodo = new System.Windows.Forms.Label();
            this.dtpPeriodo = new System.Windows.Forms.DateTimePicker();
            this.btActualizar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbTituloConfirmado = new System.Windows.Forms.Label();
            this.lbValor = new System.Windows.Forms.Label();
            this.pbTurnosConfirmados = new System.Windows.Forms.ProgressBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbTurnosPendientes = new System.Windows.Forms.Label();
            this.lbValorTP = new System.Windows.Forms.Label();
            this.pbTP = new System.Windows.Forms.ProgressBar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbTurnosCancelados = new System.Windows.Forms.Label();
            this.lbValorTC = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnVolver = new System.Windows.Forms.Button();
            this.gbDetalle = new System.Windows.Forms.GroupBox();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chPieEstados = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gbDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chPieEstados)).BeginInit();
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
            // lFechaPeriodo
            // 
            this.lFechaPeriodo.AutoSize = true;
            this.lFechaPeriodo.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFechaPeriodo.Location = new System.Drawing.Point(13, 74);
            this.lFechaPeriodo.Name = "lFechaPeriodo";
            this.lFechaPeriodo.Size = new System.Drawing.Size(69, 23);
            this.lFechaPeriodo.TabIndex = 1;
            this.lFechaPeriodo.Text = "Fecha: ";
            // 
            // dtpPeriodo
            // 
            this.dtpPeriodo.CustomFormat = "MMMM yyyy";
            this.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodo.Location = new System.Drawing.Point(99, 77);
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
            this.btActualizar.Location = new System.Drawing.Point(253, 74);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(39, 23);
            this.btActualizar.TabIndex = 3;
            this.btActualizar.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pbTurnosConfirmados);
            this.panel2.Controls.Add(this.lbValor);
            this.panel2.Controls.Add(this.lbTituloConfirmado);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Location = new System.Drawing.Point(1, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(277, 100);
            this.panel2.TabIndex = 4;
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
            // lbValor
            // 
            this.lbValor.AutoSize = true;
            this.lbValor.Location = new System.Drawing.Point(206, 22);
            this.lbValor.Name = "lbValor";
            this.lbValor.Size = new System.Drawing.Size(0, 13);
            this.lbValor.TabIndex = 1;
            // 
            // pbTurnosConfirmados
            // 
            this.pbTurnosConfirmados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTurnosConfirmados.Location = new System.Drawing.Point(3, 54);
            this.pbTurnosConfirmados.MarqueeAnimationSpeed = 0;
            this.pbTurnosConfirmados.Name = "pbTurnosConfirmados";
            this.pbTurnosConfirmados.Size = new System.Drawing.Size(269, 27);
            this.pbTurnosConfirmados.Step = 1;
            this.pbTurnosConfirmados.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbTurnosConfirmados.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pbTP);
            this.panel3.Controls.Add(this.lbValorTP);
            this.panel3.Controls.Add(this.lbTurnosPendientes);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(303, 105);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(283, 100);
            this.panel3.TabIndex = 5;
            // 
            // lbTurnosPendientes
            // 
            this.lbTurnosPendientes.AutoSize = true;
            this.lbTurnosPendientes.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTurnosPendientes.ForeColor = System.Drawing.Color.Green;
            this.lbTurnosPendientes.Location = new System.Drawing.Point(12, 14);
            this.lbTurnosPendientes.Name = "lbTurnosPendientes";
            this.lbTurnosPendientes.Size = new System.Drawing.Size(149, 23);
            this.lbTurnosPendientes.TabIndex = 0;
            this.lbTurnosPendientes.Text = "Turnos Pendientes";
            // 
            // lbValorTP
            // 
            this.lbValorTP.AutoSize = true;
            this.lbValorTP.Location = new System.Drawing.Point(206, 21);
            this.lbValorTP.Name = "lbValorTP";
            this.lbValorTP.Size = new System.Drawing.Size(0, 13);
            this.lbValorTP.TabIndex = 1;
            // 
            // pbTP
            // 
            this.pbTP.Location = new System.Drawing.Point(3, 54);
            this.pbTP.MarqueeAnimationSpeed = 0;
            this.pbTP.Name = "pbTP";
            this.pbTP.Size = new System.Drawing.Size(273, 28);
            this.pbTP.Step = 1;
            this.pbTP.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbTP.TabIndex = 2;
            this.pbTP.Click += new System.EventHandler(this.pbTP_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.progressBar1);
            this.panel4.Controls.Add(this.lbValorTC);
            this.panel4.Controls.Add(this.lbTurnosCancelados);
            this.panel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel4.Location = new System.Drawing.Point(608, 105);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(275, 102);
            this.panel4.TabIndex = 6;
            // 
            // lbTurnosCancelados
            // 
            this.lbTurnosCancelados.AutoSize = true;
            this.lbTurnosCancelados.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTurnosCancelados.ForeColor = System.Drawing.Color.Green;
            this.lbTurnosCancelados.Location = new System.Drawing.Point(12, 10);
            this.lbTurnosCancelados.Name = "lbTurnosCancelados";
            this.lbTurnosCancelados.Size = new System.Drawing.Size(150, 23);
            this.lbTurnosCancelados.TabIndex = 0;
            this.lbTurnosCancelados.Text = "Turnos Cancelados";
            this.lbTurnosCancelados.Click += new System.EventHandler(this.lbTurnosCancelados_Click);
            // 
            // lbValorTC
            // 
            this.lbValorTC.AutoSize = true;
            this.lbValorTC.Location = new System.Drawing.Point(207, 29);
            this.lbValorTC.Name = "lbValorTC";
            this.lbValorTC.Size = new System.Drawing.Size(0, 13);
            this.lbValorTC.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 52);
            this.progressBar1.MarqueeAnimationSpeed = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(264, 30);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
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
            // gbDetalle
            // 
            this.gbDetalle.Controls.Add(this.chPieEstados);
            this.gbDetalle.Controls.Add(this.dgvDetalle);
            this.gbDetalle.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetalle.Location = new System.Drawing.Point(1, 211);
            this.gbDetalle.Name = "gbDetalle";
            this.gbDetalle.Size = new System.Drawing.Size(781, 200);
            this.gbDetalle.TabIndex = 7;
            this.gbDetalle.TabStop = false;
            this.gbDetalle.Text = "Detalle de Turnos Confirmados/Pendientes/Cancelados";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPaciente,
            this.colProfesional,
            this.colEspecialidad,
            this.colFechaHora});
            this.dgvDetalle.Location = new System.Drawing.Point(27, 29);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(445, 72);
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
            this.colFechaHora.HeaderText = "Fecha/Hora";
            this.colFechaHora.Name = "colFechaHora";
            this.colFechaHora.ReadOnly = true;
            // 
            // chPieEstados
            // 
            this.chPieEstados.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chPieEstados.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chPieEstados.Legends.Add(legend1);
            this.chPieEstados.Location = new System.Drawing.Point(528, 49);
            this.chPieEstados.Name = "chPieEstados";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Estados";
            this.chPieEstados.Series.Add(series1);
            this.chPieEstados.Size = new System.Drawing.Size(223, 120);
            this.chPieEstados.TabIndex = 1;
            this.chPieEstados.Text = "chart1";
            // 
            // ReportesRecep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(895, 512);
            this.Controls.Add(this.gbDetalle);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chPieEstados)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaHora;
        private System.Windows.Forms.DataVisualization.Charting.Chart chPieEstados;
    }
}