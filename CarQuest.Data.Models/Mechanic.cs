namespace CarQuest.Data.Models;

using System.ComponentModel.DataAnnotations;

using static Common.EntityValidationConstants.Mechanic;

public class Mechanic
{
	public Mechanic()
	{
		Tickets = new HashSet<Ticket>();
	}

    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(PhoneNumberMaxLength)]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    [StringLength(ShopAddressMaxLength)]
    public string ShopAddress { get; set; } = null!;
    
    public Guid UserId { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; }
}