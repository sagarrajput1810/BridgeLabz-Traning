using System;

namespace ReflectionPractice
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Student()
        {
            Name = "Unknown";
            Age = 0;
        }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }

        private void PrivateMethod()
        {
            Console.WriteLine("This is a private method.");
        }
    }
}
