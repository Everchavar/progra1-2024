using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace condicional_de_edad
{
    class Program
    {
        static void Main(string[] args)
        {
            //condicional para la edad de una persona
            Console.Write("Edad: ");
            int edadt = int.Parse(Console.ReadLine());
            if (edadt >= 18)
            {
                Console.WriteLine("Bienvenido a la vida adulta");
            }
            else
            { 
                Console.WriteLine("disfrita mientas puedas");

            }


            Console.ReadLine();
        }
    }
}
