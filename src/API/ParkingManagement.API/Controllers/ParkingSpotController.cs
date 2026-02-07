using Microsoft.AspNetCore.Mvc;

namespace ParkingManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingSpotController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "ParkingSpot endpoint is working" });
        }
    }
}
