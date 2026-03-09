using System;
using System.Text.RegularExpressions;

class InvoiceUpdate
{
    static void Main()
    {
        Console.Write("Enter Current Invoice Number (e.g., CAP-123): ");
        string invoice = Console.ReadLine();

        Console.Write("Enter Increment Value: ");
        int increment = int.Parse(Console.ReadLine());

        Match match = Regex.Match(invoice, @"CAP-(\d+)");

        if (match.Success)
        {
            int currentNumber = int.Parse(match.Groups[1].Value);

            int newNumber = currentNumber + increment;

            string updatedInvoice = "CAP-" + newNumber;

            Console.WriteLine("Updated Invoice Number: " + updatedInvoice);
        }
        else
        {
            Console.WriteLine("Invalid Invoice Format!");
        }
    }
}
