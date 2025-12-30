using System;


class BookLibrary
{
    private static string[] bookNames =
        {
            "Clean Code",
            "The Alchemist",
            "Atomic Habits",
            "Rich Dad Poor Dad",
            "Think and Grow Rich",
            "The Power of Now",
            "Introduction to Algorithms",
            "The Pragmatic Programmer",
            "Zero to One",
            "Deep Work"
        };
    private static string[] authors =
        {
            "Robert C. Martin",
            "Paulo Coelho",
            "James Clear",
            "Robert T. Kiyosaki",
            "Napoleon Hill",
            "Eckhart Tolle",
            "Thomas H. Cormen",
            "Andrew Hunt",
            "Peter Thiel",
            "Cal Newport"
        };
    static bool[] status = new bool[10];
    public void Display()
    {
        for (int i = 0; i < status.Length; i++)
        {
            if (!status[i])
            {
                Console.WriteLine(i + ". Book: " + bookNames[i] + " Author: " + authors[i]);
            }
        }
    }
    public void Issue()
    {
        Console.WriteLine("Enter Number of Book: ");
        int i = int.Parse(Console.ReadLine());
        if (status[i])
        {
            Console.WriteLine("This book is Not available");
        }
        else
        {
            Console.WriteLine("Issued Book: " + bookNames[i] + " Author: " + authors[i]);
            status[i] = true;
        }
    }
    public void Return()
    {
        Console.WriteLine("Enter Number of Book for return: ");
        int i = int.Parse(Console.ReadLine());
        status[i] = false;
        Console.WriteLine("Book returned!!!");
    }
}
class Library
{
    static void Main()
    {
        BookLibrary user = new BookLibrary();
        while (true)
        {
            Console.WriteLine("1. Display Books");
            Console.WriteLine("2. Issue Book");
            Console.WriteLine("3. Return Book");
            Console.WriteLine("4. Exit");
            Console.Write("Enter Number: ");
            int i = int.Parse(Console.ReadLine());
            if (i == 1)
            {
                user.Display();
            }
            else if (i == 2)
            {
                user.Issue();
            }
            else if (i == 3)
            {
                user.Return();
            }
            else if (i == 4)
            {
                break;
            }
            else
            {
                Console.WriteLine("Enter A valid Number.");
            }
        }
    }
}