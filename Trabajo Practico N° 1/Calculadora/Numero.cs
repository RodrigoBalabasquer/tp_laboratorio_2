using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class Numero
    {
        private double numero;
        /// <summary>
        /// Constructor de una variable tipo Numero
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor de una variable tipo Numero que recibe un parametro tipo double y lo guarda en la variable.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero) 
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor de una variable tipo Numero que recibe un parametro tipo string y lo guarda en la variable.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero) 
        {
            this.setNumero(numero);
        }
        /// <summary>
        /// Valida que lo que ingresemos sea un numero y no contenga caracteres, si la validacion es correcta retorna el numero ingresado en una variable tipo double, caso contrario retorna 0.
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns></returns>
        private double ValidarNumero(string numeroString) 
        {
            bool valido;
            double numero;
            valido = double.TryParse(numeroString, out numero);
            return numero;
        }
        /// <summary>
        /// Retorna el valor del campo double que esta dentro de la variable de tipo Numero.
        /// </summary>
        /// <returns></returns>
        public double getNumero() 
        {
            return this.numero;
        }
        /// <summary>
        /// Convierte la variable string a double y la carga dentro de la variable Numero.
        /// </summary>
        /// <param name="numero"></param>
        private void setNumero(string numero) 
        {
            double num;
            num = this.ValidarNumero(numero);
            this.numero = num;
        }
        /// <summary>
        /// Esta funcion realiza la operacion de suma entre 2 variables tipo Numero retorna el resiltado.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <returns></returns>
        public static double operator +(Numero numero1, Numero numero2)
        {
            double num1, num2, resultado;
            num1 = numero1.getNumero();
            num2 = numero2.getNumero();
            resultado = num1 + num2;
            return resultado;
        }
        /// <summary>
        /// Esta funcion realiza la operacion de resta entre 2 variables tipo Numero retorna el resiltado.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <returns></returns>
        public static double operator -(Numero numero1, Numero numero2)
        {
            double num1, num2, resultado;
            num1 = numero1.getNumero();
            num2 = numero2.getNumero();
            resultado = num1 - num2;
            return resultado;
        }
        /// <summary>
        /// Esta funcion realiza la operacion de multiplicacion entre 2 variables tipo Numero retorna el resiltado.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <returns></returns>
        public static double operator *(Numero numero1, Numero numero2)
        {
            double num1, num2, resultado;
            num1 = numero1.getNumero();
            num2 = numero2.getNumero();
            resultado = num1 * num2;
            return resultado;
        }
        /// <summary>
        /// Esta funcion realiza la operacion de division entre 2 variables tipo Numero retorna el resiltado.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <returns></returns>
        public static double operator /(Numero numero1, Numero numero2)
        {
            double num1, num2, resultado;
            num1 = numero1.getNumero();
            num2 = numero2.getNumero();
            if (num2 == 0)
            {
                return 0;
            }
            else
            {
                resultado = num1 / num2;
                return resultado;
            }
        }
    }
}
