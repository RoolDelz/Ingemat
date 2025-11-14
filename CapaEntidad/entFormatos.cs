using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Formatos
    {
        public class Categoria
        {
            public int IdCategoria { get; set; }
            public string NomCategoria { get; set; }
        }

        public class Formato
        {
            public int IdFormato { get; set; }
            public string NomFormato { get; set; }
            public decimal PrecioFormato { get; set; }
            public int IdCategoria { get; set; }
        }

        public class SubFormato
        {
            public int IdSubFormato { get; set; }
            public string NomSubFormato { get; set; }
            public int IdFormato { get; set; }
        }
    }
}
