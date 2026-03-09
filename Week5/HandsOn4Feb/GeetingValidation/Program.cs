using System;
using System.Text.RegularExpressions;

class GreetingValidation
{
    static void Main()
    {
        Console.Write("Enter Greeting (e.g., Hi how are you Dear): ");
        string input1 = Console.ReadLine();

        Console.Write("Enter Name (More than 15 characters): ");
        string input2 = Console.ReadLine();

        string pattern = @"^Hi how are you Dear\s([A-Za-z]{16,})$";

        string finalInput = input1 + " " + input2;

        if (Regex.IsMatch(finalInput, pattern))
        {
            Console.WriteLine("Output: " + finalInput);
        }
        else
        {
            Console.WriteLine("Invalid format OR Name must be more than 15 characters.");
        }
    }
}
