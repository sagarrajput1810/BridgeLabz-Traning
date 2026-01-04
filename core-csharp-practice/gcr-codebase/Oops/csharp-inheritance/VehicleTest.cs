using System;

// Interface
interface Refuelable
{
    void Refuel();
}

// Superclass
class Vehicle
{
    public int MaxSpeed;
    public string Model;

    public void DisplayVehicle()
    {
        Console.WriteLine("Model: " + Model);
        Console.WriteLine("Max Speed: " + MaxSpeed);
    }
}

// Electric Vehicle class
class ElectricVehicle : Vehicle
{
    public void Charge()
    {
        Console.WriteLine("Electric vehicle is charging");
    }
}

// Petrol Vehicle class
class PetrolVehicle : Vehicle, Refuelable
{
    public void Refuel()
    {
        Console.WriteLine("Petrol vehicle is refueling");
    }
}

// Test class
class VehicleTest
{
    static void Main()
    {
        ElectricVehicle ev = new ElectricVehicle();
        ev.Model = "Tesla";
        ev.MaxSpeed = 200;

        PetrolVehicle pv = new PetrolVehicle();
        pv.Model = "Honda";
        pv.MaxSpeed = 180;

        Console.WriteLine("Electric Vehicle:");
        ev.DisplayVehicle();
        ev.Charge();

        Console.WriteLine();

        Console.WriteLine("Petrol Vehicle:");
        pv.DisplayVehicle();
        pv.Refuel();
    }
}
