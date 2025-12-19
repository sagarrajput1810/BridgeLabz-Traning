using System;

class FeeDiscountInput
{
    static void Main()
    {
        Console.Write("Enter fee: ");
        double fee = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter d percent: ");
        double dPercent = Convert.ToDouble(Console.ReadLine());

        double d = (fee * dPercent) / 100;
        double finalFee = fee - d;
        Console.WriteLine("final discounted fee is INR " + finalFee);
    }
}
