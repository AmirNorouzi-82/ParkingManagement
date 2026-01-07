using MediatR;
using ParkingManagement.Application.DTOs;

namespace ParkingManagement.Application.Features.Vehicle.Requests.Commands
{
    public class CreateVehicleRequest : IRequest
    {
        public CreateVehicleDTO CreateVehicleDTO { get; set; }
    }
}