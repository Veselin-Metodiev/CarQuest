namespace CarQuest.Data.Models;

using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public ApplicationUser()
    {
        Cars = new HashSet<Car>();
    }

    public ICollection<Car> Cars { get; set; }
}