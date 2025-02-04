using Microsoft.AspNetCore.Mvc;

namespace PastryShop.Controllers;

public class PieController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}