namespace CarQuest.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Mechanic
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(20)]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string ShopAddress { get; set; } = null!;
    
    public Guid UserId { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;
}