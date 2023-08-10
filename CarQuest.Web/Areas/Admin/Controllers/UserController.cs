namespace CarQuest.Web.Areas.Admin.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

using Services.Interfaces;

using ViewModels;

using Web.ViewModels.User;

using static Common.GeneralApplicationConstants;

public class UserController : BaseAdminController
{
	private readonly IUserService userService;
	private readonly IMemoryCache memoryCache;

	public UserController(IUserService userService, IMemoryCache memoryCache)
	{
		this.userService = userService;
		this.memoryCache = memoryCache;
	}

	[ResponseCache(Duration = 30)]
	public async Task<IActionResult> All()
	{
		IEnumerable<MechanicAllViewModel> mechanics =
			memoryCache.Get<IEnumerable<MechanicAllViewModel>>(MechanicsCacheKey);

		if (mechanics == null)
		{
			mechanics = await userService.GetAllMechanicsAsync();

			MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
				.SetAbsoluteExpiration(TimeSpan.FromMinutes(UsersCacheDurationMinutes));

			memoryCache.Set(MechanicsCacheKey, mechanics, cacheOptions);
		}

		IEnumerable<ApplicationUserAllViewModel> users =
			memoryCache.Get<IEnumerable<ApplicationUserAllViewModel>>(UsersCacheKey);

		if (users == null)
		{
			users = await userService.GetAllApplicationUsersAsync();

			MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
				.SetAbsoluteExpiration(TimeSpan.FromMinutes(UsersCacheDurationMinutes));

			memoryCache.Set(UsersCacheKey, users, cacheOptions);
		}

		UserAllViewModel model = new()
		{
			AllMechanics = mechanics,
			AllApplicationUsers = users
		};

		return View(model);
	}
}
