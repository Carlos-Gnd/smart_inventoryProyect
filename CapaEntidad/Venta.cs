using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int CantidadTotalProductos { get; set; } 
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public decimal Total { get; set; }
        public string MetodoPago { get; set; }
        public string Comentario { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaVenta { get; set; }

        // Propiedades de navegación
        public Usuario Usuario { get; set; }
        public List<DetalleVenta> DetallesVenta { get; set; }

        // Constructor vacío
        public Venta()
        {
            DetallesVenta = new List<DetalleVenta>();
        }

        // Constructor con parámetros principales
        public Venta(int idVenta, DateTime fecha, int idUsuario, decimal total,
                     string metodoPago, string comentario, bool estado, DateTime fechaVenta)
        {
            IdVenta = idVenta;
            Fecha = fecha;
            IdUsuario = idUsuario;
            Total = total;
            MetodoPago = metodoPago;
            Comentario = comentario;
            Estado = estado;
            FechaVenta = fechaVenta;
            DetallesVenta = new List<DetalleVenta>();
        }
    }
}
