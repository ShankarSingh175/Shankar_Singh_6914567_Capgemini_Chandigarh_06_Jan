using System;
using System.Collections.Generic;
using System.Linq;

public class Car
{
    public string Brand { get; set; }
    public int Price { get; set; }

    public Car(string brand, int price)
    {
        Brand = brand;
        Price = price;
    }
}

public class CarManager
{
    private List<Car> cars = new List<Car>();

    public void AddCar(string brand, int price)
    {
        cars.Add(new Car(brand, price));
    }

    public Car GetLeastPriceCar()
    {
        return cars.OrderBy(c => c.Price).First();
    }

    public double GetAveragePrice()
    {
        return cars.Average(c => c.Price);
    }

    public Dictionary<string, int> GetCarsWithHighestPrice()
    {
        int maxPrice = cars.Max(c => c.Price);

        return cars
            .Where(c => c.Price == maxPrice)
            .ToDictionary(c => c.Brand, c => c.Price);
    }
}

public class Solution
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        CarManager manager = new CarManager();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string brand = input[0];
            int price = int.Parse(input[1]);

            manager.AddCar(brand, price);
        }

        Car least = manager.GetLeastPriceCar();
        Console.WriteLine($"{least.Brand} {least.Price}");

        Console.WriteLine(manager.GetAveragePrice());

        var highest = manager.GetCarsWithHighestPrice();

        foreach (var car in highest)
        {
            Console.WriteLine($"{car.Key} {car.Value}");
        }
    }
}