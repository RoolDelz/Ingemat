using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logTipoGasto
    {
        private datTipoGasto datos = new datTipoGasto();
        public List<entTipoGasto> ListarTiposGasto()
        {
            return datos.ObtenerTiposGasto();
        }
        public bool Guardar(entTipoGasto tipo)
        {
            if (tipo.IdGastoTipo == 0)
                return datos.AgregarTipoGasto(tipo);
            else
                return datos.EditarTipoGasto(tipo);
        }
    }
}
