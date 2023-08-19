namespace CarQuest.Services;

using Data;
using Data.Models;
using Data.Models.Enums;

using Interfaces;

using Mapping;

using Microsoft.EntityFrameworkCore;

using Web.ViewModels.Car;
using Web.ViewModels.TicketMechanic;

public class TicketMechanicService : ITicketMechanicService
{
	private readonly CarQuestDbContext context;

	public TicketMechanicService(CarQuestDbContext context)
	{
		this.context = context;
	}

	public IEnumerable<TicketMechanicAllViewModel> GetAllTicketsAsync()
	{
		IEnumerable<TicketMechanicAllViewModel> tickets = context.Tickets
			.Include(t => t.Car)
			.Include(t => t.Owner)
			.Select(t => AutoMapperConfig.MapperInstance.Map<TicketMechanicAllViewModel>(t));

		return tickets;
	}

	public async Task TakeTicketAsync(Guid ticketId, Guid userId)
	{
		Ticket? ticket = await context.Tickets
			.Include(t => t.Offer)
			.FirstOrDefaultAsync(t => t.Id == ticketId);

		if (ticket != null)
		{
			ticket.AssignedMechanicId = await GetMechanicIdByUserId(userId);
			ticket.Status = Status.Taken;

			await context.SaveChangesAsync();
		}
	}

	public async Task<IEnumerable<TicketMechanicAllViewModel>> GetAllTicketsByStatusAsync(Guid userId, Status status)
	{
		Guid mechanicId = await GetMechanicIdByUserId(userId);

		IEnumerable<TicketMechanicAllViewModel> tickets = await context.Tickets
			.Where(t => t.AssignedMechanicId == mechanicId && t.Status == status)
			.Include(t => t.Car)
			.Include(t => t.Owner)
			.Include(t => t.Offer)
			.Select(t => AutoMapperConfig.MapperInstance.Map<TicketMechanicAllViewModel>(t))
			.ToArrayAsync();

		return tickets;
	}

	public async Task ResignTicketAsync(Guid ticketId)
	{
		Ticket? ticket = await context.Tickets
			.Include(t => t.Offer)
			.FirstOrDefaultAsync(t => t.Id == ticketId);

		if (ticket != null)
		{
			ticket.AssignedMechanicId = null;
			ticket.Status = Status.NotTaken;

			if (ticket.Offer != null)
			{
				ticket.OfferId = null;
				context.Offers.Remove(ticket.Offer);
			}

			await context.SaveChangesAsync();
		}
	}

	public async Task CompleteTicketAsync(Guid ticketId)
	{
		Ticket? ticket = await context
			.Tickets.FirstOrDefaultAsync(t => t.Id == ticketId);

		if (ticket != null)
		{
			ticket.Status = Status.Completed;

			await context.SaveChangesAsync();
		}
	}

	public async Task<bool> TicketIsAlreadyTaken(Guid ticketId, Guid userId)
	{
		Guid mechanicId = await GetMechanicIdByUserId(userId);
		Ticket? ticket = await GetTicketByIdAsync(ticketId);

		if (ticket != null)
		{
			return ticket.AssignedMechanicId == mechanicId &&
				   ticket.Status == Status.Taken;
		}

		return true;
	}

	public async Task<CarDetailsViewModel> GetCarDetailsAsync(Guid carId)
	{
		Car car = await context.Cars
			.FirstAsync(c => c.Id == carId);

		CarDetailsViewModel carModel =
			AutoMapperConfig.MapperInstance.Map<CarDetailsViewModel>(car);

		return carModel;
	}

	private async Task<Guid> GetMechanicIdByUserId(Guid userId)
	{
		Mechanic? mechanic = await context.Mechanics
			.FirstOrDefaultAsync(m => m.UserId == userId);

		return mechanic?.Id ?? Guid.Empty;
	}

	private async Task<Ticket?> GetTicketByIdAsync(Guid id)
	{
		Ticket? ticket = await context
			.Tickets.FirstOrDefaultAsync(t => t.Id == id);

		return ticket ?? null;
	}

	public bool IsMechanicAssigned(Guid userId, Guid ticketId) =>
		context.Mechanics
			.Include(m => m.Tickets)
			.FirstAsync(m => m.UserId == userId)
			.Result.Tickets
			.Any(t => t.Id == ticketId);
}
