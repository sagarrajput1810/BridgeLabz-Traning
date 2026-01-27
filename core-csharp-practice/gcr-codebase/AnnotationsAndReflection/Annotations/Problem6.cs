using System;
using System.Reflection;
using System.Text;
using System.Collections.Generic;

namespace Annotations.Practice
{
    [AttributeUsage(AttributeTargets.Property)]
    public class JsonFieldAttribute : Attribute
    {
        public string Name { get; set; }

        public JsonFieldAttribute() { }

        public JsonFieldAttribute(string name)
        {
            Name = name;
        }
    }

    public class JsonUser
    {
        [JsonField(Name = "user_name")]
        public string Username { get; set; }

        public int Age { get; set; }

        [JsonField(Name = "email_address")]
        public string Email { get; set; }

        public bool IsActive { get; set; }

        public JsonUser(string username, int age, string email, bool isActive)
        {
            Username = username;
            Age = age;
            Email = email;
            IsActive = isActive;
        }
    }

    public static class JsonSerializer
    {
        public static string ToJson(object obj)
        {
            StringBuilder sb = new StringBuilder();
            Type type = obj.GetType();
            sb.Append("{");
            bool firstProperty = true;

            foreach (PropertyInfo property in type.GetProperties())
            {
                if (!firstProperty)
                {
                    sb.Append(",");
                }

                string jsonKey = property.Name;
                var jsonFieldAttr = property.GetCustomAttribute<JsonFieldAttribute>();
                if (jsonFieldAttr != null && !string.IsNullOrEmpty(jsonFieldAttr.Name))
                {
                    jsonKey = jsonFieldAttr.Name;
                }

                sb.Append($"\"{jsonKey}\":");

                object? value = property.GetValue(obj);
                if (value is string)
                {
                    sb.Append($"\"{value}\"");
                }
                else if (value is bool)
                {
                    sb.Append(value.ToString().ToLower());
                }
                else if (value is null)
                {
                    sb.Append("null");
                }
                else
                {
                    sb.Append(value);
                }

                firstProperty = false;
            }

            sb.Append("}");
            return sb.ToString();
        }
    }

    public class Problem6
    {
        public static void Run()
        {
            Console.WriteLine("--- Practice Problem 6: JsonField Attribute ---");
            var user = new JsonUser("AliceSmith", 30, "alice.smith@example.com", true);
            string json = JsonSerializer.ToJson(user);
            Console.WriteLine(json);
            Console.WriteLine();
        }
    }
}
