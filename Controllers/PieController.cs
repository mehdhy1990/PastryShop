using Microsoft.AspNetCore.Mvc;
using PastryShop.Models;
using PastryShop.ViewModel;

namespace PastryShop.Controllers;

public class PieController : Controller
{
    private readonly IPieRepository _pieRepository;
    private readonly ICategoryRepository _categoryRepository;

    public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
    {
        _pieRepository = pieRepository;
        _categoryRepository = categoryRepository;
    }
    // GET
    public IActionResult List()
    {
        // ViewBag.CurrentCategory = "Cheese Cake";
        // return View(_pieRepository.AllPies);
        var pieListViewModel = new PieListViewModel(_pieRepository.AllPies,"Cheese Cakes");
        return View(pieListViewModel);
    }
}