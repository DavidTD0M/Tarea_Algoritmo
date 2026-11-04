using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
//Cosas para el ejercicio 1
const int PIN = 2586;
const int max_intentos = 3;
int ingresado = 0;
int opcion = 0;
decimal saldo = 10000.00m;
int cantidadDepositos = 0;
int cantidadRetiros = 0;

//Cosas para el ejercicio 2
const decimal monto_min = 5000m;
const decimal monto_max = 500000m;
const int plazo_max = 60;
const int plazo_min = 6;

do // Bucle principal del programa
{
    Console.WriteLine("=== Cooperativa Ahorro Seguro ===");
    Console.WriteLine("1. Cajero automatico");
    Console.WriteLine("2. Simulador de prestamo");
    Console.WriteLine("3. Salir");
    Console.Write("Seleccione una opción: ");

    if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 3) // Validación de entrada 
    {
        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
        continue; // Volver al inicio si la opción es inválida
    }

    switch(opcion) // Switch para la opcion que se seleccione
    {
        case 1: //Cajero Automatico
            Console.WriteLine("\n ---- Cajero Automático ----");

            for (int intentos = 1; intentos <= max_intentos; intentos++)
            {
                Console.Write("Ingrese su PIN: ");
                ingresado = Convert.ToInt32(Console.ReadLine());
                if (ingresado == PIN)
                {
                    Console.WriteLine("PIN correcto. Acceso concedido."); //PIN Correcto

                    int opcionCajero;

                    do
                    {
                        Console.WriteLine("\n >>> Cajero Automatico <<<");
                        Console.WriteLine("1. Consultar saldo\n2. Depositar\n3. Retirar\n 4. Salir");
                        Console.Write("Seleccione una opcion: ");
                        opcionCajero = Convert.ToInt32(Console.ReadLine());

                        switch (opcionCajero)
                        {
                            case 1: //Saldo
                                Console.WriteLine($"Su saldo actual es: RD$" + saldo);
                                break;

                            case 2: //Depositar
                                decimal montoDeposito;
                                Console.Write("Monto a depositar: RD$ ");
                                montoDeposito = Convert.ToDecimal(Console.ReadLine());

                                while (montoDeposito < 0)
                                {
                                    Console.Write("Cantidad no validad.\nMonto a Depositar: RD$");
                                }

                                if (montoDeposito > 0)
                                {
                                    saldo += montoDeposito;
                                    cantidadDepositos++;
                                    Console.WriteLine($"Deposito exitoso. El nuevo saldo es: RD$" + saldo);
                                }
                                break;

                            case 3: //Retirar
                                decimal montoRetiro;
                                Console.Write("Monto a retirar: RD$");
                                montoRetiro = Convert.ToDecimal(Console.ReadLine());

                                while (montoRetiro > saldo || montoRetiro <= 0 || montoRetiro % 100 != 0) ;
                                {
                                    Console.WriteLine($"Cantidad no validad.\nMonto a Retirar: RD$");
                                }

                                if (montoRetiro > 0)
                                {
                                    saldo -= montoRetiro;
                                    cantidadRetiros++;
                                    Console.WriteLine($"Retiro exitoso. Nuevo saldo: RD$" + saldo);
                                }
                                break;
                            case 4: //Salir
                                Console.WriteLine("\nSaliendo del sistema...");
                                break;
                        }
                        
                    } while (opcionCajero != 4);
                    break;
                }
                else
                {
                    Console.WriteLine($"PIN incorrecto. Intento {intentos} de {max_intentos}.");
                    if (intentos == max_intentos)
                    {
                           Console.WriteLine("Se ha excedido el número máximo de intentos. Acceso denegado.");
                    }
                }
            }
            break;
        case 2: //Simulador de prestamo
            // Lógica del ejercicio 2
            break;
        case 3:
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
            break;
        }
    } while (opcion != 3); // Continuar el bucle hasta que el usuario seleccione salir
