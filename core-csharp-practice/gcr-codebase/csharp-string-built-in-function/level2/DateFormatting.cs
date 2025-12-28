using System;

class DateFormatting
{
    static void Main(string[] args)
    {
        // Get current date
        DateTime today = DateTime.Now;

        // Display date in different formats
        Console.WriteLine("dd/MM/yyyy format: " + today.ToString("dd/MM/yyyy"));
        Console.WriteLine("yyyy-MM-dd format: " + today.ToString("yyyy-MM-dd"));
        Console.WriteLine("EEE, MMM dd, yyyy format: " + today.ToString("ddd, MMM dd, yyyy"));
    }
}
