using Microsoft.AspNetCore.Mvc;

namespace Cars.UI.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
