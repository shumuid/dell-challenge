using DellChallenge.D2.Web.Models;
using DellChallenge.D2.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DellChallenge.D2.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _productService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(NewProductModel newProduct)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(newProduct);

                return RedirectToAction("Index");
            }

            return View(newProduct);
        }

        public ActionResult Delete(int id)
        {
            var model = _productService.Get(id);

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(ProductModel model)
        {
            _productService.Delete(model.Id);

            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var model = _productService.Get(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product.Id, new NewProductModel() { Name = product.Name, Category = product.Category });

                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}