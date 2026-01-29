using System;
class CountCSV
{
    static void Main()
    {
        string[] lines = File.ReadAllLines(@"C:\Users\asus\Documents\BridgeLabz-Traning\core-csharp-practice\gcr-codebase\CSVFile\Sample.csv");
        Console.WriteLine(lines.Length-1);
    }
}