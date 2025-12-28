using System;

class PalindromeString
{
    static void Main(string[] args)
    {
        string input = ReadInput();
        bool result = IsPalindrome(input);
        DisplayResult(result);
    }

    static string ReadInput()
    {
        Console.Write("Enter a string: ");
        return Console.ReadLine();
    }

    static bool IsPalindrome(string text)
    {
        int start = 0;
        int end = text.Length - 1;

        while (start < end)
        {
            if (text[start] != text[end])
                return false;

            start++;
            end--;
        }
        return true;
    }

    static void DisplayResult(bool isPalindrome)
    {
        if (isPalindrome)
            Console.WriteLine("Palindrome");
        else
            Console.WriteLine("Not a Palindrome");
    }
}
