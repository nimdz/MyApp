using Microsoft.AspNetCore.Mvc;
using Myapp.Models;
using MyApp.Data;
using System.Linq;

namespace MyApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly MyAppContext _context;

        public ItemsController(MyAppContext context)
        {
            _context = context;
        }

        // Overview / List
        public IActionResult Overview()
        {
            var items = _context.Items.ToList();
            return View(items);
        }

        // Create - GET
        public IActionResult Create()
        {
            return View();
        }

        // Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                _context.SaveChanges();
                return RedirectToAction(nameof(Overview));
            }
            return View(item);
        }

        // Edit - GET
        public IActionResult Edit(int id)
        {
            var item = _context.Items.Find(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // Edit - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Item item)
        {
            if (id != item.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                _context.Items.Update(item);
                _context.SaveChanges();
                return RedirectToAction(nameof(Overview));
            }
            return View(item);
        }
    }
}
