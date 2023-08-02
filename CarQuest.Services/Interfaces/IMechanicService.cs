namespace CarQuest.Services.Interfaces;

using CarQuest.Data.Models;

using Web.ViewModels.Mechanic;

public interface IMechanicService
{
	Task AddMechanicAsync(MechanicBecomeViewModel mechanic, Guid userId);

	Task<bool> MechanicExistsByUserIdAsync(Guid userId);

	Task RemoveMechanicCarsAsync(Guid userId);

	Task<Mechanic?> GetMechanicByUserIdAsync(Guid userId);
}
