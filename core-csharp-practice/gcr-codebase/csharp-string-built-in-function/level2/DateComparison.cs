using System;

class DateComparison
{
    static void Main(string[] args)
    {
        // Take first date input
        Console.Write("Enter first date (yyyy-MM-dd): ");
        DateTime date1 = DateTime.Parse(Console.ReadLine());

        // Take second date inputĪ
        Console.Write("Enter second date (yyyy-MM-dd): ");
        DateTime date2 = DateTime.Parse(Console.ReadLine());

        // Compare dates
        int result = DateTime.Compare(date1, date2);

        // Display comparison result
        if (result < 0)
        {
            Console.WriteLine("First date is earlier than second date");
        }
        else if (result > 0)
        {
            Console.WriteLine("First date is later than second date");
        }
        else
        {
            Console.WriteLine("Both dates are the same");
        }
    }
}
