namespace smart_inventory
{
    partial class Productos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Productos));
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnNuevoProducto = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gbListaProductos = new System.Windows.Forms.GroupBox();
            this.lblTotalUsuarios = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnEditarProducto = new System.Windows.Forms.Button();
            this.btnBorrarProducto = new System.Windows.Forms.Button();
            this.pic_users = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDatosProductos = new System.Windows.Forms.GroupBox();
            this.cbxCategoria = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStockMinimo = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.txtPrecioCompra = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.gbListaProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_users)).BeginInit();
            this.gbBusqueda.SuspendLayout();
            this.gbDatosProductos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.BackColor = System.Drawing.Color.DimGray;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.Location = new System.Drawing.Point(579, 290);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(166, 40);
            this.btnLimpiar.TabIndex = 70;
            this.btnLimpiar.Text = "🔄 Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnNuevoProducto
            // 
            this.btnNuevoProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoProducto.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnNuevoProducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoProducto.ForeColor = System.Drawing.SystemColors.Control;
            this.btnNuevoProducto.Location = new System.Drawing.Point(579, 75);
            this.btnNuevoProducto.Name = "btnNuevoProducto";
            this.btnNuevoProducto.Size = new System.Drawing.Size(166, 40);
            this.btnNuevoProducto.TabIndex = 69;
            this.btnNuevoProducto.Text = "➕ Agregar";
            this.btnNuevoProducto.UseVisualStyleBackColor = false;
            this.btnNuevoProducto.Click += new System.EventHandler(this.btnNuevoProducto_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 36);
            this.label2.TabIndex = 65;
            this.label2.Text = "Productos";
            // 
            // gbListaProductos
            // 
            this.gbListaProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbListaProductos.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbListaProductos.Controls.Add(this.lblTotalUsuarios);
            this.gbListaProductos.Controls.Add(this.dgvProductos);
            this.gbListaProductos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbListaProductos.Location = new System.Drawing.Point(14, 446);
            this.gbListaProductos.Name = "gbListaProductos";
            this.gbListaProductos.Size = new System.Drawing.Size(740, 250);
            this.gbListaProductos.TabIndex = 74;
            this.gbListaProductos.TabStop = false;
            this.gbListaProductos.Text = "Lista de Productos";
            // 
            // lblTotalUsuarios
            // 
            this.lblTotalUsuarios.AutoSize = true;
            this.lblTotalUsuarios.Location = new System.Drawing.Point(652, 0);
            this.lblTotalUsuarios.Name = "lblTotalUsuarios";
            this.lblTotalUsuarios.Size = new System.Drawing.Size(65, 21);
            this.lblTotalUsuarios.TabIndex = 1;
            this.lblTotalUsuarios.Text = "Total: 0";
            // 
            // dgvProductos
            // 
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(6, 24);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.Size = new System.Drawing.Size(725, 220);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            // 
            // btnEditarProducto
            // 
            this.btnEditarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarProducto.BackColor = System.Drawing.Color.ForestGreen;
            this.btnEditarProducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarProducto.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEditarProducto.Location = new System.Drawing.Point(579, 146);
            this.btnEditarProducto.Name = "btnEditarProducto";
            this.btnEditarProducto.Size = new System.Drawing.Size(166, 40);
            this.btnEditarProducto.TabIndex = 72;
            this.btnEditarProducto.Text = "✏️ Editar";
            this.btnEditarProducto.UseVisualStyleBackColor = false;
            this.btnEditarProducto.Click += new System.EventHandler(this.btnEditarProducto_Click);
            // 
            // btnBorrarProducto
            // 
            this.btnBorrarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorrarProducto.BackColor = System.Drawing.Color.Red;
            this.btnBorrarProducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarProducto.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBorrarProducto.Location = new System.Drawing.Point(579, 219);
            this.btnBorrarProducto.Name = "btnBorrarProducto";
            this.btnBorrarProducto.Size = new System.Drawing.Size(166, 40);
            this.btnBorrarProducto.TabIndex = 71;
            this.btnBorrarProducto.Text = "🗑️ Eliminar";
            this.btnBorrarProducto.UseVisualStyleBackColor = false;
            this.btnBorrarProducto.Click += new System.EventHandler(this.btnBorrarProducto_Click);
            // 
            // pic_users
            // 
            this.pic_users.BackColor = System.Drawing.SystemColors.Control;
            this.pic_users.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic_users.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_users.Image = ((System.Drawing.Image)(resources.GetObject("pic_users.Image")));
            this.pic_users.Location = new System.Drawing.Point(20, 5);
            this.pic_users.Name = "pic_users";
            this.pic_users.Size = new System.Drawing.Size(50, 54);
            this.pic_users.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_users.TabIndex = 67;
            this.pic_users.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.Location = new System.Drawing.Point(9, 64);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 3);
            this.panel1.TabIndex = 66;
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBusqueda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbBusqueda.Controls.Add(this.txtBuscarProducto);
            this.gbBusqueda.Controls.Add(this.label1);
            this.gbBusqueda.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbBusqueda.Location = new System.Drawing.Point(14, 370);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(537, 69);
            this.gbBusqueda.TabIndex = 73;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Buscar Producto";
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarProducto.Location = new System.Drawing.Point(62, 28);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(469, 29);
            this.txtBuscarProducto.TabIndex = 1;
            this.txtBuscarProducto.TextChanged += new System.EventHandler(this.txtBuscarProducto_TextChanged);
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
            // gbDatosProductos
            // 
            this.gbDatosProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDatosProductos.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbDatosProductos.Controls.Add(this.cbxCategoria);
            this.gbDatosProductos.Controls.Add(this.label10);
            this.gbDatosProductos.Controls.Add(this.label9);
            this.gbDatosProductos.Controls.Add(this.label8);
            this.gbDatosProductos.Controls.Add(this.label7);
            this.gbDatosProductos.Controls.Add(this.label6);
            this.gbDatosProductos.Controls.Add(this.label5);
            this.gbDatosProductos.Controls.Add(this.txtStockMinimo);
            this.gbDatosProductos.Controls.Add(this.txtStock);
            this.gbDatosProductos.Controls.Add(this.txtPrecioVenta);
            this.gbDatosProductos.Controls.Add(this.txtPrecioCompra);
            this.gbDatosProductos.Controls.Add(this.txtNombre);
            this.gbDatosProductos.Controls.Add(this.txtDescripcion);
            this.gbDatosProductos.Controls.Add(this.lblUsuario);
            this.gbDatosProductos.Controls.Add(this.txtCodigo);
            this.gbDatosProductos.Controls.Add(this.lblNombre);
            this.gbDatosProductos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatosProductos.Location = new System.Drawing.Point(14, 75);
            this.gbDatosProductos.Name = "gbDatosProductos";
            this.gbDatosProductos.Size = new System.Drawing.Size(537, 289);
            this.gbDatosProductos.TabIndex = 68;
            this.gbDatosProductos.TabStop = false;
            this.gbDatosProductos.Text = "Datos de Productos";
            // 
            // cbxCategoria
            // 
            this.cbxCategoria.FormattingEnabled = true;
            this.cbxCategoria.Location = new System.Drawing.Point(386, 117);
            this.cbxCategoria.Margin = new System.Windows.Forms.Padding(2);
            this.cbxCategoria.Name = "cbxCategoria";
            this.cbxCategoria.Size = new System.Drawing.Size(315, 29);
            this.cbxCategoria.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(382, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 21);
            this.label10.TabIndex = 23;
            this.label10.Text = "Stock Minimo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 21);
            this.label9.TabIndex = 22;
            this.label9.Text = "Stock:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(381, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 21);
            this.label8.TabIndex = 21;
            this.label8.Text = "Precio Venta:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 21);
            this.label7.TabIndex = 20;
            this.label7.Text = "Precio Compra:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(382, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 21);
            this.label6.TabIndex = 19;
            this.label6.Text = "Categoria";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(382, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 21);
            this.label5.TabIndex = 18;
            this.label5.Text = "Nombre:";
            // 
            // txtStockMinimo
            // 
            this.txtStockMinimo.Location = new System.Drawing.Point(386, 250);
            this.txtStockMinimo.Name = "txtStockMinimo";
            this.txtStockMinimo.Size = new System.Drawing.Size(315, 29);
            this.txtStockMinimo.TabIndex = 17;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(27, 250);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(315, 29);
            this.txtStock.TabIndex = 16;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(385, 179);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(316, 29);
            this.txtPrecioVenta.TabIndex = 15;
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.Location = new System.Drawing.Point(27, 179);
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.Size = new System.Drawing.Size(315, 29);
            this.txtPrecioCompra.TabIndex = 14;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(385, 53);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(316, 29);
            this.txtNombre.TabIndex = 12;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(27, 117);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(315, 29);
            this.txtDescripcion.TabIndex = 7;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(23, 93);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(98, 21);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "Descripcion:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(27, 53);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(315, 29);
            this.txtCodigo.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(23, 25);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(65, 21);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Codigo:";
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnNuevoProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbListaProductos);
            this.Controls.Add(this.btnEditarProducto);
            this.Controls.Add(this.btnBorrarProducto);
            this.Controls.Add(this.pic_users);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.gbDatosProductos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Productos_Load);
            this.gbListaProductos.ResumeLayout(false);
            this.gbListaProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_users)).EndInit();
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            this.gbDatosProductos.ResumeLayout(false);
            this.gbDatosProductos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnNuevoProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbListaProductos;
        private System.Windows.Forms.Label lblTotalUsuarios;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnEditarProducto;
        private System.Windows.Forms.Button btnBorrarProducto;
        private System.Windows.Forms.PictureBox pic_users;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbDatosProductos;
        private System.Windows.Forms.ComboBox cbxCategoria;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStockMinimo;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblNombre;
    }
}