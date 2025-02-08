using Microsoft.AspNetCore.Mvc;
using PastryShop.Models;

namespace PastryShop.Controllers;

public class ShoppingCardController: Controller
{
    private readonly IPieRepository _pieRepository;
    private readonly IShoppingCard _shoppingCard;

    public ShoppingCardController(IPieRepository pieRepository, IShoppingCard shoppingCard)
    {
        _pieRepository = pieRepository;
        _shoppingCard = shoppingCard;
    }
}