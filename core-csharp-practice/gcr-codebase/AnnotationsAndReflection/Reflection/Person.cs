using System;

namespace ReflectionPractice
{
    public class Person
    {
        private int age;

        public Person(int initialAge)
        {
            age = initialAge;
        }

        public int GetAge()
        {
            return age;
        }
    }
}