using System;
class Ques7
{
    static void Main()
    {
        int persons = int.Parse(Console.ReadLine());
        int[][] bmi = new int[persons][];
        for(int i = 0; i < persons; i++)
        {
            bmi[i] = new int[3];
        }
        for(int i = 0; i < persons; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            bmi[i][0] = int.Parse(inputs[0]);
            bmi[i][1] = int.Parse(inputs[1]);
            bmi[i][2] = (int)((double)bmi[i][0] / ((bmi[i][1] * bmi[i][1]) / 10000));
        }
        for(int i = 0; i < persons; i++)
        {
            if(bmi[i][2] < 18)
            {
                Console.WriteLine("Underweight");
            }
            else if(bmi[i][2] >= 18 && bmi[i][2] < 25)
            {
                Console.WriteLine("Normal weight");
            }
            else if(bmi[i][2] >= 25 && bmi[i][2] < 30)
            {
                Console.WriteLine("Overweight");
            }
            else
            {
                Console.WriteLine("Obesity");
            }
        }
    }
}