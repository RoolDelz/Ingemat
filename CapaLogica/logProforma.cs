using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logProforma
    {
        private datCliente datosCliente = new datCliente();
        private datProforma datosProforma = new datProforma();
        private datGastosProf datosGastosProf = new datGastosProf();

        public bool GuardarProformaCompleta(entCliente cliente, entProforma proforma, List<entGastoAdicional> gastos)
        {
            try
            {
                int idCliente = datosCliente.InsertarCliente(cliente);
                if (idCliente == 0) return false; 

                proforma.IdCliente = idCliente;

                int idProforma = datosProforma.InsertarProforma(proforma);
                if (idProforma == 0) return false; 

                foreach (var gasto in gastos)
                {
                    entGastoProf gastoProf = new entGastoProf
                    {
                        IdProforma = idProforma,
                        IdGastoA = gasto.IdGastoA
                    };
                    datosGastosProf.InsertarGastoProf(gastoProf);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
