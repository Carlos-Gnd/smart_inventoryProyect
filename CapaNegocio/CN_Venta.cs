using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Venta
    {
        private CD_Venta objCapaDato = new CD_Venta();

        public int RegistrarVenta(Venta venta, out string mensaje)
        {
            mensaje = string.Empty;

            // Validaciones
            if (venta.IdUsuario == 0)
            {
                mensaje = "Debe especificar el usuario";
                return 0;
            }

            if (venta.DetallesVenta == null || venta.DetallesVenta.Count == 0)
            {
                mensaje = "Debe agregar al menos un producto a la venta";
                return 0;
            }

            if (venta.Total <= 0)
            {
                mensaje = "El total de la venta debe ser mayor a 0";
                return 0;
            }

            if (string.IsNullOrWhiteSpace(venta.MetodoPago))
            {
                mensaje = "Debe seleccionar un método de pago";
                return 0;
            }

            // Verificar stock de cada producto
            foreach (DetalleVenta detalle in venta.DetallesVenta)
            {
                bool stockDisponible = objCapaDato.VerificarStock(detalle.IdProducto, detalle.Cantidad, out string mensajeStock);
                if (!stockDisponible)
                {
                    mensaje = mensajeStock;
                    return 0;
                }
            }

            venta.Fecha = DateTime.Now;
            venta.FechaVenta = DateTime.Now;
            venta.Estado = true;

            return objCapaDato.RegistrarVenta(venta, out mensaje);
        }

        public List<Venta> Listar()
        {
            return objCapaDato.Listar();
        }

        public List<Venta> ListarPorUsuario(int idUsuario)
        {
            return objCapaDato.ListarPorUsuario(idUsuario);
        }

        public List<DetalleVenta> ObtenerDetalleVenta(int idVenta)
        {
            return objCapaDato.ObtenerDetalleVenta(idVenta);
        }

        public List<Venta> ListarPorFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return objCapaDato.ListarPorFechas(fechaInicio, fechaFin);
        }

        public bool VerificarStock(int idProducto, int cantidad, out string mensaje)
        {
            return objCapaDato.VerificarStock(idProducto, cantidad, out mensaje);
        }
    }
}
