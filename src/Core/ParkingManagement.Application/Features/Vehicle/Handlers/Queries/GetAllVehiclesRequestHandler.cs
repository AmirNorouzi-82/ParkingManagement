using AutoMapper;
using MediatR;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Features.Vehicle.Requests.Queries;
using System.Collections.Generic;

namespace ParkingManagement.Application.Features.Vehicle.Handlers.Queries
{
    internal class GetAllVehiclesRequestHandler : IRequestHandler<GetAllVehiclesRequest, List<VehicleDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllVehiclesRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<VehicleDTO>> Handle(GetAllVehiclesRequest request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.VehicleRepository.GetAllAsync();
            return _mapper.Map<List<VehicleDTO>>(entities);
        }
    }
}