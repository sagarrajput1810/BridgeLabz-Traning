using System;

// Interface for worker behavior
interface Worker
{
    void PerformDuties();
}

// Superclass
class Person
{
    public string Name;
    public int Id;

    public void DisplayPerson()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Id: " + Id);
    }
}

// Chef class
class Chef : Person, Worker
{
    public void PerformDuties()
    {
        Console.WriteLine("Chef prepares food");
    }
}

// Waiter class
class Waiter : Person, Worker
{
    public void PerformDuties()
    {
        Console.WriteLine("Waiter serves food");
    }
}

// Test class
class RestaurantTest
{
    static void Main()
    {
        Chef chef = new Chef();
        chef.Name = "Ramesh";
        chef.Id = 101;

        Waiter waiter = new Waiter();
        waiter.Name = "Suresh";
        waiter.Id = 102;

        Console.WriteLine("Chef Details:");
        chef.DisplayPerson();
        chef.PerformDuties();

        Console.WriteLine();

        Console.WriteLine("Waiter Details:");
        waiter.DisplayPerson();
        waiter.PerformDuties();
    }
}
