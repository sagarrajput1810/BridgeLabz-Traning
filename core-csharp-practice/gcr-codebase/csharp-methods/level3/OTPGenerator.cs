// Generate unique OTPs
using System;

class OTPGenerator {
    static void Main(string[] args) {
        int[] otps = new int[10];

        for (int i = 0; i < 10; i++)
            otps[i] = GenerateOTP();

        Console.WriteLine("Unique OTPs = " + AreUnique(otps));
    }

    static int GenerateOTP() {
        Random r = new Random();
        return r.Next(100000, 999999);
    }

    static bool AreUnique(int[] arr) {
        for (int i = 0; i < arr.Length; i++)
            for (int j = i + 1; j < arr.Length; j++)
                if (arr[i] == arr[j]) return false;
        return true;
    }
}
