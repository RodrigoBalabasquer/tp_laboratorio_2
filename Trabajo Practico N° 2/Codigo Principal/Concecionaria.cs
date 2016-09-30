using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codigo_Principal
{
    public class Concecionaria
    {
        private List<Vehiculo> _vehiculos;
        protected int _espacioDisponible;
        /// <summary>
        /// Constructor del concecionario que inicializa el listado
        /// </summary>
        public Concecionaria()
        {
            this._vehiculos = new List<Vehiculo>();
        }
        /// <summary>
        /// Constructor que inicializa el listado y ademas carga al atrivuto espacioDisponible el valor que recibe por parametros
        /// </summary>
        /// <param name="Espacio"></param>
        public Concecionaria(int Espacio) : this() 
        {
            this._espacioDisponible = Espacio;
        }
        /// <summary>
        /// Agregamos los distintos valores del enumerado
        /// </summary>
        public enum ETipo
        {
            Moto, Camion, Automovil, Todos
        }
        /// <summary>
        /// Permite agregar un nuevo vehiculo siempre y cuando haya lugar y no se encuentre en el listado
        /// </summary>
        /// <param name="concecionaria"></param>
        /// <param name="vehiculo"></param>
        /// <returns></returns>
        public static Concecionaria operator +(Concecionaria concecionaria,Vehiculo vehiculo)
        {
            if (concecionaria._espacioDisponible <= concecionaria._vehiculos.Count) 
            {
                Console.WriteLine("No hay espacio disponible.");
            }
            else 
            {
                concecionaria._vehiculos.Add(vehiculo);
                Console.WriteLine("Vehiculo agregado.");
            }
            return concecionaria;
        }
        /// <summary>
        /// Remueve un vehiculo del listado, si es que se encuentra
        /// </summary>
        /// <param name="concecionaria"></param>
        /// <param name="vehiculo"></param>
        /// <returns></returns>
        public static Concecionaria operator -(Concecionaria concecionaria, Vehiculo vehiculo)
        {
            foreach (Vehiculo item in concecionaria._vehiculos)
            {
                if (item == vehiculo) 
                {
                    concecionaria._vehiculos.Remove(vehiculo);
                    break;
                }
            }
            return concecionaria;
        }
        /// <summary>
        /// LLama a la funcion mostrar y devuelve un string
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return this.Mostrar(this, ETipo.Todos);
        }
        /// <summary>
        /// Retorna un string con el espacio disponible, el espacio ocupado y las caracteristicas de los vehiculos del listado que coincidan con el paramatro tipoDeVehiculo
        /// </summary>
        /// <param name="concecionaria"></param>
        /// <param name="tipoDeVehiculo"></param>
        /// <returns></returns>
        public string Mostrar(Concecionaria concecionaria, ETipo tipoDeVehiculo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", concecionaria._vehiculos.Count, concecionaria._espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in concecionaria._vehiculos)
            {
                switch (tipoDeVehiculo)
                {
                    case ETipo.Automovil:
                        if (v is Automovil) 
                        {
                            sb.AppendLine(((Automovil)v).Mostrar());
                        }
                        break;
                    case ETipo.Moto:
                        if (v is Moto)
                        {
                            sb.AppendLine(((Moto)v).Mostrar());
                        }
                        break;
                    case ETipo.Camion:
                        if (v is Camion)
                        {
                            sb.AppendLine(((Camion)v).Mostrar());
                        }
                        break;
                    default:
                        if (v is Automovil)
                        {
                            sb.AppendLine(((Automovil)v).Mostrar());
                        }
                        if (v is Moto)
                        {
                            sb.AppendLine(((Moto)v).Mostrar());
                        }
                        if (v is Camion)
                        {
                            sb.AppendLine(((Camion)v).Mostrar());
                        }
                        break;
                }
            }

            return sb.ToString();
        }
    }
}
