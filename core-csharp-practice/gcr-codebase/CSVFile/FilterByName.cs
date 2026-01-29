using System;
class FilterByName
{
    static void Main()
    {
        string path = @"C:\Users\asus\Documents\BridgeLabz-Traning\core-csharp-practice\gcr-codebase\CSVFile\Sample.csv";
        string[] lines = File.ReadAllLines(path);
        for(int i =1; i < lines.Length; i++)
        {
            string[] data = lines[i].Split(",");
            if(data[1].ToLower() == "Aditi".ToLower())
            {
                Console.WriteLine(string.Join(" ",data));
            }
        }
    }
}