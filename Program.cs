using PastryShop.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
builder.Services.AddScoped<IPieRepository, MockPieRepository>();
app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();
app.Run();
