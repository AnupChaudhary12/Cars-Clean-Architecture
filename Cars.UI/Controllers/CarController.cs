using Cars.Application.Contracts.DTOs;
using Cars.UI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cars.UI.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarApiService _carApiService;
        private readonly IBrandApiService _brandApiService;
        public CarController(ICarApiService carApiService, IBrandApiService brandApiService)
        {
            _carApiService = carApiService;
            _brandApiService = brandApiService;
        }
        [HttpGet]
        public async Task<IActionResult> AddCar()
        {
            if (ViewBag.Brands == null)
            {
                ViewBag.Brands = await _brandApiService.GetAllBrands();
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCar(CarGetDto carCreate)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    bool isSuccess = await _carApiService.AddCar(carCreate);
                    if (isSuccess)
                    {
                        TempData["Success"] = "Car added successfully";
                        return RedirectToAction(nameof(GetAllCars));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to Add Car, Please try again");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occured" + ex.Message);
                }
            }
            return View(carCreate);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carApiService.GetAllCars();
            if (cars == null)
            {
                return NotFound("No cars found");
            }
            return View(cars);
        }


        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _carApiService.GetCarById(id);
            if (car == null)
            {
                return NotFound("Car with provided id donot exist or that id is deleted");
            }
            return View(car);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _carApiService.GetCarById(id);
            if (car == null)
            {
                return NotFound("Car with provided id donot exist or that id is deleted");
            }
            return View(car);
        }
        [HttpPost, ActionName("DeleteCar")]
        public async Task<IActionResult> DeleteConfirmed(int id, CarGetDto car)
        {
            bool isSuccess = await _carApiService.DeleteCar(id);
            if (isSuccess)
            {
                TempData["Success"] = "Car deleted successfully";
                return RedirectToAction(nameof(GetAllCars));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete Car, Please try again");
                return RedirectToAction(nameof(DeleteCar), new { id });
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var carToUpdate = await _carApiService.GetCarById(id);
            if (carToUpdate == null)
            {
                return NotFound("Car with provided id donot exist or that id is deleted");
            }
            if (ViewBag.Brands == null)
            {
                ViewBag.Brands = await _brandApiService.GetAllBrands();
            }
            return View(carToUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(CarGetDto carUpdate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isSuccess = await _carApiService.UpdateCar(carUpdate);
                    if (isSuccess)
                    {
                        TempData["Success"] = "Car updated successfully";
                        return RedirectToAction(nameof(GetAllCars));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to update Car, Please try again");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occured" + ex.Message);
                }
            }
            return View(carUpdate);
        }
        public async Task<IActionResult> GetBrandOfCar(int id)
        {
            var brand = await _carApiService.GetBrandOfCar(id);
            if (brand == null)
            {
                return NotFound("Brand with provided id donot exist or that id is deleted");
            }
            return View(brand);
        }
    }
}


