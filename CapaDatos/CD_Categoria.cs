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
    public class CD_Categoria
    {
        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = "SELECT IdCategoria, Nombre, Descripcion FROM Categorias";

                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString()
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar categorías: " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return lista;
        }

        public int Registrar(Categoria obj, out string mensaje)
        {
            int idGenerado = 0;
            mensaje = string.Empty;
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = @"INSERT INTO Categorias (Nombre, Descripcion)
                                VALUES (@Nombre, @Descripcion);
                                SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);

                idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                mensaje = "Categoría registrada correctamente";
            }
            catch (Exception ex)
            {
                idGenerado = 0;
                mensaje = "Error al registrar categoría: " + ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return idGenerado;
        }

        public bool Editar(Categoria obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = @"UPDATE Categorias SET 
                                Nombre = @Nombre, 
                                Descripcion = @Descripcion
                                WHERE IdCategoria = @IdCategoria";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("@IdCategoria", obj.IdCategoria);

                respuesta = cmd.ExecuteNonQuery() > 0;
                mensaje = respuesta ? "Categoría editada correctamente" : "No se pudo editar la categoría";
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = "Error al editar categoría: " + ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return respuesta;
        }

        public bool Eliminar(int idCategoria, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = "DELETE FROM Categorias WHERE IdCategoria = @IdCategoria";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);

                respuesta = cmd.ExecuteNonQuery() > 0;
                mensaje = respuesta ? "Categoría eliminada correctamente" : "No se pudo eliminar la categoría";
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = "Error al eliminar categoría: " + ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return respuesta;
        }
    }
}