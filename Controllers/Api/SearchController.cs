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
        return Ok(_pieRepository.AllPies);
    }

    [HttpGet("{id}")]
    public IActionResult GetPiesById(int id)
    {
        if (!_pieRepository.AllPies.Any(c => c.PieId == id))
        {
            return NotFound();
        }
        return Ok(_pieRepository.AllPies.Where(c => c.PieId == id));
    }

   
    
}