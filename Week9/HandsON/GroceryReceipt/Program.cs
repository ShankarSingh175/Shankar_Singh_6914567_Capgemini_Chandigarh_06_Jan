using System;
using System.Collections.Generic;
using System.Globalization;

abstract class GroceryReceiptBase2
{
    public Dictionary<string, decimal> Prices { get; set; }
    public Dictionary<string, int> Discounts { get; set; }

    public GroceryReceiptBase2(Dictionary<string, decimal> prices, Dictionary<string, int> discounts)
    {
        Prices = prices;
        Discounts = discounts;
    }

    public abstract IEnumerable<(string fruit, decimal price, decimal total)>
    Calculate(List<Tuple<string, int>> shoppingList);
}

class GroceryReceipt2 : GroceryReceiptBase2
{
    public GroceryReceipt2(Dictionary<string, decimal> prices, Dictionary<string, int> discounts)
        : base(prices, discounts)
    {
    }

    public override IEnumerable<(string fruit, decimal price, decimal total)>
    Calculate(List<Tuple<string, int>> shoppingList)
    {
        List<(string fruit, decimal price, decimal total)> result =
            new List<(string fruit, decimal price, decimal total)>();

        foreach (var item in shoppingList)
        {
            string fruit = item.Item1;
            int quantity = item.Item2;

            decimal price = Prices[fruit];

            int discount = 0;
            if (Discounts.ContainsKey(fruit))
                discount = Discounts[fruit];

            int payableQuantity = quantity - (quantity / 3) * discount;
            decimal total = payableQuantity * price;

            result.Add((fruit, price, total));
        }

        return result;
    }
}

class Solution2
{
    public static void Main(string[] args)
    {
        Dictionary<string, decimal> prices = new Dictionary<string, decimal>()
        {
            { "Apple", 10.0m },
            { "Banana", 5.0m },
            { "Orange", 8.0m }
        };

        Dictionary<string, int> discounts = new Dictionary<string, int>()
        {
            { "Apple", 1 },
            { "Banana", 1 }
        };

        List<Tuple<string, int>> boughtItems = new List<Tuple<string, int>>()
        {
            new Tuple<string, int>("Apple", 5),
            new Tuple<string, int>("Banana", 6),
            new Tuple<string, int>("Orange", 3)
        };

        GroceryReceipt2 g = new GroceryReceipt2(prices, discounts);

        var result = g.Calculate(boughtItems);

        foreach (var x in result)
        {
            Console.WriteLine($"{x.fruit} {x.price.ToString("0.0", new NumberFormatInfo { NumberDecimalSeparator = "." })} {x.total.ToString("0.0", new NumberFormatInfo { NumberDecimalSeparator = "." })}");
        }
    }
}