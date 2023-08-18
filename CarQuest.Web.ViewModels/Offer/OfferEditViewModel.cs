namespace CarQuest.Web.ViewModels.Offer;

using System.ComponentModel.DataAnnotations;

using Data.Models;
using Services.Mapping;

using static Common.EntityValidationConstants.OfferAddViewModel;

public class OfferEditViewModel : IMapTo<Offer>, IMapFrom<Offer>
{
	public Guid Id { get; set; }

	[Required]
	[StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
	public string Title { get; set; } = null!;

	[Required]
	[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
	public string Description { get; set; } = null!;

	[Range(DaysMinLength, DaysMaxLength)]
	public int? EstimatedDurationDays { get; set; }

	[Required]
	[Range(HoursMinLength, HoursMaxLength)]
	public int EstimatedDurationHours { get; set; }

	[Required]
	[Range(CostMinLength, CostMaxLength)]
	public decimal Cost { get; set; }
}
