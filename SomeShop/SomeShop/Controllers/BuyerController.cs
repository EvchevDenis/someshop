using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SomeShop.Infrastructure;
using SomeShop.Models;

namespace SomeShop.Areas.Controllers
{
    public class BuyerController : Controller
    {
        private readonly DataContext _context;

        public BuyerController(DataContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(_context.Buyers);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                _context.Buyers.Add(buyer);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(buyer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Buyer buyer = await _context.Buyers.FindAsync(id);

            _context.Buyers.Remove(buyer);
            await _context.SaveChangesAsync();

            TempData["Success"] = "The order has been deleted";

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(int id)
        {
            
             Buyer buyer = await _context.Buyers.FirstOrDefaultAsync(p => p.Id == id);
             if (buyer != null) return View(buyer);
          
            return NotFound();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Buyer buyer)
        {
            _context.Buyers.Update(buyer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}
