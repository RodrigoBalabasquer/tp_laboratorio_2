using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string _apellido;
        private string _nombre;
        private ENacionalidad _nacionalidad;
        private int _dni;
        /// <summary>
        /// Enumerado de Nacionalidad
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #region Constructores
        /// <summary>
        /// Constructor por defecto para poder serializar
        /// </summary>
        public Persona()
        {

        }
        /// <summary>
        /// Constructor de la clase persona que recibe como parametros el nombre, el appellido y la nacionalidad
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <param name="Nacionalidad"></param>
        public Persona(string Nombre, string Apellido, ENacionalidad Nacionalidad)
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Nacionalidad = Nacionalidad;
        }
        /// <summary>
        /// Constructor sobrecargado que recibe los mismo atributos mas el dni
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <param name="DNI"></param>
        /// <param name="Nacionalidad"></param>
        public Persona(string Nombre, string Apellido, int DNI, ENacionalidad Nacionalidad)
            : this(Nombre, Apellido, Nacionalidad)
        {
            this.DNI = DNI;
        }
        /// <summary>
        /// Constructor sobrecargado que recibe los mismo atributos pero el dni en formato string
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <param name="DNI"></param>
        /// <param name="Nacionalidad"></param>
        public Persona(string Nombre, string Apellido, string DNI, ENacionalidad Nacionalidad)
            : this(Nombre, Apellido, Nacionalidad)
        {
            this.StringToDNI = DNI;
        }
        #endregion
        #region Propiedades
        /// <summary>
        /// Propiedad, retorna el atributo nombre, y lo setea si no tiene ningun caracter invalido
        /// </summary>
        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                if (Persona.ValidadNombreApellido(value) != null)
                {
                    this._nombre = value;
                }
            }
        }
        /// <summary>
        /// Propiedad, retorna el atributo apellido, y lo setea si no tiene ningun caracter invalido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                if (Persona.ValidadNombreApellido(value) != null)
                {
                    this._apellido = value;
                }
            }
        }
        /// <summary>
        /// Propiedad, retorna el atributo nacionalidad, y lo setea 
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }
        /// <summary>
        /// Propiedad, retorna el atributo dni, y lo setea si cumple la condicion, caso contrario lanza la excepcion
        /// </summary>
        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                try
                {
                    switch (this.Nacionalidad)
                    {
                        case ENacionalidad.Argentino:
                            this._dni = Persona.ValidarDNI(ENacionalidad.Argentino, value);
                            break;
                        case ENacionalidad.Extranjero:
                            this._dni = Persona.ValidarDNI(ENacionalidad.Extranjero, value);
                            break;
                        default:
                            break;
                    }
                }
                catch (DniInvalidoException)
                {

                    throw new NacionalidadInvalidaException("La nacionalidad no se coincide con el Número de DNI");
                }
            }
        }
        /// <summary>
        /// Propiedad, setea si cumple la condicion, caso contrario lanza la excepcion
        /// </summary>
        public string StringToDNI
        {
            set
            {
                try
                {
                    switch (this.Nacionalidad)
                    {
                        case ENacionalidad.Argentino:
                            this._dni = Persona.ValidarDNI(ENacionalidad.Argentino, value);
                            break;
                        case ENacionalidad.Extranjero:
                            this._dni = Persona.ValidarDNI(ENacionalidad.Extranjero, value);
                            break;
                        default:
                            break;
                     }
                }
                catch (DniInvalidoException)
                {

                    throw new NacionalidadInvalidaException();
                }
            }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Valida que el dni este en rango segun su nacionalidad
        /// </summary>
        /// <param name="Nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDNI(ENacionalidad Nacionalidad, int dato)
        {
            if (Nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999 || Nacionalidad == ENacionalidad.Extranjero && dato >= 90000000)
                return dato;
            throw new DniInvalidoException();
        }
        /// <summary>
        /// Convierte el string en entero y valida que el dni este en rango segun su nacionalidad
        /// </summary>
        /// <param name="Nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDNI(ENacionalidad Nacionalidad, string dato)
        {
            return Persona.ValidarDNI(Nacionalidad, int.Parse(dato));
        }
        /// <summary>
        /// Valida que el nombre o apellido no tenga ninguna caracter invalido
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static string ValidadNombreApellido(string dato)
        {
            bool estado = true;
            for (int i = 0; i < dato.Length; i++)
            {
                // Este if pregunta por cada caracter si es una letra del alfabeto
                if ((int)dato[i] <= 65 || (int)dato[i] >= 123)
                {
                    estado = false;
                    break;
                }
            }
            if (estado)
                return dato;
            return null;
        }
        /// <summary>
        /// Retorna un string con los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("POR NOMBRE COMPLETO: " + this.Apellido + "," + this.Nombre);
            sb.AppendLine("Nacionalidad: " + this.Nacionalidad);
            sb.AppendLine("DNI: " + this._dni);
            return sb.ToString();
        }
        #endregion
    }
}
