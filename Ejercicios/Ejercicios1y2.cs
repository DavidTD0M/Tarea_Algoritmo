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
const decimal MONTO_MIN = 5000m;
const decimal MONTO_MAX = 500000m;
const int PLAZO_MAX = 60;
const int PLAZO_MIN = 6;

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

    switch (opcion) // Switch para la opcion que se seleccione
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
                                Console.Write("Monto a depositar: RD$");
                                montoDeposito = Convert.ToDecimal(Console.ReadLine());

                                while (montoDeposito < 0)
                                {
                                    Console.Write("Cantidad no validad.\nMonto a Depositar: RD$");
                                    montoDeposito = Convert.ToDecimal(Console.ReadLine());
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

                                while (montoRetiro > saldo || montoRetiro <= 0 || montoRetiro % 100 != 0)
                                {
                                    Console.WriteLine($"Cantidad no validad.\nMonto a Retirar: RD$");
                                    montoRetiro = Convert.ToDecimal(Console.ReadLine());
                                }

                                if (montoRetiro > 0)
                                {
                                    saldo -= montoRetiro;
                                    cantidadRetiros++;
                                    Console.WriteLine($"Retiro exitoso. Nuevo saldo: RD$" + saldo);
                                }
                                break;
                            case 4: //Salir
                                Console.WriteLine($"Cantidad de depositos realizados: {cantidadDepositos}");
                                Console.WriteLine($"Cantidad de retiros realizados: {cantidadRetiros}");
                                Console.WriteLine($"Saldo final: RD$ {saldo}");
                                Console.WriteLine("\nSaliendo del sistema...");
                                break;
                            default: //Opcion invalida
                                Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
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
        case 2:
            {
                string repetirPrestamo;

                do
                {
                    decimal monto = 0m;
                    int plazo = 0;
                    string categoria = "";
                    decimal tasaAnual = 0;

                    // Validacion del monto
                    Console.WriteLine("\n--- SIMULADOR DE PRESTAMO ---");
                    Console.Write(
                        "Monto del prestamo (RD$5,000 a RD$500,000): RD$ ");

                    while (!decimal.TryParse(Console.ReadLine(), out monto) |   
                           monto < MONTO_MIN || monto > MONTO_MAX)
                    {
                        Console.Write(
                            "Monto invalido. Introduzca entre RD$5,000 y RD$500,000: RD$ ");
                    }

                    // Validacion del plazo
                    Console.Write("Plazo en meses (6 a 60): ");

                    while (!int.TryParse(Console.ReadLine(), out plazo) ||
                           plazo < PLAZO_MIN || plazo > PLAZO_MAX)
                    {
                        Console.Write(
                            "Plazo invalido. Introduzca entre 6 y 60 meses: ");
                    }

                    // Validacion de la categoria
                    Console.Write("Categoria del socio (A, B o C): ");
                    categoria = (Console.ReadLine() ?? "").Trim().ToUpper();

                    while (categoria != "A" &&
                           categoria != "B" &&
                           categoria != "C")
                    {
                        Console.Write(
                            "Categoria invalida. Escriba A, B o C: ");
                        categoria = (Console.ReadLine() ?? "").Trim().ToUpper();
                    }

                    // Asignacion de la tasa anual
                    switch (categoria)
                    {
                        case "A":
                            tasaAnual = 0.12m;
                            break;

                        case "B":
                            tasaAnual = 0.15m;
                            break;

                        case "C":
                            tasaAnual = 0.18m;
                            break;
                    }

                    // Calculo de la cuota mensual
                    decimal tasaMensual = tasaAnual / 12;
                    decimal factor = (decimal)Math.Pow(1 + (double)tasaMensual, plazo);

                    decimal cuota = monto *
                        (tasaMensual * factor) / (factor - 1);

                    decimal saldoPrestamo = monto;
                    decimal totalIntereses = 0;
                    decimal totalPagado = 0;
                    decimal totalCapital = 0;

                    Console.WriteLine("\n===== RESUMEN DEL PRESTAMO =====");
                    Console.WriteLine($"Monto: RD$ {monto:N2}");
                    Console.WriteLine($"Categoria: {categoria}");
                    Console.WriteLine($"Tasa anual: {tasaAnual:P0}");
                    Console.WriteLine($"Tasa mensual: {tasaMensual:P4}");
                    Console.WriteLine($"Plazo: {plazo} meses");
                    Console.WriteLine($"Cuota mensual aproximada: RD$ {cuota:N2}");

                    // Tabla de amortizacion
                    Console.WriteLine("\n===== TABLA DE AMORTIZACION =====");
                    Console.WriteLine(
                        "Mes\tCuota\t\tInteres\t\tCapital\t\tSaldo");

                    for (int mes = 1; mes <= plazo; mes++)
                    {
                        decimal interes = Math.Round(
                            saldoPrestamo * tasaMensual, 2);

                        decimal abonoCapital = Math.Round(
                            cuota - interes, 2);

                        decimal cuotaActual = Math.Round(cuota, 2);

                        // Ajustar la ultima cuota para cerrar el saldo
                        if (mes == plazo)
                        {
                            abonoCapital = saldoPrestamo;
                            cuotaActual = Math.Round(
                                interes + abonoCapital, 2);
                        }

                        saldoPrestamo = Math.Round(
                            saldoPrestamo - abonoCapital, 2);

                        if (Math.Abs(saldoPrestamo) < 0.01m)
                        {
                            saldoPrestamo = 0;
                        }

                        totalIntereses += interes;
                        totalCapital += abonoCapital;
                        totalPagado += cuotaActual;

                        Console.WriteLine(
                            $"{mes}\tRD$ {cuotaActual:N2}\t" +
                            $"RD$ {interes:N2}\t" +
                            $"RD$ {abonoCapital:N2}\t" +
                            $"RD$ {saldoPrestamo:N2}");
                    }

                    Console.WriteLine("\n===== TOTALES DEL PRESTAMO =====");
                    Console.WriteLine(
                        $"Capital pagado: RD$ {totalCapital:N2}");
                    Console.WriteLine(
                        $"Intereses pagados: RD$ {totalIntereses:N2}");
                    Console.WriteLine(
                        $"Total pagado: RD$ {totalPagado:N2}");
                    Console.WriteLine(
                        $"Saldo pendiente: RD$ {saldoPrestamo:N2}");

                    Console.Write(
                        "\nDesea simular otro prestamo? (S/N): ");

                    repetirPrestamo = (
                        Console.ReadLine() ?? "").Trim().ToUpper();

                    while (repetirPrestamo != "S" &&
                           repetirPrestamo != "N")
                    {
                        Console.Write(
                            "Respuesta invalida. Escriba S o N: ");

                        repetirPrestamo = (
                            Console.ReadLine() ?? "").Trim().ToUpper();
                    }

                } while (repetirPrestamo == "S");

                break;
            }

        case 3:
            Console.WriteLine("\nGracias por utilizar Cooperativa Ahorro Seguro.");
            break;
        default:
            Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
            break;
    }
    if (opcion != 3)
    {
        Console.Write("\nDesea regresar al menu principal? (S/N): ");
        string repetirMenu = (Console.ReadLine() ?? "").Trim().ToUpper();

        while (repetirMenu != "S" && repetirMenu != "N")
        {
            Console.Write("Respuesta invalida. Escriba S o N: ");
            repetirMenu = (Console.ReadLine() ?? "").Trim().ToUpper();
        }

        if (repetirMenu == "N")
        {
            opcion = 3;
            Console.WriteLine("\nPrograma finalizado.");
        }
    }
} while (opcion != 3); // Continuar el bucle hasta que el usuario seleccione salir



