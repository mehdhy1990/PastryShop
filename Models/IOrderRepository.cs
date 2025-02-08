namespace PastryShop.Models;

public interface IOrderRepository
{
    void CreateOrder(Order order);
}