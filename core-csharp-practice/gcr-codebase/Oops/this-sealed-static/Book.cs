using System;

class Book
{
    public static string libraryName;

    private string title;
    private string author;
    public readonly long isbn;   // FIX 1: int → long

    public Book(string title, string author, long isbn) // FIX 2
    {
        this.title = title;
        this.author = author;
        this.isbn = isbn;
    }

    public void Display()
    {
        Console.WriteLine("Library : " + libraryName);
        Console.WriteLine("Title   : " + title);
        Console.WriteLine("Author  : " + author);
        Console.WriteLine("ISBN    : " + isbn);
    }

    static void Main(string[] args)
    {
        // Hard-coded static value
        Book.libraryName = "Central City Library";

        // Hard-coded object creation
        object obj = new Book(
            "The Pragmatic Programmer",
            "Andrew Hunt & David Thomas",
            9780201616224L   // FIX 3: add L
        );

        // Type checking and casting
        if (obj is Book)
        {
            Book book = (Book)obj;
            book.Display();
        }
    }
}
