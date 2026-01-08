using System;

// Interface for department behavior
interface IDepartment
{
    void AssignDepartment(string deptName);
    string GetDepartmentDetails();
}

// Abstract class
abstract class Employee
{
    private int employeeId;
    private string name;
    private double baseSalary;

    protected Employee(int id, string name, double salary)
    {
        this.employeeId = id;
        this.name = name;
        this.baseSalary = salary;
    }

    public int EmployeeId { get { return employeeId; } }
    public string Name { get { return name; } }
    protected double BaseSalary { get { return baseSalary; } }

    public abstract double CalculateSalary();

    public void DisplayDetails()
    {
        Console.WriteLine("ID: " + employeeId);
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Salary: " + CalculateSalary());
    }
}

// Full time employee
class FullTimeEmployee : Employee, IDepartment
{
    private string department;

    public FullTimeEmployee(int id, string name, double salary)
        : base(id, name, salary) { }

    public override double CalculateSalary()
    {
        return BaseSalary;
    }

    public void AssignDepartment(string deptName)
    {
        department = deptName;
    }

    public string GetDepartmentDetails()
    {
        return department;
    }
}

// Part time employee
class PartTimeEmployee : Employee
{
    private int hoursWorked;
    private double hourlyRate;

    public PartTimeEmployee(int id, string name, int hours, double rate)
        : base(id, name, 0)
    {
        hoursWorked = hours;
        hourlyRate = rate;
    }

    public override double CalculateSalary()
    {
        return hoursWorked * hourlyRate;
    }
}

class EmployeeManagementSystem
{
    static void Main()
    {
        Employee[] employees = new Employee[2];

        FullTimeEmployee e1 = new FullTimeEmployee(101, "Rahul", 50000);
        e1.AssignDepartment("IT");

        PartTimeEmployee e2 = new PartTimeEmployee(102, "Anita", 80, 300);

        employees[0] = e1;
        employees[1] = e2;

        for (int i = 0; i < employees.Length; i++)
        {
            employees[i].DisplayDetails();
            Console.WriteLine("--------------");
        }
    }
}
