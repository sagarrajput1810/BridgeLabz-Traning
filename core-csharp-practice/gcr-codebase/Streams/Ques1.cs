using System;
using System.IO;
class Ques1
{
    static void Main()
    {
        string sourceFile = @"C:\Users\asus\Documents\BridgeLabz-Traning\core-csharp-practice\gcr-codebase\Streams\TextFile.txt";
        string DestinationFile = @"C:\Users\asus\Documents\BridgeLabz-Traning\core-csharp-practice\gcr-codebase\Streams\Destination.txt";
        try
        {
            if (!File.Exists(sourceFile))
            {
                Console.WriteLine("File Does Not Exist.");
            }
            FileStream readStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
            FileStream writeStream = new FileStream(DestinationFile, FileMode.Create, FileAccess.Write);
            int data;
            while ((data = readStream.ReadByte()) != -1)
            {
                writeStream.WriteByte((byte)data);
            }
            Console.WriteLine("Data Copied successfully");
            readStream.Close();
            writeStream.Close();
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}