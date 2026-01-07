using AutoMapper;
using MediatR;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Features.ParkingSpot.Requests.Queries;

namespace ParkingManagement.Application.Features.ParkingSpot.Handlers.Queries
{
    internal class GetParkingSpotByIdRequestHandler : IRequestHandler<GetParkingSpotByIdRequest, ParkingSpotDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetParkingSpotByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ParkingSpotDTO> Handle(GetParkingSpotByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ParkingSpotRepository.GetAsync(request.Id);
            if (entity == null) return null;

            return _mapper.Map<ParkingSpotDTO>(entity);
        }
    }
}