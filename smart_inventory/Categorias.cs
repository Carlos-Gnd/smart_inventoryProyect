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
    public partial class Categorias : Form
    {
        private CN_Categoria negocioCategoria = new CN_Categoria();
        private List<Categoria> listaCategorias = new List<Categoria>();
        private Categoria categoriaSeleccionada = null;

        public Categorias()
        {
            InitializeComponent();
        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            // Maximizar ventana
            this.WindowState = FormWindowState.Maximized;

            // Configurar DataGridView
            ConfigurarDataGridView();

            // Cargar categorías
            CargarCategorias();

            // Checkbox activo por defecto
            chkActivo.Checked = true;

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
            // Configurar el DataGridView
            dgvCategorias.AutoGenerateColumns = false;
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.ReadOnly = true;
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.MultiSelect = false;
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvCategorias.DefaultCellStyle.ForeColor = Color.Black;

            // Limpiar columnas existentes
            dgvCategorias.Columns.Clear();

            // Agregar columnas manualmente
            dgvCategorias.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "IdCategoria",
                HeaderText = "ID",
                Name = "IdCategoria",
                Width = 50
            });

            dgvCategorias.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "Nombre",
                Width = 200
            });

            dgvCategorias.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Descripcion",
                HeaderText = "Descripción",
                Name = "Descripcion",
                Width = 350
            });
        }

        private void CargarCategorias()
        {
            try
            {
                listaCategorias = negocioCategoria.Listar();
                dgvCategorias.Rows.Clear();



                foreach (Categoria categoria in listaCategorias)
                {
                    int index = dgvCategorias.Rows.Add();
                    dgvCategorias.Rows[index].Cells["IdCategoria"].Value = categoria.IdCategoria;
                    dgvCategorias.Rows[index].Cells["Nombre"].Value = categoria.Nombre;
                    dgvCategorias.Rows[index].Cells["Descripcion"].Value = categoria.Descripcion;
                }

                lblTotalCategorias.Text = $"Total: {listaCategorias.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos
                if (!ValidarCampos())
                    return;

                Categoria nueva = new Categoria
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim()
                };

                string mensaje;
                int idGenerado = negocioCategoria.Registrar(nueva, out mensaje);

                if (idGenerado > 0)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCategorias();
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

        private void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (categoriaSeleccionada == null)
                {
                    MessageBox.Show("Debe seleccionar una categoría de la tabla para editar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar campos
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre de la categoría.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                Categoria editada = new Categoria
                {
                    IdCategoria = categoriaSeleccionada.IdCategoria,
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim()
                };

                string mensaje;
                bool resultado = negocioCategoria.Editar(editada, out mensaje);

                if (resultado)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCategorias();
                    LimpiarCampos();
                    categoriaSeleccionada = null;
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

        private void btnBorrarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (categoriaSeleccionada == null)
                {
                    MessageBox.Show("Debe seleccionar una categoría de la tabla para eliminar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Está seguro que desea eliminar la categoría '{categoriaSeleccionada.Nombre}'?\n\n" +
                    "Esta acción no se puede deshacer y puede afectar los productos asociados.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacion == DialogResult.Yes)
                {
                    string mensaje;
                    bool resultado = negocioCategoria.Eliminar(categoriaSeleccionada.IdCategoria, out mensaje);

                    if (resultado)
                    {
                        MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCategorias();
                        LimpiarCampos();
                        categoriaSeleccionada = null;
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

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCategorias.Rows.Count)
            {
                try
                {
                    // Obtener el ID de la categoría de la fila seleccionada
                    int idCategoria = Convert.ToInt32(dgvCategorias.Rows[e.RowIndex].Cells["IdCategoria"].Value);

                    // Buscar la categoría en la lista por su ID
                    categoriaSeleccionada = listaCategorias.FirstOrDefault(c => c.IdCategoria == idCategoria);

                    if (categoriaSeleccionada != null)
                    {
                        // Cargar datos en los controles
                        txtNombre.Text = categoriaSeleccionada.Nombre;
                        txtDescripcion.Text = categoriaSeleccionada.Descripcion;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar categoría: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBuscarCategoria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtBuscarCategoria.Text.ToLower().Trim();

                if (string.IsNullOrWhiteSpace(filtro))
                {
                    // Mostrar todas las categorías
                    MostrarTodasCategorias();
                }
                else
                {
                    // Filtrar categorías
                    var listaFiltrada = listaCategorias.Where(c =>
                        c.Nombre.ToLower().Contains(filtro) ||
                        (c.Descripcion != null && c.Descripcion.ToLower().Contains(filtro))
                    ).ToList();

                    MostrarCategoriasFiltradas(listaFiltrada);
                }

                lblTotalCategorias.Text = $"Total: {dgvCategorias.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarTodasCategorias()
        {
            dgvCategorias.Rows.Clear();
            foreach (Categoria categoria in listaCategorias)
            {
                int index = dgvCategorias.Rows.Add();
                dgvCategorias.Rows[index].Cells["IdCategoria"].Value = categoria.IdCategoria;
                dgvCategorias.Rows[index].Cells["Nombre"].Value = categoria.Nombre;
                dgvCategorias.Rows[index].Cells["Descripcion"].Value = categoria.Descripcion;
            }
        }

        private void MostrarCategoriasFiltradas(List<Categoria> categoriasFiltradas)
        {
            dgvCategorias.Rows.Clear();
            foreach (Categoria categoria in categoriasFiltradas)
            {
                int index = dgvCategorias.Rows.Add();
                dgvCategorias.Rows[index].Cells["IdCategoria"].Value = categoria.IdCategoria;
                dgvCategorias.Rows[index].Cells["Nombre"].Value = categoria.Nombre;
                dgvCategorias.Rows[index].Cells["Descripcion"].Value = categoria.Descripcion;
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre de la categoría.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (txtNombre.Text.Trim().Length > 50)
            {
                MessageBox.Show("El nombre de la categoría no puede exceder 50 caracteres.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            chkActivo.Checked = true;
            categoriaSeleccionada = null;
            txtNombre.Focus();
        }

        private void Categorias_Load_1(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'smart_InventoryDataSet.Categorias' Puede moverla o quitarla según sea necesario.
            this.categoriasTableAdapter.Fill(this.smart_InventoryDataSet.Categorias);

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}