using System;
using System.Collections.Generic;

bool continuar = true;

List<decimal> accountBalances = new List<decimal> { 0, 0, 0 }; // Saldos para cada cuenta
List<List<string>> movements = new List<List<string>> { new List<string>(), new List<string>(), new List<string>() };
List<List<string>> movementsIncomes = new List<List<string>> { new List<string>(), new List<string>(), new List<string>() };
List<List<string>> movementsOutcomes = new List<List<string>> { new List<string>(), new List<string>(), new List<string>() };

List<string> accountNumbers = new List<string> { "12341234", "987654321", "1111111" };
List<string> accountPins = new List<string> { "1234", "9876", "1111" };

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Autenticación
int currentAccountIndex = -1;
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
            currentAccountIndex = i; // Guardo el índice de la cuenta autenticada
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

    int options;
    if (!int.TryParse(Console.ReadLine(), out options) || options < 1 || options > 7)
    {
        Console.WriteLine("Invalid option. Please select a valid option (1-7).");
        continue;
    }

    switch (options)
    {
        case 1:
            Console.WriteLine("Introduce money for income:");
            decimal moneyIncome;
            while (!decimal.TryParse(Console.ReadLine(), out moneyIncome) || moneyIncome <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a valid positive number.");
            }

            accountBalances[currentAccountIndex] += moneyIncome;
            movements[currentAccountIndex].Add($"Income: +{moneyIncome:0.00}€");
            movementsIncomes[currentAccountIndex].Add($"+{moneyIncome:0.00}€");

            Console.WriteLine($"Money income registered. Current balance: {accountBalances[currentAccountIndex]:0.00}€");
            break;

        case 2:
            Console.WriteLine("Introduce money for outcome:");
            decimal moneyOutcome;
            while (!decimal.TryParse(Console.ReadLine(), out moneyOutcome) || moneyOutcome <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a valid positive number.");
            }

            if (moneyOutcome <= accountBalances[currentAccountIndex])
            {
                accountBalances[currentAccountIndex] -= moneyOutcome;
                movements[currentAccountIndex].Add($"Outcome: -{moneyOutcome:0.00}€");
                movementsOutcomes[currentAccountIndex].Add($"-{moneyOutcome:0.00}€");

                Console.WriteLine($"Money outcome registered. Current balance: {accountBalances[currentAccountIndex]:0.00}€");
            }
            else
            {
                Console.WriteLine("Insufficient balance for this withdrawal.");
            }
            break;

        case 3:
            Console.WriteLine("All movements:");
            if (movements[currentAccountIndex].Count == 0)
            {
                Console.WriteLine("No movements recorded.");
            }
            else
            {
                foreach (string movement in movements[currentAccountIndex])
                {
                    Console.WriteLine(movement);
                }
            }
            break;

        case 4:
            Console.WriteLine("Income movements:");
            if (movementsIncomes[currentAccountIndex].Count == 0)
            {
                Console.WriteLine("No income movements recorded.");
            }
            else
            {
                foreach (string income in movementsIncomes[currentAccountIndex])
                {
                    Console.WriteLine(income);
                }
            }
            break;

        case 5:
            Console.WriteLine("Outcome movements:");
            if (movementsOutcomes[currentAccountIndex].Count == 0)
            {
                Console.WriteLine("No outcome movements recorded.");
            }
            else
            {
                foreach (string outcome in movementsOutcomes[currentAccountIndex])
                {
                    Console.WriteLine(outcome);
                }
            }
            break;

        case 6:
            Console.WriteLine($"Current balance: {accountBalances[currentAccountIndex]:0.00}€");
            break;

        case 7:
            continuar = false;
            break;

        default:
            Console.WriteLine("Invalid option, please try again.");
            break;
    }

    if (continuar)
    {
        Console.WriteLine("Would you like to perform another operation? (y/n)");
        string response = Console.ReadLine().ToLower();
        if (response != "y")
        {
            Console.WriteLine($"Exiting... Your current balance is: {accountBalances[currentAccountIndex]:0.00}€");
            continuar = false;
        }
    }
}

Console.WriteLine("Program finished.");
