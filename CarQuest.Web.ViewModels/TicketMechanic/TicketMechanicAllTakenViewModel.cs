namespace CarQuest.Web.ViewModels.TicketMechanic;

using Car;
using Data.Models;
using Services.Mapping;

public class TicketMechanicAllTakenViewModel : IMapFrom<Ticket>
{
	public Guid Id { get; set; }

	public string Title { get; set; } = null!;

	public string Description { get; set; } = null!;

	public Guid CarId { get; set; }

	public virtual CarAllViewModel Car { get; set; } = null!;

	public Guid OwnerId { get; set; }

	public virtual ApplicationUser Owner { get; set; } = null!;
}
