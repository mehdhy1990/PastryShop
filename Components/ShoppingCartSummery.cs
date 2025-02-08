using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PastryShop.Models;
using PastryShop.ViewModel;

namespace PastryShop.Components;

public class ShoppingCartSummery : ViewComponent
{
    private readonly IShoppingCart _shoppingCart;

    public ShoppingCartSummery(IShoppingCart shoppingCart)
    {
        _shoppingCart = shoppingCart;
    }

    public IViewComponentResult Invoke()
    {
        var items = _shoppingCart.GetShoppingCardItems();
        _shoppingCart.ShoppingCartItems = items;
        var shopingcartViewModel = new ShoppingCartViewModel(_shoppingCart,_shoppingCart.GetShoppingCartTotal());
        return View(shopingcartViewModel);
    }
}