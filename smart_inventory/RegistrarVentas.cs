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

namespace smart_inventory
{
    public partial class RegistrarVentas : Form
    {
        private CN_Venta negocioVenta = new CN_Venta();
        private CN_Producto negocioProducto = new CN_Producto();
        private Usuario usuarioActual;
        private List<DetalleVenta> listaDetalleVenta = new List<DetalleVenta>();
        private List<Producto> listaProductos = new List<Producto>();
        private Producto productoSeleccionado = null;
        private decimal subtotal = 0;
        private decimal descuento = 0;
        private decimal total = 0;
        private decimal montoRecibido = 0;
        private decimal vuelto = 0;

        public RegistrarVentas(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void RegistrarVentas_Load(object sender, EventArgs e)
        {
            // Maximizar ventana
            this.WindowState = FormWindowState.Maximized;

            // Configurar DataGridViews
            ConfigurarDataGridView();
            ConfigurarDataGridViewCatalogo();

            // Cargar datos iniciales
            CargarComboBoxes();
            CargarProductos();

            // Mostrar información del usuario
            txtIdUser.Text = usuarioActual.IdUsuario.ToString();
            txtIdUser.ReadOnly = true;

            // Configurar autocompletado
            ConfigurarAutocompletado();

            // Configurar eventos adicionales
            ConfigurarEventos();

            // Inicializar valores
            LimpiarFormulario();

            // Ocultar panel de pago rápido inicialmente
            gbPagoRapido.Visible = false;

            // Muestra Label de Atajos de Teclado
            lblAtajos.Text = "F1: Enfocar búsqueda de catálogo      F2: Agregar producto" +
                "       F3: Quitar producto     F5: Nueva venta" +
                "       F12: Finalizar venta     ESC: Limpiar campos de producto";
        }

        private void ConfigurarDataGridView()
        {
            dgvDetalleVenta.AutoGenerateColumns = false;
            dgvDetalleVenta.AllowUserToAddRows = false;
            dgvDetalleVenta.ReadOnly = true;
            dgvDetalleVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleVenta.MultiSelect = false;

            dgvDetalleVenta.Columns.Clear();

            dgvDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "ID",
                Name = "IdProducto",
                Width = 60
            });

            dgvDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Producto",
                Name = "NombreProducto",
                Width = 200
            });

            dgvDetalleVenta.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Precio Unit.",
                Name = "PrecioUnitario",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
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
                HeaderText = "Subtotal",
                Name = "Subtotal",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private void ConfigurarDataGridViewCatalogo()
        {
            dgvCatalogoProductos.AutoGenerateColumns = false;
            dgvCatalogoProductos.AllowUserToAddRows = false;
            dgvCatalogoProductos.ReadOnly = true;
            dgvCatalogoProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalogoProductos.MultiSelect = false;

            dgvCatalogoProductos.Columns.Clear();

            dgvCatalogoProductos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "ID",
                Name = "IdProducto",
                Width = 50
            });

            dgvCatalogoProductos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Nombre",
                Name = "Nombre",
                Width = 200
            });

            dgvCatalogoProductos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Precio",
                Name = "Precio",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvCatalogoProductos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Stock",
                Name = "Stock",
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
        }

        private void ConfigurarAutocompletado()
        {
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();

            foreach (Producto producto in listaProductos)
            {
                autoComplete.Add(producto.Nombre);
                autoComplete.Add($"ID: {producto.IdProducto}");
            }

            txtBuscarProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBuscarProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtBuscarProducto.AutoCompleteCustomSource = autoComplete;
        }

        private void ConfigurarEventos()
        {
            // Eventos de cálculo
            txtDescuento.TextChanged += txtDescuento_TextChanged;
            txtMontoRecibido.TextChanged += txtMontoRecibido_TextChanged;
            txtMontoRecibido.KeyDown += txtMontoRecibido_KeyDown;

            // Eventos de búsqueda
            txtBuscarProducto.TextChanged += txtBuscarProducto_TextChanged;
            txtBuscarProductoCatalogo.TextChanged += txtBuscarProductoCatalogo_TextChanged;

            // Eventos del catálogo
            dgvCatalogoProductos.CellDoubleClick += dgvCatalogoProductos_CellDoubleClick;
            dgvCatalogoProductos.SelectionChanged += dgvCatalogoProductos_SelectionChanged;

            // Evento de método de pago
            cbxMetodoPago.SelectedIndexChanged += cbxMetodoPago_SelectedIndexChanged;

            // Atajos de teclado
            this.KeyPreview = true;
            this.KeyDown += RegistrarVentas_KeyDown;

            // Botones de pago rápido
            btnPago10.Click += btnPagoRapido_Click;
            btnPago20.Click += btnPagoRapido_Click;
            btnPago50.Click += btnPagoRapido_Click;
            btnPago100.Click += btnPagoRapido_Click;
        }

        private void RegistrarVentas_KeyDown(object sender, KeyEventArgs e)
        {
            // F1: Buscar producto
            if (e.KeyCode == Keys.F1)
            {
                e.Handled = true;
                txtBuscarProductoCatalogo.Focus();
            }
            // F2: Agregar producto
            else if (e.KeyCode == Keys.F2)
            {
                e.Handled = true;
                btnAgregarProducto_Click(sender, e);
            }
            // F3: Quitar producto
            else if (e.KeyCode == Keys.F3)
            {
                e.Handled = true;
                btnQuitarProducto_Click(sender, e);
            }
            // F5: Nueva venta
            else if (e.KeyCode == Keys.F5)
            {
                e.Handled = true;
                btnNuevaVenta_Click(sender, e);
            }
            // F12: Finalizar venta
            else if (e.KeyCode == Keys.F12)
            {
                e.Handled = true;
                btnFinalizarVenta_Click(sender, e);
            }
            // ESC: Limpiar campos de producto
            else if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                LimpiarCamposProducto();
            }
        }

        private void CargarComboBoxes()
        {
            // Tipo de factura
            cbxTipoFactura.Items.Clear();
            cbxTipoFactura.Items.Add("Ticket");
            cbxTipoFactura.Items.Add("Factura");
            cbxTipoFactura.SelectedIndex = 0;

            // Método de pago
            cbxMetodoPago.Items.Clear();
            cbxMetodoPago.Items.Add("Efectivo");
            cbxMetodoPago.Items.Add("Tarjeta de Crédito");
            cbxMetodoPago.Items.Add("Tarjeta de Débito");
            cbxMetodoPago.Items.Add("Transferencia");
            cbxMetodoPago.SelectedIndex = 0;
        }

        private void cbxMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mostrar/ocultar panel de pago rápido según método de pago
            if (cbxMetodoPago.SelectedItem?.ToString() == "Efectivo")
            {
                gbPagoRapido.Visible = true;
                txtMontoRecibido.Enabled = true;
            }
            else
            {
                gbPagoRapido.Visible = false;
                txtMontoRecibido.Enabled = false;
                txtMontoRecibido.Text = total.ToString("0.00");
            }
        }

        private void CargarProductos()
        {
            try
            {
                listaProductos = negocioProducto.Listar()
                    .Where(p => p.Estado && p.Stock > 0)
                    .OrderBy(p => p.Nombre)
                    .ToList();

                MostrarProductosEnCatalogo(listaProductos);
                ConfigurarAutocompletado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarProductosEnCatalogo(List<Producto> productos)
        {
            dgvCatalogoProductos.Rows.Clear();

            foreach (Producto producto in productos)
            {
                int index = dgvCatalogoProductos.Rows.Add();
                dgvCatalogoProductos.Rows[index].Cells["IdProducto"].Value = producto.IdProducto;
                dgvCatalogoProductos.Rows[index].Cells["Nombre"].Value = producto.Nombre;
                dgvCatalogoProductos.Rows[index].Cells["Precio"].Value = producto.Precio;
                dgvCatalogoProductos.Rows[index].Cells["Stock"].Value = producto.Stock;

                // Resaltar productos con stock bajo
                if (producto.Stock <= producto.StockMinimo)
                {
                    dgvCatalogoProductos.Rows[index].DefaultCellStyle.BackColor = Color.LightYellow;
                    dgvCatalogoProductos.Rows[index].DefaultCellStyle.ForeColor = Color.DarkOrange;
                }
            }

            lblTotalProductosCatalogo.Text = $"Productos disponibles: {productos.Count}";
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string busqueda = txtBuscarProducto.Text.Trim();

                if (string.IsNullOrWhiteSpace(busqueda))
                {
                    LimpiarCamposProducto();
                    return;
                }

                // Buscar por ID o nombre
                Producto encontrado = null;

                // Intentar buscar por ID
                if (int.TryParse(busqueda, out int id))
                {
                    encontrado = listaProductos.FirstOrDefault(p => p.IdProducto == id);
                }

                // Si no encuentra por ID, buscar por nombre
                if (encontrado == null)
                {
                    encontrado = listaProductos.FirstOrDefault(p =>
                        p.Nombre.Equals(busqueda, StringComparison.OrdinalIgnoreCase));
                }

                if (encontrado != null)
                {
                    productoSeleccionado = encontrado;
                    lblPrecioUnitario.Text = encontrado.Precio.ToString("C2");
                    lblStockDisponible.Text = $"Stock: {encontrado.Stock}";
                    lblStockDisponible.ForeColor = encontrado.Stock <= encontrado.StockMinimo
                        ? Color.Red
                        : Color.Green;

                    // Seleccionar en el catálogo
                    foreach (DataGridViewRow row in dgvCatalogoProductos.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["IdProducto"].Value) == encontrado.IdProducto)
                        {
                            row.Selected = true;
                            dgvCatalogoProductos.FirstDisplayedScrollingRowIndex = row.Index;
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Ignorar errores durante la búsqueda en tiempo real
            }
        }

        private void txtBuscarProductoCatalogo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtBuscarProductoCatalogo.Text.ToLower().Trim();

                if (string.IsNullOrWhiteSpace(filtro))
                {
                    MostrarProductosEnCatalogo(listaProductos);
                }
                else
                {
                    var productosFiltrados = listaProductos.Where(p =>
                        p.Nombre.ToLower().Contains(filtro) ||
                        p.IdProducto.ToString().Contains(filtro) ||
                        (p.Descripcion != null && p.Descripcion.ToLower().Contains(filtro))
                    ).ToList();

                    MostrarProductosEnCatalogo(productosFiltrados);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCatalogoProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCatalogoProductos.CurrentRow != null && dgvCatalogoProductos.CurrentRow.Index >= 0)
            {
                int idProducto = Convert.ToInt32(dgvCatalogoProductos.CurrentRow.Cells["IdProducto"].Value);
                productoSeleccionado = listaProductos.FirstOrDefault(p => p.IdProducto == idProducto);

                if (productoSeleccionado != null)
                {
                    txtBuscarProducto.Text = productoSeleccionado.Nombre;
                    lblPrecioUnitario.Text = productoSeleccionado.Precio.ToString("C2");
                    lblStockDisponible.Text = $"Stock: {productoSeleccionado.Stock}";
                    lblStockDisponible.ForeColor = productoSeleccionado.Stock <= productoSeleccionado.StockMinimo
                        ? Color.Red
                        : Color.Green;
                }
            }
        }

        private void dgvCatalogoProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && productoSeleccionado != null)
            {
                txtCantidad.Text = "1";
                txtCantidad.Focus();
                txtCantidad.SelectAll();
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            txtBuscarProductoCatalogo.Focus();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            // Re-ejecuta la búsqueda superior y establece productoSeleccionado
            txtBuscarProducto_TextChanged(txtBuscarProducto, EventArgs.Empty);
            try
            {
                if (productoSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un producto del catálogo.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBuscarProductoCatalogo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCantidad.Text))
                {
                    MessageBox.Show("Debe ingresar la cantidad.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCantidad.Focus();
                    return;
                }

                int cantidad;
                if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número mayor a 0.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCantidad.Focus();
                    return;
                }

                // Verificar stock considerando lo que ya está en el carrito
                int cantidadEnCarrito = listaDetalleVenta
                    .Where(d => d.IdProducto == productoSeleccionado.IdProducto)
                    .Sum(d => d.Cantidad);

                if (cantidadEnCarrito + cantidad > productoSeleccionado.Stock)
                {
                    MessageBox.Show($"Stock insuficiente.\n\n" +
                        $"Disponible: {productoSeleccionado.Stock}\n" +
                        $"En carrito: {cantidadEnCarrito}\n" +
                        $"Puede agregar: {productoSeleccionado.Stock - cantidadEnCarrito}",
                        "Stock Insuficiente",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar si el producto ya está en la lista
                DetalleVenta detalleExistente = listaDetalleVenta
                    .FirstOrDefault(d => d.IdProducto == productoSeleccionado.IdProducto);

                if (detalleExistente != null)
                {
                    detalleExistente.Cantidad += cantidad;
                    detalleExistente.Subtotal = detalleExistente.Cantidad * detalleExistente.PrecioUnitario;
                }
                else
                {
                    DetalleVenta nuevoDetalle = new DetalleVenta
                    {
                        IdProducto = productoSeleccionado.IdProducto,
                        Producto = productoSeleccionado,
                        Cantidad = cantidad,
                        PrecioUnitario = productoSeleccionado.Precio,
                        Subtotal = cantidad * productoSeleccionado.Precio
                    };
                    listaDetalleVenta.Add(nuevoDetalle);
                }

                ActualizarTablaDetalles();
                CalcularTotales();
                LimpiarCamposProducto();

                // Mostrar mensaje de éxito
                lblMensajeAgregado.Text = $"✓ {productoSeleccionado.Nombre} agregado ({cantidad} unidades)";
                lblMensajeAgregado.ForeColor = Color.Green;

                Timer timer = new Timer { Interval = 3000 };
                timer.Tick += (s, ev) =>
                {
                    lblMensajeAgregado.Text = "";
                    timer.Stop();
                };
                timer.Start();

                txtBuscarProductoCatalogo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar producto: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetalleVenta.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar un producto de la lista.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int index = dgvDetalleVenta.SelectedRows[0].Index;
                string nombreProducto = listaDetalleVenta[index].Producto.Nombre;

                listaDetalleVenta.RemoveAt(index);

                ActualizarTablaDetalles();
                CalcularTotales();

                lblMensajeAgregado.Text = $"✓ {nombreProducto} eliminado";
                lblMensajeAgregado.ForeColor = Color.OrangeRed;

                Timer timer = new Timer { Interval = 2000 };
                timer.Tick += (s, ev) =>
                {
                    lblMensajeAgregado.Text = "";
                    timer.Stop();
                };
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al quitar producto: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarTablaDetalles()
        {
            dgvDetalleVenta.Rows.Clear();

            foreach (DetalleVenta detalle in listaDetalleVenta)
            {
                int index = dgvDetalleVenta.Rows.Add();
                dgvDetalleVenta.Rows[index].Cells["IdProducto"].Value = detalle.IdProducto;
                dgvDetalleVenta.Rows[index].Cells["NombreProducto"].Value = detalle.Producto.Nombre;
                dgvDetalleVenta.Rows[index].Cells["PrecioUnitario"].Value = detalle.PrecioUnitario;
                dgvDetalleVenta.Rows[index].Cells["Cantidad"].Value = detalle.Cantidad;
                dgvDetalleVenta.Rows[index].Cells["Subtotal"].Value = detalle.Subtotal;
            }

            int totalProductos = listaDetalleVenta.Sum(d => d.Cantidad);
            lblTotalUsuarios.Text = $"Total: {listaDetalleVenta.Count} productos ({totalProductos} unidades)";
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            CalcularTotales();
        }

        private void txtMontoRecibido_TextChanged(object sender, EventArgs e)
        {
            CalcularVuelto();
        }

        private void txtMontoRecibido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnFinalizarVenta_Click(sender, e);
            }
        }

        private void CalcularTotales()
        {
            subtotal = listaDetalleVenta.Sum(d => d.Subtotal);

            // Calcular descuento
            if (decimal.TryParse(txtDescuento.Text, out descuento) && descuento >= 0)
            {
                if (descuento > subtotal)
                {
                    descuento = 0;
                    txtDescuento.Text = "0";
                    MessageBox.Show("El descuento no puede ser mayor al subtotal.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                descuento = 0;
                txtDescuento.Text = "0";
            }

            total = subtotal - descuento;

            lblSubTotal.Text = subtotal.ToString("0.00");
            lblDescuento.Text = descuento.ToString("0.00");
            lblTotal.Text = total.ToString("0.00");

            // Actualizar colores
            lblSubTotal.ForeColor = Color.Black;
            lblDescuento.ForeColor = descuento > 0 ? Color.Red : Color.Black;
            lblTotal.ForeColor = Color.MediumSlateBlue;

            CalcularVuelto();
        }

        private void CalcularVuelto()
        {
            if (decimal.TryParse(txtMontoRecibido.Text, out montoRecibido) && montoRecibido >= 0)
            {
                vuelto = montoRecibido - total;
                lblVuelto.Text = vuelto.ToString("0.00");

                // Cambiar color según el vuelto
                if (vuelto < 0)
                {
                    lblVuelto.ForeColor = Color.Red;
                }
                else if (vuelto >= 0)
                {
                    lblVuelto.ForeColor = Color.Green;
                }
            }
            else
            {
                vuelto = 0;
                lblVuelto.Text = "0.00";
                lblVuelto.ForeColor = Color.Black;
            }
        }

        private void btnPagoExacto_Click(object sender, EventArgs e)
        {
            txtMontoRecibido.Text = total.ToString("0.00");
            btnFinalizarVenta.Focus();
        }

        private void btnPagoRapido_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                string monto = btn.Text.Replace("$", "").Trim();
                if (decimal.TryParse(monto, out decimal valor))
                {
                    decimal montoActual = 0;
                    decimal.TryParse(txtMontoRecibido.Text, out montoActual);

                    txtMontoRecibido.Text = (montoActual + valor).ToString("0.00");
                }
            }
        }

        private void btnPagoOtro_Click(object sender, EventArgs e)
        {
            using (Form formMonto = new Form())
            {
                formMonto.Text = "Ingrese Monto";
                formMonto.Size = new Size(300, 150);
                formMonto.StartPosition = FormStartPosition.CenterParent;
                formMonto.FormBorderStyle = FormBorderStyle.FixedDialog;
                formMonto.MaximizeBox = false;
                formMonto.MinimizeBox = false;

                Label lbl = new Label()
                {
                    Text = "Ingrese el monto recibido:",
                    Location = new Point(20, 20),
                    AutoSize = true
                };

                TextBox txt = new TextBox()
                {
                    Location = new Point(20, 50),
                    Size = new Size(240, 30),
                    Font = new System.Drawing.Font("Segoe UI", 12F)
                };

                Button btnOk = new Button()
                {
                    Text = "Aceptar",
                    Location = new Point(20, 85),
                    Size = new Size(100, 30),
                    DialogResult = DialogResult.OK
                };

                Button btnCancel = new Button()
                {
                    Text = "Cancelar",
                    Location = new Point(160, 85),
                    Size = new Size(100, 30),
                    DialogResult = DialogResult.Cancel
                };

                formMonto.Controls.Add(lbl);
                formMonto.Controls.Add(txt);
                formMonto.Controls.Add(btnOk);
                formMonto.Controls.Add(btnCancel);
                formMonto.AcceptButton = btnOk;
                formMonto.CancelButton = btnCancel;

                txt.Focus();

                if (formMonto.ShowDialog() == DialogResult.OK)
                {
                    if (decimal.TryParse(txt.Text, out decimal valor) && valor > 0)
                    {
                        txtMontoRecibido.Text = valor.ToString("0.00");
                    }
                }
            }
        }

        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que haya productos
                if (listaDetalleVenta.Count == 0)
                {
                    MessageBox.Show("Debe agregar al menos un producto a la venta.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar método de pago
                if (cbxMetodoPago.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un método de pago.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbxMetodoPago.Focus();
                    return;
                }

                // Validar monto recibido solo si es efectivo
                if (cbxMetodoPago.SelectedItem.ToString() == "Efectivo")
                {
                    if (montoRecibido < total)
                    {
                        MessageBox.Show($"El monto recibido ({montoRecibido:C2}) es menor al total ({total:C2}).\n\n" +
                            $"Falta: {(total - montoRecibido):C2}",
                            "Monto Insuficiente",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMontoRecibido.Focus();
                        return;
                    }
                }

                // Confirmar venta
                StringBuilder resumen = new StringBuilder();
                resumen.AppendLine("═══════════════════════════════════════");
                resumen.AppendLine("        CONFIRMAR VENTA");
                resumen.AppendLine("═══════════════════════════════════════");
                resumen.AppendLine();
                resumen.AppendLine($"Subtotal:        {subtotal:C2}");
                if (descuento > 0)
                    resumen.AppendLine($"Descuento:    - {descuento:C2}");
                resumen.AppendLine($"TOTAL:           {total:C2}");
                resumen.AppendLine();

                if (cbxMetodoPago.SelectedItem.ToString() == "Efectivo")
                {
                    resumen.AppendLine($"Recibido:        {montoRecibido:C2}");
                    resumen.AppendLine($"Vuelto:          {vuelto:C2}");
                    resumen.AppendLine();
                }

                resumen.AppendLine($"Método de Pago:  {cbxMetodoPago.SelectedItem}");
                resumen.AppendLine($"Productos:       {listaDetalleVenta.Count} ({listaDetalleVenta.Sum(d => d.Cantidad)} unidades)");

                if (!string.IsNullOrWhiteSpace(txtCliente.Text))
                    resumen.AppendLine($"Cliente:         {txtCliente.Text}");

                resumen.AppendLine();
                resumen.AppendLine("═══════════════════════════════════════");
                resumen.AppendLine();
                resumen.AppendLine("¿Confirmar esta venta?");

                DialogResult resultado = MessageBox.Show(resumen.ToString(), "Confirmar Venta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Crear venta
                    Venta nuevaVenta = new Venta
                    {
                        IdUsuario = usuarioActual.IdUsuario,
                        Fecha = DateTime.Now,
                        FechaVenta = DateTime.Now,
                        Total = total,
                        MetodoPago = cbxMetodoPago.SelectedItem.ToString(),
                        Comentario = txtComentario.Text.Trim(),
                        Estado = true,
                        DetallesVenta = listaDetalleVenta
                    };

                    // Registrar venta
                    string mensaje;
                    int idVentaGenerada = negocioVenta.RegistrarVenta(nuevaVenta, out mensaje);

                    if (idVentaGenerada > 0)
                    {
                        StringBuilder mensajeExito = new StringBuilder();
                        mensajeExito.AppendLine("╔════════════════════════════════════╗");
                        mensajeExito.AppendLine("║   ✓ VENTA REGISTRADA EXITOSA     ║");
                        mensajeExito.AppendLine("╚════════════════════════════════════╝");
                        mensajeExito.AppendLine();
                        mensajeExito.AppendLine($"ID Venta: {idVentaGenerada}");
                        mensajeExito.AppendLine($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}");
                        mensajeExito.AppendLine($"Total: {total:C2}");

                        if (cbxMetodoPago.SelectedItem.ToString() == "Efectivo")
                        {
                            mensajeExito.AppendLine();
                            mensajeExito.AppendLine($"Vuelto: {vuelto:C2}");
                        }

                        MessageBox.Show(mensajeExito.ToString(), "Venta Exitosa",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Preguntar si desea imprimir ticket
                        DialogResult imprimirTicket = MessageBox.Show(
                            "¿Desea imprimir el ticket de venta?",
                            "Imprimir Ticket",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (imprimirTicket == DialogResult.Yes)
                        {
                            ImprimirTicket(idVentaGenerada, nuevaVenta);
                        }

                        // Limpiar formulario
                        LimpiarFormulario();
                        CargarProductos(); // Recargar para actualizar stock
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error al Registrar Venta",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al finalizar venta: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirTicket(int idVenta, Venta venta)
        {
            try
            {
                StringBuilder ticket = new StringBuilder();
                ticket.AppendLine("========================================");
                ticket.AppendLine("         SMART INVENTORY");
                ticket.AppendLine("      Sistema de Inventario");
                ticket.AppendLine("========================================");
                ticket.AppendLine();
                ticket.AppendLine($"Ticket #: {idVenta}");
                ticket.AppendLine($"Fecha: {venta.FechaVenta:dd/MM/yyyy HH:mm}");
                ticket.AppendLine($"Cajero: {usuarioActual.Nombre} {usuarioActual.Apellido}");

                if (!string.IsNullOrWhiteSpace(txtCliente.Text))
                    ticket.AppendLine($"Cliente: {txtCliente.Text}");

                ticket.AppendLine($"Tipo: {cbxTipoFactura.SelectedItem}");
                ticket.AppendLine();
                ticket.AppendLine("========================================");
                ticket.AppendLine("PRODUCTOS:");
                ticket.AppendLine("========================================");

                foreach (DetalleVenta detalle in venta.DetallesVenta)
                {
                    ticket.AppendLine($"{detalle.Producto.Nombre}");
                    ticket.AppendLine($"  {detalle.Cantidad} x {detalle.PrecioUnitario:C2} = {detalle.Subtotal:C2}");
                    ticket.AppendLine();
                }

                ticket.AppendLine("========================================");
                ticket.AppendLine($"Subtotal:         {subtotal:C2}");

                if (descuento > 0)
                    ticket.AppendLine($"Descuento:      - {descuento:C2}");

                ticket.AppendLine($"TOTAL:            {total:C2}");
                ticket.AppendLine("========================================");
                ticket.AppendLine($"Método de Pago: {venta.MetodoPago}");

                if (venta.MetodoPago == "Efectivo")
                {
                    ticket.AppendLine($"Monto Recibido: {montoRecibido:C2}");
                    ticket.AppendLine($"Vuelto:         {vuelto:C2}");
                }

                ticket.AppendLine("========================================");

                if (!string.IsNullOrWhiteSpace(venta.Comentario))
                {
                    ticket.AppendLine($"Nota: {venta.Comentario}");
                    ticket.AppendLine("========================================");
                }

                ticket.AppendLine();
                ticket.AppendLine("      ¡Gracias por su compra!");
                ticket.AppendLine("       Vuelva pronto");
                ticket.AppendLine("========================================");

                MessageBox.Show(ticket.ToString(), "Ticket de Venta",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar ticket: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            if (listaDetalleVenta.Count > 0)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea iniciar una nueva venta?\n\n" +
                    "Se perderán todos los productos agregados.",
                    "Confirmar Nueva Venta",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    LimpiarFormulario();
                }
            }
            else
            {
                LimpiarFormulario();
            }
        }

        private void LimpiarFormulario()
        {
            // Limpiar campos de venta
            txtCliente.Clear();
            txtComentario.Clear();

            // Limpiar campos de producto
            LimpiarCamposProducto();

            // Resetear valores
            txtDescuento.Text = "0";
            txtMontoRecibido.Text = "0.00";
            lblSubTotal.Text = "0.00";
            lblDescuento.Text = "0.00";
            lblTotal.Text = "0.00";
            lblVuelto.Text = "0.00";

            // Resetear colores
            lblSubTotal.ForeColor = Color.Black;
            lblDescuento.ForeColor = Color.Black;
            lblTotal.ForeColor = Color.Black;
            lblVuelto.ForeColor = Color.Black;

            // Resetear combos
            cbxTipoFactura.SelectedIndex = 0;
            cbxMetodoPago.SelectedIndex = 0;

            // Limpiar listas
            listaDetalleVenta.Clear();
            dgvDetalleVenta.Rows.Clear();
            lblTotalUsuarios.Text = "Total: 0 productos";

            // Limpiar mensaje
            lblMensajeAgregado.Text = "";

            // Focus
            txtCliente.Focus();
        }

        private void LimpiarCamposProducto()
        {
            txtBuscarProducto.Clear();
            txtCantidad.Clear();
            lblPrecioUnitario.Text = "$0.00";
            lblStockDisponible.Text = "Stock: 0";
            lblStockDisponible.ForeColor = Color.Gray;
            productoSeleccionado = null;
            dgvCatalogoProductos.ClearSelection();
        }

        private void txtIdProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtCantidad.Focus();
            }
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAgregarProducto_Click(sender, e);
            }
        }
    }
}