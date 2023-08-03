namespace CarQuest.Services.Interfaces;

using Web.ViewModels.Car;
using Web.ViewModels.Ticket;

public interface ITicketService
{
	public Task<IEnumerable<TicketAllViewModel>> GetAllUserTicketsAsync(Guid userId);

	public Task AddUserTicketAsync(TicketAddAndUpdateViewModel ticketModel, Guid userId);
}
