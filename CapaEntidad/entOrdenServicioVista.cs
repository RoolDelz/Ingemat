using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entOrdenServicioVista
    {
        public int IdOS { get; set; }
        public DateTime FechaOS { get; set; }
        public string EstadoOS { get; set; }

        public int IdProforma { get; set; }
        public string MotivoProforma { get; set; }

        public string NomEmpresa { get; set; }
        public string RucEmpresa { get; set; }
    }
}
