﻿namespace CarQuest.Web.ViewModels.Car;

using System.ComponentModel.DataAnnotations;

using AutoMapper;

using Common;

using Data.Models;

using Services.Mapping;

using static Common.EntityValidationConstants.CarViewModel;


public class CarAddViewModel : IMapTo<Car>, IHaveCustomMappings
{
	[Required]
	[StringLength(BrandMaxLength, MinimumLength = BrandMinLength)]
	public string Brand { get; set; } = null!;

	[Required]
	[StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
	public string Model { get; set; } = null!;

	[Required]
	[YearRange(1900)]
	public int Year { get; set; }

	[Required]
	[Range(MileageMinValue, MileageMaxValue)]
	public long Mileage { get; set; }

	public void CreateMappings(IProfileExpression configuration)
	{
		configuration.CreateMap<CarAddViewModel, Car>()
			.ForMember(d => d.Year, opt => opt
				.MapFrom(s => s.Year.ToString()))
			.ForMember(d => d.Mileage, opt => opt
				.MapFrom(s => s.Mileage.ToString()));
	}
}
