class Book
{
    public int Id { get; set; }
    public string Books { get; set; }
    public int Price { get; set; }
    public int Stock { get; set; }
}

class Program
{
    public static void Main(string[] args)
    {
        List<Book> inventory = new List<Book>
        {
            new Book{ Id = 123 , Books = "Book1" , Price = 202 , Stock = 5},
            new Book{ Id = 125 , Books = "Book2" , Price = 252 , Stock = 0},
            new Book{ Id = 133 , Books = "Book3" , Price = 212 , Stock = 1},
            new Book{ Id = 183 , Books = "Book4" , Price = 292 , Stock = 6},
        };

        // Add new book
        inventory.Add(new Book { Id = 127, Books = "Book5", Price = 132, Stock = 4 });

        Console.WriteLine("---- Inventory ----");
        Display(inventory);

        var cheapBooks = inventory.Where(b => b.Price < 250).ToList();
        Console.WriteLine("---- Books Cheaper Than 250 ----");
        Display(cheapBooks);
        inventory.ForEach(b => b.Price += (b.Price * 10) / 100);

        Console.WriteLine("---- After 10% Price Increase ----");
        Display(inventory);

        inventory.RemoveAll(b => b.Stock == 0);

        Console.WriteLine("---- After Removing Out-of-Stock Books ----");
        Display(inventory);
    }

    public static void Display(List<Book> books)
    {
        foreach (var i in books)
        {
            Console.WriteLine($"Id:{i.Id}, Book:{i.Books}, Price:{i.Price}, Stock:{i.Stock}");
        }
    }
}
