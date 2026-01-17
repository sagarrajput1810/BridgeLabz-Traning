using System;
using System.Collections.Generic;

namespace BookShelf
{
    public class BookShelf
    {
        private Dictionary<string, CustomLinkedList> catalog;

        public BookShelf()
        {
            catalog = new Dictionary<string, CustomLinkedList>();
        }

        public void AddBook(string genre, string bookTitle)
        {
            if (!catalog.ContainsKey(genre))
            {
                catalog[genre] = new CustomLinkedList();
            }
            catalog[genre].AddLast(bookTitle);
        }

        public void RemoveBook(string genre, string bookTitle)
        {
            if (catalog.ContainsKey(genre))
            {
                catalog[genre].Remove(bookTitle);
            }
        }

        public void Display()
        {
            foreach (var genre in catalog)
            {
                Console.WriteLine($"Genre: {genre.Key}");
                foreach (var book in genre.Value.GetValues())
                {
                    Console.WriteLine($"- {book}");
                }
            }
        }
    }
}
