namespace SaludSoft
{
    partial class Backup
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
            this.lBackup = new System.Windows.Forms.Label();
            this.lBd = new System.Windows.Forms.Label();
            this.lRuta = new System.Windows.Forms.Label();
            this.cbBd = new System.Windows.Forms.ComboBox();
            this.tbRuta = new System.Windows.Forms.TextBox();
            this.btConectar = new System.Windows.Forms.Button();
            this.btRuta = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.lBackup);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 81);
            this.panel1.TabIndex = 0;
            // 
            // lBackup
            // 
            this.lBackup.AutoSize = true;
            this.lBackup.BackColor = System.Drawing.Color.White;
            this.lBackup.Font = new System.Drawing.Font("Comic Sans MS", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBackup.Location = new System.Drawing.Point(23, 21);
            this.lBackup.Name = "lBackup";
            this.lBackup.Size = new System.Drawing.Size(109, 34);
            this.lBackup.TabIndex = 8;
            this.lBackup.Text = "Back Up";
            // 
            // lBd
            // 
            this.lBd.AutoSize = true;
            this.lBd.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBd.Location = new System.Drawing.Point(52, 161);
            this.lBd.Name = "lBd";
            this.lBd.Size = new System.Drawing.Size(159, 27);
            this.lBd.TabIndex = 1;
            this.lBd.Text = "Base de datos: ";
            this.lBd.Click += new System.EventHandler(this.lBd_Click);
            // 
            // lRuta
            // 
            this.lRuta.AutoSize = true;
            this.lRuta.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRuta.Location = new System.Drawing.Point(52, 220);
            this.lRuta.Name = "lRuta";
            this.lRuta.Size = new System.Drawing.Size(152, 27);
            this.lRuta.TabIndex = 2;
            this.lRuta.Text = "Ruta Guardar: ";
            // 
            // cbBd
            // 
            this.cbBd.FormattingEnabled = true;
            this.cbBd.Items.AddRange(new object[] {
            "SaludSoft"});
            this.cbBd.Location = new System.Drawing.Point(217, 167);
            this.cbBd.Name = "cbBd";
            this.cbBd.Size = new System.Drawing.Size(233, 21);
            this.cbBd.TabIndex = 3;
            this.cbBd.SelectedIndexChanged += new System.EventHandler(this.cbBd_SelectedIndexChanged);
            // 
            // tbRuta
            // 
            this.tbRuta.Location = new System.Drawing.Point(217, 227);
            this.tbRuta.Name = "tbRuta";
            this.tbRuta.Size = new System.Drawing.Size(233, 20);
            this.tbRuta.TabIndex = 4;
            this.tbRuta.TextChanged += new System.EventHandler(this.tbRuta_TextChanged);
            // 
            // btConectar
            // 
            this.btConectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btConectar.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConectar.Location = new System.Drawing.Point(494, 143);
            this.btConectar.Name = "btConectar";
            this.btConectar.Size = new System.Drawing.Size(111, 45);
            this.btConectar.TabIndex = 5;
            this.btConectar.Text = "Conectar";
            this.btConectar.UseVisualStyleBackColor = false;
            this.btConectar.Click += new System.EventHandler(this.btConectar_Click);
            // 
            // btRuta
            // 
            this.btRuta.BackColor = System.Drawing.Color.Gray;
            this.btRuta.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRuta.Location = new System.Drawing.Point(494, 214);
            this.btRuta.Name = "btRuta";
            this.btRuta.Size = new System.Drawing.Size(111, 33);
            this.btRuta.TabIndex = 6;
            this.btRuta.Text = "Ruta";
            this.btRuta.UseVisualStyleBackColor = false;
            this.btRuta.Click += new System.EventHandler(this.btRuta_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(494, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 39);
            this.button1.TabIndex = 7;
            this.button1.Text = "BackUp";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btRuta);
            this.Controls.Add(this.btConectar);
            this.Controls.Add(this.tbRuta);
            this.Controls.Add(this.cbBd);
            this.Controls.Add(this.lRuta);
            this.Controls.Add(this.lBd);
            this.Controls.Add(this.panel1);
            this.Name = "Backup";
            this.Text = "Backup";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lBd;
        private System.Windows.Forms.Label lRuta;
        private System.Windows.Forms.ComboBox cbBd;
        private System.Windows.Forms.TextBox tbRuta;
        private System.Windows.Forms.Button btConectar;
        private System.Windows.Forms.Button btRuta;
        private System.Windows.Forms.Label lBackup;
        private System.Windows.Forms.Button button1;
    }
}