using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.Features.ParkingLog.Requests.Commands;
using ParkingManagement.Domain;

namespace ParkingManagement.Application.Features.ParkingLog.Handlers.Commands;

internal class CreateParkingLogRequestHandler : IRequestHandler<CreateParkingLogRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateParkingLogRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task Handle(CreateParkingLogRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.ParkingLogRepository;
        var log = _mapper.Map<Domain.ParkingLog>(request.CreateParkingLogDTO);
        await repository.AddAsync(log);
    }
}
