namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    partial class frmTATCitasPendientes
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkUsarFecha = new System.Windows.Forms.CheckBox();
            this.lstLista = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAprobarTodos = new System.Windows.Forms.Button();
            this.btnAprobar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAnticipos = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Enabled = false;
            this.panel4.Location = new System.Drawing.Point(848, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(3, 554);
            this.panel4.TabIndex = 137;
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "dddd-d-MMMM-yyyy ";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(64, 44);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(662, 22);
            this.dtpInicio.TabIndex = 144;
            this.dtpInicio.ValueChanged += new System.EventHandler(this.DtpInicio_ValueChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Enabled = false;
            this.panel5.Location = new System.Drawing.Point(0, 35);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(3, 431);
            this.panel5.TabIndex = 143;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(850, 3);
            this.panel2.TabIndex = 139;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 35);
            this.panel1.TabIndex = 138;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Black;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Enabled = false;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(3, 35);
            this.panel8.TabIndex = 62;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Enabled = false;
            this.panel7.Location = new System.Drawing.Point(848, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(3, 35);
            this.panel7.TabIndex = 61;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Enabled = false;
            this.panel6.Location = new System.Drawing.Point(-1, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(850, 3);
            this.panel6.TabIndex = 60;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::SISTEMA.WINFORMS.CAPTURAS.TATOO.Properties.Resources.Icono_Cerrar;
            this.pictureBox3.Location = new System.Drawing.Point(815, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.PictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Image = global::SISTEMA.WINFORMS.CAPTURAS.TATOO.Properties.Resources.EstadoFinalizado;
            this.pictureBox2.Location = new System.Drawing.Point(6, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(36, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Aprobar Citas Pendientes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 145;
            this.label1.Text = "Fecha";
            // 
            // chkUsarFecha
            // 
            this.chkUsarFecha.AutoSize = true;
            this.chkUsarFecha.Location = new System.Drawing.Point(732, 45);
            this.chkUsarFecha.Name = "chkUsarFecha";
            this.chkUsarFecha.Size = new System.Drawing.Size(110, 20);
            this.chkUsarFecha.TabIndex = 146;
            this.chkUsarFecha.Text = "Utilizar filtrado";
            this.chkUsarFecha.UseVisualStyleBackColor = true;
            this.chkUsarFecha.CheckedChanged += new System.EventHandler(this.ChkUsarFecha_CheckedChanged);
            // 
            // lstLista
            // 
            this.lstLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstLista.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLista.FullRowSelect = true;
            this.lstLista.GridLines = true;
            this.lstLista.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstLista.Location = new System.Drawing.Point(10, 76);
            this.lstLista.Margin = new System.Windows.Forms.Padding(4);
            this.lstLista.MultiSelect = false;
            this.lstLista.Name = "lstLista";
            this.lstLista.Size = new System.Drawing.Size(828, 336);
            this.lstLista.TabIndex = 147;
            this.lstLista.UseCompatibleStateImageBehavior = false;
            this.lstLista.View = System.Windows.Forms.View.Details;
            this.lstLista.SelectedIndexChanged += new System.EventHandler(this.LstLista_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Cliente";
            this.columnHeader1.Width = 293;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Fecha";
            this.columnHeader2.Width = 231;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Anticipo";
            this.columnHeader3.Width = 63;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Empleado";
            this.columnHeader4.Width = 237;
            // 
            // btnAprobarTodos
            // 
            this.btnAprobarTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAprobarTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAprobarTodos.Image = global::SISTEMA.WINFORMS.CAPTURAS.TATOO.Properties.Resources.ImgMostrar;
            this.btnAprobarTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAprobarTodos.Location = new System.Drawing.Point(15, 420);
            this.btnAprobarTodos.Margin = new System.Windows.Forms.Padding(4);
            this.btnAprobarTodos.Name = "btnAprobarTodos";
            this.btnAprobarTodos.Size = new System.Drawing.Size(129, 33);
            this.btnAprobarTodos.TabIndex = 148;
            this.btnAprobarTodos.Text = "&Aprobar todos";
            this.btnAprobarTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAprobarTodos.UseVisualStyleBackColor = true;
            this.btnAprobarTodos.Click += new System.EventHandler(this.BtnAprobarTodos_Click);
            // 
            // btnAprobar
            // 
            this.btnAprobar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAprobar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAprobar.Image = global::SISTEMA.WINFORMS.CAPTURAS.TATOO.Properties.Resources.ImgMostrar;
            this.btnAprobar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAprobar.Location = new System.Drawing.Point(650, 420);
            this.btnAprobar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(90, 33);
            this.btnAprobar.TabIndex = 149;
            this.btnAprobar.Text = "&Aprobar";
            this.btnAprobar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.Click += new System.EventHandler(this.BtnAprobar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::SISTEMA.WINFORMS.CAPTURAS.TATOO.Properties.Resources.SALIR;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(748, 420);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 33);
            this.btnSalir.TabIndex = 150;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 428);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 152;
            this.label2.Text = "Total de Anticipos";
            // 
            // lblAnticipos
            // 
            this.lblAnticipos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAnticipos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAnticipos.Location = new System.Drawing.Point(536, 426);
            this.lblAnticipos.Name = "lblAnticipos";
            this.lblAnticipos.Size = new System.Drawing.Size(64, 22);
            this.lblAnticipos.TabIndex = 153;
            // 
            // frmTATCitasPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 466);
            this.Controls.Add(this.lblAnticipos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAprobar);
            this.Controls.Add(this.btnAprobarTodos);
            this.Controls.Add(this.lstLista);
            this.Controls.Add(this.chkUsarFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTATCitasPendientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTATCitasPendientes";
            this.Load += new System.EventHandler(this.FrmTATCitasPendientes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkUsarFecha;
        public System.Windows.Forms.ListView lstLista;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        public System.Windows.Forms.Button btnAprobarTodos;
        public System.Windows.Forms.Button btnAprobar;
        public System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAnticipos;
    }
}