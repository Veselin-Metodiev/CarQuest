namespace CarQuest.Services.Interfaces;

using Data.Models.Enums;
using Web.ViewModels.Car;
using Web.ViewModels.TicketMechanic;

public interface ITicketMechanicService
{
	public IEnumerable<TicketMechanicAllViewModel> GetAllTicketsAsync();

	public Task TakeTicketAsync(Guid ticketId, Guid userId);

	public Task<IEnumerable<TicketMechanicAllViewModel>> GetAllTicketsByStatusAsync(Guid userId, Status status);

	public Task ResignTicketAsync(Guid ticketId);

	public Task CompleteTicketAsync(Guid ticketId);

	public Task<bool> TicketIsAlreadyTaken(Guid ticketId, Guid userId);

	public Task<CarDetailsViewModel> GetCarDetailsAsync(Guid carId);
}
