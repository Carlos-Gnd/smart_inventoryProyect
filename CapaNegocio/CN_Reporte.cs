using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Reporte
    {
        private CD_Reporte objCapaDato = new CD_Reporte();

        public int Registrar(Reporte obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.IdUsuario == 0)
            {
                mensaje = "Debe especificar el usuario";
                return 0;
            }

            if (string.IsNullOrWhiteSpace(obj.TipoReporte))
            {
                mensaje = "Debe especificar el tipo de reporte";
                return 0;
            }

            obj.FechaGeneracion = DateTime.Now;

            return objCapaDato.Registrar(obj, out mensaje);
        }

        public List<Reporte> Listar()
        {
            return objCapaDato.Listar();
        }

        public DataTable ObtenerReporteVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            return objCapaDato.ObtenerReporteVentas(fechaInicio, fechaFin);
        }

        public DataTable ObtenerReporteProductos()
        {
            return objCapaDato.ObtenerReporteProductos();
        }

        public DataTable ObtenerProductosMasVendidos(DateTime fechaInicio, DateTime fechaFin, int top = 10)
        {
            return objCapaDato.ObtenerProductosMasVendidos(fechaInicio, fechaFin, top);
        }

        public DataTable ObtenerTotalesVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            return objCapaDato.ObtenerTotalesVentas(fechaInicio, fechaFin);
        }
    }
}
