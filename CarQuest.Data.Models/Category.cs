namespace CarQuest.Data.Models;

using System.ComponentModel.DataAnnotations;

using static Common.EntityValidationConstants.Category;

public class Category
{
	public Category()
	{
		CategoryCars = new HashSet<CarCategory>();
	}

	[Key]
	public Guid Id { get; set; }

	[StringLength(NameMaxLength)]
	[Required]
	public string Name { get; set; } = null!;

	public virtual ICollection<CarCategory> CategoryCars { get; set; }
}
