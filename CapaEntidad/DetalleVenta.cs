using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetalleVenta
    {
        public int IdDetalle { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }

        // Propiedades de navegación
        public Venta Venta { get; set; }
        public Producto Producto { get; set; }

        // Constructor vacío
        public DetalleVenta() { }

        // Constructor con parámetros
        public DetalleVenta(int idDetalle, int idVenta, int idProducto, int cantidad,
                           decimal precioUnitario, decimal subtotal)
        {
            IdDetalle = idDetalle;
            IdVenta = idVenta;
            IdProducto = idProducto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            Subtotal = subtotal;
        }
    }
}
