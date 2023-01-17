using HeroApi.Data;
using Microsoft.EntityFrameworkCore;

namespace HeroApi.Models;

public class SuperHeroService : ISuperHeroService
{
    public readonly HeroApiDbContext _context;

    public SuperHeroService(HeroApiDbContext context)
    {
        _context = context;
    }

    public async Task<List<SuperHero?>> GetAllHeros()
    {
        var _superHeroes = await _context.SuperHeros.ToListAsync();
        return _superHeroes;
    }

    public async Task<SuperHero> GetHero(int id)
    {
        var _superHeroes = await _context.SuperHeros.FindAsync(id);
        return _superHeroes;
    }

    public async Task<List<SuperHero>> AddHero(SuperHero? superHero)
    {
        if (superHero != null)
        {
            await _context.SuperHeros.AddAsync(superHero);
        }

        await _context.SaveChangesAsync();
        return await _context.SuperHeros.ToListAsync();
    }

    public async Task<SuperHero?> UpdateHero(SuperHero superHero)
    {
        var hero = await _context.SuperHeros.FindAsync(superHero.Id);
                if (hero == null) return null;
                hero.FirstName = superHero.FirstName;
                hero.LastName = superHero.LastName;
                hero.Place = superHero.Place;
                await _context.SaveChangesAsync();
                return hero;
    }

    public async Task<List<SuperHero>> DeleteHero(int id)
    {
        var hero = await _context.SuperHeros.FindAsync(id);
        if (hero != null) _context.SuperHeros.Remove(hero);
        return await _context.SuperHeros.ToListAsync() ;
    }
}