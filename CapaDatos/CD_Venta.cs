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
    public class CD_Venta
    {
        // Registrar venta con transacción
        public int RegistrarVenta(Venta venta, out string mensaje)
        {
            int idVentaGenerado = 0;
            mensaje = string.Empty;
            SqlConnection conexion = null;
            SqlTransaction transaccion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                transaccion = conexion.BeginTransaction();

                // Insertar venta
                string queryVenta = @"INSERT INTO Ventas (Fecha, IdUsuario, Total, MetodoPago, Comentario, Estado, FechaVenta)
                                     VALUES (@Fecha, @IdUsuario, @Total, @MetodoPago, @Comentario, @Estado, @FechaVenta);
                                     SELECT SCOPE_IDENTITY();";

                SqlCommand cmdVenta = new SqlCommand(queryVenta, conexion, transaccion);
                cmdVenta.Parameters.AddWithValue("@Fecha", venta.Fecha);
                cmdVenta.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                cmdVenta.Parameters.AddWithValue("@Total", venta.Total);
                cmdVenta.Parameters.AddWithValue("@MetodoPago", venta.MetodoPago);
                cmdVenta.Parameters.AddWithValue("@Comentario", venta.Comentario ?? string.Empty);
                cmdVenta.Parameters.AddWithValue("@Estado", venta.Estado);
                cmdVenta.Parameters.AddWithValue("@FechaVenta", venta.FechaVenta);

                idVentaGenerado = Convert.ToInt32(cmdVenta.ExecuteScalar());

                // Insertar detalle de venta y actualizar stock
                foreach (DetalleVenta detalle in venta.DetallesVenta)
                {
                    // Insertar detalle
                    string queryDetalle = @"INSERT INTO DetalleVenta (IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal)
                                           VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioUnitario, @Subtotal)";

                    SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion, transaccion);
                    cmdDetalle.Parameters.AddWithValue("@IdVenta", idVentaGenerado);
                    cmdDetalle.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
                    cmdDetalle.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                    cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);
                    cmdDetalle.Parameters.AddWithValue("@Subtotal", detalle.Subtotal);
                    cmdDetalle.ExecuteNonQuery();

                    // Actualizar stock
                    string queryStock = "UPDATE Productos SET Stock = Stock - @Cantidad WHERE IdProducto = @IdProducto";
                    SqlCommand cmdStock = new SqlCommand(queryStock, conexion, transaccion);
                    cmdStock.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                    cmdStock.Parameters.AddWithValue("@IdProducto", detalle.IdProducto);
                    cmdStock.ExecuteNonQuery();
                }

                transaccion.Commit();
                mensaje = "Venta registrada correctamente";
            }
            catch (Exception ex)
            {
                if (transaccion != null)
                    transaccion.Rollback();

                idVentaGenerado = 0;
                mensaje = "Error al registrar venta: " + ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return idVentaGenerado;
        }

        // Listar todas las ventas
        public List<Venta> Listar()
        {
            List<Venta> lista = new List<Venta>();
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = @"
                    SELECT 
                        v.IdVenta, v.Fecha, v.IdUsuario, 
                        u.Nombre + ' ' + u.Apellido as NombreCompleto,
                        v.Total, v.MetodoPago, v.Comentario, v.Estado, v.FechaVenta,
                        (SELECT ISNULL(SUM(dv.Cantidad), 0) FROM DetalleVenta dv WHERE dv.IdVenta = v.IdVenta) AS CantidadTotalProductos
                    FROM Ventas v
                    INNER JOIN Usuarios u ON v.IdUsuario = u.IdUsuario
                    ORDER BY v.FechaVenta DESC";

                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Venta nuevaVenta = new Venta() // Usamos una variable nueva para claridad
                    {
                        IdVenta = Convert.ToInt32(reader["IdVenta"]),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Usuario = new Usuario()
                        {
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            Nombre = reader["NombreCompleto"].ToString()
                        },
                        Total = Convert.ToDecimal(reader["Total"]),
                        MetodoPago = reader["MetodoPago"].ToString(),
                        Comentario = reader["Comentario"].ToString(),
                        Estado = Convert.ToBoolean(reader["Estado"]),
                        FechaVenta = Convert.ToDateTime(reader["FechaVenta"]),
                        CantidadTotalProductos = Convert.ToInt32(reader["CantidadTotalProductos"])
                    };
                    lista.Add(nuevaVenta);
                }
                reader.Close();
            }
            catch (Exception)
            {
                // ...
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }
            return lista;
        }

        // Listar ventas por usuario
        public List<Venta> ListarPorUsuario(int idUsuario)
        {
            List<Venta> lista = new List<Venta>();
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();

                // CONSULTA SQL (INCLUYENDO el cálculo de productos)
                string query = @"
                                SELECT 
                                    v.IdVenta, 
                                    v.Fecha, 
                                    v.IdUsuario, 
                                    u.Nombre + ' ' + u.Apellido as NombreCompleto,
                                    v.Total, 
                                    v.MetodoPago, 
                                    v.Comentario, 
                                    v.Estado, 
                                    v.FechaVenta,
                                    (SELECT ISNULL(SUM(dv.Cantidad), 0) FROM DetalleVenta dv WHERE dv.IdVenta = v.IdVenta) AS CantidadTotalProductos
                                FROM Ventas v
                                INNER JOIN Usuarios u ON v.IdUsuario = u.IdUsuario
                                WHERE v.IdUsuario = @IdUsuario -- Asegura que solo trae las del usuario
                                ORDER BY v.FechaVenta DESC";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Venta venta = new Venta()
                    {
                        IdVenta = Convert.ToInt32(reader["IdVenta"]),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Usuario = new Usuario()
                        {
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            Nombre = reader["NombreCompleto"].ToString()
                        },
                        Total = Convert.ToDecimal(reader["Total"]),
                        MetodoPago = reader["MetodoPago"].ToString(),
                        Comentario = reader["Comentario"].ToString(),
                        Estado = reader.IsDBNull(reader.GetOrdinal("Estado")) ? false : reader.GetBoolean(reader.GetOrdinal("Estado")),
                        FechaVenta = Convert.ToDateTime(reader["FechaVenta"]),
                        // Mapea la columna calculada a la propiedad de la entidad
                        CantidadTotalProductos = Convert.ToInt32(reader["CantidadTotalProductos"])
                    };
                    lista.Add(venta);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar ventas por usuario: " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return lista;
        }

        // Obtener detalle de una venta específica
        public List<DetalleVenta> ObtenerDetalleVenta(int idVenta)
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = @"SELECT dv.IdDetalle, dv.IdVenta, dv.IdProducto, 
                                p.Nombre as ProductoNombre, dv.Cantidad, dv.PrecioUnitario, dv.Subtotal
                                FROM DetalleVenta dv
                                INNER JOIN Productos p ON dv.IdProducto = p.IdProducto
                                WHERE dv.IdVenta = @IdVenta";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdVenta", idVenta);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new DetalleVenta()
                    {
                        IdDetalle = Convert.ToInt32(reader["IdDetalle"]),
                        IdVenta = Convert.ToInt32(reader["IdVenta"]),
                        IdProducto = Convert.ToInt32(reader["IdProducto"]),
                        Producto = new Producto()
                        {
                            IdProducto = Convert.ToInt32(reader["IdProducto"]),
                            Nombre = reader["ProductoNombre"].ToString()
                        },
                        Cantidad = Convert.ToInt32(reader["Cantidad"]),
                        PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]),
                        Subtotal = Convert.ToDecimal(reader["Subtotal"])
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener detalle de venta: " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return lista;
        }

        // Listar ventas por rango de fechas
        public List<Venta> ListarPorFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Venta> lista = new List<Venta>();
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = @"
            SELECT 
                v.IdVenta, v.Fecha, v.IdUsuario, 
                u.Nombre + ' ' + u.Apellido as NombreCompleto,
                v.Total, v.MetodoPago, v.Comentario, v.Estado, v.FechaVenta,
                (SELECT ISNULL(SUM(dv.Cantidad), 0) FROM DetalleVenta dv WHERE dv.IdVenta = v.IdVenta) AS CantidadTotalProductos
            FROM Ventas v
            INNER JOIN Usuarios u ON v.IdUsuario = u.IdUsuario
            WHERE v.FechaVenta BETWEEN @FechaInicio AND @FechaFin -- ¡Este filtro es clave!
            ORDER BY v.FechaVenta DESC";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio.Date);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin.Date);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Venta nuevaVenta = new Venta() // Usamos una variable nueva para claridad
                    {
                        IdVenta = Convert.ToInt32(reader["IdVenta"]),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Usuario = new Usuario()
                        {
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            Nombre = reader["NombreCompleto"].ToString()
                        },
                        Total = Convert.ToDecimal(reader["Total"]),
                        MetodoPago = reader["MetodoPago"].ToString(),
                        Comentario = reader["Comentario"].ToString(),
                        Estado = Convert.ToBoolean(reader["Estado"]),
                        FechaVenta = Convert.ToDateTime(reader["FechaVenta"]),
                        CantidadTotalProductos = Convert.ToInt32(reader["CantidadTotalProductos"])
                    };
                    lista.Add(nuevaVenta);
                }
                reader.Close();
            }
            catch (Exception)
            {
                // ...
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }
            return lista;
        }

        // Verificar disponibilidad de stock antes de vender
        public bool VerificarStock(int idProducto, int cantidad, out string mensaje)
        {
            bool disponible = false;
            mensaje = string.Empty;
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = "SELECT Stock, Nombre FROM Productos WHERE IdProducto = @IdProducto";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int stockActual = Convert.ToInt32(reader["Stock"]);
                    string nombreProducto = reader["Nombre"].ToString();

                    if (stockActual >= cantidad)
                    {
                        disponible = true;
                        mensaje = "Stock disponible";
                    }
                    else
                    {
                        disponible = false;
                        mensaje = $"Stock insuficiente para {nombreProducto}. Disponible: {stockActual}";
                    }
                }
                else
                {
                    mensaje = "Producto no encontrado";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                disponible = false;
                mensaje = "Error al verificar stock: " + ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return disponible;
        }
    }
}