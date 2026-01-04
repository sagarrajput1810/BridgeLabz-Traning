using System;

class Employee
{
    public static string companyName;
    private static int totalEmployees = 0;

    private string name;
    public readonly int id;
    private string designation;

    public Employee(string name, int id, string designation)
    {
        this.name = name;
        this.id = id;
        this.designation = designation;
        totalEmployees++;
    }

    public void Display()
    {
        Console.WriteLine("Company: " + companyName);
        Console.WriteLine("Name: " + name);
        Console.WriteLine("ID: " + id);
        Console.WriteLine("Designation: " + designation);
    }

    public static void DisplayTotalEmployees()
    {
        Console.WriteLine("Total Employees: " + totalEmployees);
    }

    static void Main()
    {
        Console.Write("Enter Company Name: ");
        companyName = Console.ReadLine();

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Designation: ");
        string des = Console.ReadLine();

        object emp = new Employee(name, id, des);

        if (emp is Employee)
        {
            ((Employee)emp).Display();
        }

        Employee.DisplayTotalEmployees();
    }
}
