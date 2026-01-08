using System;
using System.Collections.Generic;
using System.Text;

//07-01-2026
namespace EmployeeWage
{
    internal class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeSalary { get; set; }

        public override string ToString()
        {
            return "Employee ID: " + EmployeeId +
                   "\nEmployee Name: " + EmployeeName +
                   "\nEmployee Salary: " + EmployeeSalary;
        }
    }
}