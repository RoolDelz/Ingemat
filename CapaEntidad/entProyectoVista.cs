using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entProyectoVista
    {
        public int IdProyecto { get; set; }
        public string NomProyecto { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public string NomEmpresa { get; set; }
        public string DireccionProforma { get; set; }
    }
}
