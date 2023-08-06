namespace CarQuest.Services.Interfaces;

using Web.ViewModels.Mechanic;

public interface IMechanicService
{
	Task AddMechanicAsync(MechanicBecomeViewModel mechanic, Guid userId);

	Task<bool> MechanicExistsByUserIdAsync(Guid userId);

	Task RemoveMechanicCarsAsync(Guid userId);

	Task<bool> MechanicExistsByPhoneNumberAsync(string phonenumber);

	bool MechanicHasTicketsAsync(Guid userId);
}
