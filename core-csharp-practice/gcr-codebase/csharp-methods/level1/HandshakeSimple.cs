// Find number of possible handshakes

using System;

class HandshakeSimple {
    static void Main(string[] args) {
        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int result = (n * (n - 1)) / 2;
        Console.WriteLine("Possible Handshakes = " + result);
    }
}
