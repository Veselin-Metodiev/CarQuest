namespace CarQuest.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Services.Interfaces;

using ViewModels.Car;

using static Common.NotificationMessagesConstants;


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
			TempData[ErrorMessage] = "You must not be a mehcanic to access cars";
			return RedirectToAction("Index", "Home");
		}

		try
		{
			IEnumerable<CarAllViewModel> cars = await carService.AllUserCarsAsync(userId);

			return View(cars);
		}
		catch (Exception ex)
		{
			TempData[ErrorMessage] = ex.Message;
			return RedirectToAction("Index", "Home");
		}
	}

	[HttpGet]
	public async Task<IActionResult> Add()
	{
		if (await mechanicService.MechanicExistsByUserIdAsync(GetUserId()))
		{
			TempData[ErrorMessage] = "You must not be a mehcanic to add cars";
			return RedirectToAction("Index", "Home");
		}

		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Add(CarAddViewModel car)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must not be a mehcanic to add cars";
			return RedirectToAction("Index", "Home");
		}

		if (!ModelState.IsValid)
		{
			return View();
		}

		try
		{
			await carService.AddUserCarAsync(userId, car);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}

		return RedirectToAction("All");
	}

	public async Task<IActionResult> Remove(Guid Id)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must not be a mehcanic to remove cars";
			return RedirectToAction("Index", "Home");
		}

		try
		{
			await carService.DeleteUserCarAsync(Id);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}


		return RedirectToAction("All");
	}

	[HttpGet]
	public async Task<IActionResult> Edit(Guid Id)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must not be a mehcanic to edit cars";
			return RedirectToAction("Index", "Home");
		}

		try
		{
			CarUpdateViewModel car = await carService.GetCarAddAndUpdateViewModelAsync(Id);
			return View(car);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}
	}

	[HttpPost]
	public async Task<IActionResult> Edit(Guid Id, CarUpdateViewModel car)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = "You must not be a mehcanic to edit cars";
			return RedirectToAction("Index", "Home");
		}

		if (!ModelState.IsValid)
		{
			return View(car);
		}

		try
		{
			await carService.UpdateUserCarAsync(Id, car);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}


		return RedirectToAction("All");
	}
}
