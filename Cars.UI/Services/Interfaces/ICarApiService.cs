using Cars.Application.Contracts.DTOs;

namespace Cars.UI.Services.Interfaces
{
    public interface ICarApiService
    {
        Task<List<CarGetDto>> GetAllCars();
        Task<CarGetDto> GetCarById(int id);
        Task<bool> AddCar(CarGetDto carCreate);
        Task<bool> UpdateCar(CarGetDto carUpdate);
        Task<bool> DeleteCar(int id);
        Task<BrandGetDto> GetBrandOfCar(int carId);
    }
}
