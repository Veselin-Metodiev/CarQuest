namespace CarQuest.Services.Tests;

using System;
using System.Reflection;
using System.Threading.Tasks;

using Data;
using Data.Models.Enums;
using Services;

using FluentAssertions;

using Interfaces;

using Mapping;

using Microsoft.EntityFrameworkCore;

using NUnit.Framework;
using Web.ViewModels.Car;
using Web.ViewModels.Home;
using Web.ViewModels.TicketMechanic;
using static DataSeeder;


public class TicketMechanicServiceTests
{
	private DbContextOptions<CarQuestDbContext> options;
	private CarQuestDbContext context;

	private ITicketMechanicService ticketMechanicService;

	[SetUp]
	public void Setup()
	{
		options = new DbContextOptionsBuilder<CarQuestDbContext>()
			.UseInMemoryDatabase("CarQuestInMemory" + Guid.NewGuid())
			.Options;
		context = new CarQuestDbContext(options, false);

		context.Database.EnsureCreated();
		SeedDatabase(context);

		ticketMechanicService = new TicketMechanicService(context);

		AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
	}

	[Test]
	public void CanConstruct()
	{
		// Act
		var instance = new TicketMechanicService(context);

		// Assert
		instance.Should().NotBeNull();
	}

	[Test]
	public void CanCallGetAllTicketsAsync()
	{
		// Act
		IEnumerable<TicketMechanicAllViewModel> result = ticketMechanicService.GetAllTicketsAsync();

		// Assert
		Assert.True(result.Any(t => t.Id == UserTicket.Id &&
									t.Title == "SomeUserTitle" &&
									t.Description == "SomeUserDescription"));
	}

	[Test]
	public async Task CanCallTakeTicketAsync()
	{
		// Arrange
		Guid ticketId = UserTicket.Id;
		Guid userId = MechanicUser.Id;

		// Act
		await ticketMechanicService.TakeTicketAsync(ticketId, userId);

		// Assert
		Assert.True(context.Tickets.First(t => t.Id == ticketId).Status == Status.Taken);
	}

	[Test]
	public async Task CanCallGetAllTicketsByStatusAsync()
	{
		// Arrange
		Guid userId = MechanicUser.Id;
		Status status = Status.Taken;

		// Act
		IEnumerable<TicketMechanicAllViewModel> result = await ticketMechanicService.GetAllTicketsByStatusAsync(userId, status);

		// Assert
		Assert.True(result.Any(t => t.Title == "SomeMechanicTitle" &&
		                            t.Description == "SomeMechanicDescription"));
	}

	[Test]
	public async Task CanCallResignTicketAsync()
	{
		// Arrange
		var ticketId = MechanicTicket.Id;

		// Act
		await ticketMechanicService.ResignTicketAsync(ticketId);

		// Assert
		Assert.True(context.Tickets.First(t => t.Id == ticketId).Status == Status.NotTaken);
	}

	[Test]
	public async Task CanCallCompleteTicketAsync()
	{
		// Arrange
		Guid ticketId = MechanicTicket.Id;

		// Act
		await ticketMechanicService.CompleteTicketAsync(ticketId);

		// Assert
		Assert.True(context.Tickets.First(t => t.Id == ticketId).Status == Status.Completed);
	}

	[Test]
	public async Task CanCallTicketIsAlreadyTaken()
	{
		// Arrange
		Guid ticketId = MechanicTicket.Id;
		Guid userId = MechanicUser.Id;

		// Act
		bool result = await ticketMechanicService.TicketIsAlreadyTaken(ticketId, userId);

		// Assert
		Assert.True(result);
	}

	[Test]
	public async Task CanCallGetCarDetailsAsync()
	{
		// Arrange
		Guid carId = UserCar.Id;

		CarDetailsViewModel expectedModel = new()
		{
			Year = "2019",
			Model = "Burzo",
			Brand = "Lambo",
			Mileage = "10000",
			ImageUrl =
				"https://www.google.com/url?sa=i&url=https%3A%2F%2Fgreenrentacar.bg%2Fen%2Feconomy%2F63-yaris-cross-at&psig=AOvVaw2smYuUgRrL1SgtVHRz5OcN&ust=1691856354351000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCMi8ipv-1IADFQAAAAAdAAAAABAE",
			Categories = "sport"
		};

		// Act
		CarDetailsViewModel result = await ticketMechanicService.GetCarDetailsAsync(carId);

		// Assert
		expectedModel.Should().BeEquivalentTo(result);
	}

	[Test]
	public void CanCallIsMechanicAssigned()
	{
		// Arrange
		Guid userId = MechanicUser.Id;
		Guid ticketId = MechanicTicket.Id;

		// Act
		bool result = ticketMechanicService.IsMechanicAssigned(userId, ticketId);

		// Assert
		Assert.True(result);
	}
}
