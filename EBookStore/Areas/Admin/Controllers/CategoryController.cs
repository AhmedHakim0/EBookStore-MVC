using EBookStore.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EBookStore.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public IActionResult Index()
        {
           List<Category> CategoryList = unitOfWork.categoryRepository.GetAll().ToList();
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
               unitOfWork.categoryRepository.Add(category);
                unitOfWork.Save();
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

            Category? category = unitOfWork.categoryRepository.Get(c => c.Id == id);
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
                unitOfWork.categoryRepository.Update(category);
                unitOfWork.Save();
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
            Category? category = unitOfWork.categoryRepository.Get(c=>c.Id==id);
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
            Category? category = unitOfWork.categoryRepository.Get(c => c.Id == id);

            unitOfWork.categoryRepository.Remove(category);
            unitOfWork.Save();
             TempData["Success"] = "Category Deleted Succesfully";
            return RedirectToAction("Index");

        }
    }
}
