using System;
class Bank
{
    static void Main()
    {
        BankManager manager = new BankManager();
        Client[] clients = new Client[1000];
        int index = 0;
        while (true)
        {
            Console.WriteLine("\nEnter role: manager | user | exit");
            string role = Console.ReadLine();
            if (role == "manager")
            {
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Update Balance");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Opening Balance: ");
                        int openingBalance = int.Parse(Console.ReadLine());

                        clients[index] = manager.CreateAccount(index, name, openingBalance);

                        Console.WriteLine("Account Created Successfully");
                        Console.WriteLine("Account Number: " + index);
                        Console.WriteLine("Opening Balance: " + openingBalance);
                        index++;
                        break;

                    case 2:
                        Console.Write("Enter Account Number: ");
                        int acc = int.Parse(Console.ReadLine());

                        Console.Write("Enter Amount to Add: ");
                        int amt = int.Parse(Console.ReadLine());

                        manager.UpdateBalance(clients[acc], amt);
                        break;
                }
            }
            else if (role == "user")
            {
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                int choice = int.Parse(Console.ReadLine());
                Console.Write("Enter Account Number: ");
                int num = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Balance: " + clients[num].CheckBalance());
                        break;

                    case 2:
                        Console.Write("Enter Amount: ");
                        int dep = int.Parse(Console.ReadLine());
                        clients[num].Deposit(dep);
                        break;

                    case 3:
                        Console.Write("Enter Amount: ");
                        int wd = int.Parse(Console.ReadLine());
                        clients[num].Withdraw(wd);
                        break;
                }
            }
            else
            {
                break;
            }
        }
    }
}
public class BankAccount
{
    private double bankBalance;
    public void SetValue(double amount)
    {
        bankBalance = amount;
    }
    public double CheckBalance()
    {
        return bankBalance;
    }
}
public class Client : BankAccount
{
    public string Name;
    int AccountNumber;
    public Client(int number, string name, int openingAmount)
    {
        AccountNumber = number;
        Name = name;
        SetValue(openingAmount);
    }
    public void Deposit(int amount)
    {
        SetValue(CheckBalance() + amount);
        Console.WriteLine("Deposit Successful");
    }
    public void Withdraw(int amount)
    {
        if (amount > CheckBalance())
        {
            Console.WriteLine("Insufficient Balance");
            return;
        }
        SetValue(CheckBalance() - amount);
        Console.WriteLine("Withdrawal Successful");
    }
}
public class BankManager
{
    public Client CreateAccount(int accNo, string name, int openingAmount)
    {
        return new Client(accNo, name, openingAmount);
    }
    public void UpdateBalance(Client client, int amount)
    {
        client.Deposit(amount);
        Console.WriteLine("Updated Balance: " + client.CheckBalance());
    }
}