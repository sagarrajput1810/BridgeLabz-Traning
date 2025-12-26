// Student marks and scorecard
using System;

class StudentScorecard {
    static void Main(string[] args) {
        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double[,] marks = GenerateMarks(n);
        double[,] results = CalculateResults(marks);
        DisplayScorecard(marks, results);
    }

    static double[,] GenerateMarks(int n) {
        Random r = new Random();
        double[,] m = new double[n, 3];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < 3; j++)
                m[i, j] = r.Next(10, 99);

        return m;
    }

    static double[,] CalculateResults(double[,] marks) {
        int n = marks.GetLength(0);
        double[,] res = new double[n, 3];

        for (int i = 0; i < n; i++) {
            double total = marks[i, 0] + marks[i, 1] + marks[i, 2];
            res[i, 0] = total;
            res[i, 1] = Math.Round(total / 3, 2);
            res[i, 2] = Math.Round((total / 300) * 100, 2);
        }
        return res;
    }

    static void DisplayScorecard(double[,] m, double[,] r) {
        Console.WriteLine("Phy\tChem\tMath\tTotal\tAvg\t%");
        for (int i = 0; i < m.GetLength(0); i++)
            Console.WriteLine(m[i,0] + "\t" + m[i,1] + "\t" + m[i,2] + "\t" +
                              r[i,0] + "\t" + r[i,1] + "\t" + r[i,2]);
    }
}
