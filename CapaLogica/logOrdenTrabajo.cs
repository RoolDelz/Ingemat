using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logOrdenTrabajo
    {
        private datOrdenTrabajo datos = new datOrdenTrabajo();

        public List<entOrdenTrabajoVista> Listar()
        {
            return datos.ListarOrdenesTrabajoVista();
        }

        public bool AsignarTrabajador(int idOT, int idEmpleado)
        {
            return datos.AsignarEmpleado(idOT, idEmpleado);
        }
        public List<entOrdenTrabajoVista> ListarMisActividades(int idEmpleado)
        {
            return datos.ListarOrdenesPorEmpleado(idEmpleado);
        }
        public entDetalleOT ObtenerDetalle(int idOT)
        {
            return datos.ObtenerDetalleCompleto(idOT);
        }

        public bool Finalizar(int idOT)
        {
            return datos.FinalizarOrdenTrabajo(idOT);
        }
    }
}
