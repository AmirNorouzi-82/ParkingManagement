using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Features.Admin.Requests.Queries;

namespace ParkingManagement.Application.Features.Admin.Handlers.Queries;

internal class GetAllAdminsRequestHandler : IRequestHandler<GetAllAdminsRequest, List<AdminDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllAdminsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<AdminDTO>> Handle(GetAllAdminsRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.AdminRepository;
        var admins = await repository.GetAllAsync();
        var dtos = _mapper.Map<List<AdminDTO>>(admins);
        return dtos;
    }
}
