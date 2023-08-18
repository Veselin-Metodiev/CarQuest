namespace CarQuest.Data.Configurations;

using Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class SeedAppUsers : IEntityTypeConfiguration<ApplicationUser>
{
	public void Configure(EntityTypeBuilder<ApplicationUser> builder)
	{
		builder.HasData(Users());
	}

	private static ApplicationUser[] Users()
	{
		ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();

		PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

		ApplicationUser admin = new()
		{
			Id = Guid.Parse("19B96A81-B85C-447D-8A5B-F156453C3A4F"),
			UserName = "admin@carquest.com",
			NormalizedUserName = "ADMIN@CARQUEST.COM",
			Email = "admin@carquest.com",
			SecurityStamp = Guid.NewGuid().ToString(),
			NormalizedEmail = "ADMIN@CARQUEST.COM",
			EmailConfirmed = true,
			FirstName = "Admin",
			LastName = "Admin"
		};
		admin.PasswordHash = passwordHasher.HashPassword(admin, "123456");
		users.Add(admin);

		ApplicationUser testUser = new()
		{
			Id = Guid.Parse("CE0B3F5F-5558-43E9-B1B9-07B8F4451DF2"),
			UserName = "testuser@carquest.com",
			NormalizedUserName = "TESTUSER@CARQUEST.COM",
			Email = "testuser@carquest.com",
			NormalizedEmail = "TESTUSER@CARQUEST.COM",
			EmailConfirmed = true,
			SecurityStamp = Guid.NewGuid().ToString(),
			PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
			FirstName = "Test",
			LastName = "User"
		};
		testUser.PasswordHash = passwordHasher.HashPassword(testUser, "123456");
		users.Add(testUser);

		ApplicationUser mechanicUser = new()
		{
			Id = Guid.Parse("347325E5-C944-4229-B29F-9C7D94D81CBD"),
			UserName = "testmechanicuser@carquest.com",
			NormalizedUserName = "TESTMECHANICUSER@CARQUEST.COM",
			Email = "testmechanicuser@carquest.com",
			NormalizedEmail = "TESTMECHANICUSER@CARQUEST.COM",
			SecurityStamp = Guid.NewGuid().ToString(),
			EmailConfirmed = true,
			PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
			FirstName = "Mechanic",
			LastName = "Test"
		};
		mechanicUser.PasswordHash = passwordHasher.HashPassword(mechanicUser, "123456");
		users.Add(mechanicUser);


		return users.ToArray();
	}
}
