namespace CarQuest.Services.Tests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Data;
using Services;
using Web.ViewModels.Car;
using Web.ViewModels.TicketUser;

using Data.Models;
using FluentAssertions;
using Interfaces;

using Mapping;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Web.ViewModels.Home;

using static DataSeeder;


public class TicketUserServiceTests
{
	private DbContextOptions<CarQuestDbContext> options;
	private CarQuestDbContext context;

	private ITicketUserService ticketUserService;

	[SetUp]
	public void Setup()
	{
		options = new DbContextOptionsBuilder<CarQuestDbContext>()
			.UseInMemoryDatabase("CarQuestInMemory" + Guid.NewGuid())
			.Options;
		context = new CarQuestDbContext(options);

		context.Database.EnsureCreated();
		SeedDatabase(context);

		ticketUserService = new TicketUserService(context);

		AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
	}

	[Test]
	public void CanConstruct()
	{
		// Act
		var instance = new TicketUserService(context);

		// Assert
		Assert.That(instance, Is.Not.Null);
	}

	[Test]
	public void CanCallGetAllUserTicketsAsync()
	{
		// Act
		IEnumerable<TicketUserAllViewModel> result = ticketUserService.GetAllUserActiveTickets(User.Id);

		// Assert
		Assert.True(result.Any(t => t.Description == "SomeUserDescription" &&
		                            t.Title == "SomeUserTitle"));
	}

	[Test]
	public async Task CanCallAddUserTicketAsync()
	{
		// Arrange
		var ticketUserModel = new TicketUserAddViewModel
		{
			Title = "TestValue253121033",
			Description = "TestValue787815400",
			CarId = CarToAdd.Id,
			Cars = new[] {
				new CarAllViewModel
				{
					Id = new Guid("bd6b40b9-dd6e-4e95-b92b-58c0ee477e74"),
					Brand = "TestValue1858309315",
					Model = "TestValue1167621456",
					Year = "TestValue675492167",
					Mileage = "TestValue1058728136",
					ImageUrl = "TestValue2133909812"
				},
				new CarAllViewModel
				{
					Id = new Guid("eb62bedc-a6f2-45b4-a596-769496b543c5"),
					Brand = "TestValue1128565362",
					Model = "TestValue38271345",
					Year = "TestValue1346566980",
					Mileage = "TestValue1187837114",
					ImageUrl = "TestValue513902122"
				},
				new CarAllViewModel
				{
					Id = new Guid("fde42416-7978-49ce-b491-df8e9a35e5a6"),
					Brand = "TestValue34701724",
					Model = "TestValue1928346743",
					Year = "TestValue1070120295",
					Mileage = "TestValue1683050848",
					ImageUrl = "TestValue885963160"
				}
			}
		};

		// Act
		await ticketUserService.AddUserTicketAsync(ticketUserModel, User.Id);

		// Assert
		Assert.True(context.Users.First(u => u.Id == User.Id)
			.Tickets
			.Any(t => t.Title == "TestValue253121033" &&
			          t.Description == "TestValue787815400" &&
			          t.Car == CarToAdd));
	}

	[Test]
	public void CannotCallAddUserTicketAsyncWithNullTicketUserModel()
	{
		Assert.ThrowsAsync<NullReferenceException>(() => ticketUserService.AddUserTicketAsync(null, new Guid("5d474234-f0df-4cde-a2d5-3395897d460a")));
	}

	[Test]
	public async Task CanCallRemoveUserTicketAsync()
	{
		// Arrange
		Guid ticketId = UserTicket.Id;

		// Act
		await ticketUserService.RemoveUserTicketAsync(ticketId);

		// Assert
		Assert.False(context.Users.First(u => u.Id == User.Id)
			.Tickets
			.Any(t => t.Id == UserTicket.Id));
	}

	[Test]
	public async Task CanCallGetTicketModelByIdAsync()
	{
		// Arrange
		Guid ticketId = UserTicket.Id;

		TicketUserUpdateViewModel expectedModel = new()
		{
			Id = UserTicket.Id,
			Title = "SomeUserTitle",
			Description = "SomeUserDescription",
			CarId = UserTicket.CarId,
			Cars = new HashSet<CarAllViewModel>()
		};

		// Act
		TicketUserUpdateViewModel result = await ticketUserService.GetTicketModelByIdAsync(ticketId);

		// Assert
		expectedModel.Should().BeEquivalentTo(result);
	}

	[Test]
	public async Task CanCallUpdateTicketAsync()
	{
		// Arrange
		var ticketUserModel = new TicketUserUpdateViewModel
		{
			Id = UserTicket.Id,
			Title = "TestValue1982711223",
			Description = "TestValue2016576863",
			CarId = UserCar.Id,
			Cars = new[] {
				new CarAllViewModel
				{
					Id = new Guid("763968a0-ef48-4a90-aef1-8451f50333ac"),
					Brand = "TestValue1063151211",
					Model = "TestValue904038972",
					Year = "TestValue1964844888",
					Mileage = "TestValue94617618",
					ImageUrl = "TestValue515074453"
				},
				new CarAllViewModel
				{
					Id = new Guid("0e56c67c-2e75-4734-b39b-f8cd3547110b"),
					Brand = "TestValue1516013395",
					Model = "TestValue1509693317",
					Year = "TestValue975614238",
					Mileage = "TestValue1535179406",
					ImageUrl = "TestValue516802843"
				},
				new CarAllViewModel
				{
					Id = new Guid("c281d0cc-2a45-4e92-b438-e0c2e0910add"),
					Brand = "TestValue384939367",
					Model = "TestValue851421482",
					Year = "TestValue1502396087",
					Mileage = "TestValue1815580341",
					ImageUrl = "TestValue628044498"
				}
			}
		};

		// Act
		await ticketUserService.UpdateTicketAsync(ticketUserModel);
		Ticket ticket = context.Tickets.First(t => t.Id == UserTicket.Id);
		// Assert
		Assert.True(ticket.Description == "TestValue2016576863" &&
		            ticket.Title == "TestValue1982711223");
	}

	[Test]
	public void CannotCallUpdateTicketAsyncWithNullTicketUserModel()
	{
		Assert.ThrowsAsync<InvalidOperationException>(() => ticketUserService.UpdateTicketAsync(default(TicketUserUpdateViewModel)));
	}

	[Test]
	public async Task CanCallGetMechanicInfoAsync()
	{
		// Arrange
		Guid mechanicId = DataSeeder.Mechanic.Id;

		MechanicInfoViewModel expectedModel = new()
		{
			ShopAddress = "Mladost",
			PhoneNumber = "359888888888",
			CompletedTickets = 0,
			TakenTickets = 1,
			FirstName = "Gosho",
			LastName = "Goshov",
			UserId = MechanicUser.Id
		};

		// Act
		MechanicInfoViewModel result = await ticketUserService.GetMechanicInfoAsync(mechanicId);

		// Assert
		expectedModel.Should().BeEquivalentTo(result);
	}

	[Test]
	public async Task CanCallIsUserOwner()
	{
		// Arrange
		Guid userId = User.Id;
		Guid ticketId = UserTicket.Id;

		// Act
		bool result = await ticketUserService.IsUserOwner(userId, ticketId);

		// Assert
		Assert.IsTrue(result);
	}

	[Test]
	public async Task CannotCallIsUserOwnerWhenTicketIdDoesNotExist()
	{
		// Arrange
		Guid userId = User.Id;
		Guid ticketId = Guid.NewGuid();

		// Act
		bool result = await ticketUserService.IsUserOwner(userId, ticketId);

		// Assert
		Assert.IsFalse(result);
	}

	[Test]
	public async Task CannotCallIsUserOwnerWhenUserIdDoesNotExist()
	{
		// Arrange
		Guid userId = Guid.NewGuid();
		Guid ticketId = UserTicket.Id;

		// Act
		bool result = await ticketUserService.IsUserOwner(userId, ticketId);

		// Assert
		Assert.IsFalse(result);
	}
}
