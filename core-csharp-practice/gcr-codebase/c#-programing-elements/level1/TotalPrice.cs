using System;

class TotalPrice
{
    static void Main()
    {
        Console.Write("Enter unit price: ");
        double unitPrice = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter quantity: ");
        int q = Convert.ToInt32(Console.ReadLine());

        double total = unitPrice * q;

        Console.WriteLine(
            "The total purchase price is INR "
                + total
                + " if the q "
                + quantity
                + " and unit price is INR "
                + unitPrice
        );
    }
}
