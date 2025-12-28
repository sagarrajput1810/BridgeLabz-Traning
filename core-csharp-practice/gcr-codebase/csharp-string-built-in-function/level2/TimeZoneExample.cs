using System;

class TimeZoneExample
{
    static void Main(string[] args)
    {
        // Get current UTC time
        DateTimeOffset utcTime = DateTimeOffset.UtcNow;

        // Get different time zones
        TimeZoneInfo gmtZone = TimeZoneInfo.Utc;
        TimeZoneInfo istZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

        // Convert UTC time to different zones
        DateTimeOffset gmtTime = TimeZoneInfo.ConvertTime(utcTime, gmtZone);
        DateTimeOffset istTime = TimeZoneInfo.ConvertTime(utcTime, istZone);
        DateTimeOffset pstTime = TimeZoneInfo.ConvertTime(utcTime, pstZone);

        // Display results
        Console.WriteLine("GMT Time: " + gmtTime);
        Console.WriteLine("IST Time: " + istTime);
        Console.WriteLine("PST Time: " + pstTime);
    }
}
