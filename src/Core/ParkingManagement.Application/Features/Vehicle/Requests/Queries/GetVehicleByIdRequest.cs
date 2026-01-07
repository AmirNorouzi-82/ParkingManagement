using MediatR;
using ParkingManagement.Application.DTOs;

namespace ParkingManagement.Application.Features.Vehicle.Requests.Queries
{
    public class GetVehicleByIdRequest : IRequest<VehicleDTO>
    {
        public int Id { get; set; }
    }
}