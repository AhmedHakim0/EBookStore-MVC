using EBookStore.DataAccess.Repository.IRepository;
using EBookStore.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EBookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public IActionResult Index()
        {
           List<Product> ProductList = unitOfWork.ProductRepository.GetAll().ToList();
            return View(ProductList);
        }
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = unitOfWork.categoryRepository
               .GetAll().Select(u => new SelectListItem
               {
                   Text = u.Name,
                   Value = u.Id.ToString()
               });
            ViewData["CategoryList"] = CategoryList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (product.Title == product.Author)
            {
                ModelState.AddModelError("", "Title can't be exactly match Author");
            }
            if (ModelState.IsValid)
            {
               unitOfWork.ProductRepository.Add(product);
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

            Product? product = unitOfWork.ProductRepository.Get(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Edite(Product product)
        {
            if (product.Title == product.Author)
            {
                ModelState.AddModelError("", "Title can't be exactly match Author");
            }
            if (ModelState.IsValid)
            {
                unitOfWork.ProductRepository.Update(product);
                unitOfWork.Save();
                TempData["Success"] = "Product Updated Succesfully";
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
            Product? product = unitOfWork.ProductRepository.Get(c=>c.Id==id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? product = unitOfWork.ProductRepository.Get(c => c.Id == id);

            unitOfWork.ProductRepository.Remove(product);
            unitOfWork.Save();
             TempData["Success"] = "Product Deleted Succesfully";
            return RedirectToAction("Index");

        }
    }
}
