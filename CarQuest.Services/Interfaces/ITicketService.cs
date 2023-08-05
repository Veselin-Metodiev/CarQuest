namespace CarQuest.Services.Interfaces;

using CarQuest.Web.ViewModels.TicketUser;

using Web.ViewModels.Car;
using Web.ViewModels.Ticket;

public interface ITicketService
{
	public Task<IEnumerable<TicketUserAllViewModel>> GetAllUserTicketsAsync(Guid userId);

	public Task AddUserTicketAsync(TicketUserAddViewModel ticketUserModel, Guid userId);

	public Task RemoveUserTicketAsync(Guid ticketId);

	public Task<TicketUserUpdateViewModel> GetTicketModelByIdAsync (Guid ticketId);

	public Task UpdateTicketAsync(TicketUserUpdateViewModel ticketUserModel);
}
