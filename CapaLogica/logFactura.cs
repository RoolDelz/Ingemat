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
    public class logFactura
    {
        private datFactura datos = new datFactura();

        public int ObtenerIdProyecto(int idOS)
        {
            return datos.ObtenerIdProyectoPorOS(idOS);
        }

        public bool Guardar(entFactura factura)
        {
            if (factura.IdProyecto == 0)
            {
                throw new Exception("No se encontró un Proyecto asociado a esta Orden de Servicio. Asegúrese de que el proyecto haya sido creado por el Gerente.");
            }

            if (string.IsNullOrEmpty(factura.NumFactura))
            {
                factura.NumFactura = "F-" + DateTime.Now.ToString("yyyyMMddHHmm");
            }

            return datos.InsertarFactura(factura);
        }
        public int ObtenerIdEmpresaPorOS(int idOS)
        {
            return datos.ObtenerIdEmpresaPorOS(idOS);
        }
    }
}
