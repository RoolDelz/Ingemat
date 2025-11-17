using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entEmpresa
    {
        public int IdEmpresa { get; set; }
        public string NomEmpresa { get; set; }
        public string Ruc { get; set; }
        public string TelefonoEmpresa { get; set; }
        public string CorreoEmpresa { get; set; }
        public string DireccionEmpresa { get; set; }

        public override string ToString()
        {
            return NomEmpresa;
        }
    }
}
