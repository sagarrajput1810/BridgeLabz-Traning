// Employee bonus using random salary & years
using System;

class EmployeeBonus {
    static void Main(string[] args) {
        double[,] empData = GenerateEmployeeData();
        double[,] bonusData = CalculateBonus(empData);
        DisplaySummary(empData, bonusData);
    }

    static double[,] GenerateEmployeeData() {
        Random r = new Random();
        double[,] data = new double[10, 2]; // salary, years

        for (int i = 0; i < 10; i++) {
            data[i, 0] = r.Next(10000, 99999);
            data[i, 1] = r.Next(1, 11);
        }
        return data;
    }

    static double[,] CalculateBonus(double[,] emp) {
        double[,] result = new double[10, 2]; // bonus, new salary

        for (int i = 0; i < 10; i++) {
            double rate = emp[i, 1] > 5 ? 0.05 : 0.02;
            result[i, 0] = emp[i, 0] * rate;
            result[i, 1] = emp[i, 0] + result[i, 0];
        }
        return result;
    }

    static void DisplaySummary(double[,] emp, double[,] res) {
        double oldSum = 0, newSum = 0, bonusSum = 0;

        Console.WriteLine("Salary\tYears\tBonus\tNewSalary");
        for (int i = 0; i < 10; i++) {
            Console.WriteLine(emp[i, 0] + "\t" + emp[i, 1] + "\t" +
                              res[i, 0] + "\t" + res[i, 1]);
            oldSum += emp[i, 0];
            bonusSum += res[i, 0];
            newSum += res[i, 1];
        }

        Console.WriteLine("\nTotal Old Salary = " + oldSum);
        Console.WriteLine("Total Bonus = " + bonusSum);
        Console.WriteLine("Total New Salary = " + newSum);
    }
}
