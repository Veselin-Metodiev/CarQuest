namespace CarQuest.Web.ViewModels.Offer;

using System.ComponentModel.DataAnnotations;
using Data.Models;
using Services.Mapping;

using static Common.EntityValidationConstants.OfferAddViewModel;

public class OfferAddViewModel : IMapTo<Offer>
{
	public Guid TicketId { get; set; }

	[Required]
	[StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
	public string Title { get; set; } = null!;

	[Required]
	[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
	public string Description { get; set; } = null!;

	public int EstimatedDurationDays { get; set; }

	[Required]
	[Range(1, HoursMaxLength)]
	public int EstimatedDurationHours { get; set; }

	public decimal Cost { get; set; }
}
