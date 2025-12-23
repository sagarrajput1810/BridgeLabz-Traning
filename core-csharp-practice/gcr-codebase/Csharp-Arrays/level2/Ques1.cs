using System;
class Ques1
{
    static void Main(string[] args)
    {
        double [] salary = new double[10];
        for(int i=0; i<10; i++)
        {
            salary[i] = double.Parse(Console.ReadLine());
        }
        int [] years = new int[10];
        for(int i=0; i<10; i++)
        {
            years[i] = int.Parse(Console.ReadLine());
        }
        for(int i=0; i<10; i++)
        {
            if(years[i] > 5)
            {
                salary[i] = salary[i] + (salary[i] * 0.05);
            }
            else
            {
                salary[i] = salary[i] + (salary[i] * 0.02);
            }
            Console.WriteLine("Updated Salary: "+ salary[i]);
        }

    }
}