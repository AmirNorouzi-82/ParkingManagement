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

internal class GetParkingLogByIdRequestHandler : IRequestHandler<GetParkingLogByIdRequest, ParkingLogDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetParkingLogByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ParkingLogDTO> Handle(GetParkingLogByIdRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.ParkingLogRepository;
        var log = await repository.GetAsync(request.Id);
        var dto = _mapper.Map<ParkingLogDTO>(log);
        return dto;
    }
}
