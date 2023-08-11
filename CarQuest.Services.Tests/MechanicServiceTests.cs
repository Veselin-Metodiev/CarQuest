namespace CarQuest.Services.Tests;

using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Data;

using Interfaces;

using Mapping;

using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

using Services;

using Web.ViewModels.Home;
using Web.ViewModels.Mechanic;

using static DataSeeder;

public class MechanicServiceTests
{
	private DbContextOptions<CarQuestDbContext> options;
	private CarQuestDbContext context;

	private IMechanicService mechanicService;

	[OneTimeSetUp]
	public void OneTimeSetup()
	{
		options = new DbContextOptionsBuilder<CarQuestDbContext>()
			.UseInMemoryDatabase("CarQuestInMemory" + Guid.NewGuid())
			.Options;
		context = new CarQuestDbContext(options);

		context.Database.EnsureCreated();
		SeedDatabase(context);

		mechanicService = new MechanicService(context);

		AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
	}

	[Test]
	public async Task MechanicExistByUserIdShouldReturnTrueWhenExists()
	{
		bool exists = await mechanicService.MechanicExistsByUserIdAsync(MechanicUser.Id);

		Assert.True(exists);
	}

	[Test]
	public async Task MechanicExistByUserIdShouldReturnFalseWhenNotExists()
	{
		bool exists = await mechanicService.MechanicExistsByUserIdAsync(Guid.NewGuid());

		Assert.False(exists);
	}

	[Test]
	public void CanConstruct()
	{
		// Act
		MechanicService instance = new (context);

		// Assert
		Assert.That(instance, Is.Not.Null);
	}

	[Test]
	public async Task CanCallAddMechanicAsync()
	{
		// Arrange
		var mechanicViewModel = new MechanicBecomeViewModel
		{
			PhoneNumber = "+3598888888",
			ShopAddress = "Durvenica",
		};
		var userId = User.Id;

		// Act
		await mechanicService.AddMechanicAsync(mechanicViewModel, userId);

		// Assert
		Assert.True(context.Mechanics
			.Any(m => m.UserId == User.Id &&
			          m.PhoneNumber == mechanicViewModel.PhoneNumber &&
			          m.ShopAddress == mechanicViewModel.ShopAddress));
	}

	[Test]
	public void CannotCallAddMechanicAsyncWithNullMechanicViewModel()
	{
		Assert.ThrowsAsync<NullReferenceException>(() => mechanicService.AddMechanicAsync(null, new Guid("767092e8-8969-4275-ba2c-2312b5c003c4")));
	}

	[Test]
	public async Task CanCallMechanicExistsByPhoneNumberAsync()
	{
		// Arrange
		string phonenumber = "359888888888";

		// Act
		bool result = await mechanicService.MechanicExistsByPhoneNumberAsync(phonenumber);

		// Assert
		Assert.True(result);
	}

	[TestCase(null)]
	[TestCase("")]
	[TestCase("   ")]
	public async Task CannotCallMechanicExistsByPhoneNumberAsyncWithInvalidPhonenumber(string value)
	{
		Assert.False(await mechanicService.MechanicExistsByPhoneNumberAsync(value));
	}

	[Test]
	public void CanCallMechanicHasTicketsAsyncReturningTrue()
	{
		// Act
		var result = mechanicService.MechanicHasTicketsAsync(User.Id);

		// Assert
		Assert.True(result);
	}

	[Test]
	public void CannotCallMechanicHasTicketsAsyncReturningFalse()
	{
		// Act
		var result = mechanicService.MechanicHasTicketsAsync(Mechanic.UserId);

		// Assert
		Assert.False(result);
	}
}