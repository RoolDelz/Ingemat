using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidad.Formatos;

namespace CapaLogica
{
    public class logProyecto
    {
        private datProyecto datos = new datProyecto();
        private datSubFormatos datosSubFormato = new datSubFormatos();

        private datOrdenTrabajo datosOT = new datOrdenTrabajo();

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
        public List<entProyectoVista> Listar()
        {
            return datos.ListarProyectosVista();
        }
        public string IniciarProyecto(int idProyecto, string estadoActual)
        {
            if (estadoActual != "No iniciado")
            {
                return "El proyecto ya ha sido iniciado o finalizado.";
            }

            int idFormato = datos.ObtenerIdFormatoDeProyecto(idProyecto);
            if (idFormato == 0) return "Error: No se encontró el formato asociado al proyecto.";


            List<SubFormato> subformatos = datosSubFormato.ObtenerSubFormatos(idFormato);

            if (subformatos.Count == 0) return "El formato asociado no tiene subformatos configurados.";

            // 4. Crear las Ordenes de Trabajo
            int contador = 1;
            foreach (var sub in subformatos)
            {
                entOrdenTrabajo nuevaOT = new entOrdenTrabajo
                {
                    IdProyecto = idProyecto,
                    NomOT = sub.NomSubFormato,
                    FechaCreacion = DateTime.Now,
                    N_OT = "OT-" + DateTime.Now.ToString("yyyyMMddHHmm") + "-" + contador
                };

                datosOT.InsertarOrdenTrabajo(nuevaOT);
                contador++;
            }

            datos.ActualizarEstado(idProyecto, "En proceso");

            return "OK";
        }
    }
}
