using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculo_de_sueldo
{
    class Program
    {
       
            static void Main(string[] args)
            {
            //secuencia fibonacci
            int a = 0, b = 1, c = 1;
            while (c<100)
            {
                Console.WriteLine("{0}+{1}={2}", a,b, c);
                b = a;
                a = c;
                c = + a + b;

            }
            

              

                Console.ReadLine();
            }
        }
    }


