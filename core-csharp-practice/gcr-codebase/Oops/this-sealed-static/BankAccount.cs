using System;

class BankAccount
{
    public static string bankName;
    private static int totalAccounts = 0;

    private string accountHolderName;
    public readonly int accountNumber;

    public BankAccount(string accountHolderName, int accountNumber)
    {
        this.accountHolderName = accountHolderName;
        this.accountNumber = accountNumber;
        totalAccounts++;
    }

    public void DisplayDetails()
    {
        Console.WriteLine("Bank Name: " + bankName);
        Console.WriteLine("Account Holder: " + accountHolderName);
        Console.WriteLine("Account Number: " + accountNumber);
    }

    public static void GetTotalAccounts()
    {
        Console.WriteLine("Total Accounts: " + totalAccounts);
    }

    static void Main()
    {
        Console.Write("Enter Bank Name: ");
        bankName = Console.ReadLine();

        Console.Write("Enter Account Holder Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Account Number: ");
        int number = int.Parse(Console.ReadLine());

        object acc = new BankAccount(name, number);

        if (acc is BankAccount)
        {
            BankAccount b = (BankAccount)acc;
            b.DisplayDetails();
        }

        BankAccount.GetTotalAccounts();
    }
}

