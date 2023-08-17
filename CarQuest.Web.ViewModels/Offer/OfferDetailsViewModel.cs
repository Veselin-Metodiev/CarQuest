﻿namespace CarQuest.Web.ViewModels.Offer;

using Data.Models;
using Services.Mapping;

public class OfferDetailsViewModel : IMapFrom<Offer>
{
	public Guid Id { get; set; }

	public string Title { get; set; } = null!;

	public string Description { get; set; } = null!;

	public TimeSpan EstimatedDuration { get; set; }

	public decimal Cost { get; set; }

	public bool HasUserAccepted { get; set; }
}
