using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suma_numeros_decimales
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("num 1:");
            double num1 = double.Parse(Console.ReadLine());//"5"->

            Console.Write("num 2:");
            double num2 = double.Parse(Console.ReadLine());

            double respuesta = num1 + num2;
            Console.WriteLine("La suma de {0} +{1} = {2}", num1, num2, respuesta);
            //pausa
            Console.ReadLine();

        }
    }
}
