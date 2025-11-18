using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        private CD_Categoria objCapaDato = new CD_Categoria();

        public List<Categoria> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Categoria obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validaciones
            if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje = "El nombre de la categoría es obligatorio";
                return 0;
            }

            if (obj.Nombre.Length > 50)
            {
                mensaje = "El nombre de la categoría no puede exceder 50 caracteres";
                return 0;
            }

            return objCapaDato.Registrar(obj, out mensaje);
        }

        public bool Editar(Categoria obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validaciones
            if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje = "El nombre de la categoría es obligatorio";
                return false;
            }

            if (obj.Nombre.Length > 50)
            {
                mensaje = "El nombre de la categoría no puede exceder 50 caracteres";
                return false;
            }

            return objCapaDato.Editar(obj, out mensaje);
        }

        public bool Eliminar(int idCategoria, out string mensaje)
        {
            return objCapaDato.Eliminar(idCategoria, out mensaje);
        }
    }
}