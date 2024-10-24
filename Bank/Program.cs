using System;
bool continuar = true;
decimal saleClient = 0;
List<string> movements = new List<string>();
List<string> movementsIncomes = new List<string>();
List<string> movementsOutcomes = new List<string>();

List<string> accountNumbers = new List<string> { "12341234", "987654321", "1111111" };
List<string> accountPins = new List<string> { "1234", "9876", "1111" };

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Autenticación
bool authenticated = false;
while (!authenticated)
{
    Console.WriteLine("Introduce your account number:");
    string accountNumber = Console.ReadLine();

    Console.WriteLine("Introduce your PIN:");
    string pin = Console.ReadLine();

    for (int i = 0; i < accountNumbers.Count; i++)
    {
        if (accountNumbers[i] == accountNumber && accountPins[i] == pin)
        {
            authenticated = true;
            Console.WriteLine("Authentication ok");
            break;
        }
    }
    if (!authenticated)
    {
        Console.WriteLine("Invalid account number or PIN. try again.");
    }
}


// menú
while (continuar)
{

    Console.WriteLine("****************************");
    Console.WriteLine("Welcome to BankExercice");
    Console.WriteLine("Select one option please:");
    Console.WriteLine("1 - Money income");
    Console.WriteLine("2 - Money outcome");
    Console.WriteLine("3 - List all movements");
    Console.WriteLine("4 - List incomes");
    Console.WriteLine("5 - List outcomes");
    Console.WriteLine("6 - Show current money");
    Console.WriteLine("7 - Exit");
    Console.WriteLine("****************************");

    // Leer opción del usuario y validar las opciones correctas del menu
    int options;
    if (!int.TryParse(Console.ReadLine(), out options) || options < 1 || options > 7)
    {
        Console.WriteLine("Invalid option. Please select a valid option (1-7).");
        continue;
    }

    switch (options)
    {
        case 1:
            // Ingresar dinero
            Console.WriteLine("Introduce money for income:");
            decimal moneyIncome;
            // Validar que el ingreso sea un número decimal
            while (!decimal.TryParse(Console.ReadLine(), out moneyIncome) || moneyIncome <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a valid positive number.");
            }

            saleClient = saleClient + moneyIncome;
            movements.Add($"Income: +{moneyIncome:0.00}€");
            movementsIncomes.Add($"+{moneyIncome:0.00}€");

            Console.WriteLine($"Money income registered. Current balance: {saleClient:0.00}€");
            break;

        case 2:
            // Retirada de dinero
            Console.WriteLine("Introduce money for outcome:");
            decimal moneyOutcome;
            // Validar que la retirada sea un número decimal
            while (!decimal.TryParse(Console.ReadLine(), out moneyOutcome) || moneyOutcome <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a valid positive number.");
            }

            if (moneyOutcome <= saleClient)
            {
                saleClient = saleClient - moneyOutcome;
                movements.Add($"Outcome: -{moneyOutcome:0.00}€");
                movementsOutcomes.Add($"-{moneyOutcome:0.00}€");

                Console.WriteLine($"Money outcome registered. Current balance: {saleClient:0.00}€");
            }
            else
            {
                Console.WriteLine("Insufficient balance for this withdrawal.");
            }
            break;

        case 3:
            // Listar todos los movimientos
            Console.WriteLine("All movements:");
            if (movements.Count == 0)
            {
                Console.WriteLine("No movements recorded.");
            }
            else
            {
                foreach (string movement in movements)
                {
                    Console.WriteLine(movement);
                }
            }
            break;

        case 4:
            // Listar ingresos
            Console.WriteLine("Income movements:");
            if (movementsIncomes.Count == 0)
            {
                Console.WriteLine("No income movements recorded.");
            }
            else
            {
                foreach (string income in movementsIncomes)
                {
                    Console.WriteLine(income);
                }
            }
            break;

        case 5:
            // Listar retiradas
            Console.WriteLine("Outcome movements:");
            if (movementsOutcomes.Count == 0)
            {
                Console.WriteLine("No outcome movements recorded.");
            }
            else
            {
                foreach (string outcome in movementsOutcomes)
                {
                    Console.WriteLine(outcome);
                }
            }
            break;

        case 6:
            // Mostrar saldo actual
            Console.WriteLine($"Current balance: {saleClient:0.00}€");
            break;

        case 7:
            // Salir del programa
            continuar = false;
            break;

        default:
            Console.WriteLine("Invalid option, please try again.");
            break;
    }

    if (continuar)
    {
        // Preguntar si se quiere continuar con otra operación
        Console.WriteLine("Would you like to perform another operation? (y/n)");
        string response = Console.ReadLine().ToLower();
        if (response != "y")
        {
            Console.WriteLine($"Exiting... Your current balance is: {saleClient:0.00}€");
            continuar = false;
        }
    }
}

Console.WriteLine("Program finished.");
