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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btBackup = new System.Windows.Forms.Button();
            this.btConsultorios = new System.Windows.Forms.Button();
            this.btTurnos = new System.Windows.Forms.Button();
            this.btInicio = new System.Windows.Forms.Button();
            this.btMedicos = new System.Windows.Forms.Button();
            this.btUsuario = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.panel1.Location = new System.Drawing.Point(3, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 391);
            this.panel1.TabIndex = 0;
            // 
            // btBackup
            // 
            this.btBackup.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBackup.Location = new System.Drawing.Point(61, 256);
            this.btBackup.Name = "btBackup";
            this.btBackup.Size = new System.Drawing.Size(98, 39);
            this.btBackup.TabIndex = 2;
            this.btBackup.Text = "Backup";
            this.btBackup.UseVisualStyleBackColor = true;
            // 
            // btConsultorios
            // 
            this.btConsultorios.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConsultorios.Location = new System.Drawing.Point(35, 208);
            this.btConsultorios.Name = "btConsultorios";
            this.btConsultorios.Size = new System.Drawing.Size(137, 42);
            this.btConsultorios.TabIndex = 2;
            this.btConsultorios.Text = "Consultorios";
            this.btConsultorios.UseVisualStyleBackColor = true;
            // 
            // btTurnos
            // 
            this.btTurnos.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTurnos.Location = new System.Drawing.Point(55, 162);
            this.btTurnos.Name = "btTurnos";
            this.btTurnos.Size = new System.Drawing.Size(104, 40);
            this.btTurnos.TabIndex = 5;
            this.btTurnos.Text = "Turnos";
            this.btTurnos.UseVisualStyleBackColor = true;
            // 
            // btInicio
            // 
            this.btInicio.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInicio.Location = new System.Drawing.Point(61, 15);
            this.btInicio.Name = "btInicio";
            this.btInicio.Size = new System.Drawing.Size(75, 41);
            this.btInicio.TabIndex = 2;
            this.btInicio.Text = "Inicio";
            this.btInicio.UseVisualStyleBackColor = true;
            this.btInicio.Click += new System.EventHandler(this.button1_Click);
            // 
            // btMedicos
            // 
            this.btMedicos.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMedicos.Location = new System.Drawing.Point(44, 106);
            this.btMedicos.Name = "btMedicos";
            this.btMedicos.Size = new System.Drawing.Size(117, 50);
            this.btMedicos.TabIndex = 4;
            this.btMedicos.Text = "Médicos";
            this.btMedicos.UseVisualStyleBackColor = true;
            // 
            // btUsuario
            // 
            this.btUsuario.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUsuario.Location = new System.Drawing.Point(44, 62);
            this.btUsuario.Name = "btUsuario";
            this.btUsuario.Size = new System.Drawing.Size(115, 38);
            this.btUsuario.TabIndex = 3;
            this.btUsuario.Text = "Usuarios";
            this.btUsuario.UseVisualStyleBackColor = true;
            this.btUsuario.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(35, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 51);
            this.button1.TabIndex = 2;
            this.button1.Text = "Configuración";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
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