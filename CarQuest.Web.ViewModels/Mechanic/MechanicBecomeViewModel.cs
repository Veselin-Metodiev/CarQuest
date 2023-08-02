namespace CarQuest.Web.ViewModels.Mechanic;

using System.ComponentModel.DataAnnotations;

using Data.Models;

using Services.Mapping;

using static Common.EntityValidationConstants.MechanicBecomeViewModel;

public class MechanicBecomeViewModel : IMapTo<Mechanic>
{
	[Required]
	[StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
	public string PhoneNumber { get; set; } = null!;

	[Required]
	[StringLength(ShopAddressMaxLength, MinimumLength = ShopAddressMinLength)]
	public string ShopAddress { get; set; } = null!;
    
	public Guid UserId { get; set; }
}
