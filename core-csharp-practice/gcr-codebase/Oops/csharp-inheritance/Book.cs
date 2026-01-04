using System;

// Superclass
class Book
{
    public string Title;
    public int PublicationYear;
}

// Subclass
class Author : Book
{
    public string Name;
    public string Bio;

    public void DisplayInfo()
    {
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Publication Year: " + PublicationYear);
        Console.WriteLine("Author Name: " + Name);
        Console.WriteLine("Bio: " + Bio);
    }
}

class BookTest
{
    static void Main()
    {
        Author a = new Author();
        a.Title = "C# Basics";
        a.PublicationYear = 2024;
        a.Name = "John";
        a.Bio = "Software Developer";

        a.DisplayInfo();
    }
}
