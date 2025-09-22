namespace SaludSoft
{
    partial class FormEditarHistorial
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
            this.lTitulo = new System.Windows.Forms.Label();
            this.brVolver = new System.Windows.Forms.Button();
            this.btGuardar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.lPaciente = new System.Windows.Forms.Label();
            this.lValorPaciente = new System.Windows.Forms.Label();
            this.lFecha = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lDiag = new System.Windows.Forms.Label();
            this.tbDiag = new System.Windows.Forms.TextBox();
            this.lTrat = new System.Windows.Forms.Label();
            this.tbTrat = new System.Windows.Forms.TextBox();
            this.lObserv = new System.Windows.Forms.Label();
            this.tbObserv = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.brVolver);
            this.panel1.Controls.Add(this.lTitulo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 72);
            this.panel1.TabIndex = 0;
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.BackColor = System.Drawing.Color.White;
            this.lTitulo.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitulo.Location = new System.Drawing.Point(279, 21);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(210, 27);
            this.lTitulo.TabIndex = 1;
            this.lTitulo.Text = "Editar historia clínica";
            // 
            // brVolver
            // 
            this.brVolver.Image = global::SaludSoft.Properties.Resources.angulo_izquierdo;
            this.brVolver.Location = new System.Drawing.Point(24, 12);
            this.brVolver.Name = "brVolver";
            this.brVolver.Size = new System.Drawing.Size(63, 36);
            this.brVolver.TabIndex = 1;
            this.brVolver.UseVisualStyleBackColor = true;
            this.brVolver.Click += new System.EventHandler(this.brVolver_Click);
            // 
            // btGuardar
            // 
            this.btGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btGuardar.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardar.Location = new System.Drawing.Point(485, 383);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(107, 39);
            this.btGuardar.TabIndex = 1;
            this.btGuardar.Text = "Guardar";
            this.btGuardar.UseVisualStyleBackColor = false;
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btCancelar.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Location = new System.Drawing.Point(632, 383);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(109, 39);
            this.btCancelar.TabIndex = 2;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // lPaciente
            // 
            this.lPaciente.AutoSize = true;
            this.lPaciente.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPaciente.Location = new System.Drawing.Point(44, 90);
            this.lPaciente.Name = "lPaciente";
            this.lPaciente.Size = new System.Drawing.Size(88, 23);
            this.lPaciente.TabIndex = 3;
            this.lPaciente.Text = "Paciente: ";
            // 
            // lValorPaciente
            // 
            this.lValorPaciente.AutoSize = true;
            this.lValorPaciente.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lValorPaciente.Location = new System.Drawing.Point(132, 90);
            this.lValorPaciente.Name = "lValorPaciente";
            this.lValorPaciente.Size = new System.Drawing.Size(30, 23);
            this.lValorPaciente.TabIndex = 4;
            this.lValorPaciente.Text = "--";
            // 
            // lFecha
            // 
            this.lFecha.AutoSize = true;
            this.lFecha.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFecha.Location = new System.Drawing.Point(44, 123);
            this.lFecha.Name = "lFecha";
            this.lFecha.Size = new System.Drawing.Size(69, 23);
            this.lFecha.TabIndex = 5;
            this.lFecha.Text = "Fecha: ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(110, 120);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(111, 26);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // lDiag
            // 
            this.lDiag.AutoSize = true;
            this.lDiag.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDiag.Location = new System.Drawing.Point(44, 166);
            this.lDiag.Name = "lDiag";
            this.lDiag.Size = new System.Drawing.Size(110, 23);
            this.lDiag.TabIndex = 7;
            this.lDiag.Text = "Diagnóstico: ";
            // 
            // tbDiag
            // 
            this.tbDiag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDiag.Location = new System.Drawing.Point(160, 170);
            this.tbDiag.Multiline = true;
            this.tbDiag.Name = "tbDiag";
            this.tbDiag.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDiag.Size = new System.Drawing.Size(175, 20);
            this.tbDiag.TabIndex = 8;
            // 
            // lTrat
            // 
            this.lTrat.AutoSize = true;
            this.lTrat.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTrat.Location = new System.Drawing.Point(44, 220);
            this.lTrat.Name = "lTrat";
            this.lTrat.Size = new System.Drawing.Size(118, 23);
            this.lTrat.TabIndex = 9;
            this.lTrat.Text = "Tratamiento: ";
            // 
            // tbTrat
            // 
            this.tbTrat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTrat.Location = new System.Drawing.Point(160, 220);
            this.tbTrat.Multiline = true;
            this.tbTrat.Name = "tbTrat";
            this.tbTrat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTrat.Size = new System.Drawing.Size(175, 20);
            this.tbTrat.TabIndex = 10;
            // 
            // lObserv
            // 
            this.lObserv.AutoSize = true;
            this.lObserv.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lObserv.Location = new System.Drawing.Point(44, 275);
            this.lObserv.Name = "lObserv";
            this.lObserv.Size = new System.Drawing.Size(134, 23);
            this.lObserv.TabIndex = 11;
            this.lObserv.Text = "Observaciones: ";
            // 
            // tbObserv
            // 
            this.tbObserv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbObserv.Location = new System.Drawing.Point(184, 278);
            this.tbObserv.Multiline = true;
            this.tbObserv.Name = "tbObserv";
            this.tbObserv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbObserv.Size = new System.Drawing.Size(206, 20);
            this.tbObserv.TabIndex = 12;
            // 
            // FormEditarHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbObserv);
            this.Controls.Add(this.lObserv);
            this.Controls.Add(this.tbTrat);
            this.Controls.Add(this.lTrat);
            this.Controls.Add(this.tbDiag);
            this.Controls.Add(this.lDiag);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lFecha);
            this.Controls.Add(this.lValorPaciente);
            this.Controls.Add(this.lPaciente);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditarHistorial";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormEditarHistorial";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.Button brVolver;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label lPaciente;
        private System.Windows.Forms.Label lValorPaciente;
        private System.Windows.Forms.Label lFecha;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lDiag;
        private System.Windows.Forms.TextBox tbDiag;
        private System.Windows.Forms.Label lTrat;
        private System.Windows.Forms.TextBox tbTrat;
        private System.Windows.Forms.Label lObserv;
        private System.Windows.Forms.TextBox tbObserv;
    }
}