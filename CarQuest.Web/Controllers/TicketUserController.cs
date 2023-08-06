namespace CarQuest.Web.Controllers;

using CarQuest.Web.ViewModels.TicketUser;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.Interfaces;

using ViewModels.Car;
using ViewModels.TicketUser;

using static Common.NotificationMessagesConstants;


[Authorize]
public class TicketUserController : BaseController
{
	private readonly ITicketUserService ticketUserService;
	private readonly IMechanicService mechanicService;
	private readonly ICarService carService;

	public TicketUserController(ITicketUserService ticketUserService ,IMechanicService mechanicService, ICarService carService)
	{
		this.ticketUserService = ticketUserService;
		this.mechanicService = mechanicService;
		this.carService = carService;
	}

	public async Task<IActionResult> All()
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must not be a mehcanic to see tickets";
			return RedirectToAction("Index", "Home");
		}

		IEnumerable<TicketUserAllViewModel> tickets =
			 ticketUserService.GetAllUserTicketsAsync(userId);

		return View(tickets);
	}

	[HttpGet]
	public async Task<IActionResult> Add()
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must not be a mehcanic to add tickets";
			return RedirectToAction("Index", "Home");
		}

		TicketUserAddViewModel ticketUser = new();

		IEnumerable<CarAllViewModel> cars = await carService.AllUserCarsAsync(userId);
		ticketUser.Cars = cars;

		return View(ticketUser);
	}

	[HttpPost]
	public async Task<IActionResult> Add(TicketUserAddViewModel ticketUserView)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must not be a mehcanic to add tickets";
			return RedirectToAction("Index", "Home");
		}

		if (!ModelState.IsValid)
		{
			IEnumerable<CarAllViewModel> cars = await carService.AllUserCarsAsync(userId);
			ticketUserView.Cars = cars;

			return View(ticketUserView);
		}

		await ticketUserService.AddUserTicketAsync(ticketUserView, userId);

		return RedirectToAction("All");
	}

	public async Task<IActionResult> Remove(Guid Id)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must not be a mehcanic to remove tickets";
			return RedirectToAction("Index", "Home");
		}

		await ticketUserService.RemoveUserTicketAsync(Id);

		return RedirectToAction("All");
	}

	[HttpGet]
	public async Task<IActionResult> Edit(Guid Id)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must not be a mehcanic to edit tickets";
			return RedirectToAction("Index", "Home");
		}

		TicketUserUpdateViewModel ticketUserModel =
			await ticketUserService.GetTicketModelByIdAsync(Id);

		IEnumerable<CarAllViewModel> cars = await carService.AllUserCarsAsync(userId);
		ticketUserModel.Cars = cars;

		return View(ticketUserModel);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(TicketUserUpdateViewModel ticketUserModel)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must not be a mehcanic to edit tickets";
			return RedirectToAction("Index", "Home");
		}

		if (!ModelState.IsValid)
		{
			return View(ticketUserModel);
		}

		await ticketUserService.UpdateTicketAsync(ticketUserModel);

		return RedirectToAction("All");
	}

	public async Task<IActionResult> MechanicInfo(Guid id)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must not be a mehcanic to see mehcanic info";
			return RedirectToAction("Index", "Home");
		}

		MechanicInfoViewModel mechanicModel =
			await ticketUserService.GetMechanicInfoAsync(id);

		return View(mechanicModel);
	}
}
