// Services/IOrderService.cs
using TransportOrderApp.Models;
using System.Collections.Generic;

namespace TransportOrderApp.Services
{
    public interface IOrderService
    {
        void AddOrder(Order order);
        List<Order> GetOrders();
        Order GetOrderById(int id);
    }
}