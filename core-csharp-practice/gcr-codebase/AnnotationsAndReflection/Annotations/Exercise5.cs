using System;
using System.Reflection;

namespace Annotations
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class BugReportAttribute : Attribute
    {
        public string Description { get; }

        public BugReportAttribute(string description)
        {
            Description = description;
        }
    }

    public class BuggyCode
    {
        [BugReport("The loop condition is incorrect.")]
        [BugReport("The variable `i` is not initialized.")]
        public void SomeBuggyMethod()
        {
            // Some buggy code
        }
    }

    public class Exercise5
    {
        public static void Run()
        {
            Console.WriteLine("--- Exercise 5: Repeatable Attribute ---");
            Type type = typeof(BuggyCode);
            MethodInfo? method = type.GetMethod("SomeBuggyMethod");

            if (method != null)
            {
                object[] attributes = method.GetCustomAttributes(typeof(BugReportAttribute), false);

                foreach (Attribute attr in attributes)
                {
                    if (attr is BugReportAttribute bugReport)
                    {
                        Console.WriteLine($"Bug Report: {bugReport.Description}");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
