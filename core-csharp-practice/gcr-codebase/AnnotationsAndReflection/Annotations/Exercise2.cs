using System;

namespace Annotations
{
    public class LegacyAPI
    {
        [Obsolete("This method is obsolete. Use NewFeature() instead.", false)]
        public void OldFeature()
        {
            Console.WriteLine("Executing old feature...");
        }

        public void NewFeature()
        {
            Console.WriteLine("Executing new feature...");
        }
    }

    public class Exercise2
    {
        public static void Run()
        {
            Console.WriteLine("--- Exercise 2: Obsolete Attribute ---");
            LegacyAPI api = new LegacyAPI();
            api.OldFeature();
            api.NewFeature();
            Console.WriteLine();
        }
    }
}
