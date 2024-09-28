using asp_empty.Data;
using asp_empty.Models;
using asp_empty.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace asp_empty.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {

            var books = _bookService.GetBooks();

            var view = new BookViewModel(books);

            return View(view);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {

            book.ToString();
            if (ModelState.IsValid)
            {
                _bookService.AddBook(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}
