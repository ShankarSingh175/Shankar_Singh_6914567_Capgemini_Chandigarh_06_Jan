using System;
using System.Collections.Generic;

public class Book
{
    public int Id;
    public string Title;
    public string Author;
    public string Category;
    public int Price;

    public Book(int id, string title, string author, string category, int price)
    {
        Id = id;
        Title = title;
        Author = author;
        Category = category;
        Price = price;
    }
}

public class LibrarySystem
{
    private Dictionary<Book, int> bookInventory = new Dictionary<Book, int>();

    public void AddBook(Book book, int quantity)
    {
        if (bookInventory.ContainsKey(book))
            bookInventory[book] += quantity;
        else
            bookInventory.Add(book, quantity);
    }

    public void RemoveBook(int bookId, int quantity)
    {
        Book foundBook = null;

        foreach (var item in bookInventory)
        {
            if (item.Key.Id == bookId)
            {
                foundBook = item.Key;
                break;
            }
        }

        if (foundBook != null)
        {
            bookInventory[foundBook] -= quantity;

            if (bookInventory[foundBook] <= 0)
                bookInventory.Remove(foundBook);
        }
    }

    public int CalculateTotalPrice()
    {
        int total = 0;

        foreach (var item in bookInventory)
        {
            total += item.Key.Price * item.Value;
        }

        return total;
    }

    public void CategoryTotalPrice()
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (var item in bookInventory)
        {
            string category = item.Key.Category;
            int price = item.Key.Price * item.Value;

            if (result.ContainsKey(category))
                result[category] += price;
            else
                result.Add(category, price);
        }

        foreach (var r in result)
        {
            Console.WriteLine("Category: " + r.Key + ", Total Price: " + r.Value);
        }
    }

    public void CategoryAndAuthorWithCount()
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (var item in bookInventory)
        {
            string key = item.Key.Category + " - " + item.Key.Author;

            if (result.ContainsKey(key))
                result[key] += item.Value;
            else
                result.Add(key, item.Value);
        }

        foreach (var r in result)
        {
            Console.WriteLine(r.Key + " Count: " + r.Value);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        LibrarySystem library = new LibrarySystem();

        Book b1 = new Book(1, "PeterPan", "JamesMatthewBarrie", "KidsClassics", 193);
        Book b2 = new Book(2, "WizardOfOz", "FrankBaum", "KidsClassics", 394);

        library.AddBook(b1, 11);
        library.AddBook(b2, 3);

        library.CategoryTotalPrice();
        library.CategoryAndAuthorWithCount();

        Console.WriteLine("Total Price: " + library.CalculateTotalPrice());
    }
}