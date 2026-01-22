using System;
using System.IO;
using System.Diagnostics;

class StopWatch
{
    public static void Main()
    {
        string source = "bigfile.dat";
        string dest = "copy.dat";

        byte[] buffer = new byte[4096];
        Stopwatch sw = new Stopwatch();

        // Buffered Stream
        sw.Start();
        using (FileStream fsRead = new FileStream(source, FileMode.Open))
        using (FileStream fsWrite = new FileStream(dest, FileMode.Create))
        using (BufferedStream bsRead = new BufferedStream(fsRead))
        using (BufferedStream bsWrite = new BufferedStream(fsWrite))
        {
            int bytes;
            while ((bytes = bsRead.Read(buffer, 0, buffer.Length)) > 0)
            {
                bsWrite.Write(buffer, 0, bytes);
            }
        }
        sw.Stop();
        Console.WriteLine($"Buffered Stream Time: {sw.ElapsedMilliseconds} ms");
    }
}
