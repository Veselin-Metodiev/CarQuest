namespace CarQuest.Web.ViewModels.User;

using AutoMapper;

using Data.Models;

using Services.Mapping;

public class MechanicAllViewModel : IMapFrom<Mechanic>, IHaveCustomMappings
{
	public Guid Id { get; set; }

	public string FirstName { get; set; } = null!;

	public string LastName { get; set; } = null!;

	public string Email { get; set; } = null!;

	public string PhoneNumber { get; set; } = null!;

	public string ShopAddress { get; set; } = null!;

	public void CreateMappings(IProfileExpression configuration)
	{
		configuration.CreateMap<Mechanic, MechanicAllViewModel>()
			.ForMember(m => m.FirstName, opt => opt
				.MapFrom(s => s.User.FirstName))
			.ForMember(m => m.LastName, opt => opt
				.MapFrom(s => s.User.LastName))
			.ForMember(m => m.Email, opt => opt
				.MapFrom(s => s.User.Email));
	}
}
