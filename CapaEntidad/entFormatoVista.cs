using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entFormatoVista
    {
        public int IdCategoria { get; set; }
        public string NomCategoria { get; set; }

        public int IdFormato { get; set; }
        public string NomFormato { get; set; }
        public decimal PrecioFormato { get; set; }

        public int IdSubFormato { get; set; }
        public string NomSubFormato { get; set; }
    }
}
