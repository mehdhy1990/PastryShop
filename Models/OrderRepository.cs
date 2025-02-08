namespace PastryShop.Models;

public class OrderRepository : IOrderRepository
{
    private readonly PastryShopDbContext  _bethanysPieShopDbContext;
    private readonly IShoppingCart _shoppingCart;

    public OrderRepository(PastryShopDbContext bethanysPieShopDbContext, IShoppingCart shoppingCart)
    {
        _bethanysPieShopDbContext = bethanysPieShopDbContext;
        _shoppingCart = shoppingCart;
    }

    public void CreateOrder(Order order)
    {
        order.OrderPlaced = DateTime.Now;

        List<ShoppingCartItems>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
        order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

        order.OrderDetails = new List<OrderDetail>();

        foreach (ShoppingCartItems? shoppingCartItem in shoppingCartItems)
        {
            var orderDetail = new OrderDetail
            {
                Amount = shoppingCartItem.Amount,
                PieId = shoppingCartItem.Pie.PieId,
                Price = shoppingCartItem.Pie.Price
            };

            order.OrderDetails.Add(orderDetail);
        }

        _bethanysPieShopDbContext.Orders.Add(order);

        _bethanysPieShopDbContext.SaveChanges();
}