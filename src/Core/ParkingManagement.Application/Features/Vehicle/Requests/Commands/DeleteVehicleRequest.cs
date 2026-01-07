using MediatR;
using ParkingManagement.Application.DTOs;

namespace ParkingManagement.Application.Features.Vehicle.Requests.Commands
{
    public class DeleteVehicleRequest : IRequest
    {
        public DeleteVehicleDTO DeleteVehicleDTO { get; set; }
    }
}