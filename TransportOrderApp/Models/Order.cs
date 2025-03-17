using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TransportOrderApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Город отправителя обязателен.")]
        [StringLength(100, ErrorMessage = "Город отправителя не может превышать 100 символов.")]
        public string SenderCity { get; set; }

        [Required(ErrorMessage = "Адрес отправителя обязателен.")]
        [StringLength(200, ErrorMessage = "Адрес отправителя не может превышать 200 символов.")]
        public string SenderAddress { get; set; }

        [Required(ErrorMessage = "Город получателя обязателен.")]
        [StringLength(100, ErrorMessage = "Город получателя не может превышать 100 символов.")]
        public string ReceiverCity { get; set; }

        [Required(ErrorMessage = "Адрес получателя обязателен.")]
        [StringLength(200, ErrorMessage = "Адрес получателя не может превышать 200 символов.")]
        public string ReceiverAddress { get; set; }

        [Required(ErrorMessage = "Вес груза обязателен.")]
        [Range(0.1, 1000, ErrorMessage = "Вес груза должен быть от 0.1 до 1000 кг.")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Дата забора груза обязательна.")]
        [DataType(DataType.Date, ErrorMessage = "Некорректный формат даты.")]
        public DateTime PickupDate { get; set; }

        [StringLength(500, ErrorMessage = "Описание не может превышать 500 символов.")]
        public string Description { get; set; } // Опциональное поле
    }

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; } // Таблица заказов
    }
}