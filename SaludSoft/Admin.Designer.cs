namespace SaludSoft
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BReportes = new System.Windows.Forms.Button();
            this.btCerrarSesion = new System.Windows.Forms.Button();
            this.btGestionUsuario = new System.Windows.Forms.Button();
            this.lAdministrador = new System.Windows.Forms.Label();
            this.btBackup = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btTurnos = new System.Windows.Forms.Button();
            this.btConsultorios = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlTurnos = new System.Windows.Forms.Panel();
            this.lblProfesionalMes = new System.Windows.Forms.Label();
            this.cmbMedicoMes = new System.Windows.Forms.ComboBox();
            this.lTitulo = new System.Windows.Forms.Label();
            this.dtpSemana = new System.Windows.Forms.DateTimePicker();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dgvTurnosMes = new System.Windows.Forms.DataGridView();
            this.colFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colCancelar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.LTurnosDelDia = new System.Windows.Forms.Label();
            this.LContador = new System.Windows.Forms.Label();
            this.PPacienetes = new System.Windows.Forms.Button();
            this.btHistorial = new System.Windows.Forms.Button();
            this.btEspecialidades = new System.Windows.Forms.Button();
            this.btTurnosMes = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnlTurnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnosMes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.BReportes);
            this.panel2.Controls.Add(this.btCerrarSesion);
            this.panel2.Controls.Add(this.btGestionUsuario);
            this.panel2.Controls.Add(this.lAdministrador);
            this.panel2.Controls.Add(this.btBackup);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btTurnos);
            this.panel2.Controls.Add(this.btConsultorios);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1036, 499);
            this.panel2.TabIndex = 2;
            // 
            // BReportes
            // 
            this.BReportes.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BReportes.Image = ((System.Drawing.Image)(resources.GetObject("BReportes.Image")));
            this.BReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BReportes.Location = new System.Drawing.Point(7, 266);
            this.BReportes.Name = "BReportes";
            this.BReportes.Size = new System.Drawing.Size(129, 40);
            this.BReportes.TabIndex = 9;
            this.BReportes.Text = "Reportes";
            this.BReportes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BReportes.UseVisualStyleBackColor = true;
            this.BReportes.Click += new System.EventHandler(this.BReportes_Click);
            // 
            // btCerrarSesion
            // 
            this.btCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCerrarSesion.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCerrarSesion.Image = global::SaludSoft.Properties.Resources.circulo_marca_x;
            this.btCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCerrarSesion.Location = new System.Drawing.Point(2, 435);
            this.btCerrarSesion.Margin = new System.Windows.Forms.Padding(2);
            this.btCerrarSesion.Name = "btCerrarSesion";
            this.btCerrarSesion.Size = new System.Drawing.Size(139, 41);
            this.btCerrarSesion.TabIndex = 2;
            this.btCerrarSesion.Text = "Cerrar Sesión";
            this.btCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCerrarSesion.UseVisualStyleBackColor = true;
            this.btCerrarSesion.Click += new System.EventHandler(this.btCerrarSesion_Click);
            // 
            // btGestionUsuario
            // 
            this.btGestionUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btGestionUsuario.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGestionUsuario.Image = global::SaludSoft.Properties.Resources.agregar;
            this.btGestionUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGestionUsuario.Location = new System.Drawing.Point(819, 11);
            this.btGestionUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.btGestionUsuario.Name = "btGestionUsuario";
            this.btGestionUsuario.Size = new System.Drawing.Size(193, 32);
            this.btGestionUsuario.TabIndex = 3;
            this.btGestionUsuario.Text = "Gestionar Usuario ";
            this.btGestionUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGestionUsuario.UseVisualStyleBackColor = true;
            this.btGestionUsuario.Click += new System.EventHandler(this.btGestionUsuario_Click);
            // 
            // lAdministrador
            // 
            this.lAdministrador.AutoSize = true;
            this.lAdministrador.BackColor = System.Drawing.Color.Transparent;
            this.lAdministrador.Font = new System.Drawing.Font("Comic Sans MS", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAdministrador.ForeColor = System.Drawing.Color.Green;
            this.lAdministrador.Location = new System.Drawing.Point(163, 12);
            this.lAdministrador.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lAdministrador.Name = "lAdministrador";
            this.lAdministrador.Size = new System.Drawing.Size(200, 34);
            this.lAdministrador.TabIndex = 3;
            this.lAdministrador.Text = "Administrador  ";
            // 
            // btBackup
            // 
            this.btBackup.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBackup.Image = global::SaludSoft.Properties.Resources.monedas;
            this.btBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBackup.Location = new System.Drawing.Point(7, 348);
            this.btBackup.Margin = new System.Windows.Forms.Padding(2);
            this.btBackup.Name = "btBackup";
            this.btBackup.Size = new System.Drawing.Size(129, 36);
            this.btBackup.TabIndex = 2;
            this.btBackup.Text = "Backup ";
            this.btBackup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBackup.UseVisualStyleBackColor = true;
            this.btBackup.Click += new System.EventHandler(this.btBackup_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SaludSoft.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btTurnos
            // 
            this.btTurnos.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTurnos.Image = global::SaludSoft.Properties.Resources.alt_de_inventario;
            this.btTurnos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTurnos.Location = new System.Drawing.Point(11, 172);
            this.btTurnos.Margin = new System.Windows.Forms.Padding(2);
            this.btTurnos.Name = "btTurnos";
            this.btTurnos.Size = new System.Drawing.Size(129, 40);
            this.btTurnos.TabIndex = 5;
            this.btTurnos.Text = "Turnos ";
            this.btTurnos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btTurnos.UseVisualStyleBackColor = true;
            this.btTurnos.Click += new System.EventHandler(this.btTurnos_Click);
            // 
            // btConsultorios
            // 
            this.btConsultorios.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConsultorios.Image = global::SaludSoft.Properties.Resources.construccion_de_casas;
            this.btConsultorios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btConsultorios.Location = new System.Drawing.Point(7, 78);
            this.btConsultorios.Margin = new System.Windows.Forms.Padding(2);
            this.btConsultorios.Name = "btConsultorios";
            this.btConsultorios.Size = new System.Drawing.Size(129, 45);
            this.btConsultorios.TabIndex = 2;
            this.btConsultorios.Text = "Consultorios";
            this.btConsultorios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btConsultorios.UseVisualStyleBackColor = true;
            this.btConsultorios.Click += new System.EventHandler(this.btConsultorios_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Controls.Add(this.pnlTurnos);
            this.panel3.Controls.Add(this.LTurnosDelDia);
            this.panel3.Controls.Add(this.LContador);
            this.panel3.Controls.Add(this.PPacienetes);
            this.panel3.Controls.Add(this.btHistorial);
            this.panel3.Controls.Add(this.btEspecialidades);
            this.panel3.Controls.Add(this.btTurnosMes);
            this.panel3.Location = new System.Drawing.Point(144, 52);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(890, 446);
            this.panel3.TabIndex = 3;
            // 
            // pnlTurnos
            // 
            this.pnlTurnos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTurnos.BackColor = System.Drawing.Color.PaleGreen;
            this.pnlTurnos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTurnos.Controls.Add(this.lblProfesionalMes);
            this.pnlTurnos.Controls.Add(this.cmbMedicoMes);
            this.pnlTurnos.Controls.Add(this.lTitulo);
            this.pnlTurnos.Controls.Add(this.dtpSemana);
            this.pnlTurnos.Controls.Add(this.btnVolver);
            this.pnlTurnos.Controls.Add(this.dgvTurnosMes);
            this.pnlTurnos.Location = new System.Drawing.Point(16, 6);
            this.pnlTurnos.Name = "pnlTurnos";
            this.pnlTurnos.Size = new System.Drawing.Size(852, 438);
            this.pnlTurnos.TabIndex = 9;
            this.pnlTurnos.Visible = false;
            // 
            // lblProfesionalMes
            // 
            this.lblProfesionalMes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProfesionalMes.AutoSize = true;
            this.lblProfesionalMes.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfesionalMes.Location = new System.Drawing.Point(400, 26);
            this.lblProfesionalMes.Name = "lblProfesionalMes";
            this.lblProfesionalMes.Size = new System.Drawing.Size(100, 23);
            this.lblProfesionalMes.TabIndex = 14;
            this.lblProfesionalMes.Text = "Profesional:";
            // 
            // cmbMedicoMes
            // 
            this.cmbMedicoMes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMedicoMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedicoMes.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMedicoMes.FormattingEnabled = true;
            this.cmbMedicoMes.Location = new System.Drawing.Point(506, 25);
            this.cmbMedicoMes.Name = "cmbMedicoMes";
            this.cmbMedicoMes.Size = new System.Drawing.Size(198, 26);
            this.cmbMedicoMes.TabIndex = 13;
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lTitulo.Location = new System.Drawing.Point(3, 6);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(151, 27);
            this.lTitulo.TabIndex = 7;
            this.lTitulo.Text = "Turnos del mes";
            // 
            // dtpSemana
            // 
            this.dtpSemana.CustomFormat = "dd/MM/yyyy";
            this.dtpSemana.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSemana.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSemana.Location = new System.Drawing.Point(167, 23);
            this.dtpSemana.Name = "dtpSemana";
            this.dtpSemana.ShowUpDown = true;
            this.dtpSemana.Size = new System.Drawing.Size(141, 26);
            this.dtpSemana.TabIndex = 8;
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVolver.Image = global::SaludSoft.Properties.Resources.circulo_marca_x;
            this.btnVolver.Location = new System.Drawing.Point(797, 3);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(50, 30);
            this.btnVolver.TabIndex = 10;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dgvTurnosMes
            // 
            this.dgvTurnosMes.AllowUserToAddRows = false;
            this.dgvTurnosMes.AllowUserToDeleteRows = false;
            this.dgvTurnosMes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTurnosMes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTurnosMes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTurnosMes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnosMes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFechaHora,
            this.colPaciente,
            this.colProfesional,
            this.colMotivo,
            this.colEstado,
            this.colEditar,
            this.colCancelar});
            this.dgvTurnosMes.EnableHeadersVisualStyles = false;
            this.dgvTurnosMes.Location = new System.Drawing.Point(5, 69);
            this.dgvTurnosMes.MultiSelect = false;
            this.dgvTurnosMes.Name = "dgvTurnosMes";
            this.dgvTurnosMes.ReadOnly = true;
            this.dgvTurnosMes.RowHeadersVisible = false;
            this.dgvTurnosMes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnosMes.Size = new System.Drawing.Size(836, 358);
            this.dgvTurnosMes.TabIndex = 11;
            // 
            // colFechaHora
            // 
            dataGridViewCellStyle4.Format = "g";
            dataGridViewCellStyle4.NullValue = null;
            this.colFechaHora.DefaultCellStyle = dataGridViewCellStyle4;
            this.colFechaHora.HeaderText = "Fecha/Hora";
            this.colFechaHora.Name = "colFechaHora";
            this.colFechaHora.ReadOnly = true;
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
            // colMotivo
            // 
            this.colMotivo.HeaderText = "Motivo";
            this.colMotivo.Name = "colMotivo";
            this.colMotivo.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // colEditar
            // 
            this.colEditar.HeaderText = "Editar";
            this.colEditar.Name = "colEditar";
            this.colEditar.ReadOnly = true;
            this.colEditar.Text = "Editar";
            this.colEditar.UseColumnTextForButtonValue = true;
            // 
            // colCancelar
            // 
            this.colCancelar.HeaderText = "Cancelar";
            this.colCancelar.Name = "colCancelar";
            this.colCancelar.ReadOnly = true;
            this.colCancelar.Text = "Cancelar";
            this.colCancelar.UseColumnTextForButtonValue = true;
            // 
            // LTurnosDelDia
            // 
            this.LTurnosDelDia.AutoSize = true;
            this.LTurnosDelDia.BackColor = System.Drawing.Color.Transparent;
            this.LTurnosDelDia.Font = new System.Drawing.Font("Constantia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTurnosDelDia.Location = new System.Drawing.Point(202, 90);
            this.LTurnosDelDia.Name = "LTurnosDelDia";
            this.LTurnosDelDia.Size = new System.Drawing.Size(35, 39);
            this.LTurnosDelDia.TabIndex = 8;
            this.LTurnosDelDia.Text = "0";
            // 
            // LContador
            // 
            this.LContador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LContador.AutoSize = true;
            this.LContador.BackColor = System.Drawing.Color.Transparent;
            this.LContador.Font = new System.Drawing.Font("Constantia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LContador.Location = new System.Drawing.Point(658, 296);
            this.LContador.Name = "LContador";
            this.LContador.Size = new System.Drawing.Size(35, 39);
            this.LContador.TabIndex = 7;
            this.LContador.Text = "0";
            // 
            // PPacienetes
            // 
            this.PPacienetes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PPacienetes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PPacienetes.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PPacienetes.Location = new System.Drawing.Point(558, 231);
            this.PPacienetes.Name = "PPacienetes";
            this.PPacienetes.Size = new System.Drawing.Size(234, 122);
            this.PPacienetes.TabIndex = 6;
            this.PPacienetes.Text = "Pacientes ";
            this.PPacienetes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PPacienetes.UseVisualStyleBackColor = false;
            this.PPacienetes.Click += new System.EventHandler(this.BPacienetes_Click);
            // 
            // btHistorial
            // 
            this.btHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btHistorial.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHistorial.Image = global::SaludSoft.Properties.Resources.expediente_del_paciente;
            this.btHistorial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btHistorial.Location = new System.Drawing.Point(114, 233);
            this.btHistorial.Name = "btHistorial";
            this.btHistorial.Size = new System.Drawing.Size(223, 122);
            this.btHistorial.TabIndex = 5;
            this.btHistorial.Text = "Historial Paciente";
            this.btHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btHistorial.UseVisualStyleBackColor = false;
            // 
            // btEspecialidades
            // 
            this.btEspecialidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btEspecialidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btEspecialidades.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEspecialidades.Image = global::SaludSoft.Properties.Resources.libro_medico;
            this.btEspecialidades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEspecialidades.Location = new System.Drawing.Point(558, 29);
            this.btEspecialidades.Margin = new System.Windows.Forms.Padding(2);
            this.btEspecialidades.Name = "btEspecialidades";
            this.btEspecialidades.Size = new System.Drawing.Size(234, 131);
            this.btEspecialidades.TabIndex = 3;
            this.btEspecialidades.Text = "Especialidades ";
            this.btEspecialidades.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEspecialidades.UseVisualStyleBackColor = false;
            this.btEspecialidades.Click += new System.EventHandler(this.btEspecialidades_Click);
            // 
            // btTurnosMes
            // 
            this.btTurnosMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btTurnosMes.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTurnosMes.Image = global::SaludSoft.Properties.Resources.CitasProgramadas;
            this.btTurnosMes.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btTurnosMes.Location = new System.Drawing.Point(114, 29);
            this.btTurnosMes.Margin = new System.Windows.Forms.Padding(2);
            this.btTurnosMes.Name = "btTurnosMes";
            this.btTurnosMes.Size = new System.Drawing.Size(223, 131);
            this.btTurnosMes.TabIndex = 2;
            this.btTurnosMes.Text = "Turnos del dia";
            this.btTurnosMes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btTurnosMes.UseVisualStyleBackColor = false;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 499);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Admin";
            this.Text = "Admin";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlTurnos.ResumeLayout(false);
            this.pnlTurnos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnosMes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btTurnos;
        private System.Windows.Forms.Button btBackup;
        private System.Windows.Forms.Button btConsultorios;
        private System.Windows.Forms.Button btCerrarSesion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lAdministrador;
        private System.Windows.Forms.Button btGestionUsuario;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btTurnosMes;
        private System.Windows.Forms.Button btEspecialidades;
        private System.Windows.Forms.Button btHistorial;
        private System.Windows.Forms.Button PPacienetes;
        private System.Windows.Forms.Label LContador;
        private System.Windows.Forms.Label LTurnosDelDia;
        private System.Windows.Forms.Button BReportes;
        private System.Windows.Forms.Panel pnlTurnos;
        private System.Windows.Forms.Label lblProfesionalMes;
        private System.Windows.Forms.ComboBox cmbMedicoMes;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.DateTimePicker dtpSemana;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgvTurnosMes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewButtonColumn colCancelar;
    }
}