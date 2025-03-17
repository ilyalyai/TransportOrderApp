using TransportOrderApp.Models;
using TransportOrderApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TransportOrderApp.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderService _orderService;

        public DetailsModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Order Order { get; set; }

        public IActionResult OnGet(int id)
        {
            Order = _orderService.GetOrderById(id);
            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}