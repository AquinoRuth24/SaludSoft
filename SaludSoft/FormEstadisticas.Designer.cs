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
            this.DTGRankingMedicos = new System.Windows.Forms.DataGridView();
            this.BVolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ChartEspecialidades = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DTGActividadPorTurno = new System.Windows.Forms.DataGridView();
            this.ChartTurnosPorEstado = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTGRankingMedicos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartEspecialidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGActividadPorTurno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartTurnosPorEstado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.DTGRankingMedicos);
            this.panel1.Controls.Add(this.BVolver);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 51);
            this.panel1.TabIndex = 1;
            // 
            // DTGRankingMedicos
            // 
            this.DTGRankingMedicos.BackgroundColor = System.Drawing.Color.LightGray;
            this.DTGRankingMedicos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DTGRankingMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGRankingMedicos.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.DTGRankingMedicos.Location = new System.Drawing.Point(509, -62);
            this.DTGRankingMedicos.Name = "DTGRankingMedicos";
            this.DTGRankingMedicos.Size = new System.Drawing.Size(512, 316);
            this.DTGRankingMedicos.TabIndex = 3;
            this.DTGRankingMedicos.Visible = false;
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
            // ChartEspecialidades
            // 
            this.ChartEspecialidades.BackColor = System.Drawing.Color.DimGray;
            this.ChartEspecialidades.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            this.ChartEspecialidades.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chartArea1.Name = "ChartArea";
            this.ChartEspecialidades.ChartAreas.Add(chartArea1);
            this.ChartEspecialidades.Cursor = System.Windows.Forms.Cursors.Default;
            legend1.Name = "Legend1";
            this.ChartEspecialidades.Legends.Add(legend1);
            this.ChartEspecialidades.Location = new System.Drawing.Point(49, 130);
            this.ChartEspecialidades.Name = "ChartEspecialidades";
            this.ChartEspecialidades.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea";
            series1.Legend = "Legend1";
            series1.Name = "Especialidades";
            this.ChartEspecialidades.Series.Add(series1);
            this.ChartEspecialidades.Size = new System.Drawing.Size(427, 262);
            this.ChartEspecialidades.TabIndex = 2;
            this.ChartEspecialidades.Text = "Especialidades";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.SeaGreen;
            this.panel2.Location = new System.Drawing.Point(8, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1057, 67);
            this.panel2.TabIndex = 4;
            // 
            // DTGActividadPorTurno
            // 
            this.DTGActividadPorTurno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGActividadPorTurno.Location = new System.Drawing.Point(576, 130);
            this.DTGActividadPorTurno.Name = "DTGActividadPorTurno";
            this.DTGActividadPorTurno.Size = new System.Drawing.Size(474, 262);
            this.DTGActividadPorTurno.TabIndex = 5;
            this.DTGActividadPorTurno.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DTGActividadTurnos_CellFormatting);
            // 
            // ChartTurnosPorEstado
            // 
            this.ChartTurnosPorEstado.BackColor = System.Drawing.Color.DimGray;
            this.ChartTurnosPorEstado.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            chartArea2.Name = "ChartArea1";
            this.ChartTurnosPorEstado.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ChartTurnosPorEstado.Legends.Add(legend2);
            this.ChartTurnosPorEstado.Location = new System.Drawing.Point(247, 398);
            this.ChartTurnosPorEstado.Name = "ChartTurnosPorEstado";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.ChartTurnosPorEstado.Series.Add(series2);
            this.ChartTurnosPorEstado.Size = new System.Drawing.Size(521, 219);
            this.ChartTurnosPorEstado.TabIndex = 6;
            // 
            // FormEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1077, 617);
            this.Controls.Add(this.ChartTurnosPorEstado);
            this.Controls.Add(this.DTGActividadPorTurno);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ChartEspecialidades);
            this.Controls.Add(this.panel1);
            this.Name = "FormEstadisticas";
            this.Text = "FormEstadisticas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTGRankingMedicos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartEspecialidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTGActividadPorTurno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartTurnosPorEstado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartEspecialidades;
        private System.Windows.Forms.DataGridView DTGRankingMedicos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DTGActividadPorTurno;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartTurnosPorEstado;
    }
}