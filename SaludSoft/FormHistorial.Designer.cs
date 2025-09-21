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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgHistorial = new System.Windows.Forms.DataGridView();
            this.lDni = new System.Windows.Forms.Label();
            this.mtbDni = new System.Windows.Forms.MaskedTextBox();
            this.colDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiagnostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTratamiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btBuscar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btVolver = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHistorial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.btVolver);
            this.panel1.Location = new System.Drawing.Point(0, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 383);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(135, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(675, 74);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(233, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Historia Clìnica ";
            // 
            // dgHistorial
            // 
            this.dgHistorial.AllowUserToAddRows = false;
            this.dgHistorial.AllowUserToDeleteRows = false;
            this.dgHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDni,
            this.colPaciente,
            this.colDiagnostico,
            this.colTratamiento,
            this.colEditar});
            this.dgHistorial.Location = new System.Drawing.Point(174, 157);
            this.dgHistorial.MultiSelect = false;
            this.dgHistorial.Name = "dgHistorial";
            this.dgHistorial.ReadOnly = true;
            this.dgHistorial.RowHeadersVisible = false;
            this.dgHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHistorial.Size = new System.Drawing.Size(573, 231);
            this.dgHistorial.TabIndex = 3;
            this.dgHistorial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgHistorial_CellContentClick);
            // 
            // lDni
            // 
            this.lDni.AutoSize = true;
            this.lDni.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDni.Location = new System.Drawing.Point(171, 110);
            this.lDni.Name = "lDni";
            this.lDni.Size = new System.Drawing.Size(58, 23);
            this.lDni.TabIndex = 4;
            this.lDni.Text = "DNI: ";
            // 
            // mtbDni
            // 
            this.mtbDni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.mtbDni.Location = new System.Drawing.Point(235, 110);
            this.mtbDni.Mask = "00000000";
            this.mtbDni.Name = "mtbDni";
            this.mtbDni.Size = new System.Drawing.Size(186, 20);
            this.mtbDni.TabIndex = 5;
            this.mtbDni.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // colDni
            // 
            this.colDni.HeaderText = "DNI";
            this.colDni.Name = "colDni";
            this.colDni.ReadOnly = true;
            // 
            // colPaciente
            // 
            this.colPaciente.HeaderText = "Paciente";
            this.colPaciente.Name = "colPaciente";
            this.colPaciente.ReadOnly = true;
            // 
            // colDiagnostico
            // 
            this.colDiagnostico.HeaderText = "Diagnòstico";
            this.colDiagnostico.Name = "colDiagnostico";
            this.colDiagnostico.ReadOnly = true;
            // 
            // colTratamiento
            // 
            this.colTratamiento.HeaderText = "Tratamiento";
            this.colTratamiento.Name = "colTratamiento";
            this.colTratamiento.ReadOnly = true;
            // 
            // colEditar
            // 
            this.colEditar.HeaderText = "Editar";
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.UseColumnTextForButtonValue = true;
            // 
            // btBuscar
            // 
            this.btBuscar.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Image = global::SaludSoft.Properties.Resources.busqueda;
            this.btBuscar.Location = new System.Drawing.Point(447, 92);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(59, 41);
            this.btBuscar.TabIndex = 6;
            this.btBuscar.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SaludSoft.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btVolver
            // 
            this.btVolver.BackColor = System.Drawing.Color.White;
            this.btVolver.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVolver.Image = global::SaludSoft.Properties.Resources.angulo_izquierdo;
            this.btVolver.Location = new System.Drawing.Point(12, 19);
            this.btVolver.Name = "btVolver";
            this.btVolver.Size = new System.Drawing.Size(96, 44);
            this.btVolver.TabIndex = 3;
            this.btVolver.UseVisualStyleBackColor = false;
            // 
            // FormHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(811, 456);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.mtbDni);
            this.Controls.Add(this.lDni);
            this.Controls.Add(this.dgHistorial);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FormHistorial";
            this.Text = "FormHistorial";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHistorial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btVolver;
        private System.Windows.Forms.DataGridView dgHistorial;
        private System.Windows.Forms.Label lDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiagnostico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTratamiento;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.MaskedTextBox mtbDni;
        private System.Windows.Forms.Button btBuscar;
    }
}