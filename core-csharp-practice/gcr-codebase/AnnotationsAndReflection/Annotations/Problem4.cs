using System;
using System.Reflection;

namespace Annotations.Practice
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLengthAttribute : Attribute
    {
        public int MaxLength { get; }

        public MaxLengthAttribute(int maxLength)
        {
            MaxLength = maxLength;
        }
    }

    public class User
    {
        [MaxLength(10)]
        public string Username { get; set; }

        public User(string username)
        {
            Username = username;
        }
    }

    public static class Validator
    {
        public static void Validate(object obj)
        {
            Type type = obj.GetType();
            foreach (PropertyInfo property in type.GetProperties())
            {
                var attr = property.GetCustomAttribute<MaxLengthAttribute>();
                if (attr != null)
                {
                    var value = (string?)property.GetValue(obj);
                    if (value != null && value.Length > attr.MaxLength)
                    {
                        throw new ArgumentException($"The length of {property.Name} cannot be more than {attr.MaxLength}");
                    }
                }
            }
        }
    }

    public class Problem4
    {
        public static void Run()
        {
            Console.WriteLine("--- Practice Problem 4: MaxLength Attribute ---");
            try
            {
                User user1 = new User("validuser");
                Validator.Validate(user1);
                Console.WriteLine($"User '{user1.Username}' is valid.");

                User user2 = new User("thisusernameistoolong");
                Validator.Validate(user2);
                Console.WriteLine($"User '{user2.Username}' is valid.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Validation failed: {ex.Message}");
            }
            Console.WriteLine();
        }
    }
}
