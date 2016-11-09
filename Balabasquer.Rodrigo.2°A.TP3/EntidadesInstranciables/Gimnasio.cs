using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using EntidadesAbstractas;
using Archivos;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    public class Gimnasio
    {
        private List<Alumno> _alumno;
        private List<Instructor> _instructor;
        private List<Jornada> _jornada;
        /// <summary>
        /// Enumerado de las clases
        /// </summary>
        public enum EClases
        {
            Pilates, Natacion, CrossFit, Yoga
        }
        #region Constructor
        /// <summary>
        /// Constructor del gimnasio
        /// </summary>
        public Gimnasio()
        {
            this._jornada = new List<Jornada>();
            this._instructor = new List<Instructor>();
            this._alumno = new List<Alumno>();
        }
        #endregion
        #region Indexador
        /// <summary>
        /// Devuelve la jornada correspondiente al indice, si este se encuentra en el rango
        /// </summary>
        /// <param name="indice"></param>
        /// <returns></returns>
        public Jornada this[int indice]
        {
            get
            {
                if (indice >= 0 && indice < this._jornada.Count)
                {
                    return this._jornada[indice];
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion
        #region Operadores
        /// <summary>
        /// Devuelve true si el alumno se encuentra en el gimnasio
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            bool estado = false;
            foreach (Alumno item in g._alumno)
            {
                if (item.DNI == a.DNI)
                {
                    estado = true;
                    break;
                }
            }
            return estado;
        }
        /// <summary>
        /// Devuelve true si el alumno no se encuentra en el gimnasio
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Gimnasio g, Alumno a)
        {
            if (g == a)
                return false;
            return true;
        }
        /// <summary>
        /// Devuelve true si el instructor se encuentra en el gimnasio
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Gimnasio g, Instructor i)
        {
            bool estado = false;
            foreach (Instructor item in g._instructor)
            {
                if (item == i)
                {
                    estado = true;
                    break;
                }
            }
            return estado;
        }
        /// <summary>
        /// Devuelve true si el instructor no se encuentra en el gimnasio
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Gimnasio g, Instructor i)
        {
            if (g == i)
                return false;
            return true;
        }
        /// <summary>
        /// Devuelve un instructor que de la clase pasada por parametro, caso que no haya lanza una interrupcion
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            int i;
            bool estado = false;
            for (i = 0; i < g._instructor.Count; i++)
            {
                if (g._instructor[i] == clase)
                {
                    estado = true;
                    break;
                }
            }
            if (estado)
                return g._instructor[i];
            throw new SinInstructorException();
        }
        /// <summary>
        /// Devuelve el primer instructor que no de la clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            int i;
            bool estado = false;
            for (i = 0; i < g._instructor.Count; i++)
            {
                if (g._instructor[i] != clase)
                {
                    estado = true;
                    break;
                }
            }
            if (estado)
                return g._instructor[i];
            throw new SinInstructorException();
        }
        /// <summary>
        /// Agrega un alumno si no hay ningun otro que tenga el mismo dni, caso contrario lanza una excepcion
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            bool estado = true;
            foreach (Alumno item in g._alumno)
            {
                if (item == a)
                {
                    estado = false;
                    break;
                }
            }
            if (estado)
            {
                g._alumno.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return g;
        }
        /// <summary>
        /// Agrega un instructor, siempre que no haya sido agregado antes
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            bool estado = true;
            foreach (Instructor item in g._instructor)
            {
                if (item == i)
                {
                    estado = false;
                    break;
                }
            }
            if (estado)
            {
                g._instructor.Add(i);
            }
            return g;
        }
        /// <summary>
        /// Agrega una nueva jornada con la clase por parametros, un instructor que pueda darla usando la sobrecarga del operador == y todos los alumnos que realizen esa clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
            Jornada nuevaJornada = new Jornada(clase, (g == clase));
            foreach (Alumno item in g._alumno)
            {
                if (item == clase)
                {
                    nuevaJornada = nuevaJornada + item;
                }
            }
            g._jornada.Add(nuevaJornada);
            return g;
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Retorna un string con todos los datos del gimnasio, inclutendo lista de jornada con el instructor que da la clase y la lista de alumnos por clase
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        private static string MostrarDatos(Gimnasio g)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Jornada:");
            foreach (Jornada item in g._jornada)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Metodo publico que no permite ver los datos del gimnasio mediante el metodo MostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }
        /// <summary>
        /// Guarda los datos del gimnasio en un arhivo xml
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Guardar(Gimnasio gim)
        {
            Xml<Gimnasio> xml = new Xml<Gimnasio>();
            xml.guardar("Gimnasio.xml", gim);
            return true;
        }
        /// <summary>
        /// Lee los datos de un archivo y los guarda en un objeto gimnasio.
        /// </summary>
        /// <returns></returns>
        public static Gimnasio Leer() 
        {
            Xml<Gimnasio> xml = new Xml<Gimnasio>();
            Gimnasio gim;
            xml.leer("Gimnasio.xml",out gim);
            return gim;
        }
        #endregion
        #region Propiedades para serializacion
        public List<Alumno> Alumno
        {
            get
            {
                return this._alumno;
            }
        }
        public List<Instructor> Instructor
        {
            get
            {
                return this._instructor;
            }
        }
        public List<Jornada> Jornada
        {
            get
            {
                return this._jornada;
            }
        }
        #endregion
    }
}
