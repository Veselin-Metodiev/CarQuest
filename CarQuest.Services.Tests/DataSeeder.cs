namespace CarQuest.Services.Tests;

using Data;
using Data.Models;
using Data.Models.Enums;

public static class DataSeeder
{
	public static ApplicationUser User;
	public static ApplicationUser MechanicUser;
	public static Mechanic Mechanic;
	public static Car UserCar;
	public static Ticket UserTicket;
	public static Ticket MechanicTicket;
	public static Car CarToAdd;

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
			LastName = "Petrov",
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

		UserCar = new Car
		{
			Year = "2019",
			Model = "Burzo",
			Brand = "Lambo",
			Mileage = "10000",
			ImageUrl =
				"https://www.google.com/url?sa=i&url=https%3A%2F%2Fgreenrentacar.bg%2Fen%2Feconomy%2F63-yaris-cross-at&psig=AOvVaw2smYuUgRrL1SgtVHRz5OcN&ust=1691856354351000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCMi8ipv-1IADFQAAAAAdAAAAABAE",
			Owner = User
		};

		CarToAdd = new Car
		{
			Year = "2016",
			Model = "Bavno",
			Brand = "Lambo",
			Mileage = "100000",
			ImageUrl =
				"https://www.google.com/url?sa=i&url=https%3A%2F%2Fgreenrentacar.bg%2Fen%2Feconomy%2F63-yaris-cross-at&psig=AOvVaw2smYuUgRrL1SgtVHRz5OcN&ust=1691856354351000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCMi8ipv-1IADFQAAAAAdAAAAABAE",
			Owner = User
		};

		UserTicket = new Ticket
		{
			Title = "SomeUserTitle",
			Description = "SomeUserDescription",
			Car = UserCar
		};

		MechanicTicket = new Ticket
		{
			Title = "SomeMechanicTitle",
			Description = "SomeMechanicDescription",
			Car = UserCar,
			Status = Status.Taken
		};

		context.Users.Add(User);
		context.Users.Add(MechanicUser);
		context.Mechanics.Add(Mechanic);
		context.Cars.Add(UserCar);
		context.Cars.Add(CarToAdd);
		context.Tickets.Add(UserTicket);
		context.Tickets.Add(MechanicTicket);

		User.Tickets.Add(UserTicket);
		User.Tickets.Add(MechanicTicket);
		Mechanic.Tickets.Add(MechanicTicket);

		context.SaveChanges();
	}
}
