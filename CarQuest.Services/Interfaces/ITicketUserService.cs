namespace CarQuest.Services.Interfaces;

using Web.ViewModels.TicketUser;

public interface ITicketUserService
{
	IEnumerable<TicketUserAllViewModel> GetAllUserActiveTickets(Guid userId);

	IEnumerable<TicketUserAllViewModel> GetAllUserCompletedTicketsAsync(Guid userId);

	Task AddUserTicketAsync(TicketUserAddViewModel ticketUserModel, Guid userId);

	Task RemoveUserTicketAsync(Guid ticketId);

	Task<TicketUserUpdateViewModel> GetTicketModelByIdAsync (Guid ticketId);

	Task UpdateTicketAsync(TicketUserUpdateViewModel ticketUserModel);

	Task<MechanicInfoViewModel> GetMechanicInfoAsync(Guid userId);

	Task<bool> IsUserOwner(Guid userId, Guid ticketId);
}
