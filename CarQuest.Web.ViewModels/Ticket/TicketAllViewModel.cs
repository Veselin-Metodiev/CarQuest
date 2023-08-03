namespace CarQuest.Web.ViewModels.Ticket;

using Car;

using Data.Models;

using Services.Mapping;

public class TicketAllViewModel : IMapFrom<Ticket>
{
	public Guid Id { get; set; }

	public string Title { get; set; } = null!;

	public string Description { get; set; } = null!;

	public virtual CarAllViewModel Car { get; set; } = null!;

	public virtual Mechanic? AssignedMechanic { get; set; }
}
