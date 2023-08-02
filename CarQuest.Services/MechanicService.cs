namespace CarQuest.Services;

using Mapping;

using Data;
using Data.Models;

using Interfaces;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.Mechanic;

public class MechanicService : IMechanicService
{
	private readonly CarQuestDbContext context;

	public MechanicService(CarQuestDbContext context)
	{
		this.context = context;
	}

	public async Task AddMechanicAsync(MechanicBecomeViewModel mechanicViewModel, Guid userId)
	{
		Mechanic mechanic = AutoMapperConfig.MapperInstance.Map<Mechanic>(mechanicViewModel);
		mechanic.UserId = userId;

		await context.Mechanics.AddAsync(mechanic);
		await context.SaveChangesAsync();
	}

	public async Task RemoveMechanicCarsAsync(Guid userId)
	{
		ApplicationUser? user = await context.Users.FindAsync(userId);

		if (user != null)
		{
			context.Cars.RemoveRange(user.Cars);
			await context.SaveChangesAsync();
		}
	}

	public async Task<Mechanic?> GetMechanicByUserIdAsync(Guid userId) =>
		await context.Mechanics.FirstOrDefaultAsync(m => m.UserId == userId);

	public async Task<bool> MechanicExistsByUserIdAsync(Guid userId) =>
		await context.Mechanics.AnyAsync(m => m.UserId == userId);
}
