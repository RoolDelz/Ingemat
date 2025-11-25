using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logProyecto
    {
        private datProyecto datos = new datProyecto();

        public bool ExisteProyecto(int idOS)
        {
            return datos.ExisteProyectoPorOS(idOS);
        }

        public bool CrearProyectoDesdeOS(int idOS, string motivoProforma)
        {
            if (datos.ExisteProyectoPorOS(idOS))
            {
                throw new Exception("Ya existe un Proyecto creado para esta Orden de Servicio.");
            }
            entProyecto nuevoProyecto = new entProyecto
            {
                NomProyecto = motivoProforma,
                FechaCreacion = DateTime.Now,
                IdOS = idOS
            };

            try
            {
                int id = datos.InsertarProyecto(nuevoProyecto);
                return id > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el proyecto: " + ex.Message);
            }
        }
    }
}
