using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace smart_inventory
{
    public partial class Usuarios : Form
    {
        private CN_Usuario negocioUsuario = new CN_Usuario();
        private CN_Rol negocioRol = new CN_Rol();
        private List<Usuario> listaUsuarios = new List<Usuario>();
        private Usuario usuarioSeleccionado = null;

        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarRoles();
            CargarUsuarios();
            chkActivo.Checked = true;
        }

        private void ConfigurarDataGridView()
        {
            // Configurar el DataGridView
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;

            // Limpiar columnas existentes
            dgvUsuarios.Columns.Clear();

            // Agregar columnas manualmente
            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "IdUsuario",
                HeaderText = "ID",
                Name = "IdUsuario",
                Width = 50
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "Nombre",
                Width = 120
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Apellido",
                HeaderText = "Apellido",
                Name = "Apellido",
                Width = 120
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "UsuarioNombre",
                HeaderText = "Usuario",
                Name = "UsuarioNombre",
                Width = 100
            });

            // Columna para el rol
            DataGridViewTextBoxColumn colRol = new DataGridViewTextBoxColumn();
            colRol.HeaderText = "Rol";
            colRol.Name = "Rol";
            colRol.Width = 100;
            dgvUsuarios.Columns.Add(colRol);

            dgvUsuarios.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                DataPropertyName = "Activo",
                HeaderText = "Activo",
                Name = "Activo",
                Width = 60
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "FechaRegistro",
                HeaderText = "Fecha Registro",
                Name = "FechaRegistro",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
        }

        private void CargarUsuarios()
        {
            try
            {
                listaUsuarios = negocioUsuario.Listar();
                dgvUsuarios.Rows.Clear();

                foreach (Usuario usuario in listaUsuarios)
                {
                    int index = dgvUsuarios.Rows.Add();
                    dgvUsuarios.Rows[index].Cells["IdUsuario"].Value = usuario.IdUsuario;
                    dgvUsuarios.Rows[index].Cells["Nombre"].Value = usuario.Nombre;
                    dgvUsuarios.Rows[index].Cells["Apellido"].Value = usuario.Apellido;
                    dgvUsuarios.Rows[index].Cells["UsuarioNombre"].Value = usuario.UsuarioNombre;
                    dgvUsuarios.Rows[index].Cells["Rol"].Value = usuario.Rol != null ? usuario.Rol.RolNombre : "";
                    dgvUsuarios.Rows[index].Cells["Activo"].Value = usuario.Activo;
                    dgvUsuarios.Rows[index].Cells["FechaRegistro"].Value = usuario.FechaRegistro;
                }

                lblTotalUsuarios.Text = $"Total: {listaUsuarios.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarRoles()
        {
            try
            {
                List<Rol> listaRoles = negocioRol.Listar();

                cboRol.DataSource = listaRoles;
                cboRol.DisplayMember = "RolNombre";
                cboRol.ValueMember = "IdRol";
                cboRol.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos
                if (!ValidarCampos())
                    return;

                Usuario nuevo = new Usuario
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    UsuarioNombre = txtUsuario.Text.Trim(),
                    ClaveHash = txtClave.Text, // Se hasheará en la capa de negocio
                    IdRol = Convert.ToInt32(cboRol.SelectedValue),
                    Activo = chkActivo.Checked
                };

                string mensaje;
                int idGenerado = negocioUsuario.Registrar(nuevo, out mensaje);

                if (idGenerado > 0)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
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

        private void btnEditarUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (usuarioSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un usuario de la tabla para editar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar campos (sin contraseña)
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    MessageBox.Show("Debe ingresar el apellido.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApellido.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    MessageBox.Show("Debe ingresar el usuario.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return;
                }

                if (cboRol.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un rol.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Usuario editado = new Usuario
                {
                    IdUsuario = usuarioSeleccionado.IdUsuario,
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    UsuarioNombre = txtUsuario.Text.Trim(),
                    IdRol = Convert.ToInt32(cboRol.SelectedValue),
                    Activo = chkActivo.Checked
                };

                string mensaje;
                bool resultado = negocioUsuario.Editar(editado, out mensaje);

                if (resultado)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                    LimpiarCampos();
                    usuarioSeleccionado = null;
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

        private void btnBorrarUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (usuarioSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un usuario de la tabla para eliminar.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el usuario '{usuarioSeleccionado.UsuarioNombre}'?\n\n" +
                    "El usuario será marcado como inactivo.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion == DialogResult.Yes)
                {
                    string mensaje;
                    bool resultado = negocioUsuario.Eliminar(usuarioSeleccionado.IdUsuario, out mensaje);

                    if (resultado)
                    {
                        MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarios();
                        LimpiarCampos();
                        usuarioSeleccionado = null;
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

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];
                usuarioSeleccionado = listaUsuarios[e.RowIndex];

                // Cargar datos en los controles
                txtNombre.Text = usuarioSeleccionado.Nombre;
                txtApellido.Text = usuarioSeleccionado.Apellido;
                txtUsuario.Text = usuarioSeleccionado.UsuarioNombre;
                cboRol.SelectedValue = usuarioSeleccionado.IdRol;
                chkActivo.Checked = usuarioSeleccionado.Activo;

                // Limpiar el campo de contraseña
                txtClave.Clear();
                txtClave.Enabled = false; // No permitir editar la contraseña desde aquí
            }
        }

        private void txtBuscarUsuario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = txtBuscarUsuario.Text.ToLower().Trim();

                if (string.IsNullOrWhiteSpace(filtro))
                {
                    // Mostrar todos los usuarios
                    dgvUsuarios.Rows.Clear();
                    foreach (Usuario usuario in listaUsuarios)
                    {
                        int index = dgvUsuarios.Rows.Add();
                        dgvUsuarios.Rows[index].Cells["IdUsuario"].Value = usuario.IdUsuario;
                        dgvUsuarios.Rows[index].Cells["Nombre"].Value = usuario.Nombre;
                        dgvUsuarios.Rows[index].Cells["Apellido"].Value = usuario.Apellido;
                        dgvUsuarios.Rows[index].Cells["UsuarioNombre"].Value = usuario.UsuarioNombre;
                        dgvUsuarios.Rows[index].Cells["Rol"].Value = usuario.Rol != null ? usuario.Rol.RolNombre : "";
                        dgvUsuarios.Rows[index].Cells["Activo"].Value = usuario.Activo;
                        dgvUsuarios.Rows[index].Cells["FechaRegistro"].Value = usuario.FechaRegistro;
                    }
                }
                else
                {
                    // Filtrar usuarios
                    var listaFiltrada = listaUsuarios.Where(u =>
                        u.Nombre.ToLower().Contains(filtro) ||
                        u.Apellido.ToLower().Contains(filtro) ||
                        u.UsuarioNombre.ToLower().Contains(filtro) ||
                        (u.Rol != null && u.Rol.RolNombre.ToLower().Contains(filtro))
                    ).ToList();

                    dgvUsuarios.Rows.Clear();
                    foreach (Usuario usuario in listaFiltrada)
                    {
                        int index = dgvUsuarios.Rows.Add();
                        dgvUsuarios.Rows[index].Cells["IdUsuario"].Value = usuario.IdUsuario;
                        dgvUsuarios.Rows[index].Cells["Nombre"].Value = usuario.Nombre;
                        dgvUsuarios.Rows[index].Cells["Apellido"].Value = usuario.Apellido;
                        dgvUsuarios.Rows[index].Cells["UsuarioNombre"].Value = usuario.UsuarioNombre;
                        dgvUsuarios.Rows[index].Cells["Rol"].Value = usuario.Rol != null ? usuario.Rol.RolNombre : "";
                        dgvUsuarios.Rows[index].Cells["Activo"].Value = usuario.Activo;
                        dgvUsuarios.Rows[index].Cells["FechaRegistro"].Value = usuario.FechaRegistro;
                    }
                }

                lblTotalUsuarios.Text = $"Total: {dgvUsuarios.Rows.Count}";
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
                MessageBox.Show("Debe ingresar el nombre.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar el apellido.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Debe ingresar el usuario.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Debe ingresar la contraseña.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return false;
            }

            if (txtClave.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return false;
            }

            if (cboRol.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rol.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
            cboRol.SelectedIndex = -1;
            chkActivo.Checked = true;
            txtClave.Enabled = true;
            usuarioSeleccionado = null;
            txtNombre.Focus();
        }
    }
}