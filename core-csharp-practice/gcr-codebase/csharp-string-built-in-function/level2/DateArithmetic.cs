using System;

class DateArithmetic
{
    static void Main(string[] args)
    {
        // Take date input from user
        Console.Write("Enter a date (yyyy-MM-dd): ");
        DateTime inputDate = DateTime.Parse(Console.ReadLine());

        // Add days, months, and years
        DateTime updatedDate = inputDate.AddDays(7);
        updatedDate = updatedDate.AddMonths(1);
        updatedDate = updatedDate.AddYears(2);

        // Subtract 3 weeks (21 days)
        updatedDate = updatedDate.AddDays(-21);

        // Display final result
        Console.WriteLine("Final Date: " + updatedDate.ToShortDateString());
    }
}
