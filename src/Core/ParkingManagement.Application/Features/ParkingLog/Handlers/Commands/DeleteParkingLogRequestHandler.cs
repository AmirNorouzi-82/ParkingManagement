using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.Features.ParkingLog.Requests.Commands;

namespace ParkingManagement.Application.Features.ParkingLog.Handlers.Commands;

internal class DeleteParkingLogRequestHandler : IRequestHandler<DeleteParkingLogRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DeleteParkingLogRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task Handle(DeleteParkingLogRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.ParkingLogRepository.DeleteAsync(request.DeleteParkingLogDTO.Id);
    }
}
