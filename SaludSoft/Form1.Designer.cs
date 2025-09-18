namespace SaludSoft.Resources
{
    partial class FormGestionUsuario
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
            this.lTitulo = new System.Windows.Forms.Label();
            this.lUsuario = new System.Windows.Forms.Label();
            this.tbBuscar = new System.Windows.Forms.TextBox();
            this.cbTipos = new System.Windows.Forms.ComboBox();
            this.cbeliminados = new System.Windows.Forms.CheckBox();
            this.dgUsuario = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btAgregarUsuario = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btCerrarSesion = new System.Windows.Forms.Button();
            this.btBakup = new System.Windows.Forms.Button();
            this.btTurnos = new System.Windows.Forms.Button();
            this.btConsultorio = new System.Windows.Forms.Button();
            this.btMedico = new System.Windows.Forms.Button();
            this.btUsuarios = new System.Windows.Forms.Button();
            this.btInicio = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.btCerrarSesion);
            this.panel1.Controls.Add(this.btBakup);
            this.panel1.Controls.Add(this.btTurnos);
            this.panel1.Controls.Add(this.btConsultorio);
            this.panel1.Controls.Add(this.btMedico);
            this.panel1.Controls.Add(this.btUsuarios);
            this.panel1.Controls.Add(this.btInicio);
            this.panel1.Location = new System.Drawing.Point(0, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 561);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.btAgregarUsuario);
            this.panel2.Controls.Add(this.lTitulo);
            this.panel2.Location = new System.Drawing.Point(196, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(751, 100);
            this.panel2.TabIndex = 2;
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.BackColor = System.Drawing.Color.White;
            this.lTitulo.Font = new System.Drawing.Font("Comic Sans MS", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitulo.Location = new System.Drawing.Point(231, 27);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(283, 40);
            this.lTitulo.TabIndex = 3;
            this.lTitulo.Text = "Gestión de usuarios";
            // 
            // lUsuario
            // 
            this.lUsuario.AutoSize = true;
            this.lUsuario.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUsuario.Location = new System.Drawing.Point(217, 119);
            this.lUsuario.Name = "lUsuario";
            this.lUsuario.Size = new System.Drawing.Size(114, 29);
            this.lUsuario.TabIndex = 3;
            this.lUsuario.Text = "Usuarios: ";
            // 
            // tbBuscar
            // 
            this.tbBuscar.Location = new System.Drawing.Point(337, 119);
            this.tbBuscar.Name = "tbBuscar";
            this.tbBuscar.Size = new System.Drawing.Size(209, 26);
            this.tbBuscar.TabIndex = 4;
            // 
            // cbTipos
            // 
            this.cbTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipos.FormattingEnabled = true;
            this.cbTipos.Items.AddRange(new object[] {
            "Todos los tipos",
            "Paciente",
            "Médico",
            "Recepcionista",
            "Administrador"});
            this.cbTipos.Location = new System.Drawing.Point(222, 188);
            this.cbTipos.Name = "cbTipos";
            this.cbTipos.Size = new System.Drawing.Size(324, 28);
            this.cbTipos.TabIndex = 5;
            this.cbTipos.SelectionChangeCommitted += new System.EventHandler(this.cbTipos_SelectionChangeCommitted);
            // 
            // cbeliminados
            // 
            this.cbeliminados.AutoSize = true;
            this.cbeliminados.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbeliminados.Location = new System.Drawing.Point(716, 138);
            this.cbeliminados.Name = "cbeliminados";
            this.cbeliminados.Size = new System.Drawing.Size(226, 33);
            this.cbeliminados.TabIndex = 6;
            this.cbeliminados.Text = "Mostrar Eliminados";
            this.cbeliminados.UseVisualStyleBackColor = true;
            // 
            // dgUsuario
            // 
            this.dgUsuario.AllowUserToAddRows = false;
            this.dgUsuario.AllowUserToDeleteRows = false;
            this.dgUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgUsuario.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.colUsuario,
            this.colTipo,
            this.colContacto,
            this.colEstado,
            this.colAcciones});
            this.dgUsuario.EnableHeadersVisualStyles = false;
            this.dgUsuario.GridColor = System.Drawing.SystemColors.Control;
            this.dgUsuario.Location = new System.Drawing.Point(222, 259);
            this.dgUsuario.MultiSelect = false;
            this.dgUsuario.Name = "dgUsuario";
            this.dgUsuario.ReadOnly = true;
            this.dgUsuario.RowHeadersVisible = false;
            this.dgUsuario.RowHeadersWidth = 62;
            this.dgUsuario.RowTemplate.Height = 28;
            this.dgUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgUsuario.Size = new System.Drawing.Size(693, 188);
            this.dgUsuario.TabIndex = 7;
            this.dgUsuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgUsuario.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgUsuario_CellMouseClick);
            this.dgUsuario.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgUsuario_CellPainting);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::SaludSoft.Properties.Resources.archivo_de_edicion;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.MinimumWidth = 8;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.Visible = false;
            this.dataGridViewImageColumn1.Width = 150;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::SaludSoft.Properties.Resources.basura;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.MinimumWidth = 8;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn2.Visible = false;
            this.dataGridViewImageColumn2.Width = 150;
            // 
            // btAgregarUsuario
            // 
            this.btAgregarUsuario.Image = global::SaludSoft.Properties.Resources.agregar_usuario;
            this.btAgregarUsuario.Location = new System.Drawing.Point(609, 32);
            this.btAgregarUsuario.Name = "btAgregarUsuario";
            this.btAgregarUsuario.Size = new System.Drawing.Size(75, 41);
            this.btAgregarUsuario.TabIndex = 7;
            this.btAgregarUsuario.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SaludSoft.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btCerrarSesion
            // 
            this.btCerrarSesion.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCerrarSesion.Image = global::SaludSoft.Properties.Resources.circulo_marca_x;
            this.btCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCerrarSesion.Location = new System.Drawing.Point(6, 505);
            this.btCerrarSesion.Name = "btCerrarSesion";
            this.btCerrarSesion.Size = new System.Drawing.Size(178, 42);
            this.btCerrarSesion.TabIndex = 3;
            this.btCerrarSesion.Text = "Cerrar Sesión";
            this.btCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // btBakup
            // 
            this.btBakup.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBakup.Image = global::SaludSoft.Properties.Resources.monedas;
            this.btBakup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBakup.Location = new System.Drawing.Point(27, 400);
            this.btBakup.Name = "btBakup";
            this.btBakup.Size = new System.Drawing.Size(135, 44);
            this.btBakup.TabIndex = 3;
            this.btBakup.Text = "Backup";
            this.btBakup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBakup.UseVisualStyleBackColor = true;
            // 
            // btTurnos
            // 
            this.btTurnos.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTurnos.Image = global::SaludSoft.Properties.Resources.alt_de_inventario;
            this.btTurnos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btTurnos.Location = new System.Drawing.Point(27, 329);
            this.btTurnos.Name = "btTurnos";
            this.btTurnos.Size = new System.Drawing.Size(138, 53);
            this.btTurnos.TabIndex = 3;
            this.btTurnos.Text = "Turnos ";
            this.btTurnos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btTurnos.UseVisualStyleBackColor = true;
            // 
            // btConsultorio
            // 
            this.btConsultorio.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConsultorio.Image = global::SaludSoft.Properties.Resources.construccion_de_casas;
            this.btConsultorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btConsultorio.Location = new System.Drawing.Point(3, 247);
            this.btConsultorio.Name = "btConsultorio";
            this.btConsultorio.Size = new System.Drawing.Size(181, 57);
            this.btConsultorio.TabIndex = 3;
            this.btConsultorio.Text = "Consultorios ";
            this.btConsultorio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btConsultorio.UseVisualStyleBackColor = true;
            // 
            // btMedico
            // 
            this.btMedico.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMedico.Image = global::SaludSoft.Properties.Resources.equipo_medico;
            this.btMedico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMedico.Location = new System.Drawing.Point(12, 161);
            this.btMedico.Name = "btMedico";
            this.btMedico.Size = new System.Drawing.Size(166, 63);
            this.btMedico.TabIndex = 3;
            this.btMedico.Text = "Médicos ";
            this.btMedico.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMedico.UseVisualStyleBackColor = true;
            // 
            // btUsuarios
            // 
            this.btUsuarios.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUsuarios.Image = global::SaludSoft.Properties.Resources.usuario;
            this.btUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btUsuarios.Location = new System.Drawing.Point(12, 90);
            this.btUsuarios.Name = "btUsuarios";
            this.btUsuarios.Size = new System.Drawing.Size(153, 55);
            this.btUsuarios.TabIndex = 3;
            this.btUsuarios.Text = "Usuarios ";
            this.btUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btUsuarios.UseVisualStyleBackColor = true;
            // 
            // btInicio
            // 
            this.btInicio.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInicio.Image = global::SaludSoft.Properties.Resources.hogar;
            this.btInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btInicio.Location = new System.Drawing.Point(27, 21);
            this.btInicio.Name = "btInicio";
            this.btInicio.Size = new System.Drawing.Size(136, 54);
            this.btInicio.TabIndex = 3;
            this.btInicio.Text = "Inicio ";
            this.btInicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btInicio.UseVisualStyleBackColor = true;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // colUsuario
            // 
            this.colUsuario.HeaderText = "USUARIO";
            this.colUsuario.MinimumWidth = 8;
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.ReadOnly = true;
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.MinimumWidth = 8;
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            // 
            // colContacto
            // 
            this.colContacto.HeaderText = "Contacto";
            this.colContacto.MinimumWidth = 8;
            this.colContacto.Name = "colContacto";
            this.colContacto.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.HeaderText = "Estado";
            this.colEstado.MinimumWidth = 8;
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // colAcciones
            // 
            this.colAcciones.HeaderText = "Acciones";
            this.colAcciones.MinimumWidth = 8;
            this.colAcciones.Name = "colAcciones";
            this.colAcciones.ReadOnly = true;
            // 
            // FormGestionUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(948, 657);
            this.Controls.Add(this.dgUsuario);
            this.Controls.Add(this.cbeliminados);
            this.Controls.Add(this.cbTipos);
            this.Controls.Add(this.tbBuscar);
            this.Controls.Add(this.lUsuario);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FormGestionUsuario";
            this.Text = "FormGestionUsuario";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.Button btInicio;
        private System.Windows.Forms.Button btConsultorio;
        private System.Windows.Forms.Button btMedico;
        private System.Windows.Forms.Button btUsuarios;
        private System.Windows.Forms.Button btCerrarSesion;
        private System.Windows.Forms.Button btBakup;
        private System.Windows.Forms.Button btTurnos;
        private System.Windows.Forms.Label lUsuario;
        private System.Windows.Forms.TextBox tbBuscar;
        private System.Windows.Forms.ComboBox cbTipos;
        private System.Windows.Forms.CheckBox cbeliminados;
        private System.Windows.Forms.Button btAgregarUsuario;
        private System.Windows.Forms.DataGridView dgUsuario;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAcciones;
    }
}