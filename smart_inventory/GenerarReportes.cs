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
using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace smart_inventory
{
    public partial class GenerarReportes : Form
    {
        private CN_Reporte negocioReporte = new CN_Reporte();
        private Usuario usuarioActual;

        // Constructor sin parámetros (para cuando no se pasa usuario)
        public GenerarReportes()
        {
            InitializeComponent();
        }

        // Constructor con usuario (para registrar quién genera el reporte)
        public GenerarReportes(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void GenerarReportes_Load(object sender, EventArgs e)
        {
            // Maximizar ventana
            this.WindowState = FormWindowState.Maximized;

            // Configurar fechas por defecto
            ConfigurarFechas();

            // Configurar ComboBox de tipos de reporte
            ConfigurarComboEstado();

            // Configurar DataGridView
            ConfigurarDataGridView();

            // Cargar datos iniciales
            CargarReporteVentas();
        }

        private void ConfigurarFechas()
        {
            // Fecha de inicio: primer día del mes actual
            DateTime primerDiaMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            txtFechaInicio.Text = primerDiaMes.ToString("dd/MM/yyyy");
            txtFechaInicio.ReadOnly = true; // Hacer que sea solo lectura

            // Fecha fin: día actual
            dtpFechaFin.Value = DateTime.Now;

            // Agregar evento para actualizar cuando cambia la fecha
            dtpFechaFin.ValueChanged += DtpFechaFin_ValueChanged;
        }

        private void DtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            // Recargar datos cuando cambia la fecha
            CargarReporteVentas();
        }

        private void ConfigurarComboEstado()
        {
            // Seleccionar primera opción por defecto
            if (cbxEstado.Items.Count > 0)
            {
                cbxEstado.SelectedIndex = 0;
            }

            // Agregar evento para cambio de selección
            cbxEstado.SelectedIndexChanged += CbxEstado_SelectedIndexChanged;
        }

        private void CbxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Recargar datos según el tipo de reporte seleccionado
            CargarReporteVentas();
        }

        private void ConfigurarDataGridView()
        {
            dgvReportes.AutoGenerateColumns = true;
            dgvReportes.AllowUserToAddRows = false;
            dgvReportes.ReadOnly = true;
            dgvReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReportes.MultiSelect = false;
            dgvReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportes.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void CargarReporteVentas()
        {
            try
            {
                // Obtener fechas
                DateTime fechaInicio = DateTime.ParseExact(txtFechaInicio.Text, "dd/MM/yyyy", null);
                DateTime fechaFin = dtpFechaFin.Value;

                // Validar fechas
                if (fechaFin < fechaInicio)
                {
                    MessageBox.Show("La fecha de fin no puede ser menor a la fecha de inicio.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener datos del reporte
                DataTable dt = negocioReporte.ObtenerReporteVentas(fechaInicio, fechaFin);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvReportes.DataSource = dt;
                    lblTotalUsuarios.Text = $"Total: {dt.Rows.Count} ventas";

                    // Formatear columnas si existen
                    FormatearColumnas();
                }
                else
                {
                    dgvReportes.DataSource = null;
                    lblTotalUsuarios.Text = "Total: 0 ventas";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reporte: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearColumnas()
        {
            try
            {
                // Formatear columna de fecha si existe
                if (dgvReportes.Columns.Contains("FechaVenta"))
                {
                    dgvReportes.Columns["FechaVenta"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvReportes.Columns["FechaVenta"].HeaderText = "Fecha";
                }

                // Formatear columna de total si existe
                if (dgvReportes.Columns.Contains("Total"))
                {
                    dgvReportes.Columns["Total"].DefaultCellStyle.Format = "C2"; // Formato moneda
                    dgvReportes.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // Ajustar ancho de columnas
                if (dgvReportes.Columns.Contains("IdVenta"))
                {
                    dgvReportes.Columns["IdVenta"].Width = 80;
                    dgvReportes.Columns["IdVenta"].HeaderText = "ID Venta";
                }

                if (dgvReportes.Columns.Contains("Cajero"))
                {
                    dgvReportes.Columns["Cajero"].Width = 150;
                }

                if (dgvReportes.Columns.Contains("MetodoPago"))
                {
                    dgvReportes.Columns["MetodoPago"].Width = 120;
                    dgvReportes.Columns["MetodoPago"].HeaderText = "Método de Pago";
                }

                if (dgvReportes.Columns.Contains("Estado"))
                {
                    dgvReportes.Columns["Estado"].Width = 80;
                }
            }
            catch (Exception ex)
            {
                // Si hay error al formatear, no hacer nada crítico
                Console.WriteLine("Error al formatear columnas: " + ex.Message);
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReportes.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear diálogo para guardar archivo
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel Files|*.xlsx";
                saveDialog.Title = "Guardar Reporte Excel";
                saveDialog.FileName = $"Reporte_Ventas_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportarAExcel(saveDialog.FileName);

                    // Registrar en la base de datos
                    RegistrarReporteGenerado("Excel", saveDialog.FileName);

                    MessageBox.Show("Reporte exportado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Preguntar si desea abrir el archivo
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
                MessageBox.Show("Error al exportar a Excel: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarAExcel(string rutaArchivo)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Reporte Ventas");

                    // Título del reporte
                    worksheet.Cell(1, 1).Value = "REPORTE DE VENTAS";
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Font.FontSize = 16;

                    // Fechas del reporte
                    worksheet.Cell(2, 1).Value = $"Período: {txtFechaInicio.Text} al {dtpFechaFin.Value:dd/MM/yyyy}";
                    worksheet.Cell(3, 1).Value = $"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}";

                    // Espacio
                    int filaInicio = 5;

                    // Encabezados
                    for (int i = 0; i < dgvReportes.Columns.Count; i++)
                    {
                        if (dgvReportes.Columns[i].Visible)
                        {
                            worksheet.Cell(filaInicio, i + 1).Value = dgvReportes.Columns[i].HeaderText;
                            worksheet.Cell(filaInicio, i + 1).Style.Font.Bold = true;
                            worksheet.Cell(filaInicio, i + 1).Style.Fill.BackgroundColor = XLColor.LightBlue;
                        }
                    }

                    // Datos
                    for (int i = 0; i < dgvReportes.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvReportes.Columns.Count; j++)
                        {
                            if (dgvReportes.Columns[j].Visible)
                            {
                                var valor = dgvReportes.Rows[i].Cells[j].Value;
                                worksheet.Cell(i + filaInicio + 1, j + 1).Value = valor != null ? valor.ToString() : "";
                            }
                        }
                    }

                    // Ajustar ancho de columnas
                    worksheet.Columns().AdjustToContents();

                    // Guardar archivo
                    workbook.SaveAs(rutaArchivo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear archivo Excel: " + ex.Message);
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReportes.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear diálogo para guardar archivo
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF Files|*.pdf";
                saveDialog.Title = "Guardar Reporte PDF";
                saveDialog.FileName = $"Reporte_Ventas_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportarAPDF(saveDialog.FileName);

                    // Registrar en la base de datos
                    RegistrarReporteGenerado("PDF", saveDialog.FileName);

                    MessageBox.Show("Reporte PDF exportado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Preguntar si desea abrir el archivo
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
                MessageBox.Show("Error al exportar a PDF: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportarAPDF(string rutaArchivo)
        {
            try
            {
                // Crear documento PDF (tamaño carta, orientación horizontal para más columnas)
                Document documento = new Document(PageSize.A4.Rotate(), 20, 20, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(documento, new FileStream(rutaArchivo, FileMode.Create));

                // Abrir el documento
                documento.Open();

                // Fuentes
                iTextSharp.text.Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
                iTextSharp.text.Font fuenteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.DARK_GRAY);
                iTextSharp.text.Font fuenteEncabezado = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
                iTextSharp.text.Font fuenteDatos = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);

                // Título del reporte
                Paragraph titulo = new Paragraph("REPORTE DE VENTAS", fuenteTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                titulo.SpacingAfter = 10f;
                documento.Add(titulo);

                // Información del período
                Paragraph periodo = new Paragraph($"Período: {txtFechaInicio.Text} al {dtpFechaFin.Value:dd/MM/yyyy}", fuenteSubtitulo);
                periodo.Alignment = Element.ALIGN_CENTER;
                documento.Add(periodo);

                // Fecha de generación
                Paragraph fechaGen = new Paragraph($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}", fuenteSubtitulo);
                fechaGen.Alignment = Element.ALIGN_CENTER;
                fechaGen.SpacingAfter = 20f;
                documento.Add(fechaGen);

                // Si hay usuario, agregar quién generó el reporte
                if (usuarioActual != null)
                {
                    Paragraph usuario = new Paragraph($"Generado por: {usuarioActual.Nombre} {usuarioActual.Apellido}", fuenteSubtitulo);
                    usuario.Alignment = Element.ALIGN_CENTER;
                    usuario.SpacingAfter = 20f;
                    documento.Add(usuario);
                }

                // Crear tabla con el número de columnas visibles
                int columnasVisibles = 0;
                foreach (DataGridViewColumn col in dgvReportes.Columns)
                {
                    if (col.Visible) columnasVisibles++;
                }

                PdfPTable tabla = new PdfPTable(columnasVisibles);
                tabla.WidthPercentage = 100;
                tabla.SpacingBefore = 10f;
                tabla.SpacingAfter = 20f;

                // Agregar encabezados
                foreach (DataGridViewColumn columna in dgvReportes.Columns)
                {
                    if (columna.Visible)
                    {
                        PdfPCell celda = new PdfPCell(new Phrase(columna.HeaderText, fuenteEncabezado));
                        celda.BackgroundColor = new BaseColor(100, 149, 237); // Azul
                        celda.HorizontalAlignment = Element.ALIGN_CENTER;
                        celda.Padding = 5;
                        tabla.AddCell(celda);
                    }
                }

                // Agregar datos
                foreach (DataGridViewRow fila in dgvReportes.Rows)
                {
                    if (!fila.IsNewRow)
                    {
                        foreach (DataGridViewCell celda in fila.Cells)
                        {
                            if (dgvReportes.Columns[celda.ColumnIndex].Visible)
                            {
                                string valor = celda.Value != null ? celda.Value.ToString() : "";

                                PdfPCell celdaPdf = new PdfPCell(new Phrase(valor, fuenteDatos));
                                celdaPdf.Padding = 4;

                                // Alinear a la derecha si es columna numérica (Total)
                                if (dgvReportes.Columns[celda.ColumnIndex].Name == "Total")
                                {
                                    celdaPdf.HorizontalAlignment = Element.ALIGN_RIGHT;
                                }
                                else
                                {
                                    celdaPdf.HorizontalAlignment = Element.ALIGN_LEFT;
                                }

                                tabla.AddCell(celdaPdf);
                            }
                        }
                    }
                }

                // Agregar tabla al documento
                documento.Add(tabla);

                // Total de registros
                Paragraph total = new Paragraph($"Total de registros: {dgvReportes.Rows.Count}", fuenteSubtitulo);
                total.Alignment = Element.ALIGN_RIGHT;
                total.SpacingBefore = 10f;
                documento.Add(total);

                // Calcular total de ventas si existe la columna
                if (dgvReportes.Columns.Contains("Total"))
                {
                    decimal sumaTotal = 0;
                    foreach (DataGridViewRow fila in dgvReportes.Rows)
                    {
                        if (!fila.IsNewRow && fila.Cells["Total"].Value != null)
                        {
                            sumaTotal += Convert.ToDecimal(fila.Cells["Total"].Value);
                        }
                    }

                    Paragraph montoTotal = new Paragraph($"Monto total: {sumaTotal:C2}", fuenteTitulo);
                    montoTotal.Alignment = Element.ALIGN_RIGHT;
                    montoTotal.SpacingBefore = 5f;
                    documento.Add(montoTotal);
                }

                // Pie de página con información adicional
                documento.Add(new Paragraph("\n"));
                Paragraph piePagina = new Paragraph("Sistema Smart Inventory - Control de Inventario y Ventas",
                    FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 8, BaseColor.GRAY));
                piePagina.Alignment = Element.ALIGN_CENTER;
                documento.Add(piePagina);

                // Cerrar documento
                documento.Close();
                writer.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear archivo PDF: " + ex.Message);
            }
        }

        private void RegistrarReporteGenerado(string tipoReporte, string rutaArchivo)
        {
            try
            {
                if (usuarioActual != null)
                {
                    Reporte reporte = new Reporte
                    {
                        IdUsuario = usuarioActual.IdUsuario,
                        TipoReporte = tipoReporte,
                        FechaGeneracion = DateTime.Now,
                        RutaArchivo = rutaArchivo
                    };

                    string mensaje;
                    negocioReporte.Registrar(reporte, out mensaje);
                }
            }
            catch (Exception ex)
            {
                // No mostrar error al usuario, solo registrar en consola
                Console.WriteLine("Error al registrar reporte: " + ex.Message);
            }
        }

    }
}