using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw_9
{
    internal class Program
    {
        public class Book
        {
            private string _title;
            private string _author;
            private double _price;
            private readonly string _isbn;
            private DateTime _date;

            public Book(string title, string author, double price, string isbn, DateTime date)
            {
                _title = title;
                _author = author;
                _price = price;
                _isbn = isbn;
                _date = date;
            }

            public string Title => _title;
            public string Author => _author;
            public double Price => _price;
            public string ISBN => _isbn;
            public DateTime Date => _date;

            public override string ToString()
            {
                return $"Title: {_title}, Author: {_author}, Price: {_price:C}, ISBN: {_isbn}, Date: {_date:yyyy-MM-dd}";
            }
        }

        public class BookLibrary
        {
            private static readonly BookLibrary _instance = new BookLibrary();
            private List<Book> _books = new List<Book>();

            private BookLibrary() { }

            public static BookLibrary Instance => _instance;

            public bool AddBook(Book book)
            {
                if (_books.Any(b => b.ISBN == book.ISBN))
                {
                    Console.WriteLine($"Książka z ISBN {book.ISBN} już istnieje.");
                    return false;
                }
                _books.Add(book);
                return true;
            }

            public bool RemoveBook(string isbn)
            {
                var book = _books.FirstOrDefault(b => b.ISBN == isbn);
                if (book != null)
                {
                    _books.Remove(book);
                    return true;
                }
                Console.WriteLine($"Nie znaleziono książki z ISBN {isbn}.");
                return false;
            }

            public IEnumerable<Book> SearchByISBN(string isbn) => _books.Where(b => b.ISBN == isbn);
            public IEnumerable<Book> SearchByAuthor(string author) => _books.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
            public IEnumerable<Book> SearchByTitle(string title) => _books.Where(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            public IEnumerable<Book> SearchByPrice(double price) => _books.Where(b => b.Price == price);

            public void DisplayAllBooks()
            {
                if (_books.Any())
                {
                    foreach (var book in _books)
                    {
                        Console.WriteLine(book);
                    }
                }
                else
                {
                    Console.WriteLine("Brak książek w bibliotece.");
                }
            }
            public bool BookExists(string isbn) => _books.Any(b => b.ISBN == isbn);
        }

        static void Main(string[] args)
        {
            BookLibrary library = BookLibrary.Instance;

            Book book1 = new Book("C# in Depth", "Jon Skeet", 45.99, "123-4567890123", DateTime.Now);
            Book book2 = new Book("Introduction to Algorithms", "Thomas H. Cormen", 79.99, "987-6543210987", DateTime.Now);

            library.AddBook(book1);
            library.AddBook(book2);

            Book duplicateBook = new Book("Another Book", "Author X", 30.99, "123-4567890123", DateTime.Now);
            library.AddBook(duplicateBook);

            Console.WriteLine("\nAll Books in Library:");
            library.DisplayAllBooks();

            Console.WriteLine("\nBooks by Jon Skeet:");
            foreach (var book in library.SearchByAuthor("Jon Skeet"))
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("\nChecking if ISBN 123-4567890123 exists:");
            Console.WriteLine(library.BookExists("123-4567890123") ? "Book exists." : "Book does not exist.");

            Console.WriteLine("\nRemoving book with ISBN 987-6543210987");
            library.RemoveBook("987-6543210987");

            Console.WriteLine("\nAll Books in Library after removal:");
            library.DisplayAllBooks();
            Console.ReadLine();
        }
    }
}
