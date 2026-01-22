using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program

{
    public static void Main()
    {
        string path = "employees.json";

        List<Employee> employees = new()
        {
            new Employee { Id = 1, Name = "A", Department = "IT", Salary = 50000 },
            new Employee { Id = 2, Name = "B", Department = "HR", Salary = 40000 }
        };

        // Serialize
        File.WriteAllText(path, JsonSerializer.Serialize(employees));

        // Deserialize
        var data = JsonSerializer.Deserialize<List<Employee>>(File.ReadAllText(path))!;

        foreach (var e in data)
        {
            Console.WriteLine($"{e.Id} {e.Name} {e.Department} {e.Salary}");
        }
    }
}
