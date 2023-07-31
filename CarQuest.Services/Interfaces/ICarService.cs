namespace CarQuest.Services.Interfaces;

using Common;
using Data.Models;
using Web.ViewModels.Car;

public interface ICarService
{
    Task<IEnumerable<Car>> AllUserCarsAsync(Guid userId);

    Task AddUserCarAsync(Guid userId, CarAddAndUpdateViewModel car);

    Task DeleteUserCarAsync(Guid carId);

    Task UpdateUserCarAsync(Guid carId, CarAddAndUpdateViewModel car);

    Task<Car> GetUserCar(Guid carId);
}
