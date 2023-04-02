using System;
using System.Linq;
using System.Threading;

namespace Proyecto_01
{
    internal class Facturacion
    {
        public int contarprod = 0;
        public string nit = "";
        public string nombrecliente = "";
        public string email = "";
        public double suma = 0;
        public static double sumatotal = 0;
        public static string[] productofac = new string[5];
        public string efeotar;
        public static int totalproducto = 0;
        public static int contar = 0;
        public static int sumapuntos;
        public static int tottarje;
        public static int totefectivo;
        public int puntos;

        public void volverafacturar()
        {
            string sino = "";
            while (sino != "no")
            {
                contar++;
                facturar();
                Console.Clear();
                Console.WriteLine("¿Desea ingresar una nueva factura?");
                sino = Console.ReadLine();
            }
        }
        public void facturar()
        {
            Console.Clear();
            bool repetir = false;
            int cantidad;
            double[] precios = new double[5] { 1.10, 5.00, 7.30, 32.50, 17.95 };
            string[] codigos = new string[5] { "001", "002", "003", "004", "005" };
            string[] productos = new string[5] { "Pan frances", "Libra azucar", "Caja de galletas", "Caja de granola", "Litro de juego de naranja" };
            while (repetir != true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese su nombre");
                    nombrecliente = Console.ReadLine();
                    if (nombrecliente.Any(char.IsDigit) || nombrecliente == "")
                    {
                        throw new Exception("Debe ingresar un texto, vuelva a colocar todo los datos...");
                    }
                    Console.WriteLine("Ingrese un e-mail.");
                    email = Console.ReadLine();
                    if (email == "")
                    {
                        throw new Exception("Debe ingresar un texto, vuelva a colocar todo los datos...");
                    }
                    else
                    {
                        if (!email.Any(char.IsLetter))
                        {
                            throw new Exception("El e-mail debe tener un nombre para validar que sea un correo...");
                        }
                        else if (!email.Contains("@"))
                        {
                            throw new Exception("El e-mail debe tener @ para validar que sea un correo...");
                        }
                        else if (!email.Contains("gmail") && !email.Contains("yahoo"))
                        {
                            throw new Exception("El e-mail debe tener despues de @,'gmail' o 'yahoo' para validar que sea un correo...");
                        }
                        else if (!email.Contains(".com"))
                        {
                            throw new Exception("El e-mail debe tener .com...");
                        }
                    }

                    Console.WriteLine("Ingrese un nit");
                    nit = Console.ReadLine();
                    if (nit.Any(char.IsLetter) || nit == "")
                    {
                        throw new Exception("Debe ingresar numeros, vuelva a colocar todo los datos...");
                    }
                    repetir = true;
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }
            int[] sumacantidad = new int[5];
            string[] sumaproducto = new string[5];
            suma = 0;
            string sino = "";
            int sumarfac = 0;
            do
            {
                string opcion = "";
                try
                {
                    Console.Clear();
                    Console.WriteLine("\t\t╔═══lista═══╗\t\t");
                    Console.WriteLine("╔Código═════════╩═Prodcuto══╩═══════════════════Precio══╗");
                    Console.WriteLine("║\t\t\t\t\t\t\t║");
                    Console.WriteLine($"║{codigos[0]}.\t\t{productos[0]}\t\t\tQ{precios[0]}\t║");
                    Console.WriteLine($"║{codigos[1]}.\t\t{productos[1]}\t\t\tQ{precios[1]}\t║");
                    Console.WriteLine($"║{codigos[2]}.\t\t{productos[2]}\t\tQ{precios[2]}\t║");
                    Console.WriteLine($"║{codigos[3]}.\t\t{productos[3]}\t\t\tQ{precios[3]}\t║");
                    Console.WriteLine($"║{codigos[4]}.\t\t{productos[4]}\tQ{precios[4]}  ║");
                    Console.WriteLine("║\t\t\t\t\t\t\t║");
                    Console.WriteLine($"╚═══════════════════════════════════════════════════════╝");
                    Console.WriteLine("¿Que producto desea agregar? \n");

                    opcion = Console.ReadLine();
                    if (opcion.Length != 3 || opcion.Any(char.IsLetter))
                    {
                        Console.Clear();
                        throw new Exception("Debe ingresar el codigo completo incluyendo los 0...");
                    }
                    else if (int.Parse(opcion) > 5 || int.Parse(opcion) <= 0)
                    {
                        Console.Clear();
                        throw new Exception("Debe ingresar el codigo desde 001 entre 005...");
                    }
                    else
                    {
                        switch (opcion)
                        {
                            case "001":
                                Console.WriteLine("\n¿Cuanta cantidad necesita para: " + productos[0] + " ?");
                                cantidad = int.Parse(Console.ReadLine());
                                if (cantidad > 0)
                                {
                                    suma = cantidad * precios[0] + suma;
                                    suma = Math.Round(suma, 2);
                                    sumacantidad[0] += cantidad;
                                    sumaproducto[0] += suma;
                                    totalproducto += sumacantidad[0];
                                    sumarfac += sumacantidad[0];
                                    productofac[0] = "" + productos[0] + " cantidad: " + sumacantidad[0] + " precio: Q" + precios[0] + " = Q";
                                }
                                else
                                {
                                    throw new Exception("Debe ingresar un numero > 0...");
                                }
                                break;
                            case "002":
                                Console.WriteLine("\n¿Cuanta cantidad necesita para: " + productos[1] + " ?");
                                cantidad = int.Parse(Console.ReadLine());
                                if (cantidad > 0)
                                {
                                    suma = cantidad * precios[1] + suma;
                                    suma = Math.Round(suma, 2);
                                    sumacantidad[1] += cantidad;
                                    totalproducto += sumacantidad[1];
                                    sumaproducto[1] += suma;
                                    sumarfac += sumacantidad[1];
                                    productofac[1] = "" + productos[1] + " cantidad: " + sumacantidad[1] + " precio: Q" + precios[1] + " = Q";
                                }
                                else
                                {
                                    throw new Exception("Debe ingresar un numero > 0...");
                                }
                                break;
                            case "003":
                                Console.WriteLine("\n¿Cuanta cantidad necesita para: " + productos[2] + " ?");
                                cantidad = int.Parse(Console.ReadLine());
                                if (cantidad > 0)
                                {
                                    suma = cantidad * precios[2] + suma;
                                    suma = Math.Round(suma, 2);
                                    sumacantidad[2] += cantidad;
                                    totalproducto += sumacantidad[2];
                                    sumaproducto[2] += suma;
                                    sumarfac += sumacantidad[2];
                                    productofac[2] = "" + productos[2] + " cantidad: " + sumacantidad[2] + " precio: Q" + precios[2] + " = Q";
                                }
                                else
                                {
                                    throw new Exception("Debe ingresar un numero > 0...");
                                }
                                break;
                            case "004":
                                Console.WriteLine("\n¿Cuanta cantidad necesita para: " + productos[3] + "?");
                                cantidad = int.Parse(Console.ReadLine());
                                if (cantidad > 0)
                                {
                                    suma = cantidad * precios[3] + suma;
                                    suma = Math.Round(suma, 2);
                                    sumacantidad[3] += cantidad;
                                    totalproducto += sumacantidad[3];
                                    sumaproducto[3] += suma;
                                    sumarfac += sumacantidad[3];
                                    productofac[3] = "" + productos[3] + " cantidad: " + sumacantidad[3] + " precio: Q" + precios[3] + " = Q";
                                }
                                else
                                {
                                    throw new Exception("Debe ingresar un numero > 0...");
                                }
                                break;
                            case "005":
                                Console.WriteLine("\n¿Cuanta cantidad necesita para: " + productos[4] + " ?");
                                cantidad = int.Parse(Console.ReadLine());
                                if (cantidad > 0)
                                {
                                    suma = cantidad * precios[4] + suma;
                                    suma = Math.Round(suma, 2);
                                    sumacantidad[4] += cantidad;
                                    totalproducto += sumacantidad[4];
                                    sumaproducto[4] += suma;
                                    sumarfac += sumacantidad[4];
                                    productofac[4] = "" + productos[4] + " cantidad: " + sumacantidad[4] + " precio: Q" + precios[4] + " = Q";
                                }
                                else
                                {
                                    throw new Exception("Debe ingresar un numero > 0...");
                                }
                                break;
                        }
                        sino = preguntarsino();
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }
            while (sino != "no");
            sumatotal += suma;

            try
            {
                int opcion = 0;
                Console.Clear();
                Console.WriteLine("Seleccione su método de pago:");
                Console.WriteLine("1. Efectivo");
                Console.WriteLine("2. Tarjeta de crédito \n");
                Console.Write("Ingrese el número de su opción: ");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        efeotar = "Efectivo";
                        totefectivo += sumacantidad[0] + sumacantidad[1] + sumacantidad[2] + sumacantidad[3] + sumacantidad[4];
                        break;
                    case 2:
                        efeotar = "Tarjeta de credito";
                        tottarje += sumacantidad[0] + sumacantidad[1] + sumacantidad[2] + sumacantidad[3] + sumacantidad[4];
                        if (totalimpuestos(suma) > 0 && totalimpuestos(suma) <= 50)
                        {
                            puntos = (int)totalimpuestos(suma) / 10;
                            sumapuntos += puntos;

                        }
                        else if (totalimpuestos(suma) > 50 && totalimpuestos(suma) <= 150)
                        {
                            puntos = ((int)totalimpuestos(suma) / 10) * 2;
                            sumapuntos += puntos;
                        }
                        else if (totalimpuestos(suma) > 150)
                        {
                            puntos = ((int)totalimpuestos(suma) / 15) * 3;
                            sumapuntos += puntos;
                        }
                        break;

                }
                imprimirfactura(nit, nombrecliente, suma, productofac, email, efeotar, puntos, sumarfac , sumaproducto);
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public string preguntarsino()
        {
            string sino = "";
            bool repetir = false;
            while (repetir != true)
            {
                Console.WriteLine("¿Desea ingresar más producto? si/no");
                sino = Console.ReadLine();
                if (sino != "si" && sino != "no")
                {
                    Console.Clear();
                    Console.WriteLine("Debe ingresar si o no....");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    repetir = true;
                }
            }
            return sino;
        }
        public double totalimpuestos(double suma)
        {
            double sumaimpuestos = suma + impuestos();
            return sumaimpuestos = Math.Round(sumaimpuestos,2);
        }

        public double impuestos()
        {
            double impuesto = IVA() + ISR();
            return impuesto = Math.Round(impuesto,2);
        }
        public double IVA()
        {
            double iva = suma * 0.12;
            return iva = Math.Round(iva,2);
        }
        public double ISR()
        {
            double isr = suma * 0.05;
            return isr = Math.Round(isr, 2);
        }
        public void imprimirfactura(string nit, string nombrecliente, double suma, string[] productofac,string email, string efeotar, int puntos, int totalproducto, string[] sumaaproducto)
        {
            Console.Clear();
            Console.WriteLine("-------------------------PublicMart------------------------- \n");
            Console.WriteLine("Fecha de la factura: " + (DateTime.Now.ToString("dd/MM/yyyy")));
            Console.WriteLine("Número de nit " + nit);
            Console.WriteLine("Nombre del cliente: " + nombrecliente + "\n");
            Console.WriteLine("---------------------------Lista---------------------------- \n");
            Console.WriteLine(productofac[0] + "" + sumaaproducto[0]);
            Console.WriteLine(productofac[1] + "" + sumaaproducto[1]);
            Console.WriteLine(productofac[2] + "" + sumaaproducto[2]);
            Console.WriteLine(productofac[3] + "" + sumaaproducto[3]);
            Console.WriteLine(productofac[4] + "" + sumaaproducto[4] + "\n");
            Console.WriteLine("-------------------------Información------------------------\n");
            Console.WriteLine("El subtotal es: Q" + suma);
            Console.WriteLine("La cantidad de productos es: " + totalproducto);
            Console.WriteLine("Una copia de la factura se enviará al correo: " + email);
            Console.WriteLine("El método de pago es: " + efeotar + "\n");
            if (efeotar == "Tarjeta de credito")
            {
                Console.WriteLine("El total de puntos  acumulados es: " + puntos + "\n");
            }
            Console.WriteLine("--------------------------Impuestos------------------------\n");
            Console.WriteLine("Impuestos de IVA: Q" + IVA());
            Console.WriteLine("Impuestos de IRS: Q" + ISR());
            Console.WriteLine("Los total de los impuestos es: Q" + impuestos());
            Console.WriteLine("El total incluyendo impuestos es: Q" + (suma + impuestos()) + "\n");
            Console.WriteLine("----------------------Factura No." + numfactura(puntos, totalproducto) + "----------------------");
        }
        public string numfactura(int puntos, int cantidad)
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 1000);
            int numerofactura = (((2 * num) + (puntos * puntos)) + (2021 * cantidad)) % 10000;
            string numeroCadena = numerofactura.ToString().PadLeft(4, '0');
            return numeroCadena;
        }
        

       
    }
}
