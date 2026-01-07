using MediatR;
using ParkingManagement.Application.DTOs;

namespace ParkingManagement.Application.Features.ParkingSpot.Requests.Commands
{
    public class DeleteParkingSpotRequest : IRequest
    {
        public DeleteParkingSpotDTO DeleteParkingSpotDTO { get; set; }
    }
}