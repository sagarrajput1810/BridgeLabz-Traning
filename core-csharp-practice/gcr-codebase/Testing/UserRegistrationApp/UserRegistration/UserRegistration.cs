using System;

namespace UserRegistration
{
    public class UserRegistration
    {
        public void RegisterUser(string username, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty.", nameof(username));

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Invalid email format.", nameof(email));

            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                throw new ArgumentException("Password must be at least 8 characters long.", nameof(password));
        }
    }
}
