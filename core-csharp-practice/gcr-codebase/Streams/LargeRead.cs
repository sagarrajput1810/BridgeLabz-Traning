using System;
using System.IO;

class LargeRead
{
    public static void Main()
    {
        using StreamReader reader = new StreamReader("large.txt");
        string? line;

        while ((line = reader.ReadLine()) != null)
        {
            if (line.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(line);
            }
        }
    }
}
