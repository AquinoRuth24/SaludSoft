namespace SaludSoft
{
    partial class FormModificarUsuario
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
            this.BTModificar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.TBContraseña = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CMBRol = new System.Windows.Forms.ComboBox();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.lTelefono = new System.Windows.Forms.Label();
            this.tbCorreo = new System.Windows.Forms.TextBox();
            this.lCorreo = new System.Windows.Forms.Label();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.lApellido = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lNombre = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.gbComun.SuspendLayout();
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
            this.panel2.TabIndex = 3;
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lTitulo.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitulo.Location = new System.Drawing.Point(437, 15);
            this.lTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(122, 23);
            this.lTitulo.TabIndex = 3;
            this.lTitulo.Text = "Editar Usuario";
            // 
            // gbComun
            // 
            this.gbComun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbComun.Controls.Add(this.BTModificar);
            this.gbComun.Controls.Add(this.btCancelar);
            this.gbComun.Controls.Add(this.TBContraseña);
            this.gbComun.Controls.Add(this.label2);
            this.gbComun.Controls.Add(this.label1);
            this.gbComun.Controls.Add(this.CMBRol);
            this.gbComun.Controls.Add(this.tbTelefono);
            this.gbComun.Controls.Add(this.lTelefono);
            this.gbComun.Controls.Add(this.tbCorreo);
            this.gbComun.Controls.Add(this.lCorreo);
            this.gbComun.Controls.Add(this.tbApellido);
            this.gbComun.Controls.Add(this.lApellido);
            this.gbComun.Controls.Add(this.tbNombre);
            this.gbComun.Controls.Add(this.lNombre);
            this.gbComun.Location = new System.Drawing.Point(55, 88);
            this.gbComun.Margin = new System.Windows.Forms.Padding(2);
            this.gbComun.Name = "gbComun";
            this.gbComun.Padding = new System.Windows.Forms.Padding(2);
            this.gbComun.Size = new System.Drawing.Size(927, 402);
            this.gbComun.TabIndex = 4;
            this.gbComun.TabStop = false;
            // 
            // BTModificar
            // 
            this.BTModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BTModificar.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTModificar.Location = new System.Drawing.Point(831, 365);
            this.BTModificar.Margin = new System.Windows.Forms.Padding(2);
            this.BTModificar.Name = "BTModificar";
            this.BTModificar.Size = new System.Drawing.Size(92, 32);
            this.BTModificar.TabIndex = 11;
            this.BTModificar.Text = "Modificar";
            this.BTModificar.UseVisualStyleBackColor = false;
            this.BTModificar.Click += new System.EventHandler(this.BTModificar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btCancelar.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Location = new System.Drawing.Point(719, 364);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(91, 33);
            this.btCancelar.TabIndex = 10;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = false;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // TBContraseña
            // 
            this.TBContraseña.Location = new System.Drawing.Point(480, 252);
            this.TBContraseña.Name = "TBContraseña";
            this.TBContraseña.Size = new System.Drawing.Size(146, 20);
            this.TBContraseña.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(92, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contraseña:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(141, 210);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(34, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Rol:";
            // 
            // CMBRol
            // 
            this.CMBRol.FormattingEnabled = true;
            this.CMBRol.Location = new System.Drawing.Point(480, 210);
            this.CMBRol.Name = "CMBRol";
            this.CMBRol.Size = new System.Drawing.Size(137, 21);
            this.CMBRol.TabIndex = 6;
            // 
            // tbTelefono
            // 
            this.tbTelefono.Location = new System.Drawing.Point(480, 163);
            this.tbTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(137, 20);
            this.tbTelefono.TabIndex = 5;
            // 
            // lTelefono
            // 
            this.lTelefono.AutoSize = true;
            this.lTelefono.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTelefono.Location = new System.Drawing.Point(120, 163);
            this.lTelefono.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lTelefono.Name = "lTelefono";
            this.lTelefono.Size = new System.Drawing.Size(79, 20);
            this.lTelefono.TabIndex = 5;
            this.lTelefono.Text = "Teléfono: ";
            // 
            // tbCorreo
            // 
            this.tbCorreo.Location = new System.Drawing.Point(480, 127);
            this.tbCorreo.Margin = new System.Windows.Forms.Padding(2);
            this.tbCorreo.Name = "tbCorreo";
            this.tbCorreo.Size = new System.Drawing.Size(137, 20);
            this.tbCorreo.TabIndex = 5;
            // 
            // lCorreo
            // 
            this.lCorreo.AutoSize = true;
            this.lCorreo.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCorreo.Location = new System.Drawing.Point(59, 127);
            this.lCorreo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lCorreo.Name = "lCorreo";
            this.lCorreo.Size = new System.Drawing.Size(146, 20);
            this.lCorreo.TabIndex = 5;
            this.lCorreo.Text = "Correo Electrónico: ";
            // 
            // tbApellido
            // 
            this.tbApellido.Location = new System.Drawing.Point(480, 81);
            this.tbApellido.Margin = new System.Windows.Forms.Padding(2);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(137, 20);
            this.tbApellido.TabIndex = 5;
            // 
            // lApellido
            // 
            this.lApellido.AutoSize = true;
            this.lApellido.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lApellido.Location = new System.Drawing.Point(109, 81);
            this.lApellido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lApellido.Name = "lApellido";
            this.lApellido.Size = new System.Drawing.Size(90, 20);
            this.lApellido.TabIndex = 5;
            this.lApellido.Text = "Apellido(s): ";
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(480, 37);
            this.tbNombre.Margin = new System.Windows.Forms.Padding(2);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(137, 20);
            this.tbNombre.TabIndex = 5;
            // 
            // lNombre
            // 
            this.lNombre.AutoSize = true;
            this.lNombre.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNombre.Location = new System.Drawing.Point(102, 37);
            this.lNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lNombre.Name = "lNombre";
            this.lNombre.Size = new System.Drawing.Size(97, 20);
            this.lNombre.TabIndex = 5;
            this.lNombre.Text = "Nombres(s): ";
            // 
            // FormModificarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 501);
            this.Controls.Add(this.gbComun);
            this.Controls.Add(this.panel2);
            this.Name = "FormModificarUsuario";
            this.Text = "FormModificarUsuario";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbComun.ResumeLayout(false);
            this.gbComun.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.GroupBox gbComun;
        private System.Windows.Forms.ComboBox CMBRol;
        private System.Windows.Forms.TextBox tbTelefono;
        private System.Windows.Forms.Label lTelefono;
        private System.Windows.Forms.TextBox tbCorreo;
        private System.Windows.Forms.Label lCorreo;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.Label lApellido;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label lNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBContraseña;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button BTModificar;
    }
}