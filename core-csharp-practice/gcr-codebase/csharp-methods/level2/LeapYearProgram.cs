// Check leap year
using System;

class LeapYearProgram {
    static void Main(string[] args) {
        Console.Write("Enter year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        if (IsLeapYear(year))
            Console.WriteLine("Leap Year");
        else
            Console.WriteLine("Not a Leap Year");
    }

    // function to check wheather the given year is leap or nnot
    static bool IsLeapYear(int year) {
        if (year < 1582) return false;
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }
}
