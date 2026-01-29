using System;
class WriteCSV
{
    static void Main()
    {
        String[] lines = {
            "ID, Name, Department, Salary",
            "1,Sagar,Computer Science, 10000",
            "2,Aditi,Computer Science, 9999"
            };
        File.WriteAllLines(@"C:\Users\asus\Documents\BridgeLabz-Traning\core-csharp-practice\gcr-codebase\CSVFile\Sample.csv",lines);
    }
}