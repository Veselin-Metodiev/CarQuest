namespace CarQuest.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class CarCategory
{

	[ForeignKey(nameof(Car))]
	public Guid CarId { get; set; }

	public virtual Car Car { get; set; } = null!;

	[ForeignKey(nameof(Category))]
	public Guid CategoryId { get; set; }

	public virtual Category Category { get; set; } = null!;
}
