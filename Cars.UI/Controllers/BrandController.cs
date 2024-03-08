using Cars.Application.Contracts.DTOs;
using Cars.Domain.Entities;
using Cars.UI.Models.ViewModels;
using Cars.UI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Cars.UI.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandApiService _brandApiService;
        public BrandController(IBrandApiService brandApiService)
        {
            _brandApiService = brandApiService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]   
        public async Task<IActionResult> GetAllBrands()
        {
			var brands = await _brandApiService.GetAllBrands();
            if(brands == null)
            {
                return NotFound("No brands found");
            }
			return View(brands);
		}
        public async Task<IActionResult> GetBrandById(int id)
        {
			var brand = await _brandApiService.GetBrandById(id);
            if (brand == null)
            {
				return NotFound("Brand with provided id donot exist or that id is deleted");
			}
			return View(brand);
		}
	

		[HttpGet]
        public async Task<IActionResult> AddBrand()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBrand(BrandGetDto brandCreate)
        {
			if (ModelState.IsValid)
            {
				try
                {
					bool isSuccess = await _brandApiService.AddBrand(brandCreate);

					if (isSuccess)
                    {
                        TempData["Success"] = "Brand added successfully";
						return RedirectToAction(nameof(GetAllBrands));
					}
					else
                    {
						ModelState.AddModelError(string.Empty, "Failed to Add brand, Please try again");
					}
				}
				catch (Exception ex)
                {
					ModelState.AddModelError(string.Empty,"An error occured"+ ex.Message);
				}
			}
			return View(brandCreate);
		}
        public async Task<IActionResult> GetListOfCarsByBrand(int id)
        {
            var cars = await _brandApiService.GetListOfCarsByBrand(id);
            if (cars == null)
            {
                return NotFound("No cars found for this brand");
            }
           var viewModel = cars.Select(car => new CarWithBrandVM
           {
                CarId = car.Id,
                CarModel = car.CarModel,
                Color = car.Color,
                TyreCount = car.TyreCount,
                 NumberPlate = car.NumberPlate,
                BrandId = car.BrandId,
            }).ToList();
            ViewData["Cars"] = viewModel;

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBrand(int id)
        {
            var brand = await _brandApiService.GetBrandById(id);
            if (brand == null)
            {
                return NotFound("Brand with provided id donot exist or that id is deleted");
            }
            return View(brand);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(BrandGetDto brand)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSuccess = await _brandApiService.UpdateBrand(brand);

                    if (isSuccess)
                    {
                        TempData["Success"] = "Brand updated successfully";
                        return RedirectToAction(nameof(GetAllBrands));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to update brand, Please try again");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occured" + ex.Message);
                }
            }
            return View(brand);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBrand(int id)
        {
			var brand = await _brandApiService.GetBrandById(id);
			if (brand == null)
            {
				return NotFound("Brand with provided id donot exist or that id is deleted");
			}
			return View(brand);
		}
        [HttpPost,ActionName("DeleteBrand")]
		public async Task<IActionResult> DeleteConfirmed( int id)
        { 
            bool isSuccess = await _brandApiService.DeleteBrand(id);
            if (isSuccess)
            {
                TempData["Success"] = "Brand deleted successfully";
				return RedirectToAction(nameof(GetAllBrands));
			}
			else
            {
				ModelState.AddModelError(string.Empty, "Failed to delete brand, Please try again");
				return RedirectToAction(nameof(DeleteBrand), new { id });
			}
        }
    }
}
