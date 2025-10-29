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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DTGRankingMedicos = new System.Windows.Forms.DataGridView();
            this.BVolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ChartEspecialidades = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BFiltro = new System.Windows.Forms.Button();
            this.DTPHasta = new System.Windows.Forms.DateTimePicker();
            this.DTPDesde = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.filtro = new System.Windows.Forms.Label();
            this.LContadorTurnos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lFechaPeriodo = new System.Windows.Forms.Label();
            this.lFechaHasta = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTGRankingMedicos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartEspecialidades)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            chartArea2.Name = "ChartArea";
            this.ChartEspecialidades.ChartAreas.Add(chartArea2);
            this.ChartEspecialidades.Cursor = System.Windows.Forms.Cursors.Default;
            legend2.Name = "Legend1";
            this.ChartEspecialidades.Legends.Add(legend2);
            this.ChartEspecialidades.Location = new System.Drawing.Point(352, 130);
            this.ChartEspecialidades.Name = "ChartEspecialidades";
            this.ChartEspecialidades.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.ChartArea = "ChartArea";
            series2.Legend = "Legend1";
            series2.Name = "Especialidades";
            this.ChartEspecialidades.Series.Add(series2);
            this.ChartEspecialidades.Size = new System.Drawing.Size(427, 262);
            this.ChartEspecialidades.TabIndex = 2;
            this.ChartEspecialidades.Text = "Especialidades";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.SeaGreen;
            this.panel2.Controls.Add(this.lFechaHasta);
            this.panel2.Controls.Add(this.lFechaPeriodo);
            this.panel2.Controls.Add(this.BFiltro);
            this.panel2.Controls.Add(this.DTPHasta);
            this.panel2.Controls.Add(this.DTPDesde);
            this.panel2.Location = new System.Drawing.Point(8, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1057, 67);
            this.panel2.TabIndex = 4;
            // 
            // BFiltro
            // 
            this.BFiltro.Location = new System.Drawing.Point(891, 25);
            this.BFiltro.Name = "BFiltro";
            this.BFiltro.Size = new System.Drawing.Size(75, 23);
            this.BFiltro.TabIndex = 2;
            this.BFiltro.Text = "Filtrar";
            this.BFiltro.UseVisualStyleBackColor = true;
            // 
            // DTPHasta
            // 
            this.DTPHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPHasta.Location = new System.Drawing.Point(752, 24);
            this.DTPHasta.Name = "DTPHasta";
            this.DTPHasta.Size = new System.Drawing.Size(109, 22);
            this.DTPHasta.TabIndex = 1;
            // 
            // DTPDesde
            // 
            this.DTPDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDesde.Location = new System.Drawing.Point(529, 23);
            this.DTPDesde.Name = "DTPDesde";
            this.DTPDesde.Size = new System.Drawing.Size(105, 22);
            this.DTPDesde.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.filtro);
            this.groupBox1.Controls.Add(this.LContadorTurnos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(44, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
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
            this.label2.Location = new System.Drawing.Point(37, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Total De Turnos";
            // 
            // lFechaPeriodo
            // 
            this.lFechaPeriodo.AutoSize = true;
            this.lFechaPeriodo.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFechaPeriodo.Location = new System.Drawing.Point(409, 21);
            this.lFechaPeriodo.Name = "lFechaPeriodo";
            this.lFechaPeriodo.Size = new System.Drawing.Size(123, 23);
            this.lFechaPeriodo.TabIndex = 3;
            this.lFechaPeriodo.Text = "Fecha Desde: ";
            // 
            // lFechaHasta
            // 
            this.lFechaHasta.AutoSize = true;
            this.lFechaHasta.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFechaHasta.Location = new System.Drawing.Point(640, 23);
            this.lFechaHasta.Name = "lFechaHasta";
            this.lFechaHasta.Size = new System.Drawing.Size(115, 23);
            this.lFechaHasta.TabIndex = 11;
            this.lFechaHasta.Text = "Fecha Hasta:";
            // 
            // FormEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1077, 591);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartEspecialidades;
        private System.Windows.Forms.DataGridView DTGRankingMedicos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label filtro;
        private System.Windows.Forms.Label LContadorTurnos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTPHasta;
        private System.Windows.Forms.DateTimePicker DTPDesde;
        private System.Windows.Forms.Button BFiltro;
        private System.Windows.Forms.Label lFechaPeriodo;
        private System.Windows.Forms.Label lFechaHasta;
    }
}