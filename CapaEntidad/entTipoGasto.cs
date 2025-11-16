using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entTipoGasto
    {
        public int IdGastoTipo { get; set; }
        public string NomGastoTipo { get; set; }

        public override string ToString()
        {
            return NomGastoTipo;
        }
    }
}
