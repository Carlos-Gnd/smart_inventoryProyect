using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Reporte
    {
        public int IdReporte { get; set; }
        public int IdUsuario { get; set; }
        public string TipoReporte { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public string RutaArchivo { get; set; }

        // Propiedad de navegación
        public Usuario Usuario { get; set; }

        // Constructor vacío
        public Reporte() { }

        // Constructor con parámetros
        public Reporte(int idReporte, int idUsuario, string tipoReporte,
                       DateTime fechaGeneracion, string rutaArchivo)
        {
            IdReporte = idReporte;
            IdUsuario = idUsuario;
            TipoReporte = tipoReporte;
            FechaGeneracion = fechaGeneracion;
            RutaArchivo = rutaArchivo;
        }
    }
}
