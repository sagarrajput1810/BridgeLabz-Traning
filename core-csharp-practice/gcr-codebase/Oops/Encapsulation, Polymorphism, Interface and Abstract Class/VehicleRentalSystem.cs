using System;

interface IInsurable
{
    double CalculateInsurance();
    string GetInsuranceDetails();
}

abstract class Vehicle
{
    private string vehicleNumber;
    protected double rentalRate;

    protected Vehicle(string number, double rate)
    {
        vehicleNumber = number;
        rentalRate = rate;
    }

    public abstract double CalculateRentalCost(int days);
}

class Car : Vehicle, IInsurable
{
    public Car(string number, double rate)
        : base(number, rate) { }

    public override double CalculateRentalCost(int days)
    {
        return rentalRate * days;
    }

    public double CalculateInsurance()
    {
        return 500;
    }

    public string GetInsuranceDetails()
    {
        return "Car Insurance";
    }
}

class VehicleRentalSystem
{
    static void Main()
    {
        Vehicle v = new Car("KA01AB1234", 1500);
        IInsurable ins = (IInsurable)v;

        Console.WriteLine("Rental: " + v.CalculateRentalCost(3));
        Console.WriteLine("Insurance: " + ins.CalculateInsurance());
    }
}
