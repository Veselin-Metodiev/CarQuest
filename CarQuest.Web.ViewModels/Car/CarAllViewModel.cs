namespace CarQuest.Web.ViewModels.Car;

using Data.Models;
using Services.Mapping;

public class CarAllViewModel : IMapFrom<Car>
{
	public Guid Id { get; set; }

	public string Brand { get; set; } = null!;

	public string Model { get; set; } = null!;

	public string Year { get; set; } = null!;

	public string Mileage { get; set; } = null!;
}
