using MediatR;
using ParkingManagement.Application.DTOs;

namespace ParkingManagement.Application.Features.ParkingSpot.Requests.Commands
{
    public class UpdateParkingSpotRequest : IRequest
    {
        public UpdateParkingSpotDTO UpdateParkingSpotDTO { get; set; }
    }
}