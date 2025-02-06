namespace PastryShop.Models;

public class CategoryRepository : ICategoryRepository
{
    private readonly PastryShopDbContext _context;

    public CategoryRepository(PastryShopDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Category> AllCategories
    {
        get
        {
            return _context.Categories.OrderBy(c=>c.CategoryName);
        }
    }
}