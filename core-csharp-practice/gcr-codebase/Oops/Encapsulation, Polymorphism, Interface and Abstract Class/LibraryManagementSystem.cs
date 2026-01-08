using System;

interface IReservable
{
    void ReserveItem();
    bool CheckAvailability();
}

abstract class LibraryItem
{
    private int itemId;
    private string title;

    protected LibraryItem(int id, string title)
    {
        itemId = id;
        this.title = title;
    }

    public abstract int GetLoanDuration();

    public void GetItemDetails()
    {
        Console.WriteLine("Item ID: " + itemId);
        Console.WriteLine("Title: " + title);
    }
}

class Book : LibraryItem, IReservable
{
    private bool available = true;

    public Book(int id, string title)
        : base(id, title) { }

    public override int GetLoanDuration()
    {
        return 14;
    }

    public void ReserveItem()
    {
        available = false;
    }

    public bool CheckAvailability()
    {
        return available;
    }
}

class LibraryManagementSystem
{
    static void Main()
    {
        LibraryItem item = new Book(1, "C# Basics");
        item.GetItemDetails();
        Console.WriteLine("Loan Days: " + item.GetLoanDuration());
    }
}
