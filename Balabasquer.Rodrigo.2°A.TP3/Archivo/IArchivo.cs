using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Archivos
{
    public interface IArchivos<T>
    {
        bool guardar(string archivo, T datos);//Los archivos se guardaran en la carpeta Trabajo Practico Nª3/bin/debug
        bool leer(string archivo, out T datos);
    }
}
