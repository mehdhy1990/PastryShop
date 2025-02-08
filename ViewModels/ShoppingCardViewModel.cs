using PastryShop.Models;

namespace PastryShop.ViewModel;

public class ShoppingCardViewModel
{
    public IShoppingCard ShoppingCard { get; set; }
    public decimal ShoppingCardTotal { get; set; }

    public ShoppingCardViewModel(IShoppingCard shoppingCard, decimal shoppingCardTotal)
    {
        ShoppingCard = shoppingCard;
        ShoppingCardTotal = shoppingCardTotal;
    }
}