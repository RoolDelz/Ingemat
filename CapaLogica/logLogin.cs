using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logLogin
    {
        private datEmpleado datosEmpleado = new datEmpleado();

        private const string PASS_GERENTE = "admin123";
        private const string PASS_VENTAS = "ventas123";
        private const string PASS_TECNICO = "tecnico123";

        public bool ValidarLogin(string dni, string password)
        {
            try
            {
                entEmpleado emp = datosEmpleado.BuscarEmpleadoPorDni(dni);

                if (emp == null)
                {
                    throw new Exception("El DNI ingresado no existe en el sistema.");
                }
                if (!emp.Estado)
                {
                    throw new Exception("El usuario se encuentra INACTIVO. Contacte al administrador.");
                }
                bool passCorrecta = false;

                switch (emp.Cargo)
                {
                    case "Gerente":
                        passCorrecta = (password == PASS_GERENTE);
                        break;
                    case "Area de ventas":
                        passCorrecta = (password == PASS_VENTAS);
                        break;
                    case "Ayudante Tecnico":
                        passCorrecta = (password == PASS_TECNICO);
                        break;
                    default:
                        throw new Exception($"El cargo '{emp.Cargo}' no tiene permisos de acceso configurados.");
                }
                if (passCorrecta)
                {
                    entSession.IdEmpleado = emp.IdEmpleado;
                    entSession.NombreEmpleado = emp.NombreEmpleado;
                    entSession.Cargo = emp.Cargo;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
