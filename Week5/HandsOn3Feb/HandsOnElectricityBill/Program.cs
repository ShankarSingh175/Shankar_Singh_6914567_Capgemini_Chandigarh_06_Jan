using System;
using System.Text.RegularExpressions;

class ElectricityBill
{
    static void Main()
    {
        Console.Write("Enter First Meter Reading (e.g., AAAAA12345): ");
        string input1 = Console.ReadLine();

        Console.Write("Enter Second Meter Reading (e.g., AAAAA23456): ");
        string input2 = Console.ReadLine();

        Console.Write("Enter Rate per Unit: ");
        int rate = int.Parse(Console.ReadLine());

        string number1 = Regex.Replace(input1, @"\D", "");
        string number2 = Regex.Replace(input2, @"\D", "");

        int reading1 = int.Parse(number1);
        int reading2 = int.Parse(number2);

        int difference = Math.Abs(reading2 - reading1);

        int billAmount = difference * rate;

        Console.WriteLine("Electricity Bill Amount: " + billAmount);
    }
}
