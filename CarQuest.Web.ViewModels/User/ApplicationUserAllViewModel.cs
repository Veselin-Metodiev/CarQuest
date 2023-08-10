namespace CarQuest.Web.ViewModels.User;

using Data.Models;

using Services.Mapping;

public class ApplicationUserAllViewModel : IMapFrom<ApplicationUser>
{
	public Guid Id { get; set; }

	public string FirstName { get; set; } = null!;

	public string LastName { get; set; } = null!;

	public string Email { get; set; } = null!;
}