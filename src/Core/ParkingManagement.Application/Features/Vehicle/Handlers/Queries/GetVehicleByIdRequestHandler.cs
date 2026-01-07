using AutoMapper;
using MediatR;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Features.Vehicle.Requests.Queries;

namespace ParkingManagement.Application.Features.Vehicle.Handlers.Queries
{
    internal class GetVehicleByIdRequestHandler : IRequestHandler<GetVehicleByIdRequest, VehicleDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetVehicleByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<VehicleDTO> Handle(GetVehicleByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.VehicleRepository.GetAsync(request.Id);
            if (entity == null) return null;

            return _mapper.Map<VehicleDTO>(entity);
        }
    }
}