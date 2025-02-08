using Microsoft.AspNetCore.Mvc;
using PastryShop.Models;

namespace PastryShop.Controllers;

public class OrderController : Controller
{
    private readonly IOrderRepository _orderRepository;
    private readonly IShoppingCart _shoppingCart;

    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Checkout()
    {
        return View();
    }
}