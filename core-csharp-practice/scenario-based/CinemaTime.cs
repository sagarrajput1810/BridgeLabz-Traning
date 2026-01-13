using System;

class CinemaTime
{
    static void Main(string[] args)
    {
        Movie movie = new Movie();

        while (true)
        {
            Console.WriteLine("Enter Value for select: ");
            Console.WriteLine("1. Add Movie");
            Console.WriteLine("2. Display All Movies");
            Console.WriteLine("3. Search Movies");
            Console.WriteLine("Press Enter for Exit");

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                break;

            int value = int.Parse(input);

            if (value != 1 && value != 2 && value != 3)
                break;

            switch (value)
            {
                case 1:
                    Console.WriteLine("Enter Movie Name: ");
                    string movieName = Console.ReadLine();
                    movie.AddMovie(movieName);
                    break;

                case 2:
                    movie.DisplayMovies();
                    break;

                case 3:
                    Console.WriteLine("Search Movie: ");
                    string searchName = Console.ReadLine();
                    movie.SearchMovies(searchName);
                    break;
            }
        }
    }
}

class Node
{
    public string data;
    public string time;
    public Node next;

    public Node(string data)
    {
        this.data = data;
        this.next = null;
    }
}

class Movie
{
    Node Head = null;

    public void AddMovie(string movieName)
    {
        Node newNode = new Node(movieName);

        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            Node temp = Head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = newNode;
        }
    }

    public void DisplayMovies()
    {
        if (Head == null)
        {
            Console.WriteLine("No movies available!");
            return;
        }

        Node temp = Head;
        while (temp != null)
        {
            Console.WriteLine(temp.data);
            temp = temp.next;
        }
    }
    public void SearchMovies(string movieName)
    {
        Node temp = Head;
        bool found = false;

        while (temp != null)
        {
            if (temp.data.StartsWith(movieName, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(temp.data);
                found = true;
            }
            temp = temp.next;
        }

        if (!found)
        {
            Console.WriteLine("Movie not found!");
        }
    }
}