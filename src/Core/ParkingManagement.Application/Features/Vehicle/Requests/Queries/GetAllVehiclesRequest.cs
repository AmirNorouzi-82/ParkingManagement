using MediatR;
using ParkingManagement.Application.DTOs;
using System.Collections.Generic;

namespace ParkingManagement.Application.Features.Vehicle.Requests.Queries
{
    public class GetAllVehiclesRequest : IRequest<List<VehicleDTO>>
    {
    }
}