namespace CarQuest.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.EntityValidationConstants.Offer;

public class Offer
{
	[Key]
	public Guid Id { get; set; }

	[Required]
	[StringLength(TitleMaxLength)]
	public string Title { get; set; } = null!;

	[Required]
	[StringLength(DescriptionMaxLength)]
	public string Description { get; set; } = null!;

	public int EstimatedDurationDays { get; set; }

	public int EstimatedDurationHours { get; set; }

	public decimal Cost { get; set; }

	[Required]
	[ForeignKey(nameof(Ticket))]
	public Guid TicketId { get; set; }

	public virtual Ticket Ticket { get; set; } = null!;

	public bool HasUserAccepted { get; set; }
}
