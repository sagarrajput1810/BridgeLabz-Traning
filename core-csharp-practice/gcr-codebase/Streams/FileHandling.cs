using System;

class FileHandling
{
    static void Main(string[] arr)
    {
        string path = "TextFile.txt";
        if (!File.Exists(path))
        {
            Console.WriteLine("Does not Exist");
        }
        try
        {
            var file=new FileStream(path,FileMode.Open,FileAccess.Read);
        } catch(Exception e)
        {
            
        }
    }
}