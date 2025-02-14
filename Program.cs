using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PastryShop.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<PastryShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PastryShopConnectionString"))
);
builder.Services.AddControllersWithViews().AddJsonOptions(options=>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    );

var app = builder.Build();
app.UseStaticFiles();
app.UseSession();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

app.Run();