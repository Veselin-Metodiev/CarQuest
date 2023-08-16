namespace CarQuest.Web.ViewModels.Car;

using AutoMapper;
using Data.Models;
using Services.Mapping;

public class CarAllViewModel : IMapFrom<Car>, IHaveCustomMappings
{
	public Guid Id { get; set; }

	public string Brand { get; set; } = null!;

	public string Model { get; set; } = null!;

	public string Year { get; set; } = null!;

	public string Mileage { get; set; } = null!;

	public string ImageUrl { get; set; } = null!;

	public string Categories { get; set; } = null!;

	public void CreateMappings(IProfileExpression configuration)
	{
		configuration.CreateMap<Car, CarAllViewModel>()
			.ForMember(m => m.Categories, opt => opt
				.MapFrom(s => string.Join(", ", s.CarCategories
					.Select(c => c.Category.Name)
					.ToArray())));
	}
}
