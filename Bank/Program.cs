using System;
bool continuar = true;
decimal saleClient = 0;
List<string> movements = new List<string>();
List<string> movementsIncomes = new List<string>();
List<string> movementsOutcomes = new List<string>();

Console.OutputEncoding = System.Text.Encoding.UTF8;
while (continuar)  // Mientras continuar sea true, el bucle seguirá ejecutándose.
{
    //Crear menu

Console.WriteLine("Welcome to Bank");
Console.WriteLine("Select one Option please");
Console.WriteLine("1 - Money income -");
Console.WriteLine("2 - Money outcome");
Console.WriteLine("3 - List all movements");
Console.WriteLine("4 - List incomes");
Console.WriteLine("5 - List outcomes");
Console.WriteLine("6 - Show current money");
Console.WriteLine("7 - Exit");


 int options = Convert.ToInt32(Console.ReadLine());

switch (options)
{
    case 1:
        Console.WriteLine("Introduce money for income");
        decimal ingreso = Convert.ToDecimal(Console.ReadLine());
        saleClient = saleClient + ingreso;
            movements.Add($"movimientos registrados con ingreso de: {ingreso}");
            movementsIncomes.Add($"movimientos registrados con ingreso de: {ingreso}€");
            Console.WriteLine($"Money income: {saleClient:0.00}€");
 
         break;

    case 2:
        Console.WriteLine("Money outcome");
        Console.WriteLine("Introduce money for substrac");
        decimal reintegro = Convert.ToDecimal(Console.ReadLine());
        saleClient = saleClient - reintegro;
        Console.WriteLine($"Money income: {saleClient:0.00} €");

            movements.Add($"movemets recorded with income: {reintegro}€");
            movementsOutcomes.Add($"movemets recorded with income: {reintegro}");
            break;

    case 3:
        Console.WriteLine("3 - List all movements");
            foreach (string movement in movements)
            {
                Console.WriteLine(movement);
            }
            break;
    case 4:
        Console.WriteLine("List incomes");
            foreach (string movement in movementsIncomes)
            {
                Console.WriteLine(movement);
            }
            break;
    case 5:
        Console.WriteLine("List outcomes");
            foreach (string movement in movementsOutcomes)
            {
                Console.WriteLine(movement);
            }
            break;
    case 6:
        Console.WriteLine($"Show current money {saleClient:0.00}€");
        
        break;

    default:
            if(options >= 7) {  continuar = false; }
        
        break;
}
    if (continuar)
    {
        Console.WriteLine("Would you like to do other operation?");
        string response = Console.ReadLine().ToLower();
        if (response != "y")
        {
            Console.WriteLine($"You choise Exit... Your Current money is: {saleClient:0.00} €");
            continuar = false;

        }
    }
}
    
   