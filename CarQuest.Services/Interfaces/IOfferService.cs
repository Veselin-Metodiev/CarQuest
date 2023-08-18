namespace CarQuest.Services.Interfaces;

using Web.ViewModels.Offer;

public interface IOfferService
{
	Task AddOfferToTicketAsync(OfferAddViewModel offerModel);

	Task<OfferDetailsViewModel?> GetOfferDetailsViewModel(Guid offerId);

	Task<OfferEditViewModel?> GetOfferEditViewModel(Guid offerId);

	Task UpdateOfferAsync(OfferEditViewModel offerModel);

	Task DeleteOfferAsync(Guid offerId);

	Task AcceptOfferAsync(Guid offerId);

	Task DeclineOfferAsync(Guid offerId);
}
