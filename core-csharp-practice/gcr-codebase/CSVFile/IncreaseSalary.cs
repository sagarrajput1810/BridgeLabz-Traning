using System;

class IncreaseSalary
{
    static void Main()
    {
        string path = @"C:\Users\asus\Documents\BridgeLabz-Traning\core-csharp-practice\gcr-codebase\CSVFile\Sample.csv";

        string[] lines = File.ReadAllLines(path);

        for(int i =1; i < lines.Length; i++)
        {
            string[] line = lines[i].Split(",");
            line[3] = ((int.Parse(line[3]))+(int.Parse(line[3])/ 10)).ToString();
            lines[i] = string.Join(",",line);
        }
        foreach(string l in lines)
        {
            Console.WriteLine(l);
        }
    }
}