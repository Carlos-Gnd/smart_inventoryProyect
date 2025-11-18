using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string RolNombre { get; set; }

        // Constructor vacío
        public Rol() { }

        // Constructor con parámetros
        public Rol(int idRol, string rolNombre)
        {
            IdRol = idRol;
            RolNombre = rolNombre;
        }
    }
}
