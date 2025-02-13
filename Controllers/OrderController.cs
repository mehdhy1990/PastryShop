using Microsoft.AspNetCore.Mvc;
using PastryShop.Models;

namespace PastryShop.Controllers;

public class OrderController : Controller
{
    private readonly IOrderRepository _orderRepository;
    private readonly IShoppingCart _shoppingCart;

    public OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart)
    {
        _orderRepository = orderRepository;
        _shoppingCart = shoppingCart;
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

    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        var items = _shoppingCart.GetShoppingCardItems();
        _shoppingCart.ShoppingCartItems = items;
        if (_shoppingCart.ShoppingCartItems.Count == 0)
        {
            ModelState.AddModelError("","your cart is empty add some pies first");
        }

        if (ModelState.IsValid)
        {
            _orderRepository.CreateOrder(order);
            _shoppingCart.ClearCart();
            return RedirectToAction("CheckoutComplete");
        }
        return View(order);
    }

    public IActionResult CheckoutComplete()
    {
        ViewBag.CheckoutCompleteMessage = "Thank you for your paying order!";
        return View();
    }
}