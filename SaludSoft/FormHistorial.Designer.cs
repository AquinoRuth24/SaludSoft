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
            this.dgHistorial = new System.Windows.Forms.DataGridView();
            this.lDni = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbBuscarDni = new System.Windows.Forms.TextBox();
            this.pnlOverlay = new System.Windows.Forms.Panel();
            this.gbDetalle = new System.Windows.Forms.GroupBox();
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
            this.colDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiagnostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTratamiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVerHistorial = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHistorial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.btVolver);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1018, 74);
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
            this.colDni,
            this.colPaciente,
            this.colDiagnostico,
            this.colTratamiento,
            this.colVerHistorial});
            this.dgHistorial.Location = new System.Drawing.Point(87, 149);
            this.dgHistorial.MultiSelect = false;
            this.dgHistorial.Name = "dgHistorial";
            this.dgHistorial.RowHeadersVisible = false;
            this.dgHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHistorial.Size = new System.Drawing.Size(771, 348);
            this.dgHistorial.TabIndex = 3;
            this.dgHistorial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgHistorial_CellContentClick);
            // 
            // lDni
            // 
            this.lDni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lDni.AutoSize = true;
            this.lDni.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDni.Location = new System.Drawing.Point(197, 90);
            this.lDni.Name = "lDni";
            this.lDni.Size = new System.Drawing.Size(58, 23);
            this.lDni.TabIndex = 4;
            this.lDni.Text = "DNI: ";
            // 
            // btBuscar
            // 
            this.btBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBuscar.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Image = global::SaludSoft.Properties.Resources.busqueda;
            this.btBuscar.Location = new System.Drawing.Point(686, 81);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(59, 41);
            this.btBuscar.TabIndex = 6;
            this.btBuscar.UseVisualStyleBackColor = true;
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
            // tbBuscarDni
            // 
            this.tbBuscarDni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.pnlOverlay.Location = new System.Drawing.Point(505, 149);
            this.pnlOverlay.Name = "pnlOverlay";
            this.pnlOverlay.Size = new System.Drawing.Size(465, 405);
            this.pnlOverlay.TabIndex = 8;
            this.pnlOverlay.Visible = false;
            // 
            // gbDetalle
            // 
            this.gbDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetalle.BackColor = System.Drawing.Color.Gainsboro;
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
            this.gbDetalle.Size = new System.Drawing.Size(432, 373);
            this.gbDetalle.TabIndex = 0;
            this.gbDetalle.TabStop = false;
            this.gbDetalle.Text = "Detalle Historial";
            this.gbDetalle.Visible = false;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btCancelar);
            this.pnlBotones.Controls.Add(this.btAgregar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(3, 281);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(426, 89);
            this.pnlBotones.TabIndex = 18;
            // 
            // btCancelar
            // 
            this.btCancelar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Location = new System.Drawing.Point(309, 15);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(94, 39);
            this.btCancelar.TabIndex = 1;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            // 
            // btAgregar
            // 
            this.btAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btAgregar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAgregar.Location = new System.Drawing.Point(191, 13);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(93, 43);
            this.btAgregar.TabIndex = 0;
            this.btAgregar.Text = "Agregar";
            this.btAgregar.UseVisualStyleBackColor = false;
            // 
            // tbObserv
            // 
            this.tbObserv.Location = new System.Drawing.Point(141, 185);
            this.tbObserv.Name = "tbObserv";
            this.tbObserv.Size = new System.Drawing.Size(133, 34);
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
            this.tbTrat.Location = new System.Drawing.Point(141, 145);
            this.tbTrat.Name = "tbTrat";
            this.tbTrat.Size = new System.Drawing.Size(133, 34);
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
            this.tbDiagnostico.Location = new System.Drawing.Point(141, 102);
            this.tbDiagnostico.Name = "tbDiagnostico";
            this.tbDiagnostico.ReadOnly = true;
            this.tbDiagnostico.Size = new System.Drawing.Size(133, 34);
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
            // FormHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1014, 509);
            this.Controls.Add(this.pnlOverlay);
            this.Controls.Add(this.tbBuscarDni);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.lDni);
            this.Controls.Add(this.dgHistorial);
            this.Controls.Add(this.panel2);
            this.Name = "FormHistorial";
            this.Text = "FormHistorial";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHistorial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Button btBuscar;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiagnostico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTratamiento;
        private System.Windows.Forms.DataGridViewButtonColumn colVerHistorial;
    }
}