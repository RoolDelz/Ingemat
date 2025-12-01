using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
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
        public DataTable ListarTodo()
        {
            return datos.ListarGastosAdicionales();
        }

        public bool Guardar(entGastoAdicional gasto)
        {
            if (gasto.IdGastoA == 0)
                return datos.AgregarGastoAdicional(gasto);
            else
                return datos.EditarGastoAdicional(gasto);
        }
    }
}
