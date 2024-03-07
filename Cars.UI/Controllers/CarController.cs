using Microsoft.AspNetCore.Mvc;

namespace Cars.UI.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
