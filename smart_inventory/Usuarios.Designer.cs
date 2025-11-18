namespace smart_inventory
{
    partial class Usuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usuarios));
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbDatosUsuario = new System.Windows.Forms.GroupBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.cboRol = new System.Windows.Forms.ComboBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnNuevoUser = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBorrarUser = new System.Windows.Forms.Button();
            this.btnEditarUser = new System.Windows.Forms.Button();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.txtBuscarUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbListaUsuarios = new System.Windows.Forms.GroupBox();
            this.lblTotalUsuarios = new System.Windows.Forms.Label();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.pic_users = new System.Windows.Forms.PictureBox();
            this.gbDatosUsuario.SuspendLayout();
            this.gbBusqueda.SuspendLayout();
            this.gbListaUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_users)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 45);
            this.label2.TabIndex = 7;
            this.label2.Text = "Gestión de Usuarios";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.Location = new System.Drawing.Point(13, 82);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 3);
            this.panel1.TabIndex = 9;
            // 
            // gbDatosUsuario
            // 
            this.gbDatosUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDatosUsuario.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbDatosUsuario.Controls.Add(this.chkActivo);
            this.gbDatosUsuario.Controls.Add(this.cboRol);
            this.gbDatosUsuario.Controls.Add(this.lblRol);
            this.gbDatosUsuario.Controls.Add(this.txtClave);
            this.gbDatosUsuario.Controls.Add(this.txtUsuario);
            this.gbDatosUsuario.Controls.Add(this.lblUsuario);
            this.gbDatosUsuario.Controls.Add(this.lblContraseña);
            this.gbDatosUsuario.Controls.Add(this.txtApellido);
            this.gbDatosUsuario.Controls.Add(this.txtNombre);
            this.gbDatosUsuario.Controls.Add(this.lblApellido);
            this.gbDatosUsuario.Controls.Add(this.lblNombre);
            this.gbDatosUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatosUsuario.Location = new System.Drawing.Point(17, 93);
            this.gbDatosUsuario.Name = "gbDatosUsuario";
            this.gbDatosUsuario.Size = new System.Drawing.Size(583, 255);
            this.gbDatosUsuario.TabIndex = 27;
            this.gbDatosUsuario.TabStop = false;
            this.gbDatosUsuario.Text = "Datos del Usuario";
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(384, 215);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(135, 25);
            this.chkActivo.TabIndex = 11;
            this.chkActivo.Text = "Usuario Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // cboRol
            // 
            this.cboRol.FormattingEnabled = true;
            this.cboRol.Location = new System.Drawing.Point(27, 211);
            this.cboRol.Name = "cboRol";
            this.cboRol.Size = new System.Drawing.Size(329, 29);
            this.cboRol.TabIndex = 10;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(23, 186);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(38, 21);
            this.lblRol.TabIndex = 9;
            this.lblRol.Text = "Rol:";
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(384, 135);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '●';
            this.txtClave.Size = new System.Drawing.Size(329, 29);
            this.txtClave.TabIndex = 8;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(27, 135);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(329, 29);
            this.txtUsuario.TabIndex = 7;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(23, 111);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(70, 21);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(380, 111);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(96, 21);
            this.lblContraseña.TabIndex = 5;
            this.lblContraseña.Text = "Contraseña:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(384, 62);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(329, 29);
            this.txtApellido.TabIndex = 4;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(27, 62);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(329, 29);
            this.txtNombre.TabIndex = 2;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(380, 34);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(75, 21);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(23, 34);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(72, 21);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // btnNuevoUser
            // 
            this.btnNuevoUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoUser.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnNuevoUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoUser.ForeColor = System.Drawing.SystemColors.Control;
            this.btnNuevoUser.Location = new System.Drawing.Point(614, 93);
            this.btnNuevoUser.Name = "btnNuevoUser";
            this.btnNuevoUser.Size = new System.Drawing.Size(203, 40);
            this.btnNuevoUser.TabIndex = 28;
            this.btnNuevoUser.Text = "➕ Nuevo Usuario";
            this.btnNuevoUser.UseVisualStyleBackColor = false;
            this.btnNuevoUser.Click += new System.EventHandler(this.btnNuevoUser_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.BackColor = System.Drawing.Color.DimGray;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.Location = new System.Drawing.Point(614, 308);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(203, 40);
            this.btnLimpiar.TabIndex = 29;
            this.btnLimpiar.Text = "🔄 Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBorrarUser
            // 
            this.btnBorrarUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorrarUser.BackColor = System.Drawing.Color.Red;
            this.btnBorrarUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarUser.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBorrarUser.Location = new System.Drawing.Point(614, 237);
            this.btnBorrarUser.Name = "btnBorrarUser";
            this.btnBorrarUser.Size = new System.Drawing.Size(203, 40);
            this.btnBorrarUser.TabIndex = 30;
            this.btnBorrarUser.Text = "🗑️ Eliminar  Usuario";
            this.btnBorrarUser.UseVisualStyleBackColor = false;
            this.btnBorrarUser.Click += new System.EventHandler(this.btnBorrarUser_Click);
            // 
            // btnEditarUser
            // 
            this.btnEditarUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarUser.BackColor = System.Drawing.Color.ForestGreen;
            this.btnEditarUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarUser.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEditarUser.Location = new System.Drawing.Point(614, 164);
            this.btnEditarUser.Name = "btnEditarUser";
            this.btnEditarUser.Size = new System.Drawing.Size(203, 40);
            this.btnEditarUser.TabIndex = 31;
            this.btnEditarUser.Text = "✏️ Editar Usuario";
            this.btnEditarUser.UseVisualStyleBackColor = false;
            this.btnEditarUser.Click += new System.EventHandler(this.btnEditarUser_Click);
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBusqueda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbBusqueda.Controls.Add(this.txtBuscarUsuario);
            this.gbBusqueda.Controls.Add(this.label1);
            this.gbBusqueda.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbBusqueda.Location = new System.Drawing.Point(17, 363);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(498, 69);
            this.gbBusqueda.TabIndex = 32;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Buscar Usuario";
            // 
            // txtBuscarUsuario
            // 
            this.txtBuscarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarUsuario.Location = new System.Drawing.Point(62, 28);
            this.txtBuscarUsuario.Name = "txtBuscarUsuario";
            this.txtBuscarUsuario.Size = new System.Drawing.Size(430, 29);
            this.txtBuscarUsuario.TabIndex = 1;
            this.txtBuscarUsuario.TextChanged += new System.EventHandler(this.txtBuscarUsuario_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "🔍";
            // 
            // gbListaUsuarios
            // 
            this.gbListaUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbListaUsuarios.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbListaUsuarios.Controls.Add(this.lblTotalUsuarios);
            this.gbListaUsuarios.Controls.Add(this.dgvUsuarios);
            this.gbListaUsuarios.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbListaUsuarios.Location = new System.Drawing.Point(17, 451);
            this.gbListaUsuarios.Name = "gbListaUsuarios";
            this.gbListaUsuarios.Size = new System.Drawing.Size(763, 259);
            this.gbListaUsuarios.TabIndex = 33;
            this.gbListaUsuarios.TabStop = false;
            this.gbListaUsuarios.Text = "Lista de Usuarios";
            // 
            // lblTotalUsuarios
            // 
            this.lblTotalUsuarios.AutoSize = true;
            this.lblTotalUsuarios.Location = new System.Drawing.Point(654, 12);
            this.lblTotalUsuarios.Name = "lblTotalUsuarios";
            this.lblTotalUsuarios.Size = new System.Drawing.Size(65, 21);
            this.lblTotalUsuarios.TabIndex = 1;
            this.lblTotalUsuarios.Text = "Total: 0";
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(6, 36);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(751, 212);
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            // 
            // pic_users
            // 
            this.pic_users.BackColor = System.Drawing.SystemColors.Control;
            this.pic_users.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic_users.Image = ((System.Drawing.Image)(resources.GetObject("pic_users.Image")));
            this.pic_users.Location = new System.Drawing.Point(17, 11);
            this.pic_users.Name = "pic_users";
            this.pic_users.Size = new System.Drawing.Size(66, 66);
            this.pic_users.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_users.TabIndex = 37;
            this.pic_users.TabStop = false;
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1001, 661);
            this.Controls.Add(this.pic_users);
            this.Controls.Add(this.gbListaUsuarios);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.btnEditarUser);
            this.Controls.Add(this.btnBorrarUser);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnNuevoUser);
            this.Controls.Add(this.gbDatosUsuario);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Usuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Usuarios_Load);
            this.gbDatosUsuario.ResumeLayout(false);
            this.gbDatosUsuario.PerformLayout();
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            this.gbListaUsuarios.ResumeLayout(false);
            this.gbListaUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_users)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbDatosUsuario;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Button btnNuevoUser;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBorrarUser;
        private System.Windows.Forms.Button btnEditarUser;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.TextBox txtBuscarUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbListaUsuarios;
        private System.Windows.Forms.Label lblTotalUsuarios;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.PictureBox pic_users;
    }
}