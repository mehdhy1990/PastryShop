using Microsoft.EntityFrameworkCore;
using PastryShop.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddDbContext<PastryShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PastryShopConnectionString"))
);
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();
app.Run();