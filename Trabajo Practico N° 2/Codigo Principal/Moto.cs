﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codigo_Principal
{
    public class Moto:Vehiculo
    {
        /// <summary>
        /// Constructor que llama al constructor de vehiculos.
        /// </summary>
        /// <param name="Marca"></param>
        /// <param name="Patente"></param>
        /// <param name="Color"></param>
        public Moto(EMarca Marca, string Patente, ConsoleColor Color):base(Marca,Patente,Color) 
        {
            
        }
        /// <summary>
        /// Implementacion de la propiedad abstracta de la cantidad de ruedas
        /// </summary>
        protected override int CantidadDeRuedas
        {
            get
            {
                return 2;
            }
        }
        /// <summary>
        /// Retorna un string con los datos del vehiculo mas la cantidad de ruedas
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS: " + this.CantidadDeRuedas);
            return sb.ToString();
        }
    }
}
