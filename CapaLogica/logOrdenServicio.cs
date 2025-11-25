using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logOrdenServicio
    {
        private datOrdenServicio datos = new datOrdenServicio();

        public bool Guardar(entOrdenServicio os)
        {
            if (os.IdProforma == 0)
            {
                throw new Exception("No se ha proporcionado una proforma de referencia.");
            }
            if (os.IdEmpresa == 0)
            {
                throw new Exception("Debe seleccionar una empresa solicitante.");
            }

            os.EstadoOS = "Pendiente";

            try
            {
                return datos.InsertarOrdenServicio(os);
            }
            catch (Exception ex)
            {

                throw new Exception("Error al guardar la Orden de Servicio: " + ex.Message);
            }
        }
        public List<entOrdenServicioVista> Listar(string estado = null)
        {
            return datos.ListarOrdenesServicioVista(estado);
        }

        public bool AprobarOS(int idOS)
        {
            return datos.ActualizarEstadoOS(idOS, "Aprobado");
        }

        public bool RechazarOS(int idOS)
        {
            return datos.ActualizarEstadoOS(idOS, "Rechazado");
        }
    }
}
