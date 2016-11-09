using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasia : Persona
    {
        private int _identificador;
        #region Constructor
        /// <summary>
        /// Constructor por defecto para poder serializar
        /// </summary>
        public PersonaGimnasia()
        {

        }
        /// <summary>
        /// Constructor de una persona de gimnasia que recive los mismos atributos que el constructor de persona mas su identificador
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <param name="DNI"></param>
        /// <param name="Nacionalidad"></param>
        public PersonaGimnasia(int ID, string Nombre, string Apellido, string DNI, ENacionalidad Nacionalidad)
            : base(Nombre, Apellido, DNI, Nacionalidad)
        {
            this._identificador = ID;
        }
        #endregion
        #region Operadores
        /// <summary>
        /// Devuelve true si tienen el mismo identificador y si son del mismo tipo
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(PersonaGimnasia pg1, PersonaGimnasia pg2)
        {
            if ((pg1.DNI == pg2.DNI || pg1._identificador == pg2._identificador) && pg1.Equals(pg2))
                return true;
            return false;
        }
        /// <summary>
        /// Devuelve true si no tienen el mismo identificador o son de distinto tipo
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(PersonaGimnasia pg1, PersonaGimnasia pg2)
        {
            if (pg1 == pg2)
                return false;
            return true;
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Metodo abstracto
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// Retorna un string con todos los datos de una persona de gimnasia
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("CARNET NUMERO: " + this._identificador);
            return sb.ToString();
        }
        /// <summary>
        /// Devuelve true si los dos objetos son del mismo tipo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (this.GetType() == obj.GetType())
                return true;
            return false;
        }
        #endregion
    }
}
