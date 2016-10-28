using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_de_Clases
{
    public abstract class Vehiculo
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
        /// Propiedad abstracta que devuelve la cantidad de ruedas que tiene el vehiculo
        /// </summary>
        protected abstract int CantidadDeRuedas
        {
            get;
        }
        /// <summary>
        /// Retorna un string con los datos del vehiculo
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("PATENTE: {0}\r\n", this._patente);
            sb.AppendFormat("MARCA  : {0}\r\n", this._marca.ToString());
            sb.AppendFormat("COLOR  : {0}\r\n", this._color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        /// <summary>
        /// Dos vehículos son iguales si su patente es la misma
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            if (v1._patente == v2._patente)
                return true;
            return false;
        }
        /// <summary>
        /// Dos vehículos son distintos si su patente es distinta
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            if (v1 == v2)
                return false;
            return true;
        }

    }
}
