namespace CarQuest.Data;

using System.Reflection;
using Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Models;

public class CarQuestDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
	private readonly bool seedDb;

    public CarQuestDbContext(DbContextOptions<CarQuestDbContext> options, bool seedDb = true)
        : base(options) 
    {
        this.seedDb = seedDb;
    }

    public DbSet<Mechanic> Mechanics { get; set; } = null!;
    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<Ticket> Tickets { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<CarCategory> CarsCategories { get; set; } = null!;
    public DbSet<Offer> Offers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TicketConfiguration());
        builder.ApplyConfiguration(new CarCategoryConfiguration());
        builder.ApplyConfiguration(new OfferConfiguration());

        if (seedDb)
        {
	        builder.ApplyConfiguration(new SeedAppUsers());
	        builder.ApplyConfiguration(new SeedMechanic());
	        builder.ApplyConfiguration(new SeedCars());
	        builder.ApplyConfiguration(new SeedTickets());
        }

        base.OnModelCreating(builder);
    }
}