// Find maximum number of handshakes
using System;

class HandshakeProgram {
    static void Main(string[] args) {
        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int handshakes = CalculateHandshakes(n);
        Console.WriteLine("Maximum Handshakes = " + handshakes);
    }

    // Method using combination formula
    static int CalculateHandshakes(int n) {
        return (n * (n - 1)) / 2;
    }
}
