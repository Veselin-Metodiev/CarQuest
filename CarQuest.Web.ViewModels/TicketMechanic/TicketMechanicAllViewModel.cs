namespace CarQuest.Web.ViewModels.TicketMechanic;

using AutoMapper;
using Car;
using Data.Models;
using Services.Mapping;

public class TicketMechanicAllViewModel : IMapFrom<Ticket>, IHaveCustomMappings
{
	public Guid Id { get; set; }

	public string Title { get; set; } = null!;

	public string Description { get; set; } = null!;

	public Guid CarId { get; set; }

	public virtual CarAllViewModel Car { get; set; } = null!;

	public Guid OwnerId { get; set; }

	public string OwnerFirstName { get; set; } = null!;

	public string OwnerLastName { get; set; } = null!;

	public Guid OfferId { get; set; }

	public void CreateMappings(IProfileExpression configuration)
	{
		configuration.CreateMap<Ticket, TicketMechanicAllViewModel>()
			.ForMember(m => m.Car, opt => opt
				.MapFrom(s => AutoMapperConfig.MapperInstance.Map<CarAllViewModel>(s.Car)))
			.ForMember(m => m.OwnerFirstName, opt => opt
				.MapFrom(s => s.Owner.FirstName))
			.ForMember(m => m.OwnerLastName, opt => opt
				.MapFrom(s => s.Owner.LastName));
	}
}