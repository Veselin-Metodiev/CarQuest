using CarQuest.Common;

namespace CarQuest.Data.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

using static EntityValidationConstants.ApplicationUser;

public class ApplicationUser : IdentityUser<Guid>
{
    public ApplicationUser()
    {
        Cars = new HashSet<Car>();
        Tickets = new HashSet<Ticket>();
    }

    [Required]
    [StringLength(FirstNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(LastNameMaxLength)]
    public string LastName { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; }
}