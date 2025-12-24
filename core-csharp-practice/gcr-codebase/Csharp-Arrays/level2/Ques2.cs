using System;
class Ques2
{
    static void Main()
    {
        int a_ages = int.Parse(Console.ReadLine());
        int b_ages = int.Parse(Console.ReadLine());
        int c_ages = int.Parse(Console.ReadLine());
        int a_height = int.Parse(Console.ReadLine());
        int b_height = int.Parse(Console.ReadLine());
        int c_height = int.Parse(Console.ReadLine());
        if(a_ages < b_ages && a_ages < c_ages)
        {
            Console.WriteLine("Amar is youngest");
        }else if(b_ages < a_ages && b_ages < c_ages)
        {
            Console.WriteLine("Akbar is youngest");
        }
        else
        {
            Console.WriteLine("Anthony is youngest");
        }
        if(a_height > b_height && a_height > c_height)
        {
            Console.WriteLine("Amar is tallest");
        }
        else if(b_height > a_height && b_height > c_height)
        {
            Console.WriteLine("Akbar is tallest");
        }
        else
        {
            Console.WriteLine("Anthony is tallest");
        }
    }
}