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
            .Select(c => AutoMapperConfig.MapperInstance.Map<CarAllViewModel>(c))
            .ToArrayAsync();

        return cars;
    }

    public async Task AddUserCarAsync(Guid userId, CarAddViewModel car)
    {
	    Car carModel = AutoMapperConfig.MapperInstance.Map<Car>(car);
        carModel.OwnerId = userId;

	    await context.AddAsync(carModel);
	    await context.SaveChangesAsync();
    }

    public async Task DeleteUserCarAsync(Guid carId)
    {
	    Car car = await context.Cars
		    .Include(c => c.Tickets)
		    .FirstAsync(c => c.Id == carId);

	    context.Tickets.RemoveRange(car.Tickets);

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

        await context.SaveChangesAsync();
    }

    private async Task<Car> GetUserCarAsync(Guid carId)
    {
	    Car car = await context.Cars
		    .FirstAsync(c => c.Id == carId);

        return car;
    }

    public async Task<CarUpdateViewModel> GetCarAddAndUpdateViewModelAsync(Guid carId)
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
		    .Select(c => AutoMapperConfig.MapperInstance.Map<CarAllViewModel>(c))
		    .ToArrayAsync();
}
