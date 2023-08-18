namespace CarQuest.Services.Tests;

using System;
using System.Reflection;
using System.Threading.Tasks;

using CarQuest.Data;
using CarQuest.Services;
using CarQuest.Web.ViewModels.Car;

using Data;
using Data.Models;
using FluentAssertions;

using Interfaces;

using Mapping;

using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

using Web.ViewModels.Home;

using static DataSeeder;

public class CarServiceTests
{
	private DbContextOptions<CarQuestDbContext> options;
	private CarQuestDbContext context;

	private ICarService carService;

	[SetUp]
	public void OneTimeSetup()
	{
		options = new DbContextOptionsBuilder<CarQuestDbContext>()
			.UseInMemoryDatabase("CarQuestInMemory" + Guid.NewGuid())
			.Options;
		context = new CarQuestDbContext(options, false);

		context.Database.EnsureCreated();
		SeedDatabase(context);

		carService = new CarService(context);

		AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
	}

	[Test]
	public void CanConstruct()
	{
		// Act
		var instance = new CarService(context);

		// Assert
		instance.Should().NotBeNull();
	}

	[Test]
	public async Task CanCallMineCarsAsync()
	{
		// Arrange
		Guid userId = User.Id;
		CarAllViewModel model = new()
		{
			Id = UserCar.Id,
			Year = "2019",
			Model = "Burzo",
			Brand = "Lambo",
			Mileage = "10000",
			Categories = "sport",
			ImageUrl =
				"https://www.google.com/url?sa=i&url=https%3A%2F%2Fgreenrentacar.bg%2Fen%2Feconomy%2F63-yaris-cross-at&psig=AOvVaw2smYuUgRrL1SgtVHRz5OcN&ust=1691856354351000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCMi8ipv-1IADFQAAAAAdAAAAABAE"
		};

		// Act
		IEnumerable<CarAllViewModel> result = await carService.MineCarsAsync(userId);

		// Assert
		result.Should().ContainEquivalentOf(model);
	}

	[Test]
	public async Task CanCallAddUserCarAsync()
	{
		// Arrange
		Guid userId = User.Id;
		CarAddViewModel car = new()
		{
			Year = 2016,
			Model = "Bavno",
			Brand = "Lambo",
			Mileage = 100000,
			Categories = "sport",
			ImageUrl =
				"https://www.google.com/url?sa=i&url=https%3A%2F%2Fgreenrentacar.bg%2Fen%2Feconomy%2F63-yaris-cross-at&psig=AOvVaw2smYuUgRrL1SgtVHRz5OcN&ust=1691856354351000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCMi8ipv-1IADFQAAAAAdAAAAABAE",
		};

		// Act
		await carService.AddUserCarAsync(userId, car);

		// Assert
		context.Cars.Should().ContainEquivalentOf(CarToAdd);
	}

	[Test]
	public async Task CannotCallAddUserCarAsyncWithNullCar()
	{
		await FluentActions
			.Invoking(() => carService
				.AddUserCarAsync(new Guid("91ec0cd4-6065-49c0-b9bd-afe89bda3629"), null))
			.Should()
			.ThrowAsync<NullReferenceException>();
	}

	[Test]
	public async Task CanCallDeleteUserCarAsync()
	{
		// Arrange
		Guid carId = UserCar.Id;

		// Act
		await carService.DeleteUserCarAsync(carId);

		// Assert
		context.Cars.Should().NotContain(c => c.Id == carId);
	}

	[Test]
	public async Task CanCallUpdateUserCarAsync()
	{
		// Arrange
		Guid carId = UserCar.Id;
		CarUpdateViewModel carModel = new()
		{
			Year = 2016,
			Model = "Bavno",
			Brand = "Lambo",
			Mileage = 100000,
			Categories = "sport",
			ImageUrl =
				"https://www.google.com/url?sa=i&url=https%3A%2F%2Fgreenrentacar.bg%2Fen%2Feconomy%2F63-yaris-cross-at&psig=AOvVaw2smYuUgRrL1SgtVHRz5OcN&ust=1691856354351000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCMi8ipv-1IADFQAAAAAdAAAAABAE",
		};

		// Act
		await carService.UpdateUserCarAsync(carId, carModel);

		// Assert
		Car car = context.Cars.First(c => c.Id == carId);
		Assert.True(car.Model == "Bavno" &&
		            car.Year == "2016");
	}

	[Test]
	public async Task CannotCallUpdateUserCarAsyncWithNullCar()
	{
		await FluentActions.Invoking(() => carService
				.UpdateUserCarAsync(new Guid("6272c2c0-0619-41cb-9894-9750e5f14a64"), null))
			.Should()
			.ThrowAsync<InvalidOperationException>();
	}

	[Test]
	public async Task CanCallGetCarUpdateViewModelAsync()
	{
		// Arrange
		Guid carId = UserCar.Id;
		CarUpdateViewModel expectedModel = new()
		{
			Id = UserCar.Id,
			Year = 2019,
			Model = "Burzo",
			Brand = "Lambo",
			Mileage = 10000,
			Categories = "sport",
			ImageUrl =
				"https://www.google.com/url?sa=i&url=https%3A%2F%2Fgreenrentacar.bg%2Fen%2Feconomy%2F63-yaris-cross-at&psig=AOvVaw2smYuUgRrL1SgtVHRz5OcN&ust=1691856354351000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCMi8ipv-1IADFQAAAAAdAAAAABAE",
		};

		// Act
		CarUpdateViewModel result = await carService.GetCarUpdateViewModelAsync(carId);

		// Assert
		result.Should().BeEquivalentTo(expectedModel);
	}

	[Test]
	public async Task CanCallisCarOwner()
	{
		// Arrange
		Guid userId = User.Id;
		Guid carId = UserCar.Id;

		// Act
		bool result = await carService.isCarOwner(userId, carId);

		// Assert
		Assert.True(result);
	}

	[Test]
	public async Task CanCallAllCarsAsync()
	{
		// Arrange
		CarAllViewModel expectedModel = new()
		{
			Id = UserCar.Id,
			Year = "2019",
			Model = "Burzo",
			Brand = "Lambo",
			Mileage = "10000",
			Categories = "sport",
			ImageUrl =
				"https://www.google.com/url?sa=i&url=https%3A%2F%2Fgreenrentacar.bg%2Fen%2Feconomy%2F63-yaris-cross-at&psig=AOvVaw2smYuUgRrL1SgtVHRz5OcN&ust=1691856354351000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCMi8ipv-1IADFQAAAAAdAAAAABAE"
		};

		// Act
		IEnumerable<CarAllViewModel> result = await carService.AllCarsAsync();

		// Assert
		result.Should().ContainEquivalentOf(expectedModel);
	}
}
