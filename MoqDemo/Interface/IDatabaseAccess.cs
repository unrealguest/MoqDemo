using System.Collections.Generic;
using MockingDemo.Model;

namespace MockingDemo.Interface
{
    public interface IDatabaseAccess
    {
        Book GetBookByIsbn(string isbn);
        public List<Book> GetAllBooks();

        Author GetAuthorById(long id);
        List<Author> GetAllAuthors();        
    }
}
