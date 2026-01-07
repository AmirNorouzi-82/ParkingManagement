using MediatR;
using ParkingManagement.Application.DTOs;

namespace ParkingManagement.Application.Features.Vehicle.Requests.Commands
{
    public class UpdateVehicleRequest : IRequest
    {
        public UpdateVehicleDTO UpdateVehicleDTO { get; set; }
    }
}