namespace PastryShop.Models;

public interface IShoppingCard
{
    void AddToCart(Pie pie);
    int RemoveFromCart(Pie pie);
    List<ShoppingCartItems> GetShoppingCardItems();
    void ClearCart();
    decimal GetShoppingCartTotal();
    List<ShoppingCartItems> ShoppingCartItems { get; set; }
}