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

internal class GetAdminByIdRequestHandler : IRequestHandler<GetAdminByIdRequest, AdminDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAdminByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AdminDTO> Handle(GetAdminByIdRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.AdminRepository;
        var admin = await repository.GetAsync(request.Id);
        var dto = _mapper.Map<AdminDTO>(admin);
        return dto;
    }
}
