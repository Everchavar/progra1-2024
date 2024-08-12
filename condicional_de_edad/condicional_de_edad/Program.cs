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
            string seguir = "g";
            while (seguir == "g") {

                Console.Write("Edad: ");
                int edadt = int.Parse(Console.ReadLine());
                if (edadt< 0)
                {
                    Console.WriteLine("edad incorrecta");
                }
                else if (edadt<=2)
                {        
                    Console.WriteLine("eres un bebe");

                } else if (edadt<12)
                    {
                    Console.WriteLine("eres un niño");
                }else if (edadt<18)
                {
                    Console.WriteLine("eres un adolescente");
                    
                }else if (edadt <= 64)
                {
                    Console.WriteLine("Bienbenido al mundo de las responsabilidades");
                }else if (edadt <=80)
                {
                    Console.WriteLine("eres un adulto mayor");
                }else  {
                    Console.WriteLine("Larga vida");
                }
                Console.Write("Desea seguir presione g, si no cualquier tecla.\n");
                seguir = Console.ReadLine();

            }
            
        }
    }
}
