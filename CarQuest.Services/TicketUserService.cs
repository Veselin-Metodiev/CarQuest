namespace CarQuest.Services;

using Web.ViewModels.TicketUser;

using Data;
using Data.Models;

using Interfaces;

using Mapping;

using Microsoft.EntityFrameworkCore;

using Web.ViewModels.Car;
using System.Collections.Generic;

public class TicketUserService : ITicketUserService
{
	private readonly CarQuestDbContext context;

	public TicketUserService(CarQuestDbContext context)
	{
		this.context = context;
	}

	public IEnumerable<TicketUserAllViewModel> GetAllUserTicketsAsync(Guid userId)
	{
		IEnumerable<TicketUserAllViewModel> tickets = context.Tickets
			.Where(t => t.OwnerId == userId)
			.Include(t => t.Car)
			.Include(t => t.AssignedMechanic)
			.ThenInclude(m => m!.User)
			.Select(t => AutoMapperConfig.MapperInstance.Map<TicketUserAllViewModel>(t));

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

	public async Task<MechanicInfoViewModel> GetMechanicInfoAsync(Guid mechanicId)
	{
		Mechanic? mechanic = await context.Mechanics
			.Include(m => m.User)
			.Include(m => m.Tickets)
			.FirstOrDefaultAsync(m => m.Id == mechanicId);

		MechanicInfoViewModel mechanicModel = new();

		if (mechanic != null)
		{
			mechanicModel =
			AutoMapperConfig.MapperInstance.Map<MechanicInfoViewModel>(mechanic);
		}

		return mechanicModel;
	}
}
