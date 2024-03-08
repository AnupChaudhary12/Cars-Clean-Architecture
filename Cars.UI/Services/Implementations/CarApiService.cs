using Cars.Application.Contracts.DTOs;
using Cars.UI.Models;
using Cars.UI.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Cars.UI.Services.Implementations
{
	public class CarApiService : ICarApiService
	{
		private readonly HttpClient _httpClient;
		private readonly ApiUrlOptions _apiUrlOptions;
		private readonly ILogger<CarApiService> _logger;
        public CarApiService(HttpClient httpClient,IOptions<ApiUrlOptions>options,ILogger<CarApiService> logger)
        {
            _httpClient = httpClient;
			_apiUrlOptions = options.Value;
			_logger = logger;
        }
        public async Task<bool> AddCar(CarGetDto carCreate)
		{
			try
			{
				string url = $"{_apiUrlOptions.CarsUrl}AddCar";
				var response = await _httpClient.PostAsJsonAsync(url, carCreate);
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
				_logger.LogError(ex, "Error in AddCar");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return false;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error in AddCar");
				Console.WriteLine("Exception: " + ex.Message);
				return false;
			}
		}

		public async Task<bool> DeleteCar(int id)
		{
			try
			{
				string url = $"{_apiUrlOptions.CarsUrl}DeleteCar/{id}";
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
				_logger.LogError(ex, "Error in DeleteCar");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return false;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error in DeleteCar");
				Console.WriteLine("Exception: " + ex.Message);
				return false;
			}
		}


		public async Task<List<CarGetDto>> GetAllCars()
		{
			try
			{
				string url = $"{_apiUrlOptions.CarsUrl}GetAllCars";
				var response = await _httpClient.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					var stringResponse = await response.Content.ReadAsStringAsync();
					var result = JsonConvert.DeserializeObject<List<CarGetDto>>(stringResponse);
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
				_logger.LogError(ex, "Error in GetAllCars");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error in GetAllCars");
				Console.WriteLine("Exception: " + ex.Message);
				return null;
			}

		}

		public async Task<BrandGetDto> GetBrandOfCar(int carId)
		{
			try
			{
				string url = $"{_apiUrlOptions.CarsUrl}GetBrandByCarId/{carId}";
				var response = await _httpClient.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					var stringResponse = await response.Content.ReadAsStringAsync();
					var result = JsonConvert.DeserializeObject<BrandGetDto>(stringResponse);
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
				_logger.LogError(ex, "Error in GetBrandOfCar");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error in GetBrandOfCar");
				Console.WriteLine("Exception: " + ex.Message);
				return null;
			}
		}

		public async Task<CarGetDto> GetCarById(int id)
		{
			try
			{
				string url = $"{_apiUrlOptions.CarsUrl}GetCarById/{id}";
				var response = await _httpClient.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					var stringResponse = await response.Content.ReadAsStringAsync();
					var result = JsonConvert.DeserializeObject<CarGetDto>(stringResponse);
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
				_logger.LogError(ex, "Error in GetCarById");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error in GetCarById");
				Console.WriteLine("Exception: " + ex.Message);
				return null;
			}
		}

		public async Task<bool> UpdateCar(CarGetDto carUpdate)
		{
			try
			{
				string url = $"{_apiUrlOptions.CarsUrl}UpdateCar";
				var response = await _httpClient.PutAsJsonAsync(url, carUpdate);
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
				_logger.LogError(ex, "Error in UpdateCar");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return false;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error in UpdateCar");
				Console.WriteLine("Exception: " + ex.Message);
				return false;
			}
		}
	}
}
