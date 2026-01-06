using System;

class PaymentGateWay
{

    static void Main()
    {
        double[] payments = new double[1000];
        Payment payment = new Payment();
        int index = 0;
        while (true)
        {
            Console.WriteLine("Enter Value");
            Console.WriteLine("VIP");
            Console.WriteLine("Non-VIP");
            Console.WriteLine("exit");
            string catagory = Console.ReadLine();
            if (catagory == "exit") break;
            Console.WriteLine("Enter Payment Amount");
            double amount = double.Parse(Console.ReadLine());
            Console.WriteLine("Select Methond");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. Debit Card");
            Console.WriteLine("3. Cash");
            int i = int.Parse(Console.ReadLine());

            switch (i)
            {
                case 1:
                    payments[index++] = payment.Transaction(amount, catagory, "Credit Card");
                    break;
                case 2:
                    payments[index++] = payment.Transaction(amount, catagory, "Debit  Card");
                    break;
                case 3:
                    payments[index++] = payment.Transaction(amount, catagory, "Cash");
                    break;
                default:
                    Console.WriteLine("Invalid Value");
                    break;
            }

        }

    }
}

class Payment
{
    public double Transaction(double amount, string catagory, string method)
    {
        if (catagory.ToLower() == "Vip")
        {
            Console.WriteLine("Selected Method: " + method);
            Console.WriteLine("20% Discount");
            Console.WriteLine("Press enter to pay this amount: " + (amount * 80 / 100));
            string s = Console.ReadLine();
            Console.WriteLine("Payment Successful");
            return amount * 80 / 100;
        }
        else
        {
            Console.WriteLine("Selected Method: " + method);
            Console.WriteLine("Press enter to pay this amount: " + (amount));
            string s = Console.ReadLine();
            Console.WriteLine("Payment Successful");
            return amount;
        }
    }
}

