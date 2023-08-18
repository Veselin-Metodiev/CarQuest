namespace CarQuest.Services;

using Data;
using Data.Models;

using Interfaces;

using Mapping;

using Microsoft.EntityFrameworkCore;

using Web.ViewModels.Offer;

public class OfferService : IOfferService
{
	private readonly CarQuestDbContext context;

	public OfferService(CarQuestDbContext context)
	{
		this.context = context;
	}

	public async Task AddOfferToTicketAsync(OfferAddViewModel offerModel)
	{
		Ticket? ticket = await context.Tickets
			.FirstOrDefaultAsync(t => t.Id == offerModel.TicketId);

		if (ticket != null)
		{
			Offer offer = AutoMapperConfig.MapperInstance.Map<Offer>(offerModel);
			await context.Offers.AddAsync(offer);

			ticket.Offer = offer;

			await context.SaveChangesAsync();
		}
	}

	public async Task<OfferDetailsViewModel?> GetOfferDetailsViewModel(Guid offerId)
	{
		Offer? offer = await context.Offers
			.FirstOrDefaultAsync(o => o.Id == offerId);

		if (offer != null)
		{
			OfferDetailsViewModel offerModel =
				AutoMapperConfig.MapperInstance.Map<OfferDetailsViewModel>(offer);

			return offerModel;
		}

		return null;
	}

	public async Task<OfferEditViewModel?> GetOfferEditViewModel(Guid offerId)
	{
		Offer? offer = await context.Offers
			.FirstOrDefaultAsync(o => o.Id == offerId);

		if (offer != null)
		{
			OfferEditViewModel offerModel =
				AutoMapperConfig.MapperInstance.Map<OfferEditViewModel>(offer);

			return offerModel;
		}

		return null;
	}

	public async Task UpdateOfferAsync(OfferEditViewModel offerModel)
	{
		Offer? offer = await context.Offers
			.FirstOrDefaultAsync(o => o.Id == offerModel.Id);

		if (offer != null)
		{
			offer.Cost = offerModel.Cost;
			offer.Description = offerModel.Description;
			offer.EstimatedDurationHours = offerModel.EstimatedDurationHours;
			offer.EstimatedDurationDays = offerModel.EstimatedDurationDays ?? 0;
			offer.Title = offerModel.Title;

			await context.SaveChangesAsync();
		}
	}

	public async Task DeleteOfferAsync(Guid offerId)
	{
		Offer? offer = await context.Offers
			.FirstOrDefaultAsync(o => o.Id == offerId);


		if (offer != null)
		{
			Ticket ticket = await context.Tickets
				.FirstAsync(t => t.OfferId == offerId);

			ticket.OfferId = null;

			context.Offers.Remove(offer);
			await context.SaveChangesAsync();
		}
	}

	public async Task AcceptOfferAsync(Guid offerId)
	{
		Offer? offer = await context.Offers
			.FirstOrDefaultAsync(o => o.Id == offerId);

		if (offer != null)
		{
			offer.HasUserAccepted = true;
			await context.SaveChangesAsync();
		}
	}

	public async Task DeclineOfferAsync(Guid offerId)
	{
		Offer? offer = await context.Offers
			.Include(o => o.Ticket)
			.FirstOrDefaultAsync(o => o.Id == offerId);

		if (offer != null)
		{
			offer.Ticket.OfferId = null;

			context.Offers.Remove(offer);
			await context.SaveChangesAsync();
		}
	}
}
