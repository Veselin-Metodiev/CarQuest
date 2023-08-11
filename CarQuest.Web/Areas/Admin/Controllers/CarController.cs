namespace CarQuest.Web.Areas.Admin.Controllers;

using Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Services.Interfaces;
using Web.ViewModels.Car;

using static Common.GeneralApplicationConstants;

public class CarController : BaseAdminController
{
	private readonly ICarService carService;
	private readonly IMemoryCache memoryCache;

	public CarController(ICarService carService, IMemoryCache memoryCache)
	{
		this.carService = carService;
		this.memoryCache = memoryCache;
	}

	[ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client, NoStore = false)]
	public async Task<IActionResult> All()
	{
		IEnumerable<CarAllViewModel> cars =
			memoryCache.Get<IEnumerable<CarAllViewModel>>(CarCacheKey);

		if (cars == null)
		{
			cars = await carService.AllCarsAsync();

			MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions()
				.SetAbsoluteExpiration(TimeSpan.FromMinutes(CarsCacheDurationMinutes));

			memoryCache.Set(CarCacheKey, cars, cacheEntryOptions);
		}

		return View(cars);
	}
}
