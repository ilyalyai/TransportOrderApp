using TransportOrderApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TransportOrderApp.Models;

namespace TransportOrderApp.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;

        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public List<Order> Orders { get; set; }

        public void OnGet()
        {
            Orders = _orderService.GetOrders();
        }
    }
}