using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entFactura
    {
        public int IdFactura { get; set; }
        public string NumFactura { get; set; } 
        public DateTime FechaFactura { get; set; }
        public decimal PrecioFactura { get; set; }
        public int IdProyecto { get; set; }
        public string Estado { get; set; }
        public string MetodoPago { get; set; }
    }
}
