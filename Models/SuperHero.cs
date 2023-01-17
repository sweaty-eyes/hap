using System.ComponentModel.DataAnnotations;

namespace HeroApi.Models;

public class SuperHero
{
    public int Id { get; set; }
    [Required]
    public string? FirstName { set; get; }

    public string? LastName { get; set; }

    public string Name => $"{FirstName} {LastName}";
    public string? Place { get; set; }
}