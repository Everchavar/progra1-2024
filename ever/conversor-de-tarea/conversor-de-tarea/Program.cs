
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos_mi_trabajo_de_2_dias_de_desvelo
{
    using System;

    namespace ConversorUnidades
    {
        class Program
        {
            static void Main(string[] args)

            {
                {
                    // Definir los rangos y los valores fijos y adicionales en una matriz
                    // Unidades de área
                    string[] unidades = { "Pie Cuadrado", "Vara Cuadrada", "Yarda Cuadrada", "Metro Cuadrado", "Tareas", "Manzana", "Hectárea" };

                    // Matriz de conversión (factores multiplicativos)
                    double[,] conversiones = {
            { 1, 0.698896, 0.111111, 0.092903, 0.0001476, 0.000025292, 0.0000092903 },  // Pie Cuadrado
            { 1.431111, 1, 0.159422, 0.133694, 0.0002112, 0.0000362, 0.00001332 },      // Vara Cuadrada
            { 9, 6.27264, 1, 0.836127, 0.0013689, 0.0002296, 0.00008361 },              // Yarda Cuadrada
            { 10.7639, 7.48792, 1.19599, 1, 0.0015903, 0.0002471, 0.0001 },             // Metro Cuadrado
            { 67653.95, 47826.09, 7840.64, 628.8, 1, 0.155, 0.06288 },                  // Tareas (El Salvador)
            { 645832.75, 456522.5, 74812.8, 10000, 6.4516, 1, 0.4047 },                 // Manzana (El Salvador)
            { 107639, 764554.9, 119599, 10000, 15.915, 2.471, 1 }                       // Hectárea
        };

                    Console.WriteLine("Conversor de Área");
                    Console.WriteLine("Seleccione la unidad de origen:");

                    for (int i = 0; i < unidades.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {unidades[i]}");
                    }

                    int unidadOrigen = Convert.ToInt32(Console.ReadLine()) - 1;

                    Console.WriteLine("Seleccione la unidad de destino:");

                    for (int i = 0; i < unidades.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {unidades[i]}");
                    }

                    int unidadDestino = Convert.ToInt32(Console.ReadLine()) - 1;

                    Console.WriteLine("Ingrese el valor a convertir:");
                    double valor = Convert.ToDouble(Console.ReadLine());

                    // Realizar la conversión
                    double resultado = valor * conversiones[unidadOrigen, unidadDestino];

                    Console.WriteLine($"{valor} {unidades[unidadOrigen]} equivale a {resultado} {unidades[unidadDestino]}");
                    Console.ReadLine();
                }
            }
        }
    }
}           




       