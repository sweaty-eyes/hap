using System.ComponentModel.DataAnnotations;
using HeroApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeroApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private readonly ISuperHeroService _superHeroService;

    public SuperHeroController(ISuperHeroService superHeroService)
    {
        _superHeroService = superHeroService;
    }

    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
    {
        return Ok(_superHeroService.GetAllHeros());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHero>> GetHero(int id)
    {
        var superHero = _superHeroService.GetHero(id);
        if (superHero is null)
            return NotFound("Hero Not Found");
        return Ok(superHero);
    }

    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero superHero)
    {
        var superHeros = _superHeroService.AddHero(superHero);
        return Ok(superHeros);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request, int id)
    {
        var superHero = _superHeroService.UpdateHero(request);
        if (superHero is null)
            return NotFound("Hero Id is Wrong");
        return Ok(request);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
    {
        var superHeros = _superHeroService.DeleteHero(id);
        return Ok(superHeros);
    }
}