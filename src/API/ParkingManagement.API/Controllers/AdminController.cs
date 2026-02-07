using Microsoft.AspNetCore.Mvc;

namespace ParkingManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string? actionName)
        {
            if (string.IsNullOrWhiteSpace(actionName))
            {
                _logger.LogWarning("Missing actionName");
                return BadRequest();
            }

            _logger.LogInformation("Admin action executed");
            return Ok();
        }
    }
}
