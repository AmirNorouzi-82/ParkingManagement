using Microsoft.AspNetCore.Mvc;

namespace ParkingManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingLogController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "ParkingLog endpoint is working" });
        }
    }
}
