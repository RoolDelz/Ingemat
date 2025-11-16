using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entGastoAdicional
    {
        public int IdGastoA { get; set; }
        public string NomGastoA { get; set; }
        public decimal Precio { get; set; }
        public int IdGastoTipo { get; set; }

        public override string ToString()
        {
            return $"{NomGastoA} (S/ {Precio:N2})";
        }
    }
}
