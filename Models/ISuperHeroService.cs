using Microsoft.AspNetCore.Mvc;

namespace HeroApi.Models;

public interface ISuperHeroService
{
    public Task<List<SuperHero?>> GetAllHeros();
    public Task<SuperHero> GetHero(int id);
    public Task<List<SuperHero>> AddHero(SuperHero? superHero);
    public Task<SuperHero?> UpdateHero(SuperHero superHero);
    public Task<List<SuperHero>> DeleteHero(int id);
}