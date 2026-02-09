using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Application.Features.ParkingSpot.Requests.Queries;

namespace ParkingManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingStatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParkingStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAvailableSpots")]
        public async Task<IActionResult> GetAvailableSpots()
        {
            var request = new GetAllParkingSpotsRequest();
            var spots = await _mediator.Send(request);
            var availableSpots = spots.Where(x => x.IsAvailable).ToList();
            return Ok(availableSpots);
        }
        [HttpGet("GetOccupiedSpots")]
        public async Task<IActionResult> GetOccupiedSpots()
        {
            var request = new GetAllParkingSpotsRequest();
            var spots = await _mediator.Send(request);
            var occupiedSpots = spots.Where(x=>x.IsReserved).ToList();
            return Ok(occupiedSpots);
        }
    }
}
