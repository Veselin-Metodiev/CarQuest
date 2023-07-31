namespace CarQuest.Data;

using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Models;

public class CarQuestDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public CarQuestDbContext(DbContextOptions<CarQuestDbContext> options)
        : base(options)
    {
    }

    public DbSet<Mechanic> Mechanics { get; set; } = null!;
    public DbSet<Car> Cars { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        Assembly configAssembly = Assembly.GetAssembly(typeof(CarQuestDbContext)) ??
                                  Assembly.GetExecutingAssembly();
        builder.ApplyConfigurationsFromAssembly(configAssembly);

        base.OnModelCreating(builder);
    }
}