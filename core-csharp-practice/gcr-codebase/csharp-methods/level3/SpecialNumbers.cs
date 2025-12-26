// Special number checks
using System;

class SpecialNumbers {
    static void Main(string[] args) {
        Console.Write("Enter number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Prime = " + IsPrime(n));
        Console.WriteLine("Neon = " + IsNeon(n));
        Console.WriteLine("Spy = " + IsSpy(n));
        Console.WriteLine("Automorphic = " + IsAutomorphic(n));
        Console.WriteLine("Buzz = " + IsBuzz(n));
    }

    static bool IsPrime(int n) {
        if (n <= 1) return false;
        for (int i = 2; i <= n / 2; i++)
            if (n % i == 0) return false;
        return true;
    }

    static bool IsNeon(int n) {
        int square = n * n, sum = 0;
        while (square != 0) { sum += square % 10; square /= 10; }
        return sum == n;
    }

    static bool IsSpy(int n) {
        int sum = 0, product = 1;
        while (n != 0) {
            int d = n % 10;
            sum += d;
            product *= d;
            n /= 10;
        }
        return sum == product;
    }

    static bool IsAutomorphic(int n) {
        int square = n * n;
        return square.ToString().EndsWith(n.ToString());
    }

    static bool IsBuzz(int n) {
        return n % 7 == 0 || n % 10 == 7;
    }
}
