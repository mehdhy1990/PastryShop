using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PastryShop.Models;

public class ShoppingCartItems
{
    [Key]
    public int ShoppingCartItemId { get; set; }
    public Pie Pie { get; set; } = default!;
    public int Amount { get; set; }
    public string? ShoppingCartId { get; set; }
}