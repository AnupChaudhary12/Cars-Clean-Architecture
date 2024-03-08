using Cars.Application.Contracts.DTOs;

namespace Cars.UI.Services.Interfaces
{
    public interface IBrandApiService
    {
        Task<List<BrandGetDto>> GetAllBrands();
        Task<BrandGetDto> GetBrandById(int id);
        Task<bool> AddBrand(BrandGetDto brandCreate);
        Task<bool> UpdateBrand(BrandGetDto brandUpdate);
        Task<bool> DeleteBrand(int id);
        Task<List<CarGetDto>> GetListOfCarsByBrand(int brandId);
    }
}
