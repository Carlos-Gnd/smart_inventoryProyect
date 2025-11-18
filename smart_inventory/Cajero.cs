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
    public partial class Cajero : Form
    {
        private Usuario usuarioActual;

        // Constructor que recibe el usuario logueado
        public Cajero(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void Cajero_Load(object sender, EventArgs e)
        {
            // ventana maximizada
            this.WindowState = FormWindowState.Maximized;

            // Mostrar nombre del usuario logueado en el título
            if (usuarioActual != null)
            {
                this.Text = $"Panel de Cajero - {usuarioActual.Nombre} {usuarioActual.Apellido}";

                //Label de bienvenida
                lblUsuarioActual.Text = $"Bienvenido: {usuarioActual.Nombre} {usuarioActual.Apellido}";
            }

            // Configurar efectos hover en los PictureBox
            ConfigurarHoverPictureBox();
        }

        private void ConfigurarHoverPictureBox()
        {
            // Lista de PictureBox del menú (según el Designer, son pictureBox2, pictureBox3, pictureBox4)
            PictureBox[] menuPictureBoxes = new PictureBox[]
            {
                picRegistrarVentas, // Registrar Ventas
                picVentasPropias, // Ventas Propias
                picGenerarReportes  // Generar Reportes
            };

            foreach (PictureBox pic in menuPictureBoxes)
            {
                if (pic != null)
                {
                    // Cambiar cursor al pasar el mouse
                    pic.Cursor = Cursors.Hand;

                    // Agregar eventos de hover
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
                pic.BackColor = Color.FromArgb(230, 230, 250); // Lavanda claro
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

        // EVENTOS CLICK DE LOS PICTUREBOX (Menú)

        // REGISTRAR VENTAS
        private void picRegistrarVentas_Click(object sender, EventArgs e)
        {
            try
            {
                RegistrarVentas frmRegistrarVentas = new RegistrarVentas(usuarioActual);
                AbrirFormulario(frmRegistrarVentas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir Registrar Ventas: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // VENTAS PROPIAS
        private void picVentasPropias_Click(object sender, EventArgs e)
        {
            try
            {
                VentasPropias frmVentasPropias = new VentasPropias(usuarioActual);
                AbrirFormulario(frmVentasPropias);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir Ventas Propias: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // GENERAR REPORTES
        private void picGenerarReportes_Click(object sender, EventArgs e)
        {
            try
            {
                GenerarReportes frmGenerarReportes = new GenerarReportes(usuarioActual);
                AbrirFormulario(frmGenerarReportes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir Generar Reportes: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void Cajero_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Confirmación al cerrar
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea salir del panel de cajero?\nEsto cerrará su sesión.",
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
    }
}