using asp_empty.Models;

namespace asp_empty.ViewModels
{
    public class BookViewModel
    {
        public List<Book> Books { get; set; } = new List<Book>();

        public BookViewModel(List<Book> books)
        {
            Books = books;
        }
    }
}
