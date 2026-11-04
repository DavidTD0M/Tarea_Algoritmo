using System;

const int PIN = 2586;
const int MAX_INTENTOS = 3;

const decimal MONTO_MIN = 5000m;
const decimal MONTO_MAX = 500000m;
const int PLAZO_MIN = 6;
const int PLAZO_MAX = 60;

decimal saldo = 10000m;
int cantidadDepositos = 0;
int cantidadRetiros = 0;
int opcion;

do
{
    Console.WriteLine("\n=== Cooperativa Ahorro Seguro ===");
    Console.WriteLine("1. Cajero automático");
    Console.WriteLine("2. Simulador de préstamo");
    Console.WriteLine("3. Salir");

    opcion = LeerEnteroEnRango("Seleccione una opción: ", 1, 3);

    switch (opcion)
    {
        case 1:
            UsarCajero();
            break;

        case 2:
            SimularPrestamo();
            break;

        case 3:
            Console.WriteLine("\nGracias por utilizar Cooperativa Ahorro Seguro.");
            break;
    }
}
while (opcion != 3);

Console.WriteLine("\nPrograma finalizado.");

void UsarCajero()
{
    Console.WriteLine("\n--- Cajero automático ---");

    bool accesoConcedido = false;

    for (int intento = 1; intento <= MAX_INTENTOS; intento++)
    {
        Console.Write("Ingrese su PIN: ");
        string entradaPin = Console.ReadLine() ?? "";

        if (int.TryParse(entradaPin, out int pinIngresado) && pinIngresado == PIN)
        {
            Console.WriteLine("PIN correcto. Acceso concedido.");
            accesoConcedido = true;
            break;
        }

        Console.WriteLine($"PIN incorrecto. Intento {intento} de {MAX_INTENTOS}.");
    }

    if (!accesoConcedido)
    {
        Console.WriteLine("Se ha excedido el número máximo de intentos. Acceso denegado.");
        return;
    }

    int opcionCajero;

    do
    {
        Console.WriteLine("\n--- Menú del cajero ---");
        Console.WriteLine("1. Consultar saldo");
        Console.WriteLine("2. Depositar");
        Console.WriteLine("3. Retirar");
        Console.WriteLine("4. Salir");

        opcionCajero = LeerEnteroEnRango("Seleccione una opción: ", 1, 4);

        switch (opcionCajero)
        {
            case 1:
                Console.WriteLine($"Su saldo actual es: RD$ {saldo:N2}");
                break;

            case 2:
                decimal montoDeposito = LeerDecimalEnRango(
                    "Monto a depositar: RD$ ",
                    0.01m,
                    decimal.MaxValue);

                saldo += montoDeposito;
                cantidadDepositos++;
                Console.WriteLine($"Depósito exitoso. Nuevo saldo: RD$ {saldo:N2}");
                break;

            case 3:
                if (saldo < 100m)
                {
                    Console.WriteLine("No tiene saldo suficiente para retirar un múltiplo de RD$ 100.");
                    break;
                }

                decimal montoRetiro;

                while (true)
                {
                    montoRetiro = LeerDecimalEnRango(
                        "Monto a retirar (múltiplos de RD$ 100): RD$ ",
                        0.01m,
                        saldo);

                    if (montoRetiro % 100m == 0)
                    {
                        break;
                    }

                    Console.WriteLine("El retiro debe ser un múltiplo de RD$ 100.");
                }

                saldo -= montoRetiro;
                cantidadRetiros++;
                Console.WriteLine($"Retiro exitoso. Nuevo saldo: RD$ {saldo:N2}");
                break;

            case 4:
                Console.WriteLine("\nSaliendo del cajero...");
                Console.WriteLine($"Depósitos realizados: {cantidadDepositos}");
                Console.WriteLine($"Retiros realizados: {cantidadRetiros}");
                break;
        }
    }
    while (opcionCajero != 4);
}

void SimularPrestamo()
{
    string repetirPrestamo;

    do
    {
        Console.WriteLine("\n--- Simulador de préstamo ---");

        decimal monto = LeerDecimalEnRango(
            $"Monto del préstamo (RD$ {MONTO_MIN:N0} a RD$ {MONTO_MAX:N0}): RD$ ",
            MONTO_MIN,
            MONTO_MAX);

        int plazo = LeerEnteroEnRango(
            $"Plazo en meses ({PLAZO_MIN} a {PLAZO_MAX}): ",
            PLAZO_MIN,
            PLAZO_MAX);

        string categoria;

        do
        {
            Console.Write("Categoría del socio (A, B o C): ");
            categoria = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();

            if (categoria != "A" && categoria != "B" && categoria != "C")
            {
                Console.WriteLine("Categoría inválida. Escriba A, B o C.");
            }
        }
        while (categoria != "A" && categoria != "B" && categoria != "C");

        decimal tasaAnual;

        switch (categoria)
        {
            case "A":
                tasaAnual = 0.12m;
                break;

            case "B":
                tasaAnual = 0.15m;
                break;

            default:
                tasaAnual = 0.18m;
                break;
        }

        double tasaMensualCalculo = (double)tasaAnual / 12;
        double factor = Math.Pow(1 + tasaMensualCalculo, plazo);

        decimal cuota = (decimal)(
            (double)monto * tasaMensualCalculo * factor / (factor - 1));

        decimal saldoPrestamo = monto;
        decimal totalIntereses = 0m;
        decimal totalPagado = 0m;
        decimal totalCapital = 0m;

        Console.WriteLine("\n--- Resumen del préstamo ---");
        Console.WriteLine($"Monto: RD$ {monto:N2}");
        Console.WriteLine($"Categoría: {categoria}");
        Console.WriteLine($"Tasa anual: {tasaAnual:P0}");
        Console.WriteLine($"Tasa mensual: {tasaMensualCalculo:P4}");
        Console.WriteLine($"Plazo: {plazo} meses");
        Console.WriteLine($"Cuota mensual aproximada: RD$ {cuota:N2}");

        Console.WriteLine("\n--- Tabla de amortización ---");
        Console.WriteLine("Mes\tCuota\t\tInterés\t\tCapital\t\tSaldo");

        for (int mes = 1; mes <= plazo; mes++)
        {
            decimal interes = Math.Round(
                saldoPrestamo * (decimal)tasaMensualCalculo,
                2,
                MidpointRounding.AwayFromZero);

            decimal abonoCapital = Math.Round(
                cuota - interes,
                2,
                MidpointRounding.AwayFromZero);

            decimal cuotaActual = Math.Round(
                cuota,
                2,
                MidpointRounding.AwayFromZero);

            if (mes == plazo)
            {
                abonoCapital = saldoPrestamo;
                cuotaActual = interes + abonoCapital;
            }

            saldoPrestamo = Math.Round(
                saldoPrestamo - abonoCapital,
                2,
                MidpointRounding.AwayFromZero);

            totalIntereses += interes;
            totalCapital += abonoCapital;
            totalPagado += cuotaActual;

            Console.WriteLine(
                $"{mes}\tRD$ {cuotaActual:N2}\tRD$ {interes:N2}\t" +
                $"RD$ {abonoCapital:N2}\tRD$ {saldoPrestamo:N2}");
        }

        Console.WriteLine("\n--- Totales del préstamo ---");
        Console.WriteLine($"Capital pagado: RD$ {totalCapital:N2}");
        Console.WriteLine($"Intereses pagados: RD$ {totalIntereses:N2}");
        Console.WriteLine($"Total pagado: RD$ {totalPagado:N2}");
        Console.WriteLine($"Saldo pendiente: RD$ {saldoPrestamo:N2}");

        do
        {
            Console.Write("\n¿Desea simular otro préstamo? (S/N): ");
            repetirPrestamo = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();

            if (repetirPrestamo != "S" && repetirPrestamo != "N")
            {
                Console.WriteLine("Respuesta inválida. Escriba S o N.");
            }
        }
        while (repetirPrestamo != "S" && repetirPrestamo != "N");
    }
    while (repetirPrestamo == "S");
}

int LeerEnteroEnRango(string mensaje, int minimo, int maximo)
{
    while (true)
    {
        Console.Write(mensaje);
        string entrada = Console.ReadLine() ?? "";

        if (int.TryParse(entrada, out int valor) &&
            valor >= minimo &&
            valor <= maximo)
        {
            return valor;
        }

        Console.WriteLine($"Entrada inválida. Escriba un número entre {minimo} y {maximo}.");
    }
}

decimal LeerDecimalEnRango(string mensaje, decimal minimo, decimal maximo)
{
    while (true)
    {
        Console.Write(mensaje);
        string entrada = Console.ReadLine() ?? "";

        if (decimal.TryParse(entrada, out decimal valor) &&
            valor >= minimo &&
            valor <= maximo)
        {
            return valor;
        }

        Console.WriteLine($"Entrada inválida. El valor debe estar entre {minimo:N2} y {maximo:N2}.");
    }
}
