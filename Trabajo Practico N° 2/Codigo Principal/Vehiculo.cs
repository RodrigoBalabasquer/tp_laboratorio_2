using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codigo_Principal
{
    public class Vehiculo
    {   
        /// <summary>
        /// Agregamos los distintos valores del enumerado
        /// </summary>
        public enum EMarca 
        {
            Yamaha, Chevrolet, Ford, Iveco, Scania, BMW
        }
        protected EMarca _marca;
        protected string _patente;
        protected ConsoleColor _color;
        /// <summary>
        /// Constructor del Vehiculo que carga los atributos cons sus parametros correspondientes
        /// </summary>
        /// <param name="Marca"></param>
        /// <param name="Patente"></param>
        /// <param name="Color"></param>
        public Vehiculo(EMarca Marca, string Patente, ConsoleColor Color) 
        {
            this._marca = Marca;
            this._patente = Patente;
            this._color = Color;
        }
        /// <summary>
        /// Retorna un string con los datos del vehiculo
        /// </summary>
        /// <returns></returns>
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("PATENTE: {0}\r\n", this._patente);
            sb.AppendFormat("MARCA  : {0}\r\n", this._marca.ToString());
            sb.AppendFormat("COLOR  : {0}\r\n", this._color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        
    }
}
