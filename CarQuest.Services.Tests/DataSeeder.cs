namespace CarQuest.Services.Tests;

using Data;
using Data.Models;

public static class DataSeeder
{
	public static ApplicationUser User;
	public static ApplicationUser MechanicUser;
	public static Mechanic Mechanic;

	public static void SeedDatabase(CarQuestDbContext context)
	{
		User = new ApplicationUser
		{
			UserName = "Pesho",
			NormalizedUserName = "PESHO",
			Email = "pesho@gmail.com",
			NormalizedEmail = "PESHO@GMAIL.COM",
			EmailConfirmed = true,
			PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
			ConcurrencyStamp = "caf271d7-0ba7-4ab1-8d8d-6d0e3711c27d",
			SecurityStamp = "ca32c787-626e-4234-a4e4-8c94d85a2b1c",
			TwoFactorEnabled = false,
			FirstName = "Pesho",
			LastName = "Petrov"
		};
		MechanicUser = new ApplicationUser()
		{
			UserName = "Gosho",
			NormalizedUserName = "GOSHO",
			Email = "gosho@gmail.com",
			NormalizedEmail = "GOSHO@GMAIL.COM",
			EmailConfirmed = true,
			PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
			ConcurrencyStamp = "8b51706e-f6e8-4dae-b240-54f856fb3004",
			SecurityStamp = "f6af46f5-74ba-43dc-927b-ad83497d0387",
			TwoFactorEnabled = false,
			FirstName = "Gosho",
			LastName = "Goshov"
		};

		Mechanic = new Mechanic
		{
			ShopAddress = "Mladost",
			PhoneNumber = "359888888888",
			User = MechanicUser
		};

		context.Users.Add(User);
		context.Users.Add(MechanicUser);
		context.Mechanics.Add(Mechanic);

		context.SaveChanges();
	}
}
