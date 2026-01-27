using System;
using System.Reflection;

namespace Annotations.Practice
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class TodoAttribute : Attribute
    {
        public string Task { get; }
        public string AssignedTo { get; }
        public string Priority { get; set; }

        public TodoAttribute(string task, string assignedTo)
        {
            Task = task;
            AssignedTo = assignedTo;
            Priority = "MEDIUM";
        }
    }

    public class ProjectTasks
    {
        [Todo("Implement feature X", "Alice")]
        public void FeatureX() { }

        [Todo("Fix bug Y", "Bob", Priority = "HIGH")]
        public void BugY() { }

        [Todo("Refactor class Z", "Alice")]
        public void RefactorZ() { }
    }

    public class Problem2
    {
        public static void Run()
        {
            Console.WriteLine("--- Practice Problem 2: Todo Attribute ---");
            Type type = typeof(ProjectTasks);
            foreach (var method in type.GetMethods())
            {
                var attributes = method.GetCustomAttributes(typeof(TodoAttribute), false);
                foreach (var attr in attributes)
                {
                    if (attr is TodoAttribute todo)
                    {
                        Console.WriteLine($"Task: {todo.Task}, Assigned to: {todo.AssignedTo}, Priority: {todo.Priority}");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
