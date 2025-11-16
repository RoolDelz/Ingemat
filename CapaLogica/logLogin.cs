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
        private const string PASS_GERENTE = "admin123";
        private const string PASS_VENTAS = "ventas123";
        private const string PASS_TECNICO = "tecnico123";

        public bool ValidarLogin(string nombreCompleto, string password)
        {
            string cargo = "";
            bool accesoConcedido = false;


            switch (nombreCompleto)
            {
                // Gerente
                case "Juan Pérez Gómez":
                    cargo = "Gerente";
                    break;

                // Vendedores
                case "María López Torres":
                case "Carlos Ruiz Soto":
                case "Ana Díaz Vargas":
                    cargo = "Area de ventas";
                    break;

                // Técnicos
                case "Pedro Salas Cueva":
                case "Luisa Vidal Reyes":
                case "Jorge Mendoza Huamán":
                    cargo = "Ayudante Tecnico";
                    break;

                default:
                    cargo = ""; 
                    break;
            }

            if (string.IsNullOrEmpty(cargo))
            {
                return false; 
            }

            switch (cargo)
            {
                case "Gerente":
                    accesoConcedido = (password == PASS_GERENTE);
                    break;
                case "Area de ventas":
                    accesoConcedido = (password == PASS_VENTAS);
                    break;
                case "Ayudante Tecnico":
                    accesoConcedido = (password == PASS_TECNICO);
                    break;
            }

            if (accesoConcedido)
            {
                entSession.NombreEmpleado = nombreCompleto;
                entSession.Cargo = cargo;
                return true;
            }

            return false;
        }
    }
}
