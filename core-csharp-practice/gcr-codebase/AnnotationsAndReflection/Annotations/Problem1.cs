using System;
using System.Reflection;

namespace Annotations.Practice
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ImportantMethodAttribute : Attribute
    {
        public string Level { get; set; }

        public ImportantMethodAttribute(string level = "HIGH")
        {
            Level = level;
        }
    }

    public class ImportantTasks
    {
        [ImportantMethod]
        public void HighPriorityTask()
        {
            Console.WriteLine("Executing high priority task.");
        }

        [ImportantMethod("LOW")]
        public void LowPriorityTask()
        {
            Console.WriteLine("Executing low priority task.");
        }

        public void NormalTask()
        {
            Console.WriteLine("Executing normal task.");
        }
    }

    public class Problem1
    {
        public static void Run()
        {
            Console.WriteLine("--- Practice Problem 1: ImportantMethod Attribute ---");
            Type type = typeof(ImportantTasks);
            foreach (var method in type.GetMethods())
            {
                var attr = (ImportantMethodAttribute?)method.GetCustomAttribute(typeof(ImportantMethodAttribute));
                if (attr != null)
                {
                    Console.WriteLine($"Method '{method.Name}' is an important method with level '{attr.Level}'.");
                }
            }
            Console.WriteLine();
        }
    }
}
