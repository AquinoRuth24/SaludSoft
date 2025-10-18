namespace SaludSoft
{
    partial class FormListarProfesionales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListarProfesionales));
            this.DGProfesionales = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BVolver = new System.Windows.Forms.Button();
            this.LTexto = new System.Windows.Forms.Label();
            this.LabelGestionPaciente = new System.Windows.Forms.Label();
            this.TBBuscarProfesional = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BBuscarProfesional = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGProfesionales)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // DGProfesionales
            // 
            this.DGProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGProfesionales.Location = new System.Drawing.Point(2, 94);
            this.DGProfesionales.Name = "DGProfesionales";
            this.DGProfesionales.Size = new System.Drawing.Size(1042, 398);
            this.DGProfesionales.TabIndex = 0;
            this.DGProfesionales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGProfesionales_CellClick);
            this.DGProfesionales.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGProfesionales_CellFormatting);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(242)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.BVolver);
            this.panel1.Controls.Add(this.LTexto);
            this.panel1.Controls.Add(this.LabelGestionPaciente);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1042, 46);
            this.panel1.TabIndex = 5;
            // 
            // BVolver
            // 
            this.BVolver.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVolver.Location = new System.Drawing.Point(15, 9);
            this.BVolver.Name = "BVolver";
            this.BVolver.Size = new System.Drawing.Size(77, 31);
            this.BVolver.TabIndex = 3;
            this.BVolver.Text = "<--Volver";
            this.BVolver.UseVisualStyleBackColor = true;
            // 
            // LTexto
            // 
            this.LTexto.AutoSize = true;
            this.LTexto.Location = new System.Drawing.Point(51, 47);
            this.LTexto.Name = "LTexto";
            this.LTexto.Size = new System.Drawing.Size(0, 13);
            this.LTexto.TabIndex = 2;
            // 
            // LabelGestionPaciente
            // 
            this.LabelGestionPaciente.AutoSize = true;
            this.LabelGestionPaciente.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGestionPaciente.Location = new System.Drawing.Point(390, 9);
            this.LabelGestionPaciente.Name = "LabelGestionPaciente";
            this.LabelGestionPaciente.Size = new System.Drawing.Size(250, 26);
            this.LabelGestionPaciente.TabIndex = 1;
            this.LabelGestionPaciente.Text = "Gestion De Profesionales";
            // 
            // TBBuscarProfesional
            // 
            this.TBBuscarProfesional.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBBuscarProfesional.Location = new System.Drawing.Point(256, 60);
            this.TBBuscarProfesional.Name = "TBBuscarProfesional";
            this.TBBuscarProfesional.Size = new System.Drawing.Size(540, 26);
            this.TBBuscarProfesional.TabIndex = 9;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(136, 65);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 23);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // BBuscarProfesional
            // 
            this.BBuscarProfesional.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscarProfesional.Location = new System.Drawing.Point(871, 60);
            this.BBuscarProfesional.Name = "BBuscarProfesional";
            this.BBuscarProfesional.Size = new System.Drawing.Size(81, 26);
            this.BBuscarProfesional.TabIndex = 12;
            this.BBuscarProfesional.Text = "Buscar";
            this.BBuscarProfesional.UseVisualStyleBackColor = true;
            // 
            // FormListarProfesionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 497);
            this.Controls.Add(this.BBuscarProfesional);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.TBBuscarProfesional);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DGProfesionales);
            this.Name = "FormListarProfesionales";
            this.Text = "FormListarProfesionales";
            ((System.ComponentModel.ISupportInitialize)(this.DGProfesionales)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGProfesionales;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BVolver;
        private System.Windows.Forms.Label LTexto;
        private System.Windows.Forms.Label LabelGestionPaciente;
        private System.Windows.Forms.TextBox TBBuscarProfesional;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button BBuscarProfesional;
    }
}