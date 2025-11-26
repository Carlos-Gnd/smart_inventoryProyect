namespace smart_inventory
{
    partial class Ventas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventas));
            this.label2 = new System.Windows.Forms.Label();
            this.pic_users = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.lblFiltrarCajero = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.btnVerDetalles = new System.Windows.Forms.Button();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cbxMetodoPago = new System.Windows.Forms.ComboBox();
            this.cbxCajero = new System.Windows.Forms.ComboBox();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.gbListaVentas = new System.Windows.Forms.GroupBox();
            this.lblTotalVentas = new System.Windows.Forms.Label();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.gbDetalleVenta = new System.Windows.Forms.GroupBox();
            this.dgvDetalleVenta = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pic_users)).BeginInit();
            this.gbFiltros.SuspendLayout();
            this.gbListaVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.gbDetalleVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(84, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 36);
            this.label2.TabIndex = 57;
            this.label2.Text = "Historial de Ventas";
            // 
            // pic_users
            // 
            this.pic_users.BackColor = System.Drawing.SystemColors.Control;
            this.pic_users.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic_users.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_users.Image = ((System.Drawing.Image)(resources.GetObject("pic_users.Image")));
            this.pic_users.Location = new System.Drawing.Point(21, 11);
            this.pic_users.Name = "pic_users";
            this.pic_users.Size = new System.Drawing.Size(50, 54);
            this.pic_users.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_users.TabIndex = 59;
            this.pic_users.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.Location = new System.Drawing.Point(10, 69);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1103, 3);
            this.panel1.TabIndex = 58;
            // 
            // gbFiltros
            // 
            this.gbFiltros.BackColor = System.Drawing.Color.PaleGreen;
            this.gbFiltros.Controls.Add(this.btnExportarExcel);
            this.gbFiltros.Controls.Add(this.btnExportarPDF);
            this.gbFiltros.Controls.Add(this.lblFiltrarCajero);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Controls.Add(this.lblFechaFin);
            this.gbFiltros.Controls.Add(this.btnVerDetalles);
            this.gbFiltros.Controls.Add(this.lblFechaInicio);
            this.gbFiltros.Controls.Add(this.btnLimpiarFiltros);
            this.gbFiltros.Controls.Add(this.btnBuscar);
            this.gbFiltros.Controls.Add(this.cbxMetodoPago);
            this.gbFiltros.Controls.Add(this.cbxCajero);
            this.gbFiltros.Controls.Add(this.dtpFechaFin);
            this.gbFiltros.Controls.Add(this.dtpFechaInicio);
            this.gbFiltros.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbFiltros.Location = new System.Drawing.Point(10, 77);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(283, 539);
            this.gbFiltros.TabIndex = 60;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BackColor = System.Drawing.Color.ForestGreen;
            this.btnExportarExcel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.Location = new System.Drawing.Point(37, 424);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(209, 40);
            this.btnExportarExcel.TabIndex = 11;
            this.btnExportarExcel.Text = "📊 Exportar Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.BackColor = System.Drawing.Color.Red;
            this.btnExportarPDF.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportarPDF.Location = new System.Drawing.Point(37, 470);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(209, 40);
            this.btnExportarPDF.TabIndex = 10;
            this.btnExportarPDF.Text = "📥 Exportar PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = false;
            // 
            // lblFiltrarCajero
            // 
            this.lblFiltrarCajero.AutoSize = true;
            this.lblFiltrarCajero.Location = new System.Drawing.Point(33, 145);
            this.lblFiltrarCajero.Name = "lblFiltrarCajero";
            this.lblFiltrarCajero.Size = new System.Drawing.Size(133, 21);
            this.lblFiltrarCajero.TabIndex = 9;
            this.lblFiltrarCajero.Text = "Filtrar por Cajero";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Metodo de Pago";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(33, 92);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(95, 21);
            this.lblFechaFin.TabIndex = 7;
            this.lblFechaFin.Text = "Fecha Final:";
            // 
            // btnVerDetalles
            // 
            this.btnVerDetalles.BackColor = System.Drawing.Color.Orange;
            this.btnVerDetalles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDetalles.ForeColor = System.Drawing.Color.White;
            this.btnVerDetalles.Location = new System.Drawing.Point(37, 378);
            this.btnVerDetalles.Name = "btnVerDetalles";
            this.btnVerDetalles.Size = new System.Drawing.Size(209, 40);
            this.btnVerDetalles.TabIndex = 12;
            this.btnVerDetalles.Text = "📋 Ver Detalles";
            this.btnVerDetalles.UseVisualStyleBackColor = false;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(33, 38);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(120, 21);
            this.lblFechaInicio.TabIndex = 6;
            this.lblFechaInicio.Text = "Fecha de Inicio:";
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.BackColor = System.Drawing.Color.Gray;
            this.btnLimpiarFiltros.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(37, 306);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(209, 33);
            this.btnLimpiarFiltros.TabIndex = 5;
            this.btnLimpiarFiltros.Text = "🔄 Limpiar";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(37, 267);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(209, 33);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "🔍 Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // cbxMetodoPago
            // 
            this.cbxMetodoPago.FormattingEnabled = true;
            this.cbxMetodoPago.Location = new System.Drawing.Point(37, 229);
            this.cbxMetodoPago.Name = "cbxMetodoPago";
            this.cbxMetodoPago.Size = new System.Drawing.Size(209, 29);
            this.cbxMetodoPago.TabIndex = 3;
            // 
            // cbxCajero
            // 
            this.cbxCajero.FormattingEnabled = true;
            this.cbxCajero.Location = new System.Drawing.Point(37, 169);
            this.cbxCajero.Name = "cbxCajero";
            this.cbxCajero.Size = new System.Drawing.Size(209, 29);
            this.cbxCajero.TabIndex = 2;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Location = new System.Drawing.Point(37, 116);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(209, 22);
            this.dtpFechaFin.TabIndex = 1;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Location = new System.Drawing.Point(37, 62);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(209, 22);
            this.dtpFechaInicio.TabIndex = 0;
            // 
            // gbListaVentas
            // 
            this.gbListaVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbListaVentas.BackColor = System.Drawing.Color.PaleGreen;
            this.gbListaVentas.Controls.Add(this.lblTotalVentas);
            this.gbListaVentas.Controls.Add(this.dgvVentas);
            this.gbListaVentas.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbListaVentas.Location = new System.Drawing.Point(308, 77);
            this.gbListaVentas.Name = "gbListaVentas";
            this.gbListaVentas.Size = new System.Drawing.Size(843, 268);
            this.gbListaVentas.TabIndex = 65;
            this.gbListaVentas.TabStop = false;
            this.gbListaVentas.Text = "Lista de Ventas";
            // 
            // lblTotalVentas
            // 
            this.lblTotalVentas.AutoSize = true;
            this.lblTotalVentas.Location = new System.Drawing.Point(555, 12);
            this.lblTotalVentas.Name = "lblTotalVentas";
            this.lblTotalVentas.Size = new System.Drawing.Size(65, 21);
            this.lblTotalVentas.TabIndex = 1;
            this.lblTotalVentas.Text = "Total: 0";
            // 
            // dgvVentas
            // 
            this.dgvVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVentas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new System.Drawing.Point(6, 36);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.RowHeadersWidth = 51;
            this.dgvVentas.Size = new System.Drawing.Size(824, 218);
            this.dgvVentas.TabIndex = 0;
            // 
            // gbDetalleVenta
            // 
            this.gbDetalleVenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetalleVenta.BackColor = System.Drawing.Color.PaleGreen;
            this.gbDetalleVenta.Controls.Add(this.dgvDetalleVenta);
            this.gbDetalleVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetalleVenta.Location = new System.Drawing.Point(308, 351);
            this.gbDetalleVenta.Name = "gbDetalleVenta";
            this.gbDetalleVenta.Size = new System.Drawing.Size(843, 265);
            this.gbDetalleVenta.TabIndex = 67;
            this.gbDetalleVenta.TabStop = false;
            this.gbDetalleVenta.Text = "Detalle de la Venta Seleccionada";
            // 
            // dgvDetalleVenta
            // 
            this.dgvDetalleVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalleVenta.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleVenta.Location = new System.Drawing.Point(6, 29);
            this.dgvDetalleVenta.Name = "dgvDetalleVenta";
            this.dgvDetalleVenta.RowHeadersWidth = 51;
            this.dgvDetalleVenta.Size = new System.Drawing.Size(824, 230);
            this.dgvDetalleVenta.TabIndex = 1;
            // 
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.gbDetalleVenta);
            this.Controls.Add(this.gbListaVentas);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pic_users);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ventas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_users)).EndInit();
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.gbListaVentas.ResumeLayout(false);
            this.gbListaVentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.gbDetalleVenta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pic_users;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbxMetodoPago;
        private System.Windows.Forms.ComboBox cbxCajero;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.GroupBox gbListaVentas;
        private System.Windows.Forms.Label lblTotalVentas;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.GroupBox gbDetalleVenta;
        private System.Windows.Forms.Label lblFiltrarCajero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DataGridView dgvDetalleVenta;
        private System.Windows.Forms.Button btnExportarPDF;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnVerDetalles;
    }
}