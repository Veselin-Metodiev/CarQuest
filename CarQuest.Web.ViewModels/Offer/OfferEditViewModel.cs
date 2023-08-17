namespace CarQuest.Web.ViewModels.Offer;

using System.ComponentModel.DataAnnotations;

using Data.Models;
using Services.Mapping;

using static Common.EntityValidationConstants.OfferAddViewModel;

public class OfferEditViewModel : IMapTo<Offer>
{
	public Guid Id { get; set; }

	[Required]
	[StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
	public string Title { get; set; } = null!;

	[Required]
	[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
	public string Description { get; set; } = null!;

	public TimeSpan EstimatedDuration { get; set; }

	public decimal Cost { get; set; }
}
