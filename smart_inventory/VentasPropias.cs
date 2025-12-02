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
    public partial class VentasPropias : Form
    {
        private CN_Venta negocioVenta = new CN_Venta();
        private Usuario usuarioActual;
        private List<Venta> listaVentasPropias = new List<Venta>();
        private Venta ventaSeleccionada = null;

        // Constructor que recibe el usuario logueado
        public VentasPropias(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void VentasPropias_Load(object sender, EventArgs e)
        {
            // Maximizar ventana
            this.WindowState = FormWindowState.Maximized;

            // Configurar título según el rol
            if (usuarioActual.IdRol == 1) // Administrador
            {
                this.Text = "Historial de Todas las Ventas - Administrador";
            }
            else // Cajero
            {
                this.Text = $"Mis Ventas - {usuarioActual.Nombre} {usuarioActual.Apellido}";
            }

            // Configurar DataGridView
            ConfigurarDataGridView();

            // Cargar opciones de filtro
            CargarOpcionesFiltro();

            // Cargar las ventas del usuario
            CargarVentasPropias();

            // Configurar botón de regreso
            ConfigurarBotonRegreso();
        }

        private void ConfigurarBotonRegreso()
        {
            if (this.Controls.Find("btnRegresar", true).Length > 0)
            {
                Button btnRegresar = (Button)this.Controls.Find("btnRegresar", true)[0];
                btnRegresar.Click += btnRegresar_Click;
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvTablaVentasPropias.AutoGenerateColumns = false;
            dgvTablaVentasPropias.AllowUserToAddRows = false;
            dgvTablaVentasPropias.ReadOnly = true;
            dgvTablaVentasPropias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTablaVentasPropias.MultiSelect = false;

            // Limpiar columnas existentes
            dgvTablaVentasPropias.Columns.Clear();

            // Agregar columnas
            dgvTablaVentasPropias.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "IdVenta",
                HeaderText = "ID Venta",
                Name = "IdVenta",
                Width = 80
            });

            dgvTablaVentasPropias.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Fecha y Hora",
                Name = "FechaVenta",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            dgvTablaVentasPropias.Columns.Add(new DataGridViewTextBoxColumn()
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

            dgvTablaVentasPropias.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Método de Pago",
                Name = "MetodoPago",
                Width = 150
            });

            dgvTablaVentasPropias.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Comentario",
                Name = "Comentario",
                Width = 250
            });

            dgvTablaVentasPropias.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Estado",
                Name = "Estado",
                Width = 100
            });

            dgvTablaVentasPropias.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "# Productos",
                Name = "CantidadProductos",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
        }

        private void CargarOpcionesFiltro()
        {
            cbFiltro.Items.Clear();
            cbFiltro.Items.Add("Todos");
            cbFiltro.Items.Add("Efectivo");
            cbFiltro.Items.Add("Tarjeta de Crédito");
            cbFiltro.Items.Add("Tarjeta de Débito");
            cbFiltro.Items.Add("Transferencia");
            cbFiltro.Items.Add("Hoy");
            cbFiltro.Items.Add("Esta Semana");
            cbFiltro.Items.Add("Este Mes");
            cbFiltro.SelectedIndex = 0;
        }

        private void CargarVentasPropias()
        {
            try
            {
                // Si es administrador (IdRol == 1), mostrar TODAS las ventas
                // Si es cajero (IdRol == 2), mostrar solo sus ventas
                if (usuarioActual.IdRol == 1) // Administrador
                {
                    // Obtener TODAS las ventas
                    listaVentasPropias = negocioVenta.Listar();
                }
                else // Cajero
                {
                    // Obtener SOLO las ventas del usuario actual
                    listaVentasPropias = negocioVenta.ListarPorUsuario(usuarioActual.IdUsuario);
                }

                // Ordenar por fecha descendente (más recientes primero)
                listaVentasPropias = listaVentasPropias.OrderByDescending(v => v.FechaVenta).ToList();

                // Mostrar las ventas
                MostrarVentas(listaVentasPropias);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarVentas(List<Venta> ventas)
        {
            dgvTablaVentasPropias.Rows.Clear();
            decimal totalVentas = 0;
            int totalProductosVendidos = 0;

            foreach (Venta venta in ventas)
            {
                int index = dgvTablaVentasPropias.Rows.Add();
                dgvTablaVentasPropias.Rows[index].Cells["IdVenta"].Value = venta.IdVenta;
                dgvTablaVentasPropias.Rows[index].Cells["FechaVenta"].Value = venta.FechaVenta;
                dgvTablaVentasPropias.Rows[index].Cells["Total"].Value = venta.Total;
                dgvTablaVentasPropias.Rows[index].Cells["MetodoPago"].Value = venta.MetodoPago;
                dgvTablaVentasPropias.Rows[index].Cells["Comentario"].Value = venta.Comentario ?? "";
                dgvTablaVentasPropias.Rows[index].Cells["Estado"].Value = venta.Estado ? "✓ Activo" : "✗ Anulado";

                // Obtener cantidad de productos
                int cantidadProductos = venta.CantidadTotalProductos;
                dgvTablaVentasPropias.Rows[index].Cells["CantidadProductos"].Value = cantidadProductos;

                // Cambiar color si la venta está anulada
                if (!venta.Estado)
                {
                    dgvTablaVentasPropias.Rows[index].DefaultCellStyle.BackColor = Color.LightGray;
                    dgvTablaVentasPropias.Rows[index].DefaultCellStyle.ForeColor = Color.DarkGray;
                }
                else
                {
                    totalVentas += venta.Total;
                    totalProductosVendidos += cantidadProductos;
                }
            }

            // Actualizar el label con estadísticas
            lblTotalUsuarios.Text = $"Total: {ventas.Count(v => v.Estado)} ventas activas | " +
                                   $"Productos vendidos: {totalProductosVendidos} | " +
                                   $"Monto Total: {totalVentas:C2}";
        }

        private void txtBuscarVenta_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            try
            {
                string textoBusqueda = txtBuscarVenta.Text.ToLower().Trim();
                string filtroSeleccionado = cbFiltro.SelectedItem?.ToString() ?? "Todos";

                var ventasFiltradas = listaVentasPropias.AsEnumerable();

                // Filtro por texto de búsqueda
                if (!string.IsNullOrWhiteSpace(textoBusqueda))
                {
                    ventasFiltradas = ventasFiltradas.Where(v =>
                        v.IdVenta.ToString().Contains(textoBusqueda) ||
                        (v.Comentario != null && v.Comentario.ToLower().Contains(textoBusqueda)) ||
                        v.Total.ToString("C2").ToLower().Contains(textoBusqueda) ||
                        v.MetodoPago.ToLower().Contains(textoBusqueda)
                    );
                }

                // Filtro por método de pago
                if (filtroSeleccionado != "Todos" &&
                    !filtroSeleccionado.Contains("Hoy") &&
                    !filtroSeleccionado.Contains("Semana") &&
                    !filtroSeleccionado.Contains("Mes"))
                {
                    ventasFiltradas = ventasFiltradas.Where(v => v.MetodoPago == filtroSeleccionado);
                }

                // Filtro por fecha
                DateTime hoy = DateTime.Now.Date;
                switch (filtroSeleccionado)
                {
                    case "Hoy":
                        ventasFiltradas = ventasFiltradas.Where(v => v.FechaVenta.Date == hoy);
                        break;
                    case "Esta Semana":
                        DateTime inicioSemana = hoy.AddDays(-(int)hoy.DayOfWeek);
                        ventasFiltradas = ventasFiltradas.Where(v => v.FechaVenta.Date >= inicioSemana);
                        break;
                    case "Este Mes":
                        ventasFiltradas = ventasFiltradas.Where(v =>
                            v.FechaVenta.Year == hoy.Year &&
                            v.FechaVenta.Month == hoy.Month);
                        break;
                }

                MostrarVentas(ventasFiltradas.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTablaVentasPropias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTablaVentasPropias.CurrentRow != null && dgvTablaVentasPropias.CurrentRow.Index >= 0)
            {
                int idVenta = Convert.ToInt32(dgvTablaVentasPropias.CurrentRow.Cells["IdVenta"].Value);
                ventaSeleccionada = listaVentasPropias.FirstOrDefault(v => v.IdVenta == idVenta);
            }
        }

        private void dgvTablaVentasPropias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnVerDetalle_Click(sender, e);
            }
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (ventaSeleccionada == null)
            {
                MessageBox.Show("Debe seleccionar una venta para ver su detalle.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                List<DetalleVenta> detalles = negocioVenta.ObtenerDetalleVenta(ventaSeleccionada.IdVenta);

                if (detalles.Count > 0)
                {
                    StringBuilder mensaje = new StringBuilder();
                    mensaje.AppendLine("╔════════════════════════════════════════════════╗");
                    mensaje.AppendLine($"║     DETALLE DE VENTA #{ventaSeleccionada.IdVenta.ToString().PadLeft(10)}        ║");
                    mensaje.AppendLine("╚════════════════════════════════════════════════╝");
                    mensaje.AppendLine();
                    mensaje.AppendLine($"Fecha: {ventaSeleccionada.FechaVenta:dd/MM/yyyy HH:mm}");
                    mensaje.AppendLine($"Cajero: {usuarioActual.Nombre} {usuarioActual.Apellido}");
                    mensaje.AppendLine($"Método de Pago: {ventaSeleccionada.MetodoPago}");
                    if (!string.IsNullOrWhiteSpace(ventaSeleccionada.Comentario))
                        mensaje.AppendLine($"Comentario: {ventaSeleccionada.Comentario}");
                    mensaje.AppendLine();
                    mensaje.AppendLine(new string('─', 60));
                    mensaje.AppendLine();

                    decimal total = 0;
                    foreach (DetalleVenta detalle in detalles)
                    {
                        mensaje.AppendLine($"• {detalle.Producto?.Nombre ?? "N/A"}");
                        mensaje.AppendLine($"  Cantidad: {detalle.Cantidad} x {detalle.PrecioUnitario:C2} = {detalle.Subtotal:C2}");
                        mensaje.AppendLine();
                        total += detalle.Subtotal;
                    }

                    mensaje.AppendLine(new string('─', 60));
                    mensaje.AppendLine($"\n          TOTAL: {total:C2}");
                    mensaje.AppendLine(new string('═', 60));

                    MessageBox.Show(mensaje.ToString(), "Detalle de Venta",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalle: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (listaVentasPropias.Count == 0)
            {
                MessageBox.Show("No hay ventas para exportar.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Exportar Mis Ventas a Excel",
                    FileName = $"MisVentas_{usuarioActual.Nombre}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Mis Ventas");

                        // Información del cajero
                        worksheet.Cell(1, 1).Value = "Reporte de Ventas Propias";
                        worksheet.Cell(1, 1).Style.Font.Bold = true;
                        worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                        worksheet.Range(1, 1, 1, 7).Merge();

                        worksheet.Cell(2, 1).Value = $"Cajero: {usuarioActual.Nombre} {usuarioActual.Apellido}";
                        worksheet.Cell(3, 1).Value = $"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}";

                        // Encabezados
                        int headerRow = 5;
                        worksheet.Cell(headerRow, 1).Value = "ID Venta";
                        worksheet.Cell(headerRow, 2).Value = "Fecha";
                        worksheet.Cell(headerRow, 3).Value = "Total";
                        worksheet.Cell(headerRow, 4).Value = "Método de Pago";
                        worksheet.Cell(headerRow, 5).Value = "Productos";
                        worksheet.Cell(headerRow, 6).Value = "Comentario";
                        worksheet.Cell(headerRow, 7).Value = "Estado";

                        var headerRange = worksheet.Range(headerRow, 1, headerRow, 7);
                        headerRange.Style.Font.Bold = true;
                        headerRange.Style.Fill.BackgroundColor = XLColor.LightBlue;
                        headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        // Datos
                        int row = headerRow + 1;
                        decimal totalGeneral = 0;
                        foreach (Venta venta in listaVentasPropias.Where(v => v.Estado))
                        {
                            worksheet.Cell(row, 1).Value = venta.IdVenta;
                            worksheet.Cell(row, 2).Value = venta.FechaVenta.ToString("dd/MM/yyyy HH:mm");
                            worksheet.Cell(row, 3).Value = venta.Total;
                            worksheet.Cell(row, 3).Style.NumberFormat.Format = "$#,##0.00";
                            worksheet.Cell(row, 4).Value = venta.MetodoPago;

                            List<DetalleVenta> detalles = negocioVenta.ObtenerDetalleVenta(venta.IdVenta);
                            worksheet.Cell(row, 5).Value = detalles.Sum(d => d.Cantidad);
                            worksheet.Cell(row, 6).Value = venta.Comentario ?? "";
                            worksheet.Cell(row, 7).Value = "Activo";

                            totalGeneral += venta.Total;
                            row++;
                        }

                        // Total
                        worksheet.Cell(row + 1, 2).Value = "TOTAL:";
                        worksheet.Cell(row + 1, 2).Style.Font.Bold = true;
                        worksheet.Cell(row + 1, 3).Value = totalGeneral;
                        worksheet.Cell(row + 1, 3).Style.NumberFormat.Format = "$#,##0.00";
                        worksheet.Cell(row + 1, 3).Style.Font.Bold = true;

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
            if (listaVentasPropias.Count == 0)
            {
                MessageBox.Show("No hay ventas para exportar.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    Title = "Exportar Mis Ventas a PDF",
                    FileName = $"MisVentas_{usuarioActual.Nombre}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter.GetInstance(document, new FileStream(saveDialog.FileName, FileMode.Create));

                    document.Open();

                    // Título
                    iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                    Paragraph title = new Paragraph("Reporte de Ventas Propias", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 15
                    };
                    document.Add(title);

                    // Información del cajero
                    iTextSharp.text.Font infoFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                    document.Add(new Paragraph($"Cajero: {usuarioActual.Nombre} {usuarioActual.Apellido}", infoFont));
                    document.Add(new Paragraph($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}", infoFont));
                    document.Add(new Paragraph($"Total de ventas: {listaVentasPropias.Count(v => v.Estado)}", infoFont));
                    document.Add(new Paragraph($"Monto total: {listaVentasPropias.Where(v => v.Estado).Sum(v => v.Total):C2}", infoFont));
                    document.Add(new Paragraph(" "));

                    // Tabla
                    PdfPTable table = new PdfPTable(6) { WidthPercentage = 100 };
                    table.SetWidths(new float[] { 10f, 20f, 15f, 20f, 10f, 25f });

                    // Encabezados
                    iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);
                    string[] headers = { "ID", "Fecha", "Total", "Método Pago", "Prods.", "Comentario" };
                    foreach (string header in headers)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(header, headerFont))
                        {
                            BackgroundColor = BaseColor.LIGHT_GRAY,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            Padding = 5
                        };
                        table.AddCell(cell);
                    }

                    // Datos
                    iTextSharp.text.Font dataFont = FontFactory.GetFont(FontFactory.HELVETICA, 8);
                    foreach (Venta venta in listaVentasPropias.Where(v => v.Estado))
                    {
                        table.AddCell(new Phrase(venta.IdVenta.ToString(), dataFont));
                        table.AddCell(new Phrase(venta.FechaVenta.ToString("dd/MM/yyyy HH:mm"), dataFont));
                        table.AddCell(new Phrase(venta.Total.ToString("C2"), dataFont));
                        table.AddCell(new Phrase(venta.MetodoPago, dataFont));

                        List<DetalleVenta> detalles = negocioVenta.ObtenerDetalleVenta(venta.IdVenta);
                        table.AddCell(new Phrase(detalles.Sum(d => d.Cantidad).ToString(), dataFont));
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

        private void btnImprimirTicket_Click(object sender, EventArgs e)
        {
            if (ventaSeleccionada == null)
            {
                MessageBox.Show("Debe seleccionar una venta para imprimir su ticket.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                List<DetalleVenta> detalles = negocioVenta.ObtenerDetalleVenta(ventaSeleccionada.IdVenta);

                if (detalles.Count > 0)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog
                    {
                        Filter = "PDF Files|*.pdf",
                        Title = "Guardar Ticket de Venta",
                        FileName = $"Ticket_Venta_{ventaSeleccionada.IdVenta}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                    };

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Crear documento tamaño ticket (80mm x altura variable)
                        Document document = new Document(new iTextSharp.text.Rectangle(226.77f, 600f), 10, 10, 10, 10);
                        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(saveDialog.FileName, FileMode.Create));

                        document.Open();

                        // Fuentes
                        iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                        iTextSharp.text.Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 8);
                        iTextSharp.text.Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8);

                        // Encabezado
                        Paragraph header = new Paragraph("SMART INVENTORY", titleFont)
                        {
                            Alignment = Element.ALIGN_CENTER
                        };
                        document.Add(header);
                        document.Add(new Paragraph("Sistema de Gestión", normalFont) { Alignment = Element.ALIGN_CENTER });
                        document.Add(new Paragraph(new string('-', 40), normalFont) { Alignment = Element.ALIGN_CENTER });

                        // Información de venta
                        document.Add(new Paragraph($"Ticket #: {ventaSeleccionada.IdVenta}", boldFont));
                        document.Add(new Paragraph($"Fecha: {ventaSeleccionada.FechaVenta:dd/MM/yyyy HH:mm}", normalFont));
                        document.Add(new Paragraph($"Cajero: {usuarioActual.Nombre} {usuarioActual.Apellido}", normalFont));
                        document.Add(new Paragraph($"Método: {ventaSeleccionada.MetodoPago}", normalFont));
                        document.Add(new Paragraph(new string('-', 40), normalFont));

                        // Productos
                        foreach (DetalleVenta detalle in detalles)
                        {
                            document.Add(new Paragraph(detalle.Producto?.Nombre ?? "N/A", boldFont));
                            document.Add(new Paragraph(
                                $"  {detalle.Cantidad} x {detalle.PrecioUnitario:C2} = {detalle.Subtotal:C2}",
                                normalFont));
                        }

                        document.Add(new Paragraph(new string('-', 40), normalFont));

                        // Total
                        Paragraph total = new Paragraph($"TOTAL: {ventaSeleccionada.Total:C2}", titleFont)
                        {
                            Alignment = Element.ALIGN_RIGHT
                        };
                        document.Add(total);

                        document.Add(new Paragraph(new string('-', 40), normalFont));
                        document.Add(new Paragraph("¡Gracias por su compra!", normalFont) { Alignment = Element.ALIGN_CENTER });

                        document.Close();

                        MessageBox.Show("Ticket generado exitosamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar ticket: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefrescarVentas()
        {
            CargarVentasPropias();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}