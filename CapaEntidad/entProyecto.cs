using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entProyecto
    {
        public int IdProyecto { get; set; }
        public string NomProyecto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; } 
        public int IdOS { get; set; }
    }
}
