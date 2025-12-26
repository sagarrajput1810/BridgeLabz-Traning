// Calculate BMI using 2D array
using System;

class BMIProgram {
    static void Main(string[] args) {
        double[,] data = new double[10, 3];

        for (int i = 0; i < 10; i++) {
            Console.Write("Enter weight (kg): ");
            data[i, 0] = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter height (cm): ");
            data[i, 1] = Convert.ToDouble(Console.ReadLine());
        }

        string[] status = CalculateBMI(data);

        for (int i = 0; i < 10; i++) {
            Console.WriteLine("BMI: " + data[i, 2] + " Status: " + status[i]);
        }
    }

    static string[] CalculateBMI(double[,] data) {
        string[] status = new string[10];

        for (int i = 0; i < 10; i++) {
            double heightM = data[i, 1] / 100;
            data[i, 2] = data[i, 0] / (heightM * heightM);

            if (data[i, 2] < 18.5) status[i] = "Underweight";
            else if (data[i, 2] < 25) status[i] = "Normal";
            else if (data[i, 2] < 30) status[i] = "Overweight";
            else status[i] = "Obese";
        }
        return status;
    }
}
