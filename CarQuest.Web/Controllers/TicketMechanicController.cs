namespace CarQuest.Web.Controllers;

using Data.Models.Enums;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.Interfaces;

using ViewModels.Car;
using ViewModels.TicketMechanic;

using static Common.NotificationMessagesConstants;


[Authorize]
public class TicketMechanicController : BaseController
{
	private readonly ITicketMechanicService ticketMechanicService;
	private readonly IMechanicService mechanicService;

	public TicketMechanicController(ITicketMechanicService ticketMechanicService, IMechanicService mechanicService)
	{
		this.ticketMechanicService = ticketMechanicService;
		this.mechanicService = mechanicService;
	}

	public async Task<IActionResult> AllUser()
	{
		if (!await mechanicService.MechanicExistsByUserIdAsync(GetUserId()))
		{
			TempData[ErrorMessage] = "You must be a mehcanic to see users tickets";
			return RedirectToAction("Index", "Home");
		}

		try
		{
			IEnumerable<TicketMechanicAllViewModel> ticketModel =
				ticketMechanicService.GetAllTicketsAsync();
			return View(ticketModel);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}
	}

	public async Task<IActionResult> Take(Guid id)
	{
		Guid userId = GetUserId();

		if (!await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must be a mehcanic to take users tickets";
			return RedirectToAction("Index", "Home");
		}

		if (await ticketMechanicService.TicketIsAlreadyTaken(id, userId))
		{
			TempData[ErrorMessage] = "Ticket is already taken";
			return RedirectToAction("AllUser");
		}

		try
		{
			await ticketMechanicService.TakeTicketAsync(id, userId);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}

		return RedirectToAction("AllMechanic");
	}

	public async Task<IActionResult> AllMechanic()
	{
		Guid userId = GetUserId();

		if (!await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must be a mehcanic to see tickets";
			return RedirectToAction("Index", "Home");
		}

		try
		{
			IEnumerable<TicketMechanicAllViewModel> tickets =
				await ticketMechanicService.GetAllTicketsByStatusAsync(userId, Status.Taken);
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

		if (!await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must be a mehcanic to complete tickets";
			return RedirectToAction("Index", "Home");
		}

		try
		{
			IEnumerable<TicketMechanicAllViewModel> tickets =
				await ticketMechanicService.GetAllTicketsByStatusAsync(userId, Status.Completed);
			return View(tickets);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}
	}

	public async Task<IActionResult> Resign(Guid id)
	{
		Guid userId = GetUserId();

		if (!await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must be a mehcanic to resign tickets";
			return RedirectToAction("Index", "Home");
		}

		try
		{
			await ticketMechanicService.ResignTicketAsync(id);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}

		return RedirectToAction("AllMechanic");
	}

	public async Task<IActionResult> Complete(Guid id)
	{
		Guid userId = GetUserId();

		if (!await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must be a mehcanic to resign tickets";
			return RedirectToAction("Index", "Home");
		}

		try
		{
			await ticketMechanicService.CompleteTicketAsync(id);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}

		return RedirectToAction("Completed");
	}

	public async Task<IActionResult> Details(Guid id)
	{
		Guid userId = GetUserId();

		if (!await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must be a mehcanic to see car details";
			return RedirectToAction("Index", "Home");
		}

		try
		{
			CarDetailsViewModel carModel = await ticketMechanicService.GetCarDetailsAsync(id);
			return View(carModel);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}

	}
}