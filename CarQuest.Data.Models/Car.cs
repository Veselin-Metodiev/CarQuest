using CarQuest.Common;

namespace CarQuest.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static EntityValidationConstants.Car;

public class Car
{
	public Car()
	{
		Tickets = new HashSet<Ticket>();
		CarCategories = new HashSet<CarCategory>();
	}

    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(BrandMaxLength)]
    public string Brand { get; set; } = null!;

    [Required]
    [StringLength(ModelMaxLength)]
    public string Model { get; set; } = null!;

    [Required]
    [StringLength(YearMaxLength)]
    public string Year { get; set; } = null!;

    [Required]
    [StringLength(MileageMaxLength)]
    public string Mileage { get; set; } = null!;

    [Required]
    [StringLength(CarImageUrlMaxLength)]
    public string ImageUrl { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Owner))]
    public Guid OwnerId { get; set; }

    public virtual ApplicationUser Owner { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; }

    public virtual ICollection<CarCategory> CarCategories { get; set; }
}
