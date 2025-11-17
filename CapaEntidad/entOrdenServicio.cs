using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entOrdenServicio
    {
        public int IdOS { get; set; }
        public DateTime FechaOS { get; set; }
        public int IdProforma { get; set; }
        public int IdEmpresa { get; set; }
        public string EstadoOS { get; set; }
    }
}
