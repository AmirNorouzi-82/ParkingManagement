using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.Features.Admin.Requests.Commands;

namespace ParkingManagement.Application.Features.Admin.Handlers.Commands;

internal class DeleteAdminRequestHandler : IRequestHandler<DeleteAdminRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DeleteAdminRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task Handle(DeleteAdminRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.AdminRepository;
        await repository.DeleteAsync(request.DeleteAdminDTO.Id);
    }
}
