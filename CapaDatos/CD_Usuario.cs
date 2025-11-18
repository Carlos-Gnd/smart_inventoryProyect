using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Usuario
    {
        // Listar todos los usuarios
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = @"SELECT u.IdUsuario, u.Nombre, u.Apellido, u.Usuario, u.ClaveHash, 
                                u.IdRol, r.Rol as RolNombre, u.Activo, u.FechaRegistro 
                                FROM Usuarios u
                                INNER JOIN Roles r ON u.IdRol = r.IdRol";

                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        UsuarioNombre = reader["Usuario"].ToString(),
                        ClaveHash = reader["ClaveHash"].ToString(),
                        IdRol = Convert.ToInt32(reader["IdRol"]),
                        Rol = new Rol()
                        {
                            IdRol = Convert.ToInt32(reader["IdRol"]),
                            RolNombre = reader["RolNombre"].ToString()
                        },
                        Activo = Convert.ToBoolean(reader["Activo"]),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar usuarios: " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return lista;
        }

        // Login - Validar usuario
        public Usuario Login(string usuario, string claveHash)
        {
            Usuario obj = null;
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = @"SELECT u.IdUsuario, u.Nombre, u.Apellido, u.Usuario, u.ClaveHash, 
                                u.IdRol, r.Rol as RolNombre, u.Activo, u.FechaRegistro 
                                FROM Usuarios u
                                INNER JOIN Roles r ON u.IdRol = r.IdRol
                                WHERE u.Usuario = @usuario AND u.ClaveHash = @claveHash AND u.Activo = 1";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@claveHash", claveHash);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    obj = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellido = reader["Apellido"].ToString(),
                        UsuarioNombre = reader["Usuario"].ToString(),
                        ClaveHash = reader["ClaveHash"].ToString(),
                        IdRol = Convert.ToInt32(reader["IdRol"]),
                        Rol = new Rol()
                        {
                            IdRol = Convert.ToInt32(reader["IdRol"]),
                            RolNombre = reader["RolNombre"].ToString()
                        },
                        Activo = Convert.ToBoolean(reader["Activo"]),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar usuario: " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return obj;
        }

        // Registrar usuario
        public int Registrar(Usuario obj, out string mensaje)
        {
            int idGenerado = 0;
            mensaje = string.Empty;
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = @"INSERT INTO Usuarios (Nombre, Apellido, Usuario, ClaveHash, IdRol, Activo, FechaRegistro)
                                VALUES (@Nombre, @Apellido, @Usuario, @ClaveHash, @IdRol, @Activo, @FechaRegistro);
                                SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", obj.Apellido);
                cmd.Parameters.AddWithValue("@Usuario", obj.UsuarioNombre);
                cmd.Parameters.AddWithValue("@ClaveHash", obj.ClaveHash);
                cmd.Parameters.AddWithValue("@IdRol", obj.IdRol);
                cmd.Parameters.AddWithValue("@Activo", obj.Activo);
                cmd.Parameters.AddWithValue("@FechaRegistro", obj.FechaRegistro);

                idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                mensaje = "Usuario registrado correctamente";
            }
            catch (Exception ex)
            {
                idGenerado = 0;
                mensaje = "Error al registrar usuario: " + ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return idGenerado;
        }

        // Editar usuario
        public bool Editar(Usuario obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = @"UPDATE Usuarios SET 
                                Nombre = @Nombre, 
                                Apellido = @Apellido, 
                                Usuario = @Usuario,
                                IdRol = @IdRol,
                                Activo = @Activo
                                WHERE IdUsuario = @IdUsuario";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", obj.Apellido);
                cmd.Parameters.AddWithValue("@Usuario", obj.UsuarioNombre);
                cmd.Parameters.AddWithValue("@IdRol", obj.IdRol);
                cmd.Parameters.AddWithValue("@Activo", obj.Activo);
                cmd.Parameters.AddWithValue("@IdUsuario", obj.IdUsuario);

                respuesta = cmd.ExecuteNonQuery() > 0;
                mensaje = respuesta ? "Usuario editado correctamente" : "No se pudo editar el usuario";
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = "Error al editar usuario: " + ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return respuesta;
        }

        // Cambiar contraseña
        public bool CambiarClave(int idUsuario, string nuevaClaveHash, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = "UPDATE Usuarios SET ClaveHash = @ClaveHash WHERE IdUsuario = @IdUsuario";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@ClaveHash", nuevaClaveHash);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                respuesta = cmd.ExecuteNonQuery() > 0;
                mensaje = respuesta ? "Contraseña cambiada correctamente" : "No se pudo cambiar la contraseña";
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = "Error al cambiar contraseña: " + ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return respuesta;
        }

        // Eliminar usuario (cambiar estado a inactivo)
        public bool Eliminar(int idUsuario, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = "UPDATE Usuarios SET Activo = 0 WHERE IdUsuario = @IdUsuario";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                respuesta = cmd.ExecuteNonQuery() > 0;
                mensaje = respuesta ? "Usuario eliminado correctamente" : "No se pudo eliminar el usuario";
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = "Error al eliminar usuario: " + ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return respuesta;
        }
    }
}