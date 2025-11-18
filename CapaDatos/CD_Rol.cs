using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Rol
    {
        public List<Rol> Listar()
        {
            List<Rol> lista = new List<Rol>();
            SqlConnection conexion = null;

            try
            {
                conexion = Conexion.ObtenerConexion();
                string query = "SELECT IdRol, Rol FROM Roles";

                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Rol()
                    {
                        IdRol = Convert.ToInt32(reader["IdRol"]),
                        RolNombre = reader["Rol"].ToString()
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar roles: " + ex.Message);
            }
            finally
            {
                Conexion.CerrarConexion(conexion);
            }

            return lista;
        }
    }
}

