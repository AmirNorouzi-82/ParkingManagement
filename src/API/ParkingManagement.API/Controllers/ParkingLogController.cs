using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Features.ParkingLog.Requests.Commands;
using ParkingManagement.Application.Features.ParkingLog.Requests.Queries;

namespace ParkingManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingLogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParkingLogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLogs()
        {
            var request = new GetAllParkingLogsRequest();
            var logs = await _mediator.Send(request);
            return Ok(logs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogById(int id)
        {
            var request = new GetParkingLogByIdRequest { Id = id };
            var log = await _mediator.Send(request);
            if (log == null)
            {
                return NotFound();
            }
            return Ok(log);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteLog([FromBody] DeleteParkingLogDTO parkingLogDTO)
        {
            var request = new DeleteParkingLogRequest { DeleteParkingLogDTO = parkingLogDTO };
            await _mediator.Send(request);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLog([FromBody] CreateParkingLogDTO parkingLogDTO)
        {
            var request = new CreateParkingLogRequest { CreateParkingLogDTO = parkingLogDTO };
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateLog([FromBody] UpdateParkingLogDTO parkingLogDTO)
        {
            var request = new UpdateParkingLogRequest { UpdateParkingLogDTO = parkingLogDTO };
            await _mediator.Send(request);
            return Ok();
        }
    }
}
