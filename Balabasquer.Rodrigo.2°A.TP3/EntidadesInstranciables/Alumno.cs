using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public class Alumno : PersonaGimnasia
    {
        private Gimnasio.EClases _claseQueToma;
        /// <summary>
        /// Enumerado del estado de cuenta
        /// </summary>
        public enum EEstadoCuenta
        {
            Deudor, MesPrueba, AlDia,
        }
        private EEstadoCuenta _estadoCuenta;
        #region Constructores
        /// <summary>
        /// Constructor por defecto para poder serializar
        /// </summary>
        public Alumno()
        {

        }
        /// <summary>
        /// Contructor de alumno
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <param name="DNI"></param>
        /// <param name="Nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int ID, string Nombre, string Apellido, string DNI, ENacionalidad Nacionalidad, Gimnasio.EClases claseQueToma)
            : base(ID, Nombre, Apellido, DNI, Nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Constructor de alumno sobrecargado con el estado de cuenta
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <param name="DNI"></param>
        /// <param name="Nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int ID, string Nombre, string Apellido, string DNI, ENacionalidad Nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(ID, Nombre, Apellido, DNI, Nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        #endregion
        #region Operadores
        /// <summary>
        /// Retorna true si el alumno toma la clase y si su estado no es deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            return false;
        }
        /// <summary>
        /// Retorna true si el alumno no toma la clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            if (a._claseQueToma != clase)
                return true;
            return false;
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Sobrecarga de metodo abstracto, retorna strinc con el siguiente mensaje
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma;
        }
        /// <summary>
        /// Retorna los datos de un alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("Estado de cuenta: " + this._estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Metodo publico para ver los datos de un alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
