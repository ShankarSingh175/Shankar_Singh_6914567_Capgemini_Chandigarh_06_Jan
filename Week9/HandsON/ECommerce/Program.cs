using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;

interface ICategory
{
    int Id { get; set; }
    string Name { get; set; }
    List<IProduct> Products { get; set; }
    void AddProduct(IProduct product);
}

interface IProduct
{
    int Id { get; set; }
    string Name { get; set; }
    decimal Price { get; set; }
}

interface ICompany
{
    string GetTopCategoryNameByProductCount();
    List<IProduct> GetProductsBelongsToMultipleCategory();
    (string categoryName, decimal totalValue) GetTopCategoryBySumOfProductPrices();
    List<(ICategory category, decimal totalValue)> GetCategoriesWithSumOfTheProductPrices();
}

class Product : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}

class Category : ICategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<IProduct> Products { get; set; }

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
        Products = new List<IProduct>();
    }

    public void AddProduct(IProduct product)
    {
        Products.Add(product);
    }
}

class Company : ICompany
{
    public int Id { get; set; }
    public string Name { get; set; }

    private List<ICategory> categories = new List<ICategory>();

    public Company(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void AddCategory(ICategory category)
    {
        categories.Add(category);
    }

    public string GetTopCategoryNameByProductCount()
    {
        return categories
            .OrderByDescending(c => c.Products.Count)
            .FirstOrDefault()?.Name;
    }

    public List<IProduct> GetProductsBelongsToMultipleCategory()
    {
        return categories
            .SelectMany(c => c.Products)
            .GroupBy(p => p.Id)
            .Where(g => g.Count() > 1)
            .Select(g => g.First())
            .ToList();
    }

    public (string categoryName, decimal totalValue) GetTopCategoryBySumOfProductPrices()
    {
        var result = categories
            .Select(c => new
            {
                Category = c,
                Total = c.Products.Sum(p => p.Price)
            })
            .OrderByDescending(x => x.Total)
            .FirstOrDefault();

        if (result == null)
            return ("", 0);

        return (result.Category.Name, result.Total);
    }

    public List<(ICategory category, decimal totalValue)> GetCategoriesWithSumOfTheProductPrices()
    {
        return categories
            .Select(c => (category: c, totalValue: c.Products.Sum(p => p.Price)))
            .ToList();
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = Console.Out;

        var company = new Company(1, "Company 1");

        List<IProduct> products = new List<IProduct>();
        List<ICategory> categories = new List<ICategory>();

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        for (int i = 1; i <= n; i++)
        {
            var a = Console.ReadLine().Trim().Split(" ");
            products.Add(new Product(Convert.ToInt32(a[0]), a[1], Convert.ToDecimal(a[2])));
        }

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        for (int i = 1; i <= m; i++)
        {
            var a = Console.ReadLine().Trim().Split(" ");
            categories.Add(new Category(Convert.ToInt32(a[0]), a[1]));
        }

        int p = Convert.ToInt32(Console.ReadLine().Trim());

        for (int i = 1; i <= p; i++)
        {
            var a = Console.ReadLine().Trim().Split(" ");

            var c = categories.FirstOrDefault(x => x.Id == Convert.ToInt32(a[0]));
            var pp = products.FirstOrDefault(x => x.Id == Convert.ToInt32(a[1]));

            if (c != null && pp != null)
            {
                c.AddProduct(pp);
            }
        }

        foreach (var item in categories)
        {
            company.AddCategory(item);
        }

        var topCategory = company.GetTopCategoryNameByProductCount();
        var commonProducts = company.GetProductsBelongsToMultipleCategory();
        var mostValuableCategory = company.GetTopCategoryBySumOfProductPrices();
        var categoriesWithTotalPrices = company.GetCategoriesWithSumOfTheProductPrices();

        textWriter.WriteLine("Top category:" + topCategory);

        textWriter.WriteLine("Common products:");
        foreach (var item in commonProducts)
        {
            textWriter.WriteLine(item.Name);
        }

        textWriter.WriteLine("Most valuable category:" + mostValuableCategory.categoryName
        + " " + mostValuableCategory.totalValue.ToString("0.0",
        new NumberFormatInfo() { NumberDecimalSeparator = "." }));

        foreach (var item in categoriesWithTotalPrices)
        {
            textWriter.WriteLine(item.category.Name + " " +
            item.totalValue.ToString("0.0",
            new NumberFormatInfo() { NumberDecimalSeparator = "." }));
        }
    }
}