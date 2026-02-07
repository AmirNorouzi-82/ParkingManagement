using Microsoft.AspNetCore.Mvc;

namespace ParkingManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingStatusController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "ParkingStatus endpoint is working" });
        }
    }
}
