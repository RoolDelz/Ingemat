using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entOrdenTrabajoVista
    {
        public int IdOT { get; set; }
        public string N_OT { get; set; }
        public string NomOT { get; set; } 
        public string NomProyecto { get; set; }
        public string Estado { get; set; }

        public string NombreEmpleado { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
    }
}
