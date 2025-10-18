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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PMenu = new System.Windows.Forms.Panel();
            this.BCerrarSesion = new System.Windows.Forms.Button();
            this.BAgenda = new System.Windows.Forms.Button();
            this.BTurnos = new System.Windows.Forms.Button();
            this.BPacientes = new System.Windows.Forms.Button();
            this.PSuperior = new System.Windows.Forms.Panel();
            this.BNuevoPaciente = new System.Windows.Forms.Button();
            this.LRecepcionista = new System.Windows.Forms.Label();
            this.Label = new System.Windows.Forms.Label();
            this.LNombre = new System.Windows.Forms.Label();
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
            this.LTurnosSemana = new System.Windows.Forms.Label();
            this.lTitulo = new System.Windows.Forms.Label();
            this.dtpSemana = new System.Windows.Forms.DateTimePicker();
            this.btnActualizarSemana = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dgvTurnosSemana = new System.Windows.Forms.DataGridView();
            this.colFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colCancelar = new System.Windows.Forms.DataGridViewButtonColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnosSemana)).BeginInit();
            this.SuspendLayout();
            // 
            // PMenu
            // 
            this.PMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PMenu.Controls.Add(this.BCerrarSesion);
            this.PMenu.Controls.Add(this.BAgenda);
            this.PMenu.Controls.Add(this.BTurnos);
            this.PMenu.Controls.Add(this.BPacientes);
            this.PMenu.Location = new System.Drawing.Point(2, 72);
            this.PMenu.Name = "PMenu";
            this.PMenu.Size = new System.Drawing.Size(120, 453);
            this.PMenu.TabIndex = 0;
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
            this.BAgenda.Location = new System.Drawing.Point(6, 239);
            this.BAgenda.Name = "BAgenda";
            this.BAgenda.Size = new System.Drawing.Size(98, 35);
            this.BAgenda.TabIndex = 8;
            this.BAgenda.Text = "Agenda";
            this.BAgenda.UseVisualStyleBackColor = true;
            this.BAgenda.Click += new System.EventHandler(this.BAgenda_Click);
            // 
            // BTurnos
            // 
            this.BTurnos.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTurnos.Location = new System.Drawing.Point(9, 137);
            this.BTurnos.Name = "BTurnos";
            this.BTurnos.Size = new System.Drawing.Size(92, 41);
            this.BTurnos.TabIndex = 4;
            this.BTurnos.Text = "Turnos";
            this.BTurnos.UseVisualStyleBackColor = true;
            // 
            // BPacientes
            // 
            this.BPacientes.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPacientes.Location = new System.Drawing.Point(6, 37);
            this.BPacientes.Name = "BPacientes";
            this.BPacientes.Size = new System.Drawing.Size(102, 40);
            this.BPacientes.TabIndex = 5;
            this.BPacientes.Text = "Pacientes";
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
            this.PSuperior.Controls.Add(this.Label);
            this.PSuperior.Controls.Add(this.LNombre);
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
            this.BNuevoPaciente.Location = new System.Drawing.Point(779, 11);
            this.BNuevoPaciente.Name = "BNuevoPaciente";
            this.BNuevoPaciente.Size = new System.Drawing.Size(120, 54);
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
            this.LRecepcionista.Location = new System.Drawing.Point(139, 14);
            this.LRecepcionista.Name = "LRecepcionista";
            this.LRecepcionista.Size = new System.Drawing.Size(169, 34);
            this.LRecepcionista.TabIndex = 4;
            this.LRecepcionista.Text = "Recepcionista";
            // 
            // Label
            // 
            this.Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label.AutoSize = true;
            this.Label.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label.Location = new System.Drawing.Point(424, 46);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(206, 22);
            this.Label.TabIndex = 2;
            this.Label.Text = "Sistema de Gestión Médica";
            // 
            // LNombre
            // 
            this.LNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Comic Sans MS", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(465, 8);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(131, 34);
            this.LNombre.TabIndex = 3;
            this.LNombre.Text = "SaludSoft";
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
            this.BNuevaCita.Size = new System.Drawing.Size(108, 54);
            this.BNuevaCita.TabIndex = 0;
            this.BNuevaCita.Text = "+ Nuevo     Turno";
            this.BNuevaCita.UseVisualStyleBackColor = false;
            this.BNuevaCita.Click += new System.EventHandler(this.BNuevaCita_Click);
            // 
            // PPacientes
            // 
            this.PPacientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(249)))), ((int)(((byte)(240)))));
            this.PPacientes.Controls.Add(this.LContadorPacientesHoy);
            this.PPacientes.Controls.Add(this.PPacientesHoy);
            this.PPacientes.Controls.Add(this.LPacientesHoy);
            this.PPacientes.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PPacientes.Location = new System.Drawing.Point(171, 93);
            this.PPacientes.Name = "PPacientes";
            this.PPacientes.Size = new System.Drawing.Size(263, 100);
            this.PPacientes.TabIndex = 2;
            // 
            // LContadorPacientesHoy
            // 
            this.LContadorPacientesHoy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LContadorPacientesHoy.AutoSize = true;
            this.LContadorPacientesHoy.BackColor = System.Drawing.Color.Transparent;
            this.LContadorPacientesHoy.Font = new System.Drawing.Font("Constantia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LContadorPacientesHoy.Location = new System.Drawing.Point(81, 51);
            this.LContadorPacientesHoy.Name = "LContadorPacientesHoy";
            this.LContadorPacientesHoy.Size = new System.Drawing.Size(35, 39);
            this.LContadorPacientesHoy.TabIndex = 9;
            this.LContadorPacientesHoy.Text = "0";
            // 
            // PPacientesHoy
            // 
            this.PPacientesHoy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PPacientesHoy.BackgroundImage")));
            this.PPacientesHoy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PPacientesHoy.Location = new System.Drawing.Point(184, 0);
            this.PPacientesHoy.Name = "PPacientesHoy";
            this.PPacientesHoy.Size = new System.Drawing.Size(76, 37);
            this.PPacientesHoy.TabIndex = 8;
            this.PPacientesHoy.TabStop = false;
            // 
            // LPacientesHoy
            // 
            this.LPacientesHoy.AutoSize = true;
            this.LPacientesHoy.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPacientesHoy.Location = new System.Drawing.Point(21, 6);
            this.LPacientesHoy.Name = "LPacientesHoy";
            this.LPacientesHoy.Size = new System.Drawing.Size(118, 23);
            this.LPacientesHoy.TabIndex = 0;
            this.LPacientesHoy.Text = "Pacientes Hoy";
            // 
            // PCitas
            // 
            this.PCitas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PCitas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(235)))));
            this.PCitas.Controls.Add(this.LContadorTurnosHoy);
            this.PCitas.Controls.Add(this.pictureBox3);
            this.PCitas.Controls.Add(this.LTurnosProgramados);
            this.PCitas.Location = new System.Drawing.Point(634, 93);
            this.PCitas.Name = "PCitas";
            this.PCitas.Size = new System.Drawing.Size(254, 111);
            this.PCitas.TabIndex = 3;
            // 
            // LContadorTurnosHoy
            // 
            this.LContadorTurnosHoy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LContadorTurnosHoy.AutoSize = true;
            this.LContadorTurnosHoy.BackColor = System.Drawing.Color.Transparent;
            this.LContadorTurnosHoy.Font = new System.Drawing.Font("Constantia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LContadorTurnosHoy.Location = new System.Drawing.Point(102, 61);
            this.LContadorTurnosHoy.Name = "LContadorTurnosHoy";
            this.LContadorTurnosHoy.Size = new System.Drawing.Size(35, 39);
            this.LContadorTurnosHoy.TabIndex = 9;
            this.LContadorTurnosHoy.Text = "0";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(202, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(47, 53);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // LTurnosProgramados
            // 
            this.LTurnosProgramados.AutoSize = true;
            this.LTurnosProgramados.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTurnosProgramados.Location = new System.Drawing.Point(3, 6);
            this.LTurnosProgramados.Name = "LTurnosProgramados";
            this.LTurnosProgramados.Size = new System.Drawing.Size(198, 23);
            this.LTurnosProgramados.TabIndex = 0;
            this.LTurnosProgramados.Text = "Turnos Programados hoy";
            // 
            // PDoctores
            // 
            this.PDoctores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PDoctores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.PDoctores.Controls.Add(this.LContadorDoctores);
            this.PDoctores.Controls.Add(this.pictureBox4);
            this.PDoctores.Controls.Add(this.LDoctores);
            this.PDoctores.Location = new System.Drawing.Point(634, 376);
            this.PDoctores.Name = "PDoctores";
            this.PDoctores.Size = new System.Drawing.Size(264, 100);
            this.PDoctores.TabIndex = 4;
            this.PDoctores.Click += new System.EventHandler(this.PDoctores_Click);
            // 
            // LContadorDoctores
            // 
            this.LContadorDoctores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LContadorDoctores.AutoSize = true;
            this.LContadorDoctores.BackColor = System.Drawing.Color.Transparent;
            this.LContadorDoctores.Font = new System.Drawing.Font("Constantia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LContadorDoctores.Location = new System.Drawing.Point(95, 51);
            this.LContadorDoctores.Name = "LContadorDoctores";
            this.LContadorDoctores.Size = new System.Drawing.Size(35, 39);
            this.LContadorDoctores.TabIndex = 8;
            this.LContadorDoctores.Text = "0";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(195, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(65, 50);
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // LDoctores
            // 
            this.LDoctores.AutoSize = true;
            this.LDoctores.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDoctores.Location = new System.Drawing.Point(18, 11);
            this.LDoctores.Name = "LDoctores";
            this.LDoctores.Size = new System.Drawing.Size(177, 23);
            this.LDoctores.TabIndex = 0;
            this.LDoctores.Text = "Doctores  Disponibles";
            // 
            // PEspecialidades
            // 
            this.PEspecialidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PEspecialidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.PEspecialidades.Controls.Add(this.LContadorEspecialidades);
            this.PEspecialidades.Controls.Add(this.label5);
            this.PEspecialidades.Location = new System.Drawing.Point(171, 376);
            this.PEspecialidades.Name = "PEspecialidades";
            this.PEspecialidades.Size = new System.Drawing.Size(260, 100);
            this.PEspecialidades.TabIndex = 6;
            // 
            // LContadorEspecialidades
            // 
            this.LContadorEspecialidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LContadorEspecialidades.AutoSize = true;
            this.LContadorEspecialidades.BackColor = System.Drawing.Color.Transparent;
            this.LContadorEspecialidades.Font = new System.Drawing.Font("Constantia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LContadorEspecialidades.Location = new System.Drawing.Point(104, 51);
            this.LContadorEspecialidades.Name = "LContadorEspecialidades";
            this.LContadorEspecialidades.Size = new System.Drawing.Size(35, 39);
            this.LContadorEspecialidades.TabIndex = 8;
            this.LContadorEspecialidades.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(72, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Especialidades";
            // 
            // pnlTurnos
            // 
            this.pnlTurnos.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlTurnos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTurnos.Controls.Add(this.LTurnosSemana);
            this.pnlTurnos.Controls.Add(this.lTitulo);
            this.pnlTurnos.Controls.Add(this.dtpSemana);
            this.pnlTurnos.Controls.Add(this.btnActualizarSemana);
            this.pnlTurnos.Controls.Add(this.btnVolver);
            this.pnlTurnos.Controls.Add(this.dgvTurnosSemana);
            this.pnlTurnos.Location = new System.Drawing.Point(389, 233);
            this.pnlTurnos.Name = "pnlTurnos";
            this.pnlTurnos.Size = new System.Drawing.Size(263, 100);
            this.pnlTurnos.TabIndex = 7;
            this.pnlTurnos.Visible = false;
            // 
            // LTurnosSemana
            // 
            this.LTurnosSemana.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LTurnosSemana.AutoSize = true;
            this.LTurnosSemana.BackColor = System.Drawing.Color.Transparent;
            this.LTurnosSemana.Font = new System.Drawing.Font("Constantia", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTurnosSemana.Location = new System.Drawing.Point(98, 50);
            this.LTurnosSemana.Name = "LTurnosSemana";
            this.LTurnosSemana.Size = new System.Drawing.Size(35, 39);
            this.LTurnosSemana.TabIndex = 12;
            this.LTurnosSemana.Text = "0";
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitulo.Location = new System.Drawing.Point(34, 15);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(168, 23);
            this.lTitulo.TabIndex = 7;
            this.lTitulo.Text = "Turnos de la semana";
            // 
            // dtpSemana
            // 
            this.dtpSemana.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpSemana.CustomFormat = "dd/MM/yyyy";
            this.dtpSemana.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSemana.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSemana.Location = new System.Drawing.Point(340, 256);
            this.dtpSemana.Name = "dtpSemana";
            this.dtpSemana.ShowUpDown = true;
            this.dtpSemana.Size = new System.Drawing.Size(0, 26);
            this.dtpSemana.TabIndex = 8;
            // 
            // btnActualizarSemana
            // 
            this.btnActualizarSemana.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnActualizarSemana.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnActualizarSemana.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarSemana.Image = global::SaludSoft.Properties.Resources.actualizar;
            this.btnActualizarSemana.Location = new System.Drawing.Point(473, 245);
            this.btnActualizarSemana.Name = "btnActualizarSemana";
            this.btnActualizarSemana.Size = new System.Drawing.Size(40, 37);
            this.btnActualizarSemana.TabIndex = 9;
            this.btnActualizarSemana.UseVisualStyleBackColor = false;
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVolver.Image = global::SaludSoft.Properties.Resources.circulo_marca_x;
            this.btnVolver.Location = new System.Drawing.Point(317, 218);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(50, 30);
            this.btnVolver.TabIndex = 10;
            this.btnVolver.UseVisualStyleBackColor = false;
            // 
            // dgvTurnosSemana
            // 
            this.dgvTurnosSemana.AllowUserToAddRows = false;
            this.dgvTurnosSemana.AllowUserToDeleteRows = false;
            this.dgvTurnosSemana.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTurnosSemana.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTurnosSemana.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTurnosSemana.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnosSemana.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFechaHora,
            this.colPaciente,
            this.colProfesional,
            this.colMotivo,
            this.colEstado,
            this.colEditar,
            this.colCancelar});
            this.dgvTurnosSemana.EnableHeadersVisualStyles = false;
            this.dgvTurnosSemana.Location = new System.Drawing.Point(123, 228);
            this.dgvTurnosSemana.MultiSelect = false;
            this.dgvTurnosSemana.Name = "dgvTurnosSemana";
            this.dgvTurnosSemana.ReadOnly = true;
            this.dgvTurnosSemana.RowHeadersVisible = false;
            this.dgvTurnosSemana.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnosSemana.Size = new System.Drawing.Size(216, 78);
            this.dgvTurnosSemana.TabIndex = 11;
            // 
            // colFechaHora
            // 
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
            this.colEditar.UseColumnTextForButtonValue = true;
            // 
            // colCancelar
            // 
            this.colCancelar.HeaderText = "Cancelar";
            this.colCancelar.Name = "colCancelar";
            this.colCancelar.ReadOnly = true;
            this.colCancelar.UseColumnTextForButtonValue = true;
            // 
            // SaludSoft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnosSemana)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PMenu;
        private System.Windows.Forms.Panel PSuperior;
        private System.Windows.Forms.Button BNuevaCita;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BTurnos;
        private System.Windows.Forms.Button BPacientes;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Label LNombre;
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
        private System.Windows.Forms.Button btnActualizarSemana;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgvTurnosSemana;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewButtonColumn colCancelar;
        private System.Windows.Forms.Label LTurnosSemana;
    }
}

