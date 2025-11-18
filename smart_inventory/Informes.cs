using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CapaNegocio;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace smart_inventory
{
    public partial class Informes : Form
    {
        private CN_Reporte negocioReporte = new CN_Reporte();
        private CN_Producto negocioProducto = new CN_Producto();

        public Informes()
        {
            InitializeComponent();
        }

        private void Informes_Load(object sender, EventArgs e)
        {
            // Maximizar ventana
            this.WindowState = FormWindowState.Maximized;

            // Configurar DataGridViews
            ConfigurarDataGridViews();

            // Cargar datos
            CargarReporteProductos();
            CargarReporteVentas();
        }

        private void ConfigurarDataGridViews()
        {
            // Configurar dgvTablaProductos
            dgvTablaProductos.AutoGenerateColumns = true;
            dgvTablaProductos.AllowUserToAddRows = false;
            dgvTablaProductos.ReadOnly = true;
            dgvTablaProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTablaProductos.MultiSelect = false;
            dgvTablaProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTablaProductos.DefaultCellStyle.ForeColor = Color.Black;

            // Configurar dgvTablaVentas
            dgvTablaVentas.AutoGenerateColumns = true;
            dgvTablaVentas.AllowUserToAddRows = false;
            dgvTablaVentas.ReadOnly = true;
            dgvTablaVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTablaVentas.MultiSelect = false;
            dgvTablaVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTablaVentas.DefaultCellStyle.ForeColor = Color.Black;
        }

        // CARGAR DATOS DE PRODUCTOS
        private void CargarReporteProductos()
        {
            try
            {
                DataTable dt = negocioReporte.ObtenerReporteProductos();

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvTablaProductos.DataSource = dt;
                    lblTotalUsuarios.Text = $"Total: {dt.Rows.Count} productos";
                    FormatearColumnasProductos();
                }
                else
                {
                    dgvTablaProductos.DataSource = null;
                    lblTotalUsuarios.Text = "Total: 0 productos";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearColumnasProductos()
        {
            try
            {
                if (dgvTablaProductos.Columns.Contains("Precio"))
                {
                    dgvTablaProductos.Columns["Precio"].DefaultCellStyle.Format = "C2";
                    dgvTablaProductos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dgvTablaProductos.Columns.Contains("Stock"))
                {
                    dgvTablaProductos.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvTablaProductos.Columns.Contains("StockMinimo"))
                {
                    dgvTablaProductos.Columns["StockMinimo"].HeaderText = "Stock Mínimo";
                    dgvTablaProductos.Columns["StockMinimo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvTablaProductos.Columns.Contains("EstadoStock"))
                {
                    dgvTablaProductos.Columns["EstadoStock"].HeaderText = "Estado Stock";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al formatear columnas de productos: " + ex.Message);
            }
        }

        // CARGAR DATOS DE VENTAS
        private void CargarReporteVentas()
        {
            try
            {
                // Obtener ventas del último mes
                DateTime fechaInicio = DateTime.Now.AddMonths(-1);
                DateTime fechaFin = DateTime.Now;

                DataTable dt = negocioReporte.ObtenerReporteVentas(fechaInicio, fechaFin);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvTablaVentas.DataSource = dt;
                    label1.Text = $"Total: {dt.Rows.Count} ventas";
                    FormatearColumnasVentas();
                }
                else
                {
                    dgvTablaVentas.DataSource = null;
                    label1.Text = "Total: 0 ventas";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearColumnasVentas()
        {
            try
            {
                if (dgvTablaVentas.Columns.Contains("FechaVenta"))
                {
                    dgvTablaVentas.Columns["FechaVenta"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvTablaVentas.Columns["FechaVenta"].HeaderText = "Fecha";
                }

                if (dgvTablaVentas.Columns.Contains("Total"))
                {
                    dgvTablaVentas.Columns["Total"].DefaultCellStyle.Format = "C2";
                    dgvTablaVentas.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dgvTablaVentas.Columns.Contains("MetodoPago"))
                {
                    dgvTablaVentas.Columns["MetodoPago"].HeaderText = "Método de Pago";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al formatear columnas de ventas: " + ex.Message);
            }
        }

        // EXPORTAR PRODUCTOS A EXCEL
        private void btnExportarExcelProd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTablaProductos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos de productos para exportar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files|*.xlsx";
                saveDialog.Title = "Guardar Informe de Productos";
                saveDialog.FileName = $"Informe_Productos_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportarProductosAExcel(saveDialog.FileName);
                    MessageBox.Show("Informe de productos exportado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult resultado = MessageBox.Show("¿Desea abrir el archivo?", "Abrir Archivo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(saveDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar productos a Excel: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarProductosAExcel(string rutaArchivo)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Productos");

                worksheet.Cell(1, 1).Value = "INFORME DE PRODUCTOS";
                worksheet.Cell(1, 1).Style.Font.Bold = true;
                worksheet.Cell(1, 1).Style.Font.FontSize = 16;

                worksheet.Cell(2, 1).Value = $"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}";

                int filaInicio = 4;

                for (int i = 0; i < dgvTablaProductos.Columns.Count; i++)
                {
                    if (dgvTablaProductos.Columns[i].Visible)
                    {
                        worksheet.Cell(filaInicio, i + 1).Value = dgvTablaProductos.Columns[i].HeaderText;
                        worksheet.Cell(filaInicio, i + 1).Style.Font.Bold = true;
                        worksheet.Cell(filaInicio, i + 1).Style.Fill.BackgroundColor = XLColor.LightGreen;
                    }
                }

                for (int i = 0; i < dgvTablaProductos.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvTablaProductos.Columns.Count; j++)
                    {
                        if (dgvTablaProductos.Columns[j].Visible)
                        {
                            var valor = dgvTablaProductos.Rows[i].Cells[j].Value;
                            worksheet.Cell(i + filaInicio + 1, j + 1).Value = valor != null ? valor.ToString() : "";
                        }
                    }
                }

                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(rutaArchivo);
            }
        }

        // EXPORTAR PRODUCTOS A PDF
        private void btnExportarPDFprod_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTablaProductos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos de productos para exportar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF Files|*.pdf";
                saveDialog.Title = "Guardar Informe de Productos";
                saveDialog.FileName = $"Informe_Productos_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportarProductosAPDF(saveDialog.FileName);
                    MessageBox.Show("Informe de productos exportado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult resultado = MessageBox.Show("¿Desea abrir el archivo?", "Abrir Archivo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(saveDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar productos a PDF: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarProductosAPDF(string rutaArchivo)
        {
            Document documento = new Document(PageSize.A4.Rotate(), 20, 20, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(documento, new FileStream(rutaArchivo, FileMode.Create));
            documento.Open();

            iTextSharp.text.Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
            iTextSharp.text.Font fuenteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.DARK_GRAY);
            iTextSharp.text.Font fuenteEncabezado = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
            iTextSharp.text.Font fuenteDatos = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);

            Paragraph titulo = new Paragraph("INFORME DE PRODUCTOS", fuenteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 20f;
            documento.Add(titulo);

            Paragraph fechaGen = new Paragraph($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}", fuenteSubtitulo);
            fechaGen.Alignment = Element.ALIGN_CENTER;
            fechaGen.SpacingAfter = 20f;
            documento.Add(fechaGen);

            int columnasVisibles = 0;
            foreach (DataGridViewColumn col in dgvTablaProductos.Columns)
            {
                if (col.Visible) columnasVisibles++;
            }

            PdfPTable tabla = new PdfPTable(columnasVisibles);
            tabla.WidthPercentage = 100;

            foreach (DataGridViewColumn columna in dgvTablaProductos.Columns)
            {
                if (columna.Visible)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(columna.HeaderText, fuenteEncabezado));
                    celda.BackgroundColor = new BaseColor(34, 139, 34);
                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    celda.Padding = 5;
                    tabla.AddCell(celda);
                }
            }

            foreach (DataGridViewRow fila in dgvTablaProductos.Rows)
            {
                if (!fila.IsNewRow)
                {
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        if (dgvTablaProductos.Columns[celda.ColumnIndex].Visible)
                        {
                            string valor = celda.Value != null ? celda.Value.ToString() : "";
                            PdfPCell celdaPdf = new PdfPCell(new Phrase(valor, fuenteDatos));
                            celdaPdf.Padding = 4;
                            tabla.AddCell(celdaPdf);
                        }
                    }
                }
            }

            documento.Add(tabla);

            Paragraph total = new Paragraph($"Total de productos: {dgvTablaProductos.Rows.Count}", fuenteSubtitulo);
            total.Alignment = Element.ALIGN_RIGHT;
            total.SpacingBefore = 10f;
            documento.Add(total);

            documento.Close();
            writer.Close();
        }

        // EXPORTAR VENTAS A EXCEL
        private void btnExportarExcelVentas_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTablaVentas.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos de ventas para exportar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files|*.xlsx";
                saveDialog.Title = "Guardar Informe de Ventas";
                saveDialog.FileName = $"Informe_Ventas_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportarVentasAExcel(saveDialog.FileName);
                    MessageBox.Show("Informe de ventas exportado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult resultado = MessageBox.Show("¿Desea abrir el archivo?", "Abrir Archivo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(saveDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar ventas a Excel: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarVentasAExcel(string rutaArchivo)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Ventas");

                worksheet.Cell(1, 1).Value = "INFORME DE VENTAS";
                worksheet.Cell(1, 1).Style.Font.Bold = true;
                worksheet.Cell(1, 1).Style.Font.FontSize = 16;

                worksheet.Cell(2, 1).Value = $"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}";

                int filaInicio = 4;

                for (int i = 0; i < dgvTablaVentas.Columns.Count; i++)
                {
                    if (dgvTablaVentas.Columns[i].Visible)
                    {
                        worksheet.Cell(filaInicio, i + 1).Value = dgvTablaVentas.Columns[i].HeaderText;
                        worksheet.Cell(filaInicio, i + 1).Style.Font.Bold = true;
                        worksheet.Cell(filaInicio, i + 1).Style.Fill.BackgroundColor = XLColor.LightBlue;
                    }
                }

                for (int i = 0; i < dgvTablaVentas.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvTablaVentas.Columns.Count; j++)
                    {
                        if (dgvTablaVentas.Columns[j].Visible)
                        {
                            var valor = dgvTablaVentas.Rows[i].Cells[j].Value;
                            worksheet.Cell(i + filaInicio + 1, j + 1).Value = valor != null ? valor.ToString() : "";
                        }
                    }
                }

                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(rutaArchivo);
            }
        }

        // EXPORTAR VENTAS A PDF
        private void btnExportarPDFventas_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTablaVentas.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos de ventas para exportar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF Files|*.pdf";
                saveDialog.Title = "Guardar Informe de Ventas";
                saveDialog.FileName = $"Informe_Ventas_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportarVentasAPDF(saveDialog.FileName);
                    MessageBox.Show("Informe de ventas exportado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult resultado = MessageBox.Show("¿Desea abrir el archivo?", "Abrir Archivo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(saveDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar ventas a PDF: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarVentasAPDF(string rutaArchivo)
        {
            Document documento = new Document(PageSize.A4.Rotate(), 20, 20, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(documento, new FileStream(rutaArchivo, FileMode.Create));
            documento.Open();

            iTextSharp.text.Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
            iTextSharp.text.Font fuenteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.DARK_GRAY);
            iTextSharp.text.Font fuenteEncabezado = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
            iTextSharp.text.Font fuenteDatos = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);

            Paragraph titulo = new Paragraph("INFORME DE VENTAS", fuenteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 20f;
            documento.Add(titulo);

            Paragraph fechaGen = new Paragraph($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}", fuenteSubtitulo);
            fechaGen.Alignment = Element.ALIGN_CENTER;
            fechaGen.SpacingAfter = 20f;
            documento.Add(fechaGen);

            int columnasVisibles = 0;
            foreach (DataGridViewColumn col in dgvTablaVentas.Columns)
            {
                if (col.Visible) columnasVisibles++;
            }

            PdfPTable tabla = new PdfPTable(columnasVisibles);
            tabla.WidthPercentage = 100;

            foreach (DataGridViewColumn columna in dgvTablaVentas.Columns)
            {
                if (columna.Visible)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(columna.HeaderText, fuenteEncabezado));
                    celda.BackgroundColor = new BaseColor(100, 149, 237);
                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    celda.Padding = 5;
                    tabla.AddCell(celda);
                }
            }

            foreach (DataGridViewRow fila in dgvTablaVentas.Rows)
            {
                if (!fila.IsNewRow)
                {
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        if (dgvTablaVentas.Columns[celda.ColumnIndex].Visible)
                        {
                            string valor = celda.Value != null ? celda.Value.ToString() : "";
                            PdfPCell celdaPdf = new PdfPCell(new Phrase(valor, fuenteDatos));
                            celdaPdf.Padding = 4;
                            tabla.AddCell(celdaPdf);
                        }
                    }
                }
            }

            documento.Add(tabla);

            Paragraph total = new Paragraph($"Total de ventas: {dgvTablaVentas.Rows.Count}", fuenteSubtitulo);
            total.Alignment = Element.ALIGN_RIGHT;
            total.SpacingBefore = 10f;
            documento.Add(total);

            documento.Close();
            writer.Close();
        }
    }
}