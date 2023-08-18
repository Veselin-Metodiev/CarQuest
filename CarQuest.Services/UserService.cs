namespace CarQuest.Services;

using Data;
using Interfaces;
using Mapping;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.User;

public class UserService : IUserService
{
	private readonly CarQuestDbContext context;

	public UserService(CarQuestDbContext context)
	{
		this.context = context;
	}

	public async Task<ICollection<ApplicationUserAllViewModel>> GetAllApplicationUsersAsync()
	{
		ICollection<ApplicationUserAllViewModel> appUsers = await context.Users
			.Where(u => !context.Mechanics.Any(m => m.UserId == u.Id))
			.Select(u => AutoMapperConfig.MapperInstance.Map<ApplicationUserAllViewModel>(u))
			.ToArrayAsync();

		return appUsers;
	}

	public async Task<ICollection<MechanicAllViewModel>> GetAllMechanicsAsync()
	{
		ICollection<MechanicAllViewModel> mechanics = await context.Mechanics
			.Include(m => m.User)
			.Select(m => AutoMapperConfig.MapperInstance.Map<MechanicAllViewModel>(m))
			.ToArrayAsync();

		return mechanics;
	}
}
