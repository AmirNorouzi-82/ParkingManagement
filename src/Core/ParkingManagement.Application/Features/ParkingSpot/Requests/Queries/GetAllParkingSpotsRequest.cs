using MediatR;
using ParkingManagement.Application.DTOs;
using System.Collections.Generic;

namespace ParkingManagement.Application.Features.ParkingSpot.Requests.Queries
{
    public class GetAllParkingSpotsRequest : IRequest<List<ParkingSpotDTO>>
    {
    }
}