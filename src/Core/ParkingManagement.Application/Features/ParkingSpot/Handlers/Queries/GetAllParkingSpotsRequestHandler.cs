using AutoMapper;
using MediatR;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Features.ParkingSpot.Requests.Queries;
using System.Collections.Generic;

namespace ParkingManagement.Application.Features.ParkingSpot.Handlers.Queries
{
    internal class GetAllParkingSpotsRequestHandler : IRequestHandler<GetAllParkingSpotsRequest, List<ParkingSpotDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllParkingSpotsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ParkingSpotDTO>> Handle(GetAllParkingSpotsRequest request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.ParkingSpotRepository.GetAllAsync();
            return _mapper.Map<List<ParkingSpotDTO>>(entities);
        }
    }
}