namespace smart_inventory
{
    partial class VentasPropias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentasPropias));
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.cbFiltro = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBuscarVenta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbTablaVentas = new System.Windows.Forms.GroupBox();
            this.lblTotalUsuarios = new System.Windows.Forms.Label();
            this.dgvTablaVentasPropias = new System.Windows.Forms.DataGridView();
            this.pic_users = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.btnImprimirTicket = new System.Windows.Forms.Button();
            this.gbBusqueda.SuspendLayout();
            this.gbTablaVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaVentasPropias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_users)).BeginInit();
            this.SuspendLayout();
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBusqueda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbBusqueda.Controls.Add(this.cbFiltro);
            this.gbBusqueda.Controls.Add(this.label3);
            this.gbBusqueda.Controls.Add(this.txtBuscarVenta);
            this.gbBusqueda.Controls.Add(this.label1);
            this.gbBusqueda.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbBusqueda.Location = new System.Drawing.Point(19, 102);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(944, 69);
            this.gbBusqueda.TabIndex = 76;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Buscar Categoria";
            // 
            // cbFiltro
            // 
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Location = new System.Drawing.Point(760, 28);
            this.cbFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(154, 29);
            this.cbFiltro.TabIndex = 3;
            this.cbFiltro.SelectedIndexChanged += new System.EventHandler(this.cbFiltro_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(718, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Por:";
            // 
            // txtBuscarVenta
            // 
            this.txtBuscarVenta.Location = new System.Drawing.Point(62, 28);
            this.txtBuscarVenta.Name = "txtBuscarVenta";
            this.txtBuscarVenta.Size = new System.Drawing.Size(651, 29);
            this.txtBuscarVenta.TabIndex = 1;
            this.txtBuscarVenta.TextChanged += new System.EventHandler(this.txtBuscarVenta_TextChanged);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(97, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 45);
            this.label2.TabIndex = 72;
            this.label2.Text = "Ventas propias";
            // 
            // gbTablaVentas
            // 
            this.gbTablaVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTablaVentas.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbTablaVentas.Controls.Add(this.lblTotalUsuarios);
            this.gbTablaVentas.Controls.Add(this.dgvTablaVentasPropias);
            this.gbTablaVentas.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbTablaVentas.Location = new System.Drawing.Point(21, 243);
            this.gbTablaVentas.Name = "gbTablaVentas";
            this.gbTablaVentas.Size = new System.Drawing.Size(944, 417);
            this.gbTablaVentas.TabIndex = 75;
            this.gbTablaVentas.TabStop = false;
            this.gbTablaVentas.Text = "Tabla de ventas propias";
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
            // dgvTablaVentasPropias
            // 
            this.dgvTablaVentasPropias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTablaVentasPropias.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTablaVentasPropias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablaVentasPropias.Location = new System.Drawing.Point(6, 36);
            this.dgvTablaVentasPropias.Name = "dgvTablaVentasPropias";
            this.dgvTablaVentasPropias.RowHeadersWidth = 51;
            this.dgvTablaVentasPropias.Size = new System.Drawing.Size(923, 370);
            this.dgvTablaVentasPropias.TabIndex = 0;
            this.dgvTablaVentasPropias.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTablaVentasPropias_CellDoubleClick);
            this.dgvTablaVentasPropias.SelectionChanged += new System.EventHandler(this.dgvTablaVentasPropias_SelectionChanged);
            // 
            // pic_users
            // 
            this.pic_users.BackColor = System.Drawing.SystemColors.Control;
            this.pic_users.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic_users.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_users.Image = ((System.Drawing.Image)(resources.GetObject("pic_users.Image")));
            this.pic_users.Location = new System.Drawing.Point(32, 12);
            this.pic_users.Name = "pic_users";
            this.pic_users.Size = new System.Drawing.Size(60, 62);
            this.pic_users.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_users.TabIndex = 74;
            this.pic_users.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.Location = new System.Drawing.Point(21, 81);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 3);
            this.panel1.TabIndex = 73;
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BackColor = System.Drawing.Color.ForestGreen;
            this.btnExportarExcel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.Location = new System.Drawing.Point(236, 186);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(209, 40);
            this.btnExportarExcel.TabIndex = 78;
            this.btnExportarExcel.Text = "📊 Exportar Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.BackColor = System.Drawing.Color.Red;
            this.btnExportarPDF.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportarPDF.Location = new System.Drawing.Point(451, 186);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(209, 40);
            this.btnExportarPDF.TabIndex = 77;
            this.btnExportarPDF.Text = "📥 Exportar PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = false;
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.BackColor = System.Drawing.Color.Orange;
            this.btnVerDetalle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDetalle.ForeColor = System.Drawing.Color.White;
            this.btnVerDetalle.Location = new System.Drawing.Point(21, 186);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(209, 40);
            this.btnVerDetalle.TabIndex = 79;
            this.btnVerDetalle.Text = "📋 Ver Detalles";
            this.btnVerDetalle.UseVisualStyleBackColor = false;
            this.btnVerDetalle.Click += new System.EventHandler(this.btnVerDetalle_Click);
            // 
            // btnImprimirTicket
            // 
            this.btnImprimirTicket.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnImprimirTicket.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirTicket.ForeColor = System.Drawing.Color.White;
            this.btnImprimirTicket.Location = new System.Drawing.Point(666, 186);
            this.btnImprimirTicket.Name = "btnImprimirTicket";
            this.btnImprimirTicket.Size = new System.Drawing.Size(209, 40);
            this.btnImprimirTicket.TabIndex = 80;
            this.btnImprimirTicket.Text = "🖨️ Imprimir Ticket";
            this.btnImprimirTicket.UseVisualStyleBackColor = false;
            this.btnImprimirTicket.Click += new System.EventHandler(this.btnImprimirTicket_Click);
            // 
            // VentasPropias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.btnImprimirTicket);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnExportarPDF);
            this.Controls.Add(this.btnVerDetalle);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbTablaVentas);
            this.Controls.Add(this.pic_users);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VentasPropias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VentasPropias";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VentasPropias_Load);
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            this.gbTablaVentas.ResumeLayout(false);
            this.gbTablaVentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaVentasPropias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_users)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.ComboBox cbFiltro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBuscarVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbTablaVentas;
        private System.Windows.Forms.Label lblTotalUsuarios;
        private System.Windows.Forms.DataGridView dgvTablaVentasPropias;
        private System.Windows.Forms.PictureBox pic_users;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnExportarPDF;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Button btnImprimirTicket;
    }
}