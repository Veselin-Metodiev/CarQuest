namespace CarQuest.Web.Controllers;

using CarQuest.Web.ViewModels.TicketUser;

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
			return RedirectToAction("Index", "Home");
		}

		IEnumerable<TicketUserAllViewModel> tickets =
			await ticketService.GetAllUserTicketsAsync(userId);

		return View(tickets);
	}

	[HttpGet]
	public async Task<IActionResult> UserAdd()
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			return RedirectToAction("Index", "Home");
		}

		TicketUserAddViewModel ticketUser = new();

		IEnumerable<CarAllViewModel> cars = await carService.AllUserCarsAsync(userId);
		ticketUser.Cars = cars;

		return View(ticketUser);
	}

	[HttpPost]
	public async Task<IActionResult> UserAdd(TicketUserAddViewModel ticketUserView)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			return RedirectToAction("Index", "Home");
		}

		if (!ModelState.IsValid)
		{
			IEnumerable<CarAllViewModel> cars = await carService.AllUserCarsAsync(userId);
			ticketUserView.Cars = cars;

			return View(ticketUserView);
		}

		await ticketService.AddUserTicketAsync(ticketUserView, userId);

		return RedirectToAction("UserAll");
	}

	public async Task<IActionResult> UserRemove(Guid Id)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			return RedirectToAction("Index", "Home");
		}

		await ticketService.RemoveUserTicketAsync(Id);

		return RedirectToAction("UserAll");
	}

	[HttpGet]
	public async Task<IActionResult> UserEdit(Guid Id)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			return RedirectToAction("Index", "Home");
		}

		TicketUserUpdateViewModel ticketUserModel =
			await ticketService.GetTicketModelByIdAsync(Id);

		IEnumerable<CarAllViewModel> cars = await carService.AllUserCarsAsync(userId);
		ticketUserModel.Cars = cars;

		return View(ticketUserModel);
	}

	[HttpPost]
	public async Task<IActionResult> UserEdit(TicketUserUpdateViewModel ticketUserModel)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			return RedirectToAction("Index", "Home");
		}

		if (!ModelState.IsValid)
		{
			return View(ticketUserModel);
		}

		await ticketService.UpdateTicketAsync(ticketUserModel);

		return RedirectToAction("UserAll");
	}
}
