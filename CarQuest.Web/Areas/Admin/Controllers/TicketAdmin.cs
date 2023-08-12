namespace CarQuest.Web.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Web.ViewModels.TicketMechanic;

public class TicketAdmin : BaseAdminController
{
	private readonly ITicketMechanicService ticketMechanicService;
	private readonly ITicketUserService ticketUserService;

	public TicketAdmin(ITicketMechanicService ticketMechanicService, ITicketUserService ticketUserService)
	{
		this.ticketMechanicService = ticketMechanicService;
		this.ticketUserService = ticketUserService;
	}

	public IActionResult All()
	{
		IEnumerable<TicketMechanicAllViewModel> model = 
			ticketMechanicService.GetAllTicketsAsync();

		return View(model);
	}

	public async Task<IActionResult> Remove(Guid id)
	{
		await ticketUserService.RemoveUserTicketAsync(id);

		return RedirectToAction("All");
	}
}
