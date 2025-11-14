using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidad.Formatos;

namespace CapaLogica
{
    public class logSubformatos
    {
        private datSubFormatos datos = new datSubFormatos();

        // Listar los subformatos según el formato seleccionado
        public List<SubFormato> ListarSubFormatos(int idFormato)
        {
            return datos.ObtenerSubFormatos(idFormato); // Llama a la capa de datos para obtener los subformatos
        }

        // Insertar un nuevo subformato
        public bool InsertarSubFormato(SubFormato subFormato)
        {
            // Regla de negocio: Verificar que el nombre del subformato no esté vacío
            if (string.IsNullOrWhiteSpace(subFormato.NomSubFormato))
            {
                return false; // No se puede insertar si el nombre está vacío
            }

            datos.AgregarSubFormato(subFormato); // Llama a la capa de datos para agregar el subformato
            return true;
        }
    }
}
