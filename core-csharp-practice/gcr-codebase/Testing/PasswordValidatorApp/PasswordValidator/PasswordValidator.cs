using System.Linq;

namespace PasswordValidator
{
    public class PasswordValidator
    {
        public bool IsValid(string password)
        {
            if (password == null || password.Length < 8)
                return false;

            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasDigit = password.Any(char.IsDigit);

            return hasUpperCase && hasDigit;
        }
    }
}
