﻿namespace CarQuest.Web.Controllers;

using Microsoft.AspNetCore.Mvc;

using Services.Interfaces;

using ViewModels.Offer;

using static Common.NotificationMessagesConstants;

public class OfferController : BaseController
{
	private readonly IMechanicService mechanicService;
	private readonly IOfferService offerService;

	public OfferController(IMechanicService mechanicService, IOfferService offerService)
	{
		this.mechanicService = mechanicService;
		this.offerService = offerService;
	}

	[HttpGet]
	public async Task<IActionResult> Add(Guid Id)
	{
		Guid userId = GetUserId();

		if (!await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = MustBeMechanicError;
			return RedirectToAction("Index", "Home");
		}

		OfferAddViewModel offerModel = new()
		{
			TicketId = Id
		};

		return View(offerModel);
	}

	[HttpPost]
	public async Task<IActionResult> Add(OfferAddViewModel offerModel)
	{
		Guid userId = GetUserId();

		if (!await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = MustBeMechanicError;
			return RedirectToAction("Index", "Home");
		}

		if (!ModelState.IsValid)
		{
			return View(offerModel);
		}

		try
		{
			await offerService.AddOfferToTicketAsync(offerModel);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}

		return RedirectToAction("Mine", "TicketMechanic");
	}

	public async Task<IActionResult> Details(Guid id)
	{
		Guid userId = GetUserId();

		if (!await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = MustBeMechanicError;
			return RedirectToAction("Index", "Home");
		}

		try
		{
			OfferDetailsViewModel? offerModel = await offerService.GetOfferDetailsViewModel(id);
			return View(offerModel);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}
	}

	[HttpGet]
	public async Task<IActionResult> Edit(Guid id)
	{
		Guid userId = GetUserId();

		if (!await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = MustBeMechanicError;
			return RedirectToAction("Index", "Home");
		}

		try
		{
			OfferEditViewModel? offerModel = await offerService.GetOfferEditViewModel(id);

			return View(offerModel);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}
		
	}

	[HttpPost]
	public async Task<IActionResult> Edit(OfferEditViewModel offerModel)
	{
		Guid userId = GetUserId();

		if (!await mechanicService.MechanicExistsByUserIdAsync(userId))
		{
			TempData[ErrorMessage] = MustBeMechanicError;
			return RedirectToAction("Index", "Home");
		}

		if (!ModelState.IsValid)
		{
			return View();
		}

		try
		{
			await offerService.UpdateOfferAsync(offerModel);
		}
		catch (Exception e)
		{
			TempData[ErrorMessage] = e.Message;
			return RedirectToAction("Index", "Home");
		}

		return RedirectToAction("Mine", "TicketMechanic");
	}
}
