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

        public List<Formato> ListarFormatos(int idCategoria)
        {
            return datos.ObtenerFormatos(idCategoria); 
        }

        public bool InsertarFormato(Formato formato)
        {
            if (string.IsNullOrWhiteSpace(formato.NomFormato) || formato.PrecioFormato <= 0)
            {
                return false; 
            }

            datos.AgregarFormato(formato); 
            return true;
        }
    }
}
