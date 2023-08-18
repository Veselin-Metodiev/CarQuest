namespace CarQuest.Web.ViewModels.TicketUser;

using AutoMapper;

using Car;

using Data.Models;
using Data.Models.Enums;

using Services.Mapping;

public class TicketUserAllViewModel : IMapFrom<Ticket>, IHaveCustomMappings
{
	public Guid Id { get; set; }

	public string Title { get; set; } = null!;

	public string Description { get; set; } = null!;

	public Guid CarId { get; set; }

	public virtual CarAllViewModel Car { get; set; } = null!;

	public Guid? AssignedMechanicId { get; set; }

	public string? AssignedMechanicFirstName { get; set; }

	public string? AssignedMechanicLastName { get; set; }

	public Status Status { get; set; }

	public Guid? OfferId { get; set; }

	public void CreateMappings(IProfileExpression configuration)
	{
		configuration.CreateMap<Ticket, TicketUserAllViewModel>()
			.ForMember(m => m.Car, opt => opt
				.MapFrom(s => AutoMapperConfig.MapperInstance.Map<CarAllViewModel>(s.Car)))
			.ForMember(m => m.AssignedMechanicFirstName, opt => opt
				.MapFrom(s => s.AssignedMechanic!.User.FirstName))
			.ForMember(m => m.AssignedMechanicLastName, opt => opt
				.MapFrom(s => s.AssignedMechanic!.User.LastName));
	}
}
