namespace CarQuest.Web.ViewModels.TicketUser;

using AutoMapper;
using Data.Models;
using Data.Models.Enums;
using Services.Mapping;

public class MechanicInfoViewModel : IMapFrom<Mechanic>, IHaveCustomMappings
{
	public string PhoneNumber { get; set; } = null!;

	public string ShopAddress { get; set; } = null!;

	public int CompletedTickets { get; set; }

	public int TakenTickets { get; set; }
    
	public Guid UserId { get; set; }

	public string FirstName { get; set; } = null!;

	public string LastName { get; set; } = null!;

	public void CreateMappings(IProfileExpression configuration)
	{
		configuration.CreateMap<Mechanic, MechanicInfoViewModel>()
			.ForMember(m => m.CompletedTickets, opt => opt
				.MapFrom(s => s.Tickets.Count(t => t.Status == Status.Completed)))
			.ForMember(m => m.TakenTickets, opt => opt
				.MapFrom(s => s.Tickets.Count(t => t.Status == Status.Taken)))
			.ForMember(m => m.FirstName, opt => opt
				.MapFrom(s => s.User.FirstName))
			.ForMember(m => m.LastName, opt => opt
				.MapFrom(s => s.User.LastName));
	}
}
