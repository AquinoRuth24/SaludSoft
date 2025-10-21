namespace SaludSoft
{
    partial class SaludSoft
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaludSoft));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PMenu = new System.Windows.Forms.Panel();
            this.btnReportes = new System.Windows.Forms.Button();
            this.BCerrarSesion = new System.Windows.Forms.Button();
            this.BAgenda = new System.Windows.Forms.Button();
            this.BTurnos = new System.Windows.Forms.Button();
            this.BPacientes = new System.Windows.Forms.Button();
            this.PSuperior = new System.Windows.Forms.Panel();
            this.BNuevoPaciente = new System.Windows.Forms.Button();
            this.LRecepcionista = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BNuevaCita = new System.Windows.Forms.Button();
            this.PPacientes = new System.Windows.Forms.Panel();
            this.LContadorPacientesHoy = new System.Windows.Forms.Label();
            this.PPacientesHoy = new System.Windows.Forms.PictureBox();
            this.LPacientesHoy = new System.Windows.Forms.Label();
            this.PCitas = new System.Windows.Forms.Panel();
            this.LContadorTurnosHoy = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.LTurnosProgramados = new System.Windows.Forms.Label();
            this.PDoctores = new System.Windows.Forms.Panel();
            this.LContadorDoctores = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.LDoctores = new System.Windows.Forms.Label();
            this.PEspecialidades = new System.Windows.Forms.Panel();
            this.LContadorEspecialidades = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PMenu.SuspendLayout();
            this.PSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PPacientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PPacientesHoy)).BeginInit();
            this.PCitas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.PDoctores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.PEspecialidades.SuspendLayout();
            this.pnlTurnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnosMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // PMenu
            // 
            this.PMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PMenu.Controls.Add(this.btnReportes);
            this.PMenu.Controls.Add(this.BCerrarSesion);
            this.PMenu.Controls.Add(this.BAgenda);
            this.PMenu.Controls.Add(this.BTurnos);
            this.PMenu.Controls.Add(this.BPacientes);
            this.PMenu.Location = new System.Drawing.Point(2, 72);
            this.PMenu.Name = "PMenu";
            this.PMenu.Size = new System.Drawing.Size(120, 453);
            this.PMenu.TabIndex = 0;
            // 
            // btnReportes
            // 
            this.btnReportes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportes.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.Image = global::SaludSoft.Properties.Resources.archivo_de_edicion;
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.Location = new System.Drawing.Point(7, 266);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(107, 40);
            this.btnReportes.TabIndex = 8;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportes.UseVisualStyleBackColor = true;
            // 
            // BCerrarSesion
            // 
            this.BCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BCerrarSesion.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCerrarSesion.Location = new System.Drawing.Point(3, 384);
            this.BCerrarSesion.Name = "BCerrarSesion";
            this.BCerrarSesion.Size = new System.Drawing.Size(111, 55);
            this.BCerrarSesion.TabIndex = 6;
            this.BCerrarSesion.Text = "Cerrar Sesión";
            this.BCerrarSesion.UseVisualStyleBackColor = true;
            this.BCerrarSesion.Click += new System.EventHandler(this.BCerrarSesion_Click);
            // 
            // BAgenda
            // 
            this.BAgenda.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgenda.Image = global::SaludSoft.Properties.Resources.CitasProgramadas;
            this.BAgenda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAgenda.Location = new System.Drawing.Point(7, 178);
            this.BAgenda.Name = "BAgenda";
            this.BAgenda.Size = new System.Drawing.Size(107, 39);
            this.BAgenda.TabIndex = 8;
            this.BAgenda.Text = "Agenda";
            this.BAgenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BAgenda.UseVisualStyleBackColor = true;
            this.BAgenda.Click += new System.EventHandler(this.BAgenda_Click);
            // 
            // BTurnos
            // 
            this.BTurnos.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTurnos.Image = global::SaludSoft.Properties.Resources.alt_de_inventario;
            this.BTurnos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTurnos.Location = new System.Drawing.Point(10, 91);
            this.BTurnos.Name = "BTurnos";
            this.BTurnos.Size = new System.Drawing.Size(92, 41);
            this.BTurnos.TabIndex = 4;
            this.BTurnos.Text = "Turnos";
            this.BTurnos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTurnos.UseVisualStyleBackColor = true;
            this.BTurnos.Click += new System.EventHandler(this.BTurnos_Click);
            // 
            // BPacientes
            // 
            this.BPacientes.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPacientes.Image = global::SaludSoft.Properties.Resources.usuario;
            this.BPacientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BPacientes.Location = new System.Drawing.Point(7, 18);
            this.BPacientes.Name = "BPacientes";
            this.BPacientes.Size = new System.Drawing.Size(113, 40);
            this.BPacientes.TabIndex = 5;
            this.BPacientes.Text = "Pacientes";
            this.BPacientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BPacientes.UseVisualStyleBackColor = true;
            this.BPacientes.Click += new System.EventHandler(this.BPacientes_Click);
            // 
            // PSuperior
            // 
            this.PSuperior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PSuperior.Controls.Add(this.BNuevoPaciente);
            this.PSuperior.Controls.Add(this.LRecepcionista);
            this.PSuperior.Controls.Add(this.pictureBox1);
            this.PSuperior.Controls.Add(this.BNuevaCita);
            this.PSuperior.Location = new System.Drawing.Point(2, 1);
            this.PSuperior.Name = "PSuperior";
            this.PSuperior.Size = new System.Drawing.Size(931, 75);
            this.PSuperior.TabIndex = 1;
            // 
            // BNuevoPaciente
            // 
            this.BNuevoPaciente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BNuevoPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(32)))));
            this.BNuevoPaciente.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevoPaciente.ForeColor = System.Drawing.Color.White;
            this.BNuevoPaciente.Location = new System.Drawing.Point(779, 8);
            this.BNuevoPaciente.Name = "BNuevoPaciente";
            this.BNuevoPaciente.Size = new System.Drawing.Size(113, 57);
            this.BNuevoPaciente.TabIndex = 5;
            this.BNuevoPaciente.Text = "+ Nuevo     Paciente";
            this.BNuevoPaciente.UseVisualStyleBackColor = false;
            this.BNuevoPaciente.Click += new System.EventHandler(this.BNuevoPaciente_Click);
            // 
            // LRecepcionista
            // 
            this.LRecepcionista.AutoSize = true;
            this.LRecepcionista.Font = new System.Drawing.Font("Comic Sans MS", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LRecepcionista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.LRecepcionista.Location = new System.Drawing.Point(199, 16);
            this.LRecepcionista.Name = "LRecepcionista";
            this.LRecepcionista.Size = new System.Drawing.Size(169, 34);
            this.LRecepcionista.TabIndex = 4;
            this.LRecepcionista.Text = "Recepcionista";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::SaludSoft.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // BNuevaCita
            // 
            this.BNuevaCita.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BNuevaCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(32)))));
            this.BNuevaCita.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevaCita.ForeColor = System.Drawing.Color.White;
            this.BNuevaCita.Location = new System.Drawing.Point(661, 8);
            this.BNuevaCita.Name = "BNuevaCita";
            this.BNuevaCita.Size = new System.Drawing.Size(108, 57);
            this.BNuevaCita.TabIndex = 0;
            this.BNuevaCita.Text = "+ Nuevo     Turno";
            this.BNuevaCita.UseVisualStyleBackColor = false;
            this.BNuevaCita.Click += new System.EventHandler(this.BNuevaCita_Click);
            // 
            // PPacientes
            // 
            this.PPacientes.BackColor = System.Drawing.Color.PaleGreen;
            this.PPacientes.Controls.Add(this.LContadorPacientesHoy);
            this.PPacientes.Controls.Add(this.PPacientesHoy);
            this.PPacientes.Controls.Add(this.LPacientesHoy);
            this.PPacientes.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PPacientes.Location = new System.Drawing.Point(137, 110);
            this.PPacientes.Name = "PPacientes";
            this.PPacientes.Size = new System.Drawing.Size(375, 126);
            this.PPacientes.TabIndex = 2;
            // 
            // LContadorPacientesHoy
            // 
            this.LContadorPacientesHoy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LContadorPacientesHoy.AutoSize = true;
            this.LContadorPacientesHoy.BackColor = System.Drawing.Color.Transparent;
            this.LContadorPacientesHoy.Font = new System.Drawing.Font("Constantia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LContadorPacientesHoy.Location = new System.Drawing.Point(205, 67);
            this.LContadorPacientesHoy.Name = "LContadorPacientesHoy";
            this.LContadorPacientesHoy.Size = new System.Drawing.Size(35, 39);
            this.LContadorPacientesHoy.TabIndex = 9;
            this.LContadorPacientesHoy.Text = "0";
            // 
            // PPacientesHoy
            // 
            this.PPacientesHoy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PPacientesHoy.BackgroundImage")));
            this.PPacientesHoy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PPacientesHoy.Location = new System.Drawing.Point(297, 6);
            this.PPacientesHoy.Name = "PPacientesHoy";
            this.PPacientesHoy.Size = new System.Drawing.Size(64, 37);
            this.PPacientesHoy.TabIndex = 8;
            this.PPacientesHoy.TabStop = false;
            // 
            // LPacientesHoy
            // 
            this.LPacientesHoy.AutoSize = true;
            this.LPacientesHoy.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPacientesHoy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.LPacientesHoy.Location = new System.Drawing.Point(92, 6);
            this.LPacientesHoy.Name = "LPacientesHoy";
            this.LPacientesHoy.Size = new System.Drawing.Size(142, 27);
            this.LPacientesHoy.TabIndex = 0;
            this.LPacientesHoy.Text = "Pacientes Hoy";
            // 
            // PCitas
            // 
            this.PCitas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PCitas.BackColor = System.Drawing.Color.PaleGreen;
            this.PCitas.Controls.Add(this.LContadorTurnosHoy);
            this.PCitas.Controls.Add(this.pictureBox3);
            this.PCitas.Controls.Add(this.LTurnosProgramados);
            this.PCitas.Location = new System.Drawing.Point(554, 110);
            this.PCitas.Name = "PCitas";
            this.PCitas.Size = new System.Drawing.Size(369, 126);
            this.PCitas.TabIndex = 3;
            // 
            // LContadorTurnosHoy
            // 
            this.LContadorTurnosHoy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LContadorTurnosHoy.AutoSize = true;
            this.LContadorTurnosHoy.BackColor = System.Drawing.Color.Transparent;
            this.LContadorTurnosHoy.Font = new System.Drawing.Font("Constantia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LContadorTurnosHoy.Location = new System.Drawing.Point(166, 67);
            this.LContadorTurnosHoy.Name = "LContadorTurnosHoy";
            this.LContadorTurnosHoy.Size = new System.Drawing.Size(35, 39);
            this.LContadorTurnosHoy.TabIndex = 9;
            this.LContadorTurnosHoy.Text = "0";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(319, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(47, 34);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // LTurnosProgramados
            // 
            this.LTurnosProgramados.AutoSize = true;
            this.LTurnosProgramados.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTurnosProgramados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.LTurnosProgramados.Location = new System.Drawing.Point(60, 13);
            this.LTurnosProgramados.Name = "LTurnosProgramados";
            this.LTurnosProgramados.Size = new System.Drawing.Size(236, 27);
            this.LTurnosProgramados.TabIndex = 0;
            this.LTurnosProgramados.Text = "Turnos Programados hoy";
            // 
            // PDoctores
            // 
            this.PDoctores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PDoctores.BackColor = System.Drawing.Color.PaleGreen;
            this.PDoctores.Controls.Add(this.LContadorDoctores);
            this.PDoctores.Controls.Add(this.pictureBox4);
            this.PDoctores.Controls.Add(this.LDoctores);
            this.PDoctores.Location = new System.Drawing.Point(554, 338);
            this.PDoctores.Name = "PDoctores";
            this.PDoctores.Size = new System.Drawing.Size(369, 138);
            this.PDoctores.TabIndex = 4;
            this.PDoctores.Click += new System.EventHandler(this.PDoctores_Click);
            // 
            // LContadorDoctores
            // 
            this.LContadorDoctores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LContadorDoctores.AutoSize = true;
            this.LContadorDoctores.BackColor = System.Drawing.Color.Transparent;
            this.LContadorDoctores.Font = new System.Drawing.Font("Constantia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LContadorDoctores.Location = new System.Drawing.Point(166, 85);
            this.LContadorDoctores.Name = "LContadorDoctores";
            this.LContadorDoctores.Size = new System.Drawing.Size(35, 39);
            this.LContadorDoctores.TabIndex = 8;
            this.LContadorDoctores.Text = "0";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(301, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(65, 50);
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // LDoctores
            // 
            this.LDoctores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LDoctores.AutoSize = true;
            this.LDoctores.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDoctores.Location = new System.Drawing.Point(87, 15);
            this.LDoctores.Name = "LDoctores";
            this.LDoctores.Size = new System.Drawing.Size(209, 27);
            this.LDoctores.TabIndex = 0;
            this.LDoctores.Text = "Doctores  Disponibles";
            // 
            // PEspecialidades
            // 
            this.PEspecialidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PEspecialidades.BackColor = System.Drawing.Color.PaleGreen;
            this.PEspecialidades.Controls.Add(this.pictureBox2);
            this.PEspecialidades.Controls.Add(this.LContadorEspecialidades);
            this.PEspecialidades.Controls.Add(this.label5);
            this.PEspecialidades.Location = new System.Drawing.Point(137, 338);
            this.PEspecialidades.Name = "PEspecialidades";
            this.PEspecialidades.Size = new System.Drawing.Size(375, 138);
            this.PEspecialidades.TabIndex = 6;
            // 
            // LContadorEspecialidades
            // 
            this.LContadorEspecialidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LContadorEspecialidades.AutoSize = true;
            this.LContadorEspecialidades.BackColor = System.Drawing.Color.Transparent;
            this.LContadorEspecialidades.Font = new System.Drawing.Font("Constantia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LContadorEspecialidades.Location = new System.Drawing.Point(161, 85);
            this.LContadorEspecialidades.Name = "LContadorEspecialidades";
            this.LContadorEspecialidades.Size = new System.Drawing.Size(35, 39);
            this.LContadorEspecialidades.TabIndex = 8;
            this.LContadorEspecialidades.Text = "0";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(114, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 27);
            this.label5.TabIndex = 0;
            this.label5.Text = "Especialidades";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.pnlTurnos.Location = new System.Drawing.Point(122, 82);
            this.pnlTurnos.Name = "pnlTurnos";
            this.pnlTurnos.Size = new System.Drawing.Size(811, 384);
            this.pnlTurnos.TabIndex = 7;
            this.pnlTurnos.Visible = false;
            // 
            // lblProfesionalMes
            // 
            this.lblProfesionalMes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProfesionalMes.AutoSize = true;
            this.lblProfesionalMes.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfesionalMes.Location = new System.Drawing.Point(359, 26);
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
            this.cmbMedicoMes.Location = new System.Drawing.Point(465, 25);
            this.cmbMedicoMes.Name = "cmbMedicoMes";
            this.cmbMedicoMes.Size = new System.Drawing.Size(198, 26);
            this.cmbMedicoMes.TabIndex = 13;
            this.cmbMedicoMes.SelectedIndexChanged += new System.EventHandler(this.cmbMedicoMes_SelectedIndexChanged);
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
            this.dtpSemana.ValueChanged += new System.EventHandler(this.dtpSemana_ValueChanged);
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVolver.Image = global::SaludSoft.Properties.Resources.circulo_marca_x;
            this.btnVolver.Location = new System.Drawing.Point(756, 3);
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
            this.dgvTurnosMes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTurnosMes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTurnosMes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
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
            this.dgvTurnosMes.Size = new System.Drawing.Size(795, 304);
            this.dgvTurnosMes.TabIndex = 11;
            this.dgvTurnosMes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurnosMes_CellContentClick);
            this.dgvTurnosMes.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTurnosMes_DataBindingComplete);
            // 
            // colFechaHora
            // 
            dataGridViewCellStyle10.Format = "g";
            dataGridViewCellStyle10.NullValue = null;
            this.colFechaHora.DefaultCellStyle = dataGridViewCellStyle10;
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
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = global::SaludSoft.Properties.Resources.libro_medico;
            this.pictureBox2.Location = new System.Drawing.Point(301, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // SaludSoft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(935, 523);
            this.Controls.Add(this.pnlTurnos);
            this.Controls.Add(this.PEspecialidades);
            this.Controls.Add(this.PDoctores);
            this.Controls.Add(this.PCitas);
            this.Controls.Add(this.PPacientes);
            this.Controls.Add(this.PSuperior);
            this.Controls.Add(this.PMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "SaludSoft";
            this.PMenu.ResumeLayout(false);
            this.PSuperior.ResumeLayout(false);
            this.PSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PPacientes.ResumeLayout(false);
            this.PPacientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PPacientesHoy)).EndInit();
            this.PCitas.ResumeLayout(false);
            this.PCitas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.PDoctores.ResumeLayout(false);
            this.PDoctores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.PEspecialidades.ResumeLayout(false);
            this.PEspecialidades.PerformLayout();
            this.pnlTurnos.ResumeLayout(false);
            this.pnlTurnos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnosMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PMenu;
        private System.Windows.Forms.Panel PSuperior;
        private System.Windows.Forms.Button BNuevaCita;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BTurnos;
        private System.Windows.Forms.Button BPacientes;
        private System.Windows.Forms.Label LRecepcionista;
        private System.Windows.Forms.Panel PPacientes;
        private System.Windows.Forms.Label LPacientesHoy;
        private System.Windows.Forms.Panel PCitas;
        private System.Windows.Forms.Label LTurnosProgramados;
        private System.Windows.Forms.Panel PDoctores;
        private System.Windows.Forms.Label LDoctores;
        private System.Windows.Forms.Panel PEspecialidades;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox PPacientesHoy;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button BNuevoPaciente;
        private System.Windows.Forms.Button BCerrarSesion;
        private System.Windows.Forms.Button BAgenda;
        private System.Windows.Forms.Label LContadorPacientesHoy;
        private System.Windows.Forms.Label LContadorTurnosHoy;
        private System.Windows.Forms.Label LContadorDoctores;
        private System.Windows.Forms.Label LContadorEspecialidades;
        private System.Windows.Forms.Panel pnlTurnos;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.DateTimePicker dtpSemana;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgvTurnosMes;
        private System.Windows.Forms.Label lblProfesionalMes;
        private System.Windows.Forms.ComboBox cmbMedicoMes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewButtonColumn colCancelar;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

