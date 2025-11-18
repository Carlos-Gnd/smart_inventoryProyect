using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UsuarioNombre { get; set; }
        public string ClaveHash { get; set; }
        public int IdRol { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }

        // Propiedad de navegación
        public Rol Rol { get; set; }

        // Constructor vacío
        public Usuario() { }

        // Constructor con parámetros principales
        public Usuario(int idUsuario, string nombre, string apellido, string usuarioNombre,
                       string claveHash, int idRol, bool activo, DateTime fechaRegistro)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Apellido = apellido;
            UsuarioNombre = usuarioNombre;
            ClaveHash = claveHash;
            IdRol = idRol;
            Activo = activo;
            FechaRegistro = fechaRegistro;
        }
    }
}
