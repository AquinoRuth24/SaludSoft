namespace SaludSoft
{
    partial class FormAgenda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BVolverAgenda = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LGestionAgenda = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LProfesional = new System.Windows.Forms.Label();
            this.CMBProfesionales = new System.Windows.Forms.ComboBox();
            this.pnIzquierdo = new System.Windows.Forms.Panel();
            this.gbSeleccionarFecha = new System.Windows.Forms.GroupBox();
            this.mcFecha = new System.Windows.Forms.MonthCalendar();
            this.pnlDerecho = new System.Windows.Forms.Panel();
            this.gbFranjaHoraria = new System.Windows.Forms.GroupBox();
            this.flpFranjas = new System.Windows.Forms.FlowLayoutPanel();
            this.lDisponibles = new System.Windows.Forms.Label();
            this.btSobreturno = new System.Windows.Forms.Button();
            this.gbTurnosDia = new System.Windows.Forms.GroupBox();
            this.DTVGAgenda = new System.Windows.Forms.DataGridView();
            this.colFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colCancelar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tlRootAgenda = new System.Windows.Forms.TableLayoutPanel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnIzquierdo.SuspendLayout();
            this.gbSeleccionarFecha.SuspendLayout();
            this.pnlDerecho.SuspendLayout();
            this.gbFranjaHoraria.SuspendLayout();
            this.gbTurnosDia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTVGAgenda)).BeginInit();
            this.tlRootAgenda.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.BVolverAgenda);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.LGestionAgenda);
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1041, 49);
            this.panel2.TabIndex = 5;
            // 
            // BVolverAgenda
            // 
            this.BVolverAgenda.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVolverAgenda.Image = global::SaludSoft.Properties.Resources.angulo_izquierdo;
            this.BVolverAgenda.Location = new System.Drawing.Point(15, 6);
            this.BVolverAgenda.Name = "BVolverAgenda";
            this.BVolverAgenda.Size = new System.Drawing.Size(81, 38);
            this.BVolverAgenda.TabIndex = 8;
            this.BVolverAgenda.UseVisualStyleBackColor = true;
            this.BVolverAgenda.Click += new System.EventHandler(this.BVolverAgenda_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // LGestionAgenda
            // 
            this.LGestionAgenda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LGestionAgenda.AutoSize = true;
            this.LGestionAgenda.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LGestionAgenda.Location = new System.Drawing.Point(407, 6);
            this.LGestionAgenda.Name = "LGestionAgenda";
            this.LGestionAgenda.Size = new System.Drawing.Size(205, 29);
            this.LGestionAgenda.TabIndex = 1;
            this.LGestionAgenda.Text = "Gestión De Agenda";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.LProfesional);
            this.panel3.Controls.Add(this.CMBProfesionales);
            this.panel3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(0, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1041, 48);
            this.panel3.TabIndex = 7;
            // 
            // LProfesional
            // 
            this.LProfesional.AutoSize = true;
            this.LProfesional.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProfesional.Location = new System.Drawing.Point(145, 14);
            this.LProfesional.Name = "LProfesional";
            this.LProfesional.Size = new System.Drawing.Size(96, 23);
            this.LProfesional.TabIndex = 15;
            this.LProfesional.Text = "Profesional:";
            // 
            // CMBProfesionales
            // 
            this.CMBProfesionales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CMBProfesionales.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMBProfesionales.FormattingEnabled = true;
            this.CMBProfesionales.Location = new System.Drawing.Point(258, 9);
            this.CMBProfesionales.Name = "CMBProfesionales";
            this.CMBProfesionales.Size = new System.Drawing.Size(229, 28);
            this.CMBProfesionales.TabIndex = 12;
            // 
            // pnIzquierdo
            // 
            this.pnIzquierdo.Controls.Add(this.gbSeleccionarFecha);
            this.pnIzquierdo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnIzquierdo.Location = new System.Drawing.Point(3, 3);
            this.pnIzquierdo.Name = "pnIzquierdo";
            this.pnIzquierdo.Size = new System.Drawing.Size(502, 217);
            this.pnIzquierdo.TabIndex = 8;
            // 
            // gbSeleccionarFecha
            // 
            this.gbSeleccionarFecha.Controls.Add(this.mcFecha);
            this.gbSeleccionarFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSeleccionarFecha.Location = new System.Drawing.Point(0, 0);
            this.gbSeleccionarFecha.Margin = new System.Windows.Forms.Padding(0);
            this.gbSeleccionarFecha.Name = "gbSeleccionarFecha";
            this.gbSeleccionarFecha.Padding = new System.Windows.Forms.Padding(12);
            this.gbSeleccionarFecha.Size = new System.Drawing.Size(502, 217);
            this.gbSeleccionarFecha.TabIndex = 9;
            this.gbSeleccionarFecha.TabStop = false;
            this.gbSeleccionarFecha.Enter += new System.EventHandler(this.gbSeleccionarFecha_Enter);
            // 
            // mcFecha
            // 
            this.mcFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mcFecha.BackColor = System.Drawing.Color.White;
            this.mcFecha.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mcFecha.Location = new System.Drawing.Point(134, 33);
            this.mcFecha.MaxSelectionCount = 1;
            this.mcFecha.Name = "mcFecha";
            this.mcFecha.TabIndex = 0;
            this.mcFecha.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mcFecha.TrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            // 
            // pnlDerecho
            // 
            this.pnlDerecho.Controls.Add(this.gbFranjaHoraria);
            this.pnlDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDerecho.Location = new System.Drawing.Point(511, 3);
            this.pnlDerecho.Name = "pnlDerecho";
            this.pnlDerecho.Size = new System.Drawing.Size(502, 217);
            this.pnlDerecho.TabIndex = 9;
            // 
            // gbFranjaHoraria
            // 
            this.gbFranjaHoraria.Controls.Add(this.flpFranjas);
            this.gbFranjaHoraria.Controls.Add(this.lDisponibles);
            this.gbFranjaHoraria.Controls.Add(this.btSobreturno);
            this.gbFranjaHoraria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFranjaHoraria.Location = new System.Drawing.Point(0, 0);
            this.gbFranjaHoraria.Margin = new System.Windows.Forms.Padding(0);
            this.gbFranjaHoraria.Name = "gbFranjaHoraria";
            this.gbFranjaHoraria.Padding = new System.Windows.Forms.Padding(12);
            this.gbFranjaHoraria.Size = new System.Drawing.Size(502, 217);
            this.gbFranjaHoraria.TabIndex = 0;
            this.gbFranjaHoraria.TabStop = false;
            // 
            // flpFranjas
            // 
            this.flpFranjas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpFranjas.AutoScroll = true;
            this.flpFranjas.AutoSize = true;
            this.flpFranjas.Location = new System.Drawing.Point(12, 54);
            this.flpFranjas.Margin = new System.Windows.Forms.Padding(0);
            this.flpFranjas.Name = "flpFranjas";
            this.flpFranjas.Padding = new System.Windows.Forms.Padding(8);
            this.flpFranjas.Size = new System.Drawing.Size(478, 141);
            this.flpFranjas.TabIndex = 2;
            // 
            // lDisponibles
            // 
            this.lDisponibles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lDisponibles.AutoSize = true;
            this.lDisponibles.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDisponibles.Location = new System.Drawing.Point(69, 25);
            this.lDisponibles.Name = "lDisponibles";
            this.lDisponibles.Size = new System.Drawing.Size(126, 19);
            this.lDisponibles.TabIndex = 1;
            this.lDisponibles.Text = "\"-de- disponibles\"";
            // 
            // btSobreturno
            // 
            this.btSobreturno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSobreturno.BackColor = System.Drawing.Color.Green;
            this.btSobreturno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSobreturno.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSobreturno.Image = global::SaludSoft.Properties.Resources.agregar;
            this.btSobreturno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSobreturno.Location = new System.Drawing.Point(369, 18);
            this.btSobreturno.Name = "btSobreturno";
            this.btSobreturno.Size = new System.Drawing.Size(124, 33);
            this.btSobreturno.TabIndex = 0;
            this.btSobreturno.Text = "Sobreturno";
            this.btSobreturno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSobreturno.UseVisualStyleBackColor = false;
            this.btSobreturno.Click += new System.EventHandler(this.btSobreturno_Click);
            // 
            // gbTurnosDia
            // 
            this.gbTurnosDia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTurnosDia.Controls.Add(this.DTVGAgenda);
            this.gbTurnosDia.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTurnosDia.Location = new System.Drawing.Point(12, 334);
            this.gbTurnosDia.Name = "gbTurnosDia";
            this.gbTurnosDia.Size = new System.Drawing.Size(1016, 182);
            this.gbTurnosDia.TabIndex = 10;
            this.gbTurnosDia.TabStop = false;
            this.gbTurnosDia.Text = "Turnos del día";
            // 
            // DTVGAgenda
            // 
            this.DTVGAgenda.AllowUserToAddRows = false;
            this.DTVGAgenda.AllowUserToDeleteRows = false;
            this.DTVGAgenda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTVGAgenda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DTVGAgenda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DTVGAgenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTVGAgenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFechaHora,
            this.colPaciente,
            this.colProfesional,
            this.colMotivo,
            this.colEstado,
            this.colEditar,
            this.colCancelar});
            this.DTVGAgenda.EnableHeadersVisualStyles = false;
            this.DTVGAgenda.Location = new System.Drawing.Point(3, 22);
            this.DTVGAgenda.MultiSelect = false;
            this.DTVGAgenda.Name = "DTVGAgenda";
            this.DTVGAgenda.ReadOnly = true;
            this.DTVGAgenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DTVGAgenda.Size = new System.Drawing.Size(1010, 164);
            this.DTVGAgenda.TabIndex = 0;
            // 
            // colFechaHora
            // 
            dataGridViewCellStyle8.Format = "f";
            dataGridViewCellStyle8.NullValue = null;
            this.colFechaHora.DefaultCellStyle = dataGridViewCellStyle8;
            this.colFechaHora.HeaderText = "Fecha/hora";
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
            // tlRootAgenda
            // 
            this.tlRootAgenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlRootAgenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tlRootAgenda.ColumnCount = 2;
            this.tlRootAgenda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlRootAgenda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlRootAgenda.Controls.Add(this.pnIzquierdo, 0, 0);
            this.tlRootAgenda.Controls.Add(this.pnlDerecho, 1, 0);
            this.tlRootAgenda.Location = new System.Drawing.Point(12, 105);
            this.tlRootAgenda.Name = "tlRootAgenda";
            this.tlRootAgenda.RowCount = 1;
            this.tlRootAgenda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlRootAgenda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlRootAgenda.Size = new System.Drawing.Size(1016, 223);
            this.tlRootAgenda.TabIndex = 11;
            // 
            // FormAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1040, 518);
            this.Controls.Add(this.tlRootAgenda);
            this.Controls.Add(this.gbTurnosDia);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "FormAgenda";
            this.Text = "FormAgenda";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnIzquierdo.ResumeLayout(false);
            this.gbSeleccionarFecha.ResumeLayout(false);
            this.pnlDerecho.ResumeLayout(false);
            this.gbFranjaHoraria.ResumeLayout(false);
            this.gbFranjaHoraria.PerformLayout();
            this.gbTurnosDia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DTVGAgenda)).EndInit();
            this.tlRootAgenda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LGestionAgenda;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LProfesional;
        private System.Windows.Forms.ComboBox CMBProfesionales;
        private System.Windows.Forms.Button BVolverAgenda;
        private System.Windows.Forms.Panel pnIzquierdo;
        private System.Windows.Forms.MonthCalendar mcFecha;
        private System.Windows.Forms.GroupBox gbSeleccionarFecha;
        private System.Windows.Forms.Panel pnlDerecho;
        private System.Windows.Forms.GroupBox gbFranjaHoraria;
        private System.Windows.Forms.Label lDisponibles;
        private System.Windows.Forms.Button btSobreturno;
        private System.Windows.Forms.FlowLayoutPanel flpFranjas;
        private System.Windows.Forms.GroupBox gbTurnosDia;
        private System.Windows.Forms.DataGridView DTVGAgenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewButtonColumn colEditar;
        private System.Windows.Forms.DataGridViewButtonColumn colCancelar;
        private System.Windows.Forms.TableLayoutPanel tlRootAgenda;
    }
}