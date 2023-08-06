namespace CarQuest.Web.Controllers;

using Data.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using ViewModels.TicketMechanic;

using static Common.NotificationMessagesConstants;


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

		IEnumerable<TicketMechanicAllViewModel> ticketModel =
			 ticketMechanicService.GetAllTicketsAsync();

		return View(ticketModel);
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

		await ticketMechanicService.TakeTicketAsync(id, userId);

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

		IEnumerable<TicketMechanicAllViewModel> tickets =
			await ticketMechanicService.GetAllTicketsByStatusAsync(userId, Status.Taken);

		return View(tickets);
	}

	public async Task<IActionResult> Completed()
	{
		Guid userId = GetUserId();

		if (!await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must be a mehcanic to complete tickets";
			return RedirectToAction("Index", "Home");
		}

		IEnumerable<TicketMechanicAllViewModel> tickets =
			await ticketMechanicService.GetAllTicketsByStatusAsync(userId, Status.Completed);

		return View(tickets);
	}

	public async Task<IActionResult> Resign(Guid id)
	{
		Guid userId = GetUserId();

		if (!await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must be a mehcanic to resign tickets";
			return RedirectToAction("Index", "Home");
		}

		await ticketMechanicService.ResignTicketAsync(id);

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

		await ticketMechanicService.CompleteTicketAsync(id);

		return RedirectToAction("Completed");
	}
}
