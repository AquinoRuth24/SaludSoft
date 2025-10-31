namespace SaludSoft
{
    partial class FormEstadisticas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BVolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DTGRankingMedicos = new System.Windows.Forms.DataGridView();
            this.ChartEspecialidades = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BImprimir = new System.Windows.Forms.Button();
            this.BPacientes = new System.Windows.Forms.Button();
            this.Turnos = new System.Windows.Forms.Button();
            this.BMedico = new System.Windows.Forms.Button();
            this.lFechaHasta = new System.Windows.Forms.Label();
            this.lFechaPeriodo = new System.Windows.Forms.Label();
            this.BFiltro = new System.Windows.Forms.Button();
            this.DTPHasta = new System.Windows.Forms.DateTimePicker();
            this.DTPDesde = new System.Windows.Forms.DateTimePicker();
            this.GBContadorTurnos = new System.Windows.Forms.GroupBox();
            this.filtro = new System.Windows.Forms.Label();
            this.LContadorTurnos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GBMedicos = new System.Windows.Forms.GroupBox();
            this.DTGDetalleMedico = new System.Windows.Forms.DataGridView();
            this.GBPacientes = new System.Windows.Forms.GroupBox();
            this.DTGRankingPacientes = new System.Windows.Forms.DataGridView();
            this.ChartEdades = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTGRankingMedicos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartEspecialidades)).BeginInit();
            this.panel2.SuspendLayout();
            this.GBContadorTurnos.SuspendLayout();
            this.GBMedicos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTGDetalleMedico)).BeginInit();
            this.GBPacientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTGRankingPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartEdades)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.BVolver);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 51);
            this.panel1.TabIndex = 1;
            // 
            // BVolver
            // 
            this.BVolver.Image = global::SaludSoft.Properties.Resources.angulo_izquierdo;
            this.BVolver.Location = new System.Drawing.Point(11, 3);
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
            this.label1.Location = new System.Drawing.Point(459, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reportes";
            // 
            // DTGRankingMedicos
            // 
            this.DTGRankingMedicos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTGRankingMedicos.BackgroundColor = System.Drawing.Color.LightGray;
            this.DTGRankingMedicos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DTGRankingMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGRankingMedicos.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.DTGRankingMedicos.Location = new System.Drawing.Point(64, 19);
            this.DTGRankingMedicos.Name = "DTGRankingMedicos";
            this.DTGRankingMedicos.Size = new System.Drawing.Size(970, 245);
            this.DTGRankingMedicos.TabIndex = 3;
            // 
            // ChartEspecialidades
            // 
            this.ChartEspecialidades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChartEspecialidades.BackColor = System.Drawing.Color.DimGray;
            this.ChartEspecialidades.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            this.ChartEspecialidades.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea1.Name = "ChartArea";
            this.ChartEspecialidades.ChartAreas.Add(chartArea1);
            this.ChartEspecialidades.Cursor = System.Windows.Forms.Cursors.Default;
            legend1.Name = "Legend1";
            this.ChartEspecialidades.Legends.Add(legend1);
            this.ChartEspecialidades.Location = new System.Drawing.Point(291, 130);
            this.ChartEspecialidades.Name = "ChartEspecialidades";
            this.ChartEspecialidades.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea";
            series1.Legend = "Legend1";
            series1.Name = "Especialidades";
            this.ChartEspecialidades.Series.Add(series1);
            this.ChartEspecialidades.Size = new System.Drawing.Size(510, 301);
            this.ChartEspecialidades.TabIndex = 2;
            this.ChartEspecialidades.Text = "Especialidades";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.SeaGreen;
            this.panel2.Controls.Add(this.BImprimir);
            this.panel2.Controls.Add(this.BPacientes);
            this.panel2.Controls.Add(this.Turnos);
            this.panel2.Controls.Add(this.BMedico);
            this.panel2.Controls.Add(this.lFechaHasta);
            this.panel2.Controls.Add(this.lFechaPeriodo);
            this.panel2.Controls.Add(this.BFiltro);
            this.panel2.Controls.Add(this.DTPHasta);
            this.panel2.Controls.Add(this.DTPDesde);
            this.panel2.Location = new System.Drawing.Point(8, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1067, 67);
            this.panel2.TabIndex = 4;
            // 
            // BImprimir
            // 
            this.BImprimir.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BImprimir.Image = global::SaludSoft.Properties.Resources.impresora;
            this.BImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BImprimir.Location = new System.Drawing.Point(371, 13);
            this.BImprimir.Name = "BImprimir";
            this.BImprimir.Size = new System.Drawing.Size(102, 40);
            this.BImprimir.TabIndex = 15;
            this.BImprimir.Text = "Imprimir";
            this.BImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BImprimir.UseVisualStyleBackColor = true;
            this.BImprimir.Click += new System.EventHandler(this.BImprimir_Click);
            // 
            // BPacientes
            // 
            this.BPacientes.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPacientes.Location = new System.Drawing.Point(240, 13);
            this.BPacientes.Name = "BPacientes";
            this.BPacientes.Size = new System.Drawing.Size(97, 40);
            this.BPacientes.TabIndex = 14;
            this.BPacientes.Text = "Pacientes";
            this.BPacientes.UseVisualStyleBackColor = true;
            this.BPacientes.Click += new System.EventHandler(this.BPacientes_Click);
            // 
            // Turnos
            // 
            this.Turnos.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Turnos.Location = new System.Drawing.Point(15, 13);
            this.Turnos.Name = "Turnos";
            this.Turnos.Size = new System.Drawing.Size(93, 40);
            this.Turnos.TabIndex = 13;
            this.Turnos.Text = "Turnos";
            this.Turnos.UseVisualStyleBackColor = true;
            this.Turnos.Click += new System.EventHandler(this.Turnos_Click);
            // 
            // BMedico
            // 
            this.BMedico.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BMedico.Location = new System.Drawing.Point(125, 13);
            this.BMedico.Name = "BMedico";
            this.BMedico.Size = new System.Drawing.Size(97, 40);
            this.BMedico.TabIndex = 12;
            this.BMedico.Text = "Medicos";
            this.BMedico.UseVisualStyleBackColor = true;
            this.BMedico.Click += new System.EventHandler(this.BMedico_Click);
            // 
            // lFechaHasta
            // 
            this.lFechaHasta.AutoSize = true;
            this.lFechaHasta.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFechaHasta.Location = new System.Drawing.Point(812, 13);
            this.lFechaHasta.Name = "lFechaHasta";
            this.lFechaHasta.Size = new System.Drawing.Size(115, 23);
            this.lFechaHasta.TabIndex = 11;
            this.lFechaHasta.Text = "Fecha Hasta:";
            // 
            // lFechaPeriodo
            // 
            this.lFechaPeriodo.AutoSize = true;
            this.lFechaPeriodo.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFechaPeriodo.Location = new System.Drawing.Point(678, 13);
            this.lFechaPeriodo.Name = "lFechaPeriodo";
            this.lFechaPeriodo.Size = new System.Drawing.Size(123, 23);
            this.lFechaPeriodo.TabIndex = 3;
            this.lFechaPeriodo.Text = "Fecha Desde: ";
            // 
            // BFiltro
            // 
            this.BFiltro.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BFiltro.Location = new System.Drawing.Point(933, 22);
            this.BFiltro.Name = "BFiltro";
            this.BFiltro.Size = new System.Drawing.Size(75, 31);
            this.BFiltro.TabIndex = 2;
            this.BFiltro.Text = "Filtrar";
            this.BFiltro.UseVisualStyleBackColor = true;
            // 
            // DTPHasta
            // 
            this.DTPHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPHasta.Location = new System.Drawing.Point(818, 39);
            this.DTPHasta.Name = "DTPHasta";
            this.DTPHasta.Size = new System.Drawing.Size(109, 22);
            this.DTPHasta.TabIndex = 1;
            // 
            // DTPDesde
            // 
            this.DTPDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDesde.Location = new System.Drawing.Point(683, 39);
            this.DTPDesde.Name = "DTPDesde";
            this.DTPDesde.Size = new System.Drawing.Size(105, 22);
            this.DTPDesde.TabIndex = 0;
            // 
            // GBContadorTurnos
            // 
            this.GBContadorTurnos.BackColor = System.Drawing.SystemColors.Window;
            this.GBContadorTurnos.Controls.Add(this.filtro);
            this.GBContadorTurnos.Controls.Add(this.LContadorTurnos);
            this.GBContadorTurnos.Controls.Add(this.label2);
            this.GBContadorTurnos.Location = new System.Drawing.Point(44, 139);
            this.GBContadorTurnos.Name = "GBContadorTurnos";
            this.GBContadorTurnos.Size = new System.Drawing.Size(200, 100);
            this.GBContadorTurnos.TabIndex = 5;
            this.GBContadorTurnos.TabStop = false;
            // 
            // filtro
            // 
            this.filtro.AutoSize = true;
            this.filtro.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtro.Location = new System.Drawing.Point(63, 77);
            this.filtro.Name = "filtro";
            this.filtro.Size = new System.Drawing.Size(65, 20);
            this.filtro.TabIndex = 9;
            this.filtro.Text = "Este dia";
            // 
            // LContadorTurnos
            // 
            this.LContadorTurnos.AutoSize = true;
            this.LContadorTurnos.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LContadorTurnos.Location = new System.Drawing.Point(84, 43);
            this.LContadorTurnos.Name = "LContadorTurnos";
            this.LContadorTurnos.Size = new System.Drawing.Size(24, 26);
            this.LContadorTurnos.TabIndex = 8;
            this.LContadorTurnos.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Total De Turnos";
            // 
            // GBMedicos
            // 
            this.GBMedicos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GBMedicos.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.GBMedicos.Controls.Add(this.DTGDetalleMedico);
            this.GBMedicos.Controls.Add(this.DTGRankingMedicos);
            this.GBMedicos.Location = new System.Drawing.Point(1, 130);
            this.GBMedicos.Name = "GBMedicos";
            this.GBMedicos.Size = new System.Drawing.Size(1080, 490);
            this.GBMedicos.TabIndex = 6;
            this.GBMedicos.TabStop = false;
            this.GBMedicos.Visible = false;
            // 
            // DTGDetalleMedico
            // 
            this.DTGDetalleMedico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTGDetalleMedico.BackgroundColor = System.Drawing.Color.LightGray;
            this.DTGDetalleMedico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DTGDetalleMedico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGDetalleMedico.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.DTGDetalleMedico.Location = new System.Drawing.Point(0, 270);
            this.DTGDetalleMedico.Name = "DTGDetalleMedico";
            this.DTGDetalleMedico.Size = new System.Drawing.Size(1074, 245);
            this.DTGDetalleMedico.TabIndex = 4;
            // 
            // GBPacientes
            // 
            this.GBPacientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GBPacientes.Controls.Add(this.DTGRankingPacientes);
            this.GBPacientes.Controls.Add(this.ChartEdades);
            this.GBPacientes.Location = new System.Drawing.Point(0, 130);
            this.GBPacientes.Name = "GBPacientes";
            this.GBPacientes.Size = new System.Drawing.Size(1080, 515);
            this.GBPacientes.TabIndex = 5;
            this.GBPacientes.TabStop = false;
            this.GBPacientes.Visible = false;
            // 
            // DTGRankingPacientes
            // 
            this.DTGRankingPacientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTGRankingPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGRankingPacientes.Location = new System.Drawing.Point(150, 216);
            this.DTGRankingPacientes.Name = "DTGRankingPacientes";
            this.DTGRankingPacientes.Size = new System.Drawing.Size(866, 256);
            this.DTGRankingPacientes.TabIndex = 1;
            this.DTGRankingPacientes.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DTGRankingPacientes_CellPainting);
            // 
            // ChartEdades
            // 
            chartArea2.Name = "ChartArea1";
            this.ChartEdades.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ChartEdades.Legends.Add(legend2);
            this.ChartEdades.Location = new System.Drawing.Point(12, 175);
            this.ChartEdades.Name = "ChartEdades";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.ChartEdades.Series.Add(series2);
            this.ChartEdades.Size = new System.Drawing.Size(300, 267);
            this.ChartEdades.TabIndex = 0;
            this.ChartEdades.Text = "Distribucion por edades";
            this.ChartEdades.Visible = false;
            // 
            // FormEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1077, 632);
            this.Controls.Add(this.GBPacientes);
            this.Controls.Add(this.GBMedicos);
            this.Controls.Add(this.GBContadorTurnos);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ChartEspecialidades);
            this.Controls.Add(this.panel1);
            this.Name = "FormEstadisticas";
            this.Text = "FormEstadisticas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTGRankingMedicos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartEspecialidades)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.GBContadorTurnos.ResumeLayout(false);
            this.GBContadorTurnos.PerformLayout();
            this.GBMedicos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DTGDetalleMedico)).EndInit();
            this.GBPacientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DTGRankingPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartEdades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartEspecialidades;
        private System.Windows.Forms.DataGridView DTGRankingMedicos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox GBContadorTurnos;
        private System.Windows.Forms.Label filtro;
        private System.Windows.Forms.Label LContadorTurnos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTPHasta;
        private System.Windows.Forms.DateTimePicker DTPDesde;
        private System.Windows.Forms.Button BFiltro;
        private System.Windows.Forms.Label lFechaPeriodo;
        private System.Windows.Forms.Label lFechaHasta;
        private System.Windows.Forms.GroupBox GBMedicos;
        private System.Windows.Forms.Button BMedico;
        private System.Windows.Forms.DataGridView DTGDetalleMedico;
        private System.Windows.Forms.Button Turnos;
        private System.Windows.Forms.Button BPacientes;
        private System.Windows.Forms.GroupBox GBPacientes;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartEdades;
        private System.Windows.Forms.DataGridView DTGRankingPacientes;
        private System.Windows.Forms.Button BImprimir;
    }
}