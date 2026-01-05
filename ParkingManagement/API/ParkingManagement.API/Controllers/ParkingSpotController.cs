using Microsoft.AspNetCore.Mvc;

namespace ParkingManagement.API.ParkingManagement.API.Controllers
{
    public class ParkingSpotController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
