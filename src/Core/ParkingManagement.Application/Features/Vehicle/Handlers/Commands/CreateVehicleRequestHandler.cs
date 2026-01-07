using AutoMapper;
using MediatR;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.Features.Vehicle.Requests.Commands;
using ParkingManagement.Domain;

namespace ParkingManagement.Application.Features.Vehicle.Handlers.Commands
{
    internal class CreateVehicleRequestHandler : IRequestHandler<CreateVehicleRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateVehicleRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(CreateVehicleRequest request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.VehicleRepository;
            var vehicle = _mapper.Map<ParkingManagement.Domain.Vehicle>(request.CreateVehicleDTO);

            await repository.AddAsync(vehicle);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}