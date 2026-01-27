using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Annotations.Practice
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RoleAllowedAttribute : Attribute
    {
        public string Role { get; }

        public RoleAllowedAttribute(string role)
        {
            Role = role;
        }
    }

    public class UserWithRoles
    {
        public string Name { get; }
        public List<string> Roles { get; }

        public UserWithRoles(string name, List<string> roles)
        {
            Name = name;
            Roles = roles;
        }
    }

    public class SecureActions
    {
        [RoleAllowed("ADMIN")]
        public void AdminAction()
        {
            Console.WriteLine("Admin action executed.");
        }

        public void GuestAction()
        {
            Console.WriteLine("Guest action executed.");
        }
    }

    public static class Security
    {
        public static void Execute(UserWithRoles user, object obj, string methodName)
        {
            MethodInfo? method = obj.GetType().GetMethod(methodName);
            if (method != null)
            {
                var attr = method.GetCustomAttribute<RoleAllowedAttribute>();
                if (attr != null)
                {
                    if (user.Roles.Contains(attr.Role))
                    {
                        method.Invoke(obj, null);
                    }
                    else
                    {
                        Console.WriteLine($"User '{user.Name}' does not have the required role '{attr.Role}' to execute '{method.Name}'. Access Denied!");
                    }
                }
                else
                {
                    method.Invoke(obj, null);
                }
            }
        }
    }

    public class Problem5
    {
        public static void Run()
        {
            Console.WriteLine("--- Practice Problem 5: RoleAllowed Attribute ---");
            var adminUser = new UserWithRoles("Admin", new List<string> { "ADMIN", "USER" });
            var normalUser = new UserWithRoles("Guest", new List<string> { "USER" });

            var actions = new SecureActions();

            Console.WriteLine($"Executing actions for user '{adminUser.Name}':");
            Security.Execute(adminUser, actions, "AdminAction");
            Security.Execute(adminUser, actions, "GuestAction");

            Console.WriteLine($"\nExecuting actions for user '{normalUser.Name}':");
            Security.Execute(normalUser, actions, "AdminAction");
            Security.Execute(normalUser, actions, "GuestAction");

            Console.WriteLine();
        }
    }
}
