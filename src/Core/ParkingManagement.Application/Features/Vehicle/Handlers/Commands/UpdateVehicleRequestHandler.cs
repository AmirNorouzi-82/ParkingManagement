using AutoMapper;
using MediatR;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.Features.Vehicle.Requests.Commands;

namespace ParkingManagement.Application.Features.Vehicle.Handlers.Commands
{
    internal class UpdateVehicleRequestHandler : IRequestHandler<UpdateVehicleRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateVehicleRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateVehicleRequest request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.VehicleRepository;
            var dto = request.UpdateVehicleDTO;

            var entity = await repo.GetAsync(dto.Id);
            if (entity == null) return;

            if (dto.Color is not null) entity.Color = dto.Color;
            if (dto.OwnerName is not null) entity.OwnerName = dto.OwnerName;
            if (dto.PhoneNumber is not null) entity.PhoneNumber = dto.PhoneNumber;

            await repo.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}