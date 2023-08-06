namespace CarQuest.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.Interfaces;

using ViewModels.Mechanic;

using static Common.NotificationMessagesConstants;

[Authorize]
public class MechanicController : BaseController
{
	private readonly IMechanicService mechanicService;

	public MechanicController(IMechanicService mechanicService)
	{
		this.mechanicService = mechanicService;
	}

	[HttpGet]
	public async Task<IActionResult> Become()
	{
		if (await mechanicService.MechanicExistsByUserIdAsync(GetUserId()))
		{
			TempData["ErrorMessage"] = "You are already a mechanic";
			return RedirectToAction("Index", "Home");
		}

		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Become(MechanicBecomeViewModel mechanicViewModel)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You are already a mehcanic";
			return RedirectToAction("Index", "Home");
		}

		if (await mechanicService.MechanicExistsByPhoneNumberAsync(mechanicViewModel.PhoneNumber))
		{
			TempData[ErrorMessage] = "Mechanic with the provided phone number already exists!";
			return RedirectToAction("Index", "Home");
		}

		if (mechanicService.MechanicHasTicketsAsync(userId))
		{
			TempData[ErrorMessage] = "You must not have any active tickets to be a mechanic";
			return RedirectToAction("Index", "Home");
		}

		if (!ModelState.IsValid)
		{
			return View();
		}

		try
		{
			await mechanicService.RemoveMechanicCarsAsync(GetUserId());
			await mechanicService.AddMechanicAsync(mechanicViewModel, GetUserId());
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return View();
		}

		return RedirectToAction("Index", "Home");
	}
}
