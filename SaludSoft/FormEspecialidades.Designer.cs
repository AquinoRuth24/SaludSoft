namespace SaludSoft
{
    partial class Especialidades
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
            this.BVolver = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVEspecialidad = new System.Windows.Forms.DataGridView();
            this.LNombre = new System.Windows.Forms.Label();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BAgregar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEspecialidad)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.BVolver);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1026, 79);
            this.panel1.TabIndex = 1;
            // 
            // BVolver
            // 
            this.BVolver.Image = global::SaludSoft.Properties.Resources.angulo_izquierdo;
            this.BVolver.Location = new System.Drawing.Point(12, 17);
            this.BVolver.Name = "BVolver";
            this.BVolver.Size = new System.Drawing.Size(75, 44);
            this.BVolver.TabIndex = 1;
            this.BVolver.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(419, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gestión de Usuario";
            // 
            // DGVEspecialidad
            // 
            this.DGVEspecialidad.AllowUserToAddRows = false;
            this.DGVEspecialidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEspecialidad.Location = new System.Drawing.Point(0, 192);
            this.DGVEspecialidad.Name = "DGVEspecialidad";
            this.DGVEspecialidad.ReadOnly = true;
            this.DGVEspecialidad.Size = new System.Drawing.Size(1026, 320);
            this.DGVEspecialidad.TabIndex = 2;
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNombre.Location = new System.Drawing.Point(12, 145);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(88, 26);
            this.LNombre.TabIndex = 3;
            this.LNombre.Text = "Nombre:";
            // 
            // TBNombre
            // 
            this.TBNombre.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNombre.Location = new System.Drawing.Point(117, 147);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(164, 30);
            this.TBNombre.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Agergar Especialidad";
            // 
            // BAgregar
            // 
            this.BAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BAgregar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAgregar.Location = new System.Drawing.Point(313, 145);
            this.BAgregar.Name = "BAgregar";
            this.BAgregar.Size = new System.Drawing.Size(80, 35);
            this.BAgregar.TabIndex = 6;
            this.BAgregar.Text = "Agegar";
            this.BAgregar.UseVisualStyleBackColor = false;
            this.BAgregar.Click += new System.EventHandler(this.BAgregar_Click);
            // 
            // Especialidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 524);
            this.Controls.Add(this.BAgregar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBNombre);
            this.Controls.Add(this.LNombre);
            this.Controls.Add(this.DGVEspecialidad);
            this.Controls.Add(this.panel1);
            this.Name = "Especialidades";
            this.Text = "FormEspecialidades";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEspecialidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVEspecialidad;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.TextBox TBNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BAgregar;
    }
}