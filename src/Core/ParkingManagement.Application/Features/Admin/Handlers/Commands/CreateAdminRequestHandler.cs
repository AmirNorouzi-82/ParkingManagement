using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.Features.Admin.Requests.Commands;
using ParkingManagement.Domain;

namespace ParkingManagement.Application.Features.Admin.Handlers.Commands;

internal class CreateAdminRequestHandler : IRequestHandler<CreateAdminRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateAdminRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task Handle(CreateAdminRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.AdminRepository;
        var admin = _mapper.Map<Domain.Admin>(request.CreateAdminDTO);
        await repository.AddAsync(admin);
    }
}
