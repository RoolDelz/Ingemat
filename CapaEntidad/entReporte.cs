using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entReporte
    {
        public int IdReporte { get; set; }
        public int IdOT { get; set; }
        public string NombreArchivo { get; set; }
        public string Extension { get; set; }
        public byte[] Contenido { get; set; }
        public DateTime FechaSubida { get; set; }
    }
}
