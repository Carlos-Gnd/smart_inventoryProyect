namespace smart_inventory
{
    partial class Informes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Informes));
            this.btnExportarExcelVentas = new System.Windows.Forms.Button();
            this.btnExportarPDFventas = new System.Windows.Forms.Button();
            this.gbTablaVentas = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTablaVentas = new System.Windows.Forms.DataGridView();
            this.btnExportarExcelProd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gbTablaProductos = new System.Windows.Forms.GroupBox();
            this.lblTotalUsuarios = new System.Windows.Forms.Label();
            this.dgvTablaProductos = new System.Windows.Forms.DataGridView();
            this.btnExportarPDFprod = new System.Windows.Forms.Button();
            this.pic_users = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbTablaVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaVentas)).BeginInit();
            this.gbTablaProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_users)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportarExcelVentas
            // 
            this.btnExportarExcelVentas.BackColor = System.Drawing.Color.ForestGreen;
            this.btnExportarExcelVentas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcelVentas.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExportarExcelVentas.Location = new System.Drawing.Point(200, 399);
            this.btnExportarExcelVentas.Name = "btnExportarExcelVentas";
            this.btnExportarExcelVentas.Size = new System.Drawing.Size(166, 40);
            this.btnExportarExcelVentas.TabIndex = 81;
            this.btnExportarExcelVentas.Text = "📊 Exportar Excel";
            this.btnExportarExcelVentas.UseVisualStyleBackColor = false;
            this.btnExportarExcelVentas.Click += new System.EventHandler(this.btnExportarExcelVentas_Click);
            // 
            // btnExportarPDFventas
            // 
            this.btnExportarPDFventas.BackColor = System.Drawing.Color.Red;
            this.btnExportarPDFventas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPDFventas.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExportarPDFventas.Location = new System.Drawing.Point(19, 399);
            this.btnExportarPDFventas.Name = "btnExportarPDFventas";
            this.btnExportarPDFventas.Size = new System.Drawing.Size(166, 40);
            this.btnExportarPDFventas.TabIndex = 82;
            this.btnExportarPDFventas.Text = "📥 Exportar PDF";
            this.btnExportarPDFventas.UseVisualStyleBackColor = false;
            this.btnExportarPDFventas.Click += new System.EventHandler(this.btnExportarPDFventas_Click);
            // 
            // gbTablaVentas
            // 
            this.gbTablaVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTablaVentas.BackColor = System.Drawing.Color.CornflowerBlue;
            this.gbTablaVentas.Controls.Add(this.label1);
            this.gbTablaVentas.Controls.Add(this.dgvTablaVentas);
            this.gbTablaVentas.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbTablaVentas.ForeColor = System.Drawing.Color.White;
            this.gbTablaVentas.Location = new System.Drawing.Point(19, 445);
            this.gbTablaVentas.Name = "gbTablaVentas";
            this.gbTablaVentas.Size = new System.Drawing.Size(940, 259);
            this.gbTablaVentas.TabIndex = 80;
            this.gbTablaVentas.TabStop = false;
            this.gbTablaVentas.Text = "Tabla de Ventas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(654, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total: 0";
            // 
            // dgvTablaVentas
            // 
            this.dgvTablaVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTablaVentas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTablaVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablaVentas.Location = new System.Drawing.Point(6, 36);
            this.dgvTablaVentas.Name = "dgvTablaVentas";
            this.dgvTablaVentas.RowHeadersWidth = 51;
            this.dgvTablaVentas.Size = new System.Drawing.Size(919, 212);
            this.dgvTablaVentas.TabIndex = 0;
            // 
            // btnExportarExcelProd
            // 
            this.btnExportarExcelProd.BackColor = System.Drawing.Color.ForestGreen;
            this.btnExportarExcelProd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcelProd.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExportarExcelProd.Location = new System.Drawing.Point(200, 79);
            this.btnExportarExcelProd.Name = "btnExportarExcelProd";
            this.btnExportarExcelProd.Size = new System.Drawing.Size(166, 40);
            this.btnExportarExcelProd.TabIndex = 77;
            this.btnExportarExcelProd.Text = "📊 Exportar Excel";
            this.btnExportarExcelProd.UseVisualStyleBackColor = false;
            this.btnExportarExcelProd.Click += new System.EventHandler(this.btnExportarExcelProd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(89, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 36);
            this.label2.TabIndex = 74;
            this.label2.Text = "Informes";
            // 
            // gbTablaProductos
            // 
            this.gbTablaProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTablaProductos.BackColor = System.Drawing.Color.CornflowerBlue;
            this.gbTablaProductos.Controls.Add(this.lblTotalUsuarios);
            this.gbTablaProductos.Controls.Add(this.dgvTablaProductos);
            this.gbTablaProductos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbTablaProductos.ForeColor = System.Drawing.Color.White;
            this.gbTablaProductos.Location = new System.Drawing.Point(19, 125);
            this.gbTablaProductos.Name = "gbTablaProductos";
            this.gbTablaProductos.Size = new System.Drawing.Size(940, 259);
            this.gbTablaProductos.TabIndex = 79;
            this.gbTablaProductos.TabStop = false;
            this.gbTablaProductos.Text = "Tabla de Productos";
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
            // dgvTablaProductos
            // 
            this.dgvTablaProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTablaProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvTablaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablaProductos.GridColor = System.Drawing.Color.Black;
            this.dgvTablaProductos.Location = new System.Drawing.Point(6, 36);
            this.dgvTablaProductos.Name = "dgvTablaProductos";
            this.dgvTablaProductos.RowHeadersWidth = 51;
            this.dgvTablaProductos.Size = new System.Drawing.Size(919, 212);
            this.dgvTablaProductos.TabIndex = 0;
            // 
            // btnExportarPDFprod
            // 
            this.btnExportarPDFprod.BackColor = System.Drawing.Color.Red;
            this.btnExportarPDFprod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPDFprod.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExportarPDFprod.Location = new System.Drawing.Point(19, 79);
            this.btnExportarPDFprod.Name = "btnExportarPDFprod";
            this.btnExportarPDFprod.Size = new System.Drawing.Size(166, 40);
            this.btnExportarPDFprod.TabIndex = 78;
            this.btnExportarPDFprod.Text = "📥 Exportar PDF";
            this.btnExportarPDFprod.UseVisualStyleBackColor = false;
            this.btnExportarPDFprod.Click += new System.EventHandler(this.btnExportarPDFprod_Click);
            // 
            // pic_users
            // 
            this.pic_users.BackColor = System.Drawing.SystemColors.Control;
            this.pic_users.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic_users.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_users.Image = ((System.Drawing.Image)(resources.GetObject("pic_users.Image")));
            this.pic_users.Location = new System.Drawing.Point(34, 5);
            this.pic_users.Name = "pic_users";
            this.pic_users.Size = new System.Drawing.Size(50, 54);
            this.pic_users.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_users.TabIndex = 76;
            this.pic_users.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.Location = new System.Drawing.Point(9, 71);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 3);
            this.panel1.TabIndex = 75;
            // 
            // Informes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.btnExportarExcelVentas);
            this.Controls.Add(this.btnExportarPDFventas);
            this.Controls.Add(this.gbTablaVentas);
            this.Controls.Add(this.btnExportarExcelProd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbTablaProductos);
            this.Controls.Add(this.btnExportarPDFprod);
            this.Controls.Add(this.pic_users);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Informes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Informes_Load);
            this.gbTablaVentas.ResumeLayout(false);
            this.gbTablaVentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaVentas)).EndInit();
            this.gbTablaProductos.ResumeLayout(false);
            this.gbTablaProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablaProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_users)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExportarExcelVentas;
        private System.Windows.Forms.Button btnExportarPDFventas;
        private System.Windows.Forms.GroupBox gbTablaVentas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTablaVentas;
        private System.Windows.Forms.Button btnExportarExcelProd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbTablaProductos;
        private System.Windows.Forms.Label lblTotalUsuarios;
        private System.Windows.Forms.DataGridView dgvTablaProductos;
        private System.Windows.Forms.Button btnExportarPDFprod;
        private System.Windows.Forms.PictureBox pic_users;
        private System.Windows.Forms.Panel panel1;
    }
}