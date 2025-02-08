using PastryShop.Models;

namespace PastryShop.ViewModel;

public class ShoppingCardViewModel
{
    public IShoppingCart shoppingCart { get; set; }
    public decimal ShoppingCardTotal { get; set; }

    public ShoppingCardViewModel(IShoppingCart shoppingCart, decimal shoppingCardTotal)
    {
        shoppingCart = shoppingCart;
        ShoppingCardTotal = shoppingCardTotal;
    }
}