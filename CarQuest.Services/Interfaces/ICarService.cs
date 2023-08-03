namespace CarQuest.Services.Interfaces;

using Data.Models;

using Web.ViewModels.Car;

public interface ICarService
{
    Task<IEnumerable<CarAllViewModel>> AllUserCarsAsync(Guid userId);

    Task AddUserCarAsync(Guid userId, CarAddAndUpdateViewModel car);

    Task DeleteUserCarAsync(Guid carId);

    Task UpdateUserCarAsync(Guid carId, CarAddAndUpdateViewModel car);

    Task<Car> GetUserCarAsync(Guid carId);

    Task<CarAddAndUpdateViewModel> GetCarAddAndUpdateViewModelAsync(Guid carId);
}
