using System;

class Book
{
    private string title;
    private string author;
    private double price;

    // Default constructor
    public Book()
    {
        title = "Not Assigned";
        author = "Not Assigned";
        price = 0.0;
    }

    // Parameterized constructor
    public Book(string title, string author, double price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
    }

    public void Display()
    {
        Console.WriteLine("Title  : " + title);
        Console.WriteLine("Author : " + author);
        Console.WriteLine("Price  : " + price);
    }

    static void Main(string[] args)
    {
        // Hard-coded values
        Book book1 = new Book("Clean Code", "Robert C. Martin", 599.50);

        book1.Display();
    }
}
