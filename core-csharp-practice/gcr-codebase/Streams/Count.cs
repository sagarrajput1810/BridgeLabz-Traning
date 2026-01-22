using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Count
{
    public static void Main()
    {
        Dictionary<string, int> wordCount = new();

        using StreamReader reader = new StreamReader("text.txt");
        string? line;

        while ((line = reader.ReadLine()) != null)
        {
            foreach (var word in line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                string w = word.ToLower();
                wordCount[w] = wordCount.ContainsKey(w) ? wordCount[w] + 1 : 1;
            }
        }

        var top5 = wordCount.OrderByDescending(x => x.Value).Take(5);

        foreach (var item in top5)
        {
            Console.WriteLine($"{item.Key} : {item.Value}");
        }
    }
}
