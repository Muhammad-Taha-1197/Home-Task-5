using System;
using System.Collections.Generic;

class Book
{
    public string Title;
    public string Author;
    public string Genre;
    public int PublicationYear;

    public Book(string title, string author, string genre, int year)
    {
        Title = title;
        Author = author;
        Genre = genre;
        PublicationYear = year;
    }

    public void Display()
    {
        Console.WriteLine($"\nTitle: {Title}\nAuthor: {Author}\nGenre: {Genre}\nPublication Year: {PublicationYear}");
        Console.WriteLine("----------------------");
    }
}

class Library
{
    private List<Book> books = new List<Book>();

    public Library()
    {
        books.Add(new Book("C# Basics", "John Doe", "Programming", 2021));
        books.Add(new Book("Python Fundamentals", "Jane Smith", "Programming", 2020));
    }

    public void AddBook()
    {
        Console.Write("Enter Title: ");
        string title = Console.ReadLine();
        Console.Write("Enter Author: ");
        string author = Console.ReadLine();
        Console.Write("Enter Genre: ");
        string genre = Console.ReadLine();
        Console.Write("Enter Publication Year: ");
        int year = int.Parse(Console.ReadLine());

        books.Add(new Book(title, author, genre, year));
        Console.WriteLine("\nBook added successfully!");
    }

    public void ListBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("\nNo books available.");
        }
        else
        {
            Console.WriteLine("\nLibrary Books:");
            foreach (var book in books)
            {
                book.Display();
            }
        }
    }

    public void SearchBooks()
    {
        Console.Write("\nEnter search query: ");
        string query = Console.ReadLine();
        bool found = false;

        Console.WriteLine("\nSearch Results:");
        foreach (var book in books)
        {
            if (book.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                book.Author.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                book.Genre.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                book.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No matching books found.");
        }
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nLibrary Menu:");
            Console.WriteLine("1 - Display Books");
            Console.WriteLine("2 - Input Book");
            Console.WriteLine("3 - Search Any Book");
            Console.WriteLine("4 - Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    library.ListBooks();
                    break;
                case "2":
                    library.AddBook();
                    break;
                case "3":
                    library.SearchBooks();
                    break;
                case "4":
                    exit = true;
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please enter a valid option.");
                    break;
            }
        }
    }
}
