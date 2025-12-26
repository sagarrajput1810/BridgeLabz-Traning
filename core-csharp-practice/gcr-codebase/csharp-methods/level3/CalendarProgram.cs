// Display calendar for given month and year
using System;

class CalendarProgram {
    // Main method - entry point of the program
    static void Main(string[] args) {
        // Get month input from user
        Console.Write("Enter month (1-12): ");
        int month = Convert.ToInt32(Console.ReadLine());

        // Get year input from user
        Console.Write("Enter year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        // Display the calendar
        DisplayCalendar(month, year);
    }

    static void DisplayCalendar(int month, int year) {
        string[] months = {
            "January","February","March","April","May","June",
            "July","August","September","October","November","December"
        };

        int[] days = { 31,28,31,30,31,30,31,31,30,31,30,31 };

        if (month == 2 && IsLeapYear(year))
            days[1] = 29;

        Console.WriteLine("\n   " + months[month - 1] + " " + year);
        Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

        int firstDay = GetFirstDay(month, year);

        for (int i = 0; i < firstDay; i++)
            Console.Write("    ");

        for (int day = 1; day <= days[month - 1]; day++) {
            Console.Write(String.Format("{0,3} ", day));
            if ((day + firstDay) % 7 == 0)
                Console.WriteLine();
        }
    }

    static bool IsLeapYear(int year) {
        return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
    }

    static int GetFirstDay(int m, int y) {
        int d = 1;
        int y0 = y - (14 - m) / 12;
        int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
        int m0 = m + 12 * ((14 - m) / 12) - 2;
        return (d + x + (31 * m0) / 12) % 7;
    }
}
    