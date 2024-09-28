using asp_empty.Models;

namespace asp_empty.Data
{
    public class BookService
    {
        private List<Book> _books = new List<Book>
        {
            new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Novel", Year = 1925 },
            new Book { Title = "To Kill a Mocking", Author = "Harper Lee" , Genre="Detective", Year=1122},
            new Book { Title = "1984", Author = "George Orwell", Genre="Roman", Year=1948}
        };
    
         public List<Book> GetBooks()
         {
             return _books;
         }

          public void AddBook(Book book)
          {
              _books.Add(book);
          }
        }
}
