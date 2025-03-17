using TransportOrderApp.Models;
using TransportOrderApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ����������� ��������� ���� ������
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// ����������� �������
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddRazorPages();

var app = builder.Build();

// ���������� ������������ middleware
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