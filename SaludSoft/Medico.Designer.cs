namespace SaludSoft
{
    partial class Medico
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
            this.BHistorial = new System.Windows.Forms.Button();
            this.BCerrarSesion = new System.Windows.Forms.Button();
            this.BPacientes = new System.Windows.Forms.Button();
            this.btCitas = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lTitulo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbBuscarPaciente = new System.Windows.Forms.TextBox();
            this.dgPacientes = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lDNI = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.pnlCitas = new System.Windows.Forms.Panel();
            this.btnImprimirCitas = new System.Windows.Forms.Button();
            this.dgCitas = new System.Windows.Forms.DataGridView();
            this.colHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConsultorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lFecha = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btCerrar = new System.Windows.Forms.Button();
            this.lCitas = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPacientes)).BeginInit();
            this.pnlCitas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCitas)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BHistorial
            // 
            this.BHistorial.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BHistorial.Image = global::SaludSoft.Properties.Resources.expediente_del_paciente;
            this.BHistorial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BHistorial.Location = new System.Drawing.Point(11, 248);
            this.BHistorial.Name = "BHistorial";
            this.BHistorial.Size = new System.Drawing.Size(166, 67);
            this.BHistorial.TabIndex = 6;
            this.BHistorial.Text = "Historias Clìnicas";
            this.BHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BHistorial.UseVisualStyleBackColor = true;
            this.BHistorial.Click += new System.EventHandler(this.BHistorial_Click);
            // 
            // BCerrarSesion
            // 
            this.BCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BCerrarSesion.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCerrarSesion.Image = global::SaludSoft.Properties.Resources.circulo_marca_x;
            this.BCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCerrarSesion.Location = new System.Drawing.Point(11, 393);
            this.BCerrarSesion.Name = "BCerrarSesion";
            this.BCerrarSesion.Size = new System.Drawing.Size(153, 41);
            this.BCerrarSesion.TabIndex = 3;
            this.BCerrarSesion.Text = "Cerrar Sesión";
            this.BCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCerrarSesion.UseVisualStyleBackColor = true;
            this.BCerrarSesion.Click += new System.EventHandler(this.BCerrarSesion_Click);
            // 
            // BPacientes
            // 
            this.BPacientes.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPacientes.Image = global::SaludSoft.Properties.Resources.usuario;
            this.BPacientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BPacientes.Location = new System.Drawing.Point(11, 9);
            this.BPacientes.Name = "BPacientes";
            this.BPacientes.Size = new System.Drawing.Size(153, 59);
            this.BPacientes.TabIndex = 3;
            this.BPacientes.Text = "Pacientes";
            this.BPacientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BPacientes.UseVisualStyleBackColor = true;
            // 
            // btCitas
            // 
            this.btCitas.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCitas.Image = global::SaludSoft.Properties.Resources.CitasProgramadas;
            this.btCitas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCitas.Location = new System.Drawing.Point(11, 131);
            this.btCitas.Name = "btCitas";
            this.btCitas.Size = new System.Drawing.Size(138, 62);
            this.btCitas.TabIndex = 3;
            this.btCitas.Text = "Citas  ";
            this.btCitas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCitas.UseVisualStyleBackColor = true;
            this.btCitas.Click += new System.EventHandler(this.btCitas_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.lTitulo);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1052, 74);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(183, 74);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(826, 434);
            this.panel4.TabIndex = 8;
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lTitulo.Location = new System.Drawing.Point(235, 18);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(101, 29);
            this.lTitulo.TabIndex = 3;
            this.lTitulo.Text = "MÉDICO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SaludSoft.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tbBuscarPaciente
            // 
            this.tbBuscarPaciente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBuscarPaciente.Location = new System.Drawing.Point(304, 112);
            this.tbBuscarPaciente.Name = "tbBuscarPaciente";
            this.tbBuscarPaciente.Size = new System.Drawing.Size(244, 20);
            this.tbBuscarPaciente.TabIndex = 3;
          //  this.tbBuscarPaciente.TextChanged += new System.EventHandler(this.tbBuscarPaciente_TextChanged);
            // 
            // dgPacientes
            // 
            this.dgPacientes.AllowUserToAddRows = false;
            this.dgPacientes.AllowUserToDeleteRows = false;
            this.dgPacientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPacientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colNombre,
            this.colApellido,
            this.colDni,
            this.colTel,
            this.colCorreo});
            this.dgPacientes.Location = new System.Drawing.Point(223, 191);
            this.dgPacientes.MultiSelect = false;
            this.dgPacientes.Name = "dgPacientes";
            this.dgPacientes.ReadOnly = true;
            this.dgPacientes.RowHeadersVisible = false;
            this.dgPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPacientes.Size = new System.Drawing.Size(763, 195);
            this.dgPacientes.TabIndex = 4;
            // 
            // colId
            // 
            this.colId.HeaderText = "Id_Paciente";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            // 
            // colApellido
            // 
            this.colApellido.HeaderText = "Apellido";
            this.colApellido.Name = "colApellido";
            this.colApellido.ReadOnly = true;
            // 
            // colDni
            // 
            this.colDni.HeaderText = "DNI";
            this.colDni.Name = "colDni";
            this.colDni.ReadOnly = true;
            // 
            // colTel
            // 
            this.colTel.HeaderText = "Teléfono";
            this.colTel.Name = "colTel";
            this.colTel.ReadOnly = true;
            // 
            // colCorreo
            // 
            this.colCorreo.HeaderText = "Correo Electrónico";
            this.colCorreo.Name = "colCorreo";
            this.colCorreo.ReadOnly = true;
            // 
            // lDNI
            // 
            this.lDNI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lDNI.AutoSize = true;
            this.lDNI.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDNI.Location = new System.Drawing.Point(237, 113);
            this.lDNI.Name = "lDNI";
            this.lDNI.Size = new System.Drawing.Size(48, 19);
            this.lDNI.TabIndex = 6;
            this.lDNI.Text = "DNI: ";
            // 
            // btBuscar
            // 
            this.btBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBuscar.Image = global::SaludSoft.Properties.Resources.busqueda;
            this.btBuscar.Location = new System.Drawing.Point(603, 107);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(75, 33);
            this.btBuscar.TabIndex = 5;
            this.btBuscar.UseVisualStyleBackColor = true;
            // 
            // pnlCitas
            // 
            this.pnlCitas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlCitas.Controls.Add(this.btnImprimirCitas);
            this.pnlCitas.Controls.Add(this.dgCitas);
            this.pnlCitas.Controls.Add(this.lFecha);
            this.pnlCitas.Controls.Add(this.dateTimePicker1);
            this.pnlCitas.Controls.Add(this.panel3);
            this.pnlCitas.Location = new System.Drawing.Point(190, 215);
            this.pnlCitas.Name = "pnlCitas";
            this.pnlCitas.Size = new System.Drawing.Size(402, 260);
            this.pnlCitas.TabIndex = 7;
            this.pnlCitas.Visible = false;
            // 
            // btnImprimirCitas
            // 
            this.btnImprimirCitas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimirCitas.BackgroundImage = global::SaludSoft.Properties.Resources.impresora;
            this.btnImprimirCitas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImprimirCitas.Location = new System.Drawing.Point(339, 69);
            this.btnImprimirCitas.Name = "btnImprimirCitas";
            this.btnImprimirCitas.Size = new System.Drawing.Size(47, 32);
            this.btnImprimirCitas.TabIndex = 5;
            this.btnImprimirCitas.Text = "button1";
            this.btnImprimirCitas.UseVisualStyleBackColor = true;
            this.btnImprimirCitas.Click += new System.EventHandler(this.btnImprimirCitas_Click);
            // 
            // dgCitas
            // 
            this.dgCitas.AllowUserToAddRows = false;
            this.dgCitas.AllowUserToDeleteRows = false;
            this.dgCitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCitas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHora,
            this.colPaciente,
            this.colMotivo,
            this.colConsultorio});
            this.dgCitas.Location = new System.Drawing.Point(16, 124);
            this.dgCitas.Name = "dgCitas";
            this.dgCitas.ReadOnly = true;
            this.dgCitas.RowHeadersVisible = false;
            this.dgCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCitas.Size = new System.Drawing.Size(370, 121);
            this.dgCitas.TabIndex = 4;
            // 
            // colHora
            // 
            this.colHora.HeaderText = "Hora";
            this.colHora.Name = "colHora";
            this.colHora.ReadOnly = true;
            // 
            // colPaciente
            // 
            this.colPaciente.HeaderText = "Paciente";
            this.colPaciente.Name = "colPaciente";
            this.colPaciente.ReadOnly = true;
            // 
            // colMotivo
            // 
            this.colMotivo.HeaderText = "Motivo";
            this.colMotivo.Name = "colMotivo";
            this.colMotivo.ReadOnly = true;
            // 
            // colConsultorio
            // 
            this.colConsultorio.HeaderText = "Consultorio";
            this.colConsultorio.Name = "colConsultorio";
            this.colConsultorio.ReadOnly = true;
            // 
            // lFecha
            // 
            this.lFecha.AutoSize = true;
            this.lFecha.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFecha.Location = new System.Drawing.Point(6, 74);
            this.lFecha.Name = "lFecha";
            this.lFecha.Size = new System.Drawing.Size(58, 19);
            this.lFecha.TabIndex = 3;
            this.lFecha.Text = "Fecha: ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(80, 67);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(115, 26);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel3.Controls.Add(this.btCerrar);
            this.panel3.Controls.Add(this.lCitas);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(402, 62);
            this.panel3.TabIndex = 1;
            // 
            // btCerrar
            // 
            this.btCerrar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btCerrar.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCerrar.Image = global::SaludSoft.Properties.Resources.circulo_marca_x;
            this.btCerrar.Location = new System.Drawing.Point(366, 3);
            this.btCerrar.Name = "btCerrar";
            this.btCerrar.Size = new System.Drawing.Size(33, 30);
            this.btCerrar.TabIndex = 2;
            this.btCerrar.UseVisualStyleBackColor = false;
            this.btCerrar.Click += new System.EventHandler(this.btCerrar_Click_1);
            // 
            // lCitas
            // 
            this.lCitas.AutoSize = true;
            this.lCitas.BackColor = System.Drawing.Color.White;
            this.lCitas.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCitas.Location = new System.Drawing.Point(135, 20);
            this.lCitas.Name = "lCitas";
            this.lCitas.Size = new System.Drawing.Size(107, 23);
            this.lCitas.TabIndex = 0;
            this.lCitas.Text = "Citas del día";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.BPacientes);
            this.panel1.Controls.Add(this.BCerrarSesion);
            this.panel1.Controls.Add(this.btCitas);
            this.panel1.Controls.Add(this.BHistorial);
            this.panel1.Location = new System.Drawing.Point(1, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 437);
            this.panel1.TabIndex = 0;
            // 
            // Medico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1009, 508);
            this.Controls.Add(this.pnlCitas);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.dgPacientes);
            this.Controls.Add(this.lDNI);
            this.Controls.Add(this.tbBuscarPaciente);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Medico";
            this.Text = "Medico";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPacientes)).EndInit();
            this.pnlCitas.ResumeLayout(false);
            this.pnlCitas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCitas)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.Button btCitas;
        private System.Windows.Forms.Button BPacientes;
        private System.Windows.Forms.Button BCerrarSesion;
        private System.Windows.Forms.TextBox tbBuscarPaciente;
        private System.Windows.Forms.DataGridView dgPacientes;
        private System.Windows.Forms.Button BHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCorreo;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Label lDNI;
        private System.Windows.Forms.Panel pnlCitas;
        private System.Windows.Forms.Label lCitas;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btCerrar;
        private System.Windows.Forms.DataGridView dgCitas;
        private System.Windows.Forms.Label lFecha;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConsultorio;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnImprimirCitas;
    }
}