using System;
using System.Collections.Generic;
using System.Linq;

public interface IProduct
{
    string Name { get; set; }
    string Category { get; set; }
    int Stock { get; set; }
    int Price { get; set; }
}

public interface IInventory
{
    void AddProduct(IProduct product);
    void RemoveProduct(IProduct product);
    int CalculateTotalValue();
    List<IProduct> GetProductsByCategory(string category);
    List<IProduct> SearchProductsByName(string name);
    List<(string, int)> GetProductsByCategoryWithCount();
    List<(string, List<IProduct>)> GetAllProductsByCategory();
}

public class Product : IProduct
{
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public int Stock { get; set; }
    public int Price { get; set; }
}

public class Inventory : IInventory
{
    private List<IProduct> products = new List<IProduct>();

    public void AddProduct(IProduct product)
    {
        products.Add(product);
    }

    public void RemoveProduct(IProduct product)
    {
        products.Remove(product);
    }

    public int CalculateTotalValue()
    {
        int total = 0;

        foreach (var p in products)
        {
            total += p.Price * p.Stock;
        }

        return total;
    }

    public List<IProduct> GetProductsByCategory(string category)
    {
        List<IProduct> result = new List<IProduct>();

        foreach (var p in products)
        {
            if (p.Category == category)
                result.Add(p);
        }

        return result;
    }

    public List<IProduct> SearchProductsByName(string name)
    {
        List<IProduct> result = new List<IProduct>();

        foreach (var p in products)
        {
            if (p.Name.Contains(name))
                result.Add(p);
        }

        return result;
    }

    public List<(string, int)> GetProductsByCategoryWithCount()
    {
        Dictionary<string, int> map = new Dictionary<string, int>();

        foreach (var p in products)
        {
            if (map.ContainsKey(p.Category))
                map[p.Category] += p.Stock;
            else
                map[p.Category] = p.Stock;
        }

        List<(string, int)> result = new List<(string, int)>();

        foreach (var item in map)
        {
            result.Add((item.Key, item.Value));
        }

        return result;
    }

    public List<(string, List<IProduct>)> GetAllProductsByCategory()
    {
        Dictionary<string, List<IProduct>> map = new Dictionary<string, List<IProduct>>();

        foreach (var p in products)
        {
            if (!map.ContainsKey(p.Category))
                map[p.Category] = new List<IProduct>();

            map[p.Category].Add(p);
        }

        List<(string, List<IProduct>)> result = new List<(string, List<IProduct>)>();

        foreach (var item in map)
        {
            result.Add((item.Key, item.Value));
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Inventory inventory = new Inventory();

        inventory.AddProduct(new Product { Name = "Laptop", Category = "Electronics", Stock = 5, Price = 50000 });
        inventory.AddProduct(new Product { Name = "Mouse", Category = "Electronics", Stock = 10, Price = 500 });
        inventory.AddProduct(new Product { Name = "Chair", Category = "Furniture", Stock = 3, Price = 3000 });

        Console.WriteLine("Total Value: " + inventory.CalculateTotalValue());
    }
}