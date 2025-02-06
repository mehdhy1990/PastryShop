using Microsoft.EntityFrameworkCore;

namespace PastryShop.Models;

public class PieRepository : IPieRepository
{
    private readonly PastryShopDbContext _context;

    public PieRepository(PastryShopDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Pie> AllPies
    {
        get
        {
            return _context.Pies.Include(c=>c.Category);
        }
    }

    public IEnumerable<Pie> PiesOfTheWeek
    {
        get
        {
            return _context.Pies.Include(c=>c.Category).Where(p=>p.IsPieOfTheWeek);
        }
    }

    public Pie? GetPieById(int pieId)
    {
        return _context.Pies.Include(c=>c.Category).FirstOrDefault(p=>p.PieId == pieId);
    }

    public IEnumerable<Pie> SearchPies(string searchQuery)
    {
        throw new NotImplementedException();
    }
}