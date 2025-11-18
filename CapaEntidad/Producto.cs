using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int IdCategoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; }
        public string Descripcion { get; set; }
        public int StockMinimo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool EsProductoFinal { get; set; }

        // Propiedad de navegación
        public Categoria Categoria { get; set; }

        // Constructor vacío
        public Producto() { }

        // Constructor con parámetros principales
        public Producto(int idProducto, string nombre, int idCategoria, decimal precio,
                        int stock, bool estado, string descripcion, int stockMinimo,
                        DateTime fechaRegistro, bool esProductoFinal)
        {
            IdProducto = idProducto;
            Nombre = nombre;
            IdCategoria = idCategoria;
            Precio = precio;
            Stock = stock;
            Estado = estado;
            Descripcion = descripcion;
            StockMinimo = stockMinimo;
            FechaRegistro = fechaRegistro;
            EsProductoFinal = esProductoFinal;
        }
    }
}
