using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objCapaDato = new CD_Usuario();

        public List<Usuario> Listar()
        {
            return objCapaDato.Listar();
        }

        public Usuario Login(string usuario, string clave)
        {
            // Convertir la clave a hash antes de validar
            string claveHash = ConvertirSHA256(clave);
            return objCapaDato.Login(usuario, claveHash);
        }

        public int Registrar(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validaciones
            if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje = "El nombre del usuario es obligatorio";
                return 0;
            }

            if (string.IsNullOrWhiteSpace(obj.Apellido))
            {
                mensaje = "El apellido del usuario es obligatorio";
                return 0;
            }

            if (string.IsNullOrWhiteSpace(obj.UsuarioNombre))
            {
                mensaje = "El nombre de usuario es obligatorio";
                return 0;
            }

            if (string.IsNullOrWhiteSpace(obj.ClaveHash))
            {
                mensaje = "La contraseña es obligatoria";
                return 0;
            }

            if (obj.ClaveHash.Length < 6)
            {
                mensaje = "La contraseña debe tener al menos 6 caracteres";
                return 0;
            }

            if (obj.IdRol == 0)
            {
                mensaje = "Debe seleccionar un rol";
                return 0;
            }

            // Convertir la contraseña a hash
            obj.ClaveHash = ConvertirSHA256(obj.ClaveHash);
            obj.FechaRegistro = DateTime.Now;

            return objCapaDato.Registrar(obj, out mensaje);
        }

        public bool Editar(Usuario obj, out string mensaje)
        {
            mensaje = string.Empty;

            // Validaciones
            if (string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje = "El nombre del usuario es obligatorio";
                return false;
            }

            if (string.IsNullOrWhiteSpace(obj.Apellido))
            {
                mensaje = "El apellido del usuario es obligatorio";
                return false;
            }

            if (string.IsNullOrWhiteSpace(obj.UsuarioNombre))
            {
                mensaje = "El nombre de usuario es obligatorio";
                return false;
            }

            if (obj.IdRol == 0)
            {
                mensaje = "Debe seleccionar un rol";
                return false;
            }

            return objCapaDato.Editar(obj, out mensaje);
        }

        public bool CambiarClave(int idUsuario, string claveActual, string nuevaClave, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrWhiteSpace(nuevaClave))
            {
                mensaje = "La nueva contraseña es obligatoria";
                return false;
            }

            if (nuevaClave.Length < 6)
            {
                mensaje = "La contraseña debe tener al menos 6 caracteres";
                return false;
            }

            string nuevaClaveHash = ConvertirSHA256(nuevaClave);
            return objCapaDato.CambiarClave(idUsuario, nuevaClaveHash, out mensaje);
        }

        public bool Eliminar(int idUsuario, out string mensaje)
        {
            return objCapaDato.Eliminar(idUsuario, out mensaje);
        }

        // Método para convertir texto a SHA256
        public string ConvertirSHA256(string texto)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

