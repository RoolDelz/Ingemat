using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entEmpleado
    {
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string Dni { get; set; }
        public string TelefonoEmpleado { get; set; }
        public string CorreoEmpleado { get; set; }
        public string Cargo { get; set; }
        public bool Estado { get; set; }
    }
}
