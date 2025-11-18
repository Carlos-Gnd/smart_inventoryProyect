using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace smart_inventory
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            ConfigurarFormulario();
            ConfigurarEfectosVisuales();
            this.WindowState = FormWindowState.Maximized;
        }

        private void ConfigurarFormulario()
        {
            // Configurar el TextBox de contraseña para ocultar el texto
            txtPasswd.UseSystemPasswordChar = true;

            // Establecer foco en el campo de usuario
            txtUser.Focus();
        }

        private void ConfigurarEfectosVisuales()
        {
            // Gradiente en panel izquierdo (branding morado)
            pnlLeftBranding.Paint += (s, e) =>
            {
                using (var brush = new LinearGradientBrush(
                    pnlLeftBranding.ClientRectangle,
                    Color.FromArgb(138, 99, 210),   // Morado claro
                    Color.FromArgb(101, 65, 165),    // Morado oscuro
                    45f))
                {
                    e.Graphics.FillRectangle(brush, pnlLeftBranding.ClientRectangle);
                }

                // Círculos decorativos flotantes
                using (SolidBrush circleBrush = new SolidBrush(Color.FromArgb(20, 255, 255, 255)))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    // Círculo superior izquierdo
                    e.Graphics.FillEllipse(circleBrush, -50, -50, 200, 200);
                    // Círculo inferior derecho
                    e.Graphics.FillEllipse(circleBrush, 300, 400, 250, 250);
                }
            };

            // Bordes en los contenedores de input
            pnlUsernameContainer.Paint += PintarBordeInput;
            pnlPasswordContainer.Paint += PintarBordeInput;

            // Efecto hover en botón de login (cambio de color al pasar el mouse)
            btnLogin.MouseEnter += (s, e) => btnLogin.BackColor = Color.FromArgb(118, 79, 190);
            btnLogin.MouseLeave += (s, e) => btnLogin.BackColor = Color.FromArgb(138, 99, 210);

            // Efecto focus en inputs (cambia color de fondo al hacer clic)
            txtUser.Enter += (s, e) => pnlUsernameContainer.BackColor = Color.FromArgb(248, 248, 255);
            txtUser.Leave += (s, e) => pnlUsernameContainer.BackColor = Color.White;
            txtPasswd.Enter += (s, e) => pnlPasswordContainer.BackColor = Color.FromArgb(248, 248, 255);
            txtPasswd.Leave += (s, e) => pnlPasswordContainer.BackColor = Color.White;

            // Efecto hover en botón toggle password
            btnTogglePassword.MouseEnter += (s, e) => btnTogglePassword.BackColor = Color.FromArgb(245, 245, 245);
            btnTogglePassword.MouseLeave += (s, e) => btnTogglePassword.BackColor = Color.White;
        }

        private void PintarBordeInput(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            // Dibuja un borde de 2px gris claro alrededor del panel
            ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle,
                Color.FromArgb(220, 220, 220), 2, ButtonBorderStyle.Solid,
                Color.FromArgb(220, 220, 220), 2, ButtonBorderStyle.Solid,
                Color.FromArgb(220, 220, 220), 2, ButtonBorderStyle.Solid,
                Color.FromArgb(220, 220, 220), 2, ButtonBorderStyle.Solid);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Establecer foco inicial
            txtUser.Focus();
            // Establece el ancho del panel izquierdo a la mitad del ancho del formulario
            pnlLeftBranding.Width = this.Width / 2;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                MostrarError("Por favor ingresa tu usuario", "Campo Requerido");
                txtUser.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPasswd.Text))
            {
                MostrarError("Por favor ingresa tu contraseña", "Campo Requerido");
                txtPasswd.Focus();
                return;
            }

            // Deshabilitar botón mientras se valida
            btnLogin.Enabled = false;
            btnLogin.Text = "VALIDANDO...";
            btnLogin.BackColor = Color.FromArgb(111, 207, 151);

            // Usar un Timer para simular proceso asíncrono y dar feedback visual
            Timer validationTimer = new Timer { Interval = 800 };
            validationTimer.Tick += (s, ev) =>
            {
                validationTimer.Stop();
                RealizarLogin();
            };
            validationTimer.Start();
        }

        private void RealizarLogin()
        {
            try
            {
                CN_Usuario objNegocio = new CN_Usuario();
                Usuario usuarioLogueado = objNegocio.Login(txtUser.Text.Trim(), txtPasswd.Text.Trim());

                if (usuarioLogueado != null)
                {
                    // Verificar si el usuario está activo
                    if (!usuarioLogueado.Activo)
                    {
                        MostrarError("Tu cuenta está inactiva.\nContacta al administrador del sistema.",
                            "Usuario Inactivo");
                        RestaurarBotonLogin();
                        return;
                    }

                    // Login exitoso - Mostrar mensaje de bienvenida
                    string nombreCompleto = $"{usuarioLogueado.Nombre} {usuarioLogueado.Apellido}";

                    // Obtener nombre del rol
                    string rol = usuarioLogueado.Rol?.RolNombre ??
                                 (usuarioLogueado.IdRol == 1 ? "Administrador" :
                                  usuarioLogueado.IdRol == 2 ? "Cajero" : "Usuario");

                    MostrarExito($"¡Bienvenido de nuevo!\n\n" +
                        $"Usuario: {nombreCompleto}\n" +
                        $"Rol: {rol}\n" +
                        $"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}");

                    // Ocultar el formulario de login
                    this.Hide();

                    // Redirigir según el rol del usuario
                    if (usuarioLogueado.IdRol == 1) // Administrador
                    {
                        Administrador frmAdmin = new Administrador(usuarioLogueado);
                        frmAdmin.FormClosed += (s, args) => MostrarLoginNuevamente();
                        frmAdmin.ShowDialog();
                    }
                    else if (usuarioLogueado.IdRol == 2) // Cajero
                    {
                        Cajero frmCajero = new Cajero(usuarioLogueado);
                        frmCajero.FormClosed += (s, args) => MostrarLoginNuevamente();
                        frmCajero.ShowDialog();
                    }
                    else
                    {
                        MostrarError("Rol no reconocido en el sistema.", "Error de Rol");
                        MostrarLoginNuevamente();
                    }
                }
                else
                {
                    // Credenciales incorrectas
                    MostrarError("Usuario o contraseña incorrectos.\nPor favor verifica tus datos.",
                        "Error de Autenticación");
                    txtPasswd.Clear();
                    txtPasswd.Focus();
                    RestaurarBotonLogin();
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al intentar conectar con el sistema:\n{ex.Message}",
                    "Error de Conexión");
                RestaurarBotonLogin();
            }
        }

        private void MostrarLoginNuevamente()
        {
            // Limpiar campos y mostrar el login de nuevo
            LimpiarCampos();
            RestaurarBotonLogin();
            this.Show();
        }

        private void RestaurarBotonLogin()
        {
            btnLogin.Text = "INICIAR SESIÓN";
            btnLogin.BackColor = Color.FromArgb(138, 99, 210);
            btnLogin.Enabled = true;
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            // Alternar entre mostrar y ocultar contraseña
            txtPasswd.UseSystemPasswordChar = !txtPasswd.UseSystemPasswordChar;
            btnTogglePassword.Text = txtPasswd.UseSystemPasswordChar ? "👁️" : "👁️‍🗨️";
        }

        private void LimpiarCampos()
        {
            txtUser.Clear();
            txtPasswd.Clear();
            txtUser.Focus();
        }

        private void MostrarError(string mensaje, string titulo)
        {
            MessageBox.Show(mensaje, titulo,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void MostrarExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Acceso Concedido",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            // Presionar Enter para pasar al siguiente campo
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtPasswd.Focus();
            }
        }

        private void txtPasswd_KeyDown(object sender, KeyEventArgs e)
        {
            // Presionar Enter para hacer login
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLogin_Click(sender, e);
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Confirmar si desea salir
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro que deseas salir del sistema?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }

        #region Métodos para hacer el formulario arrastrable (sin barra de título)

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

    }
}