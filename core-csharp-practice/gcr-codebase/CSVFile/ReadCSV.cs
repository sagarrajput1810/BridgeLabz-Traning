using System;

class Csv
{
    static void Main()
    {
        string[] lines = File.ReadAllLines(@"C:\Users\asus\Documents\BridgeLabz-Traning\core-csharp-practice\gcr-codebase\CSVFile\Sample.csv");
        foreach(string line in lines)
        {
            Console.WriteLine(line);
        }
    }
}