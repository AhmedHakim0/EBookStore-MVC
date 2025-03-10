using EBookStore.Data;
using EBookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EBookStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;

        public CategoryController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            List<Category> CategoryList = db.Categories.ToList();
            return View(CategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("", "the Display order can't be exactly match name");
            }
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                TempData["Success"] = "Category Created Succesfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edite(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edite(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("", "the Display order can't be exactly match name");
            }
            if (ModelState.IsValid)
            {
                db.Categories.Update(category);
                db.SaveChanges();
                TempData["Success"] = "Category Updated Succesfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = db.Categories.Find(id);

            db.Categories.Remove(category);
            db.SaveChanges();
            TempData["Success"] = "Category Deleted Succesfully";
            return RedirectToAction("Index");

        }
    }
}
