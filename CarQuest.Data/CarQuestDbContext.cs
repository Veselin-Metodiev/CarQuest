namespace CarQuest.Data;

using System.Reflection;
using Configurations;
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
    public DbSet<Ticket> Tickets { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TicketConfiguration());

        base.OnModelCreating(builder);
    }
}