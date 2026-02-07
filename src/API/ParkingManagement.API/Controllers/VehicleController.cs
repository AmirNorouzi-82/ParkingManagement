using Microsoft.AspNetCore.Mvc;

namespace ParkingManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "Vehicle endpoint is working" });
        }
    }
}
