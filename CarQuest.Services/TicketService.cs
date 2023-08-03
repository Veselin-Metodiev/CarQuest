namespace CarQuest.Services;

using Data;
using Data.Models;
using Interfaces;
using Mapping;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.Ticket;

public class TicketService : ITicketService
{
	private readonly CarQuestDbContext context;

	public TicketService(CarQuestDbContext context)
	{
		this.context = context;
	}

	public async Task<IEnumerable<TicketAllViewModel>> GetAllUserTicketsAsync(Guid userId)
	{
		IEnumerable<TicketAllViewModel> tickets = await context.Tickets
			.Where(t => t.OwnerId == userId)
			.Select(t => AutoMapperConfig.MapperInstance.Map<TicketAllViewModel>(t))
			.ToArrayAsync();

		return tickets;
	}

	public async Task AddUserTicketAsync(TicketAddAndUpdateViewModel ticketModel, Guid userId)
	{
		Ticket ticket = AutoMapperConfig.MapperInstance.Map<Ticket>(ticketModel);
		ticket.OwnerId = userId;

		await context.Tickets.AddAsync(ticket);
		await context.SaveChangesAsync();
	}
}
