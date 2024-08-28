using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImpuestoActividadesEconomicas
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Ingrese el monto de la actividad económica: ");
                double montoActividad = Convert.ToDouble(Console.ReadLine());
            
            double impuesto = CalcularImpuesto(montoActividad);

                Console.WriteLine($"El valor a pagar es: ${impuesto:F2}");
            }

            static double CalcularImpuesto(double montoActividad)
            {
                double[][] rangos = new double[][]
                {
                new double[] { 0.01, 500, 1.5, 0 },
                new double[] { 500.01, 1000, 1.5, 3 },
                new double[] { 1000.01, 2000, 3, 3 },
                new double[] { 2000.01, 3000, 6, 3 },
                new double[] { 3000.01, 6000, 9, 2 },
                new double[] { 8000.01, 18000, 15, 2 },
                new double[] { 18000.01, 30000, 39, 2 },
                new double[] { 30000.01, 60000, 63, 1 },
                new double[] { 60000.01, 100000, 93, 0.8 },
                new double[] { 100000.01, 200000, 125, 0.7 },
                new double[] { 200000.01, 300000, 195, 0.6 },
                new double[] { 300000.01, 400000, 255, 0.45 },
                new double[] { 400000.01, 500000, 300, 0.4 },
                new double[] { 500000.01, 1000000, 340, 0.3 },
                new double[] { 1000000.01, 99999999, 490, 0.18 }
                };

                foreach (double[] rango in rangos)
                {
                    if (montoActividad >= rango[0] && montoActividad <= rango[1])
                    {
                        double montoRango = montoActividad - rango[0];
                        double precioFijo = rango[2];
                        double adicional = montoRango / (rango[1] - rango[0]) * rango[3];
                        return adicional + precioFijo;
                    }
                }
            Console.WriteLine("\n");
            return 0;
            
        }
        }
    }


