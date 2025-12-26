// Matrix operations
using System;

class MatrixOperations {
    static void Main(string[] args) {
        int[,] A = CreateMatrix(2, 2);
        int[,] B = CreateMatrix(2, 2);

        Console.WriteLine("Matrix A:");
        Display(A);
        Console.WriteLine("Matrix B:");
        Display(B);

        Console.WriteLine("Addition:");
        Display(Add(A, B));

        Console.WriteLine("Transpose A:");
        Display(Transpose(A));

        Console.WriteLine("Determinant A = " + Determinant2x2(A));
    }

    static int[,] CreateMatrix(int r, int c) {
        Random rnd = new Random();
        int[,] m = new int[r, c];
        for (int i = 0; i < r; i++)
            for (int j = 0; j < c; j++)
                m[i, j] = rnd.Next(1, 9);
        return m;
    }

    static int[,] Add(int[,] a, int[,] b) {
        int[,] r = new int[2, 2];
        for (int i = 0; i < 2; i++)
            for (int j = 0; j < 2; j++)
                r[i, j] = a[i, j] + b[i, j];
        return r;
    }

    static int[,] Transpose(int[,] m) {
        int[,] t = new int[2, 2];
        for (int i = 0; i < 2; i++)
            for (int j = 0; j < 2; j++)
                t[j, i] = m[i, j];
        return t;
    }

    static int Determinant2x2(int[,] m) {
        return (m[0,0] * m[1,1]) - (m[0,1] * m[1,0]);
    }

    static void Display(int[,] m) {
        for (int i = 0; i < m.GetLength(0); i++) {
            for (int j = 0; j < m.GetLength(1); j++)
                Console.Write(m[i,j] + " ");
            Console.WriteLine();
        }
    }
}
