using System;
using System.IO;

class ImageByte
{
    public static void Main()
    {
        try
        {
            byte[] bytes = File.ReadAllBytes("image.jpg");

            using MemoryStream ms = new MemoryStream(bytes);
            File.WriteAllBytes("copy.jpg", ms.ToArray());

            Console.WriteLine("Image copied successfully.");
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
