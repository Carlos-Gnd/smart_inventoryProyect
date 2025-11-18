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

namespace smart_inventory
{
    public partial class Administrador : Form
    {
        private Usuario usuarioActual;

        // Constructor que recibe el usuario logueado
        public Administrador(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void Administrador_Load(object sender, EventArgs e)
        {
            // Mostrar nombre del usuario logueado en el título
            if (usuarioActual != null)
            {
                this.Text = $"Panel de Administrador - {usuarioActual.Nombre} {usuarioActual.Apellido}";
                lblUsuarioActual.Text = $"Bienvenido: {usuarioActual.Nombre} {usuarioActual.Apellido}";
            }

            // Configurar efectos hover en los PictureBox
            ConfigurarHoverPictureBox();
        }

        private void ConfigurarHoverPictureBox()
        {
            // Lista de todos los PictureBox del menú
            PictureBox[] menuItems = new PictureBox[]
            {
                picUsuarios,
                picCategorias,
                picProductos,
                picVentas,
                picInformes,
                picVentasPropias,
                picGenerarReportes
            };

            foreach (PictureBox pic in menuItems)
            {
                if (pic != null)
                {
                    // Cambia el cursor al pasar el mouse
                    pic.Cursor = Cursors.Hand;

                    // Agrega eventos de hover
                    pic.MouseEnter += PictureBox_MouseEnter;
                    pic.MouseLeave += PictureBox_MouseLeave;
                }
            }
        }

        // Efecto al pasar el mouse sobre el PictureBox
        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic != null)
            {
                // Crear efecto de resaltado
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.BackColor = Color.FromArgb(230, 230, 250); 
            }
        }

        // Efecto al salir el mouse del PictureBox
        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic != null)
            {
                pic.BorderStyle = BorderStyle.None;
                pic.BackColor = Color.Transparent;
            }
        }

        // EVENTOS CLICK DEL MENU

        // USUARIOS
        private void picUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Usuarios());
        }

        // CATEGORÍAS
        private void picCategorias_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Categorias());
        }

        // PRODUCTOS
        private void picProductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Productos());
        }

        // VENTAS
        private void picVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Ventas());
        }

        // INFORMES
        private void picInformes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Informes());
        }

        // VENTAS PROPIAS
        private void picVentasPropias_Click(object sender, EventArgs e)
        {
            VentasPropias frmVentasPropias = new VentasPropias(usuarioActual);
            AbrirFormulario(frmVentasPropias);
        }

        // GENERAR REPORTES
        private void picGenerarReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new GenerarReportes());
        }

        // MÉTODO PARA ABRIR FORMULARIOS
        private void AbrirFormulario(Form formulario)
        {
            try
            {
                // Ocultar el formulario actual
                this.Hide();

                // Mostrar el nuevo formulario como diálogo
                formulario.ShowDialog();

                // Volver a mostrar el menú cuando se cierre el formulario
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir formulario: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        // BOTÓN CERRAR SESIÓN
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea cerrar sesión?",
                "Confirmar Cierre de Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                this.Close(); // Esto regresará al Login
            }
        }

        // EVENTO AL CERRAR EL FORMULARIO
        private void Administrador_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Confirmación al cerrar
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea salir del panel de administrador?\nEsto cerrará su sesión.",
                    "Confirmar Salida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.No)
                {
                    e.Cancel = true; // Cancelar el cierre
                }
            }
        }

        // TIMER PARA FECHA/HORA
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFechaHora.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy - HH:mm:ss");
        }
    }
}   