using System;

// Base class
class Device
{
    public int DeviceId;
    public string Status;
}

// Subclass
class Thermostat : Device
{
    public int TemperatureSetting;

    public void DisplayStatus()
    {
        Console.WriteLine("Device Id: " + DeviceId);
        Console.WriteLine("Status: " + Status);
        Console.WriteLine("Temperature: " + TemperatureSetting);
    }
}

class DeviceTest
{
    static void Main()
    {
        Thermostat t = new Thermostat();
        t.DeviceId = 1;
        t.Status = "ON";
        t.TemperatureSetting = 24;

        t.DisplayStatus();
    }
}
