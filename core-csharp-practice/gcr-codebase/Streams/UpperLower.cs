using System;
using System.IO;

class UpperLower
{
    public static void Main()
    {
        using StreamReader reader = new StreamReader("input.txt");
        using StreamWriter writer = new StreamWriter("output.txt");

        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            writer.WriteLine(line.ToLower());
        }

        Console.WriteLine("Conversion complete.");
    }
}
