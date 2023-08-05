namespace CarQuest.Web.ViewModels.TicketUser;

using Car;

using Data.Models;

using Services.Mapping;

public class TicketUserAllViewModel : IMapFrom<Ticket>
{
	public Guid Id { get; set; }

	public string Title { get; set; } = null!;

	public string Description { get; set; } = null!;

	public Guid CarId { get; set; }

	public virtual CarAllViewModel Car { get; set; } = null!;

	public virtual Mechanic? AssignedMechanic { get; set; }
}
