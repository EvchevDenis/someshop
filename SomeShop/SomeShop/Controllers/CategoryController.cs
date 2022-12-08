using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SomeShop.Infrastructure;
using SomeShop.Models;
using System;

namespace SomeShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(_context.Categories);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            category.Slug = category.Name.ToLower().Replace(" ", "-");

            if (ModelState.IsValid)
            {
                var slug = await _context.Categories.FirstOrDefaultAsync(p => p.Slug == category.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The category already exists");
                    return View(category);
                }
                _context.Categories.Add(category);
                _context.SaveChanges();

                return RedirectToAction("Create");
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(long id)
        {
            Category category = await _context.Categories.FindAsync(id);

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            TempData["Success"] = "The category has been deleted";

            return RedirectToAction("Index");

        }
    }
}