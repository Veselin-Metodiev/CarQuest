namespace CarQuest.Web.Controllers;

using Data.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.Interfaces;

using ViewModels.Car;

[Authorize]
public class CarController : BaseController
{
	private readonly ICarService carService;

	public CarController(ICarService carService)
	{
		this.carService = carService;
	}

	public async Task<IActionResult> All()
	{
		IEnumerable<Car> cars = await carService.AllUserCarsAsync(GetUserId());

		return View(cars);
	}

	[HttpGet]
	public IActionResult Add()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Add(CarAddAndUpdateViewModel car)
	{
		await carService.AddUserCarAsync(GetUserId(), car);

		if (ModelState.IsValid)
		{
			return RedirectToAction("All");
		}

		return View();
	}

	public async Task<IActionResult> Remove(Guid Id)
	{
		await carService.DeleteUserCarAsync(Id);

		return RedirectToAction("All");
	}

	[HttpGet]
	public async Task<IActionResult> Edit(Guid Id)
	{
		CarAddAndUpdateViewModel car = await carService.GetCarAddAndUpdateViewModelAsync(Id);

		return View(car);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(Guid Id, CarAddAndUpdateViewModel car)
	{
		await carService.UpdateUserCarAsync(Id, car);

		return RedirectToAction("All");
	}
}
