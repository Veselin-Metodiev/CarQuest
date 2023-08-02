namespace CarQuest.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.Interfaces;

using ViewModels.Mechanic;

[Authorize]
public class MechanicController : BaseController
{
	private readonly IMechanicService mechanicService;

	public MechanicController(IMechanicService mechanicService)
	{
		this.mechanicService = mechanicService;
	}

	[HttpGet]
	public async Task<ViewResult> Become()
	{
		if (await mechanicService.MechanicExistsByUserIdAsync(GetUserId()))
		{
			RedirectToAction("Index", "Home");
		}

		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Become(MechanicBecomeViewModel mechanicViewModel)
	{
		if (await mechanicService.MechanicExistsByUserIdAsync(GetUserId()))
		{
			RedirectToAction("Index", "Home");
		}

		if (!ModelState.IsValid)
		{
			return View();
		}

		await mechanicService.RemoveMechanicCarsAsync(GetUserId());
		await mechanicService.AddMechanicAsync(mechanicViewModel, GetUserId());

		return RedirectToAction("Index", "Home");
	}
}
