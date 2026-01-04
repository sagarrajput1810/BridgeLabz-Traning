using System;

// Superclass
class Vehicle
{
    public int MaxSpeed;
    public string FuelType;

    public virtual void DisplayInfo()
    {
        Console.WriteLine("Max Speed: " + MaxSpeed);
        Console.WriteLine("Fuel Type: " + FuelType);
    }
}

// Car class
class Car : Vehicle
{
    public int SeatCapacity;

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Seat Capacity: " + SeatCapacity);
    }
}

// Truck class
class Truck : Vehicle
{
    public int PayloadCapacity;

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Payload Capacity: " + PayloadCapacity);
    }
}

// Motorcycle class
class Motorcycle : Vehicle
{
    public bool HasSidecar;

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Has Sidecar: " + HasSidecar);
    }
}

class VehicleTest
{
    static void Main()
    {
        Vehicle[] vehicles = new Vehicle[3];

        vehicles[0] = new Car { MaxSpeed = 180, FuelType = "Petrol", SeatCapacity = 5 };
        vehicles[1] = new Truck { MaxSpeed = 120, FuelType = "Diesel", PayloadCapacity = 2000 };
        vehicles[2] = new Motorcycle { MaxSpeed = 150, FuelType = "Petrol", HasSidecar = false };

        for (int i = 0; i < vehicles.Length; i++)
        {
            vehicles[i].DisplayInfo();
            Console.WriteLine();
        }
    }
}
