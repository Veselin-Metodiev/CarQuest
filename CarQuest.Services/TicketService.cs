namespace CarQuest.Services;

using CarQuest.Web.ViewModels.TicketUser;

using Data;
using Data.Models;

using Interfaces;

using Mapping;

using Microsoft.EntityFrameworkCore;

using Web.ViewModels.Car;
using Web.ViewModels.Ticket;

public class TicketService : ITicketService
{
	private readonly CarQuestDbContext context;

	public TicketService(CarQuestDbContext context)
	{
		this.context = context;
	}

	public async Task<IEnumerable<TicketUserAllViewModel>> GetAllUserTicketsAsync(Guid userId)
	{
		IEnumerable<TicketUserAllViewModel> tickets = await context.Tickets
			.Where(u => u.OwnerId == userId)
			.Select(t => AutoMapperConfig.MapperInstance.Map<TicketUserAllViewModel>(t))
			.ToArrayAsync();

		foreach (TicketUserAllViewModel ticket in tickets)
		{
			Car ticketCar = await context.Cars
				.FirstAsync(c => c.Id == ticket.CarId);

			ticket.Car = AutoMapperConfig.MapperInstance.Map<CarAllViewModel>(ticketCar);
		}

		return tickets;
	}

	public async Task AddUserTicketAsync(TicketUserAddViewModel ticketUserModel, Guid userId)
	{
		Ticket ticket = AutoMapperConfig.MapperInstance.Map<Ticket>(ticketUserModel);
		ticket.OwnerId = userId;

		await context.AddAsync(ticket);
		await context.SaveChangesAsync();
	}

	public async Task RemoveUserTicketAsync(Guid ticketId)
	{
		Ticket? ticket = await context.Tickets
			.FirstOrDefaultAsync(t => t.Id == ticketId);

		if (ticket != null)
		{
			context.Tickets.Remove(ticket);
			await context.SaveChangesAsync();
		}
	}

	public async Task<TicketUserUpdateViewModel> GetTicketModelByIdAsync(Guid ticketId)
	{
		Ticket? ticket = await context.Tickets
			.FirstOrDefaultAsync(t => t.Id == ticketId);

		TicketUserUpdateViewModel ticketUserModel = new();

		if (ticket != null)
		{
			ticketUserModel =
				AutoMapperConfig.MapperInstance.Map<TicketUserUpdateViewModel>(ticket);
		}

		return ticketUserModel;
	}

	public async Task UpdateTicketAsync(TicketUserUpdateViewModel ticketUserModel)
	{
		Ticket? ticket = await context.Tickets
			.FirstOrDefaultAsync(t => t.Id == ticketUserModel.Id);

		if (ticket != null)
		{
			ticket.CarId = ticketUserModel.CarId;
			ticket.Description = ticketUserModel.Description;
			ticketUserModel.Title = ticketUserModel.Title;

			await context.SaveChangesAsync();
		}
	}
}
