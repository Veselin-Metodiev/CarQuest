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

    public async Task<IEnumerable<Car>> AllUserCarsAsync(Guid userId)
    {
        IEnumerable<Car> cars = await context.Cars
            .Where(c => c.Owner.Id == userId)
            .ToArrayAsync();

        return cars;
    }

    public async Task AddUserCarAsync(Guid userId, CarAddAndUpdateViewModel car)
    {
	    Car carModel = AutoMapperConfig.MapperInstance.Map<Car>(car);
        carModel.OwnerId = userId;

	    await context.AddAsync(carModel);
	    await context.SaveChangesAsync();
    }

    public async Task DeleteUserCarAsync(Guid carId)
    {
	    Car car = await context.Cars
		    .FirstAsync(c => c.Id == carId);

	    context.Remove(car);
        await context.SaveChangesAsync();
    }

    public async Task UpdateUserCarAsync(Guid carId, CarAddAndUpdateViewModel car)
    {
	    Car carDb = await GetUserCar(carId);

	    carDb.Model = car.Model;
        carDb.Brand = car.Brand;
        carDb.Mileage = car.Mileage.ToString();
        carDb.Year = car.Year.ToString();

        await context.SaveChangesAsync();
    }

    public async Task<Car> GetUserCar(Guid carId)
    {
	    Car car = await context.Cars
		    .FirstAsync(c => c.Id == carId);

        return car;
    }
}
