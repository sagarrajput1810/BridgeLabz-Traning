using System;

class Employee
{ 
    static void Main(string[] args) {
        EmployeeDetails e1 = new EmployeeDetails(101, "John Doe", 50000);
        EmployeeDetails e2 = new EmployeeDetails(102, "Jane Smith", 60000);
        EmployeeDetails e3 = new EmployeeDetails(103, "Sam Brown", 55000);
        e1.Display();
        e2.Display();
    }
}
class EmployeeDetails
{
    int empId;
    string empName;
    int salary;
    public EmployeeDetails(int id , string name, int sal)
    {
        empId = id;
        empName = name;
        salary = sal;
    }
    public void Display()
    {
        Console.WriteLine("Employee ID: " + empId);
        Console.WriteLine("Employee Name: " + empName);
        Console.WriteLine("Employee Salary: " + salary);
    }
}