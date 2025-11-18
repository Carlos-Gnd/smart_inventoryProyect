using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Reporte
    {
        // Registrar reporte generado
        public int Registrar(Reporte obj, out string mensaje)
        {
            int idGenerado = 0;
            mensaje = string.Empty;
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = @"INSERT INTO Reportes (IdUsuario, TipoReporte, FechaGeneracion, RutaArchivo)
                                VALUES (@IdUsuario, @TipoReporte, @FechaGeneracion, @RutaArchivo);
                                SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdUsuario", obj.IdUsuario);
                cmd.Parameters.AddWithValue("@TipoReporte", obj.TipoReporte);
                cmd.Parameters.AddWithValue("@FechaGeneracion", obj.FechaGeneracion);
                cmd.Parameters.AddWithValue("@RutaArchivo", obj.RutaArchivo);

                idGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                mensaje = "Reporte registrado correctamente";
            }
            catch (Exception ex)
            {
                idGenerado = 0;
                mensaje = "Error al registrar reporte: " + ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return idGenerado;
        }

        // Listar todos los reportes
        public List<Reporte> Listar()
        {
            List<Reporte> lista = new List<Reporte>();
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = @"SELECT r.IdReporte, r.IdUsuario, 
                                u.Nombre + ' ' + u.Apellido as NombreCompleto,
                                r.TipoReporte, r.FechaGeneracion, r.RutaArchivo
                                FROM Reportes r
                                INNER JOIN Usuarios u ON r.IdUsuario = u.IdUsuario
                                ORDER BY r.FechaGeneracion DESC";

                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Reporte()
                    {
                        IdReporte = Convert.ToInt32(reader["IdReporte"]),
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        Usuario = new Usuario()
                        {
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            Nombre = reader["NombreCompleto"].ToString()
                        },
                        TipoReporte = reader["TipoReporte"].ToString(),
                        FechaGeneracion = Convert.ToDateTime(reader["FechaGeneracion"]),
                        RutaArchivo = reader["RutaArchivo"].ToString()
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar reportes: " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return lista;
        }

        // Obtener datos para reporte de ventas
        public DataTable ObtenerReporteVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = @"SELECT v.IdVenta, v.FechaVenta, 
                                u.Nombre + ' ' + u.Apellido as Cajero,
                                v.MetodoPago, v.Total, v.Estado
                                FROM Ventas v
                                INNER JOIN Usuarios u ON v.IdUsuario = u.IdUsuario
                                WHERE CAST(v.FechaVenta AS DATE) BETWEEN @FechaInicio AND @FechaFin
                                ORDER BY v.FechaVenta DESC";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio.Date);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin.Date);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener reporte de ventas: " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return dt;
        }

        // Obtener datos para reporte de productos
        public DataTable ObtenerReporteProductos()
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = @"SELECT p.IdProducto, p.Nombre, c.Nombre as Categoria,
                                p.Precio, p.Stock, p.StockMinimo, 
                                CASE WHEN p.Stock <= p.StockMinimo THEN 'Stock Bajo' ELSE 'OK' END as EstadoStock,
                                p.Estado
                                FROM Productos p
                                INNER JOIN Categorias c ON p.IdCategoria = c.IdCategoria
                                ORDER BY p.Nombre";

                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener reporte de productos: " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return dt;
        }

        // Obtener datos para reporte de productos más vendidos
        public DataTable ObtenerProductosMasVendidos(DateTime fechaInicio, DateTime fechaFin, int top = 10)
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = @"SELECT TOP (@Top) p.Nombre as Producto, 
                                c.Nombre as Categoria,
                                SUM(dv.Cantidad) as CantidadVendida,
                                SUM(dv.Subtotal) as TotalVentas
                                FROM DetalleVenta dv
                                INNER JOIN Productos p ON dv.IdProducto = p.IdProducto
                                INNER JOIN Categorias c ON p.IdCategoria = c.IdCategoria
                                INNER JOIN Ventas v ON dv.IdVenta = v.IdVenta
                                WHERE CAST(v.FechaVenta AS DATE) BETWEEN @FechaInicio AND @FechaFin
                                GROUP BY p.Nombre, c.Nombre
                                ORDER BY CantidadVendida DESC";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Top", top);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio.Date);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin.Date);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos más vendidos: " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return dt;
        }

        // Obtener totales de ventas por fecha
        public DataTable ObtenerTotalesVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = @"SELECT CAST(v.FechaVenta AS DATE) as Fecha,
                                COUNT(v.IdVenta) as TotalVentas,
                                SUM(v.Total) as MontoTotal
                                FROM Ventas v
                                WHERE CAST(v.FechaVenta AS DATE) BETWEEN @FechaInicio AND @FechaFin
                                GROUP BY CAST(v.FechaVenta AS DATE)
                                ORDER BY Fecha DESC";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio.Date);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin.Date);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener totales de ventas: " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return dt;
        }
    }
}