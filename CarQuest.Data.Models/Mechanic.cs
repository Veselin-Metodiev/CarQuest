namespace CarQuest.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Mechanic
{
    [Key]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public ApplicationUser User { get; set; } = null!;
}