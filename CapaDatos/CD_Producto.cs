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
    public class CD_Producto
    {
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = @"SELECT p.IdProducto, p.Nombre, p.IdCategoria, c.Nombre as CategoriaNombre, 
                                p.Precio, p.Stock, p.Estado, p.Descripcion, p.StockMinimo, 
                                p.FechaRegistro, p.EsProductoFinal
                                FROM Productos p
                                INNER JOIN Categorias c ON p.IdCategoria = c.IdCategoria";

                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Producto()
                    {
                        IdProducto = Convert.ToInt32(reader["IdProducto"]),
                        Nombre = reader["Nombre"].ToString(),
                        IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                        Categoria = new Categoria()
                        {
                            IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                            Nombre = reader["CategoriaNombre"].ToString()
                        },
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        Stock = Convert.ToInt32(reader["Stock"]),
                        Estado = Convert.ToBoolean(reader["Estado"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        StockMinimo = Convert.ToInt32(reader["StockMinimo"]),
                        FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                        EsProductoFinal = Convert.ToBoolean(reader["EsProductoFinal"])
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar productos: " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return lista;
        }

        public int Registrar(Producto obj, out string mensaje)
        {
            int idGenerado = 0;
            mensaje = string.Empty;
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = @"INSERT INTO Productos (Nombre, IdCategoria, Precio, Stock, Estado, 
                                Descripcion, StockMinimo, FechaRegistro, EsProductoFinal)
                                VALUES (@Nombre, @IdCategoria, @Precio, @Stock, @Estado, 
                                @Descripcion, @StockMinimo, @FechaRegistro, @EsProductoFinal);
                                SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@IdCategoria", obj.IdCategoria);
                cmd.Parameters.AddWithValue("@Precio", obj.Precio);
                cmd.Parameters.AddWithValue("@Stock", obj.Stock);
                cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("@StockMinimo", obj.StockMinimo);
                cmd.Parameters.AddWithValue("@FechaRegistro", obj.FechaRegistro);
                cmd.Parameters.AddWithValue("@EsProductoFinal", obj.EsProductoFinal);

                idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                mensaje = "Producto registrado correctamente";
            }
            catch (Exception ex)
            {
                idGenerado = 0;
                mensaje = "Error al registrar producto: " + ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return idGenerado;
        }

        public bool Editar(Producto obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = @"UPDATE Productos SET 
                                Nombre = @Nombre,
                                IdCategoria = @IdCategoria,
                                Precio = @Precio,
                                Stock = @Stock,
                                Estado = @Estado,
                                Descripcion = @Descripcion,
                                StockMinimo = @StockMinimo,
                                EsProductoFinal = @EsProductoFinal
                                WHERE IdProducto = @IdProducto";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@IdCategoria", obj.IdCategoria);
                cmd.Parameters.AddWithValue("@Precio", obj.Precio);
                cmd.Parameters.AddWithValue("@Stock", obj.Stock);
                cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("@StockMinimo", obj.StockMinimo);
                cmd.Parameters.AddWithValue("@EsProductoFinal", obj.EsProductoFinal);
                cmd.Parameters.AddWithValue("@IdProducto", obj.IdProducto);

                respuesta = cmd.ExecuteNonQuery() > 0;
                mensaje = respuesta ? "Producto editado correctamente" : "No se pudo editar el producto";
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = "Error al editar producto: " + ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return respuesta;
        }

        public bool Eliminar(int idProducto, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = "UPDATE Productos SET Estado = 0 WHERE IdProducto = @IdProducto";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                respuesta = cmd.ExecuteNonQuery() > 0;
                mensaje = respuesta ? "Producto eliminado correctamente" : "No se pudo eliminar el producto";
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = "Error al eliminar producto: " + ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return respuesta;
        }

        // Actualizar stock del producto
        public bool ActualizarStock(int idProducto, int cantidad, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = "UPDATE Productos SET Stock = Stock - @Cantidad WHERE IdProducto = @IdProducto";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);

                respuesta = cmd.ExecuteNonQuery() > 0;
                mensaje = respuesta ? "Stock actualizado correctamente" : "No se pudo actualizar el stock";
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = "Error al actualizar stock: " + ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return respuesta;
        }
    }
}

