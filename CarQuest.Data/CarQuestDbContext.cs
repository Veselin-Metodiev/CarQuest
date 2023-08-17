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
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<CarCategory> CarsCategories { get; set; } = null!;
    public DbSet<Offer> Offers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TicketConfiguration());
        builder.ApplyConfiguration(new CarCategoryConfiguration());
        builder.ApplyConfiguration(new OfferConfiguration());

    //    builder.Entity<ApplicationUser>().HasData(
	   //     new ApplicationUser
	   //     {
				//Id = Guid.NewGuid(),
		  //      UserName = "Admin",
		  //      NormalizedUserName = "ADMIN",
		  //      Email = "admin@carquest.com",
		  //      NormalizedEmail = "ADMIN@CARQUEST.COM",
		  //      EmailConfirmed = true,
		  //      PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
		  //      ConcurrencyStamp = "8b51706e-f6e8-4dae-b240-54f856fb3004",
		  //      SecurityStamp = "f6af46f5-74ba-43dc-927b-ad83497d0387",
		  //      TwoFactorEnabled = false,
		  //      FirstName = "Admin",
		  //      LastName = "Admin"
	   //     });

        base.OnModelCreating(builder);
    }
}