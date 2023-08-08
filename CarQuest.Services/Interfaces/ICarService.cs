namespace CarQuest.Services.Interfaces;

using Web.ViewModels.Car;

public interface ICarService
{
    Task<IEnumerable<CarAllViewModel>> AllUserCarsAsync(Guid userId);

    Task AddUserCarAsync(Guid userId, CarAddViewModel car);

    Task DeleteUserCarAsync(Guid carId);

    Task UpdateUserCarAsync(Guid carId, CarUpdateViewModel car);

    Task<CarUpdateViewModel> GetCarAddAndUpdateViewModelAsync(Guid carId);
}
