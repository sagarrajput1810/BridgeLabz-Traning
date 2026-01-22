using System;
using System.IO;

class ReadWrite
{
    public static void Main()
    {
        string sourcePath = "source.txt";
        string destPath = "destination.txt";

        try
        {
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist.");
                return;
            }

            using FileStream fsRead = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
            using FileStream fsWrite = new FileStream(destPath, FileMode.Create, FileAccess.Write);

            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = fsRead.Read(buffer, 0, buffer.Length)) > 0)
            {
                fsWrite.Write(buffer, 0, bytesRead);
            }

            Console.WriteLine("File copied successfully.");
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
