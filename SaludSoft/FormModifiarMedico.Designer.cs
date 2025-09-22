namespace SaludSoft.Resources.Models
{
    partial class FormModificarMedico
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lTitulo = new System.Windows.Forms.Label();
            this.gbComun = new System.Windows.Forms.GroupBox();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.lTelefono = new System.Windows.Forms.Label();
            this.tbCorreo = new System.Windows.Forms.TextBox();
            this.lCorreo = new System.Windows.Forms.Label();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.lApellido = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lNombre = new System.Windows.Forms.Label();
            this.gbMedico = new System.Windows.Forms.GroupBox();
            this.BTModificar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.LEstado = new System.Windows.Forms.Label();
            this.CMBEstado = new System.Windows.Forms.ComboBox();
            this.CMBEsecialidad = new System.Windows.Forms.ComboBox();
            this.tbContraseñaMedico = new System.Windows.Forms.TextBox();
            this.tbMatricula = new System.Windows.Forms.TextBox();
            this.lContraseñaMedico = new System.Windows.Forms.Label();
            this.lMatricula = new System.Windows.Forms.Label();
            this.lEspecialidad = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.gbComun.SuspendLayout();
            this.gbMedico.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.lTitulo);
            this.panel2.Location = new System.Drawing.Point(11, 11);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(993, 60);
            this.panel2.TabIndex = 4;
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lTitulo.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitulo.Location = new System.Drawing.Point(437, 15);
            this.lTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(117, 23);
            this.lTitulo.TabIndex = 3;
            this.lTitulo.Text = "Editar Medico";
            // 
            // gbComun
            // 
            this.gbComun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbComun.Controls.Add(this.tbTelefono);
            this.gbComun.Controls.Add(this.lTelefono);
            this.gbComun.Controls.Add(this.tbCorreo);
            this.gbComun.Controls.Add(this.lCorreo);
            this.gbComun.Controls.Add(this.tbApellido);
            this.gbComun.Controls.Add(this.lApellido);
            this.gbComun.Controls.Add(this.tbNombre);
            this.gbComun.Controls.Add(this.lNombre);
            this.gbComun.Location = new System.Drawing.Point(39, 75);
            this.gbComun.Margin = new System.Windows.Forms.Padding(2);
            this.gbComun.Name = "gbComun";
            this.gbComun.Padding = new System.Windows.Forms.Padding(2);
            this.gbComun.Size = new System.Drawing.Size(949, 182);
            this.gbComun.TabIndex = 5;
            this.gbComun.TabStop = false;
            // 
            // tbTelefono
            // 
            this.tbTelefono.Location = new System.Drawing.Point(474, 136);
            this.tbTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(137, 20);
            this.tbTelefono.TabIndex = 5;
            // 
            // lTelefono
            // 
            this.lTelefono.AutoSize = true;
            this.lTelefono.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTelefono.Location = new System.Drawing.Point(130, 136);
            this.lTelefono.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lTelefono.Name = "lTelefono";
            this.lTelefono.Size = new System.Drawing.Size(79, 20);
            this.lTelefono.TabIndex = 5;
            this.lTelefono.Text = "Teléfono: ";
            // 
            // tbCorreo
            // 
            this.tbCorreo.Location = new System.Drawing.Point(474, 94);
            this.tbCorreo.Margin = new System.Windows.Forms.Padding(2);
            this.tbCorreo.Name = "tbCorreo";
            this.tbCorreo.Size = new System.Drawing.Size(137, 20);
            this.tbCorreo.TabIndex = 5;
            // 
            // lCorreo
            // 
            this.lCorreo.AutoSize = true;
            this.lCorreo.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCorreo.Location = new System.Drawing.Point(82, 94);
            this.lCorreo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lCorreo.Name = "lCorreo";
            this.lCorreo.Size = new System.Drawing.Size(146, 20);
            this.lCorreo.TabIndex = 5;
            this.lCorreo.Text = "Correo Electrónico: ";
            // 
            // tbApellido
            // 
            this.tbApellido.Location = new System.Drawing.Point(474, 48);
            this.tbApellido.Margin = new System.Windows.Forms.Padding(2);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(137, 20);
            this.tbApellido.TabIndex = 5;
            // 
            // lApellido
            // 
            this.lApellido.AutoSize = true;
            this.lApellido.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lApellido.Location = new System.Drawing.Point(138, 48);
            this.lApellido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lApellido.Name = "lApellido";
            this.lApellido.Size = new System.Drawing.Size(90, 20);
            this.lApellido.TabIndex = 5;
            this.lApellido.Text = "Apellido(s): ";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(474, 19);
            this.tbNombre.Margin = new System.Windows.Forms.Padding(2);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(137, 20);
            this.tbNombre.TabIndex = 5;
            // 
            // lNombre
            // 
            this.lNombre.AutoSize = true;
            this.lNombre.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNombre.Location = new System.Drawing.Point(121, 19);
            this.lNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lNombre.Name = "lNombre";
            this.lNombre.Size = new System.Drawing.Size(97, 20);
            this.lNombre.TabIndex = 5;
            this.lNombre.Text = "Nombres(s): ";
            // 
            // gbMedico
            // 
            this.gbMedico.Controls.Add(this.BTModificar);
            this.gbMedico.Controls.Add(this.btCancelar);
            this.gbMedico.Controls.Add(this.LEstado);
            this.gbMedico.Controls.Add(this.CMBEstado);
            this.gbMedico.Controls.Add(this.CMBEsecialidad);
            this.gbMedico.Controls.Add(this.tbContraseñaMedico);
            this.gbMedico.Controls.Add(this.tbMatricula);
            this.gbMedico.Controls.Add(this.lContraseñaMedico);
            this.gbMedico.Controls.Add(this.lMatricula);
            this.gbMedico.Controls.Add(this.lEspecialidad);
            this.gbMedico.Location = new System.Drawing.Point(39, 261);
            this.gbMedico.Margin = new System.Windows.Forms.Padding(2);
            this.gbMedico.Name = "gbMedico";
            this.gbMedico.Padding = new System.Windows.Forms.Padding(2);
            this.gbMedico.Size = new System.Drawing.Size(949, 236);
            this.gbMedico.TabIndex = 7;
            this.gbMedico.TabStop = false;
            this.gbMedico.Visible = false;
            // 
            // BTModificar
            // 
            this.BTModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BTModificar.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTModificar.Location = new System.Drawing.Point(853, 199);
            this.BTModificar.Margin = new System.Windows.Forms.Padding(2);
            this.BTModificar.Name = "BTModificar";
            this.BTModificar.Size = new System.Drawing.Size(92, 32);
            this.BTModificar.TabIndex = 13;
            this.BTModificar.Text = "Modificar";
            this.BTModificar.UseVisualStyleBackColor = false;
            this.BTModificar.Click += new System.EventHandler(this.BTModificar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btCancelar.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Location = new System.Drawing.Point(735, 199);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(91, 33);
            this.btCancelar.TabIndex = 12;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // LEstado
            // 
            this.LEstado.AutoSize = true;
            this.LEstado.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LEstado.Location = new System.Drawing.Point(106, 186);
            this.LEstado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LEstado.Name = "LEstado";
            this.LEstado.Size = new System.Drawing.Size(55, 20);
            this.LEstado.TabIndex = 11;
            this.LEstado.Text = "Estado";
            // 
            // CMBEstado
            // 
            this.CMBEstado.FormattingEnabled = true;
            this.CMBEstado.Location = new System.Drawing.Point(490, 186);
            this.CMBEstado.Name = "CMBEstado";
            this.CMBEstado.Size = new System.Drawing.Size(121, 21);
            this.CMBEstado.TabIndex = 10;
            // 
            // CMBEsecialidad
            // 
            this.CMBEsecialidad.FormattingEnabled = true;
            this.CMBEsecialidad.Location = new System.Drawing.Point(478, 47);
            this.CMBEsecialidad.Name = "CMBEsecialidad";
            this.CMBEsecialidad.Size = new System.Drawing.Size(133, 21);
            this.CMBEsecialidad.TabIndex = 9;
            // 
            // tbContraseñaMedico
            // 
            this.tbContraseñaMedico.Location = new System.Drawing.Point(484, 138);
            this.tbContraseñaMedico.Margin = new System.Windows.Forms.Padding(2);
            this.tbContraseñaMedico.Name = "tbContraseñaMedico";
            this.tbContraseñaMedico.Size = new System.Drawing.Size(127, 20);
            this.tbContraseñaMedico.TabIndex = 8;
            // 
            // tbMatricula
            // 
            this.tbMatricula.Location = new System.Drawing.Point(484, 91);
            this.tbMatricula.Margin = new System.Windows.Forms.Padding(2);
            this.tbMatricula.Name = "tbMatricula";
            this.tbMatricula.Size = new System.Drawing.Size(127, 20);
            this.tbMatricula.TabIndex = 7;
            // 
            // lContraseñaMedico
            // 
            this.lContraseñaMedico.AutoSize = true;
            this.lContraseñaMedico.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lContraseñaMedico.Location = new System.Drawing.Point(104, 137);
            this.lContraseñaMedico.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lContraseñaMedico.Name = "lContraseñaMedico";
            this.lContraseñaMedico.Size = new System.Drawing.Size(96, 20);
            this.lContraseñaMedico.TabIndex = 7;
            this.lContraseñaMedico.Text = "Contraseña: ";
            // 
            // lMatricula
            // 
            this.lMatricula.AutoSize = true;
            this.lMatricula.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMatricula.Location = new System.Drawing.Point(115, 90);
            this.lMatricula.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lMatricula.Name = "lMatricula";
            this.lMatricula.Size = new System.Drawing.Size(85, 20);
            this.lMatricula.TabIndex = 7;
            this.lMatricula.Text = "Matrícula: ";
            // 
            // lEspecialidad
            // 
            this.lEspecialidad.AutoSize = true;
            this.lEspecialidad.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEspecialidad.Location = new System.Drawing.Point(106, 46);
            this.lEspecialidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lEspecialidad.Name = "lEspecialidad";
            this.lEspecialidad.Size = new System.Drawing.Size(103, 20);
            this.lEspecialidad.TabIndex = 7;
            this.lEspecialidad.Text = "Especialidad: ";
            // 
            // FormModificarMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 508);
            this.Controls.Add(this.gbMedico);
            this.Controls.Add(this.gbComun);
            this.Controls.Add(this.panel2);
            this.Name = "FormModificarMedico";
            this.Text = "FormModifiarMedico";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbComun.ResumeLayout(false);
            this.gbComun.PerformLayout();
            this.gbMedico.ResumeLayout(false);
            this.gbMedico.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.GroupBox gbComun;
        private System.Windows.Forms.TextBox tbTelefono;
        private System.Windows.Forms.Label lTelefono;
        private System.Windows.Forms.TextBox tbCorreo;
        private System.Windows.Forms.Label lCorreo;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.Label lApellido;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label lNombre;
        private System.Windows.Forms.GroupBox gbMedico;
        private System.Windows.Forms.TextBox tbContraseñaMedico;
        private System.Windows.Forms.TextBox tbMatricula;
        private System.Windows.Forms.Label lContraseñaMedico;
        private System.Windows.Forms.Label lMatricula;
        private System.Windows.Forms.Label lEspecialidad;
        private System.Windows.Forms.Label LEstado;
        private System.Windows.Forms.ComboBox CMBEstado;
        private System.Windows.Forms.ComboBox CMBEsecialidad;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button BTModificar;
    }
}