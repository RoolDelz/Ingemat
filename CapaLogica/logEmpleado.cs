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
            // --- Ejemplo de Regla de Negocio ---
            if (string.IsNullOrWhiteSpace(emp.NombreEmpleado) || string.IsNullOrWhiteSpace(emp.Dni))
            {
                // No inserta si los campos clave están vacíos
                return false;
            }
            // (Aquí podrías añadir una lógica para verificar DNI duplicado antes de insertar)

            return datos.InsertarEmpleado(emp);
        }

        public bool EditarEmpleado(entEmpleado emp)
        {
            // --- Ejemplo de Regla de Negocio ---
            if (emp.IdEmpleado == 0)
            {
                return false; // No se puede editar un empleado sin ID
            }

            return datos.EditarEmpleado(emp);
        }
        public entEmpleado BuscarEmpleadoPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni) || dni.Length < 8)
            {
                return null; // Regla de negocio: DNI no puede estar vacío o ser inválido
            }
            return datos.BuscarEmpleadoPorDni(dni);
        }
    }
}
