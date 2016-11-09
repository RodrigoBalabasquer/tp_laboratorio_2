using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivos<string>
    {
        /// <summary>
        /// Guarda el los datos en un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string archivo, string datos)
        {
            bool estado = true;
            try
            {
                using (StreamWriter escritor = new StreamWriter(archivo))
                {
                    escritor.Write(datos);
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return estado;
        }
        /// <summary>
        /// Retorna un string con el contenido del archivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(string archivo, out string datos)
        {
            bool estado = true;
            StringBuilder sb = new StringBuilder();
            string texto;
            try
            {
                using (StreamReader lector = new StreamReader(archivo))
                {
                    while ((texto = lector.ReadLine()) != null)
                    {
                        sb.AppendLine(texto);
                    }
                    datos = sb.ToString();
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return estado;
        }
    }
}
