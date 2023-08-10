namespace CarQuest.Services.Interfaces;

using Web.ViewModels.Car;

public interface ICarService
{
    Task<IEnumerable<CarAllViewModel>> MineCarsAsync(Guid userId);

    Task AddUserCarAsync(Guid userId, CarAddViewModel car);

    Task DeleteUserCarAsync(Guid carId);

    Task UpdateUserCarAsync(Guid carId, CarUpdateViewModel car);

    Task<CarUpdateViewModel> GetCarAddAndUpdateViewModelAsync(Guid carId);

    Task<bool> isCarOwner(Guid userId, Guid carId);

    Task<IEnumerable<CarAllViewModel>> AllCarsAsync();
}
