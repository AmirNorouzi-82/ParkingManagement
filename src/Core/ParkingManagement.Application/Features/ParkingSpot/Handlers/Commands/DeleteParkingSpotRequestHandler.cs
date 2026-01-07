using MediatR;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.Features.ParkingSpot.Requests.Commands;

namespace ParkingManagement.Application.Features.ParkingSpot.Handlers.Commands
{
    internal class DeleteParkingSpotRequestHandler : IRequestHandler<DeleteParkingSpotRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteParkingSpotRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteParkingSpotRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.ParkingSpotRepository.DeleteAsync(request.DeleteParkingSpotDTO.Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}