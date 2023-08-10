namespace CarQuest.Web.Areas.Admin.Controllers;

using Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Web.ViewModels.Car;

using static Common.NotificationMessagesConstants;

public class CarController : BaseAdminController
{
	private readonly ICarService carService;

	public CarController(ICarService carService)
	{
		this.carService = carService;
	}

	public async Task<IActionResult> All()
	{
		if (!User.IsAdmin())
		{
			TempData[ErrorMessage] = "You must have admin rights to access this page";
			return RedirectToAction("Index", "Home");
		}

		IEnumerable<CarAllViewModel> cars =
			await carService.AllCarsAsync();

		return View(cars);
	}
}
