using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ParkingManagement.Application.DTOs;

namespace ParkingManagement.Application.Features.ParkingLog.Requests.Commands;

public class UpdateParkingLogRequest : IRequest
{
    public UpdateParkingLogDTO UpdateParkingLogDTO { get; set; }
}
