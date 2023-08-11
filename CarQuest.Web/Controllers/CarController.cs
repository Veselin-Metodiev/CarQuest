namespace CarQuest.Web.Controllers;

using Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Services.Interfaces;

using ViewModels.Car;

using static Common.NotificationMessagesConstants;
using static Common.GeneralApplicationConstants;

[Authorize]
public class CarController : BaseController
{
	private readonly ICarService carService;
	private readonly IMechanicService mechanicService;
	private readonly IMemoryCache memoryCache;

	public CarController(ICarService carService, IMechanicService mechanicService, IMemoryCache memoryCache)
	{
		this.carService = carService;
		this.mechanicService = mechanicService;
		this.memoryCache = memoryCache;
	}

	public async Task<IActionResult> Mine()
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId) &&
		    !User.IsAdmin())
		{
			TempData[ErrorMessage] = "You must not be a mehcanic to access cars";
			return RedirectToAction("Index", "Home");
		}

		try
		{
			IEnumerable<CarAllViewModel> cars = await carService.MineCarsAsync(userId);

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
		if (await mechanicService.MechanicExistsByUserIdAsync(GetUserId()) &&
		    !User.IsAdmin())
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

		if (await mechanicService.MechanicExistsByUserIdAsync(userId) &&
		    !User.IsAdmin())
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

		memoryCache.Remove(CarCacheKey);

		return RedirectToAction("Mine");
	}

	public async Task<IActionResult> Remove(Guid id)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId) &&
		    !User.IsAdmin())
		{
			TempData[ErrorMessage] = "You must not be a mehcanic to remove cars";
			return RedirectToAction("Index", "Home");
		}

		if (!await carService.isCarOwner(userId, id) &&
		    !User.IsAdmin())
		{
			TempData[ErrorMessage] = "You must not be a the owner to remove this car";
			return RedirectToAction("Index", "Home");
		}

		try
		{
			await carService.DeleteUserCarAsync(id);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}

		memoryCache.Remove(CarCacheKey);

		return RedirectToAction("Mine");
	}

	[HttpGet]
	public async Task<IActionResult> Edit(Guid id)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId) &&
		    !User.IsAdmin())
		{
			TempData[ErrorMessage] = "You must not be a mehcanic to edit cars";
			return RedirectToAction("Index", "Home");
		}

		if (!await carService.isCarOwner(userId, id) &&
		    !User.IsAdmin())
		{
			TempData[ErrorMessage] = "You must not be a the owner to edit this car";
			return RedirectToAction("Index", "Home");
		}

		try
		{
			CarUpdateViewModel car = await carService.GetCarUpdateViewModelAsync(id);
			return View(car);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}
	}

	[HttpPost]
	public async Task<IActionResult> Edit(Guid id, CarUpdateViewModel car)
	{
		Guid userId = GetUserId();

		if (await mechanicService.MechanicExistsByUserIdAsync(userId) &&
		    !User.IsAdmin())
		{
			TempData[ErrorMessage] = "You must not be a mehcanic to edit cars";
			return RedirectToAction("Index", "Home");
		}

		if (!await carService.isCarOwner(userId, id) &&
		    !User.IsAdmin())
		{
			TempData[ErrorMessage] = "You must not be a the owner to edit this car";
			return RedirectToAction("Index", "Home");
		}

		if (!ModelState.IsValid)
		{
			return View(car);
		}

		try
		{
			await carService.UpdateUserCarAsync(id, car);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}

		memoryCache.Remove(CarCacheKey);

		return RedirectToAction("Mine");
	}
}
