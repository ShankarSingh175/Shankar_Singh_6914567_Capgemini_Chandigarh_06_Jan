using System;

class VATCalculation
{
    static void Main()
    {
        Console.Write("Enter Product Type (M/V/C/D): ");
        char product = Convert.ToChar(Console.ReadLine().ToUpper());

        Console.Write("Enter Product Amount: ");
        double amount = Convert.ToDouble(Console.ReadLine());

        double vatRate = 0;

        switch (product)
        {
            case 'M':
                vatRate = 5;
                break;
            case 'V':
                vatRate = 12;
                break;
            case 'C':
                vatRate = 6.25;
                break;
            case 'D':
                vatRate = 6;
                break;
            default:
                Console.WriteLine("Invalid Product Type");
                return;
        }

        double vatAmount = amount * vatRate / 100;
        double totalAmount = amount + vatAmount;

        Console.WriteLine("VAT %: " + vatRate + "%");
        Console.WriteLine("VAT Amount: " + vatAmount);
        Console.WriteLine("Total Amount (Including VAT): " + totalAmount);
    }
}
