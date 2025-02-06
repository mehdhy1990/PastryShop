using PastryShop.Models;

namespace PastryShop.ViewModel;

public class HomeViewModel
{
    public IEnumerable<Pie> PiesOfTheWeek { get;  }

    public HomeViewModel(IEnumerable<Pie> piesOfTheWeek)
    {
        PiesOfTheWeek = piesOfTheWeek;
    }
}