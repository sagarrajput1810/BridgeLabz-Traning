using System;
using System.Collections;
using System.Collections.Generic;

public class InvalidBookFormatException : Exception
{
	public InvalidBookFormatException() : base("Book must be in the format 'Title - Author'.") { }
	public InvalidBookFormatException(string message) : base(message) { }
}

public class BookBuddy
{
	private ArrayList books = new ArrayList();

	public void addBook(string title, string author)
	{
		if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
			throw new InvalidBookFormatException();

		string entry = title.Trim() + " - " + author.Trim();
		books.Add(entry);
	}

	// Optional: accept a single string like "Title - Author"
	public void addBookEntry(string entry)
	{
		if (string.IsNullOrWhiteSpace(entry))
			throw new InvalidBookFormatException();

		string[] parts = entry.Split(new string[] { " - " }, StringSplitOptions.None);
		if (parts.Length != 2 || string.IsNullOrWhiteSpace(parts[0]) || string.IsNullOrWhiteSpace(parts[1]))
			throw new InvalidBookFormatException();

		books.Add(parts[0].Trim() + " - " + parts[1].Trim());
	}

	public void sortBooksAlphabetically()
	{
		if (books.Count == 0)
			throw new InvalidOperationException("No books to sort.");

		List<string> list = new List<string>();
		foreach (var b in books)
		{
			string s = b as string;
			if (s == null) continue;
			string[] parts = s.Split(new string[] { " - " }, StringSplitOptions.None);
			if (parts.Length != 2)
				throw new InvalidBookFormatException();
			list.Add(s);
		}

		list.Sort((a, b) =>
		{
			string titleA = a.Split(new string[] { " - " }, StringSplitOptions.None)[0].Trim();
			string titleB = b.Split(new string[] { " - " }, StringSplitOptions.None)[0].Trim();
			int cmp = string.Compare(titleA, titleB, StringComparison.OrdinalIgnoreCase);
			if (cmp != 0) return cmp;
			string authA = a.Split(new string[] { " - " }, StringSplitOptions.None)[1].Trim();
			string authB = b.Split(new string[] { " - " }, StringSplitOptions.None)[1].Trim();
			return string.Compare(authA, authB, StringComparison.OrdinalIgnoreCase);
		});

		books = new ArrayList(list);
	}

	public ArrayList searchByAuthor(string author)
	{
		if (books.Count == 0)
			throw new InvalidOperationException("Book list is empty.");

		if (string.IsNullOrWhiteSpace(author))
			return new ArrayList();

		ArrayList results = new ArrayList();
		foreach (var item in books)
		{
			string s = item as string;
			if (s == null) continue;
			string[] parts = s.Split(new string[] { " - " }, StringSplitOptions.None);
			if (parts.Length != 2)
				throw new InvalidBookFormatException();

			string bookAuthor = parts[1].Trim();
			if (bookAuthor.IndexOf(author.Trim(), StringComparison.OrdinalIgnoreCase) >= 0)
				results.Add(s);
		}

		return results;
	}

	public string[] exportToArray()
	{
		string[] arr = new string[books.Count];
		books.CopyTo(arr);
		return arr;
	}

	public static void Main(string[] args)
	{
		BookBuddy bb = new BookBuddy();

		try
		{
			bb.addBook("The Hobbit", "J.R.R. Tolkien");
			bb.addBookEntry("1984 - George Orwell");
			bb.addBook("To Kill a Mockingbird", "Harper Lee");

			Console.WriteLine("Before sorting:");
			foreach (var b in bb.books) Console.WriteLine(b);

			bb.sortBooksAlphabetically();
			Console.WriteLine("\nAfter sorting:");
			foreach (var b in bb.books) Console.WriteLine(b);

			Console.WriteLine("\nSearch by author 'George':");
			ArrayList found = bb.searchByAuthor("George");
			foreach (var f in found) Console.WriteLine(f);

			Console.WriteLine("\nExporting to array:");
			string[] exported = bb.exportToArray();
			foreach (var e in exported) Console.WriteLine(e);
		}
		catch (InvalidBookFormatException ex)
		{
			Console.WriteLine("Format error: " + ex.Message);
		}
		catch (InvalidOperationException ex)
		{
			Console.WriteLine("Operation error: " + ex.Message);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Unexpected error: " + ex.Message);
		}
	}
}