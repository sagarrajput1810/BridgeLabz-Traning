using System;
using System.IO;

class DataStreams
{
    public static void Main()
    {
        string file = "student.dat";

        using (BinaryWriter bw = new BinaryWriter(File.Open(file, FileMode.Create)))
        {
            bw.Write(1);
            bw.Write("John");
            bw.Write(3.8);
        }

        using (BinaryReader br = new BinaryReader(File.Open(file, FileMode.Open)))
        {
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadDouble());
        }
    }
}
