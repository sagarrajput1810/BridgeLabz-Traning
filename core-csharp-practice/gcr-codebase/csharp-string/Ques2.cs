using System;

class Ques2
{
    static void Main()
    {
        string s = "Sagar Rajput";
        Console.WriteLine(SubString(s, 0, 5));
    }
    static string SubString(string s, int start, int length)
    {
        string result = "";
        for(int i = start; i < start + length && i < s.Length; i++)
        {
            result += s[i];
        }
        return result;
    }
}