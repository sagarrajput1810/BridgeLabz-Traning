using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace Annotations.Practice
{
    [AttributeUsage(AttributeTargets.Method)]
    public class LogExecutionTimeAttribute : Attribute
    {
    }

    public class TimedTasks
    {
        [LogExecutionTime]
        public void ShortTask()
        {
            Console.WriteLine("Executing short task...");
            Thread.Sleep(100);
        }

        [LogExecutionTime]
        public void LongTask()
        {
            Console.WriteLine("Executing long task...");
            Thread.Sleep(500);
        }

        public void NonTimedTask()
        {
            Console.WriteLine("Executing non-timed task...");
        }
    }

    public static class MethodLogger
    {
        public static void Invoke(object obj, string methodName)
        {
            MethodInfo? method = obj.GetType().GetMethod(methodName);
            if (method != null)
            {
                if (method.GetCustomAttribute<LogExecutionTimeAttribute>() != null)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    method.Invoke(obj, null);
                    stopwatch.Stop();
                    Console.WriteLine($"Method '{method.Name}' executed in {stopwatch.ElapsedMilliseconds} ms");
                }
                else
                {
                    method.Invoke(obj, null);
                }
            }
        }
    }


    public class Problem3
    {
        public static void Run()
        {
            Console.WriteLine("--- Practice Problem 3: LogExecutionTime Attribute ---");
            TimedTasks tasks = new TimedTasks();
            MethodLogger.Invoke(tasks, "ShortTask");
            MethodLogger.Invoke(tasks, "LongTask");
            MethodLogger.Invoke(tasks, "NonTimedTask");
            Console.WriteLine();
        }
    }
}
