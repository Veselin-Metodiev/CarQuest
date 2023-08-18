namespace CarQuest.Services.Tests;

using System;
using System.Reflection;
using System.Threading.Tasks;

using Data;
using Data.Models;
using Services;
using Web.ViewModels.Offer;

using FluentAssertions;

using Interfaces;

using Mapping;

using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

using Web.ViewModels.Home;

using static DataSeeder;

public class OfferServiceTests
{
	private DbContextOptions<CarQuestDbContext> options;
	private CarQuestDbContext context;

	private IOfferService offerService;

	[SetUp]
	public void Setup()
	{
		options = new DbContextOptionsBuilder<CarQuestDbContext>()
			.UseInMemoryDatabase("CarQuestInMemory" + Guid.NewGuid())
			.Options;
		context = new CarQuestDbContext(options, false);

		context.Database.EnsureCreated();
		SeedDatabase(context);

		offerService = new OfferService(context);

		AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
	}

	[Test]
	public void CanConstruct()
	{
		// Act
		OfferService instance = new OfferService(context);

		// Assert
		instance.Should().NotBeNull();
	}

	[Test]
	public async Task CanCallAddOfferToTicketAsync()
	{
		// Arrange
		OfferAddViewModel offerModel = new OfferAddViewModel
		{
			TicketId = UserTicket.Id,
			Title = "TestValue1767134168",
			Description = "TestValue1752561004",
			EstimatedDurationDays = 746344063,
			EstimatedDurationHours = 644764146,
			Cost = 464039928.99M
		};

		// Act
		await offerService.AddOfferToTicketAsync(offerModel);

		Assert.True(context.Offers
			            .Any(o => o.Title == offerModel.Title &&
		                                    o.Description == offerModel.Description) &&
		            context.Tickets
			            .Include(t => t.Offer)
			            .First(t => t.Id == offerModel.TicketId)
			            .Offer!.Title == offerModel.Title);
	}

	[Test]
	public async Task CannotCallAddOfferToTicketAsyncWithNullOfferModel()
	{
		await FluentActions.Invoking(() => offerService.AddOfferToTicketAsync(default(OfferAddViewModel))).Should()
			.ThrowAsync<InvalidOperationException>();
	}

	[Test]
	public async Task CanCallGetOfferDetailsViewModel()
	{
		// Arrange
		Guid offerId = UserTicketOffer.Id;
		OfferDetailsViewModel expected = new()
		{
			Id = offerId,
			Title = "SomeOfferTitle",
			Description = "SomeOfferDescription",
			Cost = 10,
			EstimatedDurationDays = 1,
			EstimatedDurationHours = 1,
		};

		// Act
		OfferDetailsViewModel? result = await offerService.GetOfferDetailsViewModel(offerId);


		// Assert
		result.Should().BeEquivalentTo(expected);
	}

	[Test]
	public async Task CanCallGetOfferEditViewModel()
	{
		// Arrange
		Guid offerId = UserTicketOffer.Id;
		OfferEditViewModel expected = new()
		{
			Id = offerId,
			Title = "SomeOfferTitle",
			Description = "SomeOfferDescription",
			Cost = 10,
			EstimatedDurationDays = 1,
			EstimatedDurationHours = 1,
		};

		// Act
		OfferEditViewModel? result = await offerService.GetOfferEditViewModel(offerId);

		// Assert
		result.Should().BeEquivalentTo(expected);
	}

	[Test]
	public async Task CanCallUpdateOfferAsync()
	{
		// Arrange
		OfferEditViewModel offerModel = new OfferEditViewModel
		{
			Id = UserTicketOffer.Id,
			Title = "TestValue1167384446",
			Description = "TestValue1976033379",
			EstimatedDurationDays = 1443759944,
			EstimatedDurationHours = 1329661142,
			Cost = 164041542.72M
		};

		// Act
		await offerService.UpdateOfferAsync(offerModel);

		Offer offer = context.Offers
			.First(o => o.Id == offerModel.Id);

		// Assert
		Assert.True(offer.Title == offerModel.Title &&
		            offer.Description == offerModel.Description);
	}

	[Test]
	public async Task CannotCallUpdateOfferAsyncWithNullOfferModel()
	{
		await FluentActions.Invoking(() => offerService.UpdateOfferAsync(default(OfferEditViewModel))).Should()
			.ThrowAsync<InvalidOperationException>();
	}

	[Test]
	public async Task CanCallDeleteOfferAsync()
	{
		// Arrange
		Guid offerId = UserTicketOffer.Id;

		// Act
		await offerService.DeleteOfferAsync(offerId);

		// Assert
		Assert.False(context.Offers
			.Any(o => o.Id == offerId));
	}

	[Test]
	public async Task CanCallAcceptOfferAsync()
	{
		// Arrange
		Guid offerId = UserTicketOffer.Id;

		// Act
		await offerService.AcceptOfferAsync(offerId);

		// Assert
		Assert.True(context.Offers
			.First(o => o.Id == offerId)
			.HasUserAccepted == true);
	}

	[Test]
	public async Task CanCallDeclineOfferAsync()
	{
		// Arrange
		Guid offerId = UserTicketOffer.Id;

		// Act
		await offerService.DeclineOfferAsync(offerId);

		// Assert
		Assert.False(context.Offers
			.Any(o => o.Id == offerId));
	}
}
