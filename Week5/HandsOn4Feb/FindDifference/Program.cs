using System;
using System.Globalization;

class DateDifference
{
    static void Main()
    {
        Console.Write("Enter First Date (dd/MM/yyyy): ");
        string input1 = Console.ReadLine();

        Console.Write("Enter Second Date (dd/MM/yyyy): ");
        string input2 = Console.ReadLine();

        DateTime date1 = DateTime.ParseExact(input1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime date2 = DateTime.ParseExact(input2, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        TimeSpan difference = date2 - date1;

        Console.WriteLine("Output: " + Math.Abs(difference.Days) + " days");
    }
}
