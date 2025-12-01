using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class logReporte
    {
        private datReporte datos = new datReporte();

        public List<entReporte> Listar(int idOT)
        {
            return datos.ListarPorOT(idOT);
        }

        public void SubirArchivo(int idOT, string rutaArchivo)
        {
            FileInfo fi = new FileInfo(rutaArchivo);

            if (fi.Length > 5242880)
            {
                throw new Exception("El archivo excede el tamaño máximo de 5MB.");
            }

            string ext = fi.Extension.ToLower();
            if (ext != ".pdf" && ext != ".png" && ext != ".jpg" && ext != ".jpeg")
            {
                throw new Exception("Solo se permiten archivos PDF o Imágenes (PNG, JPG).");
            }

            byte[] contenido = File.ReadAllBytes(rutaArchivo);

            entReporte reporte = new entReporte
            {
                IdOT = idOT,
                NombreArchivo = fi.Name,
                Extension = ext,
                Contenido = contenido
            };

            if (!datos.InsertarReporte(reporte))
            {
                throw new Exception("Error al guardar el archivo en la base de datos.");
            }
        }
    }
}
