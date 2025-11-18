    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using CapaEntidad;
    using CapaNegocio;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System.IO;
    using ClosedXML.Excel;

    namespace smart_inventory
    {
        public partial class Ventas : Form
        {
            private CN_Venta negocioVenta = new CN_Venta();
            private CN_Usuario negocioUsuario = new CN_Usuario();
            private List<Venta> listaVentas = new List<Venta>();
            private Venta ventaSeleccionada = null;

            public Ventas()
            {
                InitializeComponent();
            }

            private void Ventas_Load(object sender, EventArgs e)
            {
                // Maximizar ventana
                this.WindowState = FormWindowState.Maximized;

                // Configurar DataGridViews
                ConfigurarDataGridViewVentas();
                ConfigurarDataGridViewDetalle();

                // Cargar usuarios (cajeros) en el ComboBox
                CargarCajeros();

                // Cargar métodos de pago
                CargarMetodosPago();

                // Establecer fechas por defecto (último mes)
                dtpFechaInicio.Value = DateTime.Now.AddMonths(-1);
                dtpFechaFin.Value = DateTime.Now;

                // Cargar ventas iniciales
                CargarVentas();
            }

            private void ConfigurarDataGridViewVentas()
            {
                dgvVentas.AutoGenerateColumns = false;
                dgvVentas.AllowUserToAddRows = false;
                dgvVentas.ReadOnly = true;
                dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvVentas.MultiSelect = false;

                // Limpiar columnas existentes
                dgvVentas.Columns.Clear();

                // Agregar columnas
                dgvVentas.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "IdVenta",
                    HeaderText = "ID Venta",
                    Name = "IdVenta",
                    Width = 80
                });

                dgvVentas.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Fecha",
                    Name = "Fecha",
                    Width = 150,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
                });

                dgvVentas.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Cajero",
                    Name = "Cajero",
                    Width = 180
                });

                dgvVentas.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Total",
                    Name = "Total",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C2",
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    }
                });

                dgvVentas.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Método de Pago",
                    Name = "MetodoPago",
                    Width = 130
                });

                dgvVentas.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Comentario",
                    Name = "Comentario",
                    Width = 200
                });
            }

            private void ConfigurarDataGridViewDetalle()
            {
                dgvDetalleVenta.AutoGenerateColumns = false;
                dgvDetalleVenta.AllowUserToAddRows = false;
                dgvDetalleVenta.ReadOnly = true;
                dgvDetalleVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvDetalleVenta.MultiSelect = false;

                // Limpiar columnas existentes
                dgvDetalleVenta.Columns.Clear();

                // Agregar columnas
                dgvDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Producto",
                    Name = "Producto",
                    Width = 180
                });

                dgvDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Cantidad",
                    Name = "Cantidad",
                    Width = 80,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                });

                dgvDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Precio Unit.",
                    Name = "PrecioUnitario",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C2",
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    }
                });

                dgvDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Subtotal",
                    Name = "Subtotal",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C2",
                        Alignment = DataGridViewContentAlignment.MiddleRight
                    }
                });
            }

            private void CargarCajeros()
            {
                try
                {
                    CN_Usuario negocioUsuario = new CN_Usuario();
                    List<Usuario> listaUsuarios = negocioUsuario.Listar();

                    // Agregar opción "Todos"
                    cbxCajero.Items.Clear();
                    cbxCajero.Items.Add(new { IdUsuario = 0, NombreCompleto = "-- Todos los cajeros --" });

                    foreach (Usuario usuario in listaUsuarios.Where(u => u.Activo))
                    {
                        cbxCajero.Items.Add(new
                        {
                            IdUsuario = usuario.IdUsuario,
                            NombreCompleto = $"{usuario.Nombre} {usuario.Apellido}"
                        });
                    }

                    cbxCajero.DisplayMember = "NombreCompleto";
                    cbxCajero.ValueMember = "IdUsuario";
                    cbxCajero.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar cajeros: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void CargarMetodosPago()
            {
                cbxMetodoPago.Items.Clear();
                cbxMetodoPago.Items.Add("-- Todos --");
                cbxMetodoPago.Items.Add("Efectivo");
                cbxMetodoPago.Items.Add("Tarjeta de Crédito");
                cbxMetodoPago.Items.Add("Tarjeta de Débito");
                cbxMetodoPago.Items.Add("Transferencia");
                cbxMetodoPago.SelectedIndex = 0;
            }

            private void CargarVentas()
            {
                try
                {
                    listaVentas = negocioVenta.Listar();
                    MostrarVentas(listaVentas);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar ventas: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void MostrarVentas(List<Venta> ventas)
            {
                dgvVentas.Rows.Clear();
                decimal totalGeneral = 0;

                foreach (Venta venta in ventas)
                {
                    int index = dgvVentas.Rows.Add();
                    dgvVentas.Rows[index].Cells["IdVenta"].Value = venta.IdVenta;
                    dgvVentas.Rows[index].Cells["Fecha"].Value = venta.FechaVenta;
                    dgvVentas.Rows[index].Cells["Cajero"].Value = venta.Usuario?.Nombre ?? "N/A";
                    dgvVentas.Rows[index].Cells["Total"].Value = venta.Total;
                    dgvVentas.Rows[index].Cells["MetodoPago"].Value = venta.MetodoPago;
                    dgvVentas.Rows[index].Cells["Comentario"].Value = venta.Comentario ?? "";

                    totalGeneral += venta.Total;
                }

                lblTotalVentas.Text = $"Total: {ventas.Count} ventas | Monto Total: {totalGeneral:C2}";
            }

            private void btnBuscar_Click(object sender, EventArgs e)
            {
                try
                {
                    DateTime fechaInicio = dtpFechaInicio.Value.Date;
                    DateTime fechaFin = dtpFechaFin.Value.Date;

                    // Validar que la fecha inicial no sea mayor a la final
                    if (fechaInicio > fechaFin)
                    {
                        MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha final.",
                            "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Obtener ventas por rango de fechas
                    List<Venta> ventasFiltradas = negocioVenta.ListarPorFechas(fechaInicio, fechaFin);

                    // Filtrar por cajero si se seleccionó uno específico
                    if (cbxCajero.SelectedIndex > 0)
                    {
                        dynamic cajeroSeleccionado = cbxCajero.SelectedItem;
                        int idCajero = cajeroSeleccionado.IdUsuario;
                        ventasFiltradas = ventasFiltradas.Where(v => v.IdUsuario == idCajero).ToList();
                    }

                    // Filtrar por método de pago si se seleccionó uno específico
                    if (cbxMetodoPago.SelectedIndex > 0)
                    {
                        string metodoPago = cbxMetodoPago.SelectedItem.ToString();
                        ventasFiltradas = ventasFiltradas.Where(v => v.MetodoPago == metodoPago).ToList();
                    }

                    listaVentas = ventasFiltradas;
                    MostrarVentas(ventasFiltradas);

                    if (ventasFiltradas.Count == 0)
                    {
                        MessageBox.Show("No se encontraron ventas con los filtros aplicados.",
                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar ventas: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void btnLimpiarFiltros_Click(object sender, EventArgs e)
            {
                // Restablecer filtros
                dtpFechaInicio.Value = DateTime.Now.AddMonths(-1);
                dtpFechaFin.Value = DateTime.Now;
                cbxCajero.SelectedIndex = 0;
                cbxMetodoPago.SelectedIndex = 0;

                // Recargar todas las ventas
                CargarVentas();

                // Limpiar detalle
                dgvDetalleVenta.Rows.Clear();
                ventaSeleccionada = null;
            }

            private void btnVerDetalles_Click(object sender, EventArgs e)
            {
                if (dgvVentas.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar una venta para ver sus detalles.",
                        "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int rowIndex = dgvVentas.CurrentRow.Index;
                ventaSeleccionada = listaVentas[rowIndex];

                CargarDetalleVenta(ventaSeleccionada.IdVenta);
            }

            private void CargarDetalleVenta(int idVenta)
            {
                try
                {
                    List<DetalleVenta> detalles = negocioVenta.ObtenerDetalleVenta(idVenta);
                    dgvDetalleVenta.Rows.Clear();

                    foreach (DetalleVenta detalle in detalles)
                    {
                        int index = dgvDetalleVenta.Rows.Add();
                        dgvDetalleVenta.Rows[index].Cells["Producto"].Value = detalle.Producto?.Nombre ?? "N/A";
                        dgvDetalleVenta.Rows[index].Cells["Cantidad"].Value = detalle.Cantidad;
                        dgvDetalleVenta.Rows[index].Cells["PrecioUnitario"].Value = detalle.PrecioUnitario;
                        dgvDetalleVenta.Rows[index].Cells["Subtotal"].Value = detalle.Subtotal;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar detalle de venta: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                    btnVerDetalles_Click(sender, e);
                }
            }

            private void btnExportarExcel_Click(object sender, EventArgs e)
            {
                if (listaVentas.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                try
                {
                    SaveFileDialog saveDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx",
                        Title = "Exportar Ventas a Excel",
                        FileName = $"Ventas_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                    };

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Ventas");

                            // Encabezados
                            worksheet.Cell(1, 1).Value = "ID Venta";
                            worksheet.Cell(1, 2).Value = "Fecha";
                            worksheet.Cell(1, 3).Value = "Cajero";
                            worksheet.Cell(1, 4).Value = "Total";
                            worksheet.Cell(1, 5).Value = "Método de Pago";
                            worksheet.Cell(1, 6).Value = "Comentario";

                            // Formato de encabezados
                            var headerRange = worksheet.Range(1, 1, 1, 6);
                            headerRange.Style.Font.Bold = true;
                            headerRange.Style.Fill.BackgroundColor = XLColor.LightBlue;
                            headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            // Datos
                            int row = 2;
                            foreach (Venta venta in listaVentas)
                            {
                                worksheet.Cell(row, 1).Value = venta.IdVenta;
                                worksheet.Cell(row, 2).Value = venta.FechaVenta.ToString("dd/MM/yyyy HH:mm");
                                worksheet.Cell(row, 3).Value = venta.Usuario?.Nombre ?? "N/A";
                                worksheet.Cell(row, 4).Value = venta.Total;
                                worksheet.Cell(row, 4).Style.NumberFormat.Format = "$#,##0.00";
                                worksheet.Cell(row, 5).Value = venta.MetodoPago;
                                worksheet.Cell(row, 6).Value = venta.Comentario ?? "";
                                row++;
                            }

                            // Ajustar columnas
                            worksheet.Columns().AdjustToContents();

                            workbook.SaveAs(saveDialog.FileName);
                        }

                        MessageBox.Show("Exportación exitosa.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar a Excel: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void btnExportarPDF_Click(object sender, EventArgs e)
            {
                if (listaVentas.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                try
                {
                    SaveFileDialog saveDialog = new SaveFileDialog
                    {
                        Filter = "PDF Files|*.pdf",
                        Title = "Exportar Ventas a PDF",
                        FileName = $"Ventas_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                    };

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        Document document = new Document(PageSize.A4.Rotate(), 20, 20, 30, 30);
                        PdfWriter.GetInstance(document, new FileStream(saveDialog.FileName, FileMode.Create));

                        document.Open();

                        // Título
                        iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                        Paragraph title = new Paragraph("Reporte de Ventas", titleFont)
                        {
                            Alignment = Element.ALIGN_CENTER,
                            SpacingAfter = 20
                        };
                        document.Add(title);

                        // Información del reporte
                        iTextSharp.text.Font infoFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                        document.Add(new Paragraph($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}", infoFont));
                        document.Add(new Paragraph($"Total de ventas: {listaVentas.Count}", infoFont));
                        document.Add(new Paragraph($"Monto total: {listaVentas.Sum(v => v.Total):C2}", infoFont));
                        document.Add(new Paragraph(" "));

                        // Tabla
                        PdfPTable table = new PdfPTable(6)
                        {
                            WidthPercentage = 100
                        };
                        table.SetWidths(new float[] { 10f, 20f, 25f, 15f, 20f, 30f });

                        // Encabezados
                        iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                        table.AddCell(new PdfPCell(new Phrase("ID", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        table.AddCell(new PdfPCell(new Phrase("Fecha", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        table.AddCell(new PdfPCell(new Phrase("Cajero", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        table.AddCell(new PdfPCell(new Phrase("Total", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        table.AddCell(new PdfPCell(new Phrase("Método Pago", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        table.AddCell(new PdfPCell(new Phrase("Comentario", headerFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                        // Datos
                        iTextSharp.text.Font dataFont = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                        foreach (Venta venta in listaVentas)
                        {
                            table.AddCell(new Phrase(venta.IdVenta.ToString(), dataFont));
                            table.AddCell(new Phrase(venta.FechaVenta.ToString("dd/MM/yyyy HH:mm"), dataFont));
                            table.AddCell(new Phrase(venta.Usuario?.Nombre ?? "N/A", dataFont));
                            table.AddCell(new Phrase(venta.Total.ToString("C2"), dataFont));
                            table.AddCell(new Phrase(venta.MetodoPago, dataFont));
                            table.AddCell(new Phrase(venta.Comentario ?? "", dataFont));
                        }

                        document.Add(table);
                        document.Close();

                        MessageBox.Show("Exportación exitosa.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar a PDF: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }