namespace CarQuest.Services.Interfaces;

using Web.ViewModels.User;

public interface IUserService
{
	Task<ICollection<ApplicationUserAllViewModel>> GetAllApplicationUsersAsync();

	Task<ICollection<MechanicAllViewModel>> GetAllMechanicsAsync();
}
