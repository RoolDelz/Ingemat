using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidad.Formatos;

namespace CapaLogica
{
    public class logFormatos
    {
        private datFormatos datos = new datFormatos();

        // Listar los formatos según la categoría seleccionada
        public List<Formato> ListarFormatos(int idCategoria)
        {
            return datos.ObtenerFormatos(idCategoria); // Llama a la capa de datos para obtener los formatos
        }

        // Insertar un nuevo formato
        public bool InsertarFormato(Formato formato)
        {
            // Regla de negocio: Verificar que el nombre no esté vacío y el precio sea válido
            if (string.IsNullOrWhiteSpace(formato.NomFormato) || formato.PrecioFormato <= 0)
            {
                return false; // No se puede insertar si el nombre está vacío o el precio es no válido
            }

            datos.AgregarFormato(formato); // Llama a la capa de datos para agregar el formato
            return true;
        }
    }
}
