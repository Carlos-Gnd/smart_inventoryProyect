namespace smart_inventory
{
    partial class Categorias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Categorias));
            this.btnEditarCategoria = new System.Windows.Forms.Button();
            this.btnBorrarCategoria = new System.Windows.Forms.Button();
            this.pic_users = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbDatosCategoria = new System.Windows.Forms.GroupBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnNuevoCategoria = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gbListaCategorias = new System.Windows.Forms.GroupBox();
            this.lblTotalCategorias = new System.Windows.Forms.Label();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.txtBuscarCategoria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_users)).BeginInit();
            this.gbDatosCategoria.SuspendLayout();
            this.gbListaCategorias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.gbBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEditarCategoria
            // 
            this.btnEditarCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarCategoria.BackColor = System.Drawing.Color.ForestGreen;
            this.btnEditarCategoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarCategoria.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEditarCategoria.Location = new System.Drawing.Point(551, 162);
            this.btnEditarCategoria.Name = "btnEditarCategoria";
            this.btnEditarCategoria.Size = new System.Drawing.Size(199, 40);
            this.btnEditarCategoria.TabIndex = 61;
            this.btnEditarCategoria.Text = "✏️ Editar Categoria";
            this.btnEditarCategoria.UseVisualStyleBackColor = false;
            this.btnEditarCategoria.Click += new System.EventHandler(this.btnEditarCategoria_Click);
            // 
            // btnBorrarCategoria
            // 
            this.btnBorrarCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorrarCategoria.BackColor = System.Drawing.Color.Red;
            this.btnBorrarCategoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarCategoria.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBorrarCategoria.Location = new System.Drawing.Point(551, 230);
            this.btnBorrarCategoria.Name = "btnBorrarCategoria";
            this.btnBorrarCategoria.Size = new System.Drawing.Size(199, 40);
            this.btnBorrarCategoria.TabIndex = 60;
            this.btnBorrarCategoria.Text = "🗑️ Eliminar Categoria";
            this.btnBorrarCategoria.UseVisualStyleBackColor = false;
            this.btnBorrarCategoria.Click += new System.EventHandler(this.btnBorrarCategoria_Click);
            // 
            // pic_users
            // 
            this.pic_users.BackColor = System.Drawing.SystemColors.Control;
            this.pic_users.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic_users.Image = ((System.Drawing.Image)(resources.GetObject("pic_users.Image")));
            this.pic_users.Location = new System.Drawing.Point(29, 26);
            this.pic_users.Name = "pic_users";
            this.pic_users.Size = new System.Drawing.Size(50, 54);
            this.pic_users.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_users.TabIndex = 56;
            this.pic_users.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.Location = new System.Drawing.Point(18, 84);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 3);
            this.panel1.TabIndex = 55;
            // 
            // gbDatosCategoria
            // 
            this.gbDatosCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDatosCategoria.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbDatosCategoria.Controls.Add(this.chkActivo);
            this.gbDatosCategoria.Controls.Add(this.txtDescripcion);
            this.gbDatosCategoria.Controls.Add(this.lblUsuario);
            this.gbDatosCategoria.Controls.Add(this.txtNombre);
            this.gbDatosCategoria.Controls.Add(this.lblNombre);
            this.gbDatosCategoria.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatosCategoria.Location = new System.Drawing.Point(23, 95);
            this.gbDatosCategoria.Name = "gbDatosCategoria";
            this.gbDatosCategoria.Size = new System.Drawing.Size(435, 240);
            this.gbDatosCategoria.TabIndex = 57;
            this.gbDatosCategoria.TabStop = false;
            this.gbDatosCategoria.Text = "Datos de la Categoria";
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(27, 191);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(150, 25);
            this.chkActivo.TabIndex = 11;
            this.chkActivo.Text = "Categoria Activa";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(27, 135);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(329, 29);
            this.txtDescripcion.TabIndex = 7;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(23, 111);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(98, 21);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "Descripcion:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(27, 62);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(329, 29);
            this.txtNombre.TabIndex = 2;
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
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.BackColor = System.Drawing.Color.DimGray;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.Location = new System.Drawing.Point(551, 296);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(199, 40);
            this.btnLimpiar.TabIndex = 59;
            this.btnLimpiar.Text = "🔄 Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnNuevoCategoria
            // 
            this.btnNuevoCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoCategoria.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnNuevoCategoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoCategoria.ForeColor = System.Drawing.SystemColors.Control;
            this.btnNuevoCategoria.Location = new System.Drawing.Point(551, 96);
            this.btnNuevoCategoria.Name = "btnNuevoCategoria";
            this.btnNuevoCategoria.Size = new System.Drawing.Size(199, 40);
            this.btnNuevoCategoria.TabIndex = 58;
            this.btnNuevoCategoria.Text = "➕ Agregar Categoria";
            this.btnNuevoCategoria.UseVisualStyleBackColor = false;
            this.btnNuevoCategoria.Click += new System.EventHandler(this.btnNuevoCategoria_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 36);
            this.label2.TabIndex = 54;
            this.label2.Text = "Categorias";
            // 
            // gbListaCategorias
            // 
            this.gbListaCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbListaCategorias.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbListaCategorias.Controls.Add(this.lblTotalCategorias);
            this.gbListaCategorias.Controls.Add(this.dgvCategorias);
            this.gbListaCategorias.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbListaCategorias.Location = new System.Drawing.Point(23, 442);
            this.gbListaCategorias.Name = "gbListaCategorias";
            this.gbListaCategorias.Size = new System.Drawing.Size(694, 259);
            this.gbListaCategorias.TabIndex = 62;
            this.gbListaCategorias.TabStop = false;
            this.gbListaCategorias.Text = "Lista de Categorias";
            // 
            // lblTotalCategorias
            // 
            this.lblTotalCategorias.AutoSize = true;
            this.lblTotalCategorias.Location = new System.Drawing.Point(745, 12);
            this.lblTotalCategorias.Name = "lblTotalCategorias";
            this.lblTotalCategorias.Size = new System.Drawing.Size(65, 21);
            this.lblTotalCategorias.TabIndex = 1;
            this.lblTotalCategorias.Text = "Total: 0";
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCategorias.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Location = new System.Drawing.Point(6, 36);
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.RowHeadersWidth = 51;
            this.dgvCategorias.Size = new System.Drawing.Size(673, 212);
            this.dgvCategorias.TabIndex = 0;
            this.dgvCategorias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategorias_CellClick);
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBusqueda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbBusqueda.Controls.Add(this.txtBuscarCategoria);
            this.gbBusqueda.Controls.Add(this.label1);
            this.gbBusqueda.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbBusqueda.Location = new System.Drawing.Point(23, 354);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(694, 69);
            this.gbBusqueda.TabIndex = 63;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Buscar Categoria";
            // 
            // txtBuscarCategoria
            // 
            this.txtBuscarCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarCategoria.Location = new System.Drawing.Point(62, 28);
            this.txtBuscarCategoria.Name = "txtBuscarCategoria";
            this.txtBuscarCategoria.Size = new System.Drawing.Size(626, 29);
            this.txtBuscarCategoria.TabIndex = 1;
            this.txtBuscarCategoria.TextChanged += new System.EventHandler(this.txtBuscarCategoria_TextChanged);
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
            // Categorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1001, 661);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.btnEditarCategoria);
            this.Controls.Add(this.btnBorrarCategoria);
            this.Controls.Add(this.pic_users);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbDatosCategoria);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnNuevoCategoria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbListaCategorias);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Categorias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categorias";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pic_users)).EndInit();
            this.gbDatosCategoria.ResumeLayout(false);
            this.gbDatosCategoria.PerformLayout();
            this.gbListaCategorias.ResumeLayout(false);
            this.gbListaCategorias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEditarCategoria;
        private System.Windows.Forms.Button btnBorrarCategoria;
        private System.Windows.Forms.PictureBox pic_users;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbDatosCategoria;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnNuevoCategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbListaCategorias;
        private System.Windows.Forms.Label lblTotalCategorias;
        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.TextBox txtBuscarCategoria;
        private System.Windows.Forms.Label label1;
    }
}