using Microsoft.EntityFrameworkCore;

namespace PastryShop.Models;

public class PieRepository : IPieRepository
{
    private readonly PastryShopDbContext _pastryShopDbContext;

    public PieRepository(PastryShopDbContext pastryShopDbContext)
    {
        _pastryShopDbContext = pastryShopDbContext;
    }

    public IEnumerable<Pie> AllPies
    {
        get
        {
            return _pastryShopDbContext.Pies.Include(c=>c.Category);
        }
    }

    public IEnumerable<Pie> PiesOfTheWeek
    {
        get
        {
            return _pastryShopDbContext.Pies.Include(c=>c.Category).Where(p=>p.IsPieOfTheWeek);
        }
    }

    public Pie? GetPieById(int pieId)
    {
        return _pastryShopDbContext.Pies.Include(c=>c.Category).FirstOrDefault(p=>p.PieId == pieId);
    }

    public IEnumerable<Pie> SearchPies(string searchQuery)
    {
       return _pastryShopDbContext.Pies.Where(p=>p.Name.Contains(searchQuery));
    }
}