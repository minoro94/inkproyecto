namespace SISTEMA.MAINMENU
{
    partial class FORMA_PADRE
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORMA_PADRE));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Administrar = new System.Windows.Forms.ToolStripDropDownButton();
            this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.empleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCitas = new System.Windows.Forms.ToolStripButton();
            this.Clientes = new System.Windows.Forms.ToolStripButton();
            this.Herramientas = new System.Windows.Forms.ToolStripDropDownButton();
            this.blocDeNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculcadoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Configuracion = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tamañosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDePermisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeEmpleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogOut = new System.Windows.Forms.ToolStripButton();
            this.Salir = new System.Windows.Forms.ToolStripButton();
            this.Reloj = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Panel = new System.Windows.Forms.Panel();
            this.Disparador = new System.Windows.Forms.Timer(this.components);
            this.EnvioCorreo = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Administrar,
            this.toolStripButtonCitas,
            this.Clientes,
            this.Herramientas,
            this.Configuracion,
            this.LogOut,
            this.Salir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1246, 51);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Administrar
            // 
            this.Administrar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventarioToolStripMenuItem,
            this.toolStripSeparator4,
            this.empleadosToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.toolStripSeparator2});
            this.Administrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Administrar.Image = global::SISTEMA.MAINMENU.Properties.Resources.USUARIOS;
            this.Administrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Administrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Administrar.Name = "Administrar";
            this.Administrar.Size = new System.Drawing.Size(104, 48);
            this.Administrar.Text = "&Administrar";
            // 
            // inventarioToolStripMenuItem
            // 
            this.inventarioToolStripMenuItem.Image = global::SISTEMA.MAINMENU.Properties.Resources.PRODUCTO;
            this.inventarioToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(155, 32);
            this.inventarioToolStripMenuItem.Text = "Inventario";
            this.inventarioToolStripMenuItem.Click += new System.EventHandler(this.inventarioToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(152, 6);
            // 
            // empleadosToolStripMenuItem
            // 
            this.empleadosToolStripMenuItem.Image = global::SISTEMA.MAINMENU.Properties.Resources.EMPLEADOS;
            this.empleadosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            this.empleadosToolStripMenuItem.Size = new System.Drawing.Size(155, 32);
            this.empleadosToolStripMenuItem.Text = "&Empleados";
            this.empleadosToolStripMenuItem.Click += new System.EventHandler(this.empleadosToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Image = global::SISTEMA.MAINMENU.Properties.Resources.USUARIOS;
            this.usuariosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(155, 32);
            this.usuariosToolStripMenuItem.Text = "&Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // toolStripButtonCitas
            // 
            this.toolStripButtonCitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonCitas.Image = global::SISTEMA.MAINMENU.Properties.Resources.CITAS;
            this.toolStripButtonCitas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCitas.Name = "toolStripButtonCitas";
            this.toolStripButtonCitas.Size = new System.Drawing.Size(58, 48);
            this.toolStripButtonCitas.Text = "Citas";
            this.toolStripButtonCitas.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Clientes
            // 
            this.Clientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clientes.Image = global::SISTEMA.MAINMENU.Properties.Resources.CLIENTES;
            this.Clientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Clientes.Name = "Clientes";
            this.Clientes.Size = new System.Drawing.Size(76, 48);
            this.Clientes.Text = "Clientes";
            this.Clientes.Click += new System.EventHandler(this.Clientes_Click);
            // 
            // Herramientas
            // 
            this.Herramientas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blocDeNotasToolStripMenuItem,
            this.calculcadoraToolStripMenuItem});
            this.Herramientas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Herramientas.Image = global::SISTEMA.MAINMENU.Properties.Resources.HERRAMIENTAS;
            this.Herramientas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Herramientas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Herramientas.Name = "Herramientas";
            this.Herramientas.Size = new System.Drawing.Size(118, 48);
            this.Herramientas.Text = "&Herramientas";
            // 
            // blocDeNotasToolStripMenuItem
            // 
            this.blocDeNotasToolStripMenuItem.Image = global::SISTEMA.MAINMENU.Properties.Resources.BLOC;
            this.blocDeNotasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.blocDeNotasToolStripMenuItem.Name = "blocDeNotasToolStripMenuItem";
            this.blocDeNotasToolStripMenuItem.Size = new System.Drawing.Size(170, 32);
            this.blocDeNotasToolStripMenuItem.Text = "Bloc de Notas";
            this.blocDeNotasToolStripMenuItem.Click += new System.EventHandler(this.blocDeNotasToolStripMenuItem_Click);
            // 
            // calculcadoraToolStripMenuItem
            // 
            this.calculcadoraToolStripMenuItem.Image = global::SISTEMA.MAINMENU.Properties.Resources.CALCULADORA;
            this.calculcadoraToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.calculcadoraToolStripMenuItem.Name = "calculcadoraToolStripMenuItem";
            this.calculcadoraToolStripMenuItem.Size = new System.Drawing.Size(170, 32);
            this.calculcadoraToolStripMenuItem.Text = "Calculcadora";
            this.calculcadoraToolStripMenuItem.Click += new System.EventHandler(this.calculcadoraToolStripMenuItem_Click);
            // 
            // Configuracion
            // 
            this.Configuracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.tamañosToolStripMenuItem,
            this.tipoDePermisosToolStripMenuItem,
            this.tiposDeEmpleadosToolStripMenuItem});
            this.Configuracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Configuracion.Image = global::SISTEMA.MAINMENU.Properties.Resources.CONFIGURACION;
            this.Configuracion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Configuracion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Configuracion.Name = "Configuracion";
            this.Configuracion.Size = new System.Drawing.Size(119, 48);
            this.Configuracion.Text = "&Configuración";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(209, 6);
            // 
            // tamañosToolStripMenuItem
            // 
            this.tamañosToolStripMenuItem.Image = global::SISTEMA.MAINMENU.Properties.Resources.TIPO;
            this.tamañosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tamañosToolStripMenuItem.Name = "tamañosToolStripMenuItem";
            this.tamañosToolStripMenuItem.Size = new System.Drawing.Size(212, 32);
            this.tamañosToolStripMenuItem.Text = "Tamaños";
            this.tamañosToolStripMenuItem.Click += new System.EventHandler(this.tamañosToolStripMenuItem_Click);
            // 
            // tipoDePermisosToolStripMenuItem
            // 
            this.tipoDePermisosToolStripMenuItem.Image = global::SISTEMA.MAINMENU.Properties.Resources.TIPO;
            this.tipoDePermisosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tipoDePermisosToolStripMenuItem.Name = "tipoDePermisosToolStripMenuItem";
            this.tipoDePermisosToolStripMenuItem.Size = new System.Drawing.Size(212, 32);
            this.tipoDePermisosToolStripMenuItem.Text = "Tipo de Permisos";
            this.tipoDePermisosToolStripMenuItem.Click += new System.EventHandler(this.tipoDePermisosToolStripMenuItem_Click);
            // 
            // tiposDeEmpleadosToolStripMenuItem
            // 
            this.tiposDeEmpleadosToolStripMenuItem.Image = global::SISTEMA.MAINMENU.Properties.Resources.TIPO;
            this.tiposDeEmpleadosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tiposDeEmpleadosToolStripMenuItem.Name = "tiposDeEmpleadosToolStripMenuItem";
            this.tiposDeEmpleadosToolStripMenuItem.Size = new System.Drawing.Size(212, 32);
            this.tiposDeEmpleadosToolStripMenuItem.Text = "Tipos de Empleados";
            this.tiposDeEmpleadosToolStripMenuItem.Click += new System.EventHandler(this.tiposDeEmpleadosToolStripMenuItem_Click);
            // 
            // LogOut
            // 
            this.LogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOut.Image = global::SISTEMA.MAINMENU.Properties.Resources.LOGOUT2;
            this.LogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LogOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(71, 48);
            this.LogOut.Text = "&LogOut";
            this.LogOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // Salir
            // 
            this.Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salir.Image = global::SISTEMA.MAINMENU.Properties.Resources.SALIR2;
            this.Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(55, 48);
            this.Salir.Text = "Salir";
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // Reloj
            // 
            this.Reloj.Enabled = true;
            this.Reloj.Tick += new System.EventHandler(this.Reloj_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(1139, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "00:00:00";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(1139, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Dia_semana";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(1139, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Dia_mes_año";
            // 
            // Panel
            // 
            this.Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel.BackColor = System.Drawing.Color.White;
            this.Panel.BackgroundImage = global::SISTEMA.MAINMENU.Properties.Resources.LOGO_FINAL;
            this.Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel.Location = new System.Drawing.Point(0, 53);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(1246, 414);
            this.Panel.TabIndex = 2;
            // 
            // Disparador
            // 
            this.Disparador.Enabled = true;
            this.Disparador.Tick += new System.EventHandler(this.Disparador_Tick);
            // 
            // EnvioCorreo
            // 
            this.EnvioCorreo.Tick += new System.EventHandler(this.EnvioCorreo_Tick);
            // 
            // FORMA_PADRE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 467);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FORMA_PADRE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FORMA_PADRE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FORMA_PADRE_Load_1);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton Administrar;
        private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton Herramientas;
        private System.Windows.Forms.ToolStripMenuItem blocDeNotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculcadoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton Configuracion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton LogOut;
        private System.Windows.Forms.ToolStripButton Salir;
        private System.Windows.Forms.Timer Reloj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem tamañosToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonCitas;
        private System.Windows.Forms.ToolStripButton Clientes;
        private System.Windows.Forms.ToolStripMenuItem tipoDePermisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeEmpleadosToolStripMenuItem;
        private System.Windows.Forms.Timer Disparador;
        private System.Windows.Forms.Timer EnvioCorreo;
    }
}