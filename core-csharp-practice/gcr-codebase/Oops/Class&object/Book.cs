using System;

class Book
{
    // Private fields
    private string title;
    private string author;
    private double price;

    // Constructor
    public Book(string title, string author, double price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
    }

    // Method to display book details
    public void DisplayDetails()
    {
        Console.WriteLine("Book Title: " + title);
        Console.WriteLine("Author: " + author);
        Console.WriteLine("Price: " + price);
    }
}

class Program
{
    static void Main()
    {
        Book book = new Book("C# Basics", "John Doe", 399);
        book.DisplayDetails();
    }
}
