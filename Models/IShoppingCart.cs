namespace PastryShop.Models;

public interface IShoppingCart
{
    void AddToCart(Pie pie);
    int RemoveFromCart(Pie pie);
    List<ShoppingCartItems> GetShoppingCardItems();
    void ClearCart();
    decimal GetShoppingCartTotal();
    List<ShoppingCartItems> ShoppingCartItems { get; set; }
}