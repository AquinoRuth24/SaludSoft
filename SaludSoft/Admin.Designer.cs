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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btBackup = new System.Windows.Forms.Button();
            this.btConsultorios = new System.Windows.Forms.Button();
            this.btTurnos = new System.Windows.Forms.Button();
            this.btInicio = new System.Windows.Forms.Button();
            this.btMedicos = new System.Windows.Forms.Button();
            this.btUsuario = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btBackup);
            this.panel1.Controls.Add(this.btConsultorios);
            this.panel1.Controls.Add(this.btTurnos);
            this.panel1.Controls.Add(this.btInicio);
            this.panel1.Controls.Add(this.btMedicos);
            this.panel1.Controls.Add(this.btUsuario);
            this.panel1.Location = new System.Drawing.Point(2, 42);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 454);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(23, 203);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Configuración";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btBackup
            // 
            this.btBackup.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBackup.Location = new System.Drawing.Point(41, 166);
            this.btBackup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btBackup.Name = "btBackup";
            this.btBackup.Size = new System.Drawing.Size(65, 25);
            this.btBackup.TabIndex = 2;
            this.btBackup.Text = "Backup";
            this.btBackup.UseVisualStyleBackColor = true;
            // 
            // btConsultorios
            // 
            this.btConsultorios.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConsultorios.Location = new System.Drawing.Point(23, 135);
            this.btConsultorios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btConsultorios.Name = "btConsultorios";
            this.btConsultorios.Size = new System.Drawing.Size(91, 27);
            this.btConsultorios.TabIndex = 2;
            this.btConsultorios.Text = "Consultorios";
            this.btConsultorios.UseVisualStyleBackColor = true;
            // 
            // btTurnos
            // 
            this.btTurnos.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTurnos.Location = new System.Drawing.Point(37, 105);
            this.btTurnos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btTurnos.Name = "btTurnos";
            this.btTurnos.Size = new System.Drawing.Size(69, 26);
            this.btTurnos.TabIndex = 5;
            this.btTurnos.Text = "Turnos";
            this.btTurnos.UseVisualStyleBackColor = true;
            // 
            // btInicio
            // 
            this.btInicio.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInicio.Location = new System.Drawing.Point(41, 10);
            this.btInicio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btInicio.Name = "btInicio";
            this.btInicio.Size = new System.Drawing.Size(81, 27);
            this.btInicio.TabIndex = 2;
            this.btInicio.Text = "Inicio";
            this.btInicio.UseVisualStyleBackColor = true;
            this.btInicio.Click += new System.EventHandler(this.button1_Click);
            // 
            // btMedicos
            // 
            this.btMedicos.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMedicos.Location = new System.Drawing.Point(29, 69);
            this.btMedicos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btMedicos.Name = "btMedicos";
            this.btMedicos.Size = new System.Drawing.Size(78, 32);
            this.btMedicos.TabIndex = 4;
            this.btMedicos.Text = "Médicos";
            this.btMedicos.UseVisualStyleBackColor = true;
            // 
            // btUsuario
            // 
            this.btUsuario.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUsuario.Location = new System.Drawing.Point(29, 40);
            this.btUsuario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btUsuario.Name = "btUsuario";
            this.btUsuario.Size = new System.Drawing.Size(77, 25);
            this.btUsuario.TabIndex = 3;
            this.btUsuario.Text = "Usuarios";
            this.btUsuario.UseVisualStyleBackColor = true;
            this.btUsuario.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(2, -3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 496);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Admin";
            this.Text = "Admin";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btTurnos;
        private System.Windows.Forms.Button btInicio;
        private System.Windows.Forms.Button btMedicos;
        private System.Windows.Forms.Button btUsuario;
        private System.Windows.Forms.Button btBackup;
        private System.Windows.Forms.Button btConsultorios;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}