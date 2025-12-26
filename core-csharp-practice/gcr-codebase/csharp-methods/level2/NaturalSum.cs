// Compare recursive sum and formula sum
using System;

class NaturalSum {
    static void Main(string[] args) {
        Console.Write("Enter a natural number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        if (n <= 0) {
            Console.WriteLine("Not a natural number");
            return;
        }

        int recursiveSum = RecursiveSum(n);
        int formulaSum = FormulaSum(n);

        Console.WriteLine("Recursive Sum = " + recursiveSum);
        Console.WriteLine("Formula Sum = " + formulaSum);
    }

    static int RecursiveSum(int n) {
        if (n == 1) return 1;
        return n + RecursiveSum(n - 1);
    }

    static int FormulaSum(int n) {
        return n * (n + 1) / 2;
    }
}
