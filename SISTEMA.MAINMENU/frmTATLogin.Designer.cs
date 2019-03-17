namespace SISTEMA.MAINMENU
{
    partial class frmTATLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTATLogin));
            this.btnAcceder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.ptbCerrar = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAcceder
            // 
            this.btnAcceder.BackColor = System.Drawing.Color.DimGray;
            this.btnAcceder.FlatAppearance.BorderSize = 0;
            this.btnAcceder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(134)))), ((int)(((byte)(164)))));
            this.btnAcceder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAcceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceder.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAcceder.Location = new System.Drawing.Point(341, 134);
            this.btnAcceder.Name = "btnAcceder";
            this.btnAcceder.Size = new System.Drawing.Size(357, 40);
            this.btnAcceder.TabIndex = 9;
            this.btnAcceder.Text = "Acceder";
            this.btnAcceder.UseVisualStyleBackColor = false;
            this.btnAcceder.Click += new System.EventHandler(this.btnAcceder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(471, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "LOGIN";
            // 
            // txtContraseña
            // 
            this.txtContraseña.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtContraseña.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtContraseña.Location = new System.Drawing.Point(342, 99);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(355, 14);
            this.txtContraseña.TabIndex = 12;
            this.txtContraseña.Text = "Contraseña";
            this.txtContraseña.Enter += new System.EventHandler(this.txtContraseña_Enter);
            this.txtContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContraseña_KeyPress);
            this.txtContraseña.Leave += new System.EventHandler(this.txtContraseña_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(338, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(364, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "___________________________________________________";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUsuario.Location = new System.Drawing.Point(343, 62);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(355, 14);
            this.txtUsuario.TabIndex = 11;
            this.txtUsuario.Text = "pruebas";
            this.txtUsuario.Enter += new System.EventHandler(this.txtUsuario_Enter);
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(339, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "___________________________________________________";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.picBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 230);
            this.panel1.TabIndex = 8;
            // 
            // picBox
            // 
            this.picBox.Image = global::SISTEMA.MAINMENU.Properties.Resources.LOGOINK;
            this.picBox.Location = new System.Drawing.Point(0, 0);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(230, 230);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            this.picBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBox_MouseDown);
            // 
            // ptbCerrar
            // 
            this.ptbCerrar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ptbCerrar.Image = global::SISTEMA.MAINMENU.Properties.Resources.CERRAR1;
            this.ptbCerrar.Location = new System.Drawing.Point(739, 1);
            this.ptbCerrar.Name = "ptbCerrar";
            this.ptbCerrar.Size = new System.Drawing.Size(25, 25);
            this.ptbCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ptbCerrar.TabIndex = 15;
            this.ptbCerrar.TabStop = false;
            this.ptbCerrar.Click += new System.EventHandler(this.ptbCerrar_Click);
            // 
            // frmTATLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(764, 230);
            this.Controls.Add(this.ptbCerrar);
            this.Controls.Add(this.btnAcceder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTATLogin";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmTATLogin_MouseDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCerrar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbCerrar;
        private System.Windows.Forms.Button btnAcceder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picBox;
    }
}