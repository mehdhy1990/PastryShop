using Microsoft.AspNetCore.Mvc;
using PastryShop.Models;

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
        return View(_pieRepository.AllPies);
    }
}