using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.Features.ParkingLog.Requests.Commands;

namespace ParkingManagement.Application.Features.ParkingLog.Handlers.Commands;

internal class UpdateParkingLogRequestHandler : IRequestHandler<UpdateParkingLogRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateParkingLogRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task Handle(UpdateParkingLogRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.ParkingLogRepository;
        var dto = request.UpdateParkingLogDTO;
        var log = await repository.GetAsync(dto.Id);
        log.ExitTime = dto.ExitTime;
        log.Cost = dto.Cost;
        log.Status = dto.Status;
        log.Notes = dto.Notes;
        await repository.UpdateAsync(log);
    }
}
