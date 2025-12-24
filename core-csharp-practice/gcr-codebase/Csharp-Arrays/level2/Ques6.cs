using System;
class Ques6
{
    static void Main()
    {
        int persons = int.Parse(Console.ReadLine());
        double [] weights = new double[persons];
        double [] heights = new double[persons];
        double [] bmi = new double[persons];
        for(int i = 0; i < persons; i++)
        {
            weights[i] = double.Parse(Console.ReadLine());
            heights[i] = double.Parse(Console.ReadLine());
            bmi[i] = weights[i] / (heights[i] * heights[i]);
        }
        for(int i = 0; i < persons; i++)
        {
            if(bmi[i] <= 18)
            {
                Console.WriteLine("Underweight");
            }
            else if(bmi[i] > 18 && bmi[i] <= 24)
            {
                Console.WriteLine("Normal weight");
            }
            else if(bmi[i] > 24 && bmi[i] <= 29)
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