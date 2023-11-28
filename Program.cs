using System;
using System.Collections.Generic;

namespace Ass22BuidingLibrarymanagementSystem
{
    public class Program
    {
        public class Book 
        {
            
            public int BookId { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }
            public bool IsAvailable { get; set; }
        }
        

        public class Library
        {
            
            private List<Book> books = new List<Book>();

            
            public void AddBook(Book book)

            {
                books.Add(book);
                Console.WriteLine("Book added successfully!");
            }

            public void ViewAllBooks()
            {
                Console.WriteLine("All Books in the Library:");
                foreach (var item in books)
                {
                    
                    Console.WriteLine($"ID: {item.BookId}, Title: {item.Title}, Author: {item.Author}, Genre: {item.Genre}, Available: {item.IsAvailable}");
                }
            }

            public void SearchBookById(int bookId)
            {
                var book = books.Find(b => b.BookId == bookId);
                if (book != null)
                {
                    Console.WriteLine($"Book found - ID: {book.BookId}, Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Available: {book.IsAvailable}");
                }
                else
                {
                    Console.WriteLine("Book not found!");
                }
             }

            public void SearchBookByTitle(string title)
            {
                var book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
                if (book != null)
                {
                    Console.WriteLine($"Book found - ID: {book.BookId}, Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Available: {book.IsAvailable}");
                }
                else
                {
                    Console.WriteLine("Book not found!");
                }
            }
        }


    static void Main()
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("\nLibrary Management System :");
            Console.WriteLine("1. Add a Book");
            Console.WriteLine("2. View All Books");
            Console.WriteLine("3. Search by ID");
            Console.WriteLine("4. Search by Title");
            Console.WriteLine("5. Exit");

            Console.Write("choose the option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Book newBook = new Book();
                    Console.Write("Enter Book ID: ");
                    newBook.BookId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Title: ");
                    newBook.Title = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    newBook.Author = Console.ReadLine();
                    Console.Write("Enter Genre: ");
                    newBook.Genre = Console.ReadLine();
                    Console.Write("Is the book available? (true/false): ");
                    newBook.IsAvailable = bool.Parse(Console.ReadLine());

                    library.AddBook(newBook);
                    break;

                case 2:
                    library.ViewAllBooks();
                    break;

                case 3:
                    Console.Write("Enter Book ID to search: ");
                    int searchId = int.Parse(Console.ReadLine());
                    library.SearchBookById(searchId);
                    break;

                case 4:
                    Console.Write("Enter Title to search: ");
                    string searchTitle = Console.ReadLine();
                    library.SearchBookByTitle(searchTitle);
                    break;

                case 5:
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}
}