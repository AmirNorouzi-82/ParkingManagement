using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ParkingManagement.Application.DTOs;

namespace ParkingManagement.Application.Features.Admin.Requests.Commands;

public class CreateAdminRequest : IRequest
{
    public CreateAdminDTO CreateAdminDTO { get; set; }
}
