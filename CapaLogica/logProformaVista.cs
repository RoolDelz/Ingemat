using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logProformaVista
    {
        private datProforma datos = new datProforma();
        public List<entProformaVista> Listar()
        {
            return datos.ListarProformasVista();
        }
    }
}
