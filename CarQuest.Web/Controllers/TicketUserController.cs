namespace CarQuest.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.Interfaces;
using ViewModels.Car;
using ViewModels.Ticket;

[Authorize]
public class TicketUserController : BaseController
{
	private readonly ITicketService ticketService;
	private readonly IMechanicService mechanicService;
	private readonly ICarService carService;

	public TicketUserController(ITicketService ticketService ,IMechanicService mechanicService, ICarService carService)
	{
		this.ticketService = ticketService;
		this.mechanicService = mechanicService;
		this.carService = carService;
	}

	public async Task<IActionResult> UserAll()
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			RedirectToAction("Index", "Home");
		}

		IEnumerable<TicketAllViewModel> tickets =
			await ticketService.GetAllUserTicketsAsync(userId);

		return View(tickets);
	}

	[HttpGet]
	public async Task<IActionResult> UserAdd()
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			RedirectToAction("Index", "Home");
		}

		TicketAddAndUpdateViewModel ticket = new();

		IEnumerable<CarAllViewModel> cars = await carService.AllUserCarsAsync(userId);
		ticket.Cars = cars;

		return View(ticket);
	}
}
