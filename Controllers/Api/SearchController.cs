using Microsoft.AspNetCore.Mvc;
using PastryShop.Models;

namespace PastryShop.Controllers.Api;
[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    private readonly IPieRepository _pieRepository;

    public SearchController(IPieRepository pieRepository)
    {
        _pieRepository = pieRepository;
    }
[HttpGet]
    public IActionResult GetAll()
    {
        
    }

    [HttpGet("{id}")]
    public IActionResult GetPiesById(int id)
    {
        
    }
    
}