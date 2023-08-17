namespace CarQuest.Web.Controllers;

using Infrastructure.Extensions;
using ViewModels.TicketUser;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.Interfaces;

using ViewModels.Car;

using static Common.NotificationMessagesConstants;


[Authorize]
public class TicketUserController : BaseController
{
	private readonly ITicketUserService ticketUserService;
	private readonly IMechanicService mechanicService;
	private readonly ICarService carService;

	public TicketUserController(ITicketUserService ticketUserService, IMechanicService mechanicService, ICarService carService)
	{
		this.ticketUserService = ticketUserService;
		this.mechanicService = mechanicService;
		this.carService = carService;
	}

	public async Task<IActionResult> Mine()
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId) &&
		    !User.IsAdmin())
		{
			TempData[ErrorMessage] = MustNotBeMechanicError;
			return RedirectToAction("Index", "Home");
		}

		try
		{
			IEnumerable<TicketUserAllViewModel> tickets =
				ticketUserService.GetAllUserActiveTickets(userId);
			return View(tickets);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}
	}

	public async Task<IActionResult> Completed()
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId) &&
		    !User.IsAdmin())
		{
			TempData[ErrorMessage] = MustNotBeMechanicError;
			return RedirectToAction("Index", "Home");
		}

		try
		{
			IEnumerable<TicketUserAllViewModel> tickets =
				ticketUserService.GetAllUserCompletedTicketsAsync(userId);
			return View(tickets);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}
	}

	[HttpGet]
	public async Task<IActionResult> Add()
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId) &&
		    !User.IsAdmin())
		{
			TempData[ErrorMessage] = MustNotBeMechanicError;
			return RedirectToAction("Index", "Home");
		}

		TicketUserAddViewModel ticketUser = new();

		try
		{
			IEnumerable<CarAllViewModel> cars = await carService.MineCarsAsync(userId);
			ticketUser.Cars = cars;

			return View(ticketUser);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}
	}

	[HttpPost]
	public async Task<IActionResult> Add(TicketUserAddViewModel ticketUserView)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId) &&
		    !User.IsAdmin())
		{
			TempData[ErrorMessage] = MustNotBeMechanicError;
			return RedirectToAction("Index", "Home");
		}

		if (!ModelState.IsValid)
		{
			IEnumerable<CarAllViewModel> cars = await carService.MineCarsAsync(userId);
			ticketUserView.Cars = cars;

			return View(ticketUserView);
		}

		try
		{
			await ticketUserService.AddUserTicketAsync(ticketUserView, userId);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}

		return RedirectToAction("Mine");
	}

	public async Task<IActionResult> Remove(Guid id)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId) &&
		    !User.IsAdmin())
		{
			TempData[ErrorMessage] = MustNotBeMechanicError;
			return RedirectToAction("Index", "Home");
		}

		if (!await ticketUserService.IsUserOwner(userId, id) &&
		    !User.IsAdmin())
		{
			TempData[ErrorMessage] = MustBeOwnerError;
			return RedirectToAction("Index", "Home");
		}

		try
		{
			await ticketUserService.RemoveUserTicketAsync(id);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}

		return RedirectToAction("Mine");
	}

	[HttpGet]
	public async Task<IActionResult> Edit(Guid id)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId) &&
		    !User.IsAdmin())
		{
			TempData[ErrorMessage] = MustNotBeMechanicError;
			return RedirectToAction("Index", "Home");
		}

		if (!await ticketUserService.IsUserOwner(userId, id) &&
		    !User.IsAdmin())
		{
			TempData[ErrorMessage] = MustBeOwnerError;
			return RedirectToAction("Index", "Home");
		}

		try
		{
			TicketUserUpdateViewModel ticketUserModel =
				await ticketUserService.GetTicketModelByIdAsync(id);

			IEnumerable<CarAllViewModel> cars = await carService.MineCarsAsync(userId);
			ticketUserModel.Cars = cars;

			return View(ticketUserModel);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}
	}

	[HttpPost]
	public async Task<IActionResult> Edit(TicketUserUpdateViewModel ticketUserModel)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId) &&
		    !User.IsAdmin())
		{
			TempData[ErrorMessage] = MustNotBeMechanicError;
			return RedirectToAction("Index", "Home");
		}

		if (!await ticketUserService.IsUserOwner(userId, ticketUserModel.Id) &&
		    !User.IsAdmin())
		{
			TempData[ErrorMessage] = MustBeOwnerError;
			return RedirectToAction("Index", "Home");
		}

		if (!ModelState.IsValid)
		{
			return View(ticketUserModel);
		}

		try
		{
			await ticketUserService.UpdateTicketAsync(ticketUserModel);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}

		return RedirectToAction("Mine");
	}

	public async Task<IActionResult> MechanicInfo(Guid id)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId) &&
		    !User.IsAdmin())
		{
			TempData[ErrorMessage] = MustNotBeMechanicError;
			return RedirectToAction("Index", "Home");
		}

		try
		{
			MechanicInfoViewModel mechanicModel =
				await ticketUserService.GetMechanicInfoAsync(id);

			return View(mechanicModel);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}
	}
}