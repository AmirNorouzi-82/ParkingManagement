using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Features.Admin.Requests.Commands;
using ParkingManagement.Application.Features.Admin.Requests.Queries;
using ParkingManagement.Domain;

namespace ParkingManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IMediator _mediator;

        public AdminController(ILogger<AdminController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdmins()
        {
            var request = new GetAllAdminsRequest();
            var admins = await _mediator.Send(request);
            if (admins == null)
            {
                return NotFound();
            }
            return Ok(admins);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdminById(int id)
        {
            var request = new GetAdminByIdRequest();
            var admin = await _mediator.Send(request);
            if(admin == null)
            {
                return NotFound(); 
            }
            return Ok(admin);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminDTO createAdminDTO)
        {
            var request = new CreateAdminRequest();
            await _mediator.Send(request);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAdmin([FromBody] DeleteAdminDTO deleteAdminDTO)
        {
            var request = new DeleteAdminRequest();
            await _mediator.Send(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAdmin([FromBody] UpdateAdminDTO updateAdminDTO)
        {
            var request = new UpdateAdminRequest();
            await _mediator.Send(request);
            return Ok();
        }
    }
}
