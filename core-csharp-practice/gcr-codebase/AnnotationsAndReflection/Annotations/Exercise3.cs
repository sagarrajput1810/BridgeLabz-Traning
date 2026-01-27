using System;
using System.Collections;

namespace Annotations
{
    public class Exercise3
    {
        public static void Run()
        {
            Console.WriteLine("--- Exercise 3: Suppress Warnings ---");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            ArrayList list = new ArrayList();
            list.Add("hello");
            string s = (string)list[0];
            Console.WriteLine(s);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            Console.WriteLine();
        }
    }
}
