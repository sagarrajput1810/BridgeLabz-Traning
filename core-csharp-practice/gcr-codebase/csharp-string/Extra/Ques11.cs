using System;
using System.Security.Cryptography.X509Certificates;
class Ques11
{
    static void Main()
    {
        string s1 = Console.ReadLine();
        string s2 = Console.ReadLine();
        Console.WriteLine(AreAnagrams(s1,s2));
    }
    static bool AreAnagrams(string s1, string s2)
    {
        if(s1.Length != s2.Length) return false;
        for(int i = 0; i < s1.Length; i++)
        {
            if (!s2.Contains(s1[i]))
            {
                return false;
            }
        }
        for(int i = 0; i < s2.Length; i++)
        {
            if (!s1.Contains(s2[i]))
            {
                return false;
            }
        }
        return true;
    }
}