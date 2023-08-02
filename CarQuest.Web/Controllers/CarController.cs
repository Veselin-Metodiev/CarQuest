namespace CarQuest.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.Interfaces;

using ViewModels.Car;

using Car = Data.Models.Car;

[Authorize]
public class CarController : BaseController
{
	private readonly ICarService carService;
	private readonly IMechanicService mechanicService;

	public CarController(ICarService carService, IMechanicService mechanicService)
	{
		this.carService = carService;
		this.mechanicService = mechanicService;
	}

	public async Task<IActionResult> All()
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			return RedirectToAction("Index", "Home");
		}

		IEnumerable<Car> cars = await carService.AllUserCarsAsync(userId);

		return View(cars);
	}

	[HttpGet]
	public async Task<IActionResult> Add()
	{
		if (await mechanicService.MechanicExistsByUserIdAsync(GetUserId()))
		{
			return RedirectToAction("Index", "Home");
		}

		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Add(CarAddAndUpdateViewModel car)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			return RedirectToAction("Index", "Home");
		}

		if (!ModelState.IsValid)
		{
			return View();
		}
		
		await carService.AddUserCarAsync(userId, car);

		return RedirectToAction("All");
	}

	public async Task<IActionResult> Remove(Guid Id)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			return RedirectToAction("Index", "Home");
		}

		await carService.DeleteUserCarAsync(Id);

		return RedirectToAction("All");
	}

	[HttpGet]
	public async Task<IActionResult> Edit(Guid Id)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			return RedirectToAction("Index", "Home");
		}

		CarAddAndUpdateViewModel car = await carService.GetCarAddAndUpdateViewModelAsync(Id);

		return View(car);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(Guid Id, CarAddAndUpdateViewModel car)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			return RedirectToAction("Index", "Home");
		}

		if (!ModelState.IsValid)
		{
			return View(car);
		}

		await carService.UpdateUserCarAsync(Id, car);

		return RedirectToAction("All");
	}
}
