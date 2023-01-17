using HeroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroApi.Data;

public class HeroApiDbContext : DbContext
{
    public HeroApiDbContext(DbContextOptions<HeroApiDbContext> options) : base(options)
    {
    }

    public DbSet<SuperHero> SuperHeros { set; get; }
}