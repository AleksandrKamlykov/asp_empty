using asp_empty.Models;
using asp_empty.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using asp_empty.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace asp_empty.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataBase _context;

        public HomeController(DataBase db)
        {
            _context = db;
        }

        public async Task<IActionResult> Index(int? company, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 3;

            //фильтрация
            IQueryable<User> users = _context.Users.Include(x => x.Company);

            if (company != null && company != 0)
            {
                users = users.Where(p => p.CompanyId == company);
            }
            if (!String.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Name.Contains(name));
            }

            // сортировка
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    users = users.OrderByDescending(s => s.Name);
                    break;
                case SortState.AgeAsc:
                    users = users.OrderBy(s => s.Age);
                    break;
                case SortState.AgeDesc:
                    users = users.OrderByDescending(s => s.Age);
                    break;
                case SortState.CompanyAsc:
                    users = users.OrderBy(s => s.Company.Name);
                    break;
                case SortState.CompanyDesc:
                    users = users.OrderByDescending(s => s.Company.Name);
                    break;
                default:
                    users = users.OrderBy(s => s.Name);
                    break;
            }

            // пагинация
            var count = await users.CountAsync();
            var items = await users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(_context.Companies.ToList(), company, name),
                Users = items
            };
            return View(viewModel);
        }
        public async Task<IActionResult> Create()
        {

            ViewBag.Companies = await _context.Companies.ToListAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                var currentUser = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (currentUser != null)
                {
                    return View(currentUser);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var currentUser = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (currentUser != null)
                {
                    _context.Users.Remove(currentUser);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var currentUser = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (currentUser != null)
                {
                    ViewBag.Companies = await _context.Companies.ToListAsync();

                    return View(currentUser);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var currentUser = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (currentUser != null)
                {
                    return View(currentUser);
                }
            }
            return NotFound();
        }

    }
}
