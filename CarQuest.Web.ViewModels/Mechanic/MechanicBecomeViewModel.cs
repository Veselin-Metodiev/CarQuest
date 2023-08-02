namespace CarQuest.Web.ViewModels.Mechanic;

using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Data.Models;
using Services.Mapping;

public class MechanicBecomeViewModel : IMapTo<Mechanic>
{
	[Required]
	[StringLength(20, MinimumLength = 5)]
	public string PhoneNumber { get; set; } = null!;

	[Required]
	[StringLength(100, MinimumLength = 10)]
	public string ShopAddress { get; set; } = null!;
    
	public Guid UserId { get; set; }
}
