using System;
using System.Text.RegularExpressions;

class LocationUpdate
{
    static void Main()
    {
        Console.Write("Enter Current Invoice (e.g., CAP-HYD-1234): ");
        string invoice = Console.ReadLine();

        Console.Write("Enter New Location Code (e.g., BAN): ");
        string newLocation = Console.ReadLine();

        Match match = Regex.Match(invoice, @"(CAP-)([A-Z]+)(-\d+)");

        if (match.Success)
        {
            string prefix = match.Groups[1].Value;      
            string numericPart = match.Groups[3].Value; 

            string updatedInvoice = prefix + newLocation + numericPart;

            Console.WriteLine("Updated Invoice Number: " + updatedInvoice);
        }
        else
        {
            Console.WriteLine("Invalid Invoice Format!");
        }
    }
}
