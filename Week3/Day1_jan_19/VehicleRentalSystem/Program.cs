abstract class Vehicle
{
    public int VehicleId { get; private set; }
    public string Model { get; private set; }
    public double RatePerDay { get; protected set; }
    public bool IsAvailable { get; set; }

    public Vehicle(int id, string model, double rate)
    {
        VehicleId = id;
        Model = model;
        RatePerDay = rate;
        IsAvailable = true;
    }

    public virtual double CalculateRent(int days)
    {
        return RatePerDay * days;
    }
}
class Car : Vehicle
{
    public Car(int id, string model) : base(id, model, 1500) { }
}

class Bike : Vehicle
{
    public Bike(int id, string model) : base(id, model, 500) { }
}

class Truck : Vehicle
{
    public Truck(int id, string model) : base(id, model, 3000) { }
}
class Customer
{
    public int CustomerId { get; private set; }
    public string Name { get; private set; }

    public Customer(int id, string name)
    {
        CustomerId = id;
        Name = name;
    }
}
class RentalTransaction
{
    private Vehicle vehicle;
    private Customer customer;
    private int rentalDays;
    private double totalCost;

    public RentalTransaction(Vehicle vehicle, Customer customer, int days)
    {
        this.vehicle = vehicle;
        this.customer = customer;
        rentalDays = days;
    }

    public void RentVehicle()
    {
        if (!vehicle.IsAvailable)
        {
            Console.WriteLine("Vehicle not available.");
            return;
        }

        totalCost = vehicle.CalculateRent(rentalDays);
        vehicle.IsAvailable = false;

        Console.WriteLine($"Vehicle rented to {customer.Name}");
        Console.WriteLine($"Total Cost: ₹{totalCost}");
    }

    public void ReturnVehicle()
    {
        vehicle.IsAvailable = true;
        Console.WriteLine("Vehicle returned successfully.");
    }
}
class Program
{
    static void Main()
    {
        Vehicle car = new Car(101, "Hyundai Verna");
        Customer customer = new Customer(1, "Shankar");

        RentalTransaction transaction =
            new RentalTransaction(car, customer, 3);

        transaction.RentVehicle();
        transaction.ReturnVehicle();
    }
}
