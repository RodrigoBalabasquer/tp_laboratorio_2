using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class Calculadora
    {   
        /// <summary>
        /// Esta funcion realiza la operacion matematica correspondiente dependiendo del parametro operador y retorna el resultado.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero numero1,Numero numero2,string operador)
        {
            double resultado = 0;
            operador = validarOperador(operador);
            switch (operador) 
            {
                case "+":
                    resultado = numero1 + numero2;
                    break;
                case "-":
                    resultado = numero1 - numero2;
                    break;
                case "*":
                    resultado = numero1 * numero2;
                    break;
                case "/":
                    resultado = numero1 / numero2;
                    break;
             }
            return resultado;
        }
        /// <summary>
        /// Esta funcion recive como parametro un sting y valida que sea uno de los operadores validos, si lo es lo retorna, caso contrario retorna el operador +
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string validarOperador(string operador) 
        {
            string operadorAUX;
            switch (operador) 
            {
                case "+":
                    operadorAUX = "+";
                    break;
                case "-":
                    operadorAUX = "-";
                    break;
                case "*":
                    operadorAUX = "*";
                    break;
                case "/":
                    operadorAUX = "/";
                    break;
                default:
                    operadorAUX = "+";
                    break;
            }
            return operadorAUX;
        }

        
    }
}
