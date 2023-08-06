namespace CarQuest.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Enums;
using static Common.EntityValidationConstants.Ticket;

public class Ticket
{
	[Key]
	public Guid Id { get; set; }

	[Required]
	[StringLength(TitleMaxLength)]
	public string Title { get; set; } = null!;

	[Required]
	[StringLength(DescriptionMaxLength)]
	public string Description { get; set; } = null!;

	[Required]
	[ForeignKey(nameof(Car))]
	public Guid CarId { get; set; }

	public virtual Car Car { get; set; } = null!;

	[Required]
	[ForeignKey(nameof(Owner))]
	public Guid OwnerId { get; set; }

	public virtual ApplicationUser Owner { get; set; } = null!;

	[ForeignKey(nameof(AssignedMechanic))]
	public Guid? AssignedMechanicId { get; set; }

	public virtual Mechanic? AssignedMechanic { get; set; }

	public Status Status { get; set; }
}
