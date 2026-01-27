using System;
using System.Reflection;

namespace Annotations
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TaskInfoAttribute : Attribute
    {
        public string AssignedTo { get; set; }
        public int Priority { get; set; }

        public TaskInfoAttribute(string assignedTo, int priority)
        {
            AssignedTo = assignedTo;
            Priority = priority;
        }
    }

    public class TaskManager
    {
        [TaskInfo("John Doe", 1)]
        public void DoTask()
        {
            Console.WriteLine("Doing the task...");
        }
    }

    public class Exercise4
    {
        public static void Run()
        {
            Console.WriteLine("--- Exercise 4: Custom Attribute ---");
            Type type = typeof(TaskManager);
            MethodInfo? method = type.GetMethod("DoTask");
            if (method != null)
            {
                TaskInfoAttribute? attr = (TaskInfoAttribute?)method.GetCustomAttribute(typeof(TaskInfoAttribute));

                if (attr != null)
                {
                    Console.WriteLine($"Task assigned to: {attr.AssignedTo}");
                    Console.WriteLine($"Priority: {attr.Priority}");
                }
            }
            Console.WriteLine();
        }
    }
}
