using MediatR;
using ParkingManagement.Application.DTOs;

namespace ParkingManagement.Application.Features.ParkingSpot.Requests.Commands
{
    public class CreateParkingSpotRequest : IRequest
    {
        public CreateParkingSpotDTO CreateParkingSpotDTO { get; set; }
    }
}