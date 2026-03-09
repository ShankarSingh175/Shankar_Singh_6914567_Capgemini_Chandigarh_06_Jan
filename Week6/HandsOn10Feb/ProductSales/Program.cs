using System;
using System.Collections.Generic;
using System.Linq;

struct Product
{
    public string ProductID;
    public int TotalSales;
}

class ProductSales
{
    static void Main()
    {
        Dictionary<string, int> products = new Dictionary<string, int>();

        Console.WriteLine("Enter product records (ProductID-Amount). Type 'END' to stop:");

        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToUpper() == "END")
                break;

            string[] parts = input.Split('-');
            string id = parts[0];
            int amount = int.Parse(parts[1]);

            if (products.ContainsKey(id))
            {
                products[id] = Math.Max(products[id], amount);
            }
            else
            {
                products[id] = amount;
            }
        }

        var sortedProducts = products
                             .OrderByDescending(p => p.Value);

        foreach (var item in sortedProducts)
        {
            Console.WriteLine($"{item.Key}-{item.Value}");
        }
    }
}
