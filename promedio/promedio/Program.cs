using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace promedio
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prioridad de los operadores aritmeticos
            //ejercicio de obtener la nota final de la materia de programación 1

            Console.Write("Lab1:");
            double lab1 = double.Parse(Console.ReadLine());//9

            Console.Write("Lab2:");
            double lab2 = double.Parse(Console.ReadLine());//9

            Console.Write("Parcial1:");
            double parcial1 = double.Parse(Console.ReadLine());//10

            double c1 = lab1 * 30 / 100 + lab2 * 30 / 100 + parcial1 * 30 / 100;
            Console.WriteLine("La nota de c1 es: {0}", c1);

            Console.Write("Lab1:");
            double lab = double.Parse(Console.ReadLine());//9

            Console.Write("Lab2:");
            double laB2 = double.Parse(Console.ReadLine());//9

            Console.Write("Parcial2:");
            double parcial2 = double.Parse(Console.ReadLine());//9

            double c2 = lab1 * 30 / 100 + lab2 * 30 / 100 + parcial2 * 40 / 100;
            Console.WriteLine("La nota de c2 es: {0}", c2);


            Console.Write("Lab1c3:");
            double lab1c3 = double.Parse(Console.ReadLine());//10

            Console.Write("Lab2c3:");
            double lab2c3 = double.Parse(Console.ReadLine());//10

            Console.Write("Parcial3:");
            double parcial3 = double.Parse(Console.ReadLine());//10

            double c3 = lab1c3 * 30 / 100 + lab1c3 * 30 / 100 + parcial3 * 40 / 100;
            Console.WriteLine("La nota de c3 es: {0}", c3);

            double nota_final = (c1 + c2 + c3) / 3;
            //Calcula la nota final de los tres computos.
            Console.WriteLine("La nota final de los 3 Computos: {0}", nota_final);
            
            //Pausa
            Console.ReadLine();
        }
    }
}
