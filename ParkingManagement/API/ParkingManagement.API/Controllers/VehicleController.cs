using Microsoft.AspNetCore.Mvc;

namespace ParkingManagement.API.ParkingManagement.API.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
