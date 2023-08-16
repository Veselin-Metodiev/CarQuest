namespace CarQuest.Web.ViewModels.Car;

using System;
using System.ComponentModel.DataAnnotations;

using AutoMapper;

using Common;

using Data.Models;

using Services.Mapping;

using static Common.EntityValidationConstants.CarViewModel;


public class CarUpdateViewModel : IMapFrom<Car>, IHaveCustomMappings
{
	public Guid Id { get; set; }

	[Required]
	[StringLength(BrandMaxLength, MinimumLength = BrandMinLength)]
	public string Brand { get; set; } = null!;

	[Required]
	[StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
	public string Model { get; set; } = null!;

	[Required]
	[YearRange(YearMinValue)]
	public int Year { get; set; }

	[Required]
	[Range(MileageMinValue, MileageMaxValue)]
	public long Mileage { get; set; }

	[Required]
	[StringLength(CarImageUrlMaxLength, MinimumLength = CarImageUrlMinLength)]
	public string ImageUrl { get; set; } = null!;

	[Required]
	[StringLength(CategoriesMaxLength, MinimumLength = CategoriesMinLength)]
	public string Categories { get; set; } = null!;

	public void CreateMappings(IProfileExpression configuration)
	{
		configuration.CreateMap<Car, CarUpdateViewModel>()
			.ForMember(d => d.Year, opt => opt
				.MapFrom(s => int.Parse(s.Year)))
			.ForMember(d => d.Mileage, opt => opt
				.MapFrom(s => long.Parse(s.Mileage)))
			.ForMember(m => m.Categories, opt => opt
				.MapFrom(s => string.Join(", ", s.CarCategories
					.Select(c => c.Category.Name)
					.ToArray())));
	}
}
