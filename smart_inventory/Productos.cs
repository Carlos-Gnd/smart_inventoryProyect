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
    public partial class Productos : Form
    {
        private CN_Producto negocioProducto = new CN_Producto();
        private CN_Categoria negocioCategoria = new CN_Categoria();
        private List<Producto> listaProductos = new List<Producto>();
        private Producto productoSeleccionado = null;

        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            // Maximizar ventana
            this.WindowState = FormWindowState.Maximized;

            // Configurar DataGridView
            ConfigurarDataGridView();

            // Cargar categorías en el ComboBox
            CargarCategorias();

            // Cargar productos
            CargarProductos();

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
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;

            // Limpiar columnas existentes
            dgvProductos.Columns.Clear();

            // Agregar columnas manualmente
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "IdProducto",
                HeaderText = "ID",
                Name = "IdProducto",
                Width = 50
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Código",
                Name = "Codigo",
                Width = 100
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "Nombre",
                Width = 150
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Categoría",
                Name = "Categoria",
                Width = 120
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Descripcion",
                HeaderText = "Descripción",
                Name = "Descripcion",
                Width = 150
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Precio",
                HeaderText = "Precio Venta",
                Name = "Precio",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Stock",
                HeaderText = "Stock",
                Name = "Stock",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "StockMinimo",
                HeaderText = "Stock Mín.",
                Name = "StockMinimo",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvProductos.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                DataPropertyName = "Estado",
                HeaderText = "Activo",
                Name = "Estado",
                Width = 60
            });
        }

        private void CargarCategorias()
        {
            try
            {
                List<Categoria> listaCategorias = negocioCategoria.Listar();

                cbxCategoria.DataSource = listaCategorias;
                cbxCategoria.DisplayMember = "Nombre";
                cbxCategoria.ValueMember = "IdCategoria";
                cbxCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductos()
        {
            try
            {
                listaProductos = negocioProducto.Listar();
                dgvProductos.Rows.Clear();

                foreach (Producto producto in listaProductos)
                {
                    int index = dgvProductos.Rows.Add();
                    dgvProductos.Rows[index].Cells["IdProducto"].Value = producto.IdProducto;
                    dgvProductos.Rows[index].Cells["Codigo"].Value = $"PROD-{producto.IdProducto:D4}";
                    dgvProductos.Rows[index].Cells["Nombre"].Value = producto.Nombre;
                    dgvProductos.Rows[index].Cells["Categoria"].Value = producto.Categoria != null ? producto.Categoria.Nombre : "";
                    dgvProductos.Rows[index].Cells["Descripcion"].Value = producto.Descripcion;
                    dgvProductos.Rows[index].Cells["Precio"].Value = producto.Precio;
                    dgvProductos.Rows[index].Cells["Stock"].Value = producto.Stock;
                    dgvProductos.Rows[index].Cells["StockMinimo"].Value = producto.StockMinimo;
                    dgvProductos.Rows[index].Cells["Estado"].Value = producto.Estado;

                    // Resaltar productos con stock bajo
                    if (producto.Stock <= producto.StockMinimo)
                    {
                        dgvProductos.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                    }
                }

                lblTotalUsuarios.Text = $"Total: {listaProductos.Count} productos";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos
                if (!ValidarCampos())
                    return;

                Producto nuevo = new Producto
                {
                    Nombre = txtNombre.Text.Trim(),
                    IdCategoria = Convert.ToInt32(cbxCategoria.SelectedValue),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Precio = Convert.ToDecimal(txtPrecioVenta.Text),
                    Stock = Convert.ToInt32(txtStock.Text),
                    StockMinimo = Convert.ToInt32(txtStockMinimo.Text),
                    Estado = true,
                    EsProductoFinal = true
                };

                string mensaje;
                int idGenerado = negocioProducto.Registrar(nuevo, out mensaje);

                if (idGenerado > 0)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProductos();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (productoSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un producto de la tabla para editar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar campos
                if (!ValidarCampos())
                    return;

                Producto editado = new Producto
                {
                    IdProducto = productoSeleccionado.IdProducto,
                    Nombre = txtNombre.Text.Trim(),
                    IdCategoria = Convert.ToInt32(cbxCategoria.SelectedValue),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Precio = Convert.ToDecimal(txtPrecioVenta.Text),
                    Stock = Convert.ToInt32(txtStock.Text),
                    StockMinimo = Convert.ToInt32(txtStockMinimo.Text),
                    Estado = productoSeleccionado.Estado,
                    EsProductoFinal = productoSeleccionado.EsProductoFinal
                };

                string mensaje;
                bool resultado = negocioProducto.Editar(editado, out mensaje);

                if (resultado)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProductos();
                    LimpiarCampos();
                    productoSeleccionado = null;
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBorrarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (productoSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un producto de la tabla para eliminar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el producto '{productoSeleccionado.Nombre}'?\n\n" +
                    "El producto será marcado como inactivo.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacion == DialogResult.Yes)
                {
                    string mensaje;
                    bool resultado = negocioProducto.Eliminar(productoSeleccionado.IdProducto, out mensaje);

                    if (resultado)
                    {
                        MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProductos();
                        LimpiarCampos();
                        productoSeleccionado = null;
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                productoSeleccionado = listaProductos[e.RowIndex];

                // Cargar datos en los controles
                txtCodigo.Text = $"PROD-{productoSeleccionado.IdProducto:D4}";
                txtCodigo.ReadOnly = true; // El código no se edita
                txtNombre.Text = productoSeleccionado.Nombre;
                txtDescripcion.Text = productoSeleccionado.Descripcion;
                cbxCategoria.SelectedValue = productoSeleccionado.IdCategoria;

                // Limpiar el campo de precio de compra (no se usa en este diseño)
                txtPrecioCompra.Clear();

                txtPrecioVenta.Text = productoSeleccionado.Precio.ToString("0.00");
                txtStock.Text = productoSeleccionado.Stock.ToString();
                txtStockMinimo.Text = productoSeleccionado.StockMinimo.ToString();
            }
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtBuscarProducto.Text.ToLower().Trim();

                if (string.IsNullOrWhiteSpace(filtro))
                {
                    // Mostrar todos los productos
                    dgvProductos.Rows.Clear();
                    foreach (Producto producto in listaProductos)
                    {
                        int index = dgvProductos.Rows.Add();
                        dgvProductos.Rows[index].Cells["IdProducto"].Value = producto.IdProducto;
                        dgvProductos.Rows[index].Cells["Codigo"].Value = $"PROD-{producto.IdProducto:D4}";
                        dgvProductos.Rows[index].Cells["Nombre"].Value = producto.Nombre;
                        dgvProductos.Rows[index].Cells["Categoria"].Value = producto.Categoria != null ? producto.Categoria.Nombre : "";
                        dgvProductos.Rows[index].Cells["Descripcion"].Value = producto.Descripcion;
                        dgvProductos.Rows[index].Cells["Precio"].Value = producto.Precio;
                        dgvProductos.Rows[index].Cells["Stock"].Value = producto.Stock;
                        dgvProductos.Rows[index].Cells["StockMinimo"].Value = producto.StockMinimo;
                        dgvProductos.Rows[index].Cells["Estado"].Value = producto.Estado;

                        if (producto.Stock <= producto.StockMinimo)
                        {
                            dgvProductos.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                        }
                    }
                }
                else
                {
                    // Filtrar productos
                    var listaFiltrada = listaProductos.Where(p =>
                        p.Nombre.ToLower().Contains(filtro) ||
                        (p.Descripcion != null && p.Descripcion.ToLower().Contains(filtro)) ||
                        (p.Categoria != null && p.Categoria.Nombre.ToLower().Contains(filtro)) ||
                        $"PROD-{p.IdProducto:D4}".ToLower().Contains(filtro)
                    ).ToList();

                    dgvProductos.Rows.Clear();
                    foreach (Producto producto in listaFiltrada)
                    {
                        int index = dgvProductos.Rows.Add();
                        dgvProductos.Rows[index].Cells["IdProducto"].Value = producto.IdProducto;
                        dgvProductos.Rows[index].Cells["Codigo"].Value = $"PROD-{producto.IdProducto:D4}";
                        dgvProductos.Rows[index].Cells["Nombre"].Value = producto.Nombre;
                        dgvProductos.Rows[index].Cells["Categoria"].Value = producto.Categoria != null ? producto.Categoria.Nombre : "";
                        dgvProductos.Rows[index].Cells["Descripcion"].Value = producto.Descripcion;
                        dgvProductos.Rows[index].Cells["Precio"].Value = producto.Precio;
                        dgvProductos.Rows[index].Cells["Stock"].Value = producto.Stock;
                        dgvProductos.Rows[index].Cells["StockMinimo"].Value = producto.StockMinimo;
                        dgvProductos.Rows[index].Cells["Estado"].Value = producto.Estado;

                        if (producto.Stock <= producto.StockMinimo)
                        {
                            dgvProductos.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                        }
                    }
                }

                lblTotalUsuarios.Text = $"Total: {dgvProductos.Rows.Count} productos";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del producto.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (cbxCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una categoría.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxCategoria.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrecioVenta.Text))
            {
                MessageBox.Show("Debe ingresar el precio de venta.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioVenta.Focus();
                return false;
            }

            decimal precio;
            if (!decimal.TryParse(txtPrecioVenta.Text, out precio) || precio <= 0)
            {
                MessageBox.Show("El precio de venta debe ser un número válido mayor a 0.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioVenta.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("Debe ingresar el stock.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }

            int stock;
            if (!int.TryParse(txtStock.Text, out stock) || stock < 0)
            {
                MessageBox.Show("El stock debe ser un número entero válido mayor o igual a 0.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtStockMinimo.Text))
            {
                MessageBox.Show("Debe ingresar el stock mínimo.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStockMinimo.Focus();
                return false;
            }

            int stockMinimo;
            if (!int.TryParse(txtStockMinimo.Text, out stockMinimo) || stockMinimo < 0)
            {
                MessageBox.Show("El stock mínimo debe ser un número entero válido mayor o igual a 0.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStockMinimo.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtCodigo.ReadOnly = false;
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
            txtStock.Clear();
            txtStockMinimo.Clear();
            cbxCategoria.SelectedIndex = -1;
            productoSeleccionado = null;
            txtNombre.Focus();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
