using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ParkingManagement.Application.Contracts.Persistance;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Features.Admin.Requests.Commands;
using ParkingManagement.Domain;

namespace ParkingManagement.Application.Features.Admin.Handlers.Commands;

internal class UpdateAdminRequestHandler : IRequestHandler<UpdateAdminRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateAdminRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task Handle(UpdateAdminRequest request, CancellationToken cancellationToken)
    {
        var repository = _unitOfWork.AdminRepository;
        var dto = request.UpdateAdminDTO;
        var adminToUpdate = await repository.GetAsync(dto.Id);
        adminToUpdate.FullName = dto.FullName;
        adminToUpdate.Email = dto.Email;
        adminToUpdate.PasswordHash = dto.Password;
        adminToUpdate.IsActive = dto.IsActive;
        await repository.UpdateAsync(adminToUpdate);
    }
}
