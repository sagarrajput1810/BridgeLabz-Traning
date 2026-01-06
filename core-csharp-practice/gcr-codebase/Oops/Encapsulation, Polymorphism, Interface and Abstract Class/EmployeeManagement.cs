using System;

interface IDepartment {
	void AssignDepartment(string department);
	string GetDepartment();
}
abstract class Employee : IDepartment
{
	private int employeeId;
	private string name;
	protected double baseSalary;
	private string department;
	public Employee(int employeeId, string name, double baseSalary){
		this.employeeId = employeeId;
		this.name = name;
		this.baseSalary = baseSalary;
	}
	public int EmployId{
		get { return employeeId; }
		set { employeeId = value; }
	}
	public string Name {
		get { return string; }
		set { name = value; }
	}
	public abstract double CalculateSalary();
	public void DisplayDetails() {
		Console.WriteLine($"Employee Id: {employeeId}, Name: {name}, Base Salary: {baseSalary}");
	}
	public void AssignDepartment(string department) {
		this.department = department;
	}
	public string GetDepartment() {
		return department;
	}
}