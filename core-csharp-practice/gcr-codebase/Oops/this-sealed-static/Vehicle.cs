using System;

class Vehicle
{
    public static double registrationFee;

    private string ownerName;
    private string vehicleType;
    public readonly int registrationNumber;

    public Vehicle(string ownerName, string vehicleType, int registrationNumber)
    {
        this.ownerName = ownerName;
        this.vehicleType = vehicleType;
        this.registrationNumber = registrationNumber;
    }

    public void Display()
    {
        Console.WriteLine("Owner              : " + ownerName);
        Console.WriteLine("Vehicle Type       : " + vehicleType);
        Console.WriteLine("Registration Fee   : " + registrationFee);
        Console.WriteLine("Registration No.   : " + registrationNumber);
        Console.WriteLine("-------------------------------");
    }

    static void Main(string[] args)
    {
        // Hard-coded static value
        Vehicle.registrationFee = 2500.00;

        // Hard-coded vehicle objects
        object v1 = new Vehicle("Vijay", "Car", 56789);
        object v2 = new Vehicle("Anita", "Motorcycle", 67890);

        // Type checking and casting
        if (v1 is Vehicle)
        {
            ((Vehicle)v1).Display();
        }

        if (v2 is Vehicle)
        {
            ((Vehicle)v2).Display();
        }
    }
}
