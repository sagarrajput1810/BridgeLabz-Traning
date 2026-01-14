using System;
using System.Diagnostics;
using System.IO;

namespace AlgorithmComparisons
{
    public class FileReadingComparison
    {
        public static void Run()
        {
            Console.WriteLine("\n--- 4. Large File Reading Efficiency ---");
            string filePath = "testfile.tmp";
            // Creating a 10MB file for demonstration (500MB takes longer to generate/read in quick test)
            CreateLargeFile(filePath, 10); 
            Console.WriteLine("Created temporary test file (10MB).");

            // StreamReader
            Stopwatch sw = Stopwatch.StartNew();
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (sr.Read() >= 0) { }
            }
            sw.Stop();
            Console.WriteLine($"StreamReader Time: {sw.Elapsed.TotalMilliseconds:F4} ms");

            // FileStream
            sw.Restart();
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                byte[] buffer = new byte[1024];
                while (fs.Read(buffer, 0, buffer.Length) > 0) { }
            }
            sw.Stop();
            Console.WriteLine($"FileStream Time: {sw.Elapsed.TotalMilliseconds:F4} ms");

            // Clean up
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        static void CreateLargeFile(string path, int sizeInMB)
        {
            byte[] data = new byte[1024 * 1024]; // 1MB buffer
            new Random().NextBytes(data);
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                for (int i = 0; i < sizeInMB; i++)
                {
                    fs.Write(data, 0, data.Length);
                }
            }
        }
    }
}
