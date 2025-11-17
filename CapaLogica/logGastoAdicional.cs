using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logGastoAdicional
    {
        private datGastoAdicional datos = new datGastoAdicional();
        public List<entGastoAdicional> ListarGastosPorTipo(int idTipoGasto)
        {
            return datos.ObtenerGastosPorTipo(idTipoGasto);
        }
        public List<entGastoAdicional> ListarGastosPorProforma(int idProforma)
        {
            return datos.ListarGastosPorProforma(idProforma);
        }
    }
}
