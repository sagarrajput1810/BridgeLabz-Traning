using System;
class BMI
{
    static void Main(string[] args)
    {
        int weight = int.Parse(Console.ReadLine());
        double height = int.Parse(Console.ReadLine());
        height = height / 100;
        double bmi = weight / (height * height );
        Console.WriteLine(bmi);
        if(bmi < 18.4)
        {
            Console.WriteLine("Underweight");
        }
        else if(bmi >= 18.5 && bmi <= 24.9)
        {
            Console.WriteLine("Normal weight");
        }
        else if(bmi >= 25 && bmi <= 39.9)
        {
            Console.WriteLine("Overweight");
        }
        else
        {
            Console.WriteLine("Obesity");   
        }
    }
}