using TransportOrderApp.Models;
using TransportOrderApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TransportOrderApp.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly IOrderService _orderService;

        public CreateModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [BindProperty]
        public Order Order { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _orderService.AddOrder(Order);
            return RedirectToPage("Index");
        }
    }
}