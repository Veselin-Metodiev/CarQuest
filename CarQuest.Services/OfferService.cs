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

			//offer.EstimatedDuration =
			//	new TimeSpan(offerModel.EstimatedDurationDays, offerModel.EstimatedDurationHours, 0, 0);

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
			//offer.EstimatedDuration = offerModel.EstimatedDuration;
			offer.Title = offerModel.Title;

			await context.SaveChangesAsync();
		}
	}
}
