﻿	namespace CarQuest.Web.Controllers;

using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using ViewModels.Home;

using static Common.GeneralApplicationConstants;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
	    if (User.IsInRole(AdminRoleName))
	    {
		    return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
	    }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
