using Books2023.Web.Data;
using Books2023.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Books2023.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var categoryList = _db.Categories.ToList();
            return View(categoryList);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid) 
            {
                return View(category);
            }
            if (_db.Categories.Any(c=>c.Name==category.Name))
            {
                ModelState.AddModelError(string.Empty, "Category already exists");
                return View(category);
            }
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            var category = _db.Categories.FirstOrDefault(c=>c.Id==id);
            if (category==null)
            {
                return NotFound();
            }
            return View(category);
        }   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            if (_db.Categories.Any(c => c.Name == category.Name && c.Id == category.Id))
            {
                ModelState.AddModelError(string.Empty, "Category already exists");
                return View(category);
            }
            _db.Categories.Update(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(c=>c.Id ==  id);
            if (category == null)
            {
                ModelState.AddModelError(string.Empty, "Category does not exists");
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
