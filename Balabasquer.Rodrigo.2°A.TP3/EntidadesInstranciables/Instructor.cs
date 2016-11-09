using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{   
    public class Instructor : PersonaGimnasia
    {
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;       
        #region Constructores
        /// <summary>
        /// Constructor por defecto para poder serializar
        /// </summary>
        public Instructor()
        {

        }
        /// <summary>
        /// Constructor estatico
        /// </summary>
        static Instructor()
        {
            _random = new Random();
        }
        /// <summary>
        /// Constructor del objeto instructor
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <param name="DNI"></param>
        /// <param name="Nacionalidad"></param>
        public Instructor(int ID, string Nombre, string Apellido, string DNI, ENacionalidad Nacionalidad)
            : base(ID, Nombre, Apellido, DNI, Nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClases();
            this._randomClases();
        }
        #endregion
        #region Operadores
        /// <summary>
        /// Retorna true si el instructor da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            bool estado = false;
            foreach (Gimnasio.EClases item in i._clasesDelDia)
            {
                if (item == clase)
                {
                    estado = true;
                    break;
                }
            }
            return estado;
        }
        /// <summary>
        /// Retorna true si el instructor no da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            if (i == clase)
                return false;
            return true;
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Agrega un clase al azar a la cola de clases
        /// </summary>
        private void _randomClases()
        {
            Gimnasio.EClases clase;
            clase = (Gimnasio.EClases)_random.Next(0, 4);
            this._clasesDelDia.Enqueue(clase);

        }
        /// <summary>
        /// Sobrecarga de metodo abstracto, retorna string con el siguiente mensaje
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Devuelve un string con los datos del instructor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Metodo publico para ver los datos de un instructor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
