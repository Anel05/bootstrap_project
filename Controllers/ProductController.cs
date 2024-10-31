using bootstrap_project.Interfaces;
using bootstrap_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace bootstrap_project.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.AddProductAsync(product);
                TempData["SuccessMessage"] = "Продукт успешно добавлен!";
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}


