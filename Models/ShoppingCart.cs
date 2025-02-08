using Microsoft.EntityFrameworkCore;

namespace PastryShop.Models;

public class ShoppingCart : IShoppingCard
{
    private readonly PastryShopDbContext _bethanysPieShopDbContext;

    public string? ShoppingCartId { get; set; }

    public List<ShoppingCartItems> ShoppingCartItems { get; set; } = default!;

    private ShoppingCart(PastryShopDbContext bethanysPieShopDbContext)
    {
        _bethanysPieShopDbContext = bethanysPieShopDbContext;
    }

    public static ShoppingCart GetCart(IServiceProvider services)
    {
        ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

        PastryShopDbContext context =
            services.GetService<PastryShopDbContext>() ?? throw new Exception("Error initializing");

        string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

        session?.SetString("CartId", cartId);

        return new ShoppingCart(context) { ShoppingCartId = cartId };
    }

    public void AddToCart(Pie pie)
    {
        var shoppingCartItem =
            _bethanysPieShopDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItems
            {
                ShoppingCartId = ShoppingCartId,
                Pie = pie,
                Amount = 1
            };

            _bethanysPieShopDbContext.ShoppingCartItems.Add(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Amount++;
        }

        _bethanysPieShopDbContext.SaveChanges();
    }

    public int RemoveFromCart(Pie pie)
    {
        var shoppingCartItem =
            _bethanysPieShopDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

        var localAmount = 0;

        if (shoppingCartItem != null)
        {
            if (shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount--;
                localAmount = shoppingCartItem.Amount;
            }
            else
            {
                _bethanysPieShopDbContext.ShoppingCartItems.Remove(shoppingCartItem);
            }
        }

        _bethanysPieShopDbContext.SaveChanges();

        return localAmount;
    }

    public List<ShoppingCartItems> GetShoppingCardItems()
    {
        return ShoppingCartItems ??=
            _bethanysPieShopDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Pie)
                .ToList();
    }

    public void ClearCart()
    {
        var cartItems = _bethanysPieShopDbContext
            .ShoppingCartItems
            .Where(cart => cart.ShoppingCartId == ShoppingCartId);

        _bethanysPieShopDbContext.ShoppingCartItems.RemoveRange(cartItems);

        _bethanysPieShopDbContext.SaveChanges();
    }

    public decimal GetShoppingCartTotal()
    {
        var total = _bethanysPieShopDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
            .Select(c => c.Pie.Price * c.Amount).Sum();
        return total;
    }
}