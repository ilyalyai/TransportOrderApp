using TransportOrderApp.Services;
using TransportOrderApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Регистрация сервиса
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Дальнейшая конфигурация middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();