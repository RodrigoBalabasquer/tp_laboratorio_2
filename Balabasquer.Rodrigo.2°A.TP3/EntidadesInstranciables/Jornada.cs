using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumno;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;
        #region Contructores
        /// <summary>
        /// Constructor de jornada
        /// </summary>
        public Jornada()
        {
            this._alumno = new List<Alumno>();
        }
        /// <summary>
        /// Constructor sobrecargado 
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion
        #region Operadores
        /// <summary>
        /// Agrega un alumno a la jornada, si no fue ingresado antes
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool estado = true;
            foreach (Alumno item in j._alumno)
            {
                if (item == a)
                {
                    estado = false;
                    break;
                }
            }
            if (estado)
            {
                j._alumno.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return j;
        }
        /// <summary>
        /// Retorna true si el alumno se encuentra en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool estado = false;
            foreach (Alumno item in j._alumno)
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
        /// Retorna true si el alumno no se encuentra en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            if (j == a)
                return false;
            return true;
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Muestra los datos de la jornada y la lista de alumnos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CLASE DE " + this._clase + " ");
            sb.AppendLine(this._instructor.ToString());
            if (this._alumno.Count == 0)
            {
                sb.AppendLine("NO HAY ALUMNOS");
            }
            else
            {
                sb.AppendLine("ALUMNOS: ");
                foreach (Alumno item in this._alumno)
                {
                    sb.AppendLine(item.ToString());
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// Guarda los datos de la jornada en un arhivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.guardar("Jornada.txt", jornada.ToString());
        }
        /// <summary>
        /// Retorna el contenido del archivo de texto como un string
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            Texto texto = new Texto();
            string datos;
            texto.leer("Jornada.txt", out datos);
            return datos;
        }
        #endregion
        #region Propiedades para serializacion
        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumno;
            }
        }
        public Gimnasio.EClases Clase
        {
            get
            {
                return this._clase;
            }
            set
            {
                this._clase= value;
            }
        }
        public Instructor Instructor 
        {
            get
            {
                return this._instructor;
            }
            set
            {
                this._instructor = value;
            }
        }
        #endregion

    }
}
