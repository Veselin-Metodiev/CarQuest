﻿namespace CarQuest.Web.Areas.Admin.Controllers;

using Microsoft.AspNetCore.Mvc;

public class HomeController : BaseAdminController
{
	public IActionResult Index()
	{
		return View();
	}
}
