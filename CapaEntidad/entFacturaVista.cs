using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entFacturaVista
    {
        public int IdFactura { get; set; }
        public string NumFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal PrecioFactura { get; set; }
        public string Estado { get; set; }
        public string MetodoPago { get; set; }

        public string NomProyecto { get; set; }
        public string NomCliente { get; set; }
    }
}
