using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Features.ParkingLog.Requests.Queries;

namespace ParkingManagement.Application.Features.ParkingLog.Handlers.Queries;

internal class GetAllParkingLogsRequestHandler : IRequestHandler<GetAllParkingLogsRequest, List<ParkingLogDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllParkingLogsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<ParkingLogDTO>> Handle(GetAllParkingLogsRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.ParkingLogRepository;
        var logs = await repository.GetAllAsync();
        var dtos = _mapper.Map<List<ParkingLogDTO>>(logs);
        return dtos;
    }
}
