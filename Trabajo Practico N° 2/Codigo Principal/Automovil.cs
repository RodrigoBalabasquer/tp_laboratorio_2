using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codigo_Principal
{
    public class Automovil:Vehiculo
    {
        protected int _ruedas;
        /// <summary>
        /// Constructor que llama al constructor de vehiculos y carga el valor de ruedas al atributo rueda con 4
        /// </summary>
        /// <param name="Marca"></param>
        /// <param name="Patente"></param>
        /// <param name="Color"></param>
        public Automovil(EMarca Marca, string Patente, ConsoleColor Color):base(Marca,Patente,Color) 
        {
            this._ruedas = 4;
        }
        /// <summary>
        /// Retorna un string con los datos del vehiculo mas la cantidad de ruedas
        /// </summary>
        /// <returns></returns>
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS: " + this._ruedas);
            return sb.ToString();
        }
    }
}
