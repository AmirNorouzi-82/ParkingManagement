using MediatR;
using ParkingManagement.Application.DTOs;

namespace ParkingManagement.Application.Features.ParkingSpot.Requests.Queries
{
    public class GetParkingSpotByIdRequest : IRequest<ParkingSpotDTO>
    {
        public int Id { get; set; }
    }
}