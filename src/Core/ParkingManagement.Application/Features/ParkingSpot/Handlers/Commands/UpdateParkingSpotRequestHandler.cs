using AutoMapper;
using MediatR;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.Features.ParkingSpot.Requests.Commands;

namespace ParkingManagement.Application.Features.ParkingSpot.Handlers.Commands
{
    internal class UpdateParkingSpotRequestHandler : IRequestHandler<UpdateParkingSpotRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateParkingSpotRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateParkingSpotRequest request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.ParkingSpotRepository;
            var dto = request.UpdateParkingSpotDTO;

            var entity = await repo.GetAsync(dto.Id);
            if (entity == null) return;

            if (dto.Zone is not null) entity.Zone = dto.Zone;
            entity.IsAvailable = dto.IsAvailable;
            entity.IsReserved = dto.IsReserved;
            entity.Type = dto.Type;

            await repo.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}