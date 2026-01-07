using AutoMapper;
using MediatR;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.Features.ParkingSpot.Requests.Commands;
using ParkingManagement.Domain;

namespace ParkingManagement.Application.Features.ParkingSpot.Handlers.Commands
{
    internal class CreateParkingSpotRequestHandler : IRequestHandler<CreateParkingSpotRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateParkingSpotRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(CreateParkingSpotRequest request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.ParkingSpotRepository;

            var spot = _mapper.Map<ParkingManagement.Domain.ParkingSpot>(request.CreateParkingSpotDTO);

            await repo.AddAsync(spot);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}