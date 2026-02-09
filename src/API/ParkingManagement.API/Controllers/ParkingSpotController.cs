using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Features.ParkingSpot.Requests.Commands;
using ParkingManagement.Application.Features.ParkingSpot.Requests.Queries;

namespace ParkingManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingSpotController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ParkingSpotController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllParkingSpots()
        {
            var request = new GetAllParkingSpotsRequest();
            var parkingSpots = await _mediator.Send(request);
            if(parkingSpots is null || parkingSpots.Count == 0)
            {
                return NoContent();
            }
            return Ok(parkingSpots);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParkingSpotById(int id)
        {
            var request = new GetParkingSpotByIdRequest { Id = id };
            var parkingSpot = await _mediator.Send(request);
            if (parkingSpot is null)
            {
                return NotFound();
            }
            return Ok(parkingSpot);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteParkingSpot([FromBody] DeleteParkingSpotDTO deleteParkingSpotDTO)
        {
            var request = new DeleteParkingSpotRequest { DeleteParkingSpotDTO = deleteParkingSpotDTO};
            await _mediator.Send(request);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateParkingSpot([FromBody] CreateParkingSpotDTO createParkingSpotDTO)
        {
            var request = new CreateParkingSpotRequest { CreateParkingSpotDTO = createParkingSpotDTO };
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateParkingSpot([FromBody] UpdateParkingSpotDTO updateParkingSpotDTO)
        {
            var request = new UpdateParkingSpotRequest { UpdateParkingSpotDTO = updateParkingSpotDTO };
            await _mediator.Send(request);
            return Ok();
        }
    }
}
