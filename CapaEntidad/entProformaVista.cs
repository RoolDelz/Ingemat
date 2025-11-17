using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entProformaVista
    {
        public int IdProforma { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaP { get; set; }
        public string DireccionProforma { get; set; }

        public int IdCliente { get; set; }
        public string NomCliente { get; set; }

        public int IdCategoria { get; set; }
        public string NomCategoria { get; set; }
        public int IdFormato { get; set; }
        public string NomFormato { get; set; }

        public decimal Total { get; set; } 
        public decimal PrecioFinal { get; set; } 

        public decimal PrecioFormato { get; set; }
    }
}
