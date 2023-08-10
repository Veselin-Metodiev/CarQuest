namespace CarQuest.Web.Areas.Admin.ViewModels;

using Web.ViewModels.User;

public class UserAllViewModel
{
	public UserAllViewModel()
	{
		AllApplicationUsers = new HashSet<ApplicationUserAllViewModel>();
		AllMechanics = new HashSet<MechanicAllViewModel>();
	}

	public virtual IEnumerable<ApplicationUserAllViewModel> AllApplicationUsers { get; set; }

	public virtual IEnumerable<MechanicAllViewModel> AllMechanics { get; set; }
}
