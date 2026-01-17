using System;

namespace BookShelf
{
    class Program
    {
                static void Main(string[] agrs)
                {
                    BookShelf myBookShelf = new BookShelf();
        
                    myBookShelf.AddBook("Fiction", "The Great Gatsby");
                    myBookShelf.AddBook("Fiction", "To Kill a Mockingbird");
                    myBookShelf.AddBook("Non-Fiction", "Sapiens: A Brief History of Humankind");
                    myBookShelf.AddBook("Science Fiction", "Dune");
        
                    Console.WriteLine("Initial Catalog:");
                    myBookShelf.Display();
        
                    Console.WriteLine("\nRemoving 'To Kill a Mockingbird'...");
                    myBookShelf.RemoveBook("Fiction", "To Kill a Mockingbird");
        
                    Console.WriteLine("\nUpdated Catalog:");
                    myBookShelf.Display();
                }﻿    }
}
