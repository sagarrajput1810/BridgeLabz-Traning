using System;

class TemperatureAnalyzer
{
    private double[,] temperatureRecords;

    public TemperatureAnalyzer(double[,] temperatureData)
    {
        temperatureRecords = temperatureData;
    }

    static void Main()
    {
        double[,] weeklyTemperatures = new double[7, 24];
        ReadTemperatureData(weeklyTemperatures);

        TemperatureAnalyzer analyzer = new TemperatureAnalyzer(weeklyTemperatures);
        analyzer.DisplayHottestAndColdestDays();
        analyzer.DisplayDailyAverageTemperature();
    }

    static void ReadTemperatureData(double[,] temperatures)
    {
        Console.WriteLine("Enter hourly temperature readings for each day:");

        for (int day = 0; day < temperatures.GetLength(0); day++)
        {
            Console.WriteLine($"Day {day + 1}:");
            for (int hour = 0; hour < temperatures.GetLength(1); hour++)
            {
                temperatures[day, hour] = double.Parse(Console.ReadLine());
            }
        }
    }

    public void DisplayHottestAndColdestDays()
    {
        int hottestDay = 0, coldestDay = 0;
        double maxTemperature = temperatureRecords[0, 0];
        double minTemperature = temperatureRecords[0, 0];

        for (int day = 0; day < temperatureRecords.GetLength(0); day++)
        {
            double dayMax = temperatureRecords[day, 0];
            double dayMin = temperatureRecords[day, 0];

            for (int hour = 0; hour < temperatureRecords.GetLength(1); hour++)
            {
                if (temperatureRecords[day, hour] > dayMax)
                    dayMax = temperatureRecords[day, hour];

                if (temperatureRecords[day, hour] < dayMin)
                    dayMin = temperatureRecords[day, hour];
            }

            if (dayMax > maxTemperature)
            {
                maxTemperature = dayMax;
                hottestDay = day;
            }

            if (dayMin < minTemperature)
            {
                minTemperature = dayMin;
                coldestDay = day;
            }
        }

        Console.WriteLine($"Highest temperature occurred on Day {hottestDay + 1}");
        Console.WriteLine($"Lowest temperature occurred on Day {coldestDay + 1}");
    }

    public void DisplayDailyAverageTemperature()
    {
        for (int day = 0; day < temperatureRecords.GetLength(0); day++)
        {
            double dailySum = 0;

            for (int hour = 0; hour < temperatureRecords.GetLength(1); hour++)
            {
                dailySum += temperatureRecords[day, hour];
            }

            double dailyAverage = Math.Round(dailySum / temperatureRecords.GetLength(1), 2);
            Console.WriteLine($"Day {day + 1} average temperature: {dailyAverage}");
        }
    }
}
