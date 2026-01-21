using System;
using System.Collections.Generic;

class Frequency
{
    static void Main()
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        string[] arr = new string[] { "apple", "banana", "apple", "mango", "Mera kela" };

        foreach (string i in arr)
        {
            if (dict.ContainsKey(i))
            {
                dict[i] = dict[i]+1;
            }
            else
            {
                dict.Add(i,1);
            }
        }
        foreach(var item in dict)
        {
            Console.WriteLine(item.Key + " -> " + item.Value);
        }
    }
}