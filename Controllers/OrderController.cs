using bootstrap_project.Interfaces;
using bootstrap_project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace bootstrap_project.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderController(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var products = await _productRepository.GetAllProductsAsync();
            ViewBag.Products = products;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                // Добавляем заказ и сохраняем изменения
                await _orderRepository.AddOrderAsync(order);
                await _orderRepository.SaveChangesAsync();

                // Устанавливаем сообщение об успешном добавлении
                TempData["SuccessMessage"] = "Заказ успешно добавлен";
                return RedirectToAction("Index");
            }

            // Лог ошибок для невалидных данных
            foreach (var modelError in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(modelError.ErrorMessage);
            }

            // Загружаем список продуктов для повторного отображения формы
            var products = await _productRepository.GetAllProductsAsync();
            ViewBag.Products = products;

            // Возвращаем форму с отображением ошибок
            return View(order);
        }
    }
}




























