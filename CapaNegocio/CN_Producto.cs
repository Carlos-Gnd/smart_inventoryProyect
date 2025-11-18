using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Producto
    {
        private CD_Producto objCapaDato = new CD_Producto();

        public List<Producto> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validaciones
            if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje = "El nombre del producto es obligatorio";
                return 0;
            }

            if (obj.Nombre.Length > 100)
            {
                mensaje = "El nombre del producto no puede exceder 100 caracteres";
                return 0;
            }

            if (obj.IdCategoria == 0)
            {
                mensaje = "Debe seleccionar una categoría";
                return 0;
            }

            if (obj.Precio <= 0)
            {
                mensaje = "El precio debe ser mayor a 0";
                return 0;
            }

            if (obj.Stock < 0)
            {
                mensaje = "El stock no puede ser negativo";
                return 0;
            }

            if (obj.StockMinimo < 0)
            {
                mensaje = "El stock mínimo no puede ser negativo";
                return 0;
            }

            obj.FechaRegistro = DateTime.Now;

            return objCapaDato.Registrar(obj, out mensaje);
        }

        public bool Editar(Producto obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validaciones
            if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje = "El nombre del producto es obligatorio";
                return false;
            }

            if (obj.Nombre.Length > 100)
            {
                mensaje = "El nombre del producto no puede exceder 100 caracteres";
                return false;
            }

            if (obj.IdCategoria == 0)
            {
                mensaje = "Debe seleccionar una categoría";
                return false;
            }

            if (obj.Precio <= 0)
            {
                mensaje = "El precio debe ser mayor a 0";
                return false;
            }

            if (obj.Stock < 0)
            {
                mensaje = "El stock no puede ser negativo";
                return false;
            }

            if (obj.StockMinimo < 0)
            {
                mensaje = "El stock mínimo no puede ser negativo";
                return false;
            }

            return objCapaDato.Editar(obj, out mensaje);
        }

        public bool Eliminar(int idProducto, out string mensaje)
        {
            return objCapaDato.Eliminar(idProducto, out mensaje);
        }

        public bool ActualizarStock(int idProducto, int cantidad, out string mensaje)
        {
            mensaje = string.Empty;

            if (cantidad <= 0)
            {
                mensaje = "La cantidad debe ser mayor a 0";
                return false;
            }

            return objCapaDato.ActualizarStock(idProducto, cantidad, out mensaje);
        }

        // Verificar si hay stock bajo
        public List<Producto> ObtenerProductosStockBajo()
        {
            List<Producto> todosProductos = objCapaDato.Listar();
            List<Producto> productosStockBajo = new List<Producto>();

            foreach (Producto producto in todosProductos)
            {
                if (producto.Stock <= producto.StockMinimo && producto.Estado)
                {
                    productosStockBajo.Add(producto);
                }
            }

            return productosStockBajo;
        }
    }
}