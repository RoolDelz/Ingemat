using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logCliente
    {
        private datCliente datos = new datCliente();

        public int InsertarCliente(entCliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.NomCliente))
            {
                System.Diagnostics.Debug.WriteLine("El nombre del cliente no puede estar vacío.");
                return 0;
            }
            if (string.IsNullOrWhiteSpace(cliente.NDocumento))
            {
                System.Diagnostics.Debug.WriteLine("El número de documento no puede estar vacío.");
                return 0; 
            }

            try
            {
                return datos.InsertarCliente(cliente);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error en logCliente.InsertarCliente: " + ex.Message);
                return 0;
            }
        }
        public List<entClienteVista> Listar()
        {
            return datos.ListarClientesVista();
        }

        public bool Editar(entCliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.NomCliente)) throw new Exception("El nombre no puede estar vacío.");
            if (string.IsNullOrWhiteSpace(cliente.NDocumento)) throw new Exception("El número de documento es obligatorio.");

            return datos.EditarCliente(cliente);
        }
    }
}
