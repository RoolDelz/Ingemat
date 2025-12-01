using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logEmpresa
    {
        private datEmpresa datos = new datEmpresa();

        public List<entEmpresa> Listar()
        {
            return datos.ListarEmpresas();
        }

        public List<entEmpresaVista> ListarVista()
        {
            return datos.ListarEmpresasVista();
        }

        public int InsertarEmpresa(entEmpresa empresa)
        {
            if (string.IsNullOrWhiteSpace(empresa.NomEmpresa))
            {
                throw new Exception("El campo 'Empresa Solicitante' es obligatorio.");
            }
            if (string.IsNullOrWhiteSpace(empresa.Ruc))
            {
                throw new Exception("El campo 'Ruc' es obligatorio.");
            }

            try
            {
                return datos.InsertarEmpresa(empresa);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar la empresa: " + ex.Message);
            }
        }

        public entEmpresa ObtenerPorId(int id)
        {
            return datos.ObtenerEmpresaPorId(id);
        }

        public bool Editar(entEmpresa empresa)
        {
            if (string.IsNullOrWhiteSpace(empresa.NomEmpresa)) throw new Exception("El nombre de la empresa es obligatorio.");
            if (string.IsNullOrWhiteSpace(empresa.Ruc)) throw new Exception("El RUC es obligatorio.");

            return datos.EditarEmpresa(empresa);
        }
    }
}
