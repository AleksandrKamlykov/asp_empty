using asp_empty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace asp_empty.Controllers
{
    public class ProductController : Controller
    {
        IEnumerable<Company> companies = new List<Company>
        {
            new Company { Id = 1, Name = "Apple" },
            new Company { Id = 2, Name = "Samsung" },
            new Company { Id = 3, Name = "Google" }
        };
        public IActionResult Create()
        {
            ViewBag.Companies = new SelectList(companies, "Id", "Name");
            return View();
        }


        [HttpPost]
        public string Create(Product product)
        {
            Company company = companies.FirstOrDefault(c => c.Id == product.CompanyId);
            return $"Добавлен новый элемент: {product.Name} ({company?.Name})";
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
