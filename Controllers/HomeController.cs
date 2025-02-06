using Microsoft.AspNetCore.Mvc;
using PastryShop.Models;
using PastryShop.ViewModel;

namespace PastryShop.Controllers;

public class HomeController : Controller
{
    private readonly  IPieRepository _pieRepository;

    public HomeController(IPieRepository pieRepository)
    {
        _pieRepository = pieRepository;
    }
    // GET
    public IActionResult Index()
    {
        var piesOfTheWeek = _pieRepository.PiesOfTheWeek;
        var homeViewModel = new HomeViewModel(piesOfTheWeek);
        return View(homeViewModel);
    }
}