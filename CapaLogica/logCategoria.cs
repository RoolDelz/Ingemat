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
    public class logCategoria
    {
        private datCategorias datos = new datCategorias();

        public List<Categoria> ListarCategorias()
        {
            return datos.ObtenerCategorias(); 
        }

        public bool InsertarCategoria(Categoria categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.NomCategoria))
            {
                return false; 
            }

            datos.AgregarCategoria(categoria); 
            return true;
        }
    }
}
