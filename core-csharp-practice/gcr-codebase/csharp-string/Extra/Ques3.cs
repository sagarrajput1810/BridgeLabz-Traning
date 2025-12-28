using System;

class Ques3
{
    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(IsPalindrome(s));
    }

    static bool IsPalindrome(string s)
    {
        string rev = "";
        for(int i = s.Length -1; i >= 0; i--)
        {
            rev += s[i];
        }
        return rev == s;
    }
}