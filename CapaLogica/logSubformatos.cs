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
    public class logSubformatos
    {
        private datSubFormatos datos = new datSubFormatos();

        public List<SubFormato> ListarSubFormatos(int idFormato)
        {
            return datos.ObtenerSubFormatos(idFormato);
        }

        public bool InsertarSubFormato(SubFormato subFormato)
        {
            if (string.IsNullOrWhiteSpace(subFormato.NomSubFormato))
            {
                return false; 
            }

            datos.AgregarSubFormato(subFormato); 
            return true;
        }
        public bool Editar(SubFormato sub)
        {
            if (string.IsNullOrWhiteSpace(sub.NomSubFormato)) return false;
            return datos.EditarSubFormato(sub);
        }
        public List<entFormatoVista> ListarTodo()
        {
            return datos.ListarVistaCompleta();
        }
    }
}
