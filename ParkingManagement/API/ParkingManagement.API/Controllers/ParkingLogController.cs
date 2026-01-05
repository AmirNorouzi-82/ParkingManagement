using Microsoft.AspNetCore.Mvc;

namespace ParkingManagement.API.ParkingManagement.API.Controllers
{
    public class ParkingLogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
