using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Application.Features.Vehicle.Requests.Queries;
using ParkingManagement.Application.Features.Vehicle.Requests.Commands;
using ParkingManagement.Application.DTOs;

namespace ParkingManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllVehiclesRequest();
            var vehicles = await _mediator.Send(request);
            if (vehicles is null || vehicles.Count == 0)
            {
                return NoContent();
            }
            return Ok(vehicles);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(int Id)
        {
            var request = new GetVehicleByIdRequest { Id = Id };
            var vehicle = await _mediator.Send(request);
            if (vehicle is null)
            {
                return NoContent();
            }
            return Ok(vehicle);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteVehicle([FromBody] DeleteVehicleDTO deleteVehicleDTO)
        {
            var request = new DeleteVehicleRequest { DeleteVehicleDTO = deleteVehicleDTO };
            await _mediator.Send(request);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleDTO createVehicleDTO)
        {
            var request = new CreateVehicleRequest { CreateVehicleDTO = createVehicleDTO };
            await _mediator.Send(request);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateVehicle([FromBody] UpdateVehicleDTO updateVehicleDTO)
        {
            var request = new UpdateVehicleRequest { UpdateVehicleDTO = updateVehicleDTO };
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
