using System.Collections.Generic;
using TransportOrderApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TransportOrderApp.Models
{
    public class Order
    {
        public int Id { get; set; } // Уникальный номер заказа. Автоматически становится ключом с автоинкрементом
        public string SenderCity { get; set; } // Город отправителя
        public string SenderAddress { get; set; } // Адрес отправителя
        public string ReceiverCity { get; set; } // Город получателя
        public string ReceiverAddress { get; set; } // Адрес получателя
        public double Weight { get; set; } // Вес груза
        public DateTime PickupDate { get; set; } // Дата забора груза
    }

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; } // Таблица заказов
    }
}