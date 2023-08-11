namespace CarQuest.Services.Tests;

using System;
using System.Reflection;
using System.Threading.Tasks;

using CarQuest.Data;
using CarQuest.Services;

using Data;

using FluentAssertions;

using Interfaces;

using Mapping;

using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

using Web.ViewModels.Home;
using Web.ViewModels.User;
using static DataSeeder;

public class UserServiceTests
{
	private DbContextOptions<CarQuestDbContext> options;
	private CarQuestDbContext context;

	private IUserService userService;

	[SetUp]
	public void Setup()
	{
		options = new DbContextOptionsBuilder<CarQuestDbContext>()
			.UseInMemoryDatabase("CarQuestInMemory" + Guid.NewGuid())
			.Options;
		context = new CarQuestDbContext(options);

		context.Database.EnsureCreated();
		SeedDatabase(context);

		userService = new UserService(context);

		AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
	}

	[Test]
	public void CanConstruct()
	{
		// Act
		var instance = new UserService(context);

		// Assert
		instance.Should().NotBeNull();
	}

	[Test]
	public async Task CanCallGetAllApplicationUsersAsync()
	{
		// Arrange
		ApplicationUserAllViewModel expectedModel = new()
		{
			Id = User.Id,
			FirstName = User.FirstName,
			LastName = User.LastName,
			Email = User.Email
		};

		// Act
		ICollection<ApplicationUserAllViewModel> result = await userService.GetAllApplicationUsersAsync();

		// Assert
		result.Should().ContainEquivalentOf(expectedModel);
	}

	[Test]
	public async Task CanCallGetAllMechanicsAsync()
	{
		MechanicAllViewModel expectedModel = new()
		{
			Id = Mechanic.Id,
			FirstName = MechanicUser.FirstName,
			LastName = MechanicUser.LastName,
			Email = MechanicUser.Email,
			PhoneNumber = Mechanic.PhoneNumber,
			ShopAddress = Mechanic.ShopAddress
		};

		// Act
		ICollection<MechanicAllViewModel> result = await userService.GetAllMechanicsAsync();

		// Assert
		result.Should().ContainEquivalentOf(expectedModel);

	}
}
