abstract class Product
{
    public int ProductId { get; private set; }
    public string Name { get; private set; }
    public double Price { get; protected set; }
    public int Stock { get; private set; }

    protected Product(int id, string name, double price, int stock)
    {
        ProductId = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public void UpdateStock(int quantity)
    {
        if (quantity < 0 && Stock + quantity < 0)
        {
            Console.WriteLine("Insufficient stock.");
            return;
        }
        Stock += quantity;
    }

    public abstract string GetCategory();

    public virtual void DisplayProduct()
    {
        Console.WriteLine($"ID: {ProductId}, Name: {Name}, Category: {GetCategory()}, Price: ₹{Price}, Stock: {Stock}");
    }
}
class Electronics : Product
{
    public int WarrantyYears { get; private set; }

    public Electronics(int id, string name, double price, int stock, int warranty)
        : base(id, name, price, stock)
    {
        WarrantyYears = warranty;
    }

    public override string GetCategory()
    {
        return "Electronics";
    }
}
class Clothing : Product
{
    public string Size { get; private set; }

    public Clothing(int id, string name, double price, int stock, string size)
        : base(id, name, price, stock)
    {
        Size = size;
    }

    public override string GetCategory()
    {
        return "Clothing";
    }
}
class Books : Product
{
    public string Author { get; private set; }

    public Books(int id, string name, double price, int stock, string author)
        : base(id, name, price, stock)
    {
        Author = author;
    }

    public override string GetCategory()
    {
        return "Books";
    }
}
class ProductCatalog
{
    private List<Product> products = new List<Product>();

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void ViewAllProducts()
    {
        foreach (var product in products)
            product.DisplayProduct();
    }

    public void FilterByCategory(string category)
    {
        foreach (var product in products)
        {
            if (product.GetCategory().Equals(category, StringComparison.OrdinalIgnoreCase))
                product.DisplayProduct();
        }
    }
}
class Program
{
    static void Main()
    {
        ProductCatalog catalog = new ProductCatalog();

        catalog.AddProduct(new Electronics(101, "Laptop", 65000, 10, 2));
        catalog.AddProduct(new Clothing(102, "T-Shirt", 999, 50, "L"));
        catalog.AddProduct(new Books(103, "Clean Code", 799, 20, "Robert C. Martin"));

        Console.WriteLine("All Products:");
        catalog.ViewAllProducts();

        Console.WriteLine("\nFiltered: Electronics");
        catalog.FilterByCategory("Electronics");
    }}