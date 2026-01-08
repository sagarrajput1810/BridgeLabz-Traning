using System;

interface IGPS
{
    string GetCurrentLocation();
}

abstract class Vehicle
{
    protected string driverName;
    protected double ratePerKm;

    protected Vehicle(string driver, double rate)
    {
        driverName = driver;
        ratePerKm = rate;
    }

    public abstract double CalculateFare(double distance);
}

class Car : Vehicle, IGPS
{
    public Car(string driver, double rate)
        : base(driver, rate) { }

    public override double CalculateFare(double distance)
    {
        return distance * ratePerKm;
    }

    public string GetCurrentLocation()
    {
        return "MG Road";
    }
}

class RideHailingApplication
{
    static void Main()
    {
        Vehicle v = new Car("Amit", 15);
        Console.WriteLine("Fare: " + v.CalculateFare(10));
    }
}
