using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
using System.Data;

namespace CapaLogica
{
    public class logEmpleado
    {
        private datEmpleado datos = new datEmpleado();

        public DataTable ListarEmpleados()
        {
            return datos.ListarEmpleados();
        }

        public bool InsertarEmpleado(entEmpleado emp)
        {
            if (string.IsNullOrWhiteSpace(emp.NombreEmpleado) || string.IsNullOrWhiteSpace(emp.Dni))
            {
                return false;
            }

            return datos.InsertarEmpleado(emp);
        }

        public bool EditarEmpleado(entEmpleado emp)
        {
            if (emp.IdEmpleado == 0)
            {
                return false; 
            }

            return datos.EditarEmpleado(emp);
        }
        public entEmpleado BuscarEmpleadoPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni) || dni.Length < 8)
            {
                return null;
            }
            return datos.BuscarEmpleadoPorDni(dni);
        }
    }
}
