using MediatR;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.Features.Vehicle.Requests.Commands;

namespace ParkingManagement.Application.Features.Vehicle.Handlers.Commands
{
    internal class DeleteVehicleRequestHandler : IRequestHandler<DeleteVehicleRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVehicleRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteVehicleRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.VehicleRepository.DeleteAsync(request.DeleteVehicleDTO.Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}