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

        public DataTable ListarFacturas()
        {
            return datos.ListarFacturas();
        }

        public DataTable ListarProyectosSinFactura()
        {
            return datos.ListarProyectosSinFactura();
        }

        public bool InsertarFactura(entFactura fac)
        {
            // --- ESTE ES EL CÓDIGO QUE TE FALTA ---
            if (string.IsNullOrWhiteSpace(fac.NumFactura))
            {
                throw new Exception("RECHAZADO: El campo Código (NumFactura) está vacío.");
            }
            if (fac.IdProyecto == 0)
            {
                throw new Exception("RECHAZADO: No se ha seleccionado un Proyecto válido (IdProyecto es 0).");
            }
            if (fac.PrecioFactura <= 0)
            {
                throw new Exception("RECHAZADO: El Precio debe ser mayor a cero.");
            }
            if (string.IsNullOrWhiteSpace(fac.Estado))
            {
                throw new Exception("RECHAZADO: El Estado no está seleccionado.");
            }
            // --- FIN DEL BLOQUE ---

            return datos.InsertarFactura(fac);
        }

        // Añade también la excepción para Editar
        public bool EditarFactura(entFactura fac)
        {
            if (string.IsNullOrWhiteSpace(fac.NumFactura) || fac.IdFactura == 0)
            {
                throw new Exception("RECHAZADO: Faltan datos para editar (NumFactura o IdFactura).");
            }
            return datos.EditarFactura(fac);
        }
    }
}
