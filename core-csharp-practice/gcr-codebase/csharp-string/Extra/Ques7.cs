// using System;

// class Ques7
// {
//     static void Main()
//     {
//         string s = Console.ReadLine();
//         Console.WriteLine(toggleCase(s));
//     }

//     static string toggleCase(string s)
//     {
//         string result = "";
//         for(int i = 0; i<s.Length; i++)
//         {
//             if(s[i] < 'a')
//             {
//                 result += (char)(s[i] + 32);
//             }
//             else
//             {
//                 result += (char)(s[i] - 32);
//             }
//         }
//         return result;
//     }
// }


/*7. Toggle Case of Characters
Problem:
Write a C# program to toggle the case of each character in a given string. Convert
uppercase letters to lowercase and vice versa.*/

using System;
class Case
{
    static void Main()
    {
        String a=Console.ReadLine();
        String j=Casecheck(a);
        Console.WriteLine(j);
    }
    static String Casecheck(String a)
    {
        String s="";
        //A=65 a=97
        for(int i=0;i<a.Length;i++)
        {
            if(a[i]<'a')
            {
                s+=(char)(a[i]+32);
            }
            else
            {
            s+=(char)(a[i]-32);
            }
            
        }
        return s;
        
    }
}