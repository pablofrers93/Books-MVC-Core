using Books2023.DataLayer.Repository.Interfaces;
using Books2023.Models.Data;
using Books2023.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Books2023.Web.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var categoryList = _unitOfWork.Categories.GetAll();
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
            if (_unitOfWork.Categories.Exists(category))
            {
                ModelState.AddModelError(string.Empty, "Category already exists");
                return View(category);
            }
            _unitOfWork.Categories.Add(category);
            _unitOfWork.Save();
            TempData["Success"] = "Record added succesfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.Categories.Get(c => c.Id == id);
            if (category == null)
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
            if (_unitOfWork.Categories.CheckNoChanges(category))
            {
                ModelState.AddModelError(string.Empty, "No changes");
                return View(category);
            }
            if (_unitOfWork.Categories.Exists(category))
            {
                ModelState.AddModelError(string.Empty, "Category already exists");
                return View(category);
            }
            _unitOfWork.Categories.Update(category);
            _unitOfWork.Save();
            TempData["Success"] = "Record updated succesfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.Categories.Get(c => c.Id == id);
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
            var category = _unitOfWork.Categories.Get(c => c.Id == id);
            if (category == null)
            {
                ModelState.AddModelError(string.Empty, "Category does not exists");
            }
            _unitOfWork.Categories.Delete(category);
            _unitOfWork.Save();
            TempData["Success"] = "Record removed succesfully";
            return RedirectToAction("Index");
        }
    }
}
