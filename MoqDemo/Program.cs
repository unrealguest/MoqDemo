using System;
using MockingDemo.Database;

namespace dotnetcore
{
    class Program
    {
        static void Main(string[] args)
        {
            using var dbAccess = new DataBaseAccess();

            var books = dbAccess.GetAllBooks();
            var authors = dbAccess.GetAllAuthors();

            foreach (var book in books)
            {
                var author = dbAccess.GetAuthorById(book.AuthoredBy.Id);
                Console.WriteLine($"{book.Title} by {author?.FirstName} {author?.LastName}");
            }

            Console.ReadKey();
        }
    }
}
