using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entOrdenTrabajo
    {
        public int IdOT { get; set; }
        public string N_OT { get; set; }
        public string NomOT { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdProyecto { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public string Estado { get; set; } 
    }
}
