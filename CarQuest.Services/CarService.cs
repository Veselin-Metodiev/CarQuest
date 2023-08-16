namespace CarQuest.Services;

using Data;
using Data.Models;

using Interfaces;

using Mapping;

using Microsoft.EntityFrameworkCore;

using Web.ViewModels.Car;


public class CarService : ICarService
{
	private readonly CarQuestDbContext context;

	public CarService(CarQuestDbContext context)
	{
		this.context = context;
	}

	public async Task<IEnumerable<CarAllViewModel>> MineCarsAsync(Guid userId)
	{
		IEnumerable<CarAllViewModel> cars = await context.Cars
			.Where(c => c.Owner.Id == userId)
			.Include(c => c.CarCategories)
			.ThenInclude(c => c.Category)
			.Select(c => AutoMapperConfig.MapperInstance.Map<CarAllViewModel>(c))
			.ToArrayAsync();

		return cars;
	}

	public async Task AddUserCarAsync(Guid userId, CarAddViewModel car)
	{
		Car carModel = AutoMapperConfig.MapperInstance.Map<Car>(car);
		carModel.OwnerId = userId;

		string[] categories = car.Categories.Split(", ");

		await CreateOrUpdateCategory(categories, carModel);

		await context.AddAsync(carModel);
		await context.SaveChangesAsync();
	}

	public async Task DeleteUserCarAsync(Guid carId)
	{
		Car car = await context.Cars
			.Include(c => c.Tickets)
			.Include(c => c.CarCategories)
			.FirstAsync(c => c.Id == carId);

		context.Tickets.RemoveRange(car.Tickets);
		context.CarsCategories.RemoveRange(car.CarCategories);

		context.Cars.Remove(car);
		await context.SaveChangesAsync();
	}

	public async Task UpdateUserCarAsync(Guid carId, CarUpdateViewModel car)
	{
		Car carDb = await GetUserCarAsync(carId);

		carDb.Model = car.Model;
		carDb.Brand = car.Brand;
		carDb.Mileage = car.Mileage.ToString();
		carDb.Year = car.Year.ToString();
		carDb.ImageUrl = car.ImageUrl;

		context.CarsCategories.RemoveRange(carDb.CarCategories);
		await context.SaveChangesAsync();

		string[] categories = car.Categories.Split(", ");

		await CreateOrUpdateCategory(categories, carDb);

		await context.SaveChangesAsync();
	}


	public async Task<CarUpdateViewModel> GetCarUpdateViewModelAsync(Guid carId)
	{
		Car car = await GetUserCarAsync(carId);

		CarUpdateViewModel carViewModel =
			AutoMapperConfig.MapperInstance.Map<CarUpdateViewModel>(car);

		return carViewModel;
	}

	public async Task<bool> isCarOwner(Guid userId, Guid carId)
	{
		Car? car = await context.Cars
			.FirstOrDefaultAsync(c => c.Id == carId);

		if (car != null)
		{
			return car.OwnerId == userId;
		}

		return false;
	}

	public async Task<IEnumerable<CarAllViewModel>> AllCarsAsync() =>
		await context.Cars
			.Include(c => c.CarCategories)
			.ThenInclude(c => c.Category)
			.Select(c => AutoMapperConfig.MapperInstance.Map<CarAllViewModel>(c))
			.ToArrayAsync();

	private async Task CreateOrUpdateCategory(string[] categories, Car car)
	{
		foreach (string categoryString in categories)
		{
			CarCategory carCategory = new()
			{
				Car = car
			};

			if (context.Categories.Any(c => c.Name == categoryString))
			{
				Category category = await context
					.Categories.FirstAsync(c => c.Name == categoryString);

				carCategory.Category = category;
				category.CategoryCars.Add(carCategory);
			}
			else
			{
				Category newCategory = new()
				{
					Name = categoryString
				};

				carCategory.Category = newCategory;
				newCategory.CategoryCars.Add(carCategory);

				await context.Categories.AddAsync(newCategory);
			}

			car.CarCategories.Add(carCategory);
		}
	}

	private async Task<Car> GetUserCarAsync(Guid carId)
	{
		Car car = await context.Cars
			.Include(c => c.CarCategories)
			.ThenInclude(c => c.Category)
			.FirstAsync(c => c.Id == carId);

		return car;
	}
}
