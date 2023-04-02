using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proyecto_01
{
    internal class menu
    {

        public void bienvenida()
        {
            Console.WriteLine("¡Bienvenido al Supermercado PublicMart!");
            Thread.Sleep(2500);
            Console.Clear();
            Console.WriteLine("¿En que podemos ayudarte?");
            Thread.Sleep(2500);
        }
        static void Main(string[] args)
        {
            Facturacion facturar = new Facturacion();
            menu menu = new menu();
            Reporte reporte = new Reporte();
            menu.bienvenida();
            int opcion = 0;
            do
            {
                opcion = 0;
                Console.Clear();
                Console.WriteLine("-----------Menú------------");
                Console.WriteLine("1.Facturacion");
                Console.WriteLine("2.Reportes de facturación");
                Console.WriteLine("3.Cerrar el programa");
                Console.WriteLine("----------------------------");
                try
                {
                    opcion = int.Parse(Console.ReadLine());
                    if (opcion < 1 || opcion > 3)
                    {
                        Console.Clear();
                        throw new Exception("Debe ingresar un número entre 1 y 3....");
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
                switch (opcion)
                {
                    case 1:
                        facturar.volverafacturar();
                        break;
                    case 2:
                        reporte.reporte();
                        break;
                    case 3:
                        break;
                }

            }
            while (opcion != 3);
            Console.Clear();
            Console.WriteLine("¡Nos vemos!, regrese pronto.");
            Thread.Sleep(2500);
            
        }
    }
}
