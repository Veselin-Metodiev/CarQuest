namespace CarQuest.Services.Interfaces;

using Web.ViewModels.TicketUser;

public interface ITicketUserService
{
	public IEnumerable<TicketUserAllViewModel> GetAllUserTicketsAsync(Guid userId);

	public Task AddUserTicketAsync(TicketUserAddViewModel ticketUserModel, Guid userId);

	public Task RemoveUserTicketAsync(Guid ticketId);

	public Task<TicketUserUpdateViewModel> GetTicketModelByIdAsync (Guid ticketId);

	public Task UpdateTicketAsync(TicketUserUpdateViewModel ticketUserModel);

	public Task<MechanicInfoViewModel> GetMechanicInfoAsync(Guid userId);

	public Task<bool> IsUserOwner(Guid userId, Guid ticketId);
}
