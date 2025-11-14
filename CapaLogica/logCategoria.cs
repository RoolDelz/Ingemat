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

        // Listar todas las categorías
        public List<Categoria> ListarCategorias()
        {
            return datos.ObtenerCategorias(); // Llama a la capa de datos para obtener todas las categorías
        }

        // Insertar una nueva categoría
        public bool InsertarCategoria(Categoria categoria)
        {
            // Regla de negocio: Verificar que el nombre no esté vacío
            if (string.IsNullOrWhiteSpace(categoria.NomCategoria))
            {
                return false; // No se puede insertar si el nombre está vacío
            }

            datos.AgregarCategoria(categoria); // Llama a la capa de datos para agregar la categoría
            return true;
        }
    }
}
