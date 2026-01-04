using System;

// Base class
class Employee
{
    public string Name;
    public int Id;
    public double Salary;

    public virtual void DisplayDetails()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Id: " + Id);
        Console.WriteLine("Salary: " + Salary);
    }
}

// Manager class
class Manager : Employee
{
    public int TeamSize;

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Team Size: " + TeamSize);
    }
}

// Developer class
class Developer : Employee
{
    public string ProgrammingLanguage;

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Programming Language: " + ProgrammingLanguage);
    }
}

// Intern class
class Intern : Employee
{
    public string InternshipDuration;

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Internship Duration: " + InternshipDuration);
    }
}

class EmployeeTest
{
    static void Main()
    {
        Employee e1 = new Manager { Name = "Amit", Id = 101, Salary = 80000, TeamSize = 5 };
        Employee e2 = new Developer { Name = "Ravi", Id = 102, Salary = 60000, ProgrammingLanguage = "C#" };
        Employee e3 = new Intern { Name = "Neha", Id = 103, Salary = 15000, InternshipDuration = "6 Months" };

        e1.DisplayDetails();
        Console.WriteLine();
        e2.DisplayDetails();
        Console.WriteLine();
        e3.DisplayDetails();
    }
}
