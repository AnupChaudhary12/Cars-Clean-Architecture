using Cars.Application.Contracts.DTOs;
using Cars.UI.Models;
using Cars.UI.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text.Json;

namespace Cars.UI.Services.Implementations
{
    public class BrandApiService : IBrandApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiUrlOptions _apiUrlOptions;
        private readonly ILogger<BrandApiService> _logger;
        public BrandApiService(HttpClient httpClient, IOptions<ApiUrlOptions> options,
                       ILogger<BrandApiService> logger)
        {
            _httpClient = httpClient;
            _apiUrlOptions = options.Value;
            _logger = logger;
        }
        public async Task<bool> AddBrand(BrandGetDto brandCreate)
        {
            try
            {
                string url = $"{_apiUrlOptions.BrandsUrl}AddBrand";
                var response = await _httpClient.PostAsJsonAsync(url, brandCreate);
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response Content: " + stringResponse);
                    return true;
                }
                else
                {
                    Console.WriteLine("HTTP Status Code: " + response.StatusCode);
                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error in AddBrand");
                Console.WriteLine("HTTP Request Exception: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in AddBrand");
                Console.WriteLine("Exception: " + ex.Message);
                return false;
            }
            
        }

        public async Task<bool> DeleteBrand(int id)
        {
            try
            {
                string url = $"{_apiUrlOptions.BrandsUrl}DeleteBrand/{id}";
                var response = await _httpClient.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response Content: " + stringResponse);
                    return true;
                }
                else
                {
                    Console.WriteLine("HTTP Status Code: " + response.StatusCode);
                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error in DeleteBrand");
                Console.WriteLine("HTTP Request Exception: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteBrand");
                Console.WriteLine("Exception: " + ex.Message);
                return false;
            }
        }

        public async Task<List<BrandGetDto>> GetAllBrands()
        {
            try
            {
                string url = $"{_apiUrlOptions.BrandsUrl}GetAllBrands";
                
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response Content: " + stringResponse);
                    var result = JsonConvert.DeserializeObject<List<BrandGetDto>>(stringResponse);
                    return result;
                }
                else
                {
                    Console.WriteLine("HTTP Status Code: " + response.StatusCode);
                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error in GetAllBrands");
                Console.WriteLine("HTTP Request Exception: " + ex.Message);
                return new List<BrandGetDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllBrands");
                Console.WriteLine("Exception: " + ex.Message);
                return new List<BrandGetDto>();
            }
        }

        public async Task<BrandGetDto> GetBrandById(int id)
        {
            try
            {
                string url = $"{_apiUrlOptions.BrandsUrl}GetBrandById/{id}";
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response Content: " + stringResponse);
                    var brand = JsonConvert.DeserializeObject<BrandGetDto>(stringResponse);
                    return brand;
                }
                else
                {
                    Console.WriteLine("HTTP Status Code: " + response.StatusCode);
                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error in GetBrandById");
                Console.WriteLine("HTTP Request Exception: " + ex.Message);
                return new BrandGetDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetBrandById");
                Console.WriteLine("Exception: " + ex.Message);
                return new BrandGetDto();
            }
        }

        public async Task<List<CarGetDto>> GetListOfCarsByBrand(int brandId)
        {
            try
            {
                string url = $"{_apiUrlOptions.BrandsUrl}GetCarsByBrandId/{brandId}";
                var result = new List<CarGetDto>();
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response Content: " + stringResponse);
                    result = JsonConvert.DeserializeObject<List<CarGetDto>>(stringResponse);
                    return result;
                }
                else
                {
                    Console.WriteLine("HTTP Status Code: " + response.StatusCode);
                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error in GetListOfCarsByBrand");
                Console.WriteLine("HTTP Request Exception: " + ex.Message);
                return new List<CarGetDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetListOfCarsByBrand");
                Console.WriteLine("Exception: " + ex.Message);
                return new List<CarGetDto>();
            }
        }

        public async Task<bool> UpdateBrand(BrandGetDto brandUpdate)
        {
            try
            {
                string url = $"{_apiUrlOptions.BrandsUrl}UpdateBrand";
                var response = await _httpClient.PutAsJsonAsync(url, brandUpdate);
                if(response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response Content: " + stringResponse);
                    return true;
                }
                else
                {
                    Console.WriteLine("HTTP Status Code: " + response.StatusCode);
                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error in UpdateBrand");
                Console.WriteLine("HTTP Request Exception: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateBrand");
                Console.WriteLine("Exception: " + ex.Message);
                return false;
            }
        }
    }
}
