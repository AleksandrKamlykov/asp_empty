using asp_empty.Data;
using asp_empty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_empty.Controllers
{
    public class CompanyController : Controller
    {
        private readonly DataBase _context;
        public CompanyController(DataBase context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View( await _context.Companies.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Company company = await _context.Companies.FirstOrDefaultAsync(p => p.Id == id);
                if (company != null)
                    return View(company);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Company company = await _context.Companies.FirstOrDefaultAsync(p => p.Id == id);
                if (company != null)
                    return View(company);
            }
            return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Company company = new Company { Id = id.Value };
                _context.Entry(company).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

    }
}
