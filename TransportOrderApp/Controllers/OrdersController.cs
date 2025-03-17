using Microsoft.AspNetCore.Mvc;
using TransportOrderApp.Models;

namespace TransportOrderApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // Метод для отображения списка заказов
        public IActionResult Index()
        {
            // Получаем список заказов из базы данных
            List<Order> orders = _context.Orders.ToList();

            // Передаем список заказов в представление
            return View(orders);
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public IActionResult Create()
        {
            return View();
        }

        // Метод для просмотра деталей заказа (если нужно)
        public IActionResult Details(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}