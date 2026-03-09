using System;

class Car
{
    protected string brand;
    protected double baseCost;

    public Car(string brand, double baseCost)
    {
        this.brand = brand;
        this.baseCost = baseCost;
    }

    public string getBrand()
    {
        return brand;
    }

    public double getBaseCost()
    {
        return baseCost;
    }

    public virtual double getCost()
    {
        return baseCost;
    }
}

class Weight : Car
{
    double weight;

    public Weight(string brand, double baseCost, double weight) : base(brand, baseCost)
    {
        this.weight = weight;
    }

    public override double getCost()
    {
        return baseCost + (weight * 10);
    }
}

class Monthly : Car
{
    int months;

    public Monthly(string brand, double baseCost, int months) : base(brand, baseCost)
    {
        this.months = months;
    }

    public override double getCost()
    {
        return baseCost + (months * 100);
    }
}

class Emergency : Car
{
    bool emergencyService;

    public Emergency(string brand, double baseCost, bool emergencyService) : base(brand, baseCost)
    {
        this.emergencyService = emergencyService;
    }

    public override double getCost()
    {
        if (emergencyService)
            return baseCost + 500;
        return baseCost;
    }
}

class Program
{
    static void Main()
    {
        Car car1 = new Weight("Toyota", 10000, 200);
        Car car2 = new Monthly("Honda", 12000, 6);
        Car car3 = new Emergency("Ford", 15000, true);

        Console.WriteLine(car1.getBrand() + " Cost: " + car1.getCost());
        Console.WriteLine(car2.getBrand() + " Cost: " + car2.getCost());
        Console.WriteLine(car3.getBrand() + " Cost: " + car3.getCost());
    }
}